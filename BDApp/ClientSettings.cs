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
using System.IO;

namespace BDApp
{
    public partial class ClientSettings : Form
    {
        public ClientSettings()
        {
            InitializeComponent();
        }

        public ClientSettings(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        User user = new User();
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";
        bool isExistUser = false;
        string[] printToFileArr = new string[7];

        private void ClientSettings_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT COUNT(*) FROM Passengers WHERE PsID='{user.userId}'", connectionString);
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
                sda = new SqlDataAdapter($"SELECT * FROM Passengers WHERE PsID='{user.userId}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);

                fullNameBox.Text = dt.Rows[0][1].ToString();
                detailAddrBox.Text = dt.Rows[0][2].ToString();
                ageBox.Value = Int32.Parse(dt.Rows[0][3].ToString());
                NationalitiesBox.Text = dt.Rows[0][4].ToString();               
                int CnID = Int32.Parse(dt.Rows[0][5].ToString());

                sda = null;
                dt = null;
                sda = new SqlDataAdapter($"SELECT * FROM Contact_Details WHERE CnID='{CnID}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);

                emailBox.Text = dt.Rows[0][1].ToString();
                celBox.Text = dt.Rows[0][2].ToString();
                telBox.Text = dt.Rows[0][3].ToString();
                streetBox.Text = dt.Rows[0][4].ToString();
                int StID = Int32.Parse(dt.Rows[0][5].ToString());

                sda = null;
                dt = null;
                sda = new SqlDataAdapter($"SELECT * FROM State WHERE StID='{StID}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);

                stateBox.Text = dt.Rows[0][1].ToString();
                int CtID = Int32.Parse(dt.Rows[0][2].ToString());

                sda = null;
                dt = null;
                sda = new SqlDataAdapter($"SELECT * FROM Countries WHERE CtID='{CtID}'", connectionString);
                dt = new DataTable();
                sda.Fill(dt);

                countryBox.Text = dt.Rows[0][1].ToString();

            }

            sda = new SqlDataAdapter($"SELECT * FROM Transactions WHERE Passanger = '" + user.userId + "'", connectionString);
            dt = new DataTable();
            sda.Fill(dt);

            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fsId = Convert.ToInt32(dt.Rows[i][4]);

                int netFareId = Convert.ToInt32(dbClasses.getValueById("NetFare", "Flight_Schedule",
                    "FlID", fsId.ToString(), connectionString));

                int routeId = Convert.ToInt32(dbClasses.getValueById("Route", "AirFare",
                    "AfID", netFareId.ToString(), connectionString));

                string fromStr = dbClasses.getValueById("Airport", "Route",
                    "RtID", routeId.ToString(), connectionString);

                string toStr = dbClasses.getValueById("Destination", "Route",
                    "RtID", routeId.ToString(), connectionString);

                transactionsGrid.Rows.Add(dt.Rows[i][2], dt.Rows[i][1], fromStr, toStr, dt.Rows[i][7], dt.Rows[i][8], dt.Rows[i][9]);
            }
       
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string fullName = fullNameBox.Text;
            int age = Decimal.ToInt32(ageBox.Value);
            string nationalities = NationalitiesBox.Text;
            string country = countryBox.Text;
            string state = stateBox.Text;
            string streer = streetBox.Text;
            string detailAddres = detailAddrBox.Text;
            string email = emailBox.Text;
            string cel = celBox.Text;
            string tel = telBox.Text;
            string command;

            int countryId = dbClasses.getIdByCellValue("CtID", "Countries", "CountryName", country, connectionString);
            if (countryId == 0)
            {
                MessageBox.Show("This country doesn't exist!\nPlease add the country first.");
                return;
            }

            try
            {
                if (isExistUser == true)
                {
                    command = "UPDATE Countries SET CountryName ='" + country + "' WHERE CtID = '" + countryId + "'";
                } else
                {
                    command = "INSERT INTO Countries (CountryName) VALUES('" + country + "')";
                }
                dbClasses.QueryInser(connectionString, command);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                return;
            }

            int stateId = dbClasses.getIdByCellValue("StID", "State", "StateName", state, connectionString);
            if (stateId == 0)
            {
                MessageBox.Show("This state doesn't exist!\nPlease add the state first.");
                return;
            }
            try
            {
                if (isExistUser == true)
                {
                    command = "UPDATE State SET StateName ='" + state + "', Country = '"+ countryId +"' WHERE StID = '" + stateId + "'";
                }
                else
                {
                    command = "INSERT INTO State (StateName, Country) VALUES('" + state + "', '" + countryId + "')";
                }
                dbClasses.QueryInser(connectionString, command);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                return;
            }

            int ctdetailsID = 0;
                        
            ctdetailsID = dbClasses.getIdByCellValue("Contacts", "Passengers", "PsID", user.userId.ToString(), connectionString);
            try
            {
                if (isExistUser == true)
                {
                    command = "UPDATE Contact_Details SET " +
                        "Email ='" + email + "', Cell = '" + cel + "', " +
                        "Tel ='" + tel + "', Street = '" + streer + "', " +
                        "State = '" + stateId + "' " +
                        "WHERE CnID = '" + ctdetailsID + "'";
                }
                else
                {
                    command = "INSERT INTO Contact_Details(Email, Cell, Tel, Street, State) " +
                        "VALUES('" + email + "', '" + cel + "', '" + tel + "', '" + streer + "', '" + stateId + "')";
                }
                dbClasses.QueryInser(connectionString, command);

            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                return;
            }

            try
            {
                if (isExistUser == true)
                {
                    ctdetailsID = dbClasses.getIdByCellValue("Contacts", "Passengers", "PsID", user.userId.ToString(), connectionString);

                    command = "UPDATE Passengers SET " +
                        "Name ='" + fullName + "', Address = '" + detailAddres + "', " +
                        "Age ='" + age + "', Nationalities = '" + nationalities + "', " +
                        "Contacts = '" + ctdetailsID + "' " +
                        "WHERE PsID = '" + user.userId + "'";
                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter($"SELECT CnID FROM Contact_Details ORDER BY CnID DESC", connectionString);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ctdetailsID = Int32.Parse(dt.Rows[0][0].ToString());

                    command = "INSERT INTO Passengers " +
                        "(PsID, Name, Address, Age, Nationalities, Contacts) " +
                        "VALUES('" + user.userId + "','" + fullName + "', '" +
                        "" + detailAddres + "', '" + age + "', '" +
                        "" + nationalities + "','" + ctdetailsID + "')";
                }
                dbClasses.QueryInser(connectionString, command);

            }
            catch (Exception exp)
            {
                MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                return;
            }

            MessageBox.Show($"Success!");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void transactionsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < transactionsGrid.ColumnCount; i++)
            {
                printToFileArr[i] = Convert.ToString(transactionsGrid.Rows[transactionsGrid.CurrentRow.Index].Cells[i].Value);
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void printTransBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // or just "txt files (*.txt)|*.txt" if you only want to save text files
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.Write($"--------------------------------------------------------------------\n");
                    writer.Write($"---------This is the official confirmation of your booking----------\n");
                    writer.Write($"--------------------------------------------------------------------\n");
                    writer.Write($"---You need to contact this document at the cash desk for payment---\n");
                    writer.Write($"--------------------------------------------------------------------\n");
                    writer.Write($"-Full name of passenger: {fullNameBox.Text}\n");
                    writer.Write($"-Depature time:          {printToFileArr[0]}\n");
                    writer.Write($"-Arrival time:           {printToFileArr[1]}\n");
                    writer.Write($"-From:                   {printToFileArr[2]}\n");
                    writer.Write($"-To:                     {printToFileArr[3]}\n");
                    writer.Write($"-Charges:                {printToFileArr[4]}\n");
                    writer.Write($"-Discounts:              {printToFileArr[5]}\n");
                    writer.Write($"--------------------------------------------------------------------\n");
                    writer.Write($"-Total price:            {printToFileArr[6]}\n");
                    writer.Write($"--------------------------------------------------------------------\n");
                    writer.Write($"--------------------------------------------------------------------\n");
                    writer.Close();
                }
            }
        }
    }
}
