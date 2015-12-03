using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Repository;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.Controller
{
    class ReturnController
    {
        private ReturnTransactionRepository returnTransactionRepository;
        private ReturnRepository returnRepository;

        public ReturnController()
        {
            this.returnTransactionRepository = new ReturnTransactionRepository();
            this.returnRepository = new ReturnRepository();
        }


        public int GetLastInsertedID()
        {
            return this.returnTransactionRepository.GetInsertedID();
        }

        public void Return(Return newReturn)
        {
            this.returnRepository.Add(newReturn);
        }

        public void Add(ReturnTransaction transaction)
        {
            this.returnTransactionRepository.Add(transaction);
        }
    }
}
