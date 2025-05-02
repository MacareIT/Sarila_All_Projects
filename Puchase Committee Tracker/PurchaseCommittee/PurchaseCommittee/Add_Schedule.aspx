<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Add_Schedule.aspx.cs" Inherits="PurchaseCommittee.Add_Schedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
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
            <asp:TemplateField HeaderText="SCHEDULE PURCHASE COMMITTEE" ItemStyle-Width="400px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
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

    <br />
    <br />
    <div id="div_hide" runat="server">
        <div class="form-group row">
            <label class="col-lg-1 col-form-label" for="val-email">DATE </label>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
            </div>
            <div class="col-lg-1"></div>
            <label class="col-lg-1 col-form-label" for="val-email">VENUE </label>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_venue" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-lg-8 ml-auto">
                <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click" />
            </div>
        </div>
    </div>

</asp:Content>
