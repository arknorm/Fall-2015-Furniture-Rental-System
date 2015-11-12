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
    class ItemRepository : IRepository<Item>
    {

        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        public ItemRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        /// <summary>
        /// Adds the specified an item.
        /// </summary>
        /// <param name="anEmployee">An employee.</param>
        public void Add(Item anItem)
        {
        }

        /// <summary>
        /// Gets the item by itemID.
        /// </summary>
        /// <param name="anInt">An int.</param>
        /// <returns>The item with entered itemID.</returns>
        public Item GetById(int itemID)
        {
            var items = new List<Item>();
            var query = "select itemID, catagory, style, color, dailyRate, fineRate, quantity from ITEM where itemID = @itemID";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("itemID", itemID);

                        using (var reader = cmd.ExecuteReader())
                        {

                            this.populateItems(reader, items);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return items[0];
        }

        /// <summary>
        /// Gets List of all items.
        /// </summary>
        /// <returns>A list of all items</returns>
        public List<Item> GetAll()
        {
            var items = new List<Item>();
            var query ="select itemID, catagory, style, color, dailyRate, fineRate, quantity from ITEM";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {

                            this.populateItems(reader, items);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return items;
        }

        /// <summary>
        /// Gets item by style.
        /// </summary>
        /// <returns>An item that matches entered style.</returns>
        public List<Item> GetByStyle(string style)
        {
            var items = new List<Item>();
            var query = "select itemID, catagory, style, color, dailyRate, fineRate, quantity from ITEM where style = @style";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("style", style);

                        using (var reader = cmd.ExecuteReader())
                        {

                            this.populateItems(reader, items);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return items;
        }

        /// <summary>
        /// Gets item by catagory.
        /// </summary>
        /// <returns>An item that matches entered catagory.</returns>
        public List<Item> GetByCatagory(string catagory)
        {
            var items = new List<Item>();
            var query = "select itemID, catagory, style, color, dailyRate, fineRate, quantity from ITEM where catagory = @catagory";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("catagory", catagory);

                        using (var reader = cmd.ExecuteReader())
                        {

                            this.populateItems(reader, items);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return items;
        }



        private void populateItems(MySqlDataReader reader, List<Item> items)
        {
            while (reader.Read())
            {
                var entity = new Item();

                entity.ItemID = reader["itemID"] == DBNull.Value ? default(int) : (int) reader["itemID"];
                entity.Catagory = reader["catagory"].ToString();
                entity.Style = reader["style"].ToString();
                entity.Color = reader["color"].ToString();
                entity.DailyRate = reader["dailyRate"] == DBNull.Value ? default(double) : (double)reader["dailyRate"];
                entity.FineRate = reader["fineRate"] == DBNull.Value ? default(double) : (double)reader["fineRate"];
                entity.Quantity = reader["quantity"] == DBNull.Value ? default(int) : (int)reader["quantity"];

                items.Add(entity);
            }
        }
    }
}
