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
    public partial class Client_Form : Form
    {
        public Client_Form()
        {
            InitializeComponent();
        }
        public Client_Form(User client)
        {
            InitializeComponent();
            this.client = client;
        }
        User client = new User();
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";
               
        private void Client_Form_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = $"SELECT FlightDate, Departure, Arrival, Airport, Destination" +
                $" FROM Flight_Schedule as FS " +
                $" INNER JOIN AirFare as AF " +
                $" ON FS.NetFare = AF.AfID " +
                $" INNER JOIN Route as RT " +
                $" ON RT.RtID = AF.Route";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, $"Flight_Schedule");
                connection.Close();
                scheduleGrid.DataSource = ds;
                scheduleGrid.DataMember = $"Flight_Schedule";
            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientSettings admin_Form = new ClientSettings(client);
            admin_Form.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = this.dateBox.Value.Date;
            string from = fromBox.Text;
            string to = toBox.Text;

            try { 
                string sql = $"SELECT FlID, FlightDate, Departure, Arrival, Airport AS FromAirport, Destination " +
                    $" FROM Flight_Schedule as fs " +
                    $" INNER JOIN AirFare as af " +
                    $" ON fs.NetFare = af.AfID " +
                    $" INNER JOIN Route as rt " +
                    $" ON rt.RtID=af.Route " +
                    $" WHERE rt.Airport LIKE '" + from + "' AND " +
                    $" rt.Destination LIKE '" + to +"' AND " +
                    $" (DATEPART(yy, fs.FlightDate)='"+dt.Year+"' AND" +
                    $" DATEPART(mm, fs.FlightDate)='"+dt.Month+"' AND " +
                    $" DATEPART(dd, fs.FlightDate)='"+dt.Day+"')";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, $"searchResGrid");
                connection.Close();
                searchResGrid.DataSource = ds;
                searchResGrid.DataMember = $"searchResGrid";
            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                return;
            }
        }

        private void bookingBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(searchResGrid.Rows[searchResGrid.CurrentRow.Index].Cells[0].Value);

            TransactionForm tranaction_Form = new TransactionForm(client, id);
            tranaction_Form.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string from = fromBox.Text;
            string to = toBox.Text;
            fromBox.Text = to;
            toBox.Text = from;
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
    }
}
