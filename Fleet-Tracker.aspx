<%@ Page Title="Fleet-Tracker" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Fleet-Tracker.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Feet-Tracker</h3>
    <p>
        <asp:Label ID="lblDropdown" runat="server" Text="Please Select your Table"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDlst" runat="server" OnSelectedIndexChanged="DDlst_SelectedIndexChanged">
            <asp:ListItem>Null</asp:ListItem>
            <asp:ListItem>Vehicle Information Administrator Table</asp:ListItem>
            <asp:ListItem>Trip/ Usage Manager Table</asp:ListItem>
            <asp:ListItem>Timesheet Manager Table</asp:ListItem>
        </asp:DropDownList>
    &nbsp;<asp:Button ID="BtnShowTable" runat="server" Text="Show Table" OnClick="Button1_Click" />
    &nbsp;<asp:Button ID="btnShowAll" runat="server" OnClick="btnShowAll_Click" Text="Show All" />
    </p>
    <p>
        <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="Report" Width="63px" />
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="ddlReport" runat="server" Height="32px" Width="181px">
            <asp:ListItem>Vehicle status report</asp:ListItem>
            <asp:ListItem>Daily and weekly service appointment list</asp:ListItem>
            <asp:ListItem>Service requirements job sheet</asp:ListItem>
            <asp:ListItem>Daily; Weekly; monthly; yearly report on vehicle services completed</asp:ListItem>
            <asp:ListItem>Specific Service Report</asp:ListItem>
            <asp:ListItem>Daily/ weekly/ monthly planned trip report</asp:ListItem>
            <asp:ListItem>Daily/ weekly/ monthly completed trip report</asp:ListItem>
            <asp:ListItem>Daily/ weekly/ monthly timesheet report</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Error Message" Visible="False" Font-Size="XX-Large" Font-Underline="True" ForeColor="#CC0000"></asp:Label>
        <asp:GridView ID="gvReport" runat="server" Visible="False">
        </asp:GridView>
    </p>
    <p>
        <asp:GridView ID="TimeSheetGV" runat="server" AutoGenerateColumns="False" DataKeyNames="Emplyee Id" DataSourceID="TSDS" Visible="False">
            <Columns>
                <asp:BoundField DataField="Emplyee Id" HeaderText="Emplyee Id" ReadOnly="True" SortExpression="Emplyee Id" />
                <asp:BoundField DataField="EmpFName" HeaderText="EmpFName" SortExpression="EmpFName" />
                <asp:BoundField DataField="EmpLName" HeaderText="EmpLName" SortExpression="EmpLName" />
                <asp:BoundField DataField="EmpJobType" HeaderText="EmpJobType" SortExpression="EmpJobType" />
                <asp:BoundField DataField="WorkDay" HeaderText="WorkDay" SortExpression="WorkDay" />
                <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
                <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="TSDS" runat="server" ConnectionString="<%$ ConnectionStrings:CString %>" SelectCommand="SELECT * FROM [TimeSheetTable]"></asp:SqlDataSource>
        <asp:GridView ID="TripGV" runat="server" AutoGenerateColumns="False" DataKeyNames="Trip ID" DataSourceID="TDS" Visible="False">
            <Columns>
                <asp:BoundField DataField="Trip ID" HeaderText="Trip ID" ReadOnly="True" SortExpression="Trip ID" />
                <asp:BoundField DataField="Trip Destination" HeaderText="Trip Destination" SortExpression="Trip Destination" />
                <asp:BoundField DataField="Assigned Vehicle" HeaderText="Assigned Vehicle" SortExpression="Assigned Vehicle" />
                <asp:BoundField DataField="Trip Date" HeaderText="Trip Date" SortExpression="Trip Date" />
                <asp:BoundField DataField="Fuel Usage" HeaderText="Fuel Usage" SortExpression="Fuel Usage" />
                <asp:BoundField DataField="Incidents" HeaderText="Incidents" SortExpression="Incidents" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="TDS" runat="server" ConnectionString="<%$ ConnectionStrings:CString %>" SelectCommand="SELECT * FROM [TripTable]"></asp:SqlDataSource>
        <asp:GridView ID="VehicleGV" runat="server" AutoGenerateColumns="False" DataKeyNames="Vehicle ID" DataSourceID="VDS" Visible="False">
            <Columns>
                <asp:BoundField DataField="Vehicle ID" HeaderText="Vehicle ID" ReadOnly="True" SortExpression="Vehicle ID" />
                <asp:BoundField DataField="Registration Number" HeaderText="Registration Number" SortExpression="Registration Number" />
                <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" SortExpression="Manufacturer" />
                <asp:BoundField DataField="current odometer reading" HeaderText="current odometer reading" SortExpression="current odometer reading" />
                <asp:BoundField DataField="Engine Size" HeaderText="Engine Size" SortExpression="Engine Size" />
                <asp:BoundField DataField="Vehicle Configuration" HeaderText="Vehicle Configuration" SortExpression="Vehicle Configuration" />
                <asp:BoundField DataField="Cargo Body Type" HeaderText="Cargo Body Type" SortExpression="Cargo Body Type" />
                <asp:BoundField DataField="Unit Condition" HeaderText="Unit Condition" SortExpression="Unit Condition" />
                <asp:BoundField DataField="Maintenance Schedule" HeaderText="Maintenance Schedule" SortExpression="Maintenance Schedule" />
                <asp:BoundField DataField="Maintenance type" HeaderText="Maintenance type" SortExpression="Maintenance type" />
                <asp:BoundField DataField="EmpID" HeaderText="EmpID" SortExpression="EmpID" />
                <asp:BoundField DataField="Completed checks" HeaderText="Completed checks" SortExpression="Completed checks" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="VDS" runat="server" ConnectionString="<%$ ConnectionStrings:CString %>" SelectCommand="SELECT * FROM [VehicleIA]"></asp:SqlDataSource>
    </p>
    <p><asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />&nbsp;
        <asp:Label ID="lblSearch" runat="server"></asp:Label>
    </p>
    <p>&nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></p>
    <p><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlDelete" runat="server" OnSelectedIndexChanged="ddlDelete_SelectedIndexChanged">
            <asp:ListItem>Null</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update TABLE" OnClick="btnUpdate_Click1" />
    </p>
    <p>
    <asp:Panel ID="pnUVehicleAdmin" runat="server" Visible="False">
        <p style="margin-left: 40px">
            <asp:Label ID="Label11" runat="server" Text="Please Select the Vehicle ID of the row you wish to modify"></asp:Label>
            &nbsp;in the Vehicle Table<br />
            <asp:DropDownList ID="ddUVA" runat="server">
            </asp:DropDownList>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnVALoadRow" runat="server" Text="Load Row" OnClick="btnVALoadRow_Click" />
            <br />
            <asp:Label ID="Label46" runat="server" Text="RegNum"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label47" runat="server" Text="Manufacturer"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label48" runat="server" Text="current odreading"></asp:Label>
            &nbsp;
            <asp:Label ID="Label49" runat="server" Text="Engine Size"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label50" runat="server" Text="Vehicle Configuration"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label51" runat="server" Text="Cargo Body Type"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label52" runat="server" Text="Unit Condition"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label53" runat="server" Text="Maintenance Schedule"></asp:Label>
            <br />
            <asp:TextBox ID="txtURegNum" runat="server" Width="89px"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtUManu" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtUCOR" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUEngineS" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="ddlUVehCon" runat="server">
                <asp:ListItem>Truck Trailer</asp:ListItem>
                <asp:ListItem>Bus</asp:ListItem>
                <asp:ListItem>Single-Unit</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="ddlUCargoBT" runat="server" Height="21px" Width="75px">
                <asp:ListItem>pole</asp:ListItem>
                <asp:ListItem>9-5 seats</asp:ListItem>
                <asp:ListItem>dump</asp:ListItem>
                <asp:ListItem>log</asp:ListItem>
                <asp:ListItem>auto transporter</asp:ListItem>
                <asp:ListItem>garbage</asp:ListItem>
                <asp:ListItem>cargo tank</asp:ListItem>
                <asp:ListItem>no cargo body</asp:ListItem>
                <asp:ListItem>bus(16-19 seats)</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlUUnitCon" runat="server">
                <asp:ListItem>Fine                </asp:ListItem>
                <asp:ListItem>Needs Attention     </asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="txtUMS" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label57" runat="server" Text="Maintenance type"></asp:Label>
            &nbsp;
            <asp:Label ID="Label58" runat="server" Text="EmpID"></asp:Label>
            &nbsp; &nbsp;<asp:Label ID="Label59" runat="server" Text="Completed checks"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            <asp:DropDownList ID="ddlUMaintenance" runat="server">
                <asp:ListItem>Tyre Check          </asp:ListItem>
                <asp:ListItem>Major Service       </asp:ListItem>
                <asp:ListItem>Oil Service         </asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="ddlUEmpID" runat="server">
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="txtUCChecks" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnVAupdate" runat="server" Text="Update Row" OnClick="btnVAupdate_Click" />
        </p>
    </asp:Panel>
    
    <asp:Panel ID="pnUTimeSheet" runat="server" Visible="False">
        <p style="margin-left: 40px">
            <asp:Label ID="Label12" runat="server" Text="Please Select the Employee ID of the row you wish to modify"></asp:Label>
            &nbsp;in the Timesheet Table<br />
            <asp:DropDownList ID="ddUTs" runat="server">
            </asp:DropDownList>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnTsLoadRow" runat="server" Text="Load Row" OnClick="btnTsLoadRow_Click" />
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label14" runat="server" Text="EmpFName"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label15" runat="server" Text="EmpLName"></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label37" runat="server" Text="EmpJobType"></asp:Label>
            &nbsp;&nbsp;&nbsp; Workday&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; StartTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EndTime<br />
            <asp:TextBox ID="txtUEmpFName" runat="server" Width="89px"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtUEmpLName" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="dlUEJT" runat="server">
                <asp:ListItem>Driver    </asp:ListItem>
                <asp:ListItem>Mechanic  </asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="txtUWorkDay" runat="server" Width="89px"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtUStartTime" runat="server" Width="89px"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtUEndTime" runat="server" Width="89px"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnTsUpdate" runat="server" Text="Update Row" OnClick="btnTsUpdate_Click" />
        </p>
    </asp:Panel>
    
    <asp:Panel ID="pnUTripData" runat="server" Visible="False">
        <p style="margin-left: 40px">
            <asp:Label ID="Label16" runat="server" Text="Please Select the Trip ID of the row you wish to modify"></asp:Label>
            &nbsp;in the Trip Table<br />
            <asp:DropDownList ID="ddUTr" runat="server">
            </asp:DropDownList>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnTrLoadRow" runat="server" Text="Load Row" OnClick="btnTrLoadRow_Click" />
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label39" runat="server" Text="Trip Destination"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label40" runat="server" Text="Assigned Vehicle"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; Tripdate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fuel Usage&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Incidents</p>
        <p style="margin-left: 40px">
            <asp:DropDownList ID="ddlUTripDes" runat="server">
                <asp:ListItem>Pretoria</asp:ListItem>
                <asp:ListItem>Joburg</asp:ListItem>
                <asp:ListItem>Durban</asp:ListItem>
                <asp:ListItem>Polokwane</asp:ListItem>
                <asp:ListItem>CapeTown</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlUAssignedV" runat="server" OnSelectedIndexChanged="ddlInAssignedV_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUTripDate" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUFuelUsage" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtUIncidents" runat="server" Width="89px"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnTsUpdate0" runat="server" Text="Update Row" OnClick="btnTsUpdate0_Click" />
        </p>
    </asp:Panel>
    
    </p>
    <p><asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
    <asp:Panel ID="pnIVehicleAdmin" runat="server" Visible="False">
        <p style="margin-left: 40px">
            Please enter the values for the new row and then click the button to insert the new row<br />
            <asp:Label ID="Label6" runat="server" Text="Vehicle ID"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label41" runat="server" Text="RegNum"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label42" runat="server" Text="Manufacturer"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label43" runat="server" Text="current odreading"></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label44" runat="server" Text="Engine Size"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="Vehicle Configuration"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Cargo Body Type"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="Unit Condition"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Maintenance Schedule"></asp:Label>
            &nbsp;&nbsp;
            <br />
            <asp:TextBox ID="txtIVehicleID" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtIRegNum" runat="server" Width="89px"></asp:TextBox>
