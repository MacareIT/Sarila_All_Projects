<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AddTemporary_Staff.aspx.cs" Inherits="MISApplication.AddTemporary_Staff" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ScriptManager runat="server"></asp:ScriptManager>   
            <h2 class="mt-4">Add Temporary Staff</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double;background-color: #D7EBFF;">
                <br />
                <div class="row">
                    <div class="col-sm-5">
                        Choose Branch
                         <asp:DropDownList ID="ddlbranch" class="form-control" runat="server" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    <div class="col-sm-5">
                       Choose Head
                         <asp:DropDownList ID="ddlhead" class="form-control" runat="server" BackColor="White"></asp:DropDownList>  
                        </div>
                    </div>
                <div class="row">                   
                    <div class="col-sm-5">
                        Enter Name:
                        <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>           
                    </div>
                   <div class="col-sm-5">
                       <br />
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
                </div>
            </div>     
</asp:Content>
