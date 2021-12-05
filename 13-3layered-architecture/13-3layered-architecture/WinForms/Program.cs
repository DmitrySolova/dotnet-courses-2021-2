using BLL;
using DAL.List;
using System;
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

            var rewardsDAO = new RewardsListDAO();
            var usersDAO = new UsersListDAO();

            var rewardListBL = new RewardListBL(rewardsDAO);
            var userListBL = new UserListBL(usersDAO);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(userListBL, rewardListBL));


        }
    }
}
