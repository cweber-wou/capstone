<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Main" Codebehind="WCReport.aspx.cs" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:ListView ID="ListView1" runat="server" 
        EnableModelValidation="True" onsorting="ListView1_Sorting" >
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                    <asp:Label ID="AidLabel" runat="server" Text='<%# Eval("Aid") %>' />
                </td>
                <td>
                    <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID") %>' />
                </td>
                <td>
                    <asp:Label ID="TypeIDLabel" runat="server" Text='<%# Eval("TypeID") %>' />
                </td>
                <td>
                    <asp:HyperLink ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
                </td>
                <td>
                    <asp:Label ID="TestIDLabel" runat="server" Text='<%# Eval("TestID") %>' />
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
                    <asp:TextBox ID="AidTextBox" runat="server" Text='<%# Bind("Aid") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UserIDTextBox" runat="server" Text='<%# Bind("UserID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TypeIDTextBox" runat="server" Text='<%# Bind("TypeID") %>' />
                </td>
                <td>
                    <asp:HyperLink ID="LinkTextBox" runat="server" Text='<%# Bind("Link") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TestIDTextBox" runat="server" Text='<%# Bind("TestID") %>' />
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
                    <asp:TextBox ID="AidTextBox" runat="server" Text='<%# Bind("Aid") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UserIDTextBox" runat="server" Text='<%# Bind("UserID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TypeIDTextBox" runat="server" Text='<%# Bind("TypeID") %>' />
                </td>
                <td>
                    <asp:HyperLink ID="LinkTextBox" runat="server" Text='<%# Bind("Link") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TestIDTextBox" runat="server" Text='<%# Bind("TestID") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td>
                    <asp:Label ID="AidLabel" runat="server" Text='<%# Eval("Aid") %>' />
                </td>
                <td>
                    <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID") %>' />
                </td>
                <td>
                    <asp:Label ID="TypeIDLabel" runat="server" Text='<%# Eval("TypeID") %>' />
                </td>
                <td>
                    <asp:LinkButton ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' CommandArgument='<%# Eval("Link") %>'  
    OnClick="LinkLabel_Click"  />
                </td>
                <td>
                    <asp:Label ID="TestIDLabel" runat="server" Text='<%# Eval("TestID") %>' />
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
                                    User ID</th>
                                <th runat="server">
                                    File Name</th>
                                <th runat="server">
                                    Test Type</th>
                                <th runat="server">
                                    UUID</th>
                                <th runat="server">
                                    Word Count</th>
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
                    <asp:Label ID="AidLabel" runat="server" Text='<%# Eval("Aid") %>' />
                </td>
                <td>
                    <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID") %>' />
                </td>
                <td>
                    <asp:Label ID="TypeIDLabel" runat="server" Text='<%# Eval("TypeID") %>' />
                </td>
                <td>
                    <asp:Label ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
                </td>
                <td>
                    <asp:Label ID="TestIDLabel" runat="server" Text='<%# Eval("TestID") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    
</asp:Content>

