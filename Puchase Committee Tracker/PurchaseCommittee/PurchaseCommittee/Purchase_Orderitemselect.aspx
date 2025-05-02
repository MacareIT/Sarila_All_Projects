<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Purchase_Orderitemselect.aspx.cs" Inherits="PurchaseCommittee.Purchase_Orderitemselect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" >
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-Width="10px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_quotationid" runat="server" Text='<%#Eval("quotation_id") %>' Visible="false"></asp:Label>
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
                    <asp:Label ID="lbl_vendorname" runat="server" Text='<%#Eval("vendor_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AMOUNT" ItemStyle-Width="100px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_amt" runat="server" Text='<%#Eval("negotiated_amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" ItemStyle-Width="400px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="generate_po" CommandArgument="<%# Container.DataItemIndex %>">Purchase Order</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  ItemStyle-Width="1px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="50px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
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
