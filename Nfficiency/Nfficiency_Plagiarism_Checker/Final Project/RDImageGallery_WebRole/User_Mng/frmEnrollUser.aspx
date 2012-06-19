<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEnrollUser.aspx.cs" Inherits="CS430_ASPNET_Role_Records.User_Mng.frmEnrollUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="CourseClass" DeleteMethod="delete_Course" 
        InsertMethod="insert_Course" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetCourses" TypeName="CourseClassDB" UpdateMethod="update_Course">
        <UpdateParameters>
            <asp:Parameter Name="original_courseClass" Type="Object" />
            <asp:Parameter Name="courseClass" Type="Object" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblInfo2" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <h1>Enroll in Course</h1><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" 
                SortExpression="Course_ID" />
            <asp:BoundField DataField="Course_Name" HeaderText="Course_Name" 
                SortExpression="Course_Name" />
            <asp:BoundField DataField="Course_Description" HeaderText="Course_Description" 
                SortExpression="Course_Description" />
                <asp:BoundField DataField="Course_Owner" HeaderText="Course_Owner" 
                SortExpression="Course_Owner" />
          <%--  <asp:BoundField DataField="Course_EnrollmentKey" 
                HeaderText="Course_EnrollmentKey" SortExpression="Course_EnrollmentKey" /> --%>
            <asp:BoundField DataField="Course_EnrollmentKey" 
                HeaderText="Course_EnrollmentKey" SortExpression="Course_EnrollmentKey" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
