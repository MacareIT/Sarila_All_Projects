<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Doctor_Registration.aspx.cs" Inherits="CRM_Application.Doctor_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Doctor Booking</h3>
        </div>
    </div>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                   
                    <div class="row">
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Doctor</label>
                                <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                       
                        <div class="col-md-5"></div>
                        <div class="col-sm-4 col-xs-4">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Submit_click" >Submit</button>
                        </div>
                        <div class="form-group row">
                        </div>
                    </div>
                     
                    
                     
                   
                <%--</div>--%>
            <%--</div>--%>
            <%--<div class="card card-body">--%>
                    <br />
                    <br />
            <div class="form-group row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_rowdeleting" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_drid" runat="server" Text='<%#Eval("dr_id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="500px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_drname" runat="server" Text='<%#Eval("dr_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dept" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" CommandArgument="<%# Container.DataItemIndex %>">DELETE</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="#ffffff" Font-Bold="True" />
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

</asp:Content>
