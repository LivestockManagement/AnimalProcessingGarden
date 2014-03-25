using AnimalProcessingGarden.Business.RulesEngine.Specifications;
using AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Test.ProcessActionTests
{
    [TestClass]
    public class SpecificationFactoryTests
    {
        [TestMethod]
        public void specification_factory()
        {

            Workflow workflow = new Workflow();
            workflow.GroupCondition = "And";
            workflow.SpecificationName = "Processor.CowSpecification";

            ISatisfiable spec = SpecificationFactory.GetSpecification(workflow);

            Assert.IsTrue(spec is CowSpecification);
        }
    }
}
