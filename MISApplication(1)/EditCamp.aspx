<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="EditCamp.aspx.cs" Inherits="MISApplication.EditCamp" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <br />
        <h2 class="mt-4">Edit Camp</h2>
    <br />
    <div class="row">
                    <div class="col-sm-3">
                        Choose Camp
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlcamp" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcamp_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </div><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                       
        
            <div class="container-fluid" style="background-color: #D7EBFF;">
                <br />
                
                <div class="row">
                    <div class="col-sm-3">
                        Conduct On
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtcampdate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <ajaxtoolkit:CalendarExtender
                        ID="ceDOB"
                        runat="server"
                        Enabled="True"
                        TargetControlID="txtcampdate"
                        PopupButtonID="txtcampdate"
                        Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        Name
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class ="row">
                    <div class="col-sm-3">Time
                        </div>
                        <div class="col-sm-2">
                        From<asp:TextBox ID="txtftime" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                    <div class="col-sm-2">
                        To<asp:TextBox ID="txtttime" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                    </div>
                <div class="row">
                    <div class="col-sm-3">
                        Description
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtdescription" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        Status
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlststus" CssClass="form-control" runat="server" BackColor="#CCCCCC">
                            <asp:ListItem Value="2">Conduct</asp:ListItem>
                            <asp:ListItem Value="1">Not Conduct</asp:ListItem>
                            <asp:ListItem Value="0">Cancelled</asp:ListItem>
                        </asp:DropDownList>
                       <%-- <asp:RadioButtonList ID="rblstatus" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Class="one" Value="0">Cancelled</asp:ListItem>
                            <asp:ListItem Class="one"  Value="2">Conduct</asp:ListItem>
                            <asp:ListItem Class="one" Value="1">Not Conduct</asp:ListItem>
                        </asp:RadioButtonList>--%>
                    </div>
                </div>
                 <div class ="row">
                    <div class="col-sm-3">  
                       Unit Name
                        </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlbranch" CssClass="form-control" runat="server"></asp:DropDownList>
                   </div> 
                    <div class="col-sm-3">
                   </div> 
                 <br />               
            </div>
                <div class="row">
                    <div class="col-sm-3">
                        Place
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtplace" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <input type="button" class="btn btn-primary" id="Button1" name="add" onserverclick="updatecamp" value="Update" runat="server" />
                    </div>
                </div>
                <br />

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

     <script>
      $('#<%=ddlcamp.ClientID%>').chosen();       
     
     </script>
</asp:Content>
