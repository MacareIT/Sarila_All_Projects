<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approve_Helpdesk.aspx.cs" Inherits="CRF_Tracker_Latest.Approve_Helpdesk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>CRF Approval/Recommendation</title>
	<!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
        <!-- CUSTOM STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
     <!-- GOOGLE FONTS-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

</head>
<body>
   <div id="wrapper">
         <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="adjust-nav">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <h2 style="color:white;"> Internal CRF Tracker</h2>
                </div>
              
                 <span class="logout-spn" >
                  <a href="signin.aspx" style="color:#fff;font-size:medium;">LOGOUT</a>  

                </span>
            </div>
        </div>
        <!-- /. NAV TOP  -->
        <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">
                  <% if (Session["USERTYPE"].ToString() == "cfo")
                        { %>
                    <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="New_CRF.aspx"><i class="fa fa-edit "></i>Add CRF</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li class="active-link">
                        <a href="CRF_Approve.aspx"><i class="fa fa-edit "></i>Approve CRF</a>
                    </li>
                    <li>
                        <a href="New_Hlpdsk_Ticket.aspx"><i class="fa fa-edit "></i>New Ticket</a>
                    </li>
                    <% } %>
                     <%else if (Session["USERTYPE"].ToString() == "techlead")
                        { %>
                    <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li >
                        <a href="Add_TA.aspx"><i class="fa fa-edit "></i>Add TA</a>
                    </li>
                    <li>
                        <a href="New_CRF.aspx"><i class="fa fa-edit "></i>Add CRF</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li>
                        <a href="Update_CRFStatus.aspx"><i class="fa fa-edit "></i>Update CRF Status</a>
                    </li>
                    <li>
                        <a href="New_Hlpdsk_Ticket.aspx"><i class="fa fa-edit "></i>New Ticket</a>
                    </li>
                    <% } %>
                     <%else if (Session["USERTYPE"].ToString() == "itcoordinator")
                        { %>
                    <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="New_CRF.aspx"><i class="fa fa-edit "></i>Add CRF</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li class="active-link">
                        <a href="CRF_Approve.aspx"><i class="fa fa-edit "></i>Recommend CRF</a>
                    </li>
                    <li>
                        <a href="New_Hlpdsk_Ticket.aspx"><i class="fa fa-edit "></i>New Ticket</a>
                    </li>
                    <% } %>
                    <%else if (Session["USERTYPE"].ToString() == "developer")
                        { %>
                     <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li>
                        <a href="New_Hlpdsk_Ticket.aspx"><i class="fa fa-edit "></i>New Ticket</a>
                    </li>
                    <% } %>
                     <% else
                        { %>
                     <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="New_CRF.aspx"><i class="fa fa-edit "></i>Add CRF</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li>
                        <a href="New_Hlpdsk_Ticket.aspx"><i class="fa fa-edit "></i>New Ticket</a>
                    </li>
                    <% } %>
                </ul>
                            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper" >
            <form id="form1" runat="server">
    
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2>Helpdesk Approve </h2>   
                    </div>
                </div>  
                <br /><br />
                
                <panel id="panel1" runat="server">
                
                <div class="row">
                    
                    <div class="col-lg-10 col-md-6">
                        <%--<h5>CRF DETAILS</h5>--%>
                        <div>
                            
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Bold="True" Font-Size="XX-Small">
                                <Columns>
                                    <asp:BoundField HeaderText="TICKET NO" DataField="ticket_no" ItemStyle-Width="150px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ISSUED ON" DataField="issued_date" ItemStyle-Width="200px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ISSUED BY" DataField="issued_by" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ISSUE IN DETAIL" DataField="issue_detail" ItemStyle-Width="450px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="TICKET TYPE" DataField="ticket_type" ItemStyle-Width="150px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:TemplateField ItemStyle-Width="80">
                                     <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="1">Approve</asp:ListItem>
                                        <asp:ListItem Value="2">Reject</asp:ListItem>
                                        </asp:DropDownList>
                                     </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                            <br />

                        </div>
                    </div>
                </div>
                <br />
                   <div class="row">
               
                    <div class="col-lg-8 col-md-8">
                            <div class="form-group" style="text-align:center">
                                           <asp:Button ID="btn_submit" runat="server" BackColor="#003366"  ForeColor="White" Width="300" Height="30" Text="RESOLVE" CssClass="btn btn-dribbble" OnClick="Recommend_Click"  />

                             </div>   
                        </div>
                    </div>
                    <br />
                    </panel>
                 <!-- /. ROW  -->
                  <hr />
              
                 <!-- /. ROW  -->           
               </div>
                </form>
             <!-- /. PAGE INNER  -->
         <!-- /. PAGE WRAPPER  -->
        </div>
       </div>
    <div class="footer">
      
    
             <div class="row">
                <div class="col-lg-12" >
                    &copy;  2023 MAcare.in | Design by: Internal IT
                </div>
        </div>
        </div>
          

     <!-- /. WRAPPER  -->
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
      <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.min.js"></script>
      <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
    
</body>
</html>