&nbsp;<asp:TextBox ID="txtIManu" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtICOR" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtIEngineS" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="ddlIVehCon" runat="server">
                <asp:ListItem>Truck Trailer</asp:ListItem>
                <asp:ListItem>Bus</asp:ListItem>
                <asp:ListItem>Single-Unit</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="ddlICargoBT" runat="server" Height="21px" Width="75px">
                <asp:ListItem>pole</asp:ListItem>
                <asp:ListItem>9-5 seats</asp:ListItem>
                <asp:ListItem>dump</asp:ListItem>
                <asp:ListItem>log</asp:ListItem>
                <asp:ListItem>auto transporter</asp:ListItem>
                <asp:ListItem>garbage</asp:ListItem>
                <asp:ListItem>cargo tank</asp:ListItem>
                <asp:ListItem>no cargo body</asp:ListItem>
                <asp:ListItem>bus(16-19 seats)</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlIUnitCon" runat="server">
                <asp:ListItem>Fine                </asp:ListItem>
                <asp:ListItem>Needs Attention     </asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="txtInMS" runat="server"></asp:TextBox>
            &nbsp;</p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label54" runat="server" Text="Maintenance type"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="Label55" runat="server" Text="EmpID"></asp:Label>
            &nbsp; &nbsp;<asp:Label ID="Label56" runat="server" Text="Completed checks"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            <asp:DropDownList ID="ddlIMaintenance" runat="server">
                <asp:ListItem>Tyre Check          </asp:ListItem>
                <asp:ListItem>Major Service       </asp:ListItem>
                <asp:ListItem>Oil Service         </asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="ddlIEmpID1" runat="server">
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="txtICChecks" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnVAInsert" runat="server" OnClick="btnVAInsert_Click" Text="Insert Row" />
        </p>
        </asp:Panel>
    <asp:Panel ID="pnITimeSheet" runat="server" Visible="False">
        <p style="margin-left: 40px">
            Please enter the values for the new row and then click the button to insert the new row<br />
            </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label30" runat="server" Text="Employee ID"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label31" runat="server" Text="EmpFName"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label32" runat="server" Text="EmpLName"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label36" runat="server" Text="EmpJobType"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; Workday&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; StartTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EndTime<br />
            <asp:TextBox ID="txtInEmployeeID" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtInEmpFName" runat="server" Width="89px"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtInEmpLName" runat="server" Width="89px"></asp:TextBox>
            &nbsp;<asp:DropDownList ID="dlInEJT" runat="server">
                <asp:ListItem>Driver    </asp:ListItem>
                <asp:ListItem>Mechanic  </asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:TextBox ID="txtInWorkDay" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtInStartTime" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtInEndTime" runat="server" Width="89px"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnTsInsert" runat="server" OnClick="btnTsInsert_Click" Text="Inser Row" />
        </p>
        </asp:Panel>
    <asp:Panel ID="pnInTripData" runat="server" Visible="False">
        <p style="margin-left: 40px">
            Please enter the values for the new row and then click the button to insert the new row<br />
            </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label33" runat="server" Text="Trip ID"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label34" runat="server" Text="Trip Destination"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label35" runat="server" Text="Assigned Vehicle"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; Tripdate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fuel Usage&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Incidents<br />
            <asp:TextBox ID="txtInTripID" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;<asp:DropDownList ID="ddlInTripDes" runat="server">
                <asp:ListItem>Pretoria</asp:ListItem>
                <asp:ListItem>Joburg</asp:ListItem>
                <asp:ListItem>Durban</asp:ListItem>
                <asp:ListItem>Polokwane</asp:ListItem>
                <asp:ListItem>CapeTown</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlInAssignedV" runat="server" OnSelectedIndexChanged="ddlInAssignedV_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtInTripDate" runat="server" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtInFuelUsage" runat="server" Width="89px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtInIncidents" runat="server" Width="89px"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnTsUpdate1" runat="server" Text="Insert Row" OnClick="btnTsUpdate1_Click" />
        </p>
        </asp:Panel></p>
</asp:Content>
