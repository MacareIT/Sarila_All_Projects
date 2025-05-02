<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase.Master" AutoEventWireup="true" CodeBehind="PurcahseIndentDetails.aspx.cs" Inherits="MISApplication.PurcahseIndentDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
   <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <style style="font-size: medium">
         .one {
            margin: 20px;
            padding: 20px;
            
        }      
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server"></asp:ScriptManager>    
            <h2 class="mt-4">INDENT DETAILS</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
               
                <div class="row" runat="server" id="chooseoption">
                    <div class="col-sm-4">
                        Search By Medicine<asp:DropDownList ID="ddlmedicine" class="form-control" AutoPostBack="true" runat="server" BackColor="White" OnSelectedIndexChanged="ddlmedicine_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        Search By Indent
                        <asp:TextBox ID="txtindent" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <br />
                        <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="Button1" name="add" onserverclick="showmedicineList" value="List by Indent" runat="server" />

                    </div>
                </div> 
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                    </div>  
                    <div class="col-sm-2">
                      From<asp:TextBox ID="txtfrmdt" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdt"
                            PopupButtonID="txtfrmdt"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div> 
                     <div class="col-sm-2">
                      To<asp:TextBox ID="txttodate" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="txttodate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div> 
                     <div class="col-sm-2">
                        <br />
<%--                          <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="Button2" name="add" onclick="showmodalpopup" value="View Report" runat="server" />--%>
                        <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="btnadd" name="add" onserverclick="showreport" value="View Report" runat="server" />
                    </div>
                </div>
<br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-sm-4">
                                </div>
                            <div class="col-sm-8">
                                <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                <asp:RadioButtonList ID="Showsearch" runat="server" RepeatLayout="Flow"
                                    AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="Showsearch_SelectedIndexChanged" style="font-weight: 700">
                                    <asp:ListItem Class="one" Value="1">Transfer Pending</asp:ListItem>
                                    <asp:ListItem Class="one" Value="2">Received Pending</asp:ListItem>
                                    <asp:ListItem Class="one" Value="3">All Pending</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel> 
            </div>

            <div class="row">
                <div class="col-sm-12">                  
                     <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="100%">
                    </rsweb:ReportViewer>
            </div>
                </div>       
  <script>
      $('#<%=ddlbranch.ClientID%>').chosen();
      $('#<%=ddlmedicine.ClientID%>').chosen();
      function validatenumbersonly(evt) {
          var charCode = (evt.which) ? evt.which : event.keyCode
          if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
              return true;
          else {
              alert('Please Enter Numeric values.');
              return false;
          }
      }
      function ConfirmBox() {
          if (confirm("Continue?")) {
              alert("Yes");
          } else {
              alert("No");
          }
      }
     
</script>
   
</asp:Content>
