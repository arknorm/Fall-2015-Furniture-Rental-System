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

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        public Member GetByName(string fullName)
        {
           return this.repository.GetByName(fullName);
        }

        /// <summary>
        /// Gets the by phone.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public Member GetByPhone(string number)
        {
            return this.repository.GetByPhone(number);
        }
    }
}
