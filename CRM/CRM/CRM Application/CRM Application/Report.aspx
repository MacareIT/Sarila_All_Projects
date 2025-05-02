<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="CRM_Application.Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
    <%--<div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Consultaion Status </h3>
        </div>
    </div>--%>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-sm-3 col-xs-3">
                            <div class="form-group">
                                <label>From Date</label>
                                <asp:TextBox ID="Text_date" runat="server" CssClass="form-control"></asp:TextBox> 
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Text_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
                            </div>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                            <div class="form-group">
                                <label>To Date</label>
                                <asp:TextBox ID="Text_todate" runat="server" CssClass="form-control"></asp:TextBox> 
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Text_todate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
                            </div>
                        </div>
                        <div class="col-sm-5 col-xs-5">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-sm-4 col-xs-4">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="View_click" style="width: 150px">VIEW</button>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-sm-2 col-xs-2">
                            <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server"  id="Button1" onserverclick="Export_click">EXPORT TO EXCEL</button>
                        </div>
                        <div class="form-group row"></div>
                    </div>

                    <br />
                    <br />

                    <div class="form-group row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="PATIENT NAME" ItemStyle-Width="250px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_patientname" runat="server" Text='<%#Eval("patient_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PHONE NUMBER" ItemStyle-Width="140px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_phone" runat="server" Text='<%#Eval("phone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_dr" runat="server" Text='<%#Eval("dr_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DAPARTMENT NAME" ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_dept" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BOOKED ON" ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_bookingon" runat="server" Text='<%#Eval("booking_date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="STATUS" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <%--<asp:TemplateField HeaderText="ENTERED BY" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_enterby" runat="server" Text='<%#Eval("createdby") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="ENTERED ON" ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_enteron" runat="server" Text='<%#Eval("createddate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
