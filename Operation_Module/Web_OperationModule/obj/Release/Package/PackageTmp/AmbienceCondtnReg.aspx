<%@ Page Title="" Language="C#" MasterPageFile="~/Users_master.Master" AutoEventWireup="true"  MaintainScrollPositionOnPostback="true"  CodeBehind="AmbienceCondtnReg.aspx.cs" Inherits="Web_OperationModule.AmbienceCondtnReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>  
             <asp:PostBackTrigger ControlID="btnUpload1"/>
             <asp:PostBackTrigger ControlID="btnUpload2" />  
             <asp:PostBackTrigger ControlID="btnUpload3" />  
             <asp:PostBackTrigger ControlID="btnUpload4" />  
        </Triggers> 
        <ContentTemplate>

    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                             <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">AMBIENCE CONDITION</label>
                            <br /><br />
                                    <label for="exampleInputEmail1" class="form-label">Month</label>
                                    <asp:DropDownList ID="cmbMnth"  class="form-control" runat="server" DataValueField="MonthNo" DataTextField="MonthName"></asp:DropDownList>
                                <br />
                                    <label for="exampleInputEmail1" class="form-label">Year</label>
                                    <asp:DropDownList ID="cmbYr"  class="form-control" runat="server" DataValueField="Year" DataTextField="Year"></asp:DropDownList>
                                <br />

                               <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                               
                             </div>
                        </div>
                    <div class="col-sm-12 col-xl-6" style="width:980px;">
                        <div class="bg-light rounded h-100 p-4" >
                            <asp:GridView ID="GridAmbCondtn" runat="server" Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="ID" ItemStyle-Width="50" Visible="False">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("Amb_ID") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="50px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ambience" ItemStyle-Width="180">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Amb_Name") %>' Width="140"></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="180px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Count" ItemStyle-Width="80">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Amb_Count") %>'></asp:Label>--%>
                                               <asp:TextBox ID="txtCount" runat="server" Width="50" Text='<%# Eval("Amb_Count") %>' MaxLength="5" OnKeyPress=" return AllowNumericOnly(this);"></asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="80px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="WorkingCondition" ItemStyle-Width="350">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_condtn" runat="server" Text='<%# Eval("Amb_Condtn") %>'></asp:Label>--%>
                                               <asp:TextBox ID="txtCndtn" runat="server" Width="280" Text='<%# Eval("Amb_Condtn") %>'></asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="350px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <%--<asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>--%>
                                               <asp:TextBox ID="txtRemarks" runat="server" Width="400" Text='<%# Eval("Amb_Remarks") %>'></asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                            <script type="text/javascript" charset="utf-8">

                                function AllowNumericOnly(e) {
                                    var keycode;
                                    if (window.event)
                                        keycode = window.event.keyCode;
                                    else if (event)
                                        keycode = event.keyCode;
                                    else if (e)
                                        keycode = e.which;
                                    else return true;
                                    if ((keycode > 47 && keycode <= 57)) { return true; }
                                    else { return false; } return true;
                                }
                            </script>

                            <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                             <script type="text/javascript">
                             var specialKeys = new Array();
                             specialKeys.push(8); //Backspace
                             $(function () {
                             $(".numeric").bind("keypress", function (e) {
                             var keyCode = e.which ? e.which : e.keyCode
                             var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                             if (ret) {
                             $(this).next().remove();
                             } else {
                             if (!$(this).next().hasClass("error")) {
                             $(this).after("<span class = 'error'><br />* Input digits (0 - 9)</span>");
                             }
                             }
                             return ret;
                             });
                             $(".numeric").bind("paste", function (e) {
                             return false;
                             });
                             $(".numeric").bind("drop", function (e) {
                             return false;
                             });
                             });
                             </script>--%>
                            <br /><br />
                            <asp:Button ID="Btn_Submit" class="btn btn-primary" runat="server" Text="Confirm" OnClick="Btn_Submit_Click" BackColor="#1C5E55" />
                            <%--<asp:GridView ID="Grid_Ambience" runat="server" Width="820px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" OnRowCommand="Grid_Ambience_RowCommand" BorderStyle="Solid">
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="ID" ItemStyle-Width="50" Visible="False">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_conId" runat="server" Text='<%# Eval("AMB_CONDTNID") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="50px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="ID" ItemStyle-Width="50" Visible="False">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("Amb_ID") %>'></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="50px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ambience" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Amb_Name") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Count" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_count" runat="server" Text='<%# Eval("Amb_Count") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="WorkingCondition" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_condtn" runat="server" Text='<%# Eval("Amb_Condtn") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="400px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="500">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_remarks" runat="server" Text='<%# Eval("Amb_Remarks") %>'></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="500px" />
                                       </asp:TemplateField>

                                       <asp:TemplateField ItemStyle-Width="100" ShowHeader="False">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lnk_select" runat ="server" CommandArgument='<%#Eval("AMB_CONDTNID")%>' Text ='Select' CommandName ="Select">
                                                   </asp:LinkButton>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       
                                    </Columns>
                                 
                                 <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:GridView>--%>
                             <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                             <script type="text/javascript">
                             var specialKeys = new Array();
                             specialKeys.push(8); //Backspace
                             $(function () {
                             $(".numeric").bind("keypress", function (e) {
                             var keyCode = e.which ? e.which : e.keyCode
                             var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                             if (ret) {
                             $(this).next().remove();
                             } else {
                             if (!$(this).next().hasClass("error")) {
                             $(this).after("<span class = 'error'><br />* Input digits (0 - 9)</span>");
                             }
                             }
                             return ret;
                             });
                             $(".numeric").bind("paste", function (e) {
                             return false;
                             });
                             $(".numeric").bind("drop", function (e) {
                             return false;
                             });
                             });
                             </script>--%>
                         </div>
                    </div>
                    <br />
                    <br />

                    <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                               <asp:Label ID="Lbl_Lab" runat="server" Text="Lab" Width="60px"></asp:Label>&nbsp;
                               <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Button ID="btnUpload1" class="btn btn-primary" runat="server" Text="Upload" BackColor="#1C5E55" OnClick="btnUpload1_Click" />
                               &nbsp;&nbsp;<asp:Image ID="Image1" runat="server" Width="100px" Height="75" /> 
                               <asp:Label ID="lbl_Picid1" runat="server" Text="0" Visible="False"></asp:Label>
                         </div>
                    </div>
                    <br />
                     <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                               <asp:Label ID="Lbl_Board" runat="server" Text="Board" Width="60px"></asp:Label>&nbsp;
                               <asp:FileUpload ID="FileUpload2" runat="server" />&nbsp;<asp:Button ID="btnUpload2" class="btn btn-primary" runat="server" Text="Upload" BackColor="#1C5E55" OnClick="btnUpload2_Click" />
                               &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" Width="100px" Height="75" /> 
                               <asp:Label ID="Lbl_Picid2" runat="server" Text="0" Visible="False"></asp:Label>
                         </div>
                    </div>
                    <br />
                     <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                               <asp:Label ID="Lbl_Toilet" runat="server" Text="Toilet" Width="60px"></asp:Label>&nbsp;
                               <asp:FileUpload ID="FileUpload3" runat="server" />&nbsp;<asp:Button ID="btnUpload3" class="btn btn-primary" runat="server" Text="Upload" BackColor="#1C5E55" OnClick="btnUpload3_Click" />
                               &nbsp;&nbsp;<asp:Image ID="Image3" runat="server" Width="100px" Height="75" /> 
                               <asp:Label ID="Lbl_Picid3" runat="server" Text="0" Visible="False"></asp:Label>
                         </div>
                    </div>
                    <br />
                     <div class="col-sm-12 col-xl-6" style="width:800px;">
                         <div class="mb-3">
                               <asp:Label ID="Lbl_Recptn" runat="server" Text="Reception Area" Width="60px"></asp:Label>&nbsp;
                               <asp:FileUpload ID="FileUpload4" runat="server" />&nbsp;<asp:Button ID="btnUpload4" class="btn btn-primary" runat="server" Text="Upload" BackColor="#1C5E55" OnClick="btnUpload4_Click" />
                               &nbsp;&nbsp;<asp:Image ID="Image4" runat="server" Width="100px" Height="75" /> 
                               <asp:Label ID="Lbl_Picid4" runat="server" Text="0" Visible="False"></asp:Label>
                         </div>
                    </div>
                    <br />
                    <br />
                </div>
             </div>
       </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
