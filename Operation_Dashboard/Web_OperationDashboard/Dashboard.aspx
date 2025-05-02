<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Web_OperationDashboard.Dashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
   
    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row"> 
                        <div class="form-group">
                               <asp:Label ID="lbl_agr_alert" runat="server" Text="" ForeColor="#FF6600" Font-Size="Large" Font-Bold="True"></asp:Label>  
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <asp:GridView ID="GridView_agr" runat="server">

                            </asp:GridView>
                        </div>
                    </div>
                    <br /><br />
                    <div class="row">
                        
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>From Date</label>
                                <asp:TextBox ID="txtfrmdate" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdate"
                            PopupButtonID="txtfrmdate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>To Date</label>
                                <asp:TextBox ID="txttodate" runat="server" CssClass="form-control"  AutoPostBack="true" ></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="txttodate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender> 
                            </div>
                        </div>
                         
                        <%--<div class="col-md-5"></div>--%>
                        <div class="col-sm-4 col-xs-4">
                             <div class="form-group">
                               <div style="height:35px"></div>
                                 <div><asp:Button ID="btnSubmit" runat="server" type="submit" Text="SUBMIT" OnClick="btnSubmit_Click" BackColor="#008686" BorderStyle="None" ForeColor="White" Width="100" Height="30" /></div>
                            
                            <%--<button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" >Submit</button>--%>
                        </div>
                        </div>
                        <div class="form-group row">
                        </div>
                    </div>
                <%--</div>--%>
            <%--</div>--%>
            <%--<div class="card card-body">--%>
                    <br /><br />
                     <div class="row">
                        
                        
                            <div class="form-group">
                               <asp:Label ID="Lbl_name" runat="server" Text="" ForeColor="#FF6600" Font-Size="Large" Font-Bold="True"></asp:Label>
                                
                            
                        </div>
                         </div>
            <div class="form-group row">
                <div class="col-md-12">
                    <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
                  <%--  <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                    <asp:GridView ID="GridView4" runat="server"></asp:GridView>--%>
                    
                     <label id="l1" runat="server">Cash Position</label>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SystemCash" ItemStyle-Width="150px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Scash" runat="server" Text='<%#Eval("SystemCash") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PhysicalCash" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Pcash" runat="server" Text='<%#Eval("PhysicalCash") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Difference" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Diff" runat="server" Text='<%#Eval("Difference") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                                                     
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >View</asp:LinkButton>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
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
                    <br />
                    <br />
              
                    <label id="l2" runat="server">Bill Cancellation</label>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Count" ItemStyle-Width="150px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_BCount" runat="server" Text='<%#Eval("Bill_Cancellation_Count") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_BAmt" runat="server" Text='<%#Eval("Bill_Cancellation_Amount") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            
                                                     
                           
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
                    <br />
                    <br />
              
                    <label id="l3" runat="server">Sales Return</label>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Count" ItemStyle-Width="150px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SCount" runat="server" Text='<%#Eval("Sales_Return_Count") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SAmount" runat="server" Text='<%#Eval("Sales_Return_Amount") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            
                                                     
                            
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
                    <br />
                    <br />
              
                    <label id="l4" runat="server">Manual Consumption</label>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Value" ItemStyle-Width="300px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_MConsumption" runat="server" Text='<%#Eval("Manual_Consumption") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Amount" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_path" runat="server" Text='<%#Eval("Sales_Return_Amount") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>--%>
                            
                                                     
                            
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
                    <br />
                    <br />
    
                    <label id="l5" runat="server">Debit Note Create</label>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName"  >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Debit Note" ItemStyle-Width="150px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dbt" runat="server" Text='<%#Eval("Debit_Note Created") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dbtAmt" runat="server" Text='<%#Eval("Debit_Note Amount") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            
                                                     
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" >View</asp:LinkButton>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
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
                    <br />
                    <br />
      
                    <label id="l6" runat="server">Credit Note Adjust</label>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_deptName" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit Note" ItemStyle-Width="300px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Credit_Note Adjust") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_crtAmt" runat="server" Text='<%#Eval("Credit_Note Amount") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                           
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
                    <br />
                    <br />

                     <label id="l7" runat="server">Daily Inventory Tally</label>
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="BranchName" >
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_deptName" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CheckedBy" ItemStyle-Width="300px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("CheckedBy") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Items" ItemStyle-Width="300px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Modul" runat="server" Text='<%#Eval("Items") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click" >View</asp:LinkButton>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
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

                    <br />
                    <br />
    
                    <label id="Label1" runat="server">Optical Stock Entry</label>
                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="Name">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="BranchName" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" ItemStyle-Width="150px" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dbt" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SystemStock" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dbtAmt" runat="server" Text='<%#Eval("Stock") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PhysicalStock" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dbtAmt" runat="server" Text='<%#Eval("PStock") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Difference" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dbtAmt" runat="server" Text='<%#Eval("Diff") %>'></asp:Label>
                                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField>
                                                     
                         <%--   <asp:TemplateField HeaderText="" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" >View</asp:LinkButton>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>--%>
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
                        <div class="row">
                        
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <asp:Button ID="Btn_viewrpt" runat="server" Text="View Report" BackColor="#008686" BorderStyle="None" ForeColor="White" Width="150" Height="30" OnClick="Btn_viewrpt_Click"/>
                            </div>
                        </div>
                       
                        <%--<div class="col-md-5"></div>--%>
                       
                        <div class="form-group row">
                        </div>
                    </div>
        </div>
    </div>
</div>
    <!-- /.row -->
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
