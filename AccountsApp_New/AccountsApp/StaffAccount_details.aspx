<%@ Page Title="" Language="C#" MasterPageFile="~/accounts.Master" AutoEventWireup="true" CodeBehind="StaffAccount_details.aspx.cs" Inherits="AccountsApp.StaffAccount_details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2 class="mt-4">STAFF ACCOUNT DETAILS</h2>
                <br />
                <div class="container-fluid">
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            Choose Branch
                         <asp:DropDownList ID="ddlbranch" AutoPostBack="true" class="form-control" runat="server" BackColor="White" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            Choose Department
                         <asp:DropDownList ID="ddlhead" AutoPostBack="true"  class="form-control" runat="server" BackColor="White" OnSelectedIndexChanged="ddlhead_SelectedIndexChanged">
                         </asp:DropDownList>
                        </div>
                        
                    </div>
                    <br />
                    <div class="container-fluid" style="background-color: #CEEFFF">
                    <div class="row">
                        <div class="col-md-4">
                            BANKNAME
                            <asp:TextBox ID="txtbankname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            IFSCCODE
                            <asp:TextBox ID="txtifsccode" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            ACCOUNTNO
                            <asp:TextBox ID="txtaccountno" onkeypress="return validatenumbersonly(this)" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            BRANCH
                            <asp:TextBox ID="txtbranch" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <br />
                            <input type="button" class="btn btn-secondary" id="btnadd" onserverclick="updatedetails" name="add" value="Update Account" runat="server" width="500" />
                        </div>
                    </div>
                        <br />
                    </div>
                    <br />

                    <div class="row">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="3" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" DataKeyNames="id,empcode,branchid" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="empcode" HeaderText="STAFF CODE" />
                                <asp:BoundField HeaderText="STAFF NAME" DataField="empname" />
                                <asp:BoundField DataField="bankname" HeaderText="BANKNAME">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ifsccode" HeaderText="IFSCCODE"></asp:BoundField>
                                <asp:BoundField DataField="accountno" HeaderText="ACCOUNTNO">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="BRANCH" DataField="branch" />
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
                    <br />

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
     <script>

         function validatenumbersonly(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
            return true;
            else {
                alert('Please Enter Numeric values.');
            return false;
            }
           }  
     </script>
</asp:Content>
