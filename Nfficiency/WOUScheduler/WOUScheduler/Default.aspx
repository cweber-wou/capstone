<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">
        </asp:GridView>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:BoundField DataField="CID" HeaderText="CID" SortExpression="CID" />
                <asp:BoundField DataField="DID" HeaderText="DID" SortExpression="DID" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCourses" 
            TypeName="CourseDB"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCatagories" 
            TypeName="RoomDB"></asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
