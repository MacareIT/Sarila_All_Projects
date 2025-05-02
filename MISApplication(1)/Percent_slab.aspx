<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="Percent_slab.aspx.cs" Inherits="MISApplication.Percent_slab" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">Percentage setting for IncentiveAmount</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
                <div class ="row">
                    <div class="col-sm-5">  Choose Branch
                         <asp:DropDownList ID="ddlbranch"  class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                   </div> 
                    <div class="col-sm-5">  
                   </div>  
                </div>
                <br />
                <div class ="row">
                      <div class="col-sm-2">Staff
                          <asp:TextBox ID="txtpercent1" class="form-control" runat="server"></asp:TextBox>
                       </div><br />
                    <div class="col-sm-1"><br />
                    <asp:RequiredFieldValidator ControlToValidate="txtpercent1" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator1" runat="server"></asp:RequiredFieldValidator>
                </div>
                     <div class="col-sm-2">Unit Head
                          <asp:TextBox ID="txtpercent2" class="form-control" runat="server"></asp:TextBox>
                        
                       </div><br />
                     <div class="col-sm-1"><br />
                    <asp:RequiredFieldValidator ControlToValidate="txtpercent2" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator2" runat="server"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-sm-2">Business Head
                          <asp:TextBox ID="txtpercent3" class="form-control" runat="server"></asp:TextBox>
                        
                       </div><br />
                     <div class="col-sm-1"><br />
                    <asp:RequiredFieldValidator ControlToValidate="txtpercent3" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator3" runat="server"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-sm-2">
                        <br />
                        <input type="button" class="btn btn-primary" id="Button1" onserverclick="addpercent" name="add" value="Add Percent" runat="server" />

                    </div>
                 </div><br />
                <asp:GridView ID="GridView1" runat="server" CellPadding="3" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:BoundField DataField="branchid" HeaderText="Branch" />
                        <asp:BoundField DataField="incentivehead" HeaderText="Incentive Head" >
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="targetcollection" HeaderText="TargetCollection" >
                        </asp:BoundField>
                        <asp:BoundField DataField="incentive_percent1" HeaderText="Upto 100%">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="incentive_percent2" HeaderText="100-150%" />
                        <asp:BoundField DataField="incentive_percent3" HeaderText="Above 150%" />
                        <asp:BoundField DataField="update_date" HeaderText="Date" >
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
