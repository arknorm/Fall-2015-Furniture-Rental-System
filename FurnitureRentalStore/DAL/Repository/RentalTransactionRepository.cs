using System;
using System.Collections.Generic;
using System.Configuration;
using FurnitureRentalStore.DAL.Interfaces;
using FurnitureRentalStore.Model;
using MySql.Data.MySqlClient;

namespace FurnitureRentalStore.DAL.Repository
{
    internal class RentalTransactionRepository : IRepository<RentalTransaction>
    {
        private readonly string connectionString;

        private int returnTransactionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalRepository"/> class.
        /// </summary>
        public RentalTransactionRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        public void UpdateRentalTransactionPrice(double price)
        {

            var query = "UPDATE RENTAL_TRANSACTION SET totalPrice=" + price + " WHERE rentalTransactionID=" + this.GetTransactionId();

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the transaction identifier.
        /// </summary>
        /// <returns></returns>
        public int GetTransactionId()
        {
            return this.returnTransactionId;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(RentalTransaction entity)
        {
            const string query = "INSERT INTO RENTAL_TRANSACTION(employeeID, memberID, rentalDate, totalPrice) VALUES(@employeeID, @memberID, @date, @totalPrice);select last_insert_id();";

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
        /// <param name="aTransaction">a member.</param>
        /// <param name="cmd">The command.</param>
        private static void ParameterizeQuery(RentalTransaction aTransaction, MySqlCommand cmd)
        {
            cmd.Parameters.Add("@employeeID", MySqlDbType.Int32);
            cmd.Parameters.Add("@memberID", MySqlDbType.Int32);
            cmd.Parameters.Add("@date", MySqlDbType.Date);
            cmd.Parameters.Add("@totalPrice", MySqlDbType.Double);

            cmd.Parameters["@employeeID"].Value = aTransaction.EmployeeId;
            cmd.Parameters["@memberID"].Value = aTransaction.MemberId;
            cmd.Parameters["@date"].Value = aTransaction.Date;
            cmd.Parameters["@totalPrice"].Value = aTransaction.TotalPrice;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RentalTransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<RentalTransaction> GetAll()
        {
            var transactions = new List<RentalTransaction>();
            const string query = "select * from RENTAL_TRANSACTION";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            PopulateTransactions(reader, transactions);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return transactions;
        }

        /// <summary>
        /// Populates the members.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="transactions">The transactions.</param>
        private static void PopulateTransactions(MySqlDataReader reader, List<RentalTransaction> transactions)
        {
            while (reader.Read())
            {
                var entity = new RentalTransaction
                {
                    RentalTransactionId = Convert.ToInt32(reader["rentalTransactionID"].ToString()),
                    EmployeeId = Convert.ToInt32(reader["employeeID"]),
                    MemberId = Convert.ToInt32(reader["memberID"]),
                    Date = Convert.ToDateTime(reader["rentalDate"]),
                    TotalPrice = Convert.ToInt32(reader["totalPrice"]),
                };


                transactions.Add(entity);
            }
        }
    }
}
