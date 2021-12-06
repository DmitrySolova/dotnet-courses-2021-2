using BLL;
using Entities;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Interfaces;

namespace Task
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        // интерфейсы для BL, т.к. мы можем переиспользовать логику
        private readonly IUserBL _usersBL;
        private readonly IRewardBL _rewardsBL;

        public MainForm(IUserBL userBL, IRewardBL rewardBL)
        {
            _usersBL = userBL;
            _rewardsBL = rewardBL;

            InitializeComponent();
        }

        private string[] ParseRewardsNames(IRewardBL rewards)
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
            dgvUsers.DataSource = _usersBL.GetUsers();
            dgvRewards.DataSource = _rewardsBL.GetRewards();
        }

        private void DisplayUsers()
        {
            dgvUsers.DataSource = null;
            //dgvUsers.DataSource = _usersBL.GetUsers();

            BindingSource bindingUsers = new BindingSource();
            bindingUsers.SuspendBinding();
            bindingUsers.DataSource = _usersBL.GetUsers();
            bindingUsers.ResumeBinding();

            dgvUsers.DataSource = bindingUsers;

        }

        private void DisplayRewards()
        {
            dgvRewards.DataSource = null;
            //dgvRewards.DataSource = _rewardsBL.GetRewards();

            BindingSource bindingRewards = new BindingSource();
            bindingRewards.SuspendBinding();
            bindingRewards.DataSource = _rewardsBL.GetRewards();
            bindingRewards.ResumeBinding();

            dgvRewards.DataSource = bindingRewards;
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
            string[] nameOfRewards = ParseRewardsNames(_rewardsBL);

            UserForm userForm = new UserForm(nameOfRewards);

            if (userForm.ShowDialog(this) == DialogResult.OK)
            {
                _usersBL.Add(userForm.FirstName, userForm.LastName, userForm.Birthdate, userForm.SelectedRewards);
                DisplayUsers();
            }
        }

        private void EditSelectedUser()
        {
            if (dgvUsers.SelectedCells.Count > 0)
            {
                User selectedUser = (User)dgvUsers.SelectedCells[0].OwningRow.DataBoundItem;

                string[] nameOfRewards = ParseRewardsNames(_rewardsBL);

                UserForm userForm = new UserForm(selectedUser, nameOfRewards);
                if (userForm.ShowDialog(this) == DialogResult.OK)
                {
                    var tempUser = new User(0, userForm.FirstName, userForm.LastName, userForm.Birthdate, userForm.SelectedRewards);

                    _usersBL.Edit(selectedUser, tempUser);
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
                    _usersBL.Remove(selectedUser);
                }

                DisplayUsers();
            }

        }

        private void CreateNewReward()
        {
            RewardForm rewardForm = new RewardForm();

            if (rewardForm.ShowDialog(this) == DialogResult.OK)
            {
                _rewardsBL.Add(rewardForm.Title, rewardForm.Description);
            }

            DisplayRewards();
        }

        private void EditSelectReward()
        {
            if (dgvRewards.SelectedCells.Count > 0)
            {
                Reward reward = (Reward)dgvRewards.SelectedCells[0].OwningRow.DataBoundItem;

                string rewardOldTitle = reward.Title;

                RewardForm rewardForm = new RewardForm(reward);
                if (rewardForm.ShowDialog(this) == DialogResult.OK)
                {
                    var tempReward = new Reward(0, rewardForm.Title, rewardForm.Description);

                    _rewardsBL.Edit(reward, tempReward);

                    foreach (var user in _usersBL.GetUsers())
                    {
                        int index = Array.IndexOf(user.Rewards, rewardOldTitle);

                        if (index != -1)
                        {
                            user.Rewards[index] = rewardForm.Title;
                        }

                    }

                    DisplayUsers();
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
                    _rewardsBL.Remove(reward);
                }
            }

            DisplayRewards();

            if (rewardString != "" && rewardString != null)
            {
                foreach (var user in _usersBL.GetUsers())
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

    }
}
