<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Roles_RoleBasedAuthorization" Title="Untitled Page" Codebehind="RoleBasedAuthorization.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Role-Based Authorization</h3>
    <p>
        <asp:LoginView ID="LoginView1" runat="server">
            <RoleGroups>
                <asp:RoleGroup Roles="Administrators">
                    <ContentTemplate>
                        As an Administrator, you may edit and delete user accounts. Remember: With great 
                        power comes great responsibility!
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="Instructors">
                    <ContentTemplate>
                        As a Supervisor, you may edit users&#39; Email and Comment information. Simply click 
                        the Edit button, make your changes, and then click Update.
                    </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
            <LoggedInTemplate>
                You are not a member of the Instructors or Administrators roles. Therefore you 
                cannot edit or delete any user information.
            </LoggedInTemplate>
            <AnonymousTemplate>
                You are not logged into the system. Therefore you cannot edit or delete any user 
                information.
            </AnonymousTemplate>
        </asp:LoginView>
    </p>
    <asp:GridView ID="UserGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName"
        onrowcancelingedit="UserGrid_RowCancelingEdit" onrowediting="UserGrid_RowEditing" 
        onrowupdating="UserGrid_RowUpdating" onrowdeleting="UserGrid_RowDeleting" 
        onrowcreated="UserGrid_RowCreated">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" />
            <asp:BoundField DataField="LastLoginDate" DataFormatString="{0:d}" 
                HeaderText="Last Login" HtmlEncode="False" ReadOnly="True" />
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label runat="server" ID="Label1" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="Email" Text='<%# Bind("Email") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="Email" Display="Dynamic" 
                        ErrorMessage="You must provide an email address." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="Email" Display="Dynamic" 
                        ErrorMessage="The email address you have entered is not valid. Please fix this and try again." 
                        SetFocusOnError="True" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comment">
                <ItemTemplate>
                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("Comment") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="Comment" TextMode="MultiLine" Columns="40" Rows="4" Text='<%# Bind("Comment") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

