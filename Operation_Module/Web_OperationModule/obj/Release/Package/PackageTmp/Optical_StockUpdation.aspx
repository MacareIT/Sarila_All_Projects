<%@ Page Title="" Language="C#" MasterPageFile="~/Users_master.Master" AutoEventWireup="true" CodeBehind="Optical_StockUpdation.aspx.cs" Inherits="Web_OperationModule.Optical_StockUpdation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">OPTICAL STOCK UPDATION</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Branch Name</label>
                                    <asp:DropDownList ID="cmbBranch"  class="form-control" runat="server" DataValueField="branch_id" DataTextField="branch_name"></asp:DropDownList>
                                <br />
                             <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                          </div>
                        </div>
                    <div class="col-sm-12 col-xl-6" style="width:980px;">
                        <div class="bg-light rounded h-100 p-4" style="height:500px;">
                            <updatepanel runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                             <asp:GridView ID="GridAmbCondtn" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid" OnSelectedIndexChanging="GridAmbCondtn_SelectedIndexChanging">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                        <asp:TemplateField HeaderText="Item Type" ItemStyle-Width="180" Visible="false">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_branchid" runat="server" Text='<%# Eval("branch_id") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="180px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Item Type" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_ITemName" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="100px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="System Stock" ItemStyle-Width="70">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_stock" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="70px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Physical Stock" ItemStyle-Width="80">
                                           <ItemTemplate>
                                                   <asp:TextBox ID="txt_PStk" runat="server" Width="70" Text='<%# Eval("PStock") %>' MaxLength="10" class='allow_decimal' >
                                                   </asp:TextBox>
                                               <%--<Triggers>
                                                 <PostBackTrigger  ControlID="txt_PStk"/>
                                               </Triggers>--%>
                                               <%--<asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Amb_Count") %>'></asp:Label>--%>
                                           </ItemTemplate>
                                           <ItemStyle Width="80px" />
                                       </asp:TemplateField>
                                       <%--<asp:TemplateField HeaderText="Difference" ItemStyle-Width="20"  ItemStyle-ForeColor="#1C5E55" ControlStyle-ForeColor="#1C5E55" HeaderStyle-ForeColor="#1C5E55">
                                           <ItemTemplate>
                                               <asp:TextBox ID="lbl_Diff" runat="server" Width="20" Text='<%# Eval("Diff") %>'  Visible="False">
                                               </asp:TextBox>
                                           </ItemTemplate>

<ControlStyle ForeColor="#1C5E55"></ControlStyle>

<HeaderStyle ForeColor="#1C5E55"></HeaderStyle>

                                           <ItemStyle Width="20px" />
                                       </asp:TemplateField>--%>
                                       
                                      

                                      <%-- <asp:TemplateField ItemStyle-Width="100" ShowHeader="False">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lnk_select" runat ="server" CommandArgument='<%#Eval("AMB_CONDTNID")%>' Text ='Select' CommandName ="Select">
                                                   </asp:LinkButton>
                                           </ItemTemplate>
                                       </asp:TemplateField>--%>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                            </ContentTemplate>
                                <Triggers>
                                <PostBackTrigger ControlID="txt_PStk" EventName="TextChanged"  />
                                </Triggers>
                            </updatepanel>
                            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
                            <script> 
                                $(document).ready(function () {

                                    $(".allow_decimal").on("input", function (evt) {
                                        var self = $(this);
                                        self.val(self.val().replace(/[^0-9\.]/g, ''));
                                        if ((evt.which != 46 || self.val().indexOf('.') != -1) && (evt.which < 48 || evt.which > 57)) {
                                            evt.preventDefault();
                                        }
                                    });

                                });

                            </script>
                            
                            
                            <br /><br />
                            <asp:Button ID="Btn_Submit" class="btn btn-primary" runat="server" Text="Confirm" OnClick="Btn_Submit_Click" BackColor="#1C5E55" />
                            
                          
                         </div>
                    </div>
                </div>
             </div>
</asp:Content>
