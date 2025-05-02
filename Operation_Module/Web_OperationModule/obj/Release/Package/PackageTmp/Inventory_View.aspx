<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Inventory_View.aspx.cs" Inherits="Web_OperationModule.Inventory_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">INVENTORY STATUS</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Branch Name</label>
                                    <asp:DropDownList ID="cmbBranch"  class="form-control" runat="server" DataValueField="branch_id" DataTextField="name" AutoPostBack="True" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged"></asp:DropDownList>
                                <br />
                                    <label id="lblDept" for="exampleInputEmail1" class="form-label" runat="server">Department</label>
                                    <asp:DropDownList ID="cmbdept"  class="form-control" runat="server" DataValueField="Sdep_id" DataTextField="Sdep_name"></asp:DropDownList>
                                <br />     
                                    <label for="exampleInputEmail1" class="form-label">Month</label>
                                    <asp:DropDownList ID="cmbMnth"  class="form-control" runat="server" DataValueField="MonthNo" DataTextField="MonthName"></asp:DropDownList>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">Year</label>
                                    <asp:DropDownList ID="cmbYr"  class="form-control" runat="server" DataValueField="Year" DataTextField="Year"></asp:DropDownList>
                                <br />
                                    <asp:DropDownList ID="cmbType"  class="form-control" runat="server">
                                        <asp:ListItem>Before 15</asp:ListItem>
                                        <asp:ListItem>After 15</asp:ListItem>
                                        <asp:ListItem>Annual Verification</asp:ListItem>
                                    </asp:DropDownList>
                               <br /> 
                               <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                               
                             </div>
                        </div>
                    <div class="col-sm-12 col-xl-6" style="width:980px;">
                        <div class="bg-light rounded h-100 p-4" >
                            <updatepanel>
                            <asp:GridView ID="GridAmbCondtn" runat="server" Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Item Name" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_ITemName" runat="server" Text='<%# Eval("Item_Name") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="180px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Stock" ItemStyle-Width="70">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_stock" runat="server" Text='<%# Eval("Current_Stock") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="70px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Measurement" ItemStyle-Width="70">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Msrmnt" runat="server" Text='<%# Eval("Sub_Measurement") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="70px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Rate" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_unt" runat="server" Text='<%# Eval("Unit_Rate") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Total Amount" ItemStyle-Width="110">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Amt" runat="server" Text='<%# Eval("Tot_Amt") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="110px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Physical Stock" ItemStyle-Width="80">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Amb_Count") %>'></asp:Label>--%>
                                               <asp:TextBox ID="txt_PStk" runat="server" Width="70" Text='<%# Eval("Phy_Stk") %>' MaxLength="5" OnKeyPress=" return AllowNumericOnly(this);" AutoPostBack="True"></asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="80px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Difference" ItemStyle-Width="70">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Diff" runat="server" Text='<%# Eval("Diff") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="70px" />
                                       </asp:TemplateField>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                            </updatepanel>
                            <br /><br />
                            <asp:Button ID="Btn_Submit" class="btn btn-primary" runat="server" Text="Confirm" OnClick="Btn_Submit_Click" BackColor="#1C5E55" />
                            
                         </div>
                    </div>
                </div>
             </div>
</asp:Content>
