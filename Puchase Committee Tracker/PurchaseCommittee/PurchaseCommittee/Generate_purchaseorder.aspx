<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Generate_purchaseorder.aspx.cs" Inherits="PurchaseCommittee.Generate_purchaseorder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Date </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
        </div>
    </div>
    
    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Purchase Order Number </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_purchaseordernum" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
    </div>

    <%--<div class="form-group row">
        <label class="col-lg-4 col-form-label" >Vendor Name </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_vendorname" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" required="required"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Description </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_description" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" required="required"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Amount </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_amount" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
    </div>--%>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Subject </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_subject" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Payment Terms & Conditions </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_termsandconditions" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" required="required"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Delivery Address </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_deliveryaddress" runat="server" CssClass="form-control" required="required" TextMode="MultiLine" Height="100px"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click"/>
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server" Height="1500px" Width="1100px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1210px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        </rsweb:ReportViewer>
    </asp:Panel>

</asp:Content>
