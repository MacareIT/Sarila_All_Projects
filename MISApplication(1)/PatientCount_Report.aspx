<%@ Page Title="" Language="C#" MasterPageFile="~/MIS.Master" AutoEventWireup="true" CodeBehind="PatientCount_Report.aspx.cs" Inherits="MISApplication.PatientCount_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <h2 class="mt-4">DOCTORS PATIENTS/VISITS COUNT LIST</h2>
                     <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
               <br />
                 <div class="row">
               
                   <div class="col-sm-5">  Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                   </div>                   
                
               </div><br />
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
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/_images/calender.png" Width="27px" /></div>
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
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/_images/calender.png" Width="27px" /></div>
                    <div class="col-sm-4">
                        <br />
                       <%-- <input type="button" class="btn btn-primary" id="btnadd" name="add"  value="Show" onserverclick="showreport" runat="server" />--%>
                        <asp:Button ID="Button1" class="btn btn-primary"  runat="server" Text="Show" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                    </div>
                </div><br />
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
</asp:Content>
