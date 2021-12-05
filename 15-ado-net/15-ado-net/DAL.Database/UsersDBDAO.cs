using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Database
{
    public class UsersDBDAO : IUserDAO
    {
        private string _connectionString = "";

        public UsersDBDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateAndInitList()
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "CreateUsers";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            command.CommandText = "InitUsers";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
        public void Add(User user)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "InsertUser";
            command.CommandType = System.Data.CommandType.StoredProcedure;


            command.Parameters.Add("firstName", System.Data.SqlDbType.NVarChar).Value = user.FirstName;
            command.Parameters.Add("lastName", System.Data.SqlDbType.NVarChar).Value = user.LastName;
            command.Parameters.Add("birthdate", System.Data.SqlDbType.Date).Value = user.Birthdate;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Clear()
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "DELETE FROM dbo.UsersRewards";

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            command.CommandText = "DBCC CHECKIDENT ('dbo.Users', RESEED, -1)";

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            command.CommandText = "DELETE FROM dbo.Users";

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void ClearAndCopyRange(IEnumerable<User> users)
        {
            Clear();

            foreach (var user in users)
            {
                Add(user);
            }
        }

        public void Edit(User mainUser, User tempUser)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "UpdateUser";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("userId", System.Data.SqlDbType.Int).Value = mainUser.ID;
            command.Parameters.Add("firstName", System.Data.SqlDbType.NVarChar).Value = tempUser.FirstName;
            command.Parameters.Add("lastName", System.Data.SqlDbType.NVarChar).Value = tempUser.LastName;
            command.Parameters.Add("birthdate", System.Data.SqlDbType.Date).Value = tempUser.Birthdate;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            command.Parameters.Clear();

            foreach (var reward in mainUser.Rewards)
            {

                command.CommandText = "DeleteSelectedRewardByName";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("userId", System.Data.SqlDbType.Int).Value = mainUser.ID;
                command.Parameters.Add("rewardName", System.Data.SqlDbType.NVarChar).Value = reward;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

            command.Parameters.Clear();

            foreach (var reward in tempUser.Rewards)
            {

                command.CommandText = "SelectRewardByName";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("userId", System.Data.SqlDbType.Int).Value = mainUser.ID;
                command.Parameters.Add("rewardTitle", System.Data.SqlDbType.NVarChar).Value = reward;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

            connection.Close();
        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();


            command.CommandText = "GetUsers";

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var user = new User();
                user.ID = reader.GetInt32(0);
                user.FirstName = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Birthdate = reader.GetDateTime(3);

                users.Add(user);
            }

            connection.Close();

            command.Parameters.Clear();

            foreach (var user in users)
            {
                var userRewards = new List<string>();

                command.CommandText = "ReturnUserRewards " + user.ID.ToString();

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userRewards.Add(reader.GetString(0));
                }

                user.Rewards = userRewards.ToArray();

                connection.Close();
            }

            command.Parameters.Clear();

            connection.Close();

            return users;
        }

        public void Remove(User user)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "DeleteUser";
            command.CommandType = System.Data.CommandType.StoredProcedure;


            command.Parameters.Add("userId", System.Data.SqlDbType.Int).Value = user.ID;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}
