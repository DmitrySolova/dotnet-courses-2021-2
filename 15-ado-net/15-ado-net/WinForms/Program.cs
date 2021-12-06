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

            //var rewardsDAO = new RewardsListDAO();
            //var usersDAO = new UsersListDAO();

            var rewardBL = new RewardBL(rewardsDAO);
            var userBL = new UserBL(usersDAO);


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(userBL, rewardBL));


        }

    }
}
