<%@ Page Title="" Language="C#" MasterPageFile="~/internalMasterPage.master" AutoEventWireup="true" CodeFile="ViewPage.aspx.cs" Inherits="ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 40%;
        }
        .style2
        {
            width: 112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h3>
     <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="True" 
         onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
         <asp:ListItem>SkyHigh</asp:ListItem>
         <asp:ListItem>SmokeAndGlass</asp:ListItem>
         <asp:ListItem>UglyRed</asp:ListItem>
         <asp:ListItem>BasicBlue</asp:ListItem>
     </asp:DropDownList>
</h3>
<h3>Your Survay Notes:</h3>
    <table class="style1">
        <tr>
            <td class="style2">
                Course Name:</td>
            <td>
                <asp:Label ID="lblCourselName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Professor Name:</td>
            <td>
                <asp:Label ID="lblProf" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Due Date:
            </td>
            <td>
                <asp:Label ID="lblDueDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Grade:
            </td>
            <td>
                <asp:Label ID="lblGrade" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Assignment: 
            </td>
            <td>
                <asp:Label ID="lblAssignment" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Difficulty:
            </td>
            <td>
                <asp:Label ID="lblDifficulty" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Retake:
            </td>
            <td>
                <asp:Label ID="lblRetake" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <p class="text">Notes::</p>
    <p class="label"><asp:Label ID="lblNotes" runat="server"></asp:Label></p>
    <p id="buttons">
        <asp:Button ID="btnConfirm" runat="server" Text="Exit" 
            onclick="btnConfirm_Click" PostBackUrl="~/Main.aspx" Width="107px" />&nbsp;
        <asp:Button ID="btnModify" runat="server" Text="Modify Notes" 
            PostBackUrl="~/SurvayPage.aspx" />
    </p>
   
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
        



</asp:Content>

