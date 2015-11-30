using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using FurnitureRentalStore.DAL.Interfaces;
using FurnitureRentalStore.Model;
using MySql.Data.MySqlClient;

namespace FurnitureRentalStore.DAL.Repository
{
    internal class MemberRepository : IRepository<Member>
    {

        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// </summary>
        public MemberRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        /// <summary>
        /// Adds the specified a member.
        /// </summary>
        /// <param name="aMember">a member.</param>
        public void Add(Member aMember)
        {
            const string query = "INSERT INTO MEMBER VALUES(null, @ssn, @firstName, @lastName, @phone, @address1, @address2, @city, @state, @zip, @email)";
            Console.WriteLine(query);
            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {

                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(aMember, cmd);
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
        /// <param name="aMember">a member.</param>
        /// <param name="cmd">The command.</param>
        private static void ParameterizeQuery(Member aMember, MySqlCommand cmd)
        {
            cmd.Parameters.Add("@ssn", MySqlDbType.VarChar, 9);
            cmd.Parameters.Add("@firstName", MySqlDbType.VarChar);
            cmd.Parameters.Add("@lastName", MySqlDbType.VarChar);
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 10);
            cmd.Parameters.Add("@address1", MySqlDbType.VarChar);
            cmd.Parameters.Add("@address2", MySqlDbType.VarChar);
            cmd.Parameters.Add("@city", MySqlDbType.VarChar);
            cmd.Parameters.Add("@state", MySqlDbType.VarChar);
            cmd.Parameters.Add("@zip", MySqlDbType.VarChar, 5);
            cmd.Parameters.Add("@email", MySqlDbType.VarChar);

            cmd.Parameters["@ssn"].Value = aMember.Ssn;
            cmd.Parameters["@firstName"].Value = aMember.FirstName;
            cmd.Parameters["@lastName"].Value = aMember.LastName;
            cmd.Parameters["@phone"].Value = aMember.Phone;
            cmd.Parameters["@address1"].Value = aMember.Address1;
            cmd.Parameters["@address2"].Value = aMember.Address2;
            cmd.Parameters["@city"].Value = aMember.City;
            cmd.Parameters["@state"].Value = aMember.State;
            cmd.Parameters["@zip"].Value = aMember.Zip;
            cmd.Parameters["@email"].Value = aMember.Email;

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        public Member GetByName(string fullName)
        {
            var members = this.GetAll();
            foreach (var member in members)
            {
                string memberName = member.FirstName + " " + member.LastName;
                if (memberName == fullName)
                {
                    return member;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the by phone.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public Member GetByPhone(string phoneNumber)
        {
            var members = this.GetAll();
            foreach (var member in members)
            {
                if (member.Phone == phoneNumber)
                {
                    return member;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Member GetById(int index)
        {
            return this.GetAll()[index];
        }

        /// <summary>
        /// Gets List of members by super SSN.
        /// </summary>
        /// <returns>A list of members that have superssn that matches superssn</returns>
        public List<Member> GetAll()
        {
            var members = new List<Member>();
            const string query = "select * from MEMBER";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            PopulateMembers(reader, members);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return members;
        }

        /// <summary>
        /// Populates the members.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="members">The members.</param>
        private static void PopulateMembers(MySqlDataReader reader, List<Member> members)
        {
            while (reader.Read())
            {
                var entity = new Member
                {
                    MemberId = Convert.ToInt32(reader["memberID"]),
                    FirstName = reader["firstName"].ToString(),
                    LastName = reader["lastName"].ToString(),
                    Ssn = reader["ssn"].ToString(),
                    Phone = reader["phone#"].ToString(),
                    Address1 = reader["address1"].ToString(),
                    Address2 = reader["address2"].ToString(),
                    City = reader["city"].ToString(),
                    State = reader["state"].ToString(),
                    Zip = reader["zip"].ToString(),
                    Email = reader["email"].ToString()
                };

                members.Add(entity);
            }
        }
    }
}