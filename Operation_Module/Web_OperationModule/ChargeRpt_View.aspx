<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="ChargeRpt_View.aspx.cs" Inherits="Web_OperationModule.ChargeRpt_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label1" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">CHARGE REPORT</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Branch Name</label>
                                    <asp:DropDownList ID="cmbBranch"  class="form-control" runat="server" DataValueField="branch_id" DataTextField="name" AutoPostBack="True" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged" ></asp:DropDownList>
                                <br />  
                                    <label for="exampleInputEmail1" class="form-label">Entered by</label>
                                    <asp:DropDownList ID="cmbStaff"  class="form-control" runat="server" DataValueField="Entered_by" DataTextField="Staff" ></asp:DropDownList>
                                <br />  
                                 
                               <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                               
                             </div>
                        </div>
                    
                </div>
             </div>
</asp:Content>
