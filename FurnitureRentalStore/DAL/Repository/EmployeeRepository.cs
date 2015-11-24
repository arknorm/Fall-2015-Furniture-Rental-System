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
        /// Gets the by identifier.
        /// </summary>
        /// <param name="anEmployee">An Employee.</param>
        /// <returns></returns>
        public Employee GetById(int employeeID)
        {
            var employees = new List<Employee>();

            var query = "select employeeID, firstName, lastName, isAdmin, username, password, email from EMPLOYEE where employeeID = @employeeID";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("employeeID", employeeID);

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

            return employees[0];
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

        /// <summary>
        /// Adds the specified a employee.
        /// </summary>
        /// <param name="anEmployee">a employee.</param>
        public void Add(Employee anEmployee)
        {
            const string query = "INSERT INTO EMPLOYEE VALUES(null, @firstName, @lastName, @isAdmin, @username, @password, @email)";
            
            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(anEmployee, cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the specified a employee.
        /// </summary>
        /// <param name="anEmployee">a employee.</param>
        public void UpdateEmployee(Employee anEmployee)
        {
            const string query = "UPDATE EMPLOYEE SET firstName = @firstName, lastName = @lastName, isAdmin = @isAdmin, username = @username, password = @password, email = @email WHERE employeeID = @employeeID";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(anEmployee, cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Parameterizes the query.
        /// </summary>
        /// <param name="anEmployee">an Employee.</param>
        /// <param name="cmd">The command.</param>
        private static void ParameterizeQuery(Employee anEmployee, MySqlCommand cmd)
        {


            cmd.Parameters.Add("@employeeID", MySqlDbType.Int32);
            cmd.Parameters.Add("@firstName", MySqlDbType.VarChar);
            cmd.Parameters.Add("@lastName", MySqlDbType.VarChar);
            cmd.Parameters.Add("@isAdmin", MySqlDbType.Bit);
            cmd.Parameters.Add("@username", MySqlDbType.VarChar);
            cmd.Parameters.Add("@password", MySqlDbType.VarChar);
            cmd.Parameters.Add("@email", MySqlDbType.VarChar);

            cmd.Parameters["@employeeID"].Value = anEmployee.EmployeeId;
            cmd.Parameters["@firstName"].Value = anEmployee.FirstName;
            cmd.Parameters["@lastName"].Value = anEmployee.LastName;
            cmd.Parameters["@isAdmin"].Value = anEmployee.IsAdmin;
            cmd.Parameters["@username"].Value = anEmployee.Username;
            cmd.Parameters["@password"].Value = anEmployee.Password;
            cmd.Parameters["@email"].Value = anEmployee.Email;

            cmd.ExecuteNonQuery();
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
