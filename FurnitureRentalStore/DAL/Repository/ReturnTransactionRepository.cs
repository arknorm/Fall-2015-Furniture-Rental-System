using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Interfaces;
using FurnitureRentalStore.Model;
using MySql.Data.MySqlClient;

namespace FurnitureRentalStore.DAL.Repository
{
    class ReturnTransactionRepository : IRepository<ReturnTransaction>
    {
        private readonly string connectionString;
        private int returnTransactionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnTransactionRepository"/> class.
        /// </summary>
        public ReturnTransactionRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }
        public void Add(ReturnTransaction entity)
        {
            const string query = "INSERT INTO RETURN_TRANSACTION(employeeID, returnDate, totalPrice) VALUES(@employeeID, @returnDate, @totalPrice);select last_insert_id();";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(entity, cmd);
                        this.returnTransactionId = Convert.ToInt32(cmd.ExecuteScalar());
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
        /// <param name="aRental">a member.</param>
        /// <param name="cmd">The command.</param>
        private static void ParameterizeQuery(ReturnTransaction aRental, MySqlCommand cmd)
        {
            cmd.Parameters.Add("@employeeID", MySqlDbType.Int32);
            cmd.Parameters.Add("@returnDate", MySqlDbType.Date);
            cmd.Parameters.Add("@totalPrice", MySqlDbType.Double);

            cmd.Parameters["@employeeID"].Value = aRental.EmployeeId;
            cmd.Parameters["@returnDate"].Value = aRental.ReturnDate;
            cmd.Parameters["@totalPrice"].Value = aRental.TotalPrice;
        }

        public ReturnTransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReturnTransaction> GetAll()
        {
            return null;
        }

        public int GetInsertedID()
        {
            return this.returnTransactionId;
        }
    }
}
