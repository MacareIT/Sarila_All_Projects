<%@ Page Title="" Language="C#" MasterPageFile="~/Users_master.Master" AutoEventWireup="true" CodeBehind="FAssetCondition_Add.aspx.cs" Inherits="Web_OperationModule.FAssetCondition_Add" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
        <ContentTemplate>--%>

    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">FIXED ASSET CONDITION REGISTER</label>
                            <br /><br />
                             <asp:Label ID="Branchname" runat="server" class="form-label"  Text=""></asp:Label>
                             <br />
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
                        <div class="bg-light rounded h-100 p-4" >
                            <asp:GridView ID="GridAmbCondtn" runat="server" Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Class Name" ItemStyle-Width="180" Visible="False">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Cls" runat="server" Text='<%# Eval("class_name") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="180px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Asset Id" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Ast" runat="server" Text='<%# Eval("Asset_id") %>' Width="140"></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="180px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Item Name" ItemStyle-Width="230">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Amb_Count") %>'></asp:Label>--%>
                                               <asp:Label ID="lbl_item" runat="server" Text='<%# Eval("item_name") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="230px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Make Name" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_condtn" runat="server" Text='<%# Eval("Amb_Condtn") %>'></asp:Label>--%>
                                               <asp:Label ID="lbl_make" runat="server" Text='<%# Eval("make_name") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="180px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Model Name" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>--%>
                                               <asp:Label ID="lbl_model" runat="server" Text='<%# Eval("model_name") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="180px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Working" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>--%>
                                               <asp:CheckBox ID="chk1" runat="server" Checked='<%# Eval("Working").ToString() == "0" ?false : true %>'/>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Not Working" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>--%>
                                               <asp:CheckBox ID="chk2" runat="server" Checked='<%#Eval("Notworking").ToString() == "0" ?false : true %>'/>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Available" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>--%>
                                               <asp:CheckBox ID="chk3" runat="server" Checked='<%#Eval("Available").ToString() == "0" ?false : true %>'/>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                           

                           <br /><br />
                            <asp:Button ID="Btn_Submit" class="btn btn-primary" runat="server" Text="Confirm" OnClick="Btn_Submit_Click" BackColor="#1C5E55" />
                            
                             
                         </div>
                    </div>
                    
                    <br />
                </div>
             </div>
     <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
