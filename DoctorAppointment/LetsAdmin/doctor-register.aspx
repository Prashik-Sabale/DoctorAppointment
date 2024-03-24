<%@ Page Title="" Language="C#" MasterPageFile="~/LetsAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="doctor-register.aspx.cs" Inherits="LetsAdmin_doctor_register" %>

<%@ MasterType VirtualPath="~/LetsAdmin/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1 class="pageTitle">Speciality</h1>
            <span class="space20"></span>
            <div class="col_50p">
                <div class="pad_10">
                    <div class="formPanel">
                        <h4 class="formTitle themeDarkBg">Add Doctors Data</h4>
                        <div class="pad_10">
                            <asp:Label ID="lblId" runat="server" CssClass="HideCol" Text="[New]"></asp:Label>
                            <span class="space20"></span>
                            <div class="w50 float_left">
                                <span class="lblName">First Name </span>
                                <span class="space10"></span>
                                <asp:TextBox ID="txtFName" CssClass="full-name" placeholder="First Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="w50 float_left">
                                <span class="space10"></span>
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
                            <div class="float_clear"></div>

                            <span class="space20"></span>
                            <asp:Button ID="btnSave" runat="server" CssClass="buttonForm float_left mrgRgt10" Text="Save Info" OnClick="btnSave_Click" />

                            <asp:Button ID="btnReset" runat="server" CssClass="addNew float_left mrgRgt10" Text="Reset" OnClick="btnReset_Click" />

                            <asp:Button ID="btnDelete" runat="server" CssClass="addNew float_left mrgRgt10" Text="Delete" OnClick="btnDelete_Click"  />

                            <div class="float_clear"></div>


                        </div>
                    </div>
                </div>
            </div>

            <div class="col_50p">
                <div class="pad_10">
                    <div class="formPanel">
                        <h4 class="formTitle themeDarkBg">View Doctors Data</h4>
                        <div class="pad_10">
                            <span class="space20">
                            <asp:GridView ID="gvDoc" runat="server" AutoGenerateColumns="False" CssClass="gvApp" GridLines="None" OnRowDataBound="gvDoc_RowDataBound">
                                <RowStyle CssClass="row" />
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:BoundField DataField="docId" HeaderText="ID">
                                    <HeaderStyle CssClass="HideCol" />
                                    <ItemStyle CssClass="HideCol" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="docName">
                                    <ItemStyle Width="100%" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="20%" />
                                        <ItemTemplate>
                                            <asp:Literal ID="litAnch" runat="server"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <span class="warning">No Data to Display</span>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </span>

                        </div>
                    </div>
                </div>
            </div>
            <div class="float_clear"></div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

