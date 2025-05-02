<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Booking_Confirmation.aspx.cs" Inherits="CRM_Application.Booking_Confirmation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
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

    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Booking Confirmation </h3>
        </div>
    </div>
    
    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                   
                     <asp:UpdatePanel ID="container" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox ID="Text_date" runat="server" CssClass="form-control" OnTextChanged="ChangeDate_Event" AutoPostBack="true"></asp:TextBox>  
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Text_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                               
                            </div>
                        </div>
                        <%--<div class="col-sm-6 col-xs-6">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Doctor</label>
                                <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dr_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                        </div>
                    </div>
                    </ContentTemplate>
                   </asp:UpdatePanel>
                   <div class="row">
                         <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                
                            </div>
                        </div>
                   
                         <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server"  id="Button1" onserverclick="View_click" style="width: 150px">VIEW</button>
                            </div>
                        </div>
                   </div>
                    <div class="form-group row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_bookingid" runat="server" Text='<%#Eval("booking_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TOKEN NUMBER" ItemStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_token" runat="server" Text='<%#Eval("token") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PATIENT NAME" ItemStyle-Width="500px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_patientname" runat="server" Text='<%#Eval("patient_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PHONE NUMBER" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_phone" runat="server" Text='<%#Eval("phone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="confirm" CommandArgument="<%# Container.DataItemIndex %>">CONFIRM</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="cancel" CommandArgument="<%# Container.DataItemIndex %>">CANCEL</asp:LinkButton>
                                            <%--<ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="LinkButton2"  
                                                CancelControlID="Button2" BackgroundCssClass="Background">  
                                            </ajaxToolkit:ModalPopupExtender>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="reschedule" CommandArgument="<%# Container.DataItemIndex %>">RESCHEDULE</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#507CD1" ForeColor="#ffffff" Font-Bold="True" />
                                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                            <%--<Triggers>
                             <asp:PostBackTrigger ControlID="lnkRemove" />
                           </Triggers>--%>
                        </div>
                    </div>

                </div>
            </div>
        </div>
         
         
    <!-- /.row -->

    <asp:LinkButton ID="Linkbtn" runat="server"></asp:LinkButton>  
<ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Linkbtn"  
    CancelControlID="Btn_Cancel" BackgroundCssClass="Background">  
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
                                <label>Patient Name</label>
                                <asp:TextBox ID="Text_patientname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-sm-12 col-xs-12">
                            <div class="form-group">
                                <label>Reason</label>
                                <asp:TextBox ID="Text_reason" runat="server" CssClass="form-control" TextMode="MultiLine" Height="150px"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            </div>
                        <div class="col-sm-4 col-xs-4">
                            <button id="Btn_Cancel" type="submit" class="btn btn-danger waves-effect waves-light m-r-10" runat="server" >CANCEL</button>        
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <button id="Btn_Submit" type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Cancelsubmit_click">SUBMIT</button>
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
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
