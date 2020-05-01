using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UsersDB;

namespace BDApp
{
    public partial class Signup_Form : Form
    {
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";
        public Signup_Form()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            if(username=="" || password == "" || confpassBox.Text == "")
            {
                MessageBox.Show("Please fill all fields!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confpassBox.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlDataAdapter sda = new SqlDataAdapter($"SELECT PsID FROM Passengers ORDER BY PsID DESC", connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int PsId = Int32.Parse(dt.Rows[0][0].ToString());

            sda = null;
            dt = null;
            sda = new SqlDataAdapter($"SELECT COUNT(*) FROM DB_Users WHERE Username='{username}'", connectionString);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("User with this username already exists!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            User user = new User();
            user.username = username;
            user.password = password;
            user.userType = "client";
            user.userId = PsId + 1;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var insertCommand = new SqlCommand("INSERT INTO DB_Users (Username, Password, UserType, UserDetailsID) VALUES('" + user.username + "', '" + Security.Encrypt(user.password, true) + "','" + user.userType + "', '" + user.userId + "')"))
                {
                    insertCommand.Connection = conn;
                    conn.Open();
                    insertCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType()
                    , "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Successfully!");

            Client_Form client_Form = new Client_Form(user);
            this.Hide();
            client_Form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login_Form = new Login_Form();
            login_Form.Show();
        }
    }
}
