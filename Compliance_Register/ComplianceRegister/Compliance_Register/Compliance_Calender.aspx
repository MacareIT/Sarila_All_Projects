<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compliance_Calender.aspx.cs" Inherits="Compliance_Register.Compliance_Calender" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="form-group row">
    <label class="col-lg-2 col-form-label">Department </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_Dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_Dept_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><asp:Label ID="lbl_id" runat="server" Text="" Visible="False"></asp:Label>
        </div>       
    </div>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Compliance Type </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_type" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" >
                <asp:ListItem>Internal</asp:ListItem>
                <asp:ListItem>Statutory</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
           
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Compliance Description</label>
        <div class="col-lg-10">
            <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control"></asp:TextBox>
        </div> 
    </div>
    
     <div class="form-group row">
        <label class="col-lg-2 col-form-label">Duration Type</label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_duration" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddl_duration_SelectedIndexChanged" >
                <asp:ListItem>Monthly</asp:ListItem>
                <asp:ListItem>Quarterly</asp:ListItem>
                <asp:ListItem>Half Yearly</asp:ListItem>
                <asp:ListItem>Annually</asp:ListItem>
            </asp:DropDownList>
        </div> 
    </div>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Due Date</label>
        <div class="col-lg-10">
            <asp:TextBox ID="txt_due" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_due" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
        </div>
    </div>

      <div class="form-group row">
        <label class="col-lg-2 col-form-label">Alert Date</label>
        <div class="col-lg-10">
            <asp:TextBox ID="txt_alert" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_alert" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-7 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#0a0a0a" GridLines="None" DataKeyNames="com_id,dept_id" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#0a0a0a"></AlternatingRowStyle>
                <Columns> 
                    <asp:BoundField DataField="com_id" HeaderText="ComID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="5%" visible="false"/>
                    <asp:BoundField DataField="dept_id" HeaderText="DeptID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="5%" visible="false"/>  
                    <asp:BoundField DataField="dept_name" HeaderText="Department" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" />  
                    <asp:BoundField DataField="com_type" HeaderText="Compliance Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="com_desc" HeaderText="Description" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="30%" /> 
                    <asp:BoundField DataField="duration_type" HeaderText="Duration Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" /> 
                    <asp:BoundField DataField="due_date" HeaderText="Due Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" /> 
                    <asp:BoundField DataField="alert_on" HeaderText="Alert Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="30%" /> 
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
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
