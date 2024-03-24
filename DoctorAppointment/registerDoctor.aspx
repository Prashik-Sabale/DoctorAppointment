<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="registerDoctor.aspx.cs" Inherits="registerDoctor" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col_1200">
        <div class="col_1_2">
            <span class="space10"></span>
            <img src="../Doctor/Images/regForm.jpg" alt="doc image" class="formImg" />
        </div>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col_1_2 margin_auto">
                    <div class="pad_20">
                      
                        <div class="form-container">
                            <div class="pad_20">
                                <span class="space10"></span>
                                <h1 class=" heading txtCenter font-bold size-medium">Register Doctor</h1>
                                <span class="space20"></span>
                                <div class="w50 float_left">
                                    <span class="lblName">First Name </span>
                                    <span class="space10"></span>
                                    <asp:TextBox ID="txtFName" CssClass="full-name" placeholder="First Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="w50 float_left">
                                    <span class="lblName">Last Name </span>
                                    <span class="space10"></span>
                                    <asp:TextBox ID="txtLName" CssClass="full-name" placeholder="Last Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="float_clear"></div>
                                <span class="space10"></span>
                                <div class="w50 float_left">
                                    <span class="lblName">City</span>
                                    <span class="space5"></span>
                                    <asp:DropDownList ID="ddrCity" CssClass="chooseCity" runat="server">
                                        <asp:ListItem Value="0"><-Select-> </asp:ListItem>
                                        <asp:ListItem Value="1">Miraj </asp:ListItem>
                                        <asp:ListItem Value="2">Sangli </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="w50 float_left">
                                    <span class="lblName">Gender</span>
                                    <span class="space5"></span>
                                    <asp:DropDownList ID="ddrGender" CssClass="chooseGender" runat="server">
                                        <asp:ListItem Value="0"><-Select-> </asp:ListItem>
                                        <asp:ListItem Value="1">Male </asp:ListItem>
                                        <asp:ListItem Value="2">Female </asp:ListItem>
                                        <asp:ListItem Value="3">Other </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="float_clear"></div>
                                <span class="space10"></span>
                                <span class="lblName">Email ID</span>
                                <span class="space5"></span>
                                <asp:TextBox ID="txtEmail" CssClass="email" type="email" placeholder="Email ID" runat="server"></asp:TextBox>
                                <span class="space10"></span>
                                <div class="w50 float_left">
                                    <span class="lblName">Password</span>
                                    <span class="space5"></span>
                                    <asp:TextBox ID="txtPass" CssClass="password" type="password" runat="server"></asp:TextBox>
                                </div>
                                <div class="w50 float_left">
                                    <span class="lblName">Confirm Password</span>
                                    <span class="space5"></span>
                                    <asp:TextBox ID="txtCPass" CssClass="password" type="password" runat="server"></asp:TextBox>
                                </div>
                                <div class="float_clear"></div>



                                <span class="space30"></span>
                                <asp:Button ID="btnRegister" CssClass="regBtn" runat="server" Text="Register" OnClick="btnRegister_Click" />
                                  <span class="space10"></span>
                                <div class="doctor-login">Are you a User? <a href="register.aspx">Register here</a></div>
                                <span class="space20"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>