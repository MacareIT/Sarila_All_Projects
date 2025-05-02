<%@ Page Title="" Language="C#" MasterPageFile="~/MIS.Master" AutoEventWireup="true" CodeBehind="DecreaseInSale.aspx.cs" Inherits="MISApplication.DecreaseInSale" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <h2 class="mt-4">Decrease in Sales Value</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
                <br />
                <div class="row">
                    <div class="col-sm-5">
                        Choose Pharmacy<asp:DropDownList ID="ddlpharmacy" class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                        <asp:DropDownList ID="ddlbranch" runat="server" BackColor="White" class="form-control" Visible="False">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-6">
                        <br />
                        <input type="button" class="btn btn-primary" id="Button1" name="add" onserverclick="showbillvalue" value="BillValue" runat="server" />
                        &nbsp;&nbsp;<input type="button" class="btn btn-primary" id="btnadd" name="add" onserverclick="showreport" value="LossOf Sale" runat="server" />


                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        From Date<asp:TextBox ID="txtfrmdt" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdt"
                            PopupButtonID="ImageButton1"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-1">
                        <br />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/_images/calender.png" Width="27px" />
                    </div>
                    <div class="col-sm-4">
                        To date
                        <asp:TextBox ID="txttodate" class="form-control" runat="server"></asp:TextBox>
                        <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="ImageButton2"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-1">
                        <br />
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/_images/calender.png" Width="27px" />
                    </div>
                    <br />
                    <div class="col-sm-2">
                        <br />
                        &nbsp;
                       
                    </div>
                </div>
               
                <br />
            </div>
            <br />
             <div class="row">
                 <div class="col-sm-6">
                                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%">
                                          <AlternatingRowStyle BackColor="#DCDCDC" />
                                          <Columns>
                                              <asp:BoundField DataField="deptname" HeaderText="Department">
                                              <HeaderStyle HorizontalAlign="Left" />
                                              </asp:BoundField>
                                              <asp:BoundField DataField="billvalue" HeaderText="BillValue">
                                              <HeaderStyle HorizontalAlign="Left" />
                                              </asp:BoundField>
                                          </Columns>
                                          <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                          <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                          <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                          <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                          <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                          <SortedDescendingHeaderStyle BackColor="#000065" />
                                      </asp:GridView>
                                      </div>
                 <div class="col-sm-6">                    
                     <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" GridLines="Vertical">
                         <AlternatingRowStyle BackColor="#DCDCDC" />
                         <Columns>
                             <asp:BoundField DataField="vcount" HeaderText="Visit Count">
                             <HeaderStyle HorizontalAlign="Center" />
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="noncount" HeaderText="NonVisit">
                             <HeaderStyle HorizontalAlign="Center" />
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="totpat" HeaderText="Total Visit">
                             <HeaderStyle HorizontalAlign="Center" />
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField HeaderText="Average" />
                             <asp:BoundField HeaderText="Loss of sale" />
                         </Columns>
                         <EditRowStyle HorizontalAlign="Left" Width="300px" />
                         <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                         <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                         <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#0000A9" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#000065" />
                     </asp:GridView>
                     </div>
                                  
                 </div>
             <div class="row">
                 <div class="col-sm-12">
                     <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>