<%@ Page Title="" Language="C#" MasterPageFile="~/accounts.Master" AutoEventWireup="true" CodeBehind="CreditNote_TransferReport.aspx.cs" Inherits="AccountsApp.CreditNote_TransferReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
     <div class="container-fluid">
        <h2 class="mt-4">CREDIT NOTE PHYSICAL TRANSFER REPORT</h2>
         <div class="container-fluid">
            <br />
            <div class="row">
                <div class="col-md-4">
                    From<asp:TextBox ID="txtfrmdate" CssClass="form-control" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdate"
                            PopupButtonID="txtfrmdate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                </div>
                <div class="col-md-4">
                     To<asp:TextBox ID="txttodate" CssClass="form-control" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="txttodate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                </div>
                </div><br />
             <div class="row">
                  
                 <div class="col-md-4">
                       Choose Type
                         <asp:DropDownList ID="ddltype" class="form-control" runat="server" BackColor="White">
                             <%--<asp:ListItem Value="0">ALL</asp:ListItem>--%>
                             <asp:ListItem Value="1">Transfered</asp:ListItem>
                             <asp:ListItem Value="2">Received</asp:ListItem>
                       </asp:DropDownList>
                       </div>
                <div class="col-sm-4">   
                    <br />
                    <input type="button" class="btn btn-secondary" id="btnadd"  onserverclick="viewreport"  name="add" value="View Report"  runat="server" width="500" />

                </div>
            </div>         
         
            <br />
              <div class="row">
                <div class="col-sm-12">                  
                     <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                    </rsweb:ReportViewer>
            </div>
                </div>
        </div>
         </div>
</asp:Content>
