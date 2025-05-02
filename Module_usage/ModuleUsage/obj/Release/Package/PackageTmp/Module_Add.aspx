<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Module_Add.aspx.cs" Inherits="ModuleUsage.Module_Add" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Add Module</h3>
        </div>
    </div>--%>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <h2 class="mt-4">ADD MODULE</h2>
    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" DataValueField="dept_id" DataTextField="dept_name" CssClass="form-control"  AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>ModuleName</label>
                                <asp:TextBox ID="txtModule" runat="server" CssClass="form-control"  AutoPostBack="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Path-Url</label>
                                <asp:TextBox ID="txtPath" runat="server" CssClass="form-control"  AutoPostBack="true" ></asp:TextBox>
                            </div>
                        </div>
                         
                        <div class="col-md-5"></div>
                        <div class="col-sm-4 col-xs-4">
                            <asp:Button ID="btnSubmit" runat="server" type="submit" Text="SUBMIT" OnClick="btnSubmit_Click" BackColor="#008686" BorderStyle="None" ForeColor="White" Width="100" Height="30" />
                            <%--<button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" >Submit</button>--%>
                        </div>

                        <div class="form-group row">
                        </div>
                    </div>
                <%--</div>--%>
            <%--</div>--%>
            <%--<div class="card card-body">--%>
                    <br /><br />
            <div class="form-group row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="Module" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Department" ItemStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_deptName" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="10px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module" ItemStyle-Width="500px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Module") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="500px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Path" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_path" runat="server" Text='<%#Eval("Path") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="200px"></ItemStyle>
                            </asp:TemplateField>
                            
                                                     
                            <asp:TemplateField HeaderText="" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >Remove</asp:LinkButton>
                                </ItemTemplate>

<ItemStyle Width="250px"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                        <FooterStyle BackColor="#008686" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <HeaderStyle BackColor="#008686" ForeColor="#ffffff" Font-Bold="True" />
                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </div>
            </div>
            
        </div>
    </div>
</div>
    <!-- /.row -->
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
