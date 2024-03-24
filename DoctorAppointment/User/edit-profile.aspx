<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterSidebar.master" AutoEventWireup="true" CodeFile="edit-profile.aspx.cs" Inherits="User_edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="pad_20">
        <div class="profileContainer margin_auto">
            <div class="pad_20">
                <span class="space30"></span>
                <h3 class="size-medium wt-light" style="font-family: 'Kalam', cursive;">Let's Build Your Profile</h3>
                <span class="space20"></span>
                <h3 class="size_regular_medium">Basic details :</h3>
                <span class="space20"></span>
                <div class="w33 float_left">
                    <span class="lblName">Full Name* </span>
                    <span class="space10"></span>
                    <asp:TextBox ID="txtFN" CssClass="txtBox" placeholder="Enter Full Name" runat="server"></asp:TextBox>
                </div>
                <div class="w33 float_left">
                    <span class="lblName">Mobile Number* </span>
                    <span class="space10"></span>
                    <asp:TextBox ID="txtMNO" CssClass="txtBox" MaxLength="10" placeholder="Mobile Number" runat="server"></asp:TextBox>
                </div>
                <div class="w33 float_left">
                    <span class="lblName">City* </span>
                    <span class="space10"></span>
                    <asp:DropDownList ID="ddrCity" CssClass="ddrBox" runat="server">
                        <asp:ListItem Value="0"><--Select--> </asp:ListItem>
                        <asp:ListItem Value="1">Miraj </asp:ListItem>
                        <asp:ListItem Value="2">Sangli </asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="w33 float_left">
                    <span class=" space20"></span>
                    <span class="lblName">Email Id* </span>
                    <span class="space10"></span>
                    <asp:TextBox ID="txtEmailId" CssClass="txtBox" placeholder="Email Id" type="email" runat="server"></asp:TextBox>
                </div>

                <div class="w33 float_left">
                    <span class="space20"></span>
                    <span class="lblName">Gender* </span>
                    <span class="space10"></span>
                    <asp:DropDownList ID="ddrGender" CssClass="ddrBox" runat="server">
                        <asp:ListItem Value="0"><--Select--> </asp:ListItem>
                        <asp:ListItem Value="1">Male </asp:ListItem>
                        <asp:ListItem Value="2">Female </asp:ListItem>
                        <asp:ListItem Value="3">Other </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="w33 float_left">
                    <span class="space20"></span>
                    <span class="lblName">Age*</span>
                    <span class="space10"></span>
                    <asp:TextBox ID="txtAge" CssClass="txtBox" placeholder="Age" runat="server"></asp:TextBox>
                </div>
                <div class="float_clear"></div>

                <span class="space30"></span>
                <asp:Button ID="btnSave" CssClass="btnSaveProfile" runat="server" Text="Save" OnClick="btnSave_Click"  />
                <span class="space50"></span>
                <span class="space30"></span>
            </div>
        </div>
    </div>


</asp:Content>

