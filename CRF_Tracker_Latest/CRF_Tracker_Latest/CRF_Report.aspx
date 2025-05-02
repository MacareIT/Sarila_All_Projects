<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRF_Report.aspx.cs" Inherits="CRF_Tracker_Latest.CRF_Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>CRF Report</title>
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
                    <%--<a class="navbar-brand" href="#">
                        <img src="assets/img/logo.png" />
                    </a>--%>
                </div>
              
                 <span class="logout-spn" >
                  <a href="signin.aspx" style="color:#fff;font-size:medium;">LOGOUT</a>  

                </span>
            </div>
        </div>
        <!-- /. NAV TOP  -->
        <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu" >
                  <%if (Session["USERTYPE"].ToString() == "cfo")
                        { %>
                    <li class="active-link">
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li >
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
                    <li class="active-link">
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
                    <li>
                        <a href="Update_CRFStatus.aspx"><i class="fa fa-edit "></i>Update CRF Status</a>
                    </li>
                    <li>
                        <a href="New_Hlpdsk_Ticket.aspx"><i class="fa fa-edit "></i>New Ticket</a>
                    </li>
                    <% } %>
                     <%else if (Session["USERTYPE"].ToString() == "itcoordinator")
                        { %>
                    <li class="active-link">
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li >
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
                     <li class="active-link">
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
                     <li class="active-link">
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li >
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2>CRF Report</h2>   
                    </div>
                </div>  
                <br /><br />
                <div class="row">
                     <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <div class="row text-center pad-top">
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                      <div class="div-square">
                           <a href="#" >
<%-- <i class="fa fa-circle-o-notch fa-5x"></i>--%><asp:Label ID="lbllive" runat="server" Height="20px" Text="0" Font-Bold="True" Font-Size="Large"></asp:Label>
                      <h6>Live & Closed</h6>
                      </a>
                      </div>
                  </div> 
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                      <div class="div-square">
                           <a href="#" >
 <%--<i class="fa fa-users fa-5x"></i>--%><asp:Label ID="lblPrgs" runat="server" Height="20px" Text="0" Font-Bold="True" Font-Size="Large"></asp:Label>
                      <h6>In Progress</h6>
                      </a>
                      </div>
                  </div>

                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                      <div class="div-square">
                           <a href="#" >
<%-- <i class="fa fa-envelope-o fa-5x"></i>--%><asp:Label ID="lbldelay" runat="server" Height="20px" Text="0" Font-Bold="True" Font-Size="Large"></asp:Label>
                      <h6>Delayed</h6>
                      </a>
                      </div>  
                  </div>

                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                      <div class="div-square">
                           <a href="#" >
<%-- <i class="fa fa-lightbulb-o fa-5x"></i>--%><asp:Label ID="lblTA" runat="server" Height="20px" Text="0" Font-Bold="True" Font-Size="Large"></asp:Label>
                      <h6>TA Completed</h6>
                      </a>
                      </div>
                     
                     
                  </div>
                 
              </div>
                             
                            </div>
                         </div>
                </div>
                <br />
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>Select Category</label>
                                                <asp:DropDownList ID="ddl_type" runat="server" CssClass="form-control" required="required" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem selected hidden>---Select---</asp:ListItem>
                                                    <asp:ListItem>All</asp:ListItem>
                                                    <asp:ListItem>TA Completed</asp:ListItem>
                                                    <asp:ListItem>Delayed</asp:ListItem>
                                                    <asp:ListItem>In Progress</asp:ListItem>
                                                    <asp:ListItem>Live & Closed</asp:ListItem>
                                                    <asp:ListItem>Cancelled</asp:ListItem> 
                                                    <asp:ListItem>Completed</asp:ListItem> 
                                                </asp:DropDownList>                         

                        </div>
                    </div>
           
                </div>
                <br />
                
                <div class="row">
                    
                    <div class="col-lg-10 col-md-6">
                        <%--<h5>CRF DETAILS</h5>--%>
                        <div>
                            
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Bold="True" Font-Size="XX-Small">
                                <Columns>
                                    <asp:BoundField HeaderText="CRF_ID" DataField="crf_id" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="CRF NAME" DataField="crf_name" ItemStyle-Width="450px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="DEVELOPER" DataField="developer" ItemStyle-Width="300px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="REQUEST BY" DataField="requestor_name" ItemStyle-Width="300px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="REQUEST DATE" DataField="requested_date" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="DEPARTMENT" DataField="department" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="START DATE" DataField="dev_startdate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="COMPLETION DATE" DataField="dev_enddate" ItemStyle-Width="300px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="TARGET DATE" DataField="target_date" ItemStyle-Width="300px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="CRF PHASE" DataField="crf_status" ItemStyle-Width="300px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="CRF STATUS" DataField="head_remarks" ItemStyle-Width="300px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="MAN HOUR" DataField="manhours" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ACTUAL START DATE" DataField="actualdev_startdate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ACTUAL COMPLETION DATE" DataField="actualdev_enddate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="QA START" DataField="qa_startdate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="QA END" DataField="qa_enddate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ACTUAL QA START" DataField="actualqa_startdate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="ACTUAL QA END" DataField="actualqa_enddate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="UAT START" DataField="uat_startdate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="UAT CONFIRM" DataField="uat_confirmdate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="RELEASE ON" DataField="livedate" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="CONFIRM ON" DataField="userconfirm_date" ItemStyle-Width="250px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
                                    <asp:BoundField HeaderText="REMARKS" DataField="techlead_remarks" ItemStyle-Width="450px" ItemStyle-Wrap="False" ItemStyle-Font-Size="XX-Small"/>
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
                                           <asp:Button ID="btn_qadoc" runat="server" BackColor="#003366"  ForeColor="White" Width="300" Height="30" Text="GET REPORT" CssClass="btn btn-dribbble" OnClick="Btnqadoc_Click"  /> &nbsp;
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
