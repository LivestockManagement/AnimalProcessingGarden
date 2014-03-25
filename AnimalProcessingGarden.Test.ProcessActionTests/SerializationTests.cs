using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using AnimalProcessingGarden.Business.RulesEngine.Specifications;
using AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AnimalProcessingGarden.Test.ProcessActionTests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void generate_workflow_xml()
        {
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

            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(A.GetType());
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, A);
            string xml = textWriter.ToString();
            Debug.WriteLine(xml);

        }

        [TestMethod]
        public void all_files_workflow_xml()
        {
            Location location = new Location();
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow, Age = 30, Health = HealthStatus.Healthy, Location = location },
                Owner = new Account { Location = location }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;


            Workflow workflow;
            var serializer = new XmlSerializer(typeof(Workflow));
            foreach (string fileName in Directory.EnumerateFiles("../../Workflow Examples/", "*.xml"))
            {
                Debug.WriteLine("");
                Debug.WriteLine(fileName);
                using (var file = File.OpenText(fileName))
                {
                    workflow = (Workflow)serializer.Deserialize(file);
                }

                ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);
                Outcome outcome = spec.IsSatisfiedBy(package, workflow);

                OutcomeTests.DebugOutcome(outcome);

                Assert.IsTrue(outcome.Result);
            }
        }
    }
}
