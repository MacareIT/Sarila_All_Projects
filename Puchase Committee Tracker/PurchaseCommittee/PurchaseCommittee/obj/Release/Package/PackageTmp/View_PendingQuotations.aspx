<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="View_PendingQuotations.aspx.cs" Inherits="PurchaseCommittee.View_PendingQuotations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-Width="10px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_itemid" runat="server" Text='<%#Eval("item_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-Width="400px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_dept" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PRODUCT NAME" ItemStyle-Width="400px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_product" runat="server" Text='<%#Eval("product_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PURPOSE" ItemStyle-Width="400px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_purpose" runat="server" Text='<%#Eval("purpose") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QUOTATION" ItemStyle-Width="150px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="quotation_view" CommandArgument="<%# Container.DataItemIndex %>">View Quotations</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" ItemStyle-Width="150px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="add_quotation" CommandArgument="<%# Container.DataItemIndex %>">New Quotation</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  ItemStyle-Width="0%" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="50px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#7b43bf" ForeColor="#ffffff" Font-Bold="True" />
        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
    </asp:GridView>

</asp:Content>
