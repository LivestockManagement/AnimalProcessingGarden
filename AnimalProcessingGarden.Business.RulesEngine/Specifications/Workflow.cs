using System.Collections.Generic;
namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    public class Workflow
    {
        public string SpecificationName { get; set; }
        public string GroupCondition { get; set; }
        public List<Workflow> Workflows;

        public Workflow()
        {
            SpecificationName = "WorkflowSpecification";
            GroupCondition = "And";
            Workflows = new List<Workflow>();
        }
    }
}
