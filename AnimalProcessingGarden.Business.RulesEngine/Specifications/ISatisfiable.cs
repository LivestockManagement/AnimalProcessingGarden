using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalProcessingGarden.Business.RulesEngine.Specifications;

namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    public interface ISatisfiable
    {
        Outcome IsSatisfiedBy(IPackable package, Workflow workflow);
    }
}
