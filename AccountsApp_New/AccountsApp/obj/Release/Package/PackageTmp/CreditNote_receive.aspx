<%@ Page Title="" Language="C#" MasterPageFile="~/accounts.Master" AutoEventWireup="true" CodeBehind="CreditNote_receive.aspx.cs" Inherits="AccountsApp.CreditNote_receive" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
     <div class="container-fluid">
        <h2 class="mt-4">CREDIT NOTE RECEIVE</h2>
         <div class="container-fluid">
            <br />
              <div class="row">
                <div class="col-md-4">
                    From<asp:TextBox ID="txtfrmdate" CssClass="form-control" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender
                            ID="ceDOB"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txtfrmdate"
                            PopupButtonID="txtfrmdate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                </div>
                <div class="col-md-4">
                     To<asp:TextBox ID="txttodate" CssClass="form-control" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="True"
                            TargetControlID="txttodate"
                            PopupButtonID="txttodate"
                            Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                </div>
                  <div class="col-sm-4">   
                    <br />
                    <input type="button" class="btn btn-secondary" id="btnadd"  onserverclick="viewreport"  name="add" value="View Report"  runat="server" width="500" />

                </div>
                </div>
             <br />
              <div class="row" style="overflow-x:scroll">
               <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false"   OnRowCancelingEdit="Gridview1_RowCancelingEdit" OnRowEditing="Gridview1_RowEditing" OnRowUpdating="Gridview1_RowUpdating" >
                                        <Columns>
                                       <asp:TemplateField HeaderText="PR_NO" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" >
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Width="120px" Height="30px" Text='<%#Eval("pr_no") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="CR_NO" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" >
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Width="120px" Height="30px" Text='<%#Eval("cr_no") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="VENDOR CR_NO" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" >
                                            <ItemTemplate>
                                                <asp:Label ID="Label2_" runat="server" Width="120px" Height="30px" Text='<%#Eval("vendor_credit_note") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="BRANCH" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" >
                                            <ItemTemplate>
                                                 <asp:Label ID="Label3" runat="server" Width="150px" Height="30px" Text='<%#Eval("Branch_name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SUPPLIER" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366"  >
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Width="120px" Height="30px" Text='<%#Eval("supplier_name") %>'></asp:Label>
                                             </ItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PR VALUE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" >
                                            <ItemTemplate>
                                                 <asp:Label ID="Label5" runat="server" Width="100px" Height="30px" Text='<%#Eval("Pr_value") %>'></asp:Label>
                                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox5" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>--%>
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                            
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TRANSFERED" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" >
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" Enabled="False" Checked='<%#(decimal)Eval("transfered") == 0 ?false : true %>'/>
                                             </ItemTemplate>
                                           
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="RECEIVED" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" >
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" Checked='<%#(decimal)Eval("received") == 0 ?false : true %>'/>
                                             </ItemTemplate>
                                             <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%#(decimal)Eval("received") == 0 ?false : true %>'/>
                                             </EditItemTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" > 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 
                                        </Columns>
                                    </asp:gridview>
                </div>
        </div>
         </div>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
