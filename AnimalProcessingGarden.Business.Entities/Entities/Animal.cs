using AnimalProcessingGarden.Business.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Entities;

namespace AnimalProcessingGarden.Business.Entities
{
    public class Animal : IEntity
    {
        public int Id { get; set; }
        public Species Species { get; set; }
        public Location Location { get; set; }
        public int Age { get; set; }
        public HealthStatus Health { get; set; }
        public List<ProcessAction> ProcessActions { get; set; }

        public Animal()
        {
            ProcessActions = new List<ProcessAction>();
        }
    }
}
