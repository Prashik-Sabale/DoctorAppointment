<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="loginDoctor.aspx.cs" Inherits="loginDoctor" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="col_1200">
                <div class="col_1_2">
                    <div class="pad_20">
                        <img id="loginImg" src="Doctor/Images/loginbg.jpg" />
                    </div>
                </div>
                
                <div class="col_1_2">
                    <div class="pad_20">
                        <div class="logo_container">
                            <span class="space30"></span>
                            <span id="title">Welcome Doctor!!</span>
                            <span class="space10"></span>
                            <span id="title2">Please Enter Your Credentials Below</span>
                            <span class="space20"></span>
                            <div class="pad_30">
                                <asp:TextBox ID="txtEmail" CssClass="textBox" runat="server" placeholder="Enter Username"></asp:TextBox>
                                <span class="space30"></span>
                                <asp:TextBox ID="txtPassword" CssClass="textBox" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                <span class="space20"></span>
                                <asp:CheckBox ID="CheckBox1" runat="server" CssClass="check" Text=" Remember" />
                                <span class="space20"></span>
                                <asp:Button ID="Button1" runat="server" CssClass="login" Text="Login" OnClick="Button1_Click" />
                                <span class="space20"></span>
                                <div class="forget">
                                    <a href="forgot-password.aspx">Forget Password?</a>
                                </div>
                                <span class="space10"></span>
                                <div class="doctor-login">Are you a User? <a href="login.aspx">Login here</a></div>
                                <span class="space20"></span>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="float_clear">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

