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
using DB_Functionality;

namespace BDApp
{
    public partial class Employee_Form : Form
    {
        public Employee_Form()
        {
            InitializeComponent();
        }
        public Employee_Form(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        User user = new User();
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";
        bool isExistUser = false;

        private void Employee_Form_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT COUNT(*) FROM Employees WHERE EmpID='{user.userId}'", connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "0")
            {
                isExistUser = false;
            }
            else
            {
                isExistUser = true;
                sda = null;
                dt = null;
                sda = new SqlDataAdapter($"SELECT * FROM Employees WHERE EmpID='{user.userId}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);

                fullNameBox.Text = dt.Rows[0][1].ToString();
                addresBox.Text = dt.Rows[0][2].ToString();
                DesignationBox.Text = dt.Rows[0][4].ToString();
                emailBox.Text = dt.Rows[0][5].ToString();
                telBox.Text = dt.Rows[0][6].ToString();
                int BrID = Int32.Parse(dt.Rows[0][3].ToString());

                sda = null;
                dt = null;
                sda = new SqlDataAdapter($"SELECT Center FROM Branches WHERE BrID='{BrID}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);

                BranchBox.Text = dt.Rows[0][0].ToString(); 
            }

            string sql = $"SELECT * FROM Transactions WHERE Employee={user.userId}";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, $"Employee");
            connection.Close();
            transGrid.DataSource = ds;
            transGrid.DataMember = $"Employee";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
         
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Log out ?",
                                      "Confirm logout!!",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Login_Form login_Form = new Login_Form();
                this.Close();
                login_Form.Show();
            }
        }

        private void personalInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
