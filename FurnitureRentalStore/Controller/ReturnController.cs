using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Repository;

namespace FurnitureRentalStore.Controller
{
    class ReturnController
    {
        private ReturnRepository returnRepository;

        public ReturnController()
        {
            this.returnRepository = new ReturnRepository();
        }

       
    }
}
