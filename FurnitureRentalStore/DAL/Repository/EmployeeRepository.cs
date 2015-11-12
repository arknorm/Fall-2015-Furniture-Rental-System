using System;
using System.Collections.Generic;
using System.Configuration;
using FurnitureRentalStore.DAL.Interfaces;
using FurnitureRentalStore.Model;
using MySql.Data.MySqlClient;

namespace FurnitureRentalStore.DAL.Repository
{
    class EmployeeRepository : IRepository<Employee>
    {

        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        public EmployeeRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        /// <summary>
        /// Adds the specified an employee.
        /// </summary>
        /// <param name="anEmployee">An employee.</param>
        public void Add(Employee anEmployee)
        {
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="anInt">An int.</param>
        /// <returns></returns>
        public Employee GetById(int anInt)
        {
            return null;
        }

        /// <summary>
        /// Gets List of employees by super SSN.
        /// </summary>
        /// <returns>A list of employees that have superssn that matches superssn</returns>
        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();
            var query ="select employeeID, firstName, lastName, isAdmin, username, password, email from EMPLOYEE";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {

                            this.populateEmployees(reader, employees);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return employees;
        }

        /// <summary>
        /// Gets employee that matches log in info.
        /// </summary>
        /// <returns>An employee that matches log in info</returns>
        public List<Employee> GetEmployeeForLogIn(string username, string password)
        {
            var employees = new List<Employee>();
            var query = "select employeeID, firstName, lastName, isAdmin, username, password, email from EMPLOYEE where username = @username AND password = @password";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);

                        using (var reader = cmd.ExecuteReader())
                        {

                            this.populateEmployees(reader, employees);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return employees;
        }



        private void populateEmployees(MySqlDataReader reader, List<Employee> employees)
        {
            while (reader.Read())
            {
                var entity = new Employee();

                entity.EmployeeId = reader["employeeID"] == DBNull.Value ? default(int) : (int) reader["employeeID"];
                entity.FirstName = reader["firstName"].ToString();
                entity.LastName = reader["lastName"].ToString();
                entity.IsAdmin = reader["isAdmin"] as bool? ?? false;
                entity.Username = reader["username"].ToString();
                entity.Password = reader["password"].ToString();
                entity.Email = reader["email"].ToString();

                employees.Add(entity);
            }
        }
    }
}
