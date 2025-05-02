<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase.Master" AutoEventWireup="true" CodeBehind="ItemTransfer_store.aspx.cs" Inherits="MISApplication.ItemTransfer_store" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">ITEM TRANSFER TO VALAPAD STORE REPORT</h2>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-3">
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
                    <div class="col-sm-3">
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
                    <div class="col-sm-2">
                        <br />
                        <input type="button" class="btn btn-primary" id="Button1" name="add" value="View Report" onserverclick="showreport" runat="server" />
                    </div>
                </div>
                <br />
            </div>
            <br />
            <br />
            <div class="row">

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                </rsweb:ReportViewer>

            </div>
                
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
