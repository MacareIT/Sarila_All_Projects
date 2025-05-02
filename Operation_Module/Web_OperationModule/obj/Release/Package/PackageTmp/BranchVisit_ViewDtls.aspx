<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="BranchVisit_ViewDtls.aspx.cs" Inherits="Web_OperationModule.BranchVisit_ViewDtls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                                    <label for="exampleInputEmail1" class="form-label">Branch Name</label>
                                    <asp:DropDownList ID="cmbBranch"  class="form-control" runat="server" DataValueField="branch_id" DataTextField="name"></asp:DropDownList>
                                <br />  
                                    <label for="exampleInputEmail1" class="form-label">Month</label>
                                    <asp:DropDownList ID="cmbMnth"  class="form-control" runat="server" DataValueField="MonthNo" DataTextField="MonthName"></asp:DropDownList>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">Year</label>
                                    <asp:DropDownList ID="cmbYr"  class="form-control" runat="server" DataValueField="Year" DataTextField="Year"></asp:DropDownList>
                                <br />

                               <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit"  BackColor="#1C5E55" />
                               <br />
                               <br />
                               
                             </div>
                        </div>
                    
                </div>
                <asp:GridView ID="Grid_Ambience" runat="server" Width="800px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" BorderColor="Black" OnRowCommand="Grid_Ambience_RowCommand">
                                   <Columns>
                                       <asp:TemplateField HeaderText="Open Link" ItemStyle-Width="400">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="Lbtn_Link" runat="server" Text='<%# Eval("Link") %>' CommandArgument='<%# Bind("Link") %>' CommandName="Select"></asp:LinkButton>
                                           </ItemTemplate>
                                           <ItemStyle Width="400px" />
                                       </asp:TemplateField>
                                   </Columns>
                                    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:GridView>
             </div>
</asp:Content>
