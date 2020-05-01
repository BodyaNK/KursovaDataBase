namespace BDApp
{
    partial class Employee_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.personalInfoPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.transGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.telBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Branch = new System.Windows.Forms.Label();
            this.BranchBox = new System.Windows.Forms.TextBox();
            this.addresBox = new System.Windows.Forms.TextBox();
            this.DesignationBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.fullNameBox = new System.Windows.Forms.TextBox();
            this.personalInfoPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 1;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(779, 9);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(56, 23);
            this.logoutBtn.TabIndex = 32;
            this.logoutBtn.Text = "Log out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // personalInfoPanel
            // 
            this.personalInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.personalInfoPanel.Controls.Add(this.groupBox2);
            this.personalInfoPanel.Controls.Add(this.groupBox3);
            this.personalInfoPanel.Controls.Add(this.groupBox1);
            this.personalInfoPanel.Location = new System.Drawing.Point(12, 38);
            this.personalInfoPanel.Name = "personalInfoPanel";
            this.personalInfoPanel.Size = new System.Drawing.Size(823, 488);
            this.personalInfoPanel.TabIndex = 33;
            this.personalInfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.personalInfoPanel_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.transGrid);
            this.groupBox2.Location = new System.Drawing.Point(9, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(798, 317);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My transactions";
            // 
            // transGrid
            // 
            this.transGrid.AllowUserToAddRows = false;
            this.transGrid.AllowUserToDeleteRows = false;
            this.transGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transGrid.Location = new System.Drawing.Point(6, 19);
            this.transGrid.Name = "transGrid";
            this.transGrid.ReadOnly = true;
            this.transGrid.Size = new System.Drawing.Size(786, 292);
            this.transGrid.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.telBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.emailBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(400, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 152);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact info";
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(73, 60);
            this.telBox.Name = "telBox";
            this.telBox.ReadOnly = true;
            this.telBox.Size = new System.Drawing.Size(263, 20);
            this.telBox.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Telephone";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(73, 27);
            this.emailBox.Name = "emailBox";
            this.emailBox.ReadOnly = true;
            this.emailBox.Size = new System.Drawing.Size(263, 20);
            this.emailBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Branch);
            this.groupBox1.Controls.Add(this.BranchBox);
            this.groupBox1.Controls.Add(this.addresBox);
            this.groupBox1.Controls.Add(this.DesignationBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.fullNameBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal info";
            // 
            // Branch
            // 
            this.Branch.AutoSize = true;
            this.Branch.Location = new System.Drawing.Point(6, 109);
            this.Branch.Name = "Branch";
            this.Branch.Size = new System.Drawing.Size(41, 13);
            this.Branch.TabIndex = 9;
            this.Branch.Text = "Branch";
            // 
            // BranchBox
            // 
            this.BranchBox.Location = new System.Drawing.Point(73, 106);
            this.BranchBox.Name = "BranchBox";
            this.BranchBox.ReadOnly = true;
            this.BranchBox.Size = new System.Drawing.Size(263, 20);
            this.BranchBox.TabIndex = 8;
            // 
            // addresBox
            // 
            this.addresBox.Location = new System.Drawing.Point(73, 54);
            this.addresBox.Name = "addresBox";
            this.addresBox.ReadOnly = true;
            this.addresBox.Size = new System.Drawing.Size(263, 20);
            this.addresBox.TabIndex = 7;
            // 
            // DesignationBox
            // 
            this.DesignationBox.Location = new System.Drawing.Point(73, 80);
            this.DesignationBox.Name = "DesignationBox";
            this.DesignationBox.ReadOnly = true;
            this.DesignationBox.Size = new System.Drawing.Size(263, 20);
            this.DesignationBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Designation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Addres";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Full name";
            // 
            // fullNameBox
            // 
            this.fullNameBox.Location = new System.Drawing.Point(73, 28);
            this.fullNameBox.Name = "fullNameBox";
            this.fullNameBox.ReadOnly = true;
            this.fullNameBox.Size = new System.Drawing.Size(263, 20);
            this.fullNameBox.TabIndex = 0;
            // 
            // Employee_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 538);
            this.Controls.Add(this.personalInfoPanel);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Employee_Form";
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Employee_Form_Load);
            this.personalInfoPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Panel personalInfoPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DesignationBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox fullNameBox;
        private System.Windows.Forms.TextBox addresBox;
        private System.Windows.Forms.Label Branch;
        private System.Windows.Forms.TextBox BranchBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView transGrid;
    }
}