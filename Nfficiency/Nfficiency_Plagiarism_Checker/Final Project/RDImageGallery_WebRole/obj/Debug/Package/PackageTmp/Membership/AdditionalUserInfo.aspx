<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Membership_AdditionalUserInfo" Title="Untitled Page" Codebehind="AdditionalUserInfo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Update Your Settings</h2>
    <p>
        <asp:Label ID="SettingsUpdatedMessage" runat="server" Text="Your settings have been updated." EnableViewState="false" Visible="false"></asp:Label>
    </p>
    <asp:DetailsView ID="UserProfile" runat="server" 
        AutoGenerateRows="False" DataKeyNames="UserId" 
        DataSourceID="UserProfileDataSource" DefaultMode="Edit" 
        onitemupdated="UserProfile_ItemUpdated">
        <Fields>
            <asp:BoundField DataField="HomeTown" HeaderText="HomeTown" 
                SortExpression="HomeTown" />
            <asp:BoundField DataField="HomepageUrl" HeaderText="HomepageUrl" 
                SortExpression="HomepageUrl" />
            <asp:BoundField DataField="Signature" HeaderText="Signature" 
                SortExpression="Signature" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
    
    <asp:SqlDataSource ID="UserProfileDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SecurityTutorialsConnectionString %>" 
        
        SelectCommand="SELECT [UserId], [HomeTown], [HomepageUrl], [Signature] FROM [UserProfiles] WHERE ([UserId] = @UserId)" 
        onselecting="UserProfileDataSource_Selecting" UpdateCommand="UPDATE UserProfiles SET
    HomeTown = @HomeTown,
    HomepageUrl = @HomepageUrl,
    Signature = @Signature
WHERE UserId = @UserId
">
        <SelectParameters>
            <asp:Parameter Name="UserId" Type="Object" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="HomeTown" />
            <asp:Parameter Name="HomepageUrl" />
            <asp:Parameter Name="Signature" />
            <asp:Parameter Name="UserId" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
