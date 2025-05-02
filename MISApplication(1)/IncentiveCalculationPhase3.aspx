<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncentiveCalculationPhase3.aspx.cs" Inherits="MISApplication.IncentiveCalculationPhase3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="css/styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
          <h1>Daily Incentive Collection</h1>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double;background-color: #D7EBFF;">
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <i class="fa fa-backward" style="font-size: 30px; color: red" onclick="return theFunction();"></i>
                    </div>
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
                            PopupButtonID="ImageButton1"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-1">
                        <br />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/_images/calender.png" Width="27px" />
                    </div>
                </div>
                <br />
                <div class="row">

                    <div class="col-sm-5">
                        <br />
                    </div>
                    <div class="col-sm-2">
                        <br />                  
                        <input type="button" class="btn btn-primary" id="Button1" name="addmicro" onserverclick="showmicrolab" value="View Microlab" runat="server" style="background-color: #00CC99" />

                    </div>
                     <div class="col-sm-2">
                        <br />                     
                         <input type="button" class="btn btn-primary" id="btnadd" name="add" onserverclick="showreport" value="View Collection" runat="server" style="background-color: #33CCCC" />

                    </div>
                    <div class="col-sm-2">
                        <br />                     
                        <input type="button" class="btn btn-primary" id="btnshow" name="addmicro" onserverclick="showreportincentive" value="Load Incentive" runat="server" style="background-color: #9999FF" />

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
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function theFunction() {
        window.location = "IncentiveDashboard.aspx";
    }
</script>
