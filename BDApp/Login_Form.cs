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
    public partial class Login_Form : Form
    {
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";

        public Login_Form()
        {
            InitializeComponent();
            userTypeBox.SelectedItem = "client";
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string userType = userTypeBox.SelectedItem.ToString();
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            if (username == "" || password == "" || userTypeBox.Text == "")
            {
                MessageBox.Show("Please fill all fields!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT COUNT(*) FROM DB_Users WHERE Username='{username}' AND UserType='{userType}'", connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("User with this username doesn't exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                sda = new SqlDataAdapter($"SELECT Password FROM DB_Users WHERE Username='{username}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);
                //root@12345 - main admin password
                //designation@tel - employee password
                if(password != Security.Decrypt(dt.Rows[0][0].ToString(), true))
                {
                    MessageBox.Show("Incorrect password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    sda = new SqlDataAdapter($"SELECT UserDetailsID FROM DB_Users WHERE Username='{username}'", connectionString);
                    dt = new DataTable();
                    sda.Fill(dt);

                    User user = new User();
                    user.username = username;
                    user.password = password;
                    user.userType = userType;
                    
                    int userID;
                    if (dt.Rows[0][0].ToString() != "")
                    {
                        userID = Int32.Parse(dt.Rows[0][0].ToString());
                        user.userId = userID;
                    }

                    if (userType == "admin")
                    {
                        Admin_Form admin_Form = new Admin_Form(user);
                        this.Hide();
                        admin_Form.Show();
                    }
                    if (userType == "client")
                    {
                        Client_Form client_Form = new Client_Form(user);
                        this.Hide();
                        client_Form.Show();
                    }
                    if (userType == "employee")
                    {
                        Employee_Form employee_Form = new Employee_Form(user);
                        this.Hide();
                        employee_Form.Show();
                    }
                }
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void signup_Click(object sender, EventArgs e)
        {
            Signup_Form signup_Form = new Signup_Form();
            this.Hide();
            signup_Form.Show();
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

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
