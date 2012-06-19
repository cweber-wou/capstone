<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Step2.ascx.cs" Inherits="CS430_FinalPractice.Step2" %>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="PlunderID" 
    DataSourceID="SqlDataSource1" 
    onselectedindexchanged="ListView1_SelectedIndexChanged">
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
                <asp:Label ID="PlunderIDLabel" runat="server" Text='<%# Eval("PlunderID") %>' />
            </td>
            <td>
                <asp:Label ID="PIDLabel" runat="server" Text='<%# Eval("PID") %>' />
            </td>
            <td>
                <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
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
                <asp:Label ID="PlunderIDLabel1" runat="server" 
                    Text='<%# Eval("PlunderID") %>' />
            </td>
            <td>
                <asp:TextBox ID="PIDTextBox" runat="server" Text='<%# Bind("PID") %>' />
            </td>
            <td>
                <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
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
                &nbsp;</td>
            <td>
                <asp:TextBox ID="PIDTextBox" runat="server" Text='<%# Bind("PID") %>' />
            </td>
            <td>
                <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
                <asp:Label ID="PlunderIDLabel" runat="server" Text='<%# Eval("PlunderID") %>' />
            </td>
            <td>
                <asp:Label ID="PIDLabel" runat="server" Text='<%# Eval("PID") %>' />
            </td>
            <td>
                <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
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
                                PlunderID</th>
                            <th runat="server">
                                PID</th>
                            <th runat="server">
                                Amount</th>
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
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
                <asp:Label ID="PlunderIDLabel" runat="server" Text='<%# Eval("PlunderID") %>' />
            </td>
            <td>
                <asp:Label ID="PIDLabel" runat="server" Text='<%# Eval("PID") %>' />
            </td>
            <td>
                <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:Pirate_dbConnectionString %>" 
    DeleteCommand="DELETE FROM [Plunder] WHERE [PlunderID] = @PlunderID" 
    InsertCommand="INSERT INTO [Plunder] ([PID], [Amount]) VALUES (@PID, @Amount)" 
    SelectCommand="SELECT * FROM [Plunder]" 
    UpdateCommand="UPDATE [Plunder] SET [PID] = @PID, [Amount] = @Amount WHERE [PlunderID] = @PlunderID">
    <DeleteParameters>
        <asp:Parameter Name="PlunderID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="PID" Type="Int32" />
        <asp:Parameter Name="Amount" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="PID" Type="Int32" />
        <asp:Parameter Name="Amount" Type="Int32" />
        <asp:Parameter Name="PlunderID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

