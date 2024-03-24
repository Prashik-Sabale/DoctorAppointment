<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="forgot-password.aspx.cs" Inherits="forgot_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <span class="space50"></span>
            <div class="forgotContainer margin_auto txtCenter">
                <div class="pad_20">
                    <div class="width100">
                        <img src="Images/Icons/lock.png" style="height: 90px; width: 90px;" />
                    </div>
                    <span class="space10"></span>
                    <h1 class=" font-regular size-extra-medium">Forgot Password ?</h1>
                    <span class="size-small">You can reset password here</span>
                    <span class="space30"></span>
                    <asp:TextBox ID="txtMail" CssClass="txtForgetMail" type="email" runat="server" placeholder="Enter registered email address"></asp:TextBox>
                    <span class="space5"></span>
                    <span class="size-small">OR</span>
                    <span class="space5"></span>
                    <asp:TextBox ID="TxtMNO" CssClass="txtForgetMNO" MaxLength="10" runat="server" placeholder="Enter registered Mobile Number"></asp:TextBox>
                    <span class="space20"></span>
                    <asp:Button ID="btnSubmit" CssClass="BtnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <span class="space40"></span>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

