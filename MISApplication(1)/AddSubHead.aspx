<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AddSubHead.aspx.cs" Inherits="MISApplication.AddSubHead" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">Add IncentiveSubHead</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
               
                <div class ="row">
                    <div class="col-sm-5"> 
                         Choose Incentive Head
                         <asp:DropDownList ID="ddl_incentivehead" class="form-control" runat="server" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="ddl_incentivehead_SelectedIndexChanged"></asp:DropDownList>
                   </div>                    
                    <div class="col-sm-5">SubHead Name 
                <asp:DropDownList ID="ddl_subhead" runat="server" BackColor="White" class="form-control">
                </asp:DropDownList>
                        </div>                     
                </div>
               
                <br />
                 <div class ="row">
                    <div class="col-sm-5">  
                   </div> 
                    <div class="col-sm-5">  
                         <input type="button" class="btn btn-primary" id="Button2" onserverclick="addincentivesubhead" name="add"  value="Add SubHead" runat="server" />
                   </div>  
                </div>
                <br />
              <asp:GridView ID="GridView1" runat="server" CellPadding="3" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:BoundField DataField="subhead_name" HeaderText="Sub Head" />
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
