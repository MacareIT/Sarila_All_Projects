<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AssignHead.aspx.cs" Inherits="MISApplication.AssignHead" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager runat="server"></asp:ScriptManager>   
            <h2 class="mt-4">Assign Head</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double;background-color: #D7EBFF;">
                <br />
                <div class="row">
                    <div class="col-sm-5">
                        Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    <div class="col-sm-5">
                        Choose Department
                         <asp:DropDownList ID="ddldepartment" AutoPostBack="true" class="form-control" runat="server" BackColor="White" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    </div>
                <div class="row">                   
                    <div class="col-sm-5">
                        Choose Head
                         <asp:DropDownList ID="ddlhead" class="form-control" runat="server" BackColor="White"></asp:DropDownList>                   
                    </div>
                   <div class="col-sm-5">
                        Choose Type
                         <asp:DropDownList ID="ddltype" class="form-control" runat="server" BackColor="White">
                             <asp:ListItem Value="">Choose</asp:ListItem>
                             <asp:ListItem Value="unithead">Unit Head</asp:ListItem>
                             <asp:ListItem Value="businesshead">Business Head</asp:ListItem>
                              <asp:ListItem Value="purchasehead">Purchase Head</asp:ListItem>
                              <asp:ListItem Value="shophead">Shop Head</asp:ListItem>
                             <asp:ListItem Value="saleshead">Sales Head</asp:ListItem> 
                             <asp:ListItem Value="microlabincharge">Microlab Incharge</asp:ListItem>
                        </asp:DropDownList>                   
                    </div>
                </div>
                <br />
            </div>                                     
  
    <div class="row">
                 <div class="col-sm-2">
                     Choose Staff
                     </div>
                 <div class="col-sm-5">
                    <asp:DropDownList CssClass="form-control" ID="ddlstaff" runat="server"></asp:DropDownList>
                     </div>
                 <div class="col-sm-5">                       
                     <input type="button" class="btn btn-primary" id="Button1" name="addmicro" onserverclick="assignEmployee" value="Assign Department" runat="server" />
                    </div>
                 </div>
    <br />
           <div class="row">
                 <div class="col-sm-1">
                     </div>
                <div class="col-sm-8">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </div>
               <div class="col-sm-2">
                     </div>
            </div>    
      <script>
        $('#<%=ddlstaff.ClientID%>').chosen();
       
            function validatenumbersonly(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
            return true;
            else {
                alert('Please Enter Numeric values.');
            return false;
            }
           }
  
      </script>
</asp:Content>
