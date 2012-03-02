<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="WouSchedulerProject.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
        InsertItemPosition="LastItem" DataKeyNames="CID">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                        Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="CIDLabel" runat="server" Text='<%# Eval("CID") %>' />
                </td>
                <td>
                    <asp:Label ID="DIDLabel" runat="server" Text='<%# Eval("DID") %>' />
                </td>
                <td>
                    <asp:Label ID="DescriptionLabel" runat="server" 
                        Text='<%# Eval("Description") %>' />
                </td>
                <td>
                    <asp:Label ID="HoursLabel" runat="server" Text='<%# Eval("Hours") %>' />
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
                    <asp:TextBox ID="CIDTextBox" runat="server" Text='<%# Bind("CID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DIDTextBox" runat="server" Text='<%# Bind("DID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" 
                        Text='<%# Bind("Description") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HoursTextBox" runat="server" Text='<%# Bind("Hours") %>' />
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
                    <asp:TextBox ID="CIDTextBox" runat="server" Text='<%# Bind("CID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DIDTextBox" runat="server" Text='<%# Bind("DID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" 
                        Text='<%# Bind("Description") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HoursTextBox" runat="server" Text='<%# Bind("Hours") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                        Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="CIDLabel" runat="server" Text='<%# Eval("CID") %>' />
                </td>
                <td>
                    <asp:Label ID="DIDLabel" runat="server" Text='<%# Eval("DID") %>' />
                </td>
                <td>
                    <asp:Label ID="DescriptionLabel" runat="server" 
                        Text='<%# Eval("Description") %>' />
                </td>
                <td>
                    <asp:Label ID="HoursLabel" runat="server" Text='<%# Eval("Hours") %>' />
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
                                </th>
                                <th runat="server">
                                    CID</th>
                                <th runat="server">
                                    DID</th>
                                <th runat="server">
                                    Description</th>
                                <th runat="server">
                                    Hours</th>
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
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                        Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="CIDLabel" runat="server" Text='<%# Eval("CID") %>' />
                </td>
                <td>
                    <asp:Label ID="DIDLabel" runat="server" Text='<%# Eval("DID") %>' />
                </td>
                <td>
                    <asp:Label ID="DescriptionLabel" runat="server" 
                        Text='<%# Eval("Description") %>' />
                </td>
                <td>
                    <asp:Label ID="HoursLabel" runat="server" Text='<%# Eval("Hours") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Course" DeleteMethod="DeleteCourse" 
        InsertMethod="InsertCourse" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAllCourses" TypeName="CourseDB" UpdateMethod="UpdateCourse">
        <UpdateParameters>
            <asp:Parameter Name="original_Course" Type="Object" />
            <asp:Parameter Name="course" Type="Object" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
