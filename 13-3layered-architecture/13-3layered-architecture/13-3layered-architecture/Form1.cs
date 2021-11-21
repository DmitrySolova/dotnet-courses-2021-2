using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private int _id = 0;
        private enum SortMode { Asceding, Desceding };
        private SortMode _sortMode = SortMode.Asceding;

        private BindingList<User> _users = new BindingList<User>();
        private BindingList<Reward> _rewards = new BindingList<Reward>();
        public Form1()
        {
            InitializeComponent();
        }

        private int GenerateId()
        {
            return ++_id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _users.Add(new User(1, "яа", "а", new DateTime(2005, 12, 12)));
            _users.Add(new User(2, "Ая", "б", new DateTime(2002, 12, 12)));
            _users.Add(new User(2, "Ая", "б", new DateTime(2002, 12, 12)));

            _rewards.Add(new Reward(1, "sfsf", "sffss"));
            _rewards.Add(new Reward(2, "sfsf", "sffss"));
            _rewards.Add(new Reward(3, "sfsf", "sffss"));

            SortUserByIDAsc();

            dgvUsers.DataSource = _users;
            dgvRewards.DataSource = _rewards;
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            RegisterNewUser();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            EditSelectedUser();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedUser();
        }

        private void RegisterNewUser()
        {
            UserForm userForm = new UserForm();

            if (userForm.ShowDialog(this) == DialogResult.OK)
            {
                User user = new User(GenerateId());
                user.FirstName = userForm.FirstName;
                user.LastName = userForm.LastName;
                user.Birthdate = userForm.Birthdate;

                _users.Add(user);
            }

            _users.ResetBindings();
        }

        private void EditSelectedUser()
        {
            if (dgvUsers.SelectedCells.Count > 0)
            {
                User user = (User)dgvUsers.SelectedCells[0].OwningRow.DataBoundItem;

                UserForm userForm = new UserForm(user);
                if (userForm.ShowDialog(this) == DialogResult.OK)
                {
                    user.FirstName = userForm.FirstName;
                    user.LastName = userForm.LastName;
                    user.Birthdate = userForm.Birthdate;
                }
            }

            _users.ResetBindings();
        }

        private void RemoveSelectedUser()
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this item?", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                if (dgvUsers.SelectedCells.Count > 0)
                {
                    User student = (User)dgvUsers.SelectedCells[0].OwningRow.DataBoundItem;
                    _users.Remove(student);
                }
            }

            _users.ResetBindings();
        }

        private void dgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SortUserByIDAsc();
            }
            if (e.ColumnIndex == 1)
            {
                SortUserByFirstNameAsc();
            }
            if (e.ColumnIndex == 2)
            {
                SortUserByLastNameAsc();
            }
            if (e.ColumnIndex == 3)
            {
                SortUserByBirthdateAsc();
            }
            if (e.ColumnIndex == 4)
            {
                SortUserByAgeeAsc();
            }

            dgvUsers.DataSource = _users;


            _users.ResetBindings();
        }

        private void dgvUsers_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SortUserByIDDesc();
            }
            if (e.ColumnIndex == 1)
            {
                SortUserByFirstNameDesc();
            }
            if (e.ColumnIndex == 2)
            {
                SortUserByLastNameDesc();
            }
            if (e.ColumnIndex == 3)
            {
                SortUserByBirthdateDesc();
            }
            if (e.ColumnIndex == 4)
            {
                SortUserByAgeDesc();
            }

            dgvUsers.DataSource = _users;


            _users.ResetBindings();
        }

        private void SortUserByFirstNameAsc()
        {
            _users = new BindingList<User>(_users.OrderBy(s => s.FirstName).ToList());
        }

        private void SortUserByFirstNameDesc()
        {
            _users = new BindingList<User>(_users.OrderByDescending(s => s.FirstName).ToList());
        }

        private void SortUserByLastNameAsc()
        {
            _users = new BindingList<User>(_users.OrderBy(s => s.LastName).ToList());
        }

        private void SortUserByLastNameDesc()
        {
            _users = new BindingList<User>(_users.OrderByDescending(s => s.LastName).ToList());
        }

        private void SortUserByIDAsc()
        {
            _users = new BindingList<User>(_users.OrderBy(s => s.ID).ToList());
        }

        private void SortUserByIDDesc()
        {
            _users = new BindingList<User>(_users.OrderByDescending(s => s.ID).ToList());
        }

        private void SortUserByBirthdateAsc()
        {
            _users = new BindingList<User>(_users.OrderByDescending(s => s.Birthdate).ToList());
        }

        private void SortUserByBirthdateDesc()
        {
            _users = new BindingList<User>(_users.OrderBy(s => s.Birthdate).ToList());
        }

        private void SortUserByAgeeAsc()
        {
            _users = new BindingList<User>(_users.OrderBy(s => s.Age).ToList());
        }

        private void SortUserByAgeDesc()
        {
            _users = new BindingList<User>(_users.OrderByDescending(s => s.Age).ToList());
        }

        
    }
}
