<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_CRF.aspx.cs" Inherits="CRF_Tracker_Latest.New_CRF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>New CRF Register</title>
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
                    <li class="active-link">
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
                     <% else if (Session["USERTYPE"].ToString() == "techlead")
                        { %>
                    <li>
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="Add_TA.aspx"><i class="fa fa-edit "></i>Add TA</a>
                    </li>
                    <li class="active-link">
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
                     <% else if (Session["USERTYPE"].ToString() == "itcoordinator")
                        { %>
                    <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li class="active-link">
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
                    <% else if (Session["USERTYPE"].ToString() == "developer")
                        { %>
                     <li>
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li  class="active-link">
                        <a href="New_CRF.aspx"><i class="fa fa-edit "></i>Add CRF</a>
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
                    <li class="active-link">
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
                     <h2>CRF REGISTER </h2>   
                    </div>
                </div>  
                <br /><br />
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>CRF Name</label>
                            <asp:TextBox ID="txt_crfname" runat="server"  CssClass="form-control" required="required"></asp:TextBox>
                            <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>Description</label>
                            <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" Height="120px" CssClass="form-control" required="required"></asp:TextBox>
                            <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>CRF Scope</label>
                            <asp:TextBox ID="txt_scope" runat="server"  CssClass="form-control" required="required"></asp:TextBox>
                            <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="form-group">
                            <label>Request Type</label>
                            <asp:DropDownList ID="ddl_reqtype" runat="server" CssClass="form-control" required="required" Width="250px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>New Module</asp:ListItem>
                                                <asp:ListItem>Modify Module</asp:ListItem>
                                                <asp:ListItem>New Report</asp:ListItem>
                                                <asp:ListItem>Modify Report</asp:ListItem>
                               </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-lg-4 col-md-4">
                         <div class="form-group">
                            <label>Priority</label><br />
                                            <asp:RadioButtonList ID="radio_priority" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Table" required="required" Width="180px"  >
                                                <asp:ListItem>High </asp:ListItem>
                                                <asp:ListItem>Medium </asp:ListItem>
                                                <asp:ListItem>Low </asp:ListItem>
                                            </asp:RadioButtonList>
                        </div>
                        </div>
                     
                      <div class="col-lg-4 col-md-4">
                            <div class="form-group">
                                            <label>Reference documents</label><br /> 
                                            <asp:FileUpload ID="FileUpload1" multiple="multiple" runat="server" CssClass="form-control" Width="250px" />        
                                        </div>   
                        </div>
                     </div>
                     <div class="row">
                     <div class="col-lg-4 col-md-4" id="appear" runat="server">
                            <div class="form-group">
                                            <label>Department</label><br /> 
                                            <asp:DropDownList ID="ddl_dept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged"></asp:DropDownList>   
                                            &nbsp; <asp:DropDownList ID="ddl_emp" runat="server"></asp:DropDownList>  
                                        </div>   
                        </div>
                    <%-- <div class="col-lg-4 col-md-4" id="Div1" runat="server">
                            <div class="form-group">
                                            <label>Department</label><br /> 
                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged"></asp:DropDownList>   
                                            &nbsp; <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>  
                                        </div>   
                        </div>--%>
                </div>
                <br /><br />
                <div class="row">
               
                    <div class="col-lg-8 col-md-8">
                            <div class="form-group" style="text-align:center">
                                            <asp:Button ID="btnSubmit" runat="server" type="submit" Text="SUBMIT" OnClick="btnSubmit_Click" BackColor="#003366" BorderStyle="None" ForeColor="White" Width="300" Height="30" />       
                                        </div>   
                        </div>
                    </div>
                 <!-- /. ROW  -->
                  <hr />
              
                 <!-- /. ROW  -->           
               </div>
                </form>
             <!-- /. PAGE INNER  -->
            </div>
         <!-- /. PAGE WRAPPER  -->
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
