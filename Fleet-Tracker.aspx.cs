using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    SqlConnection sConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\dbFleetTracking.mdf;");
    SqlCommand sCmd;
    DataSet dSet;
    SqlDataAdapter dAdapter = new SqlDataAdapter();
    SqlCommandBuilder cBuilder;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void DDlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        pnITimeSheet.Visible = false;
        pnIVehicleAdmin.Visible = false;
        pnInTripData.Visible = false;
        pnUTimeSheet.Visible = false;
        pnUTripData.Visible = false;
        pnUVehicleAdmin.Visible = false;

        
        //
        if (DDlst.Text.Equals("Vehicle Information Administrator Table"))
        {
            VehicleGV.Visible = true;
            TimeSheetGV.Visible = false;
            TripGV.Visible = false;
            gvReport.Visible = false;
            lblSearch.Text = "Enter either the Vehicle id or the cargo body type";


            //delete fields
            try
            {
                lblError.Visible = false;
                ddlDelete.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From VehicleIA", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlDelete.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        else
            if (DDlst.Text.Equals("Trip/ Usage Manager Table"))
        {
            VehicleGV.Visible = false;
            TimeSheetGV.Visible = false;
            TripGV.Visible = true;
            gvReport.Visible = false;
            lblSearch.Text = "Enter either the trip id or trip destination";

            //delete fields
            try
            {
                lblError.Visible = false;
                ddlDelete.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From TripTable", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlDelete.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        else
            if (DDlst.Text.Equals("Timesheet Manager Table"))
        {
            VehicleGV.Visible = false;
            TimeSheetGV.Visible = true;
            TripGV.Visible = false;
            gvReport.Visible = false;
            lblSearch.Text = "Enter either the employee id or the employee first name";

            //delete fields
            try
            {
                lblError.Visible = false;
                ddlDelete.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From TimeSheetTable", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlDelete.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        else
            if (DDlst.Text.Equals("Service Manager Table"))
        {
            VehicleGV.Visible = false;
            TimeSheetGV.Visible = false;
            TripGV.Visible = false;
            gvReport.Visible = true;
        }
        else
        {
            VehicleGV.Visible = false;
            TimeSheetGV.Visible = false;
            TripGV.Visible = false;
            lblSearch.Text = "";

            ddlDelete.Items.Clear();
            ddlDelete.Items.Add("Null");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            if (TripGV.Visible == true)
            {
                sConn.Open();
                SqlCommand dbCMB = sConn.CreateCommand();
                dbCMB = new SqlCommand("DELETE FROM TripTable WHERE [Trip ID]='" + ddlDelete.Text + "'", sConn);
                dbCMB.ExecuteNonQuery();
                sConn.Close();


                sConn.Open();
                sCmd = new SqlCommand("Select * From TripTable", sConn);
                cBuilder = new SqlCommandBuilder(dAdapter);
                dAdapter.SelectCommand = sCmd;
                sCmd.ExecuteNonQuery();
                dSet = new DataSet();
                dAdapter.Fill(dSet, "TripTable");
                TripGV.DataSourceID = "";
                TripGV.DataSource = dSet;
                TripGV.DataMember = "TripTable";
                TripGV.DataBind();
                sConn.Close();
            }
            else
                if (TimeSheetGV.Visible == true)
            {
                sConn.Open();
                SqlCommand dbCMB = sConn.CreateCommand();
                dbCMB = new SqlCommand("DELETE FROM TimeSheetTable WHERE [Emplyee Id]='" + ddlDelete.Text + "'", sConn);
                dbCMB.ExecuteNonQuery();
                sConn.Close();


                sConn.Open();
                sCmd = new SqlCommand("Select * From TimeSheetTable", sConn);
                cBuilder = new SqlCommandBuilder(dAdapter);
                dAdapter.SelectCommand = sCmd;
                sCmd.ExecuteNonQuery();
                dSet = new DataSet();
                dAdapter.Fill(dSet, "TimeSheetTable");
                TimeSheetGV.DataSourceID = "";
                TimeSheetGV.DataSource = dSet;
                TimeSheetGV.DataMember = "TimeSheetTable";
                TimeSheetGV.DataBind();
                sConn.Close();
            }
            else
                if (VehicleGV.Visible == true)
            {
            sConn.Open();
                SqlCommand dbCMB = sConn.CreateCommand();
                dbCMB = new SqlCommand("DELETE FROM VehicleIA WHERE [Vehicle ID]='" + ddlDelete.Text + "'", sConn);
                dbCMB.ExecuteNonQuery();
                sConn.Close();


                sConn.Open();
                sCmd = new SqlCommand("Select * From VehicleIA", sConn);
                cBuilder = new SqlCommandBuilder(dAdapter);
                dAdapter.SelectCommand = sCmd;
                sCmd.ExecuteNonQuery();
                dSet = new DataSet();
                dAdapter.Fill(dSet, "VehicleIA");
                VehicleGV.DataSourceID = "";
                VehicleGV.DataSource = dSet;
                VehicleGV.DataMember = "VehicleIA";
                VehicleGV.DataBind();
                sConn.Close();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            if (VehicleGV.Visible == true)
            {
                sCmd = new SqlCommand("Select  * From [VehicleIA] where [Vehicle ID] = '" + txtSearch.Text +
                    "' or [Cargo Body Type]='" + txtSearch.Text + "'", sConn);
                cBuilder = new SqlCommandBuilder(dAdapter);
                dAdapter.SelectCommand = sCmd;
                dSet = new DataSet();
                dAdapter.Fill(dSet, "[VehicleIA]");
                VehicleGV.DataSourceID = "";
                VehicleGV.DataSource = dSet;
                VehicleGV.DataMember = "[VehicleIA]";
                VehicleGV.DataBind();
            }
            else
                if (TimeSheetGV.Visible == true)
            {
                sCmd = new SqlCommand("Select  * From TimeSheetTable where ([Emplyee Id] = '" + txtSearch.Text +
                    "') or EmpFName='" + txtSearch.Text + "'", sConn);
                cBuilder = new SqlCommandBuilder(dAdapter);
                dAdapter.SelectCommand = sCmd;
                dSet = new DataSet();
                dAdapter.Fill(dSet, "TimeSheetTable");
                TimeSheetGV.DataSourceID = "";
                TimeSheetGV.DataSource = dSet;
                TimeSheetGV.DataMember = "TimeSheetTable";
                TimeSheetGV.DataBind();
            }
            else
                if (TripGV.Visible == true)
            {
                sCmd = new SqlCommand("Select  * From TripTable where ([Trip Id] = '" + txtSearch.Text +
                    "') or [Trip Destination]='" + txtSearch.Text + "'", sConn);
                cBuilder = new SqlCommandBuilder(dAdapter);
                dAdapter.SelectCommand = sCmd;
                dSet = new DataSet();
                dAdapter.Fill(dSet, "TripTable");
                TripGV.DataSourceID = "";
                TripGV.DataSource = dSet;
                TripGV.DataMember = "TripTable";
                TripGV.DataBind();
            }
            else
            {
                lblSearch.Text = "Please select a table before you search";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }


    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sCmd = new SqlCommand("Select  * From [VehicleIA]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[VehicleIA]");
            VehicleGV.DataSourceID = "";
            VehicleGV.DataSource = dSet;
            VehicleGV.DataMember = "[VehicleIA]";
            VehicleGV.DataBind();

            sCmd = new SqlCommand("Select  * From [TimeSheetTable]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[TimeSheetTable]");
            TimeSheetGV.DataSourceID = "";
            TimeSheetGV.DataSource = dSet;
            TimeSheetGV.DataMember = "[TimeSheetTable]";
            TimeSheetGV.DataBind();

            sCmd = new SqlCommand("Select  * From [TripTable] ", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[TripTable]");
            TripGV.DataSourceID = "";
            TripGV.DataSource = dSet;
            TripGV.DataMember = "[TripTable]";
            TripGV.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }




    }

    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            if (VehicleGV.Visible == true)
            {
                pnUTimeSheet.Visible = false;
                pnUVehicleAdmin.Visible = true;
                pnUTripData.Visible = false;

                //Select Row

                ddUVA.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From VehicleIA", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddUVA.Items.Add(reader.GetSqlString(0).ToString());
                }
                reader.Close();
                sConn.Close();

                try
                {
                    lblError.Visible = false;
                    ddlUEmpID.Items.Clear();
                    sConn.Open();
                    sCmd = new SqlCommand("Select  * From TimeSheetTable", sConn);
                    reader = sCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ddlUEmpID.Items.Add(reader.GetSqlString(0).ToString());
                    }
                    sConn.Close();
                }
                catch (Exception exe)
                {
                    lblError.Text = exe.Message;
                    lblError.Visible = true;
                }
            }
            else
                if (TimeSheetGV.Visible == true)
            {
                pnUTimeSheet.Visible = true;
                pnUVehicleAdmin.Visible = false;
                pnUTripData.Visible = false;

                ddUTs.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From TimeSheetTable", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddUTs.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            else
            if (TripGV.Visible == true)
            {
                pnUTimeSheet.Visible = false;
                pnUVehicleAdmin.Visible = false;
                pnUTripData.Visible = true;

                ddUTr.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From TripTable", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddUTr.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();


                //Select Row
                ddlInAssignedV.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From VehicleIA", sConn);
                reader.Close();
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlUAssignedV.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            else
            {
                pnUTimeSheet.Visible = false;
                pnUVehicleAdmin.Visible = false;
                pnUTripData.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }



    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (VehicleGV.Visible == true)
        {
            pnITimeSheet.Visible = false;
            pnIVehicleAdmin.Visible = true;
            pnInTripData.Visible = false;

            try
            {
                lblError.Visible = false;
                ddlIEmpID1.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From TimeSheetTable", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlIEmpID1.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        else
           if (TimeSheetGV.Visible == true)
        {
            pnITimeSheet.Visible = true;
            pnIVehicleAdmin.Visible = false;
            pnInTripData.Visible = false;
        }
        else
        if (TripGV.Visible == true)
        {
            pnITimeSheet.Visible = false;
            pnIVehicleAdmin.Visible = false;
            pnInTripData.Visible = true;

            //Select Row
            try
            {
                lblError.Visible = false;
                ddlInAssignedV.Items.Clear();
                sConn.Open();
                sCmd = new SqlCommand("Select  * From VehicleIA", sConn);
                SqlDataReader reader;
                reader = sCmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlInAssignedV.Items.Add(reader.GetSqlString(0).ToString());
                }
                sConn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        else
        {
            pnITimeSheet.Visible = false;
            pnIVehicleAdmin.Visible = false;
            pnInTripData.Visible = false;
        }
    }

    protected void ddlDelete_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnVALoadRow_Click(object sender, EventArgs e)
    {
        //populates the update panel with the values from a selected row
        try
        {
            lblError.Visible = false;
            string temp;
            sConn.Open();
            sCmd = new SqlCommand("Select  * From VehicleIA", sConn);
            SqlDataReader reader;
            reader = sCmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetSqlString(0).ToString().Equals(ddUVA.Text))
                {
                    txtURegNum.Text = reader.GetSqlString(1).ToString();
                    txtUManu.Text = reader.GetSqlString(2).ToString();
                    txtUCOR.Text = reader.GetSqlInt32(3).ToString();
                    txtUEngineS.Text = reader.GetSqlDouble(4).ToString().Replace(',','.');
                    ddlUVehCon.Text = reader.GetSqlString(5).ToString();
                    ddlUCargoBT.Text = reader.GetSqlString(6).ToString();
                    ddlUUnitCon.Text = reader.GetSqlString(7).ToString();
                    txtUMS.Text = reader.GetSqlValue(8).ToString().Substring(0,10);
                    ddlUMaintenance.Text = reader.GetSqlString(9).ToString();
                    ddlUEmpID.Text = reader.GetSqlString(10).ToString();
                    txtUCChecks.Text = reader.GetSqlInt32(11).ToString();
                }
            }
            sConn.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnVAInsert_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            SqlCommand dbCMB = sConn.CreateCommand();
            dbCMB = new SqlCommand("INSERT INTO VehicleIA Values ('" + txtIVehicleID.Text + "','" +
              txtIRegNum.Text+"','"+txtIManu.Text+"','"+txtICOR.Text+"','"+txtIEngineS.Text+
              "','"+ddlIVehCon.Text + "','" + ddlICargoBT.Text + "','" + ddlIUnitCon.Text + "','" +
              txtInMS.Text +"','"+ ddlIMaintenance .Text+"','"+ ddlIEmpID1 .Text+"','"+
              txtICChecks.Text+"')", sConn);
            dbCMB.ExecuteNonQuery();
            sConn.Close();


            sConn.Open();
            sCmd = new SqlCommand("Select  * From [VehicleIA]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[VehicleIA]");
            VehicleGV.DataSourceID = "";
            VehicleGV.DataSource = dSet;
            VehicleGV.DataMember = "[VehicleIA]";
            VehicleGV.DataBind();
            sConn.Close();

            pnIVehicleAdmin.Visible = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnTsInsert_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            SqlCommand dbCMB = sConn.CreateCommand();
            dbCMB = new SqlCommand("INSERT INTO TimeSheetTable Values ('" + txtInEmployeeID.Text + "','" +
                txtInEmpFName.Text + "','" + txtInEmpLName.Text + "','" + dlInEJT.Text + "','" + txtInWorkDay.Text + "','" + txtInStartTime.Text + "','" + txtInEndTime.Text + "')", sConn);
            dbCMB.ExecuteNonQuery();
            sConn.Close();

            sConn.Open();
            sCmd = new SqlCommand("Select  * From [TimeSheetTable]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[TimeSheetTable]");
            TimeSheetGV.DataSourceID = "";
            TimeSheetGV.DataSource = dSet;
            TimeSheetGV.DataMember = "[TimeSheetTable]";
            TimeSheetGV.DataBind();
            sConn.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnTsLoadRow_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            sCmd = new SqlCommand("Select  * From TimeSheetTable", sConn);
            SqlDataReader reader;
            reader = sCmd.ExecuteReader();
            while (reader.Read())
            {
                if (ddUTs.Text.Equals(reader.GetSqlString(0).ToString()))
                {
                    txtUEmpFName.Text = reader.GetSqlString(1).ToString();
                    txtUEmpLName.Text = reader.GetSqlString(2).ToString();
                    dlUEJT.Text = reader.GetSqlString(3).ToString();
                    txtUWorkDay.Text = reader.GetSqlValue(4).ToString().Substring(0, 10);
                    txtUStartTime.Text = reader.GetSqlValue(5).ToString();
                    txtUEndTime.Text = reader.GetSqlValue(6).ToString();
                }

            }
            sConn.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnVAupdate_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            SqlCommand dbCMB = sConn.CreateCommand();
            dbCMB = new SqlCommand("UPDATE VehicleIA SET [Registration Number]='"+txtURegNum.Text+ "',Manufacturer='"+
                txtUManu.Text+ "',[current odometer reading]=" +
                int.Parse(txtUCOR.Text)+ ",[Engine Size]="+txtUEngineS.Text+",[Vehicle Configuration]='" + ddlUVehCon.Text +
                "', [Cargo Body Type]='" + ddlUCargoBT.Text + "',[Unit Condition]='" + ddlUUnitCon.Text +
                "',[Maintenance Schedule] = '" + txtUMS.Text + "',[Maintenance type]='" +
                ddlUMaintenance.Text+ "',EmpID='"+ ddlUEmpID.Text+ "',[Completed checks]='" +
                txtUCChecks.Text+"' WHERE [Vehicle ID]='" + ddUVA.Text + "'", sConn);
            dbCMB.ExecuteNonQuery();
            sConn.Close();


            sConn.Open();
            sCmd = new SqlCommand("Select  * From [VehicleIA]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[VehicleIA]");
            VehicleGV.DataSourceID = "";
            VehicleGV.DataSource = dSet;
            VehicleGV.DataMember = "[VehicleIA]";
            VehicleGV.DataBind();
            sConn.Close();

            pnIVehicleAdmin.Visible = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnTsUpdate1_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            SqlCommand dbCMB = sConn.CreateCommand();
            dbCMB = new SqlCommand("INSERT INTO TripTable Values ('" + txtInTripID.Text + "','" +
                ddlInTripDes.Text + "','" + ddlInAssignedV.Text + "','" + txtInTripDate.Text + "','" + txtInFuelUsage.Text + "','" + txtInIncidents.Text + "')", sConn);
            dbCMB.ExecuteNonQuery();
            sConn.Close();

            sCmd = new SqlCommand("Select  * From [TripTable]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[TripTable]");
            TripGV.DataSourceID = "";
            TripGV.DataSource = dSet;
            TripGV.DataMember = "[TripTable]";
            TripGV.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }

    }

    protected void ddlInAssignedV_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnTsUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            SqlCommand dbCMB = sConn.CreateCommand();
            dbCMB = new SqlCommand("UPDATE TimeSheetTable SET [EmpFName]='" +
                txtUEmpFName.Text + "',EmpLName='" + txtUEmpLName.Text + "',EmpJobType='" +
                dlUEJT.Text + "',WorkDay='" + txtUWorkDay.Text + "',StartTime='" + txtUStartTime.Text + "',EndTime='" + txtUEndTime.Text +
                "' WHERE [Emplyee Id]='" + ddUTs.Text + "'", sConn);
            dbCMB.ExecuteNonQuery();
            sConn.Close();

            sConn.Open();
            sCmd = new SqlCommand("Select  * From [TimeSheetTable]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[TimeSheetTable]");
            TimeSheetGV.DataSourceID = "";
            TimeSheetGV.DataSource = dSet;
            TimeSheetGV.DataMember = "[TimeSheetTable]";
            TimeSheetGV.DataBind();
            sConn.Close();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void btnTrLoadRow_Click(object sender, EventArgs e)
    {

        //Select Row
        try
        {
            lblError.Visible = false;
            sConn.Open();
            sCmd = new SqlCommand("Select  * From TripTable", sConn);
            SqlDataReader reader;
            reader = sCmd.ExecuteReader();
            while (reader.Read())
            {
                if (ddUTr.Text.Equals(reader.GetSqlString(0).ToString()))
                {
                    ddlUTripDes.Text = reader.GetSqlString(1).ToString();
                    ddlUAssignedV.Text = reader.GetSqlString(2).ToString();
                    txtUTripDate.Text = reader.GetSqlValue(3).ToString().Substring(0, 10);
                    txtUFuelUsage.Text = reader.GetSqlInt32(4).ToString();
                    txtUIncidents.Text = reader.GetSqlInt32(5).ToString();
                }
            }
            sConn.Close();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void btnTsUpdate0_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Visible = false;
            sConn.Open();
            SqlCommand dbCMB = sConn.CreateCommand();
            dbCMB = new SqlCommand("UPDATE TripTable SET [Trip Destination]='" +
                ddlUTripDes.Text + "',[Assigned Vehicle]='"
                + ddlUAssignedV.Text + "',[Trip Date]='" +
                txtUTripDate.Text + "',[Fuel Usage]='" + txtUFuelUsage.Text +
                "',[Incidents]='" + txtUIncidents.Text +
                "'WHERE [Trip ID]= '" + ddUTr.Text + "'", sConn);
            dbCMB.ExecuteNonQuery();
            sConn.Close();

            sCmd = new SqlCommand("Select  * From [TripTable]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet, "[TripTable]");
            TripGV.DataSourceID = "";
            TripGV.DataSource = dSet;
            TripGV.DataMember = "[TripTable]";
            TripGV.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        VehicleGV.Visible = false;
        TimeSheetGV.Visible = false;
        TripGV.Visible = false;
        gvReport.Visible = true;
       
        if (ddlReport.Text.Equals("Vehicle status report"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select  [Vehicle No.]=[Vehicle ID], [Registration No.]=[Registration Number]"+
                ",[Vehicle Type]=[Vehicle Configuration], Manufacturer, [Engine Size],"+
                "[Odometer Reading]=[current odometer reading] From  VehicleIA ", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
            if (ddlReport.Text.Equals("Daily and weekly service appointment list"))
        {

            sConn.Open();
            sCmd = new SqlCommand("Select  [Vehicle No.]=[Vehicle ID], [Appointment Time]=[StartTime]" +
                ",[Service to be performed]=[Maintenance type]," +
                "Case WHEN [Maintenance type]='Tyre Check' THEN 'p10: Tyre pressure ok'"+
                "WHEN [Maintenance type]='Major Service' THEN 'p3: Successful'"+
                "WHEN [Maintenance type]='Oil Service' THEN 'p8: Oil and water refilled' END AS[Procedure code & Description]"+
                " From  VehicleIA JOIN  TimeSheetTable ON VehicleIA.EmpID= TimeSheetTable.[Emplyee Id]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
            if (ddlReport.Text.Equals("Service requirements job sheet"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select  [Vehicle No.]=[Vehicle ID],[Service Type]=[Maintenance type], [Appointment Time]=[StartTime]" +
                ",[Appointment Date]=[Maintenance Schedule]," +
                "Case WHEN [Maintenance type]='Tyre Check' THEN 'Replace old parts'" +
                "WHEN [Maintenance type]='Major Service' THEN 'Full overhall'" +
                "WHEN [Maintenance type]='Oil Service' THEN 'Replace oil if required'" +
                "END AS[Work to be completed]" +
                "From  VehicleIA JOIN  TimeSheetTable ON VehicleIA.EmpID= TimeSheetTable.[Emplyee Id]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
            if (ddlReport.Text.Equals("Daily; Weekly; monthly; yearly report on vehicle services completed"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select  [Vehicle No.]=[Vehicle ID],[Date Of Service]=[Maintenance Schedule]," +
                "[Type of service completed]=[Maintenance type]," +
                "Case WHEN [Maintenance type]='Tyre Check' THEN 'p3'" +
                "WHEN [Maintenance type]='Major Service' THEN 'p10'" +
                "WHEN [Maintenance type]='Oil Service' THEN 'p8'" +
                "END AS[Procedure Code]," +
                "Case WHEN [Maintenance type]='Tyre Check' THEN '56.99'" +
                "WHEN [Maintenance type]='Major Service' THEN '98.99'" +
                "WHEN [Maintenance type]='Oil Service' THEN '314.50'" +
                "END AS[Cost]" +
                "From  VehicleIA JOIN  TimeSheetTable ON VehicleIA.EmpID= TimeSheetTable.[Emplyee Id]", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
            if (ddlReport.Text.Equals("Specific Service Report"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select [Completed service],[Vehicle No.],[Service Information] FROM"+
                "(SELECT [Completed service]=[Maintenance type],DATEDIFF(day,[Maintenance Schedule],'" + DateTime.Today + "')as[diff]" +
                ",[Vehicle No.]=[Vehicle ID], [Service Information]='Successfully completed'"+
                " From  VehicleIA JOIN  TimeSheetTable ON VehicleIA.EmpID= TimeSheetTable.[Emplyee Id])as a" +
                " WHERE diff>0", sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
            if (ddlReport.Text.Equals("Daily/ weekly/ monthly planned trip report"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select Destination=[Trip Destination],"+
                "Case WHEN [Trip Destination]='Pretoria' THEN '50' "+
                "WHEN [Trip Destination]='Joburg' THEN '191'"+
                "WHEN [Trip Destination]='Durban' THEN '689'" +
                "WHEN [Trip Destination]='Polokwane' THEN '283'" +
                "WHEN [Trip Destination]='CapeTown' THEN '850' END AS [Kilometres Estimated]" +
                ",[Vehicle No.]=[Assigned Vehicle] FROM TripTable"
                , sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
            if (ddlReport.Text.Equals("Daily/ weekly/ monthly completed trip report"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select Destination=[Trip Destination]," +
                "Case WHEN [Trip Destination]='Pretoria' THEN '50' " +
                "WHEN [Trip Destination]='Joburg' THEN '191'" +
                "WHEN [Trip Destination]='Durban' THEN '689'" +
                "WHEN [Trip Destination]='Polokwane' THEN '283'" +
                "WHEN [Trip Destination]='CapeTown' THEN '850' END AS [Kilometres Estimated]" +
                ",[Vehicle No.]=[Assigned Vehicle], Incidents FROM TripTable"
                , sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }
        else
             if (ddlReport.Text.Equals("Daily/ weekly/ monthly timesheet report"))
        {
            sConn.Open();
            sCmd = new SqlCommand("Select [Employee No.]=[Emplyee Id],[Employee Name]= EmpFName"+
                ",[Employee Surname]=EmpLName,DATEDIFF(hour,StartTime,EndTime) AS [Regular Hours Worked]," +
                "Case WHEN DATEDIFF(hour,StartTime,EndTime)>4 THEN DATEDIFF(hour,StartTime,EndTime)-4"+
                " WHEN  DATEDIFF(hour,StartTime,EndTime) <= 4 THEN 0 END AS Overtime "+
                "FROM TimeSheetTable"
                , sConn);
            cBuilder = new SqlCommandBuilder(dAdapter);
            sCmd.ExecuteNonQuery();
            dAdapter.SelectCommand = sCmd;
            dSet = new DataSet();
            dAdapter.Fill(dSet);
            gvReport.DataSourceID = "";
            gvReport.DataSource = dSet;

            gvReport.DataBind();
            sConn.Close();
        }




    }
}