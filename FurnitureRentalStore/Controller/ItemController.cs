using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Repository;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.Controller
{
    class ItemController
    {

        private readonly ItemRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        public ItemController()
        {
            this.repository = new ItemRepository();
        }

        public void UpdateItem(Item anItem)
        {
            this.repository.UpdateItem(anItem);
        }

        public void Add(Item anItem)
        {
            this.repository.Add(anItem);
        }

        public void DeleteItem(int itemID)
        {
            this.repository.Delete(itemID);
        }

        public List<Item> GetAllItems()
        {
            return this.repository.GetAll();
        }

        public Item GetById(int itemId)
        {
            return this.repository.GetById(itemId);
        }

        public List<Item> GetByStyle(string style)
        {
            return this.repository.GetByStyle(style);
        }

        public List<Item> GetBycategory(string category)
        {
            return this.repository.GetBycategory(category);
        }
    }
}
