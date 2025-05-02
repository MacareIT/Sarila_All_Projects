<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="NABL_Accreditatn_Reg.aspx.cs" Inherits="Web_OperationModule.NABL_Accreditatn_Reg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">NABL ACCREDITATION REGISTER</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Branch Name</label>
                                    <asp:DropDownList ID="cmbBranch"  class="form-control" runat="server" DataValueField="branch_id" DataTextField="branch_name" Enabled="False"></asp:DropDownList>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">Issued_Date</label>
                                    <asp:TextBox ID="txt_issuedate" runat="server" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_issuedate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                               <%-- <br />
                                    <label for="exampleInputEmail1" class="form-label">End_Date</label>
                                    <asp:TextBox ID="txt_enddate" runat="server" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_enddate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> --%>                         
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
                        <asp:GridView ID="Grid_Ambience" runat="server" Width="800px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"  BorderColor="Black" DataKeyNames="Id">
                                   <Columns>
                                       <asp:TemplateField HeaderText="Branch_Name" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Branch_Name") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="250px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Issued On" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_start" runat="server" Text='<%# Eval("Issued_Date") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="180px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Valid Upto" ItemStyle-Width="70">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_end" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="180px" />
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
                            

                             </div>
                           </div>
                         </updatepanel>
                       
                     <br /> 
        <br />
         </div>
</asp:Content>
