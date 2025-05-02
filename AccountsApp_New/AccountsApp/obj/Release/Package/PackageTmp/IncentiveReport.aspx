<%@ Page Title="" Language="C#" MasterPageFile="~/accounts.Master" AutoEventWireup="true" CodeBehind="IncentiveReport.aspx.cs" Inherits="AccountsApp.IncentiveReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2 class="mt-4">INCENTIVE COLLECTION DETAILS</h2>
                <br />
                <div class="container-fluid">
                    <br />
                    <div class="row">
                        <div class="col-sm-5">
                            Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            Date<asp:TextBox ID="txtfrmdt" class="form-control" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender
                                ID="ceDOB"
                                runat="server"
                                Enabled="True"
                                TargetControlID="txtfrmdt"
                                PopupButtonID="txtfrmdt"
                                Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                        </div>
                        <div class="col-sm-1">
                            <br />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-5">
                            <br />
                        </div>
                        <div class="col-sm-2">
                            <br />
                            <input type="button" class="btn btn-primary" id="Button1" name="addmicro" onserverclick="showmicrolab" value="View MicrolabIncentive" runat="server" style="background-color: #00CC99" />
                        </div>
                        <div class="col-sm-2">
                            <br />
                            <input type="button" class="btn btn-primary" id="btnshow" name="addmicro" onserverclick="showreportincentive" value="View UnitIncentive" runat="server" style="background-color: #9999FF" />
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
    </div>
</asp:Content>
