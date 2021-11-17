
namespace Task1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tcForm = new System.Windows.Forms.TabControl();
            this.Users = new System.Windows.Forms.TabPage();
            this.Rewards = new System.Windows.Forms.TabPage();
            this.dgvRewards = new System.Windows.Forms.DataGridView();
            this.msForm = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tcForm.SuspendLayout();
            this.Users.SuspendLayout();
            this.Rewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRewards)).BeginInit();
            this.msForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(6, 6);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 25;
            this.dgvUsers.Size = new System.Drawing.Size(891, 430);
            this.dgvUsers.TabIndex = 0;
            // 
            // tcForm
            // 
            this.tcForm.Controls.Add(this.Users);
            this.tcForm.Controls.Add(this.Rewards);
            this.tcForm.Location = new System.Drawing.Point(12, 82);
            this.tcForm.Name = "tcForm";
            this.tcForm.SelectedIndex = 0;
            this.tcForm.Size = new System.Drawing.Size(911, 400);
            this.tcForm.TabIndex = 1;
            // 
            // Users
            // 
            this.Users.Controls.Add(this.dgvUsers);
            this.Users.Location = new System.Drawing.Point(4, 24);
            this.Users.Name = "Users";
            this.Users.Padding = new System.Windows.Forms.Padding(3);
            this.Users.Size = new System.Drawing.Size(903, 372);
            this.Users.TabIndex = 0;
            this.Users.Text = "Users";
            this.Users.UseVisualStyleBackColor = true;
            // 
            // Rewards
            // 
            this.Rewards.Controls.Add(this.dgvRewards);
            this.Rewards.Location = new System.Drawing.Point(4, 24);
            this.Rewards.Name = "Rewards";
            this.Rewards.Padding = new System.Windows.Forms.Padding(3);
            this.Rewards.Size = new System.Drawing.Size(903, 372);
            this.Rewards.TabIndex = 1;
            this.Rewards.Text = "Rewards";
            this.Rewards.UseVisualStyleBackColor = true;
            // 
            // dgvRewards
            // 
            this.dgvRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRewards.Location = new System.Drawing.Point(6, 6);
            this.dgvRewards.Name = "dgvRewards";
            this.dgvRewards.RowTemplate.Height = 25;
            this.dgvRewards.Size = new System.Drawing.Size(891, 430);
            this.dgvRewards.TabIndex = 0;
            // 
            // msForm
            // 
            this.msForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.msForm.Location = new System.Drawing.Point(0, 0);
            this.msForm.Name = "msForm";
            this.msForm.Size = new System.Drawing.Size(935, 24);
            this.msForm.TabIndex = 2;
            this.msForm.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreate,
            this.tsmiEdit,
            this.tsmiRemove});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiCreate
            // 
            this.tsmiCreate.Name = "tsmiCreate";
            this.tsmiCreate.Size = new System.Drawing.Size(180, 22);
            this.tsmiCreate.Text = "Создать";
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(180, 22);
            this.tsmiEdit.Text = "Редактировать";
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(180, 22);
            this.tsmiRemove.Text = "Удалить";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 494);
            this.Controls.Add(this.tcForm);
            this.Controls.Add(this.msForm);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tcForm.ResumeLayout(false);
            this.Users.ResumeLayout(false);
            this.Rewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRewards)).EndInit();
            this.msForm.ResumeLayout(false);
            this.msForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TabControl tcForm;
        private System.Windows.Forms.TabPage Users;
        private System.Windows.Forms.TabPage Rewards;
        private System.Windows.Forms.DataGridView dgvRewards;
        private System.Windows.Forms.MenuStrip msForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;
    }
}

