<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <span class="space10"></span>
    <div class="col_1200">
        <div class="col_1_2">
            <img src="Doctor/Images/regForm.jpg" alt="doc image" class="formImg" />
        </div>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col_1_2 margin_auto">
                    <div class="pad_20">
                        <span class="space30"></span>
                        <div class="form-container">
                            <div class="pad_20">
                                <span class="space5"></span>
                                <h1 class=" heading font-bold txtCenter size-medium">Register User</h1>
                                <span class="space30"></span>
                                <span class="lblName">Full Name </span>
                                <span class="space10"></span>
                                <asp:TextBox ID="txtFullName" CssClass="user-name" placeholder="Enter Full Name" runat="server"></asp:TextBox>
                                <div class="float_clear"></div>
                                <span class="space10"></span>
                                <span class="lblName">Mobile Number</span>
                                <span class="space5"></span>
                                <asp:TextBox ID="txtPhone" CssClass="email" MaxLength="10" placeholder="Mobile Number" runat="server"></asp:TextBox>
                                <span class="space10"></span>
                                <span class="lblName">Create Password</span>
                                <span class="space5"></span>
                                <asp:TextBox ID="txtPass" CssClass="user-password" placeholder="Password" type="password" runat="server"></asp:TextBox>
                                <span class="space20"></span>
                                <asp:Button ID="btnRegister" CssClass="regBtn" runat="server" Text="Register" OnClick="btnRegister_Click"  />
                                <span class="space20"></span>
                                <div class="txtCenter">
                                    <span class="display_InlineBlk size-small txtCenter">Are you a doctor?</span>
                                    <a href="registerDoctor.aspx" class="selcVal size-small txtCenter">Register Here</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

