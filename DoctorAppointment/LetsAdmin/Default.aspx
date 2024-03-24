<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LetsAdmin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="IE=edge" http-equiv="X-UA-Compatible" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <script src="JS/jquery-3.5.1.js"></script>
    <script src="JS/toastr.min.js" ></script>
    <link href="css/toastr.min.css" rel="stylesheet" />
    <title> Doctors Appointment </title>
</head>
<body>
    <span class="space50"></span>
    <div id="userLogin">
        <span class="space30"></span>
        <h1 id="Alogin">Admin Login</h1>
         <span class="space30"></span>
        <div id="Iblock" >
            <form runat="server">
                <span class="lableBox"><b>Username: </b></span>
                <span class="space10"></span>
                <asp:TextBox ID="username" runat="server" CssClass="TextBox1" placeholder="Enter Username"></asp:TextBox>
                <span class="space10"></span>
                <span class="lableBox"><b>Password: </b></span>
                <span class="space10"></span>
                <asp:TextBox ID="password" runat="server" CssClass="TextBox1" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                <span class="space30"></span>

                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                <span class="space20"></span>
                 <% =errMsg %>
                <span class="space20"></span>
                <asp:LinkButton Id="LinkButton1" runat="server">Forgot Password?</asp:LinkButton>
                 <span class="space30"></span>
                <asp:CheckBox ID="CheckBox1" runat="server" Text=" Remember" />
               
                <asp:LinkButton ID="LinkButton3" runat="server">Create Account</asp:LinkButton>
                <span class="space30"></span>
            </form>
        </div>
    </div>
</body>
</html>
