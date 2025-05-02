<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="AmbienceRegister.aspx.cs" Inherits="Web_OperationModule.AmbienceRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:650px;">
                        <div class="bg-light rounded h-100 p-4" >
                           <div class="mb-3">
                               <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">AMBIENCE REGISTER</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Item Name</label>
                                    <asp:TextBox ID="txtItem" class="form-control" runat="server"></asp:TextBox>
                                    
                                <br />
                               <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit"  BackColor="#1C5E55"  OnClick="BtnSubmit_Click1" />
                               &nbsp;&nbsp;<asp:Button ID="BtnCancel" class="btn btn-primary" runat="server" Text="Cancel" BackColor="#1C5E55" OnClick="BtnCancel_Click" />
                             <br /><br />
                               <asp:GridView ID="Grid_Ambience" runat="server" Width="580px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="Grid_Ambience_RowCommand" BorderStyle="Solid">
                                       <Columns>
                                       <asp:TemplateField HeaderText="ID" ItemStyle-Width="50" Visible="False">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("Amb_ID") %>'></asp:Label>
                                           </ItemTemplate>

                                       <ItemStyle Width="50px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ambience" ItemStyle-Width="400">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Amb_Name") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="400px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Select" ItemStyle-Width="100" ShowHeader="False">
                                           <ItemTemplate>
                                               <%--<asp:LinkButton ID="Lnk_Select" runat="server" Text='<%# Eval("Amb_Id") %>'></asp:LinkButton>--%>
                                               <asp:LinkButton ID="lnk_select" runat ="server" CommandArgument='<%#Eval("amb_id")%>' Text ='Select' CommandName ="Select">
                                                   </asp:LinkButton>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                       <%--<asp:CommandField ShowSelectButton="True" runat="server" HeaderText="Select"/>--%>
                                    </Columns>
                            <%--<AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />--%>
                             <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                             <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:GridView>
                             </div>
                             </div>
                          </div>
                      </div>
              </div>
</asp:Content>
