<%@ Page Language="C#" AutoEventWireup="true" Inherits="custMngr" Codebehind="custMngr.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course Management</title>
    <link href="Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="header">
            <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1">
            </asp:TreeView>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
        <div id="main">
            <h1>Customer Maintenance</h1>
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                DataSourceID="ObjectDataSource1" ForeColor="Black" 
                onrowdeleted="GridView1_RowDeleted" onrowupdated="GridView1_RowUpdated1" 
                onselectedindexchanged="GridView1_SelectedIndexChanged1" Height="175px" 
                Width="741px" AllowPaging="True" PageSize="3" >
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="Customer_ID" HeaderText="Customer_ID" 
                        SortExpression="Customer_ID" >
                    </asp:BoundField>
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" 
                        SortExpression="First_Name" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" 
                        SortExpression="Last_Name" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Street" HeaderText="Street" 
                        SortExpression="Street" />
                    <asp:BoundField DataField="City" HeaderText="City" 
                        SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State" 
                        SortExpression="State" />
                    <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                </Columns>
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="Black" />
                <AlternatingRowStyle BackColor="LightGray" ForeColor="Black" />
                <EditRowStyle BackColor="#F46D11" ForeColor="White" />
            </asp:GridView>

            &nbsp;&nbsp;
            
            SEARCH [Use % as wildcard]:<br />
            Last Name:&nbsp;
            <asp:TextBox ID="txtLName" runat="server" AutoPostBack="True"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" />
&nbsp;<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetCategory" TypeName="CategoryDB" 
                UpdateMethod="UpdateCategory" ConflictDetection="CompareAllValues" 
                ondeleted="ObjectDataSource1_Deleted" 
                onupdated="ObjectDataSource1_Updated1" DataObjectTypeName="Category" 
                InsertMethod="InsertCatigory" 
                OldValuesParameterFormatString="original_{0}" 
                DeleteMethod="DeleteCategory">
                <UpdateParameters>
                    <asp:Parameter Name="original_Category" Type="Object" />
                    <asp:Parameter Name="category" Type="Object" />
                </UpdateParameters>
               
            </asp:ObjectDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Nfficiency_dbConnectionString %>" 
                DeleteCommand="DELETE FROM [Customers] WHERE [Customer_id] = @Customer_id" 
                InsertCommand="INSERT INTO [Customers] ([first_name], [last_name], [street], [city], [state], [zip]) VALUES (@first_name, @last_name, @street, @city, @state, @zip)" 
                SelectCommand="SELECT * FROM [Customers] WHERE ([last_name] like @last_name)" 
                UpdateCommand="UPDATE [Customers] SET [first_name] = @first_name, [last_name] = @last_name, [street] = @street, [city] = @city, [state] = @state, [zip] = @zip WHERE [Customer_id] = @Customer_id">
                <DeleteParameters>
                    <asp:Parameter Name="Customer_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="first_name" Type="String" />
                    <asp:Parameter Name="last_name" Type="String" />
                    <asp:Parameter Name="street" Type="String" />
                    <asp:Parameter Name="city" Type="String" />
                    <asp:Parameter Name="state" Type="String" />
                    <asp:Parameter Name="zip" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtLName" Name="last_name" PropertyName="Text" 
                        Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="first_name" Type="String" />
                    <asp:Parameter Name="last_name" Type="String" />
                    <asp:Parameter Name="street" Type="String" />
                    <asp:Parameter Name="city" Type="String" />
                    <asp:Parameter Name="state" Type="String" />
                    <asp:Parameter Name="zip" Type="String" />
                    <asp:Parameter Name="Customer_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" DataKeyNames="Customer_id" 
                DataSourceID="SqlDataSource1" Width="657px">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="Customer_id" HeaderText="Customer_id" 
                        InsertVisible="False" ReadOnly="True" SortExpression="Customer_id" />
                    <asp:BoundField DataField="first_name" HeaderText="first_name" 
                        SortExpression="first_name" />
                    <asp:BoundField DataField="last_name" HeaderText="last_name" 
                        SortExpression="last_name" />
                    <asp:BoundField DataField="street" HeaderText="street" 
                        SortExpression="street" />
                    <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                    <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                    <asp:BoundField DataField="zip" HeaderText="zip" SortExpression="zip" />
                </Columns>
            </asp:GridView>
            <p id="new">To create a new customer, enter the customer information and click Insert.</p>
            <p>
                <asp:Label ID="lblError" runat="server" EnableViewState="False" ForeColor="Green">
                </asp:Label>
            </p>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="161px" Width="425px" 
                AutoGenerateRows="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                DefaultMode="Insert" GridLines="None" 
                oniteminserted="DetailsView1_ItemInserted1" AllowPaging="True">
                <Fields>
                    <asp:BoundField DataField="Customer_ID" HeaderText="Customer_ID" 
                        SortExpression="Customer_ID" />
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
    </div>
    </form>
</body>
</html>
