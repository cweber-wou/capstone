<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="_Default" Title="Untitled Page" Codebehind="Default.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
        <asp:Label runat="server" ID="WelcomeBackMessage"></asp:Label>
        <p>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetEnrollment" 
                TypeName="EnrollmentClassDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblUserName" DefaultValue="ckessel" 
                        Name="inUser_ID" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Label ID="lblUserName" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="User_ID" HeaderText="User_ID" 
                        SortExpression="User_ID" />
                    <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" 
                        SortExpression="Course_ID" />
                    <asp:BoundField DataField="eCourse_Name" HeaderText="eCourse_Name" 
                        SortExpression="eCourse_Name" />
                </Columns>
            </asp:GridView>
        </p>
    </asp:Panel>
    
    <asp:Panel runat="Server" ID="AnonymousMessagePanel">
        <asp:HyperLink runat="server" ID="lnkLogin" Text="Log In" NavigateUrl="~/Login.aspx"></asp:HyperLink>
        <br />
        <br />
        Courses you are enrolled in:<br />
    </asp:Panel>
    
    <p><asp:HyperLink runat="server" ID="lnk" 
            NavigateUrl="~/Course_Mng/courseMainPage.aspx" Text="Go To SomePage.aspx"></asp:HyperLink></p>
</asp:Content>