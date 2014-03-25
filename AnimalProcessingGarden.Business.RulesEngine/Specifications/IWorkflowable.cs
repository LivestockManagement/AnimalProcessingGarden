using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    public interface IWorkflowable
    {
        Workflow Workflow { get; set; }
    }
}
