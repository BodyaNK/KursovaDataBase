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
    public partial class TransactionForm : Form
    {
        public TransactionForm()
        {
            InitializeComponent();
        }
        public TransactionForm(User user, int id)
        {
            InitializeComponent();
            this.user = user;
            this.idFlight = id;
        }
        User user = new User();
        int idFlight;
        int routeId;
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";
        int netFareId;
        int fareSum;
        int fscSum;
        int totalCharges;
        int totalDiscounts;
        float totalPrice;
        string flightType = "Reservation";//or Cancellation

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            departureBox.Text = dbClasses.getValueById("Departure", "Flight_Schedule", 
                "FlID", idFlight.ToString(), connectionString);
            arrivalBox.Text = dbClasses.getValueById("Arrival", "Flight_Schedule",
                "FlID", idFlight.ToString(), connectionString);
            if(flightType== "Reservation")
            {
                int id = dbClasses.getIdByCellValue("ChID", "Charges", "Title", flightType, connectionString);
                if (id != 0)
                {
                    totalCharges = Convert.ToInt32(dbClasses.getValueById("Amount", "Charges", "ChID", id.ToString(), connectionString));
                    chargesBox.Text = totalCharges.ToString();
                }
                else
                {
                    totalCharges = 0;
                    chargesBox.Text = "No charges for this flight";
                }
            } else if(flightType== "Cancellation")
            {
                chargesBox.Text = "Unfortunately cancellation charges are not yet available";
            }

            discountsBox.Text = "Discounts isn't available for this user";
            totalDiscounts = 0;

            netFareId = Convert.ToInt32(dbClasses.getValueById("NetFare", "Flight_Schedule",
                "FlID", idFlight.ToString(), connectionString));
            
            routeId = Convert.ToInt32(dbClasses.getValueById("Route", "AirFare",
                "AfID", netFareId.ToString(), connectionString));
            
            fromBox.Text = dbClasses.getValueById("Airport", "Route",
                "RtID", routeId.ToString(), connectionString);
            toBox.Text = dbClasses.getValueById("Destination", "Route",
                "RtID", routeId.ToString(), connectionString);
            fareSum = Convert.ToInt32(dbClasses.getValueById("Fare", "AirFare",
                "AfID", netFareId.ToString(), connectionString));
            fscSum = Convert.ToInt32(dbClasses.getValueById("FSC", "AirFare",
                "AfID", netFareId.ToString(), connectionString));

            totalPrice = (fareSum + fscSum);
            float chPlus = (totalPrice * totalCharges) / 100;
            if (totalDiscounts != 0)
            {
                float dsPlus = (totalPrice * totalDiscounts) / 100;
                totalPrice -= dsPlus;
            }
            totalPrice += chPlus;
            totalBox.Text = totalPrice.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you really want to book this ?",
                                      "Confirm booking!!",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                int ch=0;
                int ds=0;
                bool isInt = Int32.TryParse(chargesBox.Text, out ch);
                if (!isInt)
                {
                    ch = 0;
                }
                isInt = Int32.TryParse(discountsBox.Text, out ds);
                if (!isInt)
                {
                    ds = 0;
                }
                int idCh = dbClasses.getIdByCellValue("ChID", "Charges", "Amount", ch.ToString(), connectionString);
                if (idCh == 0)
                {
                    idCh = 1;
                }
                int idDs = dbClasses.getIdByCellValue("DiID", "Discounts", "Amount", ds.ToString(), connectionString);
                if (idDs == 0)
                {
                    idDs = 1;
                }
                try
                {
                    int idEmp = dbClasses.getIdByCellValue("EmpID", "Employees", "Designation", "Sales manager", connectionString);

                    dbClasses.QueryInser(connectionString,
                    $" INSERT INTO Transactions (BookingDate, DepartureDate, Passanger, " +
                    $" Flight, Type, Employee, Charges, Discount, Total)" +
                    $" VALUES('" + arrivalBox.Text + "', '" + departureBox.Text + "', " +
                    " '" + user.userId + "', '" + idFlight + "', " +
                    " '" + 1 + "', '" + idEmp.ToString() + "', " +
                    " '" + idCh + "', '" + idDs + "', " +
                    " '" + totalBox.Text + "')");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                    return;
                }
                MessageBox.Show("You have successfully booked your ticket!\n" +
                                      "You can view and print it in the settings section.",
                                      "Success!",
                                      MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
