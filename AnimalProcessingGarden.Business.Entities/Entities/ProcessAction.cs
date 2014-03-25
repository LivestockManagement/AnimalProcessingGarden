using AnimalProcessingGarden.Business.Entities.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Business.Entities
{
    public class ProcessAction : IEntity
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Animal Animal { get; set; }
        public ActionType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public Account Owner { get; set; }

        public void Accept()
        { 
            // Save to database.

        }

        public void Reject()
        {
            // Save to database.
        }

        public Account GetAccount()
        {
            return Location.Account;
        }
    }
}
