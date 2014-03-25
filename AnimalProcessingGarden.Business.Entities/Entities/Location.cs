using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Business.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Account Account { get; set; }
    }
}
