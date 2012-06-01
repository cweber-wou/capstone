<%@ Page Title="Course Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course_Mngr.aspx.cs" Inherits="CS430_ASPNET_Role_Records.Course_Mngr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="CourseClass" DeleteMethod="delete_Course" 
        InsertMethod="insert_Course" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetCourses" TypeName="CourseClassDB" UpdateMethod="update_Course">
        <UpdateParameters>
            <asp:Parameter Name="original_courseClass" Type="Object" />
            <asp:Parameter Name="courseClass" Type="Object" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <p id="new">
        To create a new Course, enter the Course information and click Insert.</p>
    <p>
        <asp:Label ID="lblError0" runat="server" EnableViewState="False" 
            ForeColor="Green">
                </asp:Label>
    </p>
   
    <p>
        <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </p>
    <asp:DetailsView ID="DetailsView2" runat="server" AllowPaging="True" 
        AutoGenerateRows="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
        DefaultMode="Insert" GridLines="None" Height="161px" 
        oniteminserted="DetailsView1_ItemInserted1" Width="425px">
        <Fields>
            <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" 
                SortExpression="Course_ID" />

            <asp:BoundField DataField="Course_Name" HeaderText="Course_Name" 
                SortExpression="Course_Name" />

            <asp:BoundField DataField="Course_Description" HeaderText="Course_Description" 
                SortExpression="Course_Description" />
            
             <asp:BoundField DataField="Course_EnrollmentKey" HeaderText="Course_EnrollmentKey" 
                SortExpression="Course_EnrollmentKey"/>

             <asp:BoundField DataField="Course_Owner" HeaderText="Course_Owner" 
                SortExpression="Course_Owner" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>

        <FieldHeaderStyle BackColor="#711515" Font-Bold="True" ForeColor="White" />
        <InsertRowStyle BackColor="#B51032" />
        <CommandRowStyle BackColor="#ED9F9F" />
    </asp:DetailsView>


    <br />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
