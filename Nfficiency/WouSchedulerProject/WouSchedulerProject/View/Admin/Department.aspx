<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="WouSchedulerProject.View.Admin.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Department" DeleteMethod="DeleteDepartment" 
        InsertMethod="InsertDepartment" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAllCourses" TypeName="DepartmentDB" 
        UpdateMethod="UpdateDepartment"></asp:ObjectDataSource>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
        InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="DIDLabel" runat="server" Text='<%# Eval("DID") %>' />
                </td>
                <td>
                    <asp:Label ID="departmentLabel" runat="server" 
                        Text='<%# Eval("department") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="DIDTextBox" runat="server" Text='<%# Bind("DID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="departmentTextBox" runat="server" 
                        Text='<%# Bind("department") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="DIDTextBox" runat="server" Text='<%# Bind("DID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="departmentTextBox" runat="server" 
                        Text='<%# Bind("department") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="DIDLabel" runat="server" Text='<%# Eval("DID") %>' />
                </td>
                <td>
                    <asp:Label ID="departmentLabel" runat="server" 
                        Text='<%# Eval("department") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">
                                </th>
                                <th runat="server">
                                    DID</th>
                                <th runat="server">
                                    department</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="DIDLabel" runat="server" Text='<%# Eval("DID") %>' />
                </td>
                <td>
                    <asp:Label ID="departmentLabel" runat="server" 
                        Text='<%# Eval("department") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>
