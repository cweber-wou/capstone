<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<script runat="server">
void goToPage(object sender, System.EventArgs e)
{
Response.Redirect("Main.aspx");
}
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .error
        {
            margin-top: 1em;
            color: Green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2> Please enter you user information below:</h2>
    <br />
    <asp:DetailsView ID="DetailsView2" runat="server" AllowPaging="True" 
    AutoGenerateRows="False" DataSourceID="ObjectDataSource1" DefaultMode="Insert" 
    Height="161px" Width="400px" OnItemInserted="DetailsView2_ItemInserted" 
        onpageindexchanging="DetailsView2_PageIndexChanging">
    <Fields>
            <asp:TemplateField HeaderText="User_ID" SortExpression="Customer_ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password" SortExpression="Password">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First_Name" SortExpression="First_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("First_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("First_Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("First_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last_Name" SortExpression="Last_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Last_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Last_Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Last_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Street" SortExpression="Street">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Street") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Street") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Street") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" SortExpression="City">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="State" SortExpression="State">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                    <asp:CustomValidator ID="valZip" runat="server" ControlToValidate="TextBox8" ErrorMessage="Custom Validator-Checking zip aginst DB"></asp:CustomValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox8"
                        CssClass="validator" Display="Dynamic" ErrorMessage="Email is required.">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Custom Validator-Checking zip aginst DB \n Regular Expression: Email format is invalid."
                        ControlToValidate="TextBox9" CssClass="validator" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*
                    </asp:RegularExpressionValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True" />
        </Fields>
        <FieldHeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
        <InsertRowStyle BackColor="LightGray" />
        <CommandRowStyle BackColor="#A9A9A9" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCategory"
        TypeName="CategoryDB" UpdateMethod="UpdateCategory" ConflictDetection="CompareAllValues"
        OnDeleted="ObjectDataSource1_Deleted" OnUpdated="ObjectDataSource1_Updated"
        DataObjectTypeName="Category" InsertMethod="InsertCatigory" 
        OldValuesParameterFormatString="original_{0}"
        DeleteMethod="DeleteCategory">
        <UpdateParameters>
            <asp:Parameter Name="original_Category" Type="Object" />
            <asp:Parameter Name="category" Type="Object" />
           </UpdateParameters>
    </asp:ObjectDataSource>
   





    
&nbsp;<asp:Label ID="lblError" runat="server" EnableViewState="False" ForeColor="Green"> </asp:Label>
     





    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        CssClass="validator" ForeColor="#339933" 
        HeaderText="Please correct the following errors:" />
     





    <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource2"  >
    </asp:Menu>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server">
    </asp:SiteMapPath>
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource2">
    </asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
    <br />
     





   </asp:Content>

