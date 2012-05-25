<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dynamicBlob.aspx.cs" Inherits="RDImageGallery_WebRole.dynamicBlob" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Windows Azure Blob Service</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <style type="text/css">
        body { font-family: Verdana; font-size: 12px; }
        h1 { font-size:x-large; font-weight:bold; }
        h2 { font-size:large; font-weight:bold; }
        img { width:200px; height:175px; margin:2em;}
        li { list-style: none; }
        ul { padding:1em; }
        
        .form { width:50em; }
        .form li span {width:30%; float:left; font-weight:bold; }
        .form li input { width:70%; float:left; }
        .form input { float:right; }
        
        .item { font-size:smaller; font-weight:bold; }
        .item ul li { padding:0.25em; background-color:#ffeecc; }
        .item ul li span { padding:0.25em; background-color:#ffffff; display:block; font-style:italic; font-weight:normal; }
    </style>
</head>

<script type="text/javascript" language="javascript">

function AddNewRow() {

var rownum = 1;

var div = document.createElement("div")

var divid= "dv" + rownum

div.setAttribute("ID",divid)

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

_upload.setAttribute("name","uploads"+rownum)

rownum++

var hyp = document.createElement("a")

hyp.setAttribute("style", "cursor:Pointer")

hyp.setAttribute("onclick", "return RemoveDv('" + divid + "');");

hyp.innerHTML = "Remove"

rownum++

var br=document.createElement("br")

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
<body>


    <form id="form1" runat="server">
    <div>
        <h1>File Uploader (Azure Blob)</h1>
        <div class="form">
            <ul>
                
                <li><span>True Assignment ID:</span><asp:TextBox ID="txtAssignID" runat="server"/></li>
                <li><span>True File Link:</span><asp:TextBox ID="txtFileLink" runat="server"/></li>
               <li><span>True User ID:</span><asp:TextBox ID="txtUserID" runat="server"/></li>
                <li><span>Filename: </span><asp:FileUpload ID="txtFileName" runat="server" /></li>
                 <li><span>Container: </span></li>
                 <li><span>Blob: </span></li>
            </ul>
            <asp:Button ID="btnProcess" runat="server" onclick="btnProcess_Click" 
                Text="Process File" Width="97px" />
            <asp:Button ID="upload" runat="server" onclick="upload_Click" 
                Text="Upload File" />
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
            <asp:Button ID="btnCreateDir" runat="server" onclick="btnCreateDir_Click" 
                Text="CreateDir" />
            <br />
            <br />
        </div>
        <div style=" float:left;">
        Status: <asp:Label ID="status" runat="server" ForeColor="Red" />
        </div>
        <br />
        <br />
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtTest" runat="server" TextMode="MultiLine" Width="996px"></asp:TextBox>
        <br />
        <asp:Label ID="lblInfo1" runat="server" Text="Label_Info1"></asp:Label>
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
onclick="btnAddFile_Click1" />&nbsp;
<asp:Button ID="btnCancel" Text="Cancel" runat="server" />
</td></tr></table>


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
                            <li><asp:Label ID="Label2" runat="server" Text="AID: " ></asp:Label><%# Eval("AID") %><span><asp:Label ID="Label1" runat="server" Text="User ID: " ></asp:Label><%# Eval("UserID") %><span><asp:Label ID="Label3" runat="server" Text="File Name: " ></asp:Label><%# Eval("txtFileName") %><span><asp:Label ID="Label4" runat="server" Text="Link: " ></asp:Label><%# Eval("Link") %></span></li>
                        
                        <li>
                            <asp:LinkButton ID="deleteBlob" 
                                    OnClientClick="return confirm('Delete file?');"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Delete" oncommand="OnDeleteFile" />

                            <asp:LinkButton ID="CopyBlob" 
                                    OnClientClick="return confirm('Copy file?');"
                                    CommandName="Copy" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Copy" oncommand="OnCopyFile" />

                            <asp:LinkButton ID="SnapshotBlob" 
                                    OnClientClick="return confirm('Snapshot file?');"
                                    CommandName="Snapshot" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Snapshot" oncommand="OnSnapshotFile" />

<%--Adding Download button --%>
                                    <asp:LinkButton ID="DownloadBlob" 
                                    OnClientClick="return confirm('Download file?');"
                                    CommandName="Download" 
                                    CommandArgument='<%# Eval("AID")%>'
                                    runat="server" Text="Download" oncommand="OnDownloadFile" />
                        </li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <img src="<%# Eval("txtFileName") %>" alt="<%# Eval("txtFileName") %>" style="float:left"/>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    



    </form>






</body>
</html>
