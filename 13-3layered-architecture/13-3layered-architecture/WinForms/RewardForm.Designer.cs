
namespace Task
{
    partial class RewardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lID = new System.Windows.Forms.Label();
            this.lIDShow = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.lDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.epTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDescription = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Location = new System.Drawing.Point(23, 40);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(18, 15);
            this.lID.TabIndex = 0;
            this.lID.Text = "ID";
            // 
            // lIDShow
            // 
            this.lIDShow.AutoSize = true;
            this.lIDShow.Location = new System.Drawing.Point(110, 40);
            this.lIDShow.Name = "lIDShow";
            this.lIDShow.Size = new System.Drawing.Size(50, 15);
            this.lIDShow.TabIndex = 1;
            this.lIDShow.Text = "lIDShow";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(23, 81);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(29, 15);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Title";
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Location = new System.Drawing.Point(23, 123);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(67, 15);
            this.lDescription.TabIndex = 3;
            this.lDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(110, 120);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(322, 149);
            this.rtbDescription.TabIndex = 4;
            this.rtbDescription.Text = "";
            this.rtbDescription.Validating += new System.ComponentModel.CancelEventHandler(this.rtbDescription_Validating);
            this.rtbDescription.Validated += new System.EventHandler(this.rtbDescription_Validated);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(110, 78);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(322, 23);
            this.tbTitle.TabIndex = 5;
            this.tbTitle.Validating += new System.ComponentModel.CancelEventHandler(this.tbTitle_Validating);
            this.tbTitle.Validated += new System.EventHandler(this.tbTitle_Validated);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(259, 303);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // epTitle
            // 
            this.epTitle.ContainerControl = this;
            // 
            // epDescription
            // 
            this.epDescription.ContainerControl = this;
            // 
            // RewardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 356);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lIDShow);
            this.Controls.Add(this.lID);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 391);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(488, 391);
            this.Name = "RewardForm";
            this.Text = "Reward";
            this.Load += new System.EventHandler(this.RewardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lID;
        private System.Windows.Forms.Label lIDShow;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider epTitle;
        private System.Windows.Forms.ErrorProvider epDescription;
    }
}