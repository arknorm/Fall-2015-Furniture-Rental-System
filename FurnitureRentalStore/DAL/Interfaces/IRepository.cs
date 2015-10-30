using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureRentalStore.DAL.Interfaces
{
    interface IRepository<T>
    {

        void Add(T entity);

        T GetById(int id);

        List<T> GetAll();
    }
}
