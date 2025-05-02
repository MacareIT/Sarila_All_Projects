<%@ Page Title="" Language="C#" MasterPageFile="~/Incentive.Master" AutoEventWireup="true" CodeBehind="AddCamp.aspx.cs" Inherits="MISApplication.AddCamp" %>
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
       #overlay {
position: fixed;
top: 0;
left: 0;
width: 100%;
height: 100%;
background-color: #000;
filter:alpha(opacity=70);
-moz-opacity:0.7;
-khtml-opacity: 0.7;
opacity: 0.7;
z-index: 100;
display: none;
}
.content a{
text-decoration: none;
}
.popup{
width: 100%;
margin: 0 auto;
display: none;
position: fixed;
z-index: 101;
}
.content{
min-width: 600px;
width: 600px;
min-height: 150px;
margin: 100px auto;
background: #f3f3f3;
position: relative;
z-index: 103;
padding: 10px;
border-radius: 5px;
box-shadow: 0 2px 5px #000;
}
.content p{
clear: both;
color: #555555;
text-align: justify;
}
.content p a{
color: #d91900;
font-weight: bold;
}
.content .x{
float: right;
height: 35px;
left: 22px;
position: relative;
top: -25px;
width: 34px;
}
.content .x:hover{
cursor: pointer;
}
    </style>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
.btn {
  background-color: DodgerBlue;
  border: none;
  color: white;
  padding: 12px 16px;
  font-size: 16px;
  cursor: pointer;
}

/* Darker background on mouse-over */
.btn:hover {
  background-color: RoyalBlue;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager> 
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<%--<div class='popup' id="MyPopup" runat="server">
<div class='content'>
<img src="_images/close.png" alt='quit' class='x' id='x' />

<h2 class="mt-4">Camp Details</h2>
                <br />
    <div class ="row">
                    <div class="col-sm-3">
                        Choose Camp
                        </div>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlcamp" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcamp_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                       
                   </div>  
                <div class ="row">
                    <div class="col-sm-3">
                        Conduct On
                        </div>
                    <div class="col-sm-5"> 
                        <asp:TextBox ID="txteditdate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                       
                   </div>                 
                 <div class ="row">
                    <div class="col-sm-3">Name
                        </div>
                        <div class="col-sm-5">
                        <asp:TextBox ID="txteditname" CssClass="form-control" runat="server"></asp:TextBox>
                   </div> 
                    </div>
               
                <div class ="row">
                    <div class="col-sm-3">Description
                        </div>
                        <div class="col-sm-5">
                        <asp:TextBox ID="txteditdesc" CssClass="form-control" runat="server"></asp:TextBox>
                   </div> 
                    </div>
                <div class ="row">
                    <div class="col-sm-3">  
                       Place
                        </div>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txteditplace" CssClass="form-control" runat="server"></asp:TextBox>
                   </div> 
                    <div class="col-sm-3">
                   </div> 
                 <br />               
            </div> 
     <div class ="row">
                    <div class="col-sm-3">  
                       Status
                        </div>
                    <div class="col-sm-5">
                        <asp:RadioButtonList ID="rblstatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="2">Conducted</asp:ListItem>
                            <asp:ListItem Value="1">Not Conducted</asp:ListItem>
                            <asp:ListItem Value="0">Cancelled</asp:ListItem>
                        </asp:RadioButtonList>
                   </div> 
                    <div class="col-sm-3">
                   </div> 
                 <br />               
            </div> 
      
    <br />
     <div class ="row">
       
         <div class="col-sm-3">  
             </div>
         <div class="col-sm-2">  
        <input type="button" class="btn btn-primary" style="background-color: #00CC99" id="Button2" name="add"  value="Update" runat="server" />
             </div>
          <div class="col-sm-2">  
        <input type="button" class="btn btn-primary" id="Button3" name="add"  style="background-color: #9999FF"  value="Cancel" runat="server" />
             </div>
         </div>

</div>
</div>--%>
            <h2 class="mt-4">Register Camp </h2>
            <div class="container-fluid" style="border-color: #C0C0C0; border-style: double; background-color: #D7EBFF;">
                <br />
                <div class ="row">
                    <div class="col-sm-3">
                        Camp Conduct Date
                        </div>
                    <div class="col-sm-4"> 
                        <asp:TextBox ID="txtcampdate" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <ajaxtoolkit:CalendarExtender
                        ID="ceDOB"
                        runat="server"
                        Enabled="True"
                        TargetControlID="txtcampdate"
                        PopupButtonID="txtcampdate"
                        Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxtoolkit:CalendarExtender>
                    <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtcampdate" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator4" runat="server"></asp:RequiredFieldValidator>
                          </div>
                   </div>                
                    <div class="row">
                        <div class="col-sm-3">
                            Camp Name
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtname" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator1" runat="server"></asp:RequiredFieldValidator>
                          </div>
                    </div>
                 <div class ="row">
                    <div class="col-sm-3">Time
                        </div>
                        <div class="col-sm-2">
                        From<asp:TextBox ID="txtftime" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                    <div class="col-sm-2">
                        To<asp:TextBox ID="txtttime" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            Description
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtdescription" value="NILL" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2"><br />
                  <asp:RequiredFieldValidator ControlToValidate="txtdescription" ErrorMessage="*" ForeColor="Red" ID="RequiredFieldValidator2" runat="server"></asp:RequiredFieldValidator>
                          </div>
                    </div>
              
                    <div class="row">
                       <div class="col-sm-5">
                           </div>
                        <div class="col-sm-3">
                        </div>
                    </div>
                    <br />
                <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">

                    <Columns>

                        <asp:BoundField DataField="RowNumber" HeaderText="SL NO">

                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="UNIT NAME">

                            <ItemTemplate>
                                <asp:DropDownList ID="ddlbranch" CssClass="form-control" runat="server"></asp:DropDownList>


                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PLACE">

                            <ItemTemplate>

                                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>

                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />

                            <FooterTemplate>
                                <button class="btn" id="ButtonAdd" onserverclick="ButtonAdd_Click" runat="server"><i class="fa fa-plus"></i></button>
                                <input type="button" class="btn btn-primary" id="Button1" name="add" onserverclick="addcamp" value="Register Camp" runat="server" />

                                <%--<asp:Button ID="ButtonAdd" OnClick="ButtonAdd_Click"  runat="server" Text="Add New Row" />--%>
                            </FooterTemplate>

                            <ItemStyle HorizontalAlign="Left" />

                        </asp:TemplateField>


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
<h2>CAMP DETAILS</h2>
                    <asp:GridView ID="grdcamp" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%" DataKeyNames="campid">
                        <Columns>
                            <asp:BoundField DataField="campdate" HeaderText="Conduct ON" />
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:BoundField DataField="place" HeaderText="Place" />
                            <asp:BoundField DataField="camptime" HeaderText="Time" />
                            <%--<asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                            <a href="click" class='click'>View</a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type='text/javascript'>
        $(function () {
            var overlay = $('<div id="overlay"></div>');
            $('.close').click(function () {
                $('.popup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });
            $('.x').click(function () {
                $('.popup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });

            $('.click').click(function () {
                overlay.show();
                overlay.appendTo(document.body);
                $('.popup').show();
                return false;
            });
        });
    </script>
   
</asp:Content>
