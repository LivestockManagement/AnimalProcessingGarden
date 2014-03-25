using AnimalProcessingGarden.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Data.Repository
{
    public interface IRepository<T>
    {
        T Add(T animal);
        T Get(int id);
        List<T> GetAll();
        void Remove(T entity);
    }
}
