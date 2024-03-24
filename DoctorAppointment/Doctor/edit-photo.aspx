<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterSidebar.master" AutoEventWireup="true" CodeFile="edit-photo.aspx.cs" Inherits="Doctor_edit_photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="col_900">
        <div class="edit-photo-container margin_auto" >
            <space class="space20"></space>
            <div class="photo-container">
                <img src="Images/IMG_20230518_130442.jpg"/>
            </div>
            <span class="space20"></span>
            <div class="edit-container margin_auto">
                <asp:Button ID="Button1" runat="server" CssClass="btnChange" Text="Change Profile Photo" />
                <span class="space20"></span>
                <asp:Button ID="Button2" runat="server" CssClass="btnDel" Text="Delete Profile Photo" />

            </div>
        </div>
    </div>
</asp:Content>

