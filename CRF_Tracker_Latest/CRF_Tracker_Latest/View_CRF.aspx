<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_CRF.aspx.cs" Inherits="CRF_Tracker_Latest.View_CRF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>CRF View In Detail</title>
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
                    <li class="active-link">
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
                    <li class="active-link">
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
                    <li class="active-link">
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
                    <li class="active-link">
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
                    <li class="active-link">
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
                     <h2>CRF View In Detail</h2>   
                    </div>
                </div>  
                <br /><br />
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
                                                </asp:DropDownList>                         

                        </div>
                    </div>
           
                </div>
                <br />
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>CRF Name</label>
                            <asp:DropDownList ID="ddl_crf" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlcrf_SelectedIndexChanged" OnTextChanged="ddlcrf_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                <br />
                <panel id="Panel1" runat="server">
                <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lbl_crfid" runat="server" Text="CRF Id : " ForeColor="Black" Font-Bold="true"></asp:Label>
                            <asp:Label ID="label_crfid" runat="server" Text="Label"></asp:Label>                                <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lbl_crfname" runat="server" Text="CRF Name : " ForeColor="Black" Font-Bold="true"></asp:Label>
                            <asp:Label ID="label_crfname" runat="server" Text="Label"></asp:Label>                                
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                           <asp:Label ID="lbl_reqtype" runat="server" Text="Request Type : " ForeColor="Black" Font-Bold="true"></asp:Label>
                           <asp:Label ID="Label_reqtype" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-lg-10 col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lbl_description" runat="server" Text="Description : " ForeColor="Black" Font-Bold="true"></asp:Label>
                            <asp:Label ID="label_description" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                 </div>
                 <div class="row">
                     <div class="col-lg-4 col-md-4">
                         <div class="form-group">
                            <asp:Label ID="lbl_scope" runat="server" Text="CRF Scope : " ForeColor="Black" Font-Bold="true"></asp:Label>
                            <asp:Label ID="Label_scope" runat="server" Text="Label"></asp:Label> 
                        </div>
                        </div>
                 </div>
                 <div class="row">
                      <div class="col-lg-4 col-md-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_requestor" runat="server" Text="Requestor Name : " ForeColor="Black" Font-Bold="true"></asp:Label>
                               <asp:Label ID="Label_requestor" runat="server" Text="Label"></asp:Label>                            </div>   
                        </div>
                 </div>
            
                 <div class="row">
                      <div class="col-lg-4 col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lbl_priority" runat="server" Text="Priority : " ForeColor="Black" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label_priority" runat="server" Text="Label"></asp:Label>
                            </div>   
                        </div>
                 </div>
                
                 <div class="row">
                      <div class="col-lg-4 col-md-4">
                            <div class="form-group">
                               <asp:Button ID="btn_viewrefdoc" runat="server" Text="View Reference Document" CssClass="btn btn-dark" OnClick="Btncrfdoc_Click" />                           

                            </div>   
                        </div>
                 </div>
                <br />
                <div class="row">
                    
                    <div class="col-lg-10 col-md-6">
                        <h5 runat="server" id="h5">TA Details</h5>
                       <%-- <div class="table table-striped table-bordered table-hover">--%>
                            
                                   <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" >
                                                    <Columns>
                                                    <asp:BoundField DataField="crf_id" HeaderText="CRF ID" SortExpression="crf_id" ItemStyle-Width="200px" />
                                                    <asp:BoundField DataField="manhours" HeaderText="TOTAL MAN HOURS" SortExpression="manhours" ItemStyle-Width="350px" ItemStyle-Wrap="False"/>
                                                    <asp:BoundField DataField="dev_startdate" HeaderText="START DATE" SortExpression="startdate" ItemStyle-Width="300px" ItemStyle-Wrap="False" />
                                                    <asp:BoundField DataField="dev_enddate" HeaderText="END DATE" SortExpression="enddate" ItemStyle-Width="300px" ItemStyle-Wrap="False" />
                                                    <asp:BoundField DataField="target_date" HeaderText="TARGET DATE" SortExpression="targetdate" ItemStyle-Width="300px" ItemStyle-Wrap="False" />
                                                    </Columns>
                                                </asp:GridView>

                                                <br />
 


                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" >
                                                    <Columns>
                                                        <asp:BoundField DataField="phase" HeaderText="PHASE" SortExpression="crf_id" ItemStyle-Width="350px" ItemStyle-Wrap="False" />
                                                        <asp:BoundField DataField="taskname" HeaderText="TASK NAME" SortExpression="taskname" ItemStyle-Width="500px" ItemStyle-Wrap="False"/>
                                                        <asp:BoundField DataField="manhours" HeaderText="MAN HOURS" SortExpression="manhours" ItemStyle-Width="400px" ItemStyle-Wrap="False"/>
                                                        <asp:BoundField DataField="startdate" HeaderText="START DATE" SortExpression="startdate" ItemStyle-Width="400px" ItemStyle-Wrap="False"/>
                                                        <asp:BoundField DataField="enddate" HeaderText="END DATE" SortExpression="enddate" ItemStyle-Width="400px" ItemStyle-Wrap="False"/>
                                                    </Columns>
                                                </asp:GridView>
                                    <br />
                       <%-- </div>--%>
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
                    &copy;  2014 yourdomain.com | Design by: <a href="http://binarytheme.com" style="color:#fff;"  target="_blank">www.binarytheme.com</a>
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
