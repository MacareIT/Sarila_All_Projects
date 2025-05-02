<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="View_SOP_KRA.aspx.cs" Inherits="SOP_and_KRA.View_SOP_KRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
  <div class="col-xl-12">
    <!-- Basic Examples -->
    <div class="card card-default">
      <div class="card-header">
        <h2>ADD NEW SOP AND KRA</h2>
      </div>
      <div class="card-body">
        <div class="collapse" id="collapse-basic-input">
          <pre class="language-html mb-4">
          </pre>
        </div>
          <div class="form-group">
            <label for="exampleFormControlInput2">Department</label>
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
          </div>

          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="CRF ID" ItemStyle-Width="80px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_sopkraid" runat="server" Text='<%#Eval("sop_kra_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CRF NAME" ItemStyle-Width="380px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_dept" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CRF STATUS" ItemStyle-Width="380px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:Label ID="lbl_designation" runat="server" Text='<%#Eval("designation") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="sop_view" CommandArgument="<%# Container.DataItemIndex %>">View SOP</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" ItemStyle-Width="100px" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#542a87" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="kra_view" CommandArgument="<%# Container.DataItemIndex %>">View KRA</asp:LinkButton>
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

          <%--<div class="form-footer mt-6">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-pill" Text="SUBMIT" OnClick="Button1_Click" />
          </div>--%>

      </div>
    </div>
      </div>


  </div>
</asp:Content>
