<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compl_Dept_Registration.aspx.cs" Inherits="Compliance_Register.Compl_Dept_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="form-group row">
    <label class="col-lg-2 col-form-label">Department </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_Dept" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>       
    </div>
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Dept.Head </label>
        <div class="col-lg-4">
            <asp:textbox runat="server" id="txtAutoComplete" CssClass="form-control" OnTextChanged="txtAutoComplete_TextChanged"></asp:textbox>
        </div>
        <div class="col-lg-2">
             <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <div class="col-lg-4">
            <asp:DropDownList ID="ddl_empcode" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_empcode_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
               
    <div class="form-group row">
        <div class="col-lg-7 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#0a0a0a" GridLines="None" DataKeyNames="Dept_Id"  OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#0a0a0a"></AlternatingRowStyle>
                <Columns> 
                    <asp:BoundField DataField="dept_id" HeaderText="Dept ID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" Visible="false" ItemStyle-Width="5%" />  
                    <asp:BoundField DataField="dept_name" HeaderText="Department" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="35%" />  
                    <asp:BoundField DataField="dept_head" HeaderText="Dept_Head" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="25%" /> 
                    <asp:BoundField DataField="log_user" HeaderText="name" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="30%" /> 
                    
                    <asp:CommandField ShowSelectButton="True" />
                  <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="lbl_select" runat="server" ForeColor="Green" Font-Underline="true" CommandName="select" CommandArgument='<%#Eval("Dept_id")%>'>Select</asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>--%>
                </Columns>
                <EditRowStyle BackColor="#999999"></EditRowStyle>
                <FooterStyle BackColor="#104c59" Font-Bold="True" ForeColor="White"></FooterStyle>
                <HeaderStyle BackColor="#104c59" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" BackColor="White" ForeColor="White"></PagerStyle>
                <RowStyle BackColor="#F7F6F3" ForeColor="#0a0a0a"></RowStyle>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#0a0a0a"></SelectedRowStyle>
                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
            </asp:GridView>    
        </div>
    </div>

</asp:Content>
