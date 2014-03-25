using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using AnimalProcessingGarden.Business.RulesEngine.Specifications;
using AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor;
using AnimalProcessingGarden.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Test.ProcessActionTests
{
    [TestClass]
    public class WorkflowTests
    {

        [TestMethod]
        public void single_workflow_spec()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();
            workflow.GroupCondition = "And";
            workflow.SpecificationName = "Processor.CowSpecification";

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);

            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsTrue(outcome.Result);
        }

        [TestMethod]
        public void nested_workflow_spec()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow, Age = 20 }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow cowWorkflow = new Workflow { SpecificationName = "Processor.CowSpecification" };
            Workflow youngWorkflow = new Workflow { SpecificationName = "Processor.YoungSpecification" };
            cowWorkflow.Workflows.Add(youngWorkflow);

            Workflow workflow = new Workflow();
            workflow.Workflows.Add(cowWorkflow);

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsTrue(outcome.Result);
        }

        [TestMethod]
        public void conditional_spec_and()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow, Age = 10 }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();
            workflow.GroupCondition = "And";
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.CowSpecification" });
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.YoungSpecification" });

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsTrue(outcome.Result);
        }

        [TestMethod]
        public void conditional_spec_and_fail()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Goat, Age = 30 }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();
            workflow.GroupCondition = "And";
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.CowSpecification" });
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.YoungSpecification" });

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsFalse(outcome.Result);
        }

        [TestMethod]
        public void conditional_spec_or()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow, Age = 30 }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();
            workflow.GroupCondition = "Or";
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.CowSpecification" });
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.YoungSpecification" });

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsTrue(outcome.Result);
        }

        [TestMethod]
        public void conditional_spec_or_fail()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Goat, Age = 30 }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();
            workflow.GroupCondition = "Or";
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.CowSpecification" });
            workflow.Workflows.Add(new Workflow { SpecificationName = "Processor.YoungSpecification" });

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            Assert.IsTrue(outcome.Result);
        }
    }
}

