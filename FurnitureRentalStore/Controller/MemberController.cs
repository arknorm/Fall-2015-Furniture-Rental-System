using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Repository;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.Controller
{
    class MemberController
    {
        private readonly MemberRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        public MemberController()
        {
            repository = new MemberRepository();
        }

        public List<Member> GetAllEmployees()
        {
            return this.repository.GetAll();
        }

        public void Add(Member aMember)
        {
            this.repository.Add(aMember);
        }
    }
}
