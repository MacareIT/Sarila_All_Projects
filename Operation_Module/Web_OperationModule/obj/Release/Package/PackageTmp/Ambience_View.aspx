<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Ambience_View.aspx.cs" Inherits="Web_OperationModule.Ambience_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">AMBIENCE CONDITION</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Branch Name</label>
                                    <asp:DropDownList ID="cmbBranch"  class="form-control" runat="server" DataValueField="branch_id" DataTextField="name"></asp:DropDownList>
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
                   <script>
                       $('#custom7').on('change', function () {
                           this.value = this.checked ? 1 : 0;
                           // alert(this.value);
                       }).change();
                   </script>
                         </div>
             </div>
                        <updatepanel>
                        <div class="col-sm-12 col-xl-6" style="width:980px;">
                        <div class="bg-light rounded h-100 p-4" >    
                        <asp:GridView ID="Grid_Ambience" runat="server" Width="800px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"  OnRowEditing="Grid_Ambience_RowEditing" OnRowUpdating="Grid_Ambience_RowUpdating" OnRowDataBound="Grid_Ambience_RowDataBound" BorderColor="Black" OnRowCancelingEdit="Grid_Ambience_RowCancelingEdit">
                                   <Columns>
                                       <asp:TemplateField HeaderText="ID" ItemStyle-Width="50" Visible="False">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_conId" runat="server" Text='<%# Eval("AMB_CONDTNID") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="50px"></ItemStyle>
                                       </asp:TemplateField>
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
                                       <asp:TemplateField HeaderText="Count" ItemStyle-Width="250">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Amb_Count") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="250px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="WorkingCondition" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_condtn" runat="server" Text='<%# Eval("Amb_Condtn") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="400">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="400px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Cleared" ItemStyle-Width="300">
                                           <EditItemTemplate>
                                               <asp:CheckBox ID="chkbox" runat="server"   Checked='<%#Convert.ToBoolean(Eval("Amb_checked"))%>'/> <%--Text='<%# Eval("Amb_checked") %>'--%> 
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:CheckBox ID="chkbox" runat="server" Checked='<%#Convert.ToBoolean(Eval("Amb_checked"))%>' Enabled="false"/>
                                           </ItemTemplate>
                                           <ItemStyle Width="300px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Explanation" ItemStyle-Width="500">
                                           <EditItemTemplate>
                                               <asp:TextBox ID="txtExplanation" runat="server" Text='<%# Eval("Amb_Reason") %>'></asp:TextBox>
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="lblExplanation" runat="server" Text='<%# Eval("Amb_Reason") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField ItemStyle-Width="200" ShowHeader="False">
                                           <ItemTemplate>  
                                             <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" ForeColor="#006666" />  
                                           </ItemTemplate>  
                                           <EditItemTemplate>  
                                             <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                                             <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                                           </EditItemTemplate> 
                                       <ItemStyle Width="200px"></ItemStyle>
                                       </asp:TemplateField>
                                       <%--<asp:CommandField ShowSelectButton="True" runat="server" HeaderText="Select"/>--%>
                                    </Columns>
                                 
                                   <%-- <AlternatingRowStyle BackColor="White" />
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
                            <br />
                            
                            
                            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                <ItemTemplate>
                                               <asp:Label ID="Label1" runat="server" Text='<%# Eval("amb_pic_name") %>'></asp:Label>
                                               <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("amb_pic_path") %>' Width="150" Height="130"  />
                                </ItemTemplate>
                                <ItemStyle Width="170px"></ItemStyle>
                            </asp:DataList>
                            <br />
                            <asp:Button ID="BtnVerify" class="btn btn-primary" runat="server" Text="Verify"  BackColor="#1C5E55" OnClick="BtnVerify_Click" />
                            </div>
                           </div>
                         </updatepanel>
                       
                     <br /> 
        <br />
         </div>           
               
</asp:Content>
