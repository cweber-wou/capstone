<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Step1.ascx.cs" Inherits="CS430_FinalPractice.Step1" %>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    Plunder Amount&nbsp;</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnSubmit" runat="server" Text="Button" 
    onclick="btnSubmit_Click" />
<br />
<asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
    DataSourceID="SqlDataSource1" DataTextField="PName" DataValueField="PID" 
    Height="137px" onselectedindexchanged="ListBox1_SelectedIndexChanged" 
    Width="83px"></asp:ListBox>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:Pirate_dbConnectionString %>" 
    SelectCommand="SELECT * FROM [Pirate]"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
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
<asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>

