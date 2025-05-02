<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AddPharmacyMargin.aspx.cs" Inherits="MISApplication.AddPharmacyMargin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="mt-4">Add Pharmacy Margin</h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double;background-color: #D7EBFF;">
                <div class ="row">
                    <div class="col-sm-4">  Choose Branch
                         <asp:DropDownList ID="ddlbranch"   class="form-control" runat="server" BackColor="White"></asp:DropDownList>
                   </div>                     
                      <div class="col-sm-2">
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
                    <div class="col-sm-4">  
                        Target margin
                     <asp:TextBox ID="txttargetmargin" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                   </div> 
                    <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txttargetmargin" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator1" runat="server"></asp:RequiredFieldValidator>
                          </div>
                </div>
                <br />
                 <div class ="row">                    
                     <div class="col-sm-3">
                       Below Percent1
                          <asp:TextBox ID="txtpercent1" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                       </div>
                      <div class="col-sm-1"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtpercent1" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator2" runat="server"></asp:RequiredFieldValidator>
                          </div>
                     <div class="col-sm-3">
                       Between Percent2
                          <asp:TextBox ID="txtpercent2" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                       </div>
                      <div class="col-sm-1"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtpercent2" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator4" runat="server"></asp:RequiredFieldValidator>
                          </div>
                      <div class="col-sm-3">
                       Above Percent3
                          <asp:TextBox ID="txtpercent3" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                       </div>
                      <div class="col-sm-1"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtpercent3" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator3" runat="server"></asp:RequiredFieldValidator>
                          </div>
                     
                 </div> 
                <div class ="row">
                    <div class="col-sm-3">Below Amount
                    <asp:TextBox ID="txtbelowamt" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                    </div>
                     <div class="col-sm-1"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtbelowamt" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator5" runat="server"></asp:RequiredFieldValidator>
                          </div>
                    <div class="col-sm-3">Above Amount
                     <asp:TextBox ID="txtaboveamt" onkeypress="return validatenumbersonly(this)" class="form-control" runat="server"></asp:TextBox>
                    </div>
                     <div class="col-sm-1"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtaboveamt" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator6" runat="server"></asp:RequiredFieldValidator>
                          </div>
                   <div class="col-sm-3">
                         <br />
                    <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="Button1" name="add" onserverclick="addmargin" value="Add Margin" runat="server" />
                         </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" CellPadding="3" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:BoundField DataField="branchid" HeaderText="BRANCH" />
                        <asp:BoundField DataField="targetmargin" HeaderText="TARGET MARGIN" >
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="percent1" HeaderText="PERCENT1" >
                        </asp:BoundField>
                        <asp:BoundField DataField="percent2" HeaderText="PERCENT2">
                        </asp:BoundField>                        
                        <asp:BoundField DataField="percent3" HeaderText="PERCENT3" />
                        <asp:BoundField DataField="updatedate" HeaderText="LAST UPDATED">
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
     <script>
         <%-- // $('#<%=ddlcustomer.ClientID%>').chosen();--%>
         
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
