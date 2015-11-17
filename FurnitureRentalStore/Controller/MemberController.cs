using System.Collections.Generic;
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
            this.repository = new MemberRepository();
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        public List<Member> GetAllEmployees()
        {
            return this.repository.GetAll();
        }

        /// <summary>
        /// Adds the specified a member.
        /// </summary>
        /// <param name="aMember">a member.</param>
        public void Add(Member aMember)
        {
            this.repository.Add(aMember);
        }
    }
}
