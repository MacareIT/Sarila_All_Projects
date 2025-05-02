<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Todays_Booking.aspx.cs" Inherits="CRM_Application.Todays_Booking" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Todays Booking</h3>
        </div>
    </div>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Doctor</label>
                                <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4"></div>
                    <div class="col-sm-4 col-xs-4">
                        <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server"  id="Btn_submit" onserverclick="View_click" style="width: 150px">VIEW</button>
                    </div>
                        <div class="col-md-1"></div>
                        <div class="col-sm-2 col-xs-2">
                        <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server"  id="Button1" onserverclick="Export_click">EXPORT TO EXCEL</button>
                    </div>

                        <div class="form-group row">
                    </div>
                    </div>

                    <br />
                    <br />
                    <div class="form-group row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="TOKEN NUMBER" ItemStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_token" runat="server" Text='<%#Eval("token") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PATIENT NAME" ItemStyle-Width="500px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_patientname" runat="server" Text='<%#Eval("patient_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PHONE NUMBER" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_phone" runat="server" Text='<%#Eval("phone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="STATUS" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#507CD1" ForeColor="#ffffff" Font-Bold="True" />
                                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>



                    <%--<asp:Panel ID="Panel1" runat="server" Height="15000px" Width="1100px">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ClientIDMode="AutoID" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                        </rsweb:ReportViewer>
                    </asp:Panel>--%>

                </div>
            </div>
        </div>
    <!-- /.row -->
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
