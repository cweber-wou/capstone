<%@ Page Title="" Language="C#" MasterPageFile="~/internalMasterPage.master" AutoEventWireup="true" CodeFile="App.aspx.cs" Inherits="App" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Dynamic Theme:
        <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
            <asp:ListItem>SkyHigh</asp:ListItem>
            <asp:ListItem>SmokeAndGlass</asp:ListItem>
            <asp:ListItem>UglyRed</asp:ListItem>
            <asp:ListItem>BasicBlue</asp:ListItem>
        </asp:DropDownList>
</p>
<p>
        Search for Assignment:</p>
    <p>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="21px" 
            ImageUrl="~/Images/pen_paper_icon.bmp" Width="16px" />
&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" >
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="Course_idLabel" runat="server" Text='<%# Eval("Course_id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssignmentLabel" runat="server" 
                            Text='<%# Eval("Assignment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Subject_idLabel" runat="server" 
                            Text='<%# Eval("Subject_id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InstructorLabel" runat="server" 
                            Text='<%# Eval("Instructor") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Instructor_rankLabel" runat="server" 
                            Text='<%# Eval("Instructor_rank") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Due_DateLabel" runat="server" Text='<%# Eval("Due_Date") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                            Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="Course_idTextBox" runat="server" 
                            Text='<%# Bind("Course_id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AssignmentTextBox" runat="server" 
                            Text='<%# Bind("Assignment") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Subject_idTextBox" runat="server" 
                            Text='<%# Bind("Subject_id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="InstructorTextBox" runat="server" 
                            Text='<%# Bind("Instructor") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Instructor_rankTextBox" runat="server" 
                            Text='<%# Bind("Instructor_rank") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Due_DateTextBox" runat="server" 
                            Text='<%# Bind("Due_Date") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                            Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="Course_idTextBox" runat="server" 
                            Text='<%# Bind("Course_id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AssignmentTextBox" runat="server" 
                            Text='<%# Bind("Assignment") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Subject_idTextBox" runat="server" 
                            Text='<%# Bind("Subject_id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="InstructorTextBox" runat="server" 
                            Text='<%# Bind("Instructor") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Instructor_rankTextBox" runat="server" 
                            Text='<%# Bind("Instructor_rank") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Due_DateTextBox" runat="server" 
                            Text='<%# Bind("Due_Date") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="Course_idLabel" runat="server" Text='<%# Eval("Course_id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssignmentLabel" runat="server" 
                            Text='<%# Eval("Assignment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Subject_idLabel" runat="server" 
                            Text='<%# Eval("Subject_id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InstructorLabel" runat="server" 
                            Text='<%# Eval("Instructor") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Instructor_rankLabel" runat="server" 
                            Text='<%# Eval("Instructor_rank") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Due_DateLabel" runat="server" Text='<%# Eval("Due_Date") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">
                                        Course_id</th>
                                    <th runat="server">
                                        Assignment</th>
                                    <th runat="server">
                                        Subject_id</th>
                                    <th runat="server">
                                        Instructor</th>
                                    <th runat="server">
                                        Instructor_rank</th>
                                    <th runat="server">
                                        Due_Date</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Label ID="Course_idLabel" runat="server" Text='<%# Eval("Course_id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AssignmentLabel" runat="server" 
                            Text='<%# Eval("Assignment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Subject_idLabel" runat="server" 
                            Text='<%# Eval("Subject_id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InstructorLabel" runat="server" 
                            Text='<%# Eval("Instructor") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Instructor_rankLabel" runat="server" 
                            Text='<%# Eval("Instructor_rank") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Due_DateLabel" runat="server" Text='<%# Eval("Due_Date") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:accountdbConnectionString %>" 
                
                SelectCommand="SELECT [Course_id],[Assignment],[Subject_id],[Instructor],[Instructor_rank],[Due_Date] FROM [AssignmentDB] WHERE ([Assignment] LIKE '%' + @Assignment + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="%" 
                        Name="Assignment" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    </p>
</asp:Content>

