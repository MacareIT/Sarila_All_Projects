<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Doctor_booking.aspx.cs" Inherits="CRM_Application.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Doctor Booking </h3>
        </div>
    </div>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label>Tocken</label>
                                <asp:TextBox ID="Text_tocken" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                               
                            </div>
                        </div>
                        <div class="col-sm-8 col-xs-8">
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox ID="Text_date" runat="server" CssClass="form-control" OnTextChanged="ChangeDate_Event" AutoPostBack="true" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Text_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-8 col-xs-8">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Doctor</label>
                                <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dr_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Visiting Time</label>
                                <asp:DropDownList ID="Ddl_visitingtime" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Patient Name</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Text_patientname" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator> 
                                <asp:TextBox ID="Text_patientname" runat="server" CssClass="form-control"></asp:TextBox>              
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Phone Number</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Text_phone" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Text_phone" ValidationExpression="[0-9]{10}" Text="* Invalid Phone Number!" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="Text_phone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-5"></div>
                        <div class="col-sm-4 col-xs-4">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Submit_click" >Submit</button>
                        </div>

                        <div class="form-group row">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <!-- /.row -->
</asp:Content>
