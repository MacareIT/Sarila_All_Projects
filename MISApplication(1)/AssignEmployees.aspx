<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AssignEmployees.aspx.cs" Inherits="MISApplication.AssignEmployees" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">Employee Department Assign</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
                <br />
                <div class="row">
                    <div class="col-sm-5">
                        Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-sm-5">
                        Choose Department
                         <asp:DropDownList ID="ddldepartment" AutoPostBack="true" class="form-control" runat="server" BackColor="White" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">                    
                    <div class="col-sm-5">
                        Choose Head
                         <asp:DropDownList ID="ddlhead" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <input type="button" class="btn btn-primary" id="Button1" name="addmicro" onserverclick="assignEmployee" value="Assign Department" runat="server" />
                    </div>
                </div>
                <br />
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:TextBox ID="txtempcode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-3">
                    <input type="button" class="btn btn-primary" id="Button3" name="search" onserverclick="searchEmployeecode" value="Search" runat="server" />

                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-3">
                    <input type="button" class="btn btn-primary" id="Button2" name="search" onserverclick="searchEmployee" value="Search" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" ForeColor="Black">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="emp_code" HeaderText="EmpCode" />
                            <asp:BoundField DataField="emp_name" HeaderText="Employee Name" />
                            <asp:TemplateField HeaderText="Choose">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
            </div>
            <br />           
            <div class="row">
                <h3>EXISTING STAFF LIST</h3>
                <div class="col-sm-1">
                </div>
                <div class="col-sm-8">
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

