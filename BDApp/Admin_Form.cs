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
    public partial class Admin_Form : Form
    {
        public Admin_Form()
        {
            InitializeComponent();
        }
        public Admin_Form(User admin)
        {
            InitializeComponent();
            this.admin = admin;
        }
        User admin = new User();
        string connectionString = "Data Source=DESKTOP-GTF2REP;Initial Catalog=DB_Flights;Integrated Security=True";

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            dbClasses.QuerySelect(connectionString, "Employees", dataGridEmployee);
            dbClasses.QuerySelect(connectionString, "Branches", branchesGrid);
            dbClasses.QuerySelect(connectionString, "State", stateGrid);
            dbClasses.QuerySelect(connectionString, "Countries", countriesGrid);  
        }

        private void EmployessTab_Click(object sender, EventArgs e)
        {

        }

        private void EmployeesTab_Selected(object sender, TabControlEventArgs e)
        {
        }
        private void FlightScheduleTab_Selected(object sender, TabControlEventArgs e)
        {
        }
        
        private void scheduleGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmployeesTab_SelectedCustom()
        {
            dbClasses.QuerySelect(connectionString, "Employees", dataGridEmployee);
            dbClasses.QuerySelect(connectionString, "Branches", branchesGrid);
            dbClasses.QuerySelect(connectionString, "State", stateGrid);
            dbClasses.QuerySelect(connectionString, "Countries", countriesGrid);
        }
        private void FlightScheduleTab_SelectedCustom()
        {
            dbClasses.QuerySelect(connectionString, "Flight_Schedule", scheduleGrid);
            dbClasses.QuerySelect(connectionString, "AirCrafts", AirCraftsGrid);
            dbClasses.QuerySelect(connectionString, "AirFare", AirFareGrid);
            dbClasses.QuerySelect(connectionString, "Route", RouteGrid);
        }
        private void TransactionsTab_SelectedCustom()
        {
            dbClasses.QuerySelect(connectionString, "Transactions", transGrid);
            dbClasses.QuerySelect(connectionString, "Discounts", discountsGrid);
            dbClasses.QuerySelect(connectionString, "Charges", chargesGrid);
        }

        private void EmployeesTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    EmployeesTab_SelectedCustom();
                    break;
                case 1:
                    FlightScheduleTab_SelectedCustom();
                    break;
                case 2:
                    TransactionsTab_SelectedCustom();
                    break;
            }
        }

        private void dataGridEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveRouteBtn_Click(object sender, EventArgs e)
        {
            string airpotr = airportBox.Text;
            string destination = destinationBox.Text;
            string routeCode = routeCodeBox.Text;
            if(airpotr!="" && destination!="" && routeCode != "")
            {
                try
                {
                    dbClasses.QueryInser(connectionString, $"INSERT INTO Route (Airport, Destination, RouteCode) VALUES('" + airpotr + "', '" + destination + "','" + routeCode + "')");
                    FlightScheduleTab_SelectedCustom();
                    airportBox.Text = "";
                    destinationBox.Text = "";
                    routeCodeBox.Text = "";
                }
                catch (Exception exp)
                { 
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType(), 
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!",
                                "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void saveAirfareBtn_Click(object sender, EventArgs e)
        {
            string idRoute = idRouteBox.Text;
            string fare = fareBox.Text;
            string fsc = fscBox.Text;

            if (dbClasses.checkIsExistEntry("Route", connectionString, "RtID", idRoute) == 0)
            {
                MessageBox.Show("This route doesn't exist!\nPlease add the route first.",
                                "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (idRoute != "" && fare != "" && fsc != "")
                {
                    try
                    {
                        dbClasses.QueryInser(connectionString, $"INSERT INTO AirFare (Route, Fare, FSC) VALUES('" + idRoute + "', '" + fare + "','" + fsc + "')");
                        FlightScheduleTab_SelectedCustom();
                        idRouteBox.Text = "";
                        fareBox.Text = "";
                        fscBox.Text = "";
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType(),
                                "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields!",
                                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void saveAirCBtn_Click(object sender, EventArgs e)
        {
            string acNum = acNumBox.Text;
            string mdfBy = mdfByBox.Text;
            string mdfOn = mdfOnBox.Text;
            int cap = Decimal.ToInt32(capacity.Value);
            if (acNum != "" && mdfBy != "" && mdfOn != "" && cap!=0)
            {
                try
                {
                    dbClasses.QueryInser(connectionString, 
                        $"INSERT INTO AirCrafts (AcNumber, Capacity, MfdBy, MfdOn) VALUES('" + acNum + "', '" + cap + "','" + mdfBy + "','" + mdfOn + "')");
                    FlightScheduleTab_SelectedCustom();
                    acNumBox.Text = "";
                    mdfByBox.Text = "";
                    mdfOnBox.Text = "";
                    capacity.Value = 0;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }
        }

        private void saveScheduleBtn_Click(object sender, EventArgs e)
        {
            string flightdate = flightdateBox.Text;
            string departure = departureBox.Text;
            string arrival = arrivalBox.Text;
            int idAirCraft = Int32.Parse(idAirCraftBox.Text);
            int idNetFare = Int32.Parse(idNetFareBox.Text);

            if (dbClasses.checkIsExistEntry( "AirCrafts", connectionString, "AcID", idAirCraft.ToString()) == 0)
            {
                MessageBox.Show("This aircraft doesn't exist!\nPlease add the aircraft first.");
                return;
            }

            if (dbClasses.checkIsExistEntry("AirFare", connectionString, "AfID", idNetFare.ToString()) == 0)
            {
                MessageBox.Show("This airfare doesn't exist!\nPlease check the airfare table.");
                return;
            }

            if (flightdate != "" && departure != "" && arrival != "" && idAirCraft!=0 && idNetFare!=0)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                        $"INSERT INTO Flight_Schedule (FlightDate, Departure, Arrival, AirCraft, NetFare) VALUES('" + flightdate + "', '" + departure + "','" + arrival + "','" + idAirCraft + "','" + idNetFare + "')");
                    FlightScheduleTab_SelectedCustom();
                    flightdateBox.Text = "";
                    departureBox.Text = "";
                    arrivalBox.Text = "";
                    idAirCraftBox.Text = "";
                    idNetFareBox.Text = "";
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }
        }

        private void saveCountryBtn_Click(object sender, EventArgs e)
        {
            string countryName = countryNameBox.Text;
            if (dbClasses.checkIsExistEntry("Countries", connectionString, "CountryName", countryName) == 1)
            {
                MessageBox.Show("This country already exists in table!");
                return;
            }
            if (countryName != "")
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                        $"INSERT INTO Countries (CountryName) VALUES('" + countryName + "')");
                    EmployeesTab_SelectedCustom();
                    countryNameBox.Text = "";
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }
        }

        private void saveStatebtn_Click(object sender, EventArgs e)
        {
            string stateName = stateNameBox.Text;
            string Country = idCountryBox.Text;
            int idCountry = dbClasses.getIdByCellValue("CtID", "Countries", "CountryName", Country, connectionString);
            if (idCountry == 0)
            {
                MessageBox.Show("This country doesn't exist!\nPlease add the country first.");
                return;
            }
            if (dbClasses.checkIsExistEntry("Countries", connectionString, "CtID", idCountry.ToString()) == 0)
            {
                MessageBox.Show("This country doesn't exist!\nPlease add the country first.");
                return;
            }
            if (dbClasses.checkIsExistEntry("State", connectionString, "StateName", stateName) == 1)
            {
                MessageBox.Show("This state already exist!");
                return;
            }
            else
            {
                if (stateName != "" && Country != "")
                {
                    try
                    {
                        dbClasses.QueryInser(connectionString, $"INSERT INTO State (StateName, Country) VALUES('" + stateName + "', '" + idCountry + "')");
                        EmployeesTab_SelectedCustom();
                        idRouteBox.Text = "";
                        stateNameBox.Text = "";
                        idCountryBox.Text = "";
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields!");
                    return;
                }
            }
        }

        private void saveBranchBtn_Click(object sender, EventArgs e)
        {
            string center = centerBox.Text;
            string address = addressBox.Text;
            string state = stateBox.Text;
            int idState = dbClasses.getIdByCellValue("StID", "State", "StateName", state, connectionString);
            if (idState == 0)
            {
                MessageBox.Show("This state doesn't exist!\nPlease add the state first.");
                return;
            }
            if (dbClasses.checkIsExistEntry("State", connectionString, "StID", idState.ToString()) == 0)
            {
                MessageBox.Show("This state doesn't exist!\nPlease add the state first.");
                return;
            }
            else
            {
                if (center != "" && address != "" && state != "")
                {
                    try
                    {
                        dbClasses.QueryInser(connectionString, $"INSERT INTO Branches (Center, Address, State) VALUES('" + center + "', '" + address + "','" + idState + "')");
                        EmployeesTab_SelectedCustom();
                        centerBox.Text = "";
                        addressBox.Text = "";
                        stateBox.Text = "";
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields!");
                    return;
                }
            }
        }

        private void saveEmpBtn_Click(object sender, EventArgs e)
        {

            User employee = new User();
            string empName = empNameBox.Text;
            string empAddr = empAddrBox.Text;
            string Branch = idBranchBox.Text;
            string designation = designationBox.Text;
            string email = emailBox.Text;
            string tel = telBox.Text;
            int ext = Decimal.ToInt32(extBoxNum.Value);

            int idBranch = dbClasses.getIdByCellValue("BrID", "Branches", "Center", Branch, connectionString);
            if (idBranch == 0)
            {
                MessageBox.Show("This branche doesn't exist!\nPlease add the branche first.");
                return;
            }
            if (empName != "" && empAddr != "" && Branch != ""
                && designation != "" && email != "" && tel != "" && ext != 0)
            {
                try
                {
                    dbClasses.QueryInser(connectionString, 
                        $"INSERT INTO Employees (Name, Address, Branch, Designation, Email, Tel, Ext) " +
                        $"VALUES('" + empName + "', '" + empAddr + "','" + idBranch + "','" + designation + "','" + email + "','" + tel + "','" + ext + "')");
                    EmployeesTab_SelectedCustom();
                    empNameBox.Text = "";
                    empAddrBox.Text = "";
                    idBranchBox.Text = "";
                    designationBox.Text = "";
                    emailBox.Text = "";
                    telBox.Text = "";
                    extBoxNum.Value = 0;

                    employee.username = empName;
                    string pass = $"{designation}@{tel}";
                    employee.password = Security.Encrypt(pass, true);
                    employee.userType = "employee";
                    SqlDataAdapter sda = new SqlDataAdapter($"SELECT EmpID FROM Employees ORDER BY EmpID DESC", connectionString);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    employee.userId = Int32.Parse(dt.Rows[0][0].ToString());

                    dbClasses.QueryInser(connectionString,
                        $"INSERT INTO DB_Users (Username, Password, UserType, UserDetailsID)"+
                        $"VALUES('" + employee.username + "', '" + employee.password + "','" + employee.userType + "', '" + employee.userId + "')");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }
        }

        private void dataGridEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            int id = Convert.ToInt32(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[0].Value);
            empNameBox.Text = Convert.ToString(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[1].Value);
            empAddrBox.Text = Convert.ToString(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[2].Value);
            int idbranch = Convert.ToInt32(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[3].Value);
            string branch = dbClasses.getValueById("Center", "Branches", "BrID", idbranch.ToString(), connectionString);
            idBranchBox.Text = branch;
            designationBox.Text = Convert.ToString(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[4].Value);
            emailBox.Text = Convert.ToString(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[5].Value);
            telBox.Text = Convert.ToString(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[6].Value);
            if (dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[7].Value != DBNull.Value)
            {
                extBoxNum.Value = Convert.ToInt32(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[7].Value);
            }
            else
            {
                extBoxNum.Value = 0;
            }
        }

        private void countriesGrid_MouseClick(object sender, MouseEventArgs e)
        {
            countryNameBox.Text = Convert.ToString(countriesGrid.Rows[countriesGrid.CurrentRow.Index].Cells[1].Value);           
        }

        private void stateGrid_MouseClick(object sender, MouseEventArgs e)
        {
            stateNameBox.Text = Convert.ToString(stateGrid.Rows[stateGrid.CurrentRow.Index].Cells[1].Value);
            int idcountry = Convert.ToInt32(stateGrid.Rows[stateGrid.CurrentRow.Index].Cells[2].Value);
            string country = dbClasses.getValueById("CountryName", "Countries", "CtID", idcountry.ToString(), connectionString);
            idCountryBox.Text = country;         
        }

        private void branchesGrid_MouseClick(object sender, MouseEventArgs e)
        {
            centerBox.Text = Convert.ToString(branchesGrid.Rows[branchesGrid.CurrentRow.Index].Cells[1].Value);
            addressBox.Text = Convert.ToString(branchesGrid.Rows[branchesGrid.CurrentRow.Index].Cells[2].Value);
            int idstate = Convert.ToInt32(branchesGrid.Rows[branchesGrid.CurrentRow.Index].Cells[3].Value);
            string state = dbClasses.getValueById("StateName", "State", "StID", idstate.ToString(), connectionString);
            stateBox.Text = state;
        }

        private void scheduleGrid_MouseClick(object sender, MouseEventArgs e)
        {
            flightdateBox.Text = Convert.ToString(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[1].Value);
            departureBox.Text = Convert.ToString(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[2].Value);
            arrivalBox.Text = Convert.ToString(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[3].Value);
            int idcraft = Convert.ToInt32(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[4].Value);
            int idfare = Convert.ToInt32(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[5].Value);
            string craft = dbClasses.getValueById("AcNumber", "AirCrafts", "AcID", idcraft.ToString(), connectionString);
            idAirCraftBox.Text = craft;
            idNetFareBox.Text = idfare.ToString();
        }

        private void AirFareGrid_MouseClick(object sender, MouseEventArgs e)
        {
            int idroute = Convert.ToInt32(AirFareGrid.Rows[AirFareGrid.CurrentRow.Index].Cells[1].Value);
            string route = dbClasses.getValueById("RouteCode", "Route", "RtID", idroute.ToString(), connectionString);
            idRouteBox.Text = route;
            fareBox.Text = Convert.ToString(AirFareGrid.Rows[AirFareGrid.CurrentRow.Index].Cells[2].Value);
            fscBox.Text = Convert.ToString(AirFareGrid.Rows[AirFareGrid.CurrentRow.Index].Cells[3].Value);
        }

        private void RouteGrid_MouseClick(object sender, MouseEventArgs e)
        {
            airportBox.Text = Convert.ToString(RouteGrid.Rows[RouteGrid.CurrentRow.Index].Cells[1].Value);
            destinationBox.Text = Convert.ToString(RouteGrid.Rows[RouteGrid.CurrentRow.Index].Cells[2].Value);
            routeCodeBox.Text = Convert.ToString(RouteGrid.Rows[RouteGrid.CurrentRow.Index].Cells[3].Value);
        }

        private void AirCraftsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            acNumBox.Text = Convert.ToString(AirCraftsGrid.Rows[AirCraftsGrid.CurrentRow.Index].Cells[1].Value);
            capacity.Value = Convert.ToInt32(AirCraftsGrid.Rows[AirCraftsGrid.CurrentRow.Index].Cells[2].Value);
            mdfByBox.Text = Convert.ToString(AirCraftsGrid.Rows[AirCraftsGrid.CurrentRow.Index].Cells[3].Value);
            mdfOnBox.Text = Convert.ToString(AirCraftsGrid.Rows[AirCraftsGrid.CurrentRow.Index].Cells[4].Value);
        }

        private void editEmpBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[0].Value);
            string branch = idBranchBox.Text;
            int idBranch = dbClasses.getIdByCellValue("BrID", "Branches", "Center", branch, connectionString);
            if (idBranch == 0)
            {
                MessageBox.Show("This branche doesn't exist!\nPlease add the branche first.");
                return;
            }
            try { 
                dbClasses.QueryInser(connectionString, 
                    $"UPDATE Employees " +
                    $"SET Name = '" + empNameBox.Text + "' , Address = '" + empAddrBox.Text + "', " +
                    $"Branch = '" + idBranch + "', Designation = '" + designationBox.Text + "', " +
                    $"Email = '" + emailBox.Text + "', " +
                    $"Tel = '" + telBox.Text + "', Ext = '" + extBoxNum.Value.ToString() + "' " +
                    $"WHERE EmpID = '" + id + "'");
                EmployeesTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void editBranchBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(branchesGrid.Rows[branchesGrid.CurrentRow.Index].Cells[0].Value);
            string state = stateBox.Text;
            int idState = dbClasses.getIdByCellValue("StID", "State", "StateName", state, connectionString);
            if (idState == 0)
            {
                MessageBox.Show("This state doesn't exist!\nPlease add the state first.");
                return;
            }
            try { 
                dbClasses.QueryInser(connectionString,
                    $"UPDATE Branches " +
                    $"SET Center = '" + centerBox.Text + "', Address = '" + addressBox.Text + "', " +
                    $"State = '" + idState + "' "+
                    $"WHERE BrID = '" + id + "'");
                EmployeesTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
}

        private void editStateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(stateGrid.Rows[stateGrid.CurrentRow.Index].Cells[0].Value);
            string country = idCountryBox.Text;
            int idCountry = dbClasses.getIdByCellValue("CtID", "Countries", "CountryName", country, connectionString);
            if (idCountry == 0)
            {
                MessageBox.Show("This country doesn't exist!\nPlease add the country first.");
                return;
            }
            try { 
                dbClasses.QueryInser(connectionString,
                    $"UPDATE State " +
                    $"SET StateName = '" + stateNameBox.Text + "', " +
                    $"Country = '" + idCountry + "' " +
                    $"WHERE StID = '" + id + "'");
                EmployeesTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
}

        private void editCountyBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(countriesGrid.Rows[countriesGrid.CurrentRow.Index].Cells[0].Value);

            try { 
                dbClasses.QueryInser(connectionString,
                    $"UPDATE Countries " +
                    $"SET CountryName = '" + countryNameBox.Text + "' " +
                    $"WHERE CtID = '" + id + "'");
                EmployeesTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
}

        private void delEmpBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridEmployee.Rows[dataGridEmployee.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try { 
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Employees " +
                    $"WHERE EmpID = '" + id + "'");
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM DB_Users " +
                    $"WHERE UserDetailsID = '" + id + "'");
                    EmployeesTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                } catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void delBrancheBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(branchesGrid.Rows[branchesGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try { 
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Branches " +
                    $"WHERE BrID = '" + id + "'");
                    EmployeesTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                } catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
        }
            else
                return;
        }

        private void delStateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(stateGrid.Rows[stateGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try { 
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM State " +
                    $"WHERE StID = '" + id + "'");
                    EmployeesTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                } catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
        }
            else
                return;
        }

        private void delCountryBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(countriesGrid.Rows[countriesGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Countries " +
                    $"WHERE CtID = '" + id + "'");
                    EmployeesTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void scdEditBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[0].Value);
            string aircraft = idAirCraftBox.Text;
            string netfare = idNetFareBox.Text;
            int idAircraft = dbClasses.getIdByCellValue("AcID", "AirCrafts", "AcNumber", aircraft, connectionString);
            if (idAircraft == 0)
            {
                MessageBox.Show("This aircraft doesn't exist!\nPlease add the aircraft first.");
                return;
            }
            int idNetfare = dbClasses.getIdByCellValue("AfID", "AirFare", "Route", netfare, connectionString);
            if (idNetfare == 0)
            {
                MessageBox.Show("This airfare doesn't exist!\nPlease add the airfare first.");
                return;
            }
            try
            {
                dbClasses.QueryInser(connectionString,
                    $"UPDATE Flight_Schedule " +
                    $"SET FlightDate = '" + flightdateBox.Text + "' , Departure = '" + departureBox.Text + "', " +
                    $"Arrival = '" + arrivalBox + "', AirCraft = '" + idAircraft + "', " +
                    $"NetFare = '" + idNetfare + "' " +
                    $"WHERE FlID = '" + id + "'");
                FlightScheduleTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void scdDelBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(scheduleGrid.Rows[scheduleGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Flight_Schedule " +
                    $"WHERE FlID = '" + id + "'");
                    FlightScheduleTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void aircraftDelBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(AirCraftsGrid.Rows[AirCraftsGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM AirCrafts " +
                    $"WHERE AcID = '" + id + "'");
                    FlightScheduleTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void routeDelBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RouteGrid.Rows[RouteGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Route " +
                    $"WHERE RtID = '" + id + "'");
                    FlightScheduleTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void airfareDelBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(AirFareGrid.Rows[AirFareGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM AirFare " +
                    $"WHERE AfID = '" + id + "'");
                    FlightScheduleTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void airfareEditBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(AirFareGrid.Rows[AirFareGrid.CurrentRow.Index].Cells[0].Value);
            string route = idRouteBox.Text;
            int idRoute = dbClasses.getIdByCellValue("RtID", "Route", "RouteCode", route, connectionString);
            if (idRoute == 0)
            {
                MessageBox.Show("This route doesn't exist!\nPlease add the route first.");
                return;
            }
            try
            {
                dbClasses.QueryInser(connectionString,
                    $"UPDATE AirFare " +
                    $"SET Route = '" + idRoute + "', Fare = '" + fareBox.Text + "', " +
                    $"FSC = '" + fscBox.Text + "' " +
                    $"WHERE AfID = '" + id + "'");
                FlightScheduleTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void routeEditBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RouteGrid.Rows[RouteGrid.CurrentRow.Index].Cells[0].Value);         
            try
            {
                dbClasses.QueryInser(connectionString,
                    $"UPDATE Route " +
                    $"SET Airport = '" + airportBox.Text + "', Destination = '" + destinationBox.Text + "', " +
                    $"RouteCode = '" + routeCodeBox.Text + "' " +
                    $"WHERE RtID = '" + id + "'");
                FlightScheduleTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void aircraftEditBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(AirCraftsGrid.Rows[AirCraftsGrid.CurrentRow.Index].Cells[0].Value);
            try
            {
                dbClasses.QueryInser(connectionString,
                    $"UPDATE AirCrafts " +
                    $"SET AcNumber = '" + acNumBox.Text + "', Capacity = '" + capacity.Value.ToString()+ "', " +
                    $"MfdBy = '" + mdfByBox.Text + "', MfdOn = '" + mdfOnBox.Text + "' " + 
                    $"WHERE AcID = '" + id + "'");
                FlightScheduleTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
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

        private void fareBox_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void discountsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            discTitleBox.Text = Convert.ToString(discountsGrid.Rows[discountsGrid.CurrentRow.Index].Cells[1].Value);
            amountDiscBox.Value = Convert.ToInt32(discountsGrid.Rows[discountsGrid.CurrentRow.Index].Cells[2].Value);
            discDescBox.Text = Convert.ToString(discountsGrid.Rows[discountsGrid.CurrentRow.Index].Cells[3].Value);
        }

        private void chargesGrid_MouseClick(object sender, MouseEventArgs e)
        {
            chTitleBox.Text = Convert.ToString(chargesGrid.Rows[chargesGrid.CurrentRow.Index].Cells[1].Value);
            amountChBox.Value = Convert.ToInt32(chargesGrid.Rows[chargesGrid.CurrentRow.Index].Cells[2].Value);
            chDescBox.Text = Convert.ToString(chargesGrid.Rows[chargesGrid.CurrentRow.Index].Cells[3].Value);
        }

        private void addDiscBtn_Click(object sender, EventArgs e)
        {
            string title = discTitleBox.Text;
            string amount = Convert.ToString(amountDiscBox.Value);
            string description = discDescBox.Text;
            if (title != "" && amount != "0" && description != "")
            {
                try
                {
                    dbClasses.QueryInser(connectionString, $"INSERT INTO Discounts " +
                        $"(Title, Amount, Description) " +
                        $"VALUES('" + title + "', '" + amount + "','" + description + "')");
                    TransactionsTab_SelectedCustom();
                    discTitleBox.Text = "";
                    amountDiscBox.Value = 0;
                    discDescBox.Text = "";
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType(),
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!",
                                "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void addChBtn_Click(object sender, EventArgs e)
        {
            string title = chTitleBox.Text;
            string amount = Convert.ToString(amountChBox.Value);
            string description = chDescBox.Text;
            if (title != "" && amount != "0" && description != "")
            {
                try
                {
                    dbClasses.QueryInser(connectionString, $"INSERT INTO Charges " +
                        $"(Title, Amount, Description) " +
                        $"VALUES('" + title + "', '" + amount + "','" + description + "')");
                    TransactionsTab_SelectedCustom();
                    chTitleBox.Text = "";
                    amountChBox.Value = 0;
                    chDescBox.Text = "";
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Exception Occre while creating table:" + exp.Message + "\t" + exp.GetType(),
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!",
                                "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void delDiscBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(discountsGrid.Rows[discountsGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Discounts " +
                    $"WHERE DiID = '" + id + "'");
                    TransactionsTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void delChBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(chargesGrid.Rows[chargesGrid.CurrentRow.Index].Cells[0].Value);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    dbClasses.QueryInser(connectionString,
                    $"DELETE FROM Charges " +
                    $"WHERE ChID = '" + id + "'");
                    TransactionsTab_SelectedCustom();
                    MessageBox.Show("Deleted!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
                return;
        }

        private void editDiscBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(discountsGrid.Rows[discountsGrid.CurrentRow.Index].Cells[0].Value);
            try
            {
                dbClasses.QueryInser(connectionString,
                    $"UPDATE Discounts " +
                    $"SET Title = '" + discTitleBox.Text + "', Amount = '" + amountDiscBox.Value.ToString() + "', " +
                    $"Description = '" + discDescBox.Text + "' " +
                    $"WHERE DiID = '" + id + "'");
                TransactionsTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void editChBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(chargesGrid.Rows[chargesGrid.CurrentRow.Index].Cells[0].Value);
            try
            {
                dbClasses.QueryInser(connectionString,
                    $"UPDATE Charges " +
                    $"SET Title = '" + chTitleBox.Text + "', Amount = '" + amountChBox.Value.ToString() + "', " +
                    $"Description = '" + chDescBox.Text + "' " +
                    $"WHERE ChID = '" + id + "'");
                TransactionsTab_SelectedCustom();
                MessageBox.Show("Successfully edited!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
