<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="Web_OperationModule.Change_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label1" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">CHANGE PASSWORD</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">
                                    <br />
                                    User Name</label>
                                    <asp:TextBox ID="txtUname" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">Old Password</label>
                                    <asp:TextBox ID="txtOld" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">New Password</label>
                                    <asp:TextBox ID="txtNew" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">Confirm Password</label>
                                    <asp:TextBox ID="txtConfirm" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="lblValidtn" runat="server" Text="Password Mismatch" Visible="False" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                             <br />
                               <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                               
                             </div>
                        </div>
                </div>
             </div>
</asp:Content>
