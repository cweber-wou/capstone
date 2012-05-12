<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Roles_CreateUserWizardWithRoles" Title="Untitled Page" Codebehind="CreateUserWizardWithRoles.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Create a User Account (with Roles!)</h2>
    
    <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" 
        ContinueDestinationPageUrl="~/Default.aspx" 
        onactivestepchanged="RegisterUserWithRoles_ActiveStepChanged" 
        LoginCreatedUser="False">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:WizardStep ID="SpecifyRolesStep" runat="server" StepType="Step" 
                Title="Specify Roles" AllowReturn="False">
                <asp:CheckBoxList ID="RoleList" runat="server">
                </asp:CheckBoxList>
            </asp:WizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

