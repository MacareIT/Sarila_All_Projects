<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="Compliance_Register.Verify" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">  
        .Background  
        {  
            background-color: Black;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  
        }  
        .Popup  
        {  
            background-color: #FFFFFF;  
            border-width: 3px;  
            border-style: solid;  
            border-color: black;  
            padding-top: 10px;  
            padding-left: 10px;  
            /*width: 400px;  
            height: 350px;*/  
        }  
        .lbl  
        {  
            font-size:16px;  
            font-style:italic;  
            font-weight:bold;  
        }  
    </style>
     
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Type </label>
        <div class="col-lg-10">
            <asp:DropDownList ID="Ddl_type" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Ddl_type_SelectedIndexChanged">

                <asp:ListItem>Internal</asp:ListItem>
                <asp:ListItem>Statutory</asp:ListItem>
            </asp:DropDownList>
        </div>      
    </div>

  <%--  <div class="form-group row">
        <div class="col-lg-7 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="View" class="btn btn-primary" OnClick="Btn_submit_Click"/>
        </div>
    </div>--%>
           
    <div class="row">
        <div class="col-12">
            <asp:Label ID="Lbl_status" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#0a0a0a" GridLines="None" OnRowCommand="GridView1_RowCommand" DataKeyNames="Com_Reg_Id,Com_Id,due_date,alert_on,duration_type">
                <AlternatingRowStyle BackColor="White" ForeColor="#0a0a0a"></AlternatingRowStyle>
                <Columns> 
                    <asp:BoundField DataField="com_desc" HeaderText="Compliance_incident" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="30%" />  
                    <asp:BoundField DataField="dept_id" visible="false" HeaderText="Dept ID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="5%" />  
                    <asp:BoundField DataField="dept_name" HeaderText="Department" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" />  
                    <asp:BoundField DataField="com_type" HeaderText="Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="duration_type" HeaderText="Duration" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="entered_date" HeaderText="Entered Date" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" /> 
                    <asp:BoundField DataField="entered_by" HeaderText="Entered By" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" />
               
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"  HeaderText="File Download" HeaderStyle-ForeColor="White">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="lnkDownload" runat="server" ForeColor="Blue" Font-Underline="true" OnClick="DownloadFile" CommandArgument='<%#Eval("com_reg_id")%>'>Download</asp:LinkButton>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
              
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">  
                        <ItemTemplate>  
                            <asp:LinkButton ID="lnkVerify" runat="server" ForeColor="Green" Font-Underline="true" CommandName="verify" CommandArgument="<%# Container.DataItemIndex %>">Verify</asp:LinkButton>  
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
    <asp:LinkButton ID="Linkbtn" runat="server"></asp:LinkButton>  
    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Linkbtn"  
    BackgroundCssClass="Background">  
</ajaxToolkit:ModalPopupExtender>  
<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">  
    <%--<iframe style=" width: 350px; height: 300px;" id="irm1" src="Cancel.aspx" runat="server"></iframe>--%>  
    <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>

    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                        <div class="col-sm-12 col-xs-12">
                            <div class="form-group">
                                <label>Compliance Incident</label>
                                <asp:TextBox ID="Txt_comp" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Previous Due Date</label>
                                <asp:TextBox ID="txt_Predue" runat="server" CssClass="form-control" ></asp:TextBox> 
                            </div>
                        </div>
                         <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>New Due Date</label>
                                <asp:TextBox ID="txt_NewDue" runat="server" CssClass="form-control" ></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Previous Alert Date</label>
                                <asp:TextBox ID="txt_PreAlrt" runat="server" CssClass="form-control" ></asp:TextBox> 
                            </div>
                        </div>
                         <div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>New Alert Date</label>
                                <asp:TextBox ID="txt_NewAlrt" runat="server" CssClass="form-control" ></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            </div>
                        <%--<div class="col-sm-4 col-xs-4">
                            <button id="Btn_Cancel" type="submit" class="btn btn-danger waves-effect waves-light m-r-10" runat="server" >CANCEL</button>        
                        </div>--%>
                        <div class="col-sm-4 col-xs-4">
                            <button id="Button1" type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Cancelsubmit_click">SUBMIT</button>
                        </div>

                        <div class="form-group row">
                    </div>
                    </div>
                </div>
            </div>
        </div>
    <!-- /.row -->

   <%--<br/>  
    <asp:Button ID="Button2" runat="server" Text="Close" />  --%>
</asp:Panel>
</asp:Content>
