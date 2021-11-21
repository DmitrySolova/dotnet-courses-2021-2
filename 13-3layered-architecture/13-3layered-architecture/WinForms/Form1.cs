using BLL;
using Entities;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;

namespace Task
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private readonly UserBL usersBL;
        private readonly RewardBL rewardsBL;

        public Form1()
        {
            usersBL = new UserBL();
            rewardsBL = new RewardBL();

            InitializeComponent();
        }

        private string[] ParseRewardsNames(RewardBL rewards)
        {
            var rewardsList = rewards.GetRewards().ToList();

            string[] names = new string[rewardsList.Count];

            for (int i = 0; i < rewardsList.Count; i++)
            {
                names[i] = rewardsList[i].Title;
            }

            return names;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dgvUsers.DataSource = usersBL.InitList();
            dgvRewards.DataSource = rewardsBL.InitList();
            //SortUserByIDAsc();

        }

        private void DisplayUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = usersBL.GetUsers();
        }

        private void DisplayRewards()
        {
            dgvRewards.DataSource = null;
            dgvRewards.DataSource = rewardsBL.GetRewards();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            var tab = this.tcForm1.SelectedTab.Text;

            if (tab == "Users")
            {
                RegisterNewUser();
            }
            if (tab == "Rewards")
            {
                CreateNewReward();
            }

        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            var tab = this.tcForm1.SelectedTab.Text;

            if (tab == "Users")
            {
                EditSelectedUser();
            }
            if (tab == "Rewards")
            {
                EditSelectReward();
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            var tab = this.tcForm1.SelectedTab.Text;

            if (tab == "Users")
            {
                RemoveSelectedUser();
            }
            if (tab == "Rewards")
            {
                RemoveSelectedReward();
            }
        }

        private void RegisterNewUser()
        {
            string[] nameOfRewards = ParseRewardsNames(rewardsBL);

            UserForm userForm = new UserForm(nameOfRewards);

            if (userForm.ShowDialog(this) == DialogResult.OK)
            {
                usersBL.Add(userForm.FirstName, userForm.LastName, userForm.Birthdate, userForm.SelectedRewards);
                DisplayUsers();
            }
        }

        private void EditSelectedUser()
        {
            if (dgvUsers.SelectedCells.Count > 0)
            {
                User selectedUser = (User)dgvUsers.SelectedCells[0].OwningRow.DataBoundItem;

                string[] nameOfRewards = ParseRewardsNames(rewardsBL);

                UserForm userForm = new UserForm(selectedUser, nameOfRewards);
                if (userForm.ShowDialog(this) == DialogResult.OK)
                {
                    usersBL.EditFirstName(selectedUser, userForm.FirstName);
                    usersBL.EditLastName(selectedUser, userForm.LastName);
                    usersBL.EditBirthdate(selectedUser, userForm.Birthdate);
                    usersBL.EditRewards(selectedUser, userForm.SelectedRewards);
                }

                DisplayUsers();
            }
        }

        private void RemoveSelectedUser()
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this item?", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                if (dgvUsers.SelectedCells.Count > 0)
                {
                    User selectedUser = (User)dgvUsers.SelectedCells[0].OwningRow.DataBoundItem;
                    usersBL.Remove(selectedUser);
                }

                DisplayUsers();
            }

        }

        private void CreateNewReward()
        {
            RewardForm rewardForm = new RewardForm();

            if (rewardForm.ShowDialog(this) == DialogResult.OK)
            {
                rewardsBL.Add(rewardForm.Title, rewardForm.Description);
            }

            DisplayRewards();
        }

        private void EditSelectReward()
        {
            if (dgvRewards.SelectedCells.Count > 0)
            {
                Reward reward = (Reward)dgvRewards.SelectedCells[0].OwningRow.DataBoundItem;

                RewardForm rewardForm = new RewardForm(reward);
                if (rewardForm.ShowDialog(this) == DialogResult.OK)
                {
                    rewardsBL.EditTitle(reward, rewardForm.Title);
                    rewardsBL.EditDescription(reward, rewardForm.Description);
                }
            }

            DisplayRewards();
        }

        private void RemoveSelectedReward()
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this reward?", "Delete this reward?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string rewardString = "";
            if (dialogResult == DialogResult.OK)
            {
                if (dgvRewards.SelectedCells.Count > 0)
                {
                    Reward reward = (Reward)dgvRewards.SelectedCells[0].OwningRow.DataBoundItem;
                    rewardString = reward.Title;
                    rewardsBL.Remove(reward);
                }
            }

            DisplayRewards();

            if (rewardString != "" && rewardString != null)
            {
                foreach (var user in usersBL.GetUsers())
                {
                    int index = Array.IndexOf(user.Rewards, rewardString);

                    if (index != -1)
                    {
                        user.Rewards[index] = "";
                    }

                }

                DisplayUsers();
            }

        }

        private void dgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                usersBL.SortUserByIDAsc();
            }
            if (e.ColumnIndex == 1)
            {
                usersBL.SortUserByFirstNameAsc();
            }
            if (e.ColumnIndex == 2)
            {
                usersBL.SortUserByLastNameAsc();
            }
            if (e.ColumnIndex == 3)
            {
                usersBL.SortUserByBirthdateAsc();
            }
            if (e.ColumnIndex == 4)
            {
                usersBL.SortUserByAgeeAsc();
            }

            DisplayUsers();
        }

        private void dgvUsers_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                usersBL.SortUserByIDDesc();
            }
            if (e.ColumnIndex == 1)
            {
                usersBL.SortUserByFirstNameDesc();
            }
            if (e.ColumnIndex == 2)
            {
                usersBL.SortUserByLastNameDesc();
            }
            if (e.ColumnIndex == 3)
            {
                usersBL.SortUserByBirthdateDesc();
            }
            if (e.ColumnIndex == 4)
            {
                usersBL.SortUserByAgeDesc();
            }

            DisplayUsers();
        }

        private void dgvRewards_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                rewardsBL.SortRewardByIDAsc();
            }
            if (e.ColumnIndex == 1)
            {
                rewardsBL.SortRewardByTitleAsc();
            }

            DisplayRewards();
        }

        private void dgvRewards_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                rewardsBL.SortRewardByIDDesc();
            }
            if (e.ColumnIndex == 1)
            {
                rewardsBL.SortRewardByTitleDesc();
            }

            DisplayRewards();
        }

    }
}
