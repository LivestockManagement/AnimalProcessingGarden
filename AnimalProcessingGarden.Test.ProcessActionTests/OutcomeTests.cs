using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using AnimalProcessingGarden.Business.RulesEngine.Specifications;
using AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor;
using AnimalProcessingGarden.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Test.ProcessActionTests
{
    [TestClass]
    public class OutcomeTests
    {
        [TestMethod]
        public void conditional_or_fail()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Goat, Age = 30 }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();

            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.CowSpecification" });
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.YoungSpecification" });

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsFalse(outcome.Result);
        }

        [TestMethod]
        public void nested_waterfall_outcomes()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow, Age = 10, Health = HealthStatus.Healthy }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow cowWorkflow = new Workflow { SpecificationName = "Processor.CowSpecification" };
            Workflow healthyWorkflow = new Workflow { SpecificationName = "Processor.HealthySpecification" };
            Workflow youngWorkflow = new Workflow { SpecificationName = "Processor.YoungSpecification" };


            Workflow A = new Workflow();
            A.Workflows.Add(cowWorkflow);

            Workflow B = new Workflow();
            B.Workflows.Add(healthyWorkflow);

            Workflow C = new Workflow();
            C.Workflows.Add(youngWorkflow);

            B.Workflows.Add(C);
            A.Workflows.Add(B);

            ISatisfiable spec = SpecificationFactory.GetSpecification(A);
            Outcome outcome = spec.IsSatisfiedBy(package, A);

            DebugOutcome(outcome);

            Assert.IsTrue(outcome.Result);
        }

        [TestMethod]
        public void nested_conditional_outcomes()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow, Age = 10, Health = HealthStatus.Sick }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow cowWorkflow = new Workflow { SpecificationName = "Processor.CowSpecification" };
            Workflow healthyWorkflow = new Workflow { SpecificationName = "Processor.HealthySpecification" };
            Workflow youngWorkflow = new Workflow { SpecificationName = "Processor.YoungSpecification" };


            Workflow A = new Workflow();
            A.Workflows.Add(cowWorkflow);

            Workflow B = new Workflow();
            B.GroupCondition = "Or";
            B.Workflows.Add(healthyWorkflow);
            B.Workflows.Add(youngWorkflow);

            A.Workflows.Add(B);

            ISatisfiable spec = SpecificationFactory.GetSpecification(A);
            Outcome outcome = spec.IsSatisfiedBy(package, A);

            
            DebugOutcome(outcome);

            Assert.IsTrue(outcome.Result);
        }

        public static void DebugOutcome(Outcome outcome)
        {
            
            Debug.WriteLine(string.Format("[{0}] {1}", outcome.Result, outcome.SpecificationType.Name));
            if (outcome.Outcomes != null)
            {
                foreach (Outcome o in outcome.Outcomes)
                {
                    DebugOutcome(o);
                }
            }
        }
    }
}
