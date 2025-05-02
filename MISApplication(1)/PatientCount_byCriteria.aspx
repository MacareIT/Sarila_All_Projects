<%@ Page Title="" Language="C#" MasterPageFile="~/MIS.Master" AutoEventWireup="true" CodeBehind="PatientCount_byCriteria.aspx.cs" Inherits="MISApplication.PatientCount_byCriteria" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">DOCTORS PATIENTS/VISITS COUNT BY CRITERIA</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
                <br />
                <div class="row">

                    <div class="col-sm-5">
                        Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                    </div>
                    <div class="col-sm-5">
                        Choose Department
                         <asp:DropDownList ID="ddldepartment" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        From Date<asp:TextBox ID="txtfrmdt" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdt"
                            PopupButtonID="ImageButton1"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-1">
                        <br />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/_images/calender.png" Width="27px" />
                    </div>
                    <div class="col-sm-4">
                        To date<asp:TextBox ID="txttodate" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="ImageButton2"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-1">
                        <br />
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/_images/calender.png" Width="27px" />
                    </div>
                    <br />
                    <div class="col-sm-2">
                        <br />
                        <input type="button" class="btn btn-primary" id="btnadd" name="add" value="Show Report" onserverclick="showreport" runat="server" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-5">
                        Choose Option
                         <asp:DropDownList ID="ddloption" BackColor="White" class="form-control" runat="server">
                             <asp:ListItem Value="GREATER">Greater Than</asp:ListItem>
                             <asp:ListItem Value="LESSER">Less Than</asp:ListItem>
                             <asp:ListItem Value="EQUALS">Equals</asp:ListItem>
                             <asp:ListItem>ALL</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <div class="col-sm-5">
                        Enter Count Value
                         <asp:TextBox ID="txtcriteria" onkeypress="return numeric(event)" CssClass="form-control" runat="server">4</asp:TextBox>
                    </div>

                </div>

                <br />
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-sm-1">
                </div>
                <div class="col-sm-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                    </rsweb:ReportViewer>
                </div>
                <div class="col-sm-1">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" language="javascript">
        function numeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
                return true;
            else {
                alert('Please Enter Numeric values.');
                return false;
            }
        }
    </script>
</asp:Content>
