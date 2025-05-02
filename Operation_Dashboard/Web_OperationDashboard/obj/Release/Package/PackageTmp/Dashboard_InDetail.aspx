<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Dashboard_InDetail.aspx.cs" Inherits="Web_OperationDashboard.Dashboard_InDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="row">
            <div class="col-md-12">
                <div class="card card-body">

                     <div class="row">
                        
                        
                            <div class="form-group">
                               <asp:Label ID="Lbl_name" runat="server" Text="" ForeColor="#FF6600" Font-Size="Large" Font-Bold="True"></asp:Label>
                                
                            
                        </div>
                         </div>
            <div class="form-group row">
                <div class="col-md-12">
                        <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
                        <%--<asp:GridView ID="GridView2" runat="server"></asp:GridView>
                        <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                        <asp:GridView ID="GridView4" runat="server"></asp:GridView>--%>
                    
                        <%--<asp:GridView ID="GridView1" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" >
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
                        </asp:GridView>--%>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <br />
                    <br />
                </div>
            </div>
                        <div class="row">
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <asp:Button ID="Btn_back" runat="server" Text="BACK" BackColor="#008686" BorderStyle="None" ForeColor="White" Width="150" Height="30" Visible="False" PostBackUrl="~/Dashboard.aspx" />
                            </div>
                        </div>
                       
                        <%--<div class="col-md-5"></div>--%>
                       
                        <div class="form-group row">
                        </div>
                        </div>
        </div>
    </div>
</div>
    
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
