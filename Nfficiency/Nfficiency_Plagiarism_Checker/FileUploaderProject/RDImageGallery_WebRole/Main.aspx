﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Main" Codebehind="Main.aspx.cs" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    <br />
What do you want to do?<br />
<br />
<asp:Button ID="btnRegister" runat="server" Text="Register" 
    onclick="btnRegister_Click" />
&nbsp;&nbsp;
<asp:Button ID="btnLogin" runat="server" Text="Login" 
    onclick="btnLogin_Click" />
<br />
    <asp:Button ID="btnProcess" runat="server" onclick="btnProcess_Click" 
        Text="Button" />
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/dynamicBlob.aspx">dynamicBlob</asp:HyperLink>
<br />
    <asp:TextBox ID="txtOut" runat="server" TextMode="MultiLine" Width="1040px"></asp:TextBox>
<br />

    <asp:Table ID="tblOut" runat="server" GridLines="Both">
    <asp:TableHeaderRow>
    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
    <asp:TableHeaderCell>File Name</asp:TableHeaderCell>
    <asp:TableHeaderCell>Test Type</asp:TableHeaderCell>
    <asp:TableHeaderCell>Word Count</asp:TableHeaderCell>
    <asp:TableHeaderCell>Link</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    </asp:Table>

    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" 
        EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Aid" HeaderText="Aid" SortExpression="Aid" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" 
                SortExpression="UserID" />
            <asp:BoundField DataField="TypeID" HeaderText="TypeID" 
                SortExpression="TypeID" />
            <asp:BoundField DataField="Link" HeaderText="Link" SortExpression="Link" />
            <asp:BoundField DataField="TestID" HeaderText="TestID" 
                SortExpression="TestID" />
        </Columns>
    </asp:GridView>
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
                                    Aid</th>
                                <th runat="server">
                                    UserID</th>
                                <th runat="server">
                                    TypeID</th>
                                <th runat="server">
                                    Link</th>
                                <th runat="server">
                                    TestID</th>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="getReports" 
        TypeName="RDImageGallery_WebRole.Old_App_Code.Tester">
    </asp:ObjectDataSource>
</asp:Content>

