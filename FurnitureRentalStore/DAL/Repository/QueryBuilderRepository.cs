using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FurnitureRentalStore.DAL.Repository
{
    class QueryBuilderRepository
    {

        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        public QueryBuilderRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        /// <summary>
        /// Gets data for entered query.
        /// </summary>
        /// <param name="aQuery">a query.</param>
        public DataTable GetQueryResults(string query)
        {

            var table = new DataTable();
            
            try
            {
                using (var conn = new MySqlDataAdapter(query, this.connectionString))
                {

                    using (var cmd = new MySqlCommandBuilder(conn))
                    {

                        table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                        conn.Fill(table);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return table;
        }
    }
}
