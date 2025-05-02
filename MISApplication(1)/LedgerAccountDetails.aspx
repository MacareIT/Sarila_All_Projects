<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase.Master" AutoEventWireup="true" CodeBehind="LedgerAccountDetails.aspx.cs" Inherits="MISApplication.LedgerAccountDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />

   <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager runat="server"></asp:ScriptManager> 
   
            <h2 class="mt-4">LEDGER ACCOUNT DETAILS</h2>
            <br />
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-3">
                        Choose Vender                       
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList CssClass="form-control" ID="ddlvendor" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-sm-3">

                    </div>

                </div>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
                <div class="row">
                    <div class="col-sm-3">
                                            
                    </div>
                    <div class="col-sm-2">

                    </div>
                    <div class="col-sm-3">
                        <input type="button" class="btn btn-primary" id="Button1" style="background-color: #9999FF" name="add" value="View Report" onserverclick="showreport" runat="server" />
                   </div>
                    
                    </div>                
    </ContentTemplate>
    </asp:UpdatePanel>
                   <script>
                       $('#<%=ddlvendor.ClientID%>').chosen();
                   </script>
            </div>           
            <br />
            <div class="row">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                </rsweb:ReportViewer>
            </div>    
    
</asp:Content>
