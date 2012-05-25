<%@ Page Language="C#" MasterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="stuAssignUpload.aspx.cs" Inherits="RDImageGallery_WebRole.stuAssignUpload" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

<script type="text/javascript" language="javascript">

    function AddNewRow() {

        var rownum = 1;

        var div = document.createElement("div")

        var divid = "dv" + rownum

        div.setAttribute("ID", divid)

        rownum++

        var lbl = document.createElement("label")

        lbl.setAttribute("ID", "lbl" + rownum)

        lbl.setAttribute("class", "label1")

        lbl.innerHTML = "File: "

        rownum++

        var _upload = document.createElement("input")

        _upload.setAttribute("type", "file")

        _upload.setAttribute("ID", "upload" + rownum)

        _upload.setAttribute("runat", "server")

        _upload.setAttribute("name", "uploads" + rownum)

        rownum++

        var hyp = document.createElement("a")

        hyp.setAttribute("style", "cursor:Pointer")

        hyp.setAttribute("onclick", "return RemoveDv('" + divid + "');");

        hyp.innerHTML = "Remove"

        rownum++

        var br = document.createElement("br")

        var _pdiv = document.getElementById("Parent")

        div.appendChild(br)

        div.appendChild(lbl)

        div.appendChild(_upload)

        div.appendChild(hyp)

        _pdiv.appendChild(div)

    }

    function RemoveDv(obj) {

        var p = document.getElementById("Parent")

        var chld = document.getElementById(obj)

        p.removeChild(chld)

    }

</script>



    
    <div>
        <h1>
            <asp:Label ID="lblCourse_Name" runat="server" Text="Label"></asp:Label>
&nbsp;Course Home</h1>
        <div class="form">
          
            <br />
            <asp:Label ID="lblCourse_ID" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:justin_dbConnectionString %>" 
                SelectCommand="SELECT * FROM [Assignments] WHERE ([Course_ID] = @Course_ID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblCourse_ID" Name="Course_ID" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:justin_dbConnectionString %>" 
                SelectCommand="SELECT [Course_Name] FROM [Courses] WHERE ([Course_ID] = @Course_ID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblCourse_ID" Name="Course_ID" 
                        PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </div>
        <div style=" float:left;">
        Status: <asp:Label ID="status" runat="server" ForeColor="Red" />
        </div>
        <br />
        <br />
        <asp:Label ID="lblInfo" runat="server" Text="Text output of file"></asp:Label>
        <asp:TextBox ID="txtTest" runat="server" TextMode="MultiLine" Width="996px"></asp:TextBox>
        <br />
        <asp:Label ID="lblInfo1" runat="server" Text="aGUID Check"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="aGUID" DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="aGUID" HeaderText="aGUID" ReadOnly="True" 
                    SortExpression="aGUID" />
                <asp:BoundField DataField="Assignment_ID" HeaderText="Assignment_ID" 
                    SortExpression="Assignment_ID" />
                <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" 
                    SortExpression="Course_ID" />
            </Columns>
        </asp:GridView>


        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Add Custom Word List:"></asp:Label>
        <br />


        <table cellpadding="0" cellspacing="0" width="100%" border="0">
<tr id="Tr1" runat="Server">
<td>
<label>
File :</label><asp:FileUpload ID="uploadFile1" runat="server" CssClass="" /><br />
<div id="Parent">
</div>
<label>
&nbsp;</label>
<input type="button" onclick="AddNewRow(); return false;"  value="Add File" />&nbsp;
<asp:Button ID="btnAddFile" Text="Commit File" runat="server"
onclick="btnAddFile_Click1" CausesValidation="False" />&nbsp;
<asp:Button ID="btnCancel" Text="Cancel" runat="server" />
</td></tr></table>


        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Turned in files"></asp:Label>
        <br />


        <asp:ListView ID="images" runat="server" onitemdatabound="OnBlobDataBound" 
            onselectedindexchanged="images_SelectedIndexChanged">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </LayoutTemplate>
            <EmptyDataTemplate>
                <h2>No Data Available</h2>
            </EmptyDataTemplate>
            <ItemTemplate>            
                <div class="item">
                    <ul style="width:40em;float:left;clear:left" >
                   
                        <asp:Repeater ID="blobMetadata" runat="server">
                        <ItemTemplate>
                            <li><asp:Label ID="Label2" runat="server" Text="AID: " ></asp:Label><%# Eval("AID") %>
                            <span><asp:Label ID="Label1" runat="server" Text="User ID: " ></asp:Label><%# Eval("UserID") %>
                            <span><asp:Label ID="Label3" runat="server" Text="File Name: " ></asp:Label><%# Eval("txtFileName") %>
                            <span><asp:Label ID="Label4" runat="server" Text="Link: " ></asp:Label><%# Eval("Link") %></span></li>
                        
                        <li>
                            <asp:LinkButton ID="deleteFile" 
                                    OnClientClick="return confirm('Delete file?');"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Delete" oncommand="OnDeleteFile" />

                            <asp:LinkButton ID="CopyFile" 
                                    OnClientClick="return confirm('Copy file?');"
                                    CommandName="Copy" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Copy" oncommand="OnCopyFile" />

                            <asp:LinkButton ID="SnapshotFile" 
                                    OnClientClick="return confirm('Snapshot file?');"
                                    CommandName="Snapshot" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Snapshot" oncommand="OnSnapshotFile" />

                                    <asp:LinkButton ID="DownloadFile" 
                                    OnClientClick="return confirm('Download file?');"
                                    CommandName="Download" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Download" oncommand="OnDownloadFile" />
                        </li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    
                
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    



 






   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
