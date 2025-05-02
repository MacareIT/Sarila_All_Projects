<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Upload_Quotation.aspx.cs" Inherits="PurchaseCommittee.Upload_Quotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Vendor Name </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_vendorname" runat="server" CssClass="form-control" required="required" TextMode="MultiLine" Height="100px"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Description </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_dec" runat="server" CssClass="form-control" required="required" TextMode="MultiLine" Height="100px"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-1 col-form-label">Amount </label>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_amt" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <label class="col-lg-2 col-form-label">Upload Quotation </label>
        <div class="col-lg-4">
            <asp:FileUpload ID="file_quotation" runat="server" />
        </div>
    </div>

    <asp:Button ID="Button1" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="Button1_Click" />
</asp:Content>
