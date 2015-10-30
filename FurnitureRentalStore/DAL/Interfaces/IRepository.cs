using System.Collections.Generic;

namespace FurnitureRentalStore.DAL.Interfaces
{
    interface IRepository<T>
    {

        void Add(T entity);

        T GetById(int id);

        List<T> GetAll();
    }
}
