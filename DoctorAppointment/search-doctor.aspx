<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="search-doctor.aspx.cs" Inherits="search_doctor" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="col_1200">

        <div class="pad_20">
            <h1 class="txt-header">Search Doctors in Your Area</h1>
            <asp:TextBox ID="txtSearch" CssClass="txtSearch" runat="server" placeholder="Search For: Doctors & Specialities"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="searchBtn" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
    </div>
    <div class="col_1200">
        <div class="pad_20">
            <div class="doctors-details border_r_20 ">
                <div class="img-box">
                    <span class="space30"></span>
                    <div class="pad_30">
                        <img src="<%=Master.rootPath + "Images/Icons/doctor.png" %>" alt="doc-icon" class="doc-icon border_r_20" />
                    </div>
                </div>

                <div class="txt-box">
                    <span class="space40"></span>
                    <div class="pad_10">
                        <a class="font-semibold">Dr. XYZ</a>
                        <span class="space10"></span>
                        <span class="txt-details">BDS, MDS</span>
                        <span class="space10"></span>
                        <span class="txt-speciality">Dentist</span>
                        <span class="space15"></span>
                        <span class="space5"></span>
                        <span class="txt-exp">10 years exp</span>
                        <span class="space10"></span>
                        <span class="space5"></span>
                      
                        <asp:Button ID="btnAppoint" runat="server" CssClass="book-appointment" Text="Book Appointment" />

                    </div>

                </div>

            </div>
        </div>

    </div>

</asp:Content>

