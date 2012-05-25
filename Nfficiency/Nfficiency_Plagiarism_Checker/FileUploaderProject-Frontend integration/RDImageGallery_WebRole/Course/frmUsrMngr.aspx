<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsrMngr.aspx.cs" Inherits="CS430_ASPNET_Role_Records.frmUsrMngr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


    
    <div id="page">
        
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
            <br />
        </div>
        <div id="main">

            <h1>Add Assignment for courses you own: <br/></h1>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:justin_dbConnectionString %>" 
                
                
                SelectCommand="SELECT * FROM [Courses] WHERE ([Course_Owner] = @Course_Owner)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblUser_ID" DefaultValue="ckessel" 
                        Name="Course_Owner" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
            <br />
            <asp:Label ID="lblUserID_Label" runat="server" Text="Instructor Name: "></asp:Label>
            <asp:Label ID="lblUser_ID" runat="server" Text="Default_User_ID"></asp:Label>
            <br />
            
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Course_ID" DataSourceID="SqlDataSource1" 
                onselectedindexchanged="GridView3_SelectedIndexChanged" Width="692px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" 
                        InsertVisible="False" ReadOnly="True" SortExpression="Course_ID" />
                    <asp:BoundField DataField="Course_Name" HeaderText="Course_Name" 
                        SortExpression="Course_Name" />
                    <asp:BoundField DataField="Course_Description" HeaderText="Course_Description" 
                        SortExpression="Course_Description" />
                    <asp:BoundField DataField="Course_EnrollmentKey" HeaderText="Course_EnrollmentKey" 
                        SortExpression="Course_EnrollmentKey" />
                    <asp:BoundField DataField="Course_Owner" HeaderText="Course_Owner" 
                        SortExpression="Course_Owner" />
                </Columns>
            </asp:GridView>
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetCategory" TypeName="CategoryDB" 
                UpdateMethod="UpdateCategory" ConflictDetection="CompareAllValues" 
                ondeleted="ObjectDataSource1_Deleted" 
                onupdated="ObjectDataSource1_Updated" DataObjectTypeName="Category" 
                InsertMethod="InsertCatigory" 
                OldValuesParameterFormatString="original_{0}">
                <UpdateParameters>
                    <asp:Parameter Name="original_Category" Type="Object" />
                    <asp:Parameter Name="category" Type="Object" />
                </UpdateParameters>
               
            </asp:ObjectDataSource>
                <asp:Label ID="lblError" runat="server" EnableViewState="False" ForeColor="Green">
                </asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DetailsView ID="DetailsView1" runat="server" Height="139px" Width="170px" 
                AutoGenerateRows="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                DefaultMode="Insert" GridLines="None" 
                oniteminserted="DetailsView1_ItemInserted" AllowPaging="True" 
                Visible="False">
                <Fields>
                    <asp:BoundField DataField="Customer_ID" HeaderText="Customer_ID" 
                        ReadOnly="true" SortExpression="Customer_ID" Visible="False" />
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" 
                        SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" 
                        SortExpression="Last_Name" />
                    <asp:BoundField DataField="Street" HeaderText="Street" 
                        SortExpression="Street" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                    <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                </Fields>
                <FieldHeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                <InsertRowStyle BackColor="LightGray" />
                <CommandRowStyle BackColor="#A9A9A9" />
            </asp:DetailsView>

        </div>
   
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>

