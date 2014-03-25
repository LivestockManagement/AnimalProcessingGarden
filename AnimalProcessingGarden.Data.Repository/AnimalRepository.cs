using AnimalProcessingGarden.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Data.Repository
{
    public class AnimalRepository : IRepository<Animal>
    {
        List<Animal> animals = new List<Animal>(); // Mock Repository

        public Animal Add(Animal animal)
        {
            animal.Id = animals.Count + 1;
            animals.Add(animal);
            return animal;
        }

        public List<Animal> GetAll()
        {
            return animals;
        }

        public Animal Get(int id)
        {
            return animals.Find(x => x.Id == id);
        }

        public void Remove(Animal animal)
        {
            animals.Remove(animal);
        }
    }
}
