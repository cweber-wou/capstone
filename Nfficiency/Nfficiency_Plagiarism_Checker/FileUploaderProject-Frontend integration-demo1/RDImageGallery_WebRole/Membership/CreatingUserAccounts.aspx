<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Membership_CreatingUserAccounts" Title="Untitled Page" Codebehind="CreatingUserAccounts.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Create a New User Account</h2>
    <p>
        <asp:CreateUserWizard ID="RegisterUser" runat="server" 
            CancelDestinationPageUrl="~/Default.aspx" 
            ContinueDestinationPageUrl="~/Default.aspx" DisplayCancelButton="True"
            oncreatinguser="RegisterUser_CreatingUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    </p>
    <p>
        <asp:Label runat="server" id="InvalidUserNameOrPasswordMessage" Visible="false" EnableViewState="false" ForeColor="Red"></asp:Label>
    </p>
    
    <p>
        Enter a username: 
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />
        
        Choose a password:
        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>        
        <br />
        
        Enter your email address:
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label runat="server" ID="SecurityQuestion"></asp:Label>: 
        <asp:TextBox ID="SecurityAnswer" runat="server"></asp:TextBox>
        <br />
                
        <asp:Button ID="CreateAccountButton" runat="server" 
            Text="Create the User Account" onclick="CreateAccountButton_Click" />
    </p>
    <p>
        <asp:Label ID="CreateAccountResults" runat="server"></asp:Label>
    </p>    
</asp:Content>


