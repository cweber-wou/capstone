<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="CourseAssignmentMng" Codebehind="CourseAssignmentMng.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Nfficiency_dbConnectionString %>" 
                SelectCommand="SELECT * FROM [Assignments]"></asp:SqlDataSource>
        
        <div id="main">
       <h1> Assignment Management</h1>
            <p> 
                <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
            </p>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetCourses" TypeName="assignmentDB" 
                DataObjectTypeName="CourseClass" DeleteMethod="delete_Course" 
                InsertMethod="insert_Course" UpdateMethod="update_Course">
                <UpdateParameters>
                    <asp:Parameter Name="original_courseClass" Type="Object" />
                    <asp:Parameter Name="courseClass" Type="Object" />
                </UpdateParameters>
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
                    <asp:ListBox ID="lstCart" runat="server" CssClass="style2" Height="108px" 
                        Width="1299px"></asp:ListBox>
             </p>
            <p>
                    Assignment Description:
                    <asp:TextBox ID="txtDescription" runat="server" CausesValidation="True" 
                        Width="235px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDescription" 
                        ErrorMessage="*Please Enter a Description" ValidationGroup="addAssignment"></asp:RequiredFieldValidator>
             </p>
            <p>
                    <asp:ListBox ID="lstNewCart" runat="server" Height="16px" Visible="False" 
                        Width="240px"></asp:ListBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             </p>
            <p>
               <asp:Button ID="btnAdd" runat="server" Text="Add Assignments" 
            onclick="btnAdd_Click" ValidationGroup="addAssignment" /> &nbsp;&nbsp; 
                <asp:Button ID="btn_AddAssignment" runat="server" Text="Apply Assignment" 
                    onclick="btn_AddAssignment_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAssignmentBlob" runat="server" 
                    onclick="btnAssignmentBlob_Click" Text="Next &gt;&gt;" Width="70px" />
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
                Visible="False" EnableModelValidation="True">
                <Fields>
                    <asp:BoundField DataField="Course_id" HeaderText="Course_id" 
                        SortExpression="Course_id" />
                    <asp:BoundField DataField="aGUID" HeaderText="aGUID" 
                        SortExpression="aGUID" />
                    <asp:BoundField DataField="assignmentNumber" HeaderText="assignmentNumber" 
                        SortExpression="assignmentNumber" />
                    <asp:BoundField DataField="Num_Assignment" HeaderText="Num_Assignment" 
                        SortExpression="Num_Assignment" />
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
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
