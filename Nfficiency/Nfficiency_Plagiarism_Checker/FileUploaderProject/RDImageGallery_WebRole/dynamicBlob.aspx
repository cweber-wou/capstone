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
                 <li><span>Container: </span><asp:FileUpload ID="txtContainer" runat="server" /></li>
                 <li><span>Blob: </span><asp:FileUpload ID="txtBlob" runat="server" /></li>
            </ul>
            <asp:Button ID="btnProcess" runat="server" onclick="btnProcess_Click" 
                Text="Process File" Width="97px" />
            <asp:Button ID="upload" runat="server" onclick="upload_Click" 
                Text="Upload File" />
        </div>
        <div style=" float:left;">
        Status: <asp:Label ID="status" runat="server" ForeColor="Red" />
        </div>
        <br />
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtTest" runat="server" TextMode="MultiLine" Width="996px"></asp:TextBox>
        <br />
        <asp:Label ID="lblInfo1" runat="server" Text="Label"></asp:Label>
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
                            <li><%# Eval("Name") %><span><%# Eval("Value") %></span></li>
                        </ItemTemplate>
                        </asp:Repeater>
                        <li>
                            <asp:LinkButton ID="deleteBlob" 
                                    OnClientClick="return confirm('Delete file?');"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("Uri")%>'
                                    runat="server" Text="Delete" oncommand="OnDeleteImage" />

                            <asp:LinkButton ID="CopyBlob" 
                                    OnClientClick="return confirm('Copy file?');"
                                    CommandName="Copy" 
                                    CommandArgument='<%# Eval("Uri")%>'
                                    runat="server" Text="Copy" oncommand="OnCopyImage" />

                            <asp:LinkButton ID="SnapshotBlob" 
                                    OnClientClick="return confirm('Snapshot file?');"
                                    CommandName="Snapshot" 
                                    CommandArgument='<%# Eval("Uri")%>'
                                    runat="server" Text="Snapshot" oncommand="OnSnapshotImage" />

<%--Adding Download button --%>
 <asp:LinkButton ID="DownloadBlob" 
                                    OnClientClick="return confirm('Download file?');"
                                    CommandName="Download" 
                                    CommandArgument='<%# Eval("Uri")%>'
                                    runat="server" Text="Download" oncommand="OnDownloadImage" />
                        </li>
                    </ul>
                    <img src="<%# Eval("Uri") %>" alt="<%# Eval("Uri") %>" style="float:left"/>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
