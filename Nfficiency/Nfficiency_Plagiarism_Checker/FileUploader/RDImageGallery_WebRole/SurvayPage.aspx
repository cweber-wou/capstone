<%@ Page Title="" Language="C#" MasterPageFile="~/internalMasterPage.master" AutoEventWireup="true" CodeFile="SurvayPage.aspx.cs" Inherits="SurvayPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .validator
    {}
        .style1
        {
            width: 31%;
        }
        .style2
        {
            width: 76%;
        }
        .style3
        {
            width: 71%;
        }
    .style4
    {
        width: 233px;
    }
    .style5
    {
        width: 255px;
    }
    .style6
    {
        height: 26px;
    }
    .style7
    {
        width: 255px;
        height: 26px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <p id="arrival_date">
        <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
            <asp:ListItem>SkyHigh</asp:ListItem>
            <asp:ListItem>SmokeAndGlass</asp:ListItem>
            <asp:ListItem>UglyRed</asp:ListItem>
            <asp:ListItem>BasicBlue</asp:ListItem>
        </asp:DropDownList>
       
    </p>
<p>
        Due date:&nbsp;
        <asp:TextBox ID="txtDueDate" runat="server" Width="75px">mm/dd/yyyy</asp:TextBox>&nbsp;
        <asp:ImageButton ID="ibtnCalendar" runat="server" 
            ImageUrl="~/Images/Calendar.bmp" ImageAlign="Top" 
            CausesValidation="False" onclick="ibtnCalendar_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Arrival date is required." Display="Dynamic" 
            ControlToValidate="txtDueDate" CssClass="validator" 
            InitialValue="mm/dd/yyyy">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txtDueDate" CssClass="validator" Display="Dynamic" 
            ErrorMessage="Required Field & Compare Validator-You must enter a valid date." Operator="DataTypeCheck" 
            Type="Date">*</asp:CompareValidator>
       
    </p>
    <p>
        <asp:Calendar ID="clnDueDate" runat="server" Visible="False" 
            onselectionchanged="clnArrival_SelectionChanged"></asp:Calendar>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:accountdbConnectionString %>" 
            SelectCommand="SELECT * FROM [AssignmentDB]"></asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True"
            DataSourceID="SqlDataSource1">
            <EditItemTemplate>
                Assignment_id:
                <asp:Label ID="Assignment_idLabel1" runat="server" 
                    Text='<%# Eval("Assignment_id") %>' />
                <br />
                Course_id:
                <asp:TextBox ID="Course_idTextBox" runat="server" 
                    Text='<%# Bind("Course_id") %>' />
                <br />
                Assignment:
                <asp:TextBox ID="AssignmentTextBox" runat="server" 
                    Text='<%# Bind("Assignment") %>' />
                <br />
                Subject_id:
                <asp:TextBox ID="Subject_idTextBox" runat="server" 
                    Text='<%# Bind("Subject_id") %>' />
                <br />
                Instructor:
                <asp:TextBox ID="InstructorTextBox" runat="server" 
                    Text='<%# Bind("Instructor") %>' />
                <br />
                Instructor_rank:
                <asp:TextBox ID="Instructor_rankTextBox" runat="server" 
                    Text='<%# Bind("Instructor_rank") %>' />

                <br />
                Due_Date:
                <asp:TextBox ID="Due_DateTextBox" runat="server" 
                    Text='<%# Bind("Due_Date") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Course_id:
                <asp:TextBox ID="Course_idTextBox" runat="server" 
                    Text='<%# Bind("Course_id") %>' />
                <br />
                Assignment:
                <asp:TextBox ID="AssignmentTextBox" runat="server" 
                    Text='<%# Bind("Assignment") %>' />
                <br />
                Subject_id:
                <asp:TextBox ID="Subject_idTextBox" runat="server" 
                    Text='<%# Bind("Subject_id") %>' />
                <br />
                Instructor:
                <asp:TextBox ID="InstructorTextBox" runat="server" 
                    Text='<%# Bind("Instructor") %>' />
                <br />
                Instructor_rank:
                <asp:TextBox ID="Instructor_rankTextBox" runat="server" 
                    Text='<%# Bind("Instructor_rank") %>' />
                <br />
                Due_Date:
                <asp:TextBox ID="Due_DateTextBox" runat="server" 
                    Text='<%# Bind("Due_Date") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                Assignment_id:
                <asp:Label ID="Assignment_idLabel" runat="server" 
                    Text='<%# Eval("Assignment_id") %>' />
                <br />
                Course_id:
                <asp:Label ID="Course_idLabel" runat="server" Text='<%# Bind("Course_id") %>' />
                <br />
                Assignment:
                <asp:Label ID="AssignmentLabel" runat="server" 
                    Text='<%# Bind("Assignment") %>' />
                <br />
                Subject_id:
                <asp:Label ID="Subject_idLabel" runat="server" 
                    Text='<%# Bind("Subject_id") %>' />
                <br />
                Instructor:
                <asp:Label ID="InstructorLabel" runat="server" 
                    Text='<%# Bind("Instructor") %>' />
                <br />
                Instructor_rank:
                <asp:Label ID="Instructor_rankLabel" runat="server" 
                    Text='<%# Bind("Instructor_rank") %>' />
                <br />
                Due_Date:
                <asp:Label ID="Due_DateLabel" runat="server" Text='<%# Bind("Due_Date") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
        &nbsp;&nbsp;
        &nbsp;
        </p>
    <p title="Grade">
        &nbsp;<table class="style3">
            <tr>
                <td class="style4">
    <table class="style1">
        <tr>
            <td width="75">
                Course:</td>
            <td width="100">
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="Course_id" 
            DataValueField="Course_id">
        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Assignment:</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="Assignment" 
            DataValueField="Assignment">
        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Instructor:</td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="Instructor" 
            DataValueField="Instructor">
        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
                </td>
                <td>
                    <table class="style2">
                        <tr>
                            <td>
                                Difficulty:</td>
                            <td class="style5">
         <asp:RadioButton ID="rdoDiff1" runat="server" Text="One" 
            GroupName="classDiff" />
        <asp:RadioButton ID="rdoDiff2" runat="server" Text="Two" GroupName="classDiff" 
            oncheckedchanged="rdoSuite_CheckedChanged" />
        <asp:RadioButton ID="rdoDiff3" runat="server" Text="Three" 
            GroupName="classDiff" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Retake?</td>
                            <td class="style5">
        <asp:CheckBox ID="chkRetake" runat="server" TextAlign="Left" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                Grade:</td>
                            <td class="style7">
        <asp:DropDownList ID="ddlGrade" runat="server">
            <asp:ListItem Value="A"></asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem Value="C"></asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
        </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                <asp:TextBox ID="txtProf" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtCourse" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <p id="requests">Learning Outcome:</p>
    <p>
        <asp:TextBox ID="txtNote" runat="server" Rows="4" TextMode="MultiLine" 
            Width="250px"></asp:TextBox>
    </p>
    <p id="buttons">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="80px" 
            onclick="btnSubmit_Click" />&nbsp;
        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" 
            CausesValidation="False" onclick="btnClear_Click" />
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            CssClass="validator" 
    HeaderText="Please correct the following errors:" Width="988px" />
            </asp:Content>

