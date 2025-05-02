<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Compliance_Register.Registration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="form-group row">
        <label class="col-lg-2 col-form-label">Department </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Ddl_dept_SelectedIndexChanged"></asp:DropDownList>
        </div>       
    </div>

     <div class="form-group row">
        <label class="col-lg-2 col-form-label">Compliance Type </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                <asp:ListItem>Internal</asp:ListItem>
                <asp:ListItem>Statutory</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Compliance Incident </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddl_com_incident" runat="server" CssClass="form-control" DataValueField="com_id" DataTextField="com_desc">
            </asp:DropDownList>
        </div>
    </div>

    <%--<div class="form-group row">
        <label class="col-lg-2 col-form-label">Type </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="Ddl_type" runat="server" CssClass="form-control">
                <asp:ListItem>---Select---</asp:ListItem>
                <asp:ListItem>Monthly</asp:ListItem>
                <asp:ListItem>Quarterly</asp:ListItem>
                <asp:ListItem>Annually</asp:ListItem>
            </asp:DropDownList>
        </div>       
    </div>--%>
           
    <div class="form-group row">
        <label class="col-lg-2 col-form-label" id="lbl_com_name" runat="server"><%--Internal / Custodial Compliance Certificate--%> </label>
        <div class="col-lg-10">
            <asp:FileUpload runat="server" id="file_compliance" CssClass="form-control"></asp:FileUpload>
        </div>       
    </div>

   <%-- <div class="form-group row">
        <label class="col-lg-2 col-form-label">Statutory Compliance Certificate </label>
        <div class="col-lg-10">
            <asp:FileUpload runat="server" id="file_statutary" CssClass="form-control"></asp:FileUpload>
        </div>       
    </div>--%>

    <div class="form-group row">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
           
    <div class="form-group row">
        <div class="col-lg-7 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#0a0a0a" GridLines="None" DataKeyNames="Com_Reg_Id,Com_Id"   OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#0a0a0a"></AlternatingRowStyle>
                <Columns> 
                    <asp:BoundField DataField="com_desc" HeaderText="Compliance incident" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="55%" />
                    <asp:BoundField DataField="due_date" HeaderText="Due Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" />  
                    <asp:BoundField DataField="Entered_date" HeaderText="Entered Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="Entered_by" HeaderText="Entered By" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"  HeaderText="File Download" HeaderStyle-ForeColor="White">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="lnkDownload" runat="server" ForeColor="Blue" Font-Underline="true" OnClick="DownloadFile" CommandArgument='<%#Eval("com_reg_id")%>'>Download</asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                    <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Button" />--%>
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
