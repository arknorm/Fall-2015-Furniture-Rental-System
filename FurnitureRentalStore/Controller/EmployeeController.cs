using System.Collections.Generic;
using FurnitureRentalStore.DAL.Repository;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.Controller
{
    /// <summary>
    /// This class is a Controller to connect Employee with the Form.
    /// </summary>
    class EmployeeController
    {

        private readonly EmployeeRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        public EmployeeController()
        {
            this.repository = new EmployeeRepository();
        }

        public List<Employee> GetAllEmployees()
        {
            return this.repository.GetAll();
        }
    }
}
