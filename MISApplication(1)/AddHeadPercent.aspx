<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AddHeadPercent.aspx.cs" Inherits="MISApplication.AddHeadPercent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">Assign Head IncentivePercent</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double;background-color: #D7EBFF;">
                <div class ="row">
                    <div class="col-sm-4">  Choose Branch
                         <asp:DropDownList ID="ddlbranch"   class="form-control" runat="server" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                   </div> 
                    <div class="col-sm-4">  Choose Type
                         <asp:DropDownList ID="ddltype" class="form-control" runat="server" BackColor="White">
                             <asp:ListItem Value="0">Select</asp:ListItem>
                             <asp:ListItem Value="businesshead">Business Head</asp:ListItem>
                             <asp:ListItem Value="unithead">Unit Head</asp:ListItem>
                             <asp:ListItem Value="purchasehead">Purchase Head</asp:ListItem>
                             <asp:ListItem Value="microlabincharge">Microlab Incharge</asp:ListItem>
                             <asp:ListItem Value="shophead">ShopHead</asp:ListItem>
                             <asp:ListItem Value="opticalshophead">Optical ShopHead</asp:ListItem>
                             <asp:ListItem Value="pharmacyshophead">Pharmacy ShopHead</asp:ListItem>
                             <asp:ListItem Value="staff">Staff</asp:ListItem>
                        </asp:DropDownList>
                   </div>  
                      <div class="col-sm-4">
                          Choose date
                          <asp:TextBox ID="txtdate" class="form-control" runat="server"></asp:TextBox>
                         <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtdate"
                            PopupButtonID="txtdate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                       </div>
                </div>
                <br />
                 <div class ="row">
                    
                     <div class="col-sm-5">
                        Incentive Percent
                          <asp:TextBox ID="txtpercent" class="form-control" runat="server"></asp:TextBox>
                       </div><br />
                      <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtpercent" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator4" runat="server"></asp:RequiredFieldValidator>
                          </div>
                     <div class="col-sm-5">
                         <br />
                    <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="Button1" name="add" onserverclick="addpercent" value="Save Percent" runat="server" />
                         </div>
                 </div> 
                <br />
                <asp:GridView ID="GridView1" runat="server" CellPadding="3" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="branchid" HeaderText="BRANCH" />
                        <asp:BoundField DataField="incentive_headtype" HeaderText="TYPE" >
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="incentive_percent" HeaderText="PERCENT AMOUNT" >
                        </asp:BoundField>
                        <asp:BoundField DataField="entereddate" HeaderText="LAST UPDATED">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>                        
                        <asp:CommandField ShowSelectButton="True" />
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
