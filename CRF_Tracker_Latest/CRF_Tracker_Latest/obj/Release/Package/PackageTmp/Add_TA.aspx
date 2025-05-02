<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_TA.aspx.cs" Inherits="CRF_Tracker_Latest.Add_TA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Add TA</title>
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
                <ul class="nav" id="main-menu" >
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
                    <% } %>
                     <%else if (Session["USERTYPE"].ToString() == "techlead")
                        { %>
                    <li >
                        <a href="CRF_Report.aspx" ><i class="fa fa-desktop "></i>Dashboard</a>
                    </li>
                    <li class="active-link">
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
                    <li>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                     <h2>ADD TA</h2>   
                    </div>
                </div>  
                <br /><br />
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <label>Select CRF</label>
                                <asp:DropDownList ID="ddl_crf" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlcrf_SelectedIndexChanged" OnTextChanged="ddlcrf_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                  </div>
                
                <panel id="Panel1" runat="server">
                <div class="row">
                     <div class="col-lg-4 col-md-4">
                        <div class="form-group">
                                <asp:label runat="server" Text="" Width="300px" height="30px"></asp:label>
                                <asp:Button ID="Button2" runat="server" Text="View Reference Document" CssClass="btn btn-dark" OnClick="Btncrfdoc_Click" />
                                <%--<input class="form-control" />--%>
                        </div>
                    </div>
                </div>
                <br />
                
                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Description : " ForeColor="Black" Font-Bold="true"></asp:Label>
                                   <asp:Label ID="label2" runat="server" Text="Label"></asp:Label>                               
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="col-lg-8 col-md-4">
                        <div class="form-group">
                           <asp:Label ID="Label3" runat="server" Text="Requestor Name : " ForeColor="Black" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> 
                        </div>
                    </div>
                </div>
               
                <div class="row">
                      <div class="col-lg-2 col-md-4">
                            <div class="form-group">
                                <label id="label9" runat="server">START DATE</label>
                                                <asp:TextBox ID="txt_startdate" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_startdate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                          </div>   
                        </div>
                      <div class="col-lg-2 col-md-4">
                            <div class="form-group">
                              <label id="label5" runat="server">END DATE</label>
                                                <asp:TextBox ID="txt_devenddate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_devenddate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>   
                        </div>
                      <div class="col-lg-2 col-md-4">
                            <div class="form-group">
                                <label id="label6" runat="server">TARGET DATE</label>
                                                <asp:TextBox ID="txt_trgdate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_trgdate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                          </div>   
                        </div>
                     <div class="col-lg-2 col-md-4">
                            <div class="form-group">
                               <label id="label7" runat="server">TOTAL MANHOURS</label>
                                                <asp:TextBox ID="txt_ttlmanhours" runat="server" CssClass="form-control"></asp:TextBox>                          
                            </div>   
                        </div>
                      <div class="col-lg-2 col-md-4">
                            <div class="form-group">
                               <label id="label8" runat="server">QA START DATE</label>
                                                <asp:TextBox ID="txt_qastart" runat="server" CssClass="form-control"></asp:TextBox>  
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_qastart" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>   
                        </div>
                      <div class="col-lg-2 col-md-4">
                            <div class="form-group">
                               <label id="label10" runat="server">QA END DATE</label>
                                                <asp:TextBox ID="txt_qaend" runat="server" CssClass="form-control"></asp:TextBox>   
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_qaend" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                            </div>   
                        </div>
                 </div>
         
        
                <br />
                <div class="row">
                    
                    <div class="col-lg-6 col-md-6">
                        <h5>TA Details</h5>
                        <div class="table table-striped table-bordered table-hover">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                               <ContentTemplate>
                                  <%--<asp:Timer ID="Timer1" runat="server" Interval="3600" ontick="Timer1_Tick"></asp:Timer>--%>
                                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TA_Id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True">
                                        <Columns>
                                        <asp:TemplateField HeaderText="Phase" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger"> 
                                        <EditItemTemplate> 
                                                <asp:DropDownList ID="ddlPhase" runat="server" SelectedValue='<%# Eval("phase") %>'> 
                                                   <asp:ListItem Value="Design" Text="Design"></asp:ListItem>
                                                   <asp:ListItem Value="Back End" Text="Back End"></asp:ListItem>
                                                   <asp:ListItem Value="Coding" Text="Coding"></asp:ListItem>
                                                   <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                                </asp:DropDownList> 
                                       </EditItemTemplate> 
                                       <ItemTemplate> 
                                                <asp:Label ID="lblphase" runat="server" Text='<%# Eval("phase") %>'></asp:Label> 
                                       </ItemTemplate> 
                                       <FooterTemplate> 
                                               <asp:DropDownList ID="ddlphase" runat="server">
                                                   <asp:ListItem Value="Design" Text="Design"></asp:ListItem>
                                                   <asp:ListItem Value="Back End" Text="Back End"></asp:ListItem>
                                                   <asp:ListItem Value="Coding" Text="Coding"></asp:ListItem>
                                                   <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                               </asp:DropDownList> 
                                       </FooterTemplate> 
                                       </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="Task Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Width="350px" Height="30px" Text='<%#Eval("taskname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="350px" Height="30px" Text='<%#Eval("taskname") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="350px" Height="30px"></asp:TextBox>
                                            </FooterTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                                           <ItemStyle width="350px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Man Hours" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                                            <ItemTemplate>
                                                 <asp:Label ID="Label3" runat="server" Width="100px" Height="30px" Text='<%#Eval("manhours") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Width="100px" Height="30px" Text='<%#Eval("manhours") %>' ></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Width="100px" Height="30px" ></asp:TextBox>
                                            </FooterTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                                            <ItemStyle width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Width="100px" Height="30px" Text='<%#Eval("startdate") %>'></asp:Label>
                                             </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Width="100px" Height="30px" Text='<%#Eval("startdate") %>'></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox4" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Width="100px" Height="30px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox4" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                            </FooterTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                                            <ItemStyle width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                                            <ItemTemplate>
                                                 <asp:Label ID="Label5" runat="server" Width="100px" Height="30px" Text='<%#Eval("enddate") %>'></asp:Label>
                                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox5" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>--%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Width="100px" Height="30px" Text='<%#Eval("enddate") %>'></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox5" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Width="100px" Height="30px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBox5" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                            </FooterTemplate>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                                            <ItemStyle width="100px"/>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Developer" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                                            <ItemTemplate>
                                                <%--<asp:DropDownList ID="ddlDeveloper" runat="server" Width="150px" DataTextField="log_user" DataValueField="developer"  AppendDataBoundItems="true"></asp:DropDownList>--%>
                                                <asp:Label ID="lbldevlpr" runat="server" Text='<%# Eval("log_user") %>' Width="150px" Height="30px"></asp:Label> 
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="developer"  runat="server" Width="150px" Height="30px" DataTextField="log_user" DataValueField="developer"></asp:DropDownList>
                                            </EditItemTemplate>
                                             <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:DropDownList ID="developer"  Width="150px" runat="server" Height="30px" DataTextField="log_user" DataValueField="developer"></asp:DropDownList>
                                             <%--<asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />--%>
                                            </FooterTemplate>
                                             <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                                             <ItemStyle width="150px"/>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger"> 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert" ForeColor="#000099" Font-Size="Medium" Font-Bold="True"></asp:LinkButton> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger"/> 
                                        </Columns>
                                   </asp:GridView>

                                                <br />
                              </ContentTemplate>
                          </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
               
                    <div class="col-lg-8 col-md-8">
                            <div class="form-group" style="text-align:center">
                                           <asp:Button ID="Button1" runat="server" BackColor="#003366"  Text="SAVE" CssClass="btn btn-dribbble" OnClick="Button1_Click"  ForeColor="White" Width="300" Height="30"/>
                            </div>   
                        </div>
                     <%--<div class="col-lg-8 col-md-8">
                            <div class="form-group" style="text-align:center">
                                           <asp:Button ID="Button3" runat="server" BackColor="#003366"  Text="GET REPORT" CssClass="btn btn-dribbble" OnClick="Button3_Click"  ForeColor="White" Width="300" Height="30"/>
                            </div>   
                        </div>--%>
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
