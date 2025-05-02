<%@ Page Title="" Language="C#" MasterPageFile="~/MIS.Master" AutoEventWireup="true" CodeBehind="AgewiseStockReport.aspx.cs" Inherits="MISApplication.AgewiseStockReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:ScriptManager runat="server"></asp:ScriptManager>    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                        <h2 class="mt-4">AGEWISE STOCK REPORT</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
                <br />
             <div class="row">
                  <div class="col-sm-5">
                      Choose Branch
                      </div>
                    <div class="col-sm-5">
                        
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                    </div>   
                     <div class="col-sm-2">                       
                        <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="btnadd" name="add" onserverclick="showreport" value="View Report" runat="server" />
                    </div>
                </div> 
                <br />
            </div>
            <br />
                <div class="row">
                <div class="col-sm-12">                  
                     <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                    </rsweb:ReportViewer>
            </div>                 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
