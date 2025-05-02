<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Compliance_Register.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="form-group row">
        <label class="col-lg-2 col-form-label">Department </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>       
    </div>--%>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Type </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="Ddl_type" runat="server" CssClass="form-control" OnSelectedIndexChanged="Ddl_type_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>Internal</asp:ListItem>
                <asp:ListItem>Statutory</asp:ListItem>
            </asp:DropDownList>
        </div>       
    </div>
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Department </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_Dept" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_Dept_SelectedIndexChanged">
                
            </asp:DropDownList>
        </div>       
    </div>

     <div class="row">
        <div class="col-12">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#0a0a0a" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#0a0a0a"></AlternatingRowStyle>
                <Columns>  
                    <asp:BoundField DataField="com_desc" HeaderText="Compliance_incident" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="30%" />  
                    <asp:BoundField DataField="dept_name" HeaderText="Department" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" />  
                    <asp:BoundField DataField="com_type" HeaderText="Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="duration_type" HeaderText="Duration" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="entered_date" HeaderText="Entered Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="log_user" HeaderText="Entered By" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" />
                    <asp:BoundField DataField="cs_verify_date" HeaderText="CS Verify Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" />
                    
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"  HeaderText="File Download" HeaderStyle-ForeColor="White">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="lnkDownload" runat="server" ForeColor="Blue" Font-Underline="true" OnClick="DownloadFile" CommandArgument='<%#Eval("com_reg_id")%>'>Download</asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
        
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
    <div class="form-group row">
        <div class="col-lg-7 ml-auto">
            <asp:Button ID="Button1" runat="server" Text="Download Report" class="btn btn-primary" OnClick="Btn_submit_Click" />
        </div>
    </div>

</asp:Content>
