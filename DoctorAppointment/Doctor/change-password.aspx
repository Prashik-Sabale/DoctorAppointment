<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterSidebar.master" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="Doctor_change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
    <div class="container col_900 ">
        <span class="space20"></span>
        <div class="passContainer margin_auto">
            <div class="pad_50">
                <span class="space20"></span>
                <asp:Label ID="lblCpass" runat="server" Text="Current Password: " CssClass="lblPass"></asp:Label>
                <span class="space10"></span>
                <asp:TextBox ID="txtCpass" runat="server" CssClass="txtPass" placeholder="Enter Old Password"></asp:TextBox>
                <span class="space20"></span>
                <asp:Label ID="lblNpass" runat="server" Text="New Password: " CssClass="lblPass"></asp:Label>
                <span class="space10"></span>
                <asp:TextBox ID="txtNpass" runat="server" CssClass="txtPass" placeholder="Enter New Password"></asp:TextBox>
                <span class="space20"></span>
                <asp:Label ID="lblCNpass" runat="server" Text="Confirm Password: " CssClass="lblPass"></asp:Label>
                <span class="space10"></span>
                <asp:TextBox ID="txtCNpass" runat="server" CssClass="txtPass" placeholder="Re-Enter New Password"></asp:TextBox>
                <span class="space30"></span>
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btnSubmit" OnClick="btn_Submit_Click" />
                <span class="space20"></span>
            </div>
        </div>
    </div>
</asp:Content>

