<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CS430_FinalPractice._Default" %>
    <%@ Register TagPrefix="uc1" TagName="menu" Src="Step1.ascx" %>
    <%@ Register TagPrefix="uc2" TagName="menu1" Src="Step2.ascx" %>
    

  

<asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"></asp:Content>
<asp:Content ID="ContentPlaceHolder2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2"></asp:Content>
<asp:Content ID="ContentPlaceHolder3" runat="server" ContentPlaceHolderID="ContentPlaceHolder3"></asp:Content>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">



    <h2>
        Welcome to ASP.NET!
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="0">Order 1</asp:ListItem>
            <asp:ListItem Value="1">Order 2</asp:ListItem>
        </asp:RadioButtonList>
       
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
   

 


 <%--  <uc1:menu ID="Step1" runat="server"></uc1:menu> 
    <uc2:menu1 ID="Step2" runat="server"></uc2:menu1> --%>
    <p>
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="PlunderID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PlunderID" HeaderText="PlunderID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="PlunderID" />
                <asp:BoundField DataField="PID" HeaderText="PID" SortExpression="PID" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" 
                    SortExpression="Amount" />
                <asp:BoundField DataField="PName" HeaderText="PName" SortExpression="PName" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Pirate_dbConnectionString %>" 
            SelectCommand="NewSelectCommand" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblInfo" Name="PID" PropertyName="Text" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
