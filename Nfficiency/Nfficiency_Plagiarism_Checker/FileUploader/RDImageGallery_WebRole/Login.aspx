<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 64%;
    }
    .style4
    {
        width: 76px;
    }
.error
{
    margin-top: 1em;        
    color: Blue;        
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
&nbsp;&nbsp;
<br />
Please enter User Name and Password below.<br />
<table class="style1">
    <tr>
        <td class="style4">
            User Name:</td>
        <td>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate="txtUser"
                    ErrorMessage="User Name is a required field.">*
                </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style4">
            Password:</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator21"
                    runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password is a required field.">*
                </asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
    Text="Submit" />

&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:accountdbConnectionString %>" 
    SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
<br />
<asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
<br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    HeaderText="Please correct the following errors:" 
        CssClass="error" ForeColor="#000066" />
<br />
<br />











</asp:Content>

