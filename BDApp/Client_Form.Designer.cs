namespace BDApp
{
    partial class Client_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Form));
            this.fromBox = new System.Windows.Forms.TextBox();
            this.toBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.scheduleGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.searchResGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.bookingBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // fromBox
            // 
            this.fromBox.Location = new System.Drawing.Point(172, 82);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(202, 20);
            this.fromBox.TabIndex = 3;
            // 
            // toBox
            // 
            this.toBox.Location = new System.Drawing.Point(172, 121);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(202, 20);
            this.toBox.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(779, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // scheduleGrid
            // 
            this.scheduleGrid.AllowUserToAddRows = false;
            this.scheduleGrid.AllowUserToDeleteRows = false;
            this.scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGrid.Location = new System.Drawing.Point(90, 291);
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.ReadOnly = true;
            this.scheduleGrid.RowHeadersWidth = 20;
            this.scheduleGrid.Size = new System.Drawing.Size(667, 235);
            this.scheduleGrid.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Flight shedule";
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(172, 56);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(202, 20);
            this.dateBox.TabIndex = 23;
            // 
            // searchResGrid
            // 
            this.searchResGrid.AllowUserToAddRows = false;
            this.searchResGrid.AllowUserToDeleteRows = false;
            this.searchResGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResGrid.Location = new System.Drawing.Point(413, 56);
            this.searchResGrid.Name = "searchResGrid";
            this.searchResGrid.ReadOnly = true;
            this.searchResGrid.RowHeadersWidth = 20;
            this.searchResGrid.Size = new System.Drawing.Size(344, 182);
            this.searchResGrid.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Flight date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "To";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(172, 180);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(202, 26);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // bookingBtn
            // 
            this.bookingBtn.Location = new System.Drawing.Point(172, 212);
            this.bookingBtn.Name = "bookingBtn";
            this.bookingBtn.Size = new System.Drawing.Size(202, 26);
            this.bookingBtn.TabIndex = 29;
            this.bookingBtn.Text = "Booking";
            this.bookingBtn.UseVisualStyleBackColor = true;
            this.bookingBtn.Click += new System.EventHandler(this.bookingBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(258, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "←→";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(779, 41);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(56, 23);
            this.logoutBtn.TabIndex = 31;
            this.logoutBtn.Text = "Log out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 538);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bookingBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchResGrid);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scheduleGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.fromBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Client_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search form";
            this.Load += new System.EventHandler(this.Client_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox fromBox;
        private System.Windows.Forms.TextBox toBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.DataGridView searchResGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button bookingBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button logoutBtn;
    }
}