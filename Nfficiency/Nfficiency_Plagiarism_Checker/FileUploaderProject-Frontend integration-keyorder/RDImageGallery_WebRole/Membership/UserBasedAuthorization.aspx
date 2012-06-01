﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Membership_UserBasedAuthorization" Title="Untitled Page" ValidateRequest="false" Codebehind="UserBasedAuthorization.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>User-Based Authorization</h2>
    <asp:LoginView ID="LoginViewForFileContentsTextBox" runat="server">
        <LoggedInTemplate>
            <p>
                <asp:TextBox ID="FileContents" runat="server" Rows="10" TextMode="MultiLine" 
                    Width="95%"></asp:TextBox>
            </p>
        </LoggedInTemplate>
    </asp:LoginView>
    <p>
        <asp:GridView ID="FilesGrid" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="FullName" onrowdeleting="FilesGrid_RowDeleting" 
            onselectedindexchanged="FilesGrid_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LoginView ID="LoginView1" runat="server">
                            <LoggedInTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                     CommandName="Select" Text="View"></asp:LinkButton>
                            </LoggedInTemplate>
                        </asp:LoginView>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Length" DataFormatString="{0:N0}" 
                    HeaderText="Size in Bytes" HtmlEncode="False" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
