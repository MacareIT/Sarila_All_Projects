<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Consultaion_Status.aspx.cs" Inherits="CRM_Application.Consultaion_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Consultation Status </h3>
        </div>
    </div>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox ID="Text_date" runat="server" CssClass="form-control" OnTextChanged="ChangeDate_Event" AutoPostBack="true"></asp:TextBox> 
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Text_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
                            </div>
                        </div>
                        <%--<div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Doctor</label>
                                <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dr_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                    </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_bookingid" runat="server" Text='<%#Eval("booking_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                    <asp:TemplateField HeaderText="ARRIVED OR NOT" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp;" Checked='<%#Convert.ToBoolean(Eval("status1"))%>' />
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
                        <div class="col-sm-4 col-xs-4" >
                        
                        </div>
                        <div class="col-sm-4 col-xs-4" id="appear" runat ="server">
                        <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Submit_click" id="Btn_submit">UPDATE</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    <!-- /.row -->
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
