<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Agreement_Renewal.aspx.cs" Inherits="Web_OperationDashboard.Agreement_Renewal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="mt-4">Agreement Renewal</h2>
    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row">
                        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Agreement Type</label>
                                <asp:TextBox ID="txt_Agrmnt_type" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txt_Agrmnt_type"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Agreement Party</label>
                                <asp:TextBox ID="txt_Agrmnt_party" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txt_Agrmnt_party"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label>Date of Execution</label>
                                <asp:TextBox ID="txt_dt_Exectn" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txt_dt_Exectn"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_dt_Exectn" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                         <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label>Next Renewal</label>
                                <asp:TextBox ID="txt_renewal" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txt_renewal"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_renewal" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                         <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label>First Reminder</label>
                                <asp:TextBox ID="txt_reminder1" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txt_reminder1"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_reminder1" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label>Second Reminder</label>
                                <asp:TextBox ID="txt_reminder2" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txt_reminder2"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_reminder2" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label>Third Reminder</label>
                                <asp:TextBox ID="txt_reminder3" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txt_reminder3"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_reminder3" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <div class="form-group">
                                <label></label>
                                <asp:Button ID="btnSubmit" runat="server" type="submit" Text="SUBMIT" OnClick="btnSubmit_Click" BackColor="#008686" BorderStyle="None" ForeColor="White" Width="100" Height="30" />
                            </div>
                        </div>    
                    </div>
                <%--</div>--%>
            <%--</div>--%>
            <%--<div class="card card-body">--%>
                    <br /><br />
            <div class="form-group row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="agrmnt_id" Font-Size="Small" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                             <asp:BoundField DataField="agrmnt_id" HeaderText="Argmnt ID" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" Visible="false" ItemStyle-Width="2%" />  
                                <asp:BoundField DataField="agrmnt_type" HeaderText="Agreement Type" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" />  
                                <asp:BoundField DataField="agrmnt_party" HeaderText="Agreement Party" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="20%" /> 
                                <asp:BoundField DataField="Date_of_execution" HeaderText="Date of Execution" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" /> 
                                <asp:BoundField DataField="next_renewal" HeaderText="Next Renewal" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="12%" />  
                                <asp:BoundField DataField="first_alert" HeaderText="First Reminder" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="12%" /> 
                                <asp:BoundField DataField="second_alert" HeaderText="Second Alert" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="12%" />  
                                <asp:BoundField DataField="third_alert" HeaderText="Third Alert" HeaderStyle-ForeColor="White" ItemStyle-ForeColor="Black" ItemStyle-Width="12%" />    
                                <asp:CommandField ShowSelectButton="True"/>
                                <%--<asp:CommandField ShowDeleteButton="True" />--%>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                        <FooterStyle BackColor="#008686" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <HeaderStyle BackColor="#008686" ForeColor="#ffffff" Font-Bold="True" />
                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </div>
            </div>
            
        </div>
    </div>
</div>
</asp:Content>
