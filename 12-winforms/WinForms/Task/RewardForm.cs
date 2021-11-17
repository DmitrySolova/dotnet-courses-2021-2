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
    }
}
