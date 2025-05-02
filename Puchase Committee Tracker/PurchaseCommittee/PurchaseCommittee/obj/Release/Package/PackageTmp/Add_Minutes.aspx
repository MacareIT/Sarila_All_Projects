<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Add_Minutes.aspx.cs" Inherits="PurchaseCommittee.Add_Minutes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-Width="10px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87"  HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_quotationid" runat="server" Text='<%#Eval("quotation_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField><%--ControlStyle-Height="25px"--%>
            <asp:TemplateField HeaderText="VENDOR NAME" ItemStyle-Width="400px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87"  HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_vendorname" runat="server" Text='<%#Eval("vendor_name") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AMOUNT" ItemStyle-Width="250px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87"  HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_amount" runat="server" Text='<%#Eval("amount") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="QUOTATION" ItemStyle-Width="250px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#  Eval("quotation")  %>'  height="120px" Width="200px" />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="QUOTATION" ItemStyle-Width="300px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="quotation_view" CommandArgument="<%# Container.DataItemIndex %>">View Quotation</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NEGOTIATED AMOUNT" ItemStyle-Width="300px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:TextBox ID="txt_negotiatedamt" runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="APPROVE" ItemStyle-Width="50px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
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

    <br />
    <br />
    <div id="appear" runat="server">
    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Status </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_status" runat="server" CssClass="form-control">
                <asp:ListItem>---Select---</asp:ListItem>
                <asp:ListItem>Approved</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
                <asp:ListItem Value="Requested">Reschedule</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Participants </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_participants" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
        </div>
    </div>
    
    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Decision </label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_decision" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click" />
        </div>
    </div>
    </div>

    <asp:Label ID="lbl_quotationid" runat="server" Text="Label"></asp:Label>

</asp:Content>
