<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="KeyWCtest.aspx.cs" Inherits="RDImageGallery_WebRole.WebForm1" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="mine" runat="server"></asp:PlaceHolder>

    
    <asp:ListView ID="ListView1" runat="server" 
        EnableModelValidation="True" >
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
                  <asp:Repeater ID="keywordDateRepeat" runat="server"  DataSource='<%# Eval("keyData") %>'>
                <ItemTemplate>
                <td>
                    
                    <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                </td>
                </ItemTemplate>
                </asp:Repeater>
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
                  <asp:Repeater ID="keywordDateRepeat" runat="server"  DataSource='<%# Eval("keyData") %>'>
                <ItemTemplate>
                <td>
                   
                    <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                </td>
                </ItemTemplate>
                </asp:Repeater>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table id="Table1" runat="server" 
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
                  <asp:Repeater ID="keywordDateRepeat" runat="server"  DataSource='<%# Eval("keyData") %>'>
                <ItemTemplate>
                <td>
                   
                    <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                </td>
                </ItemTemplate>
                </asp:Repeater>
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
                    <asp:LinkButton ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' CommandArgument='<%# Eval("Link") %>'/>
                </td>
                <td>
                    <asp:Label ID="TestIDLabel" runat="server" Text='<%# Eval("TestID") %>' />
                </td>
                <asp:Repeater ID="keywordDateRepeat" runat="server"  DataSource='<%# Eval("keyData") %>'>
                <ItemTemplate>
                <td>
                   
                    <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                </td>
                </ItemTemplate>
                </asp:Repeater>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
       
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="Tr2" runat="server" style="background-color:#DCDCDC;color: #000000;">
                                <th id="Th1" runat="server">
                                    User ID</th>
                                <th id="Th2" runat="server">
                                    File Name</th>
                                <th id="Th3" runat="server">
                                    Test Type</th>
                                <th id="Th4" runat="server">
                                    UUID</th>

                                
                                
                               

                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" 
                        style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        
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
                 <asp:Repeater ID="keywordDateRepeat" runat="server"  DataSource='<%# Eval("keyData") %>'>
                <ItemTemplate>
                <td>
                    
                    <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                </td>
                </ItemTemplate>
                </asp:Repeater>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
