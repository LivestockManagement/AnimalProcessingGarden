using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalProcessingGarden.Data.Repository;
using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using AnimalProcessingGarden.Business.RulesEngine.Specifications;
using AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Reflection;


namespace AnimalProcessingGarden.Test.ProcessActions
{
    [TestClass]
    public class SpecificationTests
    {

        [TestMethod]
        public void single_spec()
        {
            ProcessAction processAction = new ProcessAction
            {
                Animal = new Animal { Species = Species.Cow }
            };

            IPackable package = new ProcessorPackage();
            package.Entity = processAction;

            Workflow workflow = new Workflow();
            workflow.SpecificationName = "Processor.CowSpecification";
            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);

            Outcome outcome = spec.IsSatisfiedBy(package, workflow);

            // Do we want to hardcode the resulting actions for a given outcome set?
            // 


            Assert.IsTrue(outcome.Result);
        }
    }
}
