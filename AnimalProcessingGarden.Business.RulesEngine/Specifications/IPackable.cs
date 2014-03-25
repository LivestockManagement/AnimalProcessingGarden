using AnimalProcessingGarden.Business.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    public interface IPackable
    {
        IEntity Entity { get; set; }
    }
}
