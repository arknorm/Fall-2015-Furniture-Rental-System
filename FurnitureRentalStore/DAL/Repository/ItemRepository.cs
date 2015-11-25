using System;
using System.Collections.Generic;
using System.Configuration;
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
        /// <param name="anItem">An item.</param>
        public void Add(Item anItem)
        {

            const string query = "INSERT INTO ITEM VALUES(null, @category, @style, @color, @dailyRate, @fineRate, @quantity)";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(anItem, cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified a item.
        /// </summary>
        /// <param name="itemID">an itemID.</param>
        public void Delete(int itemID)
        {
            const string query = "DELETE FROM ITEM WHERE itemID = @itemID";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("itemID", itemID);

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
        /// Updates the specified a item.
        /// </summary>
        /// <param name="anItem">an item.</param>
        public void UpdateItem(Item anItem)
        {
            const string query = "UPDATE ITEM SET category = @category, style = @style, color = @color, dailyRate = @dailyRate, fineRate = @fineRate, quantity = @quantity WHERE itemID = @itemID";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(anItem, cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ParameterizeQuery(Item anItem, MySqlCommand cmd)
        {


            cmd.Parameters.Add("@itemID", MySqlDbType.Int32);
            cmd.Parameters.Add("@category", MySqlDbType.VarChar);
            cmd.Parameters.Add("@style", MySqlDbType.VarChar);
            cmd.Parameters.Add("@color", MySqlDbType.VarChar);
            cmd.Parameters.Add("@dailyRate", MySqlDbType.Double);
            cmd.Parameters.Add("@fineRate", MySqlDbType.Double);
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32);

            cmd.Parameters["@itemID"].Value = anItem.ItemID;
            cmd.Parameters["@category"].Value = anItem.Category;
            cmd.Parameters["@style"].Value = anItem.Style;
            cmd.Parameters["@color"].Value = anItem.Color;
            cmd.Parameters["@dailyRate"].Value = anItem.DailyRate;
            cmd.Parameters["@fineRate"].Value = anItem.FineRate;
            cmd.Parameters["@quantity"].Value = anItem.Quantity;

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the item by itemID.
        /// </summary>
        /// <param name="itemID">The item identifier.</param>
        /// <returns>
        /// The item with entered itemID.
        /// </returns>
        public Item GetById(int itemID)
        {
            var items = new List<Item>();
            var query = "select itemID, category, style, color, dailyRate, fineRate, quantity from ITEM where itemID = @itemID";

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
            const string query = "select itemID, category, style, color, dailyRate, fineRate, quantity from ITEM";

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
            var query = "select itemID, category, style, color, dailyRate, fineRate, quantity from ITEM where style = @style";

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
        /// Gets item by category.
        /// </summary>
        /// <returns>An item that matches entered category.</returns>
        public List<Item> GetBycategory(string category)
        {
            var items = new List<Item>();
            var query = "select itemID, category, style, color, dailyRate, fineRate, quantity from ITEM where category = @category";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("category", category);

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
                entity.Category = reader["category"].ToString();
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
