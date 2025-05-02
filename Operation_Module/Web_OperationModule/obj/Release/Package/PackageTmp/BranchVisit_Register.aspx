<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="BranchVisit_Register.aspx.cs" Inherits="Web_OperationModule.BranchVisit_Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">BRANCH VISIT</label>
                            <br /><br />
                            <asp:Label ID="Label4" runat="server" class="form-label" Text="Branch Name"></asp:Label>
                            <asp:DropDownList ID="cmb_branch" class="form-control" runat="server" DataTextField="Name" DataValueField="Branch_Id"></asp:DropDownList>
                            <br />
                             <label for="exampleInputEmail1" class="form-label">Month</label>
                                    <asp:DropDownList ID="cmbMnth"  class="form-control" runat="server" DataValueField="MonthNo" DataTextField="MonthName"></asp:DropDownList>
                            <br />
                                    <label for="exampleInputEmail1" class="form-label">Year</label>
                                    <asp:DropDownList ID="cmbYr"  class="form-control" runat="server" DataValueField="Year" DataTextField="Year"></asp:DropDownList>
                            <br />
                             <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                        </div>
                        </div>
                    <div class="col-sm-12 col-xl-6" style="width:980px;">
                        <div class="bg-light rounded h-100 p-4" style="height:500px;">
                            <label id="Label1" for="exampleInputEmail1" class="form-label" runat="server">CASH POSITION STATUS</label>
                            <updatepanel runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:Panel ID="Mypan" runat="server">
                                <asp:GridView ID="GridCashPosition1" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Physical Cash" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_PCash" runat="server" Width="100"  Text='<%# Eval("Name") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);"  >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="System Cash" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_SCash" runat="server" Width="100" Text='<%# Eval("Status") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" OnTextChanged="txt_SCash_TextChanged"  AutoPostBack="True">
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Difference" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Diff" runat="server" Width="70" Text='<%# Eval("Remarks") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>

                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                            
                                <br />

                                 <asp:GridView ID="GridCashPosition2" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Physical Cash" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_PCash" runat="server" Width="100" Text='<%# Eval("Name") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);"  AutoPostBack="True">
                                               </asp:TextBox>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Registerwise" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_SCash" runat="server" Width="100" Text='<%# Eval("Status") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" OnTextChanged="txt_SCash_TextChanged" AutoPostBack="True">
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Difference" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Diff" runat="server" Width="70" Text='<%# Eval("Remarks") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>

                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                                
                                <br />
                                <label id="Label2" for="exampleInputEmail1" class="form-label" runat="server">REGISTERS</label>
                                <asp:GridView ID="GridRegisters" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Updating Registers" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Upd" runat="server" Text='<%# Eval("Name") %>' Width="150"></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Status" ItemStyle-Width="300">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Status" runat="server" Width="300" Text='<%# Eval("Status") %>' >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="300px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="350">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="350" Text='<%# Eval("Remarks") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="350px" />
                                       </asp:TemplateField>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>

                                <br />
                                <label id="Label3" for="exampleInputEmail1" class="form-label" runat="server">ASSET VERIFICATION</label>
                                <asp:GridView ID="GridAssetVerifn" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Asset Verification" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_AsstVerfn" runat="server" Text='<%# Eval("Name") %>' Width="150"></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Working Status" ItemStyle-Width="300">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_WrkStatus" runat="server" Width="300" Text='<%# Eval("Status") %>' >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="300px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="350">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="350" Text='<%# Eval("Remarks") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="350px" />
                                       </asp:TemplateField>

                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                                    </asp:Panel>
                               <%-- <Triggers>
                                <PostBackTrigger ControlID="txt_PStk" EventName="TextChanged"  />
                                </Triggers>--%>
                                </ContentTemplate>
                            </updatepanel>

                             <script type="text/javascript" charset="utf-8">

                                 function isNumberKey(evt) {
                                     var charCode = (evt.which) ? evt.which : evt.keyCode;
                                     if (charCode != 46 && charCode > 31
                                         && (charCode < 48 || charCode > 57))
                                         return false;

                                     return true;
                                 }
                             </script>
                            
                            
                            <br /><br />
                            <%--<asp:Button ID="Btn_Submit1" class="btn btn-primary" runat="server" Visible="false" Text="Confirm" BackColor="#1C5E55" OnClick="Btn_Submit_Click1" />--%>
                            <asp:Button ID="Btn_Submit2" class="btn btn-primary" runat="server" Text="Confirm" BackColor="#1C5E55" OnClick="Btn_Submit2_Click" />
                         </div>
                    </div>
                </div>
             </div>
</asp:Content>
