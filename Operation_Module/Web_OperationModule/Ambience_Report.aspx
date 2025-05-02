<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="Ambience_Report.aspx.cs" Inherits="Web_OperationModule.Ambience_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:900px;">
                        <div class="mb-3">
                            <asp:Label ID="Label1" runat="server" class="form-label" Text="Branch Name"></asp:Label>
                            <asp:DropDownList ID="cmb_branch" class="form-control" runat="server" DataTextField="Name" DataValueField="Branch_Id"></asp:DropDownList>
                            <br />
                            <asp:Label ID="Label2" runat="server" class="form-label" Text="Month"></asp:Label>
                            <asp:DropDownList ID="cmbMonth" class="form-control" runat="server" DataTextField="MonthName" DataValueField="MonthNo">
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="Label3" runat="server" class="form-label" Text="Year"></asp:Label>
                            <asp:DropDownList ID="cmbYear" class="form-control" runat="server" DataTextField="Year" DataValueField="Year">
                            </asp:DropDownList>
                            <br />
                            <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" BackColor="#1C5E55" OnClick="BtnSubmit_Click" />
                            <br /><br />
                            </div>
                            <asp:GridView ID="Grid_Ambience" runat="server" Width="800px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" BorderColor="Black">
                                   <Columns>
                                       <asp:TemplateField HeaderText="Ambience" ItemStyle-Width="400">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Ambience") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="400px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Count" ItemStyle-Width="250">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Count") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="250px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="WorkingCondition" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_condtn" runat="server" Text='<%# Eval("Condition") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="400">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="400px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Cleared" ItemStyle-Width="300">
                                           <EditItemTemplate>
                                               <asp:CheckBox ID="chkbox" runat="server"   Checked='<%#Convert.ToBoolean(Eval("Checked"))%>'/> <%--Text='<%# Eval("Amb_checked") %>'--%> 
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                               <asp:CheckBox ID="chkbox" runat="server" Checked='<%#Convert.ToBoolean(Eval("Checked"))%>' Enabled="false"/>
                                           </ItemTemplate>
                                           <ItemStyle Width="300px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Explanation" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <asp:Label ID="lblExplanation" runat="server" Text='<%# Eval("Reason") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>
                                    </Columns>
                                 
                                 
                                    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:GridView>
                            <br />
                            <%--<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                <ItemTemplate>
                                               <asp:Label ID="Label1" runat="server" Text='<%# Eval("amb_pic_name") %>'></asp:Label>
                                               <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("amb_pic_path") %>' Width="150" Height="130"  />
                                </ItemTemplate>
                                <ItemStyle Width="170px"></ItemStyle>
                            </asp:DataList>--%>
                            <asp:GridView ID="Grid_Image" runat="server" Width="800px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="Black" >
                                   <Columns>
                                       <asp:TemplateField ItemStyle-Width="150">
                                           <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("amb_pic_name") %>' Width="150"></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="300">
                                           <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("amb_pic_path") %>'  Width="300" Height="200"/>
                                           </ItemTemplate>
                                       <ItemStyle Width="300px"></ItemStyle>
                                       </asp:TemplateField>
                                    </Columns>
                                    </asp:GridView>
                         
                    </div>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Export to Excel" OnClick="Button1_Click" />
                    <br />
                </div>
             </div>
</asp:Content>
