using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Database
{
    public class RewardsDBDAO : IRewardDAO
    {
        string _connectionString = "";

        private int _id = 0;
        public int GenerateID()
        {
            return ++_id;
        }
        public RewardsDBDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Reward reward)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            // лучше использовать using
            command.CommandText = "InsertReward";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("title", System.Data.SqlDbType.NVarChar).Value = reward.Title;
            command.Parameters.Add("description", System.Data.SqlDbType.NVarChar).Value = reward.Description;

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

            command.CommandText = "DBCC CHECKIDENT ('dbo.Rewards', RESEED, 0)";

            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM dbo.Rewards";

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void ClearAndCopyRange(IEnumerable<Reward> rewards)
        {
            Clear();

            foreach (var reward in rewards)
            {
                Add(reward);
            }
        }

        public void Edit(Reward mainReward, Reward tempReward)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "UpdateReward";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("rewardId", System.Data.SqlDbType.Int).Value = mainReward.ID;
            command.Parameters.Add("title", System.Data.SqlDbType.NVarChar).Value = tempReward.Title;
            command.Parameters.Add("description", System.Data.SqlDbType.NVarChar).Value = tempReward.Description;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<Reward> GetRewards()
        {
            var rewards = new List<Reward>();

            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "GetRewards";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var reward = new Reward();
                reward.ID = reader.GetInt32(0);
                reward.Title = reader.GetString(1);
                reward.Description = reader.GetString(2);

                rewards.Add(reward);
            }

            connection.Close();

            return rewards;
        }

        public void Remove(Reward reward)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "DeleteReward";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("rewardId", System.Data.SqlDbType.Int).Value = reward.ID;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
