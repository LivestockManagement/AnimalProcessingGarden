using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Entities;
using AnimalProcessingGarden.Business.RulesEngine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor
{
    public class ProcessorPackage : IPackable
    {
        public IEntity Entity { get; set; }
    }
}
