<%@ Page Title="" Language="C#" MasterPageFile="~/LetsAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="specialty-master.aspx.cs" Inherits="LetsAdmin_specialty_master" %>
<%@ MasterType VirtualPath="~/LetsAdmin/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h1 class="pageTitle">Speciality</h1>
    <span class="space20"></span>
    <div class="col_50p">
        <div class="pad_10">
            <div class="formPanel">
                <h4 class="formTitle themeDarkBg">Add Speciality</h4>
                <div class="pad_10">
                    <span class="space20"></span>

                    <asp:Label ID="lblId" runat="server" CssClass="HideCol"  Text="[New]"></asp:Label>


                    <div class="w50 float_left">
                        <span class="space10"></span>
                        <span class="labelCap ">Speciality Name:*</span>

                        <asp:TextBox ID="txtSPName" runat="server" CssClass="textBox"></asp:TextBox>
                        <span class="space10"></span>
                    </div>
                    <div class="float_clear"></div>
                    <span class="space20"></span>

                    <asp:Button ID="btnSave" runat="server" CssClass="buttonForm float_left mrgRgt10" Text="Save Info" OnClick="btnSave_Click" />

                    <asp:Button ID="btnReset" runat="server" CssClass="addNew float_left mrgRgt10" Text="Reset" OnClick="btnReset_Click" />

                    <asp:Button ID="btnDelete" runat="server" CssClass="addNew float_left mrgRgt10" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />

                    <div class="float_clear"></div>
                    <span class="space20"></span>
                </div>

            </div>
        </div>
    </div>
    <div class="col_50p">
        <div class="pad_10">
            <div class="formPanel">
                <h4 class="formTitle themeDarkBg">All Speciality</h4>
                <div class="pad_10">
                    <span class="space20"></span>
                    
                     <asp:GridView ID="gvSpec" runat="server" AutoGenerateColumns="False" CssClass="gvApp" GridLines="None" OnRowDataBound="gvSpec_RowDataBound">
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:BoundField DataField="speId" HeaderText="ID" >

                                <HeaderStyle CssClass="HideCol" />
                                <ItemStyle CssClass="HideCol" />
                            </asp:BoundField>
                            <asp:BoundField DataField="speName" HeaderText="Speciality">
                                <ItemStyle Width="80%" />
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
                </div>
            </div>
        </div>
    </div>
    <div class="float_clear"></div>
</asp:Content>