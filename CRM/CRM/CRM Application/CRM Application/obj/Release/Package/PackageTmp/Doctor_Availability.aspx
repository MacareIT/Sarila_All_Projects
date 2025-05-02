<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Doctor_Availability.aspx.cs" Inherits="CRM_Application.Doctor_Availability" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Doctor Booking</h3>
        </div>
    </div>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <div class="row">
                        
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox ID="Text_date" runat="server" CssClass="form-control" OnTextChanged="ChangeDate_Event" AutoPostBack="true" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Text_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
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
                        <%--<div class="col-md-5"></div>
                        <div class="col-sm-4 col-xs-4">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" >Submit</button>
                        </div>--%>

                        <div class="form-group row">
                        </div>
                        
                    </div>
                        
                   <%-- <triggers>
                                <asp:asyncpostbacktrigger controlid="Ddl_dept" eventname="ddl_SelectedIndexChanged" />
                                
                            </triggers>--%>

                <%--</div>--%>
            <%--</div>--%>
            <%--<div class="card card-body">--%>
           
            <div class="form-group row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_drid" runat="server" Text='<%#Eval("dr_id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="500px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_drname" runat="server" Text='<%#Eval("dr_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="DOCTOR ID" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("dr_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DUTY ID" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_from" runat="server" Text='<%#Eval("duty_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="DUTY TIME" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_time" runat="server" Text='<%#Eval("time_") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NO OF BOOKING" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_bookinno" runat="server" Text='<%#Eval("Booking_no")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="booknow" CommandArgument="<%# Container.DataItemIndex %>">BOOK NOW</asp:LinkButton>
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
                        
            <%-- <asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
            <div runat="server" id="div_booking">
                <asp:Label ID="Label_drid" runat="server" Text="" Visible="false"></asp:Label>
                <div class="row">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                    <div class="col-sm-2 col-xs-2">
                        <div class="form-group">
                            <label>Tocken</label>
                            <asp:TextBox ID="Text_tocken" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                               
                        </div>
                    </div>
                    <div class="col-sm-5 col-xs-5">
                        <div class="form-group">
                            <label>Doctor</label>
                            <asp:TextBox ID="Text_doctor" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-5 col-xs-5">
                        <div class="form-group">
                            <label>Visiting Time</label>
                            <asp:TextBox ID="Text_time" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xs-6">
                        <div class="form-group">
                            <label>Patient Name</label><asp:Label ID="Label_requiredname" runat="server" Text="* Required" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Text_patientname" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>--%> 
                            <asp:TextBox ID="Text_patientname" runat="server" CssClass="form-control"></asp:TextBox>              
                        </div>
                    </div>
                    <div class="col-sm-6 col-xs-6">
                        <div class="form-group">
                            <label>Phone Number</label><asp:Label ID="Label_requiredphone" runat="server" Text="* Required" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Text_phone" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>--%> 
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Text_phone" ValidationExpression="[0-9]{10,12}" Text="* Invalid Phone Number!" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="Text_phone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                   

                    
                </div>
              </div>

                    </ContentTemplate>
                        </asp:UpdatePanel>
                     <div class="row">
                    <div class="form-group row">
                    </div>
                    <div class="col-md-5"></div>
                    <div class="col-sm-4 col-xs-4">
                        <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Submit_click" >CONFIRM BOOKING</button>
                    </div>
                   </div>
                   <%-- <Triggers>        
                         <asp:PostBackTrigger ControlID="Button1" />
                   </Triggers>--%>
                   
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</div>
    <!-- /.row -->
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
