using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureRentalStore.Model
{
    class Employee
    {

        /// <summary>
        /// Gets or sets the EmployeeID.
        /// </summary>
        /// <value>
        /// The EmployeeID.
        /// </value>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets if the employee is an admin.
        /// </summary>
        /// <value>
        /// True if admin. False if not.
        /// </value>
        public bool isAdmin { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the employee's password.
        /// </summary>
        /// <value>
        /// The employee's password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the employee's email.
        /// </summary>
        /// <value>
        /// The employee's email.
        /// </value>
        public string Email { get; set; }
    }
}
