<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
What do you want to do?<br />
<br />
<asp:Button ID="btnRegister" runat="server" Text="Register" 
    onclick="btnRegister_Click" />
&nbsp;&nbsp;
<asp:Button ID="btnLogin" runat="server" Text="Login" 
    onclick="btnLogin_Click" />
<br />
<br />
<br />
</asp:Content>

