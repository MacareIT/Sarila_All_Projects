<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_CRFStatus.aspx.cs" Inherits="CRF_Tracker_Latest.Update_CRFStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Update CRF Status</title>
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
                    <li>
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
                    <li>
                        <a href="Add_TA.aspx"><i class="fa fa-edit "></i>Add TA</a>
                    </li>
                    <li>
                        <a href="New_CRF.aspx"><i class="fa fa-edit "></i>Add CRF</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li class="active-link">
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
                    <li>
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
                     <h2>Update CRF Status</h2>   
                    </div>
                </div>  
                <br /><br />
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                                <label>Select CRF</label>
                                <asp:DropDownList ID="ddl_crf" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>
                            <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>Select Status</label>
                                                <asp:DropDownList ID="ddl_status" runat="server" CssClass="form-control">
                                                    <asp:ListItem selected hidden>--Select--</asp:ListItem>
                                                    <asp:ListItem>Development Started</asp:ListItem>
                                                    <asp:ListItem>Development Completed</asp:ListItem>
                                                    <asp:ListItem>QA Started</asp:ListItem>
                                                    <asp:ListItem>QA Completed</asp:ListItem>
                                                    <asp:ListItem>UAT Started</asp:ListItem>
                                                    <asp:ListItem>UAT Completed</asp:ListItem>
                                                    <asp:ListItem>UAT Confirmed</asp:ListItem>
                                                    <asp:ListItem>Live</asp:ListItem>
                                                    <asp:ListItem>User Confirmed</asp:ListItem>
                                                    <asp:ListItem>Cancelled</asp:ListItem>
                                                    <asp:ListItem>Completed</asp:ListItem>
                                                </asp:DropDownList>                       <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>Delay Status</label>
                                                <asp:DropDownList ID="ddl_delay" runat="server" CssClass="form-control">
                                                    <asp:ListItem>In Progress</asp:ListItem>
                                                    <asp:ListItem>Delayed</asp:ListItem>
                                                </asp:DropDownList>                       <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                <br />
                 <div class="row">
                      <div class="col-lg-4 col-md-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_remarks" runat="server" Text="Remarks"></asp:Label>
                             <asp:TextBox ID="txt_remarks" runat="server" TextMode="MultiLine" Height="100px" CssClass="form-control"></asp:TextBox>
                            </div>   
                        </div>
                 </div>
                <br />
                <div class="row">
               
                    <div class="col-lg-8 col-md-8">
                            <div class="form-group" style="text-align:center">
                                          <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="#003366"  ForeColor="White" Width="300" Height="30" CssClass="btn btn-dribbble" OnClick="update_Click" />  
                                        </div>   
                        </div>
                    </div>
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
