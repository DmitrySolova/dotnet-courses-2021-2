using BLL;
using DAL.Database;
using DAL.List;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Task
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "localhost";
            connectionStringBuilder.InitialCatalog = "14-database-basics";
            connectionStringBuilder.IntegratedSecurity = true;

            var connectionString = connectionStringBuilder.ToString();

            var rewardsDAO = new RewardsDBDAO(connectionString);
            var usersDAO = new UsersDBDAO(connectionString);

            DeleteTables(connectionString);

            usersDAO.CreateAndInitList();
            rewardsDAO.CreateAndInitList();

            var rewardListBL = new RewardDBBL(rewardsDAO);
            var userListBL = new UserDBBL(usersDAO);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(userListBL, rewardListBL));


        }

        static void DeleteTables(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();

            command.CommandText = "DeleteAllTables";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
