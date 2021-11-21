using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task
{
    public partial class UserForm : Form
    {
        private bool _createNew = true;

        public int ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthdate { get; private set; }

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(User user)
        {
            InitializeComponent();

            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;

            _createNew = false;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            lIDShow.Text = ID.ToString();
            tbFirstName.Text = FirstName;
            tbLastName.Text = LastName;

            if (_createNew)
            {
                Text = "Create new User";
                btnOK.Text = "Create";
            }
            else
            {
                Text = "Edit User";
                btnOK.Text = "Edit";
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            string input = tbFirstName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                epFirstName.SetError(tbFirstName, "Can't be null or empty");
                e.Cancel = true;
            }
            else if (input.Length > 50)
            {
                epFirstName.SetError(tbFirstName, "Can't be > 50 characters");
                e.Cancel = true;
            }
            else
            {
                epFirstName.SetError(tbFirstName, String.Empty);
                e.Cancel = false;
            }
        }

        private void tbFirstName_Validated(object sender, EventArgs e)
        {
            FirstName = tbFirstName.Text.Trim();
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            string input = tbLastName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                epLastName.SetError(tbLastName, "Can't be null or empty");
                e.Cancel = true;
            }
            else if (input.Length > 50)
            {
                epLastName.SetError(tbLastName, "Can't be > 50 characters");
                e.Cancel = true;
            }
            else
            {
                epLastName.SetError(tbLastName, String.Empty);
                e.Cancel = false;
            }
        }

        private void tbLastName_Validated(object sender, EventArgs e)
        {
            LastName = tbLastName.Text.Trim();
        }

        private void dtpBirthdate_Validating(object sender, CancelEventArgs e)
        {
            var input = dtpBirthdate.Value;

            if (User.CalculateAge(input) > 150)
            {
                epBirthdate.SetError(dtpBirthdate, "Can't be > 150 years");
                e.Cancel = true;
            }
            else if (DateTime.Compare(input, DateTime.Now) > 0)
            {
                epBirthdate.SetError(dtpBirthdate, "Cannot be less than the current date");
                e.Cancel = true;
            }
            else
            {
                epBirthdate.SetError(dtpBirthdate, String.Empty);
                e.Cancel = false;
            }
        }

        private void dtpBirthdate_Validated(object sender, EventArgs e)
        {
            Birthdate = dtpBirthdate.Value;
        }

        
    }
}
