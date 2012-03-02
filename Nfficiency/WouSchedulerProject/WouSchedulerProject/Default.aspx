<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WouSchedulerProject.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WOU Schedule</title>
    <link href="Styles/MasterStyle.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <table style="width: 775px;" align="center">
        <tr>
            <td bgcolor="Maroon">
                <div id="logo" align="left">
                    <img src="Images/wouLogo1.png" />
                </div>
                <div id="admin" align="right">
                    Student User
                </div>
            </td>      
        </tr>
        <tr align="center">    
            <td align="center">
        <ul>
            <li><a href="View/Admin/Schedule.aspx">Admin</a></li>
            <li><a href="View/User/UserQuery.aspx">User</a></li>           
        </ul>
            </td>
        </tr>
    </table>
</body>
</html>
