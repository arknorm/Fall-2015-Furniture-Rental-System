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
    class ReturnRepository : IRepository<Return>
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnRepository"/> class.
        /// </summary>
        public ReturnRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }
        public void Add(Return entity)
        {
            const string query = "INSERT INTO RENTAL VALUES(@rentalTransactionID, @itemID, @rentalTotal, @dueDate, @quantityRented)";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Return GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Return> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
