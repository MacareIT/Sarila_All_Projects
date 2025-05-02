<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Module_Usage.aspx.cs" Inherits="ModuleUsage.Module_Usage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <%-- <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Add Module</h3>
        </div>
    </div>--%>
     <%--<div class="container-fluid">--%>
        <h2 class="mt-4">MODULE USAGE REPORT</h2>
        <%-- <div class="container-fluid">
            <br />--%>
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
                 <div class="col-md-4">
                     <br />
                     <asp:Button ID="btnSubmit" runat="server" type="submit" Text="SUBMIT"  BackColor="#008686" BorderStyle="None" ForeColor="White" Width="100" Height="37" OnClick="btnSubmit_Click" />
                 </div>
                </div><br />
                   <%-- <div class="col-md-5"></div>
                        <div class="col-sm-4 col-xs-4">--%>
                            
                            <%--<button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" >Submit</button>--%>
                       <%-- </div> --%>  
         
           <div class="row">
              <div class="row">
                <div class="col-sm-12">                  
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1200px" Height="800px"></rsweb:ReportViewer>
               </div>
        </div>
    <div class="row">
                <div class="col-sm-12">                  
                    <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="1200px" Height="1000px"></rsweb:ReportViewer>
                </div>
        </div>
     <div class="row">
     <%--   <div class="col-sm-12">   
            <rsweb:ReportViewer ID="ReportViewer3" runat="server" Width="1200px" Height="450px"></rsweb:ReportViewer>
        </div>--%>
    </div>
               </div>
    
   
        <%-- </div>
        </div>--%>
</asp:Content>
