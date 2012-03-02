<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course_WebForm.aspx.cs" Inherits="Nifficiency_Scheduler.Course_WebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Course" DeleteMethod="DeleteCourse" 
        InsertMethod="InsertCourse" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetCourse" TypeName="CourseDB" UpdateMethod="UpdateCourse">
        <UpdateParameters>
            <asp:Parameter Name="original_Course" Type="Object" />
            <asp:Parameter Name="course" Type="Object" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
        DataSourceID="ObjectDataSource1" Height="174px" Width="368px">
        <EditItemTemplate>
            CID:
            <asp:TextBox ID="CIDTextBox" runat="server" Text='<%# Bind("CID") %>' />
            <br />
            DID:
            <asp:TextBox ID="DIDTextBox" runat="server" Text='<%# Bind("DID") %>' />
            <br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" 
                Text='<%# Bind("Description") %>' />
            <br />
            Hours:
            <asp:TextBox ID="HoursTextBox" runat="server" Text='<%# Bind("Hours") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            CID:
            <asp:TextBox ID="CIDTextBox" runat="server" Text='<%# Bind("CID") %>' />
            <br />
            DID:
            <asp:TextBox ID="DIDTextBox" runat="server" Text='<%# Bind("DID") %>' />
            <br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" 
                Text='<%# Bind("Description") %>' />
            <br />
            Hours:
            <asp:TextBox ID="HoursTextBox" runat="server" Text='<%# Bind("Hours") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            CID:
            <asp:Label ID="CIDLabel" runat="server" Text='<%# Bind("CID") %>' />
            <br />
            DID:
            <asp:Label ID="DIDLabel" runat="server" Text='<%# Bind("DID") %>' />
            <br />
            Description:
            <asp:Label ID="DescriptionLabel" runat="server" 
                Text='<%# Bind("Description") %>' />
            <br />
            Hours:
            <asp:Label ID="HoursLabel" runat="server" Text='<%# Bind("Hours") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
