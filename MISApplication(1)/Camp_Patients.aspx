<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="Camp_Patients.aspx.cs" Inherits="MISApplication.Camp_Patients" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />

   <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <style style="font-size: medium">
         .one {
            margin: 20px;
            padding: 20px;
            
        }      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager> <br />
 <h2 class="mt-4">Patient Register</h2>
      <div class ="row">
                    <div class="col-sm-3">
                        Choose Camp
                        </div>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlcamp"  CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcamp_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                       
                   </div>  
    <br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double;background-color: #D7EBFF;">
                <br />
            
                <div class ="row">
                    <div class="col-sm-3">
                        Patient
                        </div>
                    <div class="col-sm-5"> 
                        <asp:TextBox ID="txtpatientname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                       <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtpatientname" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator2" runat="server"></asp:RequiredFieldValidator>
                          </div> 
                   </div>                 
                 <div class ="row">
                    <div class="col-sm-3">Age
                        </div>
                        <div class="col-sm-5">
                        <asp:TextBox ID="txtage" onkeypress="return numeric(event)" value="0" CssClass="form-control" runat="server"></asp:TextBox>
                   </div> 
                     <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtage" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator5" runat="server"></asp:RequiredFieldValidator>
                          </div> 
                    </div>
                
                <div class ="row">
                    <div class="col-sm-3">Phone
                        </div>
                        <div class="col-sm-5">
                        <asp:TextBox ID="txtphone" onkeypress="return numeric(event)" CssClass="form-control" runat="server"></asp:TextBox>
                   </div> 
                    <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtphone" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator1" runat="server"></asp:RequiredFieldValidator>
                          </div> 
                    </div>
                <div class ="row">
                    <div class="col-sm-3">  
                       BloodGroup
                        </div>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlbloodgroup" CssClass="form-control" runat="server">
                            <asp:ListItem>NILL</asp:ListItem>
                            <asp:ListItem>A+</asp:ListItem>
                            <asp:ListItem>A-</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B+</asp:ListItem>
                            <asp:ListItem>B-</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>AB+</asp:ListItem>
                            <asp:ListItem>AB-</asp:ListItem>
                            <asp:ListItem>AB</asp:ListItem>
                            <asp:ListItem>O+</asp:ListItem>
                            <asp:ListItem>O-</asp:ListItem>
                            <asp:ListItem>O</asp:ListItem>
                        </asp:DropDownList>
                   </div> 
                   <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="ddlbloodgroup" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator3" runat="server"></asp:RequiredFieldValidator>
                          </div> 
                 <br />               
            </div> 
     <div class ="row">
                    <div class="col-sm-3">  
                       Gender
                        </div>
                    <div class="col-sm-5">
                        <asp:RadioButtonList ID="rblstatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Class="one" Selected="True" Value="Male">Male</asp:ListItem>
                            <asp:ListItem Class="one" Value="Female">Female</asp:ListItem>
                            <asp:ListItem Class="one" Value="Trans">Trans</asp:ListItem>
                        </asp:RadioButtonList>
                   </div> 
                     <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="rblstatus" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator4" runat="server"></asp:RequiredFieldValidator>
                          </div> 
                 <br />               
            </div>
                <div class="row">
                    <div class="col-sm-3">
                        Remark
                    </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtremark" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtremark" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator6" runat="server"></asp:RequiredFieldValidator>
                    </div> 
                </div>
                <br />
                <div class ="row">       
         <div class="col-sm-8">  
             </div>
         <div class="col-sm-4">  
        <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="Button2" name="add"  onserverclick="addpatient" value="Register" runat="server" />
             </div>
      
         </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%" DataKeyNames="patientid" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:BoundField DataField="bloodgroup" HeaderText="Group" />
                        <asp:BoundField DataField="campname" HeaderText="Camp" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
      <script>
      $('#<%=ddlcamp.ClientID%>').chosen();       
     
      </script>
     <script type="text/javascript" language="javascript">
         function numeric(evt) {
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
