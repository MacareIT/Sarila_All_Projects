<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Compliance_Register.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
   <div class="row"><label id ="lbl_caption" class="col-lg-6 col-form-label-lg" style="color:red" runat="server">DashBoard For Compliance Due!!!</label></div>
    
    <%-- <div class="form-group row">
        <label class="col-lg-2 col-form-label">Compliance Type </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_type" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" >
                <asp:ListItem>Internal</asp:ListItem>
                <asp:ListItem>Statutory</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-12">
            <asp:Label ID="Lbl_status" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#0a0a0a" GridLines="None" DataKeyNames="com_id,dept_id">
                <AlternatingRowStyle BackColor="White" ForeColor="#0a0a0a"></AlternatingRowStyle>
                <Columns> 
<%--                    <asp:BoundField DataField="com_id" HeaderText="ComID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="5%" visible="false"/>
                    <asp:BoundField DataField="dept_id" HeaderText="DeptID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="5%" visible="false"/>--%>  
                    <asp:BoundField DataField="dept_name" HeaderText="Department" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" />  
                    <asp:BoundField DataField="com_type" HeaderText="Compliance Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="com_desc" HeaderText="Compliance incident" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="50%" /> 
                    <asp:BoundField DataField="duration_type" HeaderText="Duration Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="due_date" HeaderText="Due Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="7%"  /> 
                    <%--<asp:BoundField DataField="alert_on" HeaderText="Alert Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="30%" /> --%>
                   
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

