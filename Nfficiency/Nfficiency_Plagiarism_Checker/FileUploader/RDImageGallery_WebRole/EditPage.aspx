<%@ Page Title="" Language="C#" MasterPageFile="~/internalMasterPage.master" AutoEventWireup="true" CodeFile="EditPage.aspx.cs" Inherits="EditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 55%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="True" 
    onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
    <asp:ListItem>SkyHigh</asp:ListItem>
    <asp:ListItem>SmokeAndGlass</asp:ListItem>
    <asp:ListItem>UglyRed</asp:ListItem>
    <asp:ListItem>BasicBlue</asp:ListItem>
</asp:DropDownList>
<br />
<br />
    Select Edit button to edit an assignment:<br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" pagesize="3"
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Assignment_id" 
        DataSourceID="SqlDataSource1" Height="179px" Width="321px">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Assignment_id" HeaderText="Assignment_id" 
                InsertVisible="False" ReadOnly="True" SortExpression="Assignment_id" />
            <asp:TemplateField HeaderText="Course_id" SortExpression="Course_id">
               
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Course_id") %>'></asp:TextBox>
                
                </EditItemTemplate>

                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Course_id") %>'></asp:Label>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("Assignment") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
           <asp:BoundField DataField="Subject_id" HeaderText="Subject_id" 
                SortExpression="Subject_id" />
            <asp:BoundField DataField="Instructor" HeaderText="Instructor" 
                SortExpression="Instructor" />
            <asp:BoundField DataField="Instructor_rank" HeaderText="Instructor_rank" 
                SortExpression="Instructor_rank" />
            <asp:TemplateField HeaderText="Due_Date" SortExpression="Due_Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Due_Date") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Calendar ID="Calendar3" runat="server"  
                        SelectedDate='<%# Eval("Due_Date") %>' VisibleDate='<%# Eval("Due_Date") %>'>
                    </asp:Calendar>
                </ItemTemplate>
            </asp:TemplateField>
                         
        </Columns>
        </asp:GridView>
    <table class="style4">
        <tr>
            <td>
            Course_ID</td>
            <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Due_Date</td>
        </tr>
        <tr>
        <td width="75">
            Assignment_id</td>
        <td width="75">
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
            <td rowspan="4">
            <asp:Calendar ID="Calendar4" runat="server" Height="17px" 
                onselectionchanged="Calendar4_SelectionChanged" Visible="False" Width="88px">
            </asp:Calendar>
            <asp:LinkButton ID="ibtnCalendar" runat="server" onclick="ibtnCalendar_Click1">Calendar</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
            Subject_ID</td>
            <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            Instructor</td>
            <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Instructor_rank</td>
            <td>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="valInstructorRank" runat="server" 
                    ControlToValidate="TextBox6" Type="Integer" 
                    ErrorMessage="Range Validator-Your must enter a number between 1-10" 
                    MaximumValue="10" MinimumValue="1" ></asp:RangeValidator>
            </td>
        </tr>
</table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:accountdbConnectionString %>" 
        DeleteCommand="DELETE FROM [AssignmentDB] WHERE [Assignment_id] = @original_Assignment_id AND (([Course_id] = @original_Course_id) OR ([Course_id] IS NULL AND @original_Course_id IS NULL)) AND (([Assignment] = @original_Assignment) OR ([Assignment] IS NULL AND @original_Assignment IS NULL)) AND (([Subject_id] = @original_Subject_id) OR ([Subject_id] IS NULL AND @original_Subject_id IS NULL)) AND (([Instructor] = @original_Instructor) OR ([Instructor] IS NULL AND @original_Instructor IS NULL)) AND (([Instructor_rank] = @original_Instructor_rank) OR ([Instructor_rank] IS NULL AND @original_Instructor_rank IS NULL)) AND (([Due_Date] = @original_Due_Date) OR ([Due_Date] IS NULL AND @original_Due_Date IS NULL))" 
        InsertCommand="INSERT INTO [AssignmentDB] ([Course_id], [Assignment], [Subject_id], [Instructor], [Instructor_rank], [Due_Date]) VALUES (@Course_id, @Assignment, @Subject_id, @Instructor, @Instructor_rank, @Due_Date)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [AssignmentDB]" 
        UpdateCommand="UPDATE [AssignmentDB] SET [Course_id] = @Course_id, [Assignment] = @Assignment, [Subject_id] = @Subject_id, [Instructor] = @Instructor, [Instructor_rank] = @Instructor_rank, [Due_Date] = @Due_Date WHERE [Assignment_id] = @original_Assignment_id AND (([Course_id] = @original_Course_id) OR ([Course_id] IS NULL AND @original_Course_id IS NULL)) AND (([Assignment] = @original_Assignment) OR ([Assignment] IS NULL AND @original_Assignment IS NULL)) AND (([Subject_id] = @original_Subject_id) OR ([Subject_id] IS NULL AND @original_Subject_id IS NULL)) AND (([Instructor] = @original_Instructor) OR ([Instructor] IS NULL AND @original_Instructor IS NULL)) AND (([Instructor_rank] = @original_Instructor_rank) OR ([Instructor_rank] IS NULL AND @original_Instructor_rank IS NULL)) AND (([Due_Date] = @original_Due_Date) OR ([Due_Date] IS NULL AND @original_Due_Date IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_Assignment_id" Type="Int32" />
            <asp:Parameter Name="original_Course_id" Type="String" />
            <asp:Parameter Name="original_Assignment" Type="String" />
            <asp:Parameter Name="original_Subject_id" Type="String" />
            <asp:Parameter Name="original_Instructor" Type="String" />
            <asp:Parameter Name="original_Instructor_rank" Type="String" />
            <asp:Parameter Name="original_Due_Date" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Course_id" Type="String" />
            <asp:Parameter Name="Assignment" Type="String" />
            <asp:Parameter Name="Subject_id" Type="String" />
            <asp:Parameter Name="Instructor" Type="String" />
            <asp:Parameter Name="Instructor_rank" Type="String" />
            <asp:Parameter Name="Due_Date" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Course_id" Type="String" />
            <asp:Parameter Name="Assignment" Type="String" />
            <asp:Parameter Name="Subject_id" Type="String" />
            <asp:Parameter Name="Instructor" Type="String" />
            <asp:Parameter Name="Instructor_rank" Type="String" />
            <asp:Parameter Name="Due_Date" Type="String" />
            <asp:Parameter Name="original_Assignment_id" Type="Int32" />
            <asp:Parameter Name="original_Course_id" Type="String" />
            <asp:Parameter Name="original_Assignment" Type="String" />
            <asp:Parameter Name="original_Subject_id" Type="String" />
            <asp:Parameter Name="original_Instructor" Type="String" />
            <asp:Parameter Name="original_Instructor_rank" Type="String" />
            <asp:Parameter Name="original_Due_Date" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
<asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
    Width="74px" />
<asp:Label ID="lblError" runat="server"></asp:Label>
<asp:TextBox ID="TextBox9" runat="server" Visible="False"></asp:TextBox>
</asp:Content>

