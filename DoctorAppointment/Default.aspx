<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="IE=edge" http-equiv="X-UA-Compatible" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/generic.css" rel="stylesheet" />
    <script src="js/jquery-3.5.1.js"></script>
    <title>Take Appointment</title>



</head>
<body>
    <form id="form1" runat="server">

        <div class="col_1200">
            <div class="logo-container"></div>
            <div class="navBtn"></div>

            <asp:Button ID="btnSignup" CssClass="signupBtn" runat="server" Text="Sign-Up" OnClick="btnSignup_Click" />
            <asp:Button ID="btnLogin" CssClass="loginBtn" runat="server" Text="Login" OnClick="btnLogin_Click" />

            <div class="navMain">
                <ul class="float_right">
                    <li><a href="Default.aspx">Home</a></li>
                    <li><a href="#">Find Doctors</a></li>
                    <li><a href="#">Medicines</a></li>
                    <li><a href="#">Lab Tests</a></li>
                </ul>
            </div>
            <div class="float_clear"></div>
        </div>

        <div class="searchBar col_1200_full">
            <div class="col_1200_full overlay">
                <div class="Slogan-cont txtCenter margin_auto">
                    <span class="space50"></span>
                    <h1 style="color: #fff" class="font-bold large">Empowering Your Health Journey</h1>
                </div>
                <span class="space50"></span>
                <span class="space50"></span>
                <h1 class="txtCenter medium font-bold">Best Doctors in Miraj</h1>
                <span class="space20"></span>
                <div class="search_Col">
                    <asp:TextBox ID="TextBox1" CssClass="txtSearch" runat="server" placeholder="Search For: Doctors & Specialities"></asp:TextBox>

                    <asp:Button ID="Button1" CssClass="searchBtn" runat="server" Text="Search" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        <div class="float_clear"></div>


        <span class="space40"></span>

    </form>
</body>
</html>
