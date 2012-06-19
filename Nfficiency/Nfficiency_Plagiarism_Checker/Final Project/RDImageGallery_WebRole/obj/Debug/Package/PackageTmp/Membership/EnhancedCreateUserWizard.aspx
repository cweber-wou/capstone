﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Membership_EnhancedCreateUserWizard" Title="Untitled Page" Codebehind="EnhancedCreateUserWizard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Create a New User Account </h2>
    <p>
        This form creates a new user account.</p>
    <asp:CreateUserWizard ID="NewUserWizard" runat="server" 
        ContinueDestinationPageUrl="~/Membership/AdditionalUserInfo.aspx" 
        oncreateduser="NewUserWizard_CreatedUser" 
        onactivestepchanged="NewUserWizard_ActiveStepChanged">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:WizardStep ID="UserSettings" runat="server" StepType="Step" Title="Your Settings">
                <p>
                    <b>Home Town:</b><br />
                    <asp:TextBox ID="HomeTown" runat="server"></asp:TextBox>
                </p>
                <p>
                    <b>Homepage URL:</b><br />
                    <asp:TextBox ID="HomepageUrl" Columns="40" runat="server"></asp:TextBox>
                </p>
                <p>
                    <b>Signature:</b><br />
                    <asp:TextBox ID="Signature" TextMode="MultiLine" Width="95%" Rows="5" runat="server"></asp:TextBox>
                </p>
            </asp:WizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
