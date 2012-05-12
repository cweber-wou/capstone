<%@ Page Language="C#" AutoEventWireup="true" Inherits="OrderPage" Codebehind="OrderPage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course List</title>
    <link href="Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {}
        .style6
        {}
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="header">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:justin_dbConnectionString %>" 
                SelectCommand="SELECT * FROM [Assignments]"></asp:SqlDataSource>
        </div>
        <div id="main">
       <h1> Assignment Management</h1>
            <p> 
                <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
            </p>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetCourses" TypeName="CourseClassDB">
            </asp:ObjectDataSource>
            <p>
                    &nbsp;
                    <asp:Button ID="btnRemove" runat="server" CssClass="style5" Text="Remove Item" 
                        Width="100px" onclick="btnRemove_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEmpty" runat="server" CssClass="style6" Text="Empty Assignments" 
                        Width="131px" onclick="btnEmpty_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
             </p>
            <p>
                    &nbsp;
                    <asp:ListBox ID="lstCart" runat="server" CssClass="style2" Height="167px" 
                        Width="1299px"></asp:ListBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             </p>
            <p>
               <asp:Button ID="btnAdd" runat="server" Text="Add Assignments" 
            onclick="btnAdd_Click" /> &nbsp;<asp:DropDownList ID="ddNumAssign" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="btn_Add" runat="server" Text="Add Courses" />
            </p>
            <p>
                To create a new order, enter the Order information and click Insert.</p>
            <p>
                <asp:Label ID="lblError" runat="server" EnableViewState="False" ForeColor="Green">
                </asp:Label>
            </p>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="16px" Width="51px" AutoGenerateRows="False"
                CellPadding="4" DataSourceID="ObjectDataSource2" DefaultMode="Insert" GridLines="None"
                OnItemInserted="DetailsView1_ItemInserted" AllowPaging="True" 
                Visible="False">
                <Fields>
                    <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" 
                        SortExpression="Course_ID" />
                    <asp:BoundField DataField="Course_Name" HeaderText="Course_Name" 
                        SortExpression="Course_Name" />
                    <asp:BoundField DataField="Course_Description" HeaderText="Course_Description" 
                        SortExpression="Course_Description" />
                    <asp:BoundField DataField="Course_EnrollmentKey" HeaderText="Course_EnrollmentKey" 
                        SortExpression="Course_EnrollmentKey" />
                    <asp:BoundField DataField="Course_Owner" HeaderText="Course_Owner" 
                        SortExpression="Course_Owner" />
                </Fields>
                <FieldHeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                <InsertRowStyle BackColor="LightGray" />
                <CommandRowStyle BackColor="#A9A9A9" />
            </asp:DetailsView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetOrder"
                TypeName="OrderDB" UpdateMethod="UpdateOrder" ConflictDetection="CompareAllValues"
                OnDeleted="ObjectDataSource1_Deleted" 
                OnUpdated="ObjectDataSource1_Updated" DataObjectTypeName="Order"
                InsertMethod="InsertOrder" OldValuesParameterFormatString="original_{0}" 
                DeleteMethod="DeleteOrder">
                <UpdateParameters>
                    <asp:Parameter Name="original_Order" Type="Object" />
                    <asp:Parameter Name="Order" Type="Object" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:Label ID="lblDate" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
