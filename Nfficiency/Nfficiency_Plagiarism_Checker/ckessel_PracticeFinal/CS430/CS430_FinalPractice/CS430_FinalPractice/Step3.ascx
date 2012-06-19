<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Step3.ascx.cs" Inherits="CS430_FinalPractice.Step3" %>
  INPUT (is a int):&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
OUTPUT(is a int):<br />
<asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtOutput" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    &nbsp;&nbsp;<asp:Button ID="btnWCF" runat="server" onclick="btnWCF_Click" 
        Text="WCF Submit" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
    Text="Local Submit" />
&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server">
    <asp:ListItem Selected="True">dollars2Dublons</asp:ListItem>
    <asp:ListItem>dublons2Dolars</asp:ListItem>
</asp:RadioButtonList>
&nbsp;
</asp:Content>