<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEnrollUserVarification.aspx.cs" Inherits="CS430_ASPNET_Role_Records.User_Mng.frmEnrollUserVarification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" ForeColor="#33CC33"></asp:Label>
    <br />
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblInfo2" runat="server" Visible="False"></asp:Label>
    <br />
    Enter enrollment key for
    <asp:Label ID="lblCourse" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Enrollment Key"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtEnrollKey" runat="server"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEnroll" runat="server" onclick="btnEnroll_Click" 
        Text="Enroll" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
