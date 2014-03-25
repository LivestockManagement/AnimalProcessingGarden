using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    public class Outcome
    {
        public Type SpecificationType { get; set; }
        public bool Result { get; set; }
        public List<Outcome> Outcomes;

        public Outcome()
        {
            Result = true;
            SpecificationType = typeof(WorkflowSpecification);
        }
    }
}
