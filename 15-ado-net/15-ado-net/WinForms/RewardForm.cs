using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task
{
    public partial class RewardForm : Form
    {
        private bool _createNew = true;
        public int ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public RewardForm()
        {
            InitializeComponent();
        }

        public RewardForm(Reward reward)
        {
            InitializeComponent();

            ID = reward.ID;
            Title = reward.Title;
            Description = reward.Description;

            _createNew = false;
        }

        private void RewardForm_Load(object sender, EventArgs e)
        {
            lIDShow.Text = ID.ToString();
            tbTitle.Text = Title;
            rtbDescription.Text = Description;

            if (_createNew)
            {
                Text = "Create new Reward";
                btnOK.Text = "Create";
            }
            else
            {
                Text = "Edit Reward";
                btnOK.Text = "Edit";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            string input = tbTitle.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                epTitle.SetError(tbTitle, "Can't be null or empty");
                e.Cancel = true;
            }
            else if (input.Length > 50)
            {
                epTitle.SetError(tbTitle, "Can't be > 50 characters");
                e.Cancel = true;
            }
            else
            {
                epTitle.SetError(tbTitle, String.Empty);
                e.Cancel = false;
            }
        }

        private void tbTitle_Validated(object sender, EventArgs e)
        {
            Title = tbTitle.Text.Trim();
        }

        private void rtbDescription_Validating(object sender, CancelEventArgs e)
        {
            string input = rtbDescription.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                epDescription.SetError(rtbDescription, "Can't be null or empty");
                e.Cancel = true;
            }
            else if (input.Length > 250)
            {
                epDescription.SetError(rtbDescription, "Can't be > 250 characters");
                e.Cancel = true;
            }
            else
            {
                epDescription.SetError(rtbDescription, String.Empty);
                e.Cancel = false;
            }
        }

        private void rtbDescription_Validated(object sender, EventArgs e)
        {
            Description = rtbDescription.Text.Trim();
        }
    }
}
