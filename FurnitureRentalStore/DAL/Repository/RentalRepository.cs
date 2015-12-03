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
    class RentalRepository : IRepository<Rental>
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalRepository"/> class.
        /// </summary>
        public RentalRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Rental entity)
        {
            const string query = "INSERT INTO RENTAL VALUES(@rentalTransactionID, @itemID, @rentalTotal, @dueDate, @quantityRented)";
            string update = "UPDATE ITEM SET quantity=quantity-" + entity.QuantityRented + " WHERE itemID=" + entity.ItemId;

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(entity, cmd);

                    }

                    using (var noncmd = new MySqlCommand(update, conn))
                    {
                        noncmd.ExecuteNonQuery();
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
        private static void ParameterizeQuery(Rental aRental, MySqlCommand cmd)
        {
            cmd.Parameters.Add("@rentalTransactionID", MySqlDbType.Int32);
            cmd.Parameters.Add("@itemID", MySqlDbType.Int32);
            cmd.Parameters.Add("@rentalTotal", MySqlDbType.Double);
            cmd.Parameters.Add("@dueDate", MySqlDbType.DateTime);
            cmd.Parameters.Add("@quantityRented", MySqlDbType.Int32);

            cmd.Parameters["@rentalTransactionID"].Value = aRental.RentalTransactionId;
            cmd.Parameters["@itemID"].Value = aRental.ItemId;
            cmd.Parameters["@rentalTotal"].Value = aRental.RentalTotal;
            cmd.Parameters["@dueDate"].Value = aRental.DueDate;
            cmd.Parameters["@quantityRented"].Value = aRental.QuantityRented;

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Rental GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Rental> GetAll()
        {
            var rentals = new List<Rental>();
            const string query = "select * FROM RENTAL";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            PopulateTransactions(reader, rentals);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rentals;
        }
        /// <summary>
        /// Populates the members.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="transactions">The transactions.</param>
        private static void PopulateTransactions(MySqlDataReader reader, List<Rental> transactions)
        {
            while (reader.Read())
            {
                var entity = new Rental
                {
                    RentalTransactionId = Convert.ToInt32(reader["rentalTransactionID"].ToString()),
                    ItemId = Convert.ToInt32(reader["itemID"]),
                    RentalTotal = Convert.ToDouble(reader["rentalTotal"]),
                    DueDate = Convert.ToDateTime(reader["dueDate"]),
                    QuantityRented = Convert.ToInt32(reader["quantityRented"]),
                };
                transactions.Add(entity);
            }
        }
    }
}
