<%@ Page Title="" Language="C#" MasterPageFile="~/MIS.Master" AutoEventWireup="true" CodeBehind="MISCampConversionRpt.aspx.cs" Inherits="MISApplication.MISCampConversionRpt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">CAMP CONVERSION REPORT</h2>
            <div class="container-fluid" style="border-color: #C0C0C0;background-color: #D7EBFF;">
               <br />
                   <div class="row">
                    <div class="col-sm-5">
                        From<asp:TextBox ID="txtfrmdt" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdt"
                            PopupButtonID="txtfrmdt"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                        </div>
                       <div class="col-sm-5">
                           To<asp:TextBox ID="txttodate" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="txttodate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                        </div>
                       </div>
                <div class="row">
                    <div class="col-sm-5">
                        Choose Camp
                         <asp:DropDownList ID="ddlcamp" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <input type="button" class="btn btn-primary" id="btnadd" name="add" onserverclick="showPatientreport" value="Camp Patients" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <br />                        
                        <input type="button" class="btn btn-primary" id="Button2" name="add" onserverclick="showallConversionreport" value="Conversion Report" runat="server" />
                        <input type="button" class="btn btn-primary" id="Button1" visible="false" name="add" onserverclick="showConversionreport" value="Patient Conversion List" runat="server" />
                    </div>
                      <div class="col-sm-2">
                        <br />
                    </div>
                </div>
                <br />
            </div>
             <div class="row">
                <div class="col-sm-12">
                     <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                    </rsweb:ReportViewer>                  
            </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
