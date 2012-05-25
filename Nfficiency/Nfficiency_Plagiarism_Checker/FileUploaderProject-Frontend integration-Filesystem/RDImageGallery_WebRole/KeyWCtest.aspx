<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="KeyWCtest.aspx.cs" Inherits="NfficiencyPD.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="NfficiencyPD.Old_App_Code.KeyWcData" 
        InsertMethod="AddEntry" SelectMethod="GetEntries" 
        TypeName="NfficiencyPD.Old_App_Code.KeyWCAccess" 
        UpdateMethod="AddEntry">
    </asp:ObjectDataSource>


    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
        EnableModelValidation="True" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC;">
                <td>
                </td>
                <td>
                    <asp:Label ID="TIDLabel" runat="server" Text='<%# Eval("TID") %>' />
                </td>
                <td>
                    <asp:Label ID="ifWcLabel" runat="server" Text='<%# Eval("ifWc") %>' />
                </td>
                <td>
                    <asp:Label ID="whileWcLabel" runat="server" Text='<%# Eval("whileWc") %>' />
                </td>
                <td>
                    <asp:Label ID="forWcLabel" runat="server" Text='<%# Eval("forWc") %>' />
                </td>
                <td>
                    <asp:Label ID="foreachWcLabel" runat="server" Text='<%# Eval("foreachWc") %>' />
                </td>
                <td>
                    <asp:Label ID="publicWcLabel" runat="server" Text='<%# Eval("publicWc") %>' />
                </td>
                <td>
                    <asp:Label ID="privateWcLabel" runat="server" Text='<%# Eval("privateWc") %>' />
                </td>
                <td>
                    <asp:Label ID="voidWcLabel" runat="server" Text='<%# Eval("voidWc") %>' />
                </td>
                <td>
                    <asp:Label ID="importWcLabel" runat="server" Text='<%# Eval("importWc") %>' />
                </td>
                <td>
                    <asp:Label ID="newWcLabel" runat="server" Text='<%# Eval("newWc") %>' />
                </td>
                <td>
                    <asp:Label ID="constWcLabel" runat="server" Text='<%# Eval("constWc") %>' />
                </td>
                <td>
                    <asp:Label ID="switchWcLabel" runat="server" Text='<%# Eval("switchWc") %>' />
                </td>
                <td>
                    <asp:Label ID="staticWcLabel" runat="server" Text='<%# Eval("staticWc") %>' />
                </td>
                <td>
                    <asp:Label ID="TimestampLabel" runat="server" Text='<%# Eval("Timestamp") %>' />
                </td>
                <td>
                    <asp:Label ID="PartitionKeyLabel" runat="server" 
                        Text='<%# Eval("PartitionKey") %>' />
                </td>
                <td>
                    <asp:Label ID="RowKeyLabel" runat="server" Text='<%# Eval("RowKey") %>' />
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
                    <asp:TextBox ID="TIDTextBox" runat="server" Text='<%# Bind("TID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ifWcTextBox" runat="server" Text='<%# Bind("ifWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="whileWcTextBox" runat="server" Text='<%# Bind("whileWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="forWcTextBox" runat="server" Text='<%# Bind("forWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="foreachWcTextBox" runat="server" 
                        Text='<%# Bind("foreachWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="publicWcTextBox" runat="server" 
                        Text='<%# Bind("publicWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="privateWcTextBox" runat="server" 
                        Text='<%# Bind("privateWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="voidWcTextBox" runat="server" Text='<%# Bind("voidWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="importWcTextBox" runat="server" 
                        Text='<%# Bind("importWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="newWcTextBox" runat="server" Text='<%# Bind("newWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="constWcTextBox" runat="server" Text='<%# Bind("constWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="switchWcTextBox" runat="server" 
                        Text='<%# Bind("switchWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="staticWcTextBox" runat="server" 
                        Text='<%# Bind("staticWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TimestampTextBox" runat="server" 
                        Text='<%# Bind("Timestamp") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PartitionKeyTextBox" runat="server" 
                        Text='<%# Bind("PartitionKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="RowKeyTextBox" runat="server" Text='<%# Bind("RowKey") %>' />
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
                    <asp:TextBox ID="TIDTextBox" runat="server" Text='<%# Bind("TID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ifWcTextBox" runat="server" Text='<%# Bind("ifWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="whileWcTextBox" runat="server" Text='<%# Bind("whileWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="forWcTextBox" runat="server" Text='<%# Bind("forWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="foreachWcTextBox" runat="server" 
                        Text='<%# Bind("foreachWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="publicWcTextBox" runat="server" 
                        Text='<%# Bind("publicWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="privateWcTextBox" runat="server" 
                        Text='<%# Bind("privateWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="voidWcTextBox" runat="server" Text='<%# Bind("voidWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="importWcTextBox" runat="server" 
                        Text='<%# Bind("importWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="newWcTextBox" runat="server" Text='<%# Bind("newWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="constWcTextBox" runat="server" Text='<%# Bind("constWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="switchWcTextBox" runat="server" 
                        Text='<%# Bind("switchWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="staticWcTextBox" runat="server" 
                        Text='<%# Bind("staticWc") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TimestampTextBox" runat="server" 
                        Text='<%# Bind("Timestamp") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PartitionKeyTextBox" runat="server" 
                        Text='<%# Bind("PartitionKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="RowKeyTextBox" runat="server" Text='<%# Bind("RowKey") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC;color: #000000;">
                <td>
                </td>
                <td>
                    <asp:Label ID="TIDLabel" runat="server" Text='<%# Eval("TID") %>' />
                </td>
                <td>
                    <asp:Label ID="ifWcLabel" runat="server" Text='<%# Eval("ifWc") %>' />
                </td>
                <td>
                    <asp:Label ID="whileWcLabel" runat="server" Text='<%# Eval("whileWc") %>' />
                </td>
                <td>
                    <asp:Label ID="forWcLabel" runat="server" Text='<%# Eval("forWc") %>' />
                </td>
                <td>
                    <asp:Label ID="foreachWcLabel" runat="server" Text='<%# Eval("foreachWc") %>' />
                </td>
                <td>
                    <asp:Label ID="publicWcLabel" runat="server" Text='<%# Eval("publicWc") %>' />
                </td>
                <td>
                    <asp:Label ID="privateWcLabel" runat="server" Text='<%# Eval("privateWc") %>' />
                </td>
                <td>
                    <asp:Label ID="voidWcLabel" runat="server" Text='<%# Eval("voidWc") %>' />
                </td>
                <td>
                    <asp:Label ID="importWcLabel" runat="server" Text='<%# Eval("importWc") %>' />
                </td>
                <td>
                    <asp:Label ID="newWcLabel" runat="server" Text='<%# Eval("newWc") %>' />
                </td>
                <td>
                    <asp:Label ID="constWcLabel" runat="server" Text='<%# Eval("constWc") %>' />
                </td>
                <td>
                    <asp:Label ID="switchWcLabel" runat="server" Text='<%# Eval("switchWc") %>' />
                </td>
                <td>
                    <asp:Label ID="staticWcLabel" runat="server" Text='<%# Eval("staticWc") %>' />
                </td>
                <td>
                    <asp:Label ID="TimestampLabel" runat="server" Text='<%# Eval("Timestamp") %>' />
                </td>
                <td>
                    <asp:Label ID="PartitionKeyLabel" runat="server" 
                        Text='<%# Eval("PartitionKey") %>' />
                </td>
                <td>
                    <asp:Label ID="RowKeyLabel" runat="server" Text='<%# Eval("RowKey") %>' />
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
                                    TID</th>
                                <th runat="server">
                                    ifWc</th>
                                <th runat="server">
                                    whileWc</th>
                                <th runat="server">
                                    forWc</th>
                                <th runat="server">
                                    foreachWc</th>
                                <th runat="server">
                                    publicWc</th>
                                <th runat="server">
                                    privateWc</th>
                                <th runat="server">
                                    voidWc</th>
                                <th runat="server">
                                    importWc</th>
                                <th runat="server">
                                    newWc</th>
                                <th runat="server">
                                    constWc</th>
                                <th runat="server">
                                    switchWc</th>
                                <th runat="server">
                                    staticWc</th>
                                <th runat="server">
                                    Timestamp</th>
                                <th runat="server">
                                    PartitionKey</th>
                                <th runat="server">
                                    RowKey</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" 
                        style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                <td>
                </td>
                <td>
                    <asp:Label ID="TIDLabel" runat="server" Text='<%# Eval("TID") %>' />
                </td>
                <td>
                    <asp:Label ID="ifWcLabel" runat="server" Text='<%# Eval("ifWc") %>' />
                </td>
                <td>
                    <asp:Label ID="whileWcLabel" runat="server" Text='<%# Eval("whileWc") %>' />
                </td>
                <td>
                    <asp:Label ID="forWcLabel" runat="server" Text='<%# Eval("forWc") %>' />
                </td>
                <td>
                    <asp:Label ID="foreachWcLabel" runat="server" Text='<%# Eval("foreachWc") %>' />
                </td>
                <td>
                    <asp:Label ID="publicWcLabel" runat="server" Text='<%# Eval("publicWc") %>' />
                </td>
                <td>
                    <asp:Label ID="privateWcLabel" runat="server" Text='<%# Eval("privateWc") %>' />
                </td>
                <td>
                    <asp:Label ID="voidWcLabel" runat="server" Text='<%# Eval("voidWc") %>' />
                </td>
                <td>
                    <asp:Label ID="importWcLabel" runat="server" Text='<%# Eval("importWc") %>' />
                </td>
                <td>
                    <asp:Label ID="newWcLabel" runat="server" Text='<%# Eval("newWc") %>' />
                </td>
                <td>
                    <asp:Label ID="constWcLabel" runat="server" Text='<%# Eval("constWc") %>' />
                </td>
                <td>
                    <asp:Label ID="switchWcLabel" runat="server" Text='<%# Eval("switchWc") %>' />
                </td>
                <td>
                    <asp:Label ID="staticWcLabel" runat="server" Text='<%# Eval("staticWc") %>' />
                </td>
                <td>
                    <asp:Label ID="TimestampLabel" runat="server" Text='<%# Eval("Timestamp") %>' />
                </td>
                <td>
                    <asp:Label ID="PartitionKeyLabel" runat="server" 
                        Text='<%# Eval("PartitionKey") %>' />
                </td>
                <td>
                    <asp:Label ID="RowKeyLabel" runat="server" Text='<%# Eval("RowKey") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
