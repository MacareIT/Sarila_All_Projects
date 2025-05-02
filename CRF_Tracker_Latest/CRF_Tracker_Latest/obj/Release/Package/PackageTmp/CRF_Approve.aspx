<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRF_Approve.aspx.cs" Inherits="CRF_Tracker_Latest.CRF_Approve" %>

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
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
                    </li>
                    <li>
                        <a href="Update_CRFStatus.aspx"><i class="fa fa-edit "></i>Update CRF Status</a>
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
                    <% } %>
                    <%else if (Session["USERTYPE"].ToString() == "developer")
                        { %>
                     <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="View_CRF.aspx"><i class="fa fa-table "></i>CRF_View</a>
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
                     <h2>CRF Approve/Recommend </h2>   
                    </div>
                </div>  
                <br /><br />
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
                <panel id="panel1" runat="server">
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
                                                <asp:Label ID="Label_priority" runat="server" Text="Label"></asp:Label>                            </div>   
                        </div>
                 </div>
            
                 <div class="row">
                      <div class="col-lg-4 col-md-4">
                            <div class="form-group">
                               <asp:Label ID="lbl_remarks" runat="server" Text="Remarks"></asp:Label>
                             <asp:TextBox ID="txt_remarks" runat="server" TextMode="MultiLine" Height="100px" CssClass="form-control"></asp:TextBox>
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
                
                <br />
                <div class="row">
               
                    <div class="col-lg-8 col-md-8">
                            <div class="form-group" style="text-align:center">
                                           <asp:Button ID="btn_cancel" runat="server" BackColor="#003366"  ForeColor="White" Width="300" Height="30" Text="REJECT" CssClass="btn btn-dribbble" OnClick="Reject_Click" /> &nbsp;
                                           <asp:Button ID="btn_submit" runat="server" BackColor="#003366"  ForeColor="White" Width="300" Height="30" Text="RECOMMEND" CssClass="btn btn-dribbble" OnClick="Recommend_Click"  />

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
