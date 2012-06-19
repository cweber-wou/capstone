<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataForm.aspx.cs" Inherits="CS430_FinalPractice.DataForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
