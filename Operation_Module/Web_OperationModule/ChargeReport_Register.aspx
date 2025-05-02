<%@ Page Title="" Language="C#" MasterPageFile="~/Users_master.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="ChargeReport_Register.aspx.cs" Inherits="Web_OperationModule.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:980px;">
                        <div class="bg-light rounded h-100 p-4" style="height:500px;">
                             <%--<div class="mb-3">
                            <asp:Label ID="Label12" runat="server" class="form-label" Text="Branch Name"></asp:Label>
                            <asp:DropDownList ID="cmb_branch" class="form-control" runat="server" DataTextField="Name" DataValueField="Branch_Id"></asp:DropDownList>
                            <br />
                            
                             <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="BtnSubmit_Click" BackColor="#1C5E55" />
                               <br />
                               <br />
                        </div>--%>
                            <label id="Label1" for="exampleInputEmail1" class="form-label" runat="server" style="text-decoration: underline; font-size: large; font-weight: bold">CHARGE REPORT</label>
                            <br /><br />
                            <label id="Label2" for="exampleInputEmail1" class="form-label" runat="server">CASH POSITION STATUS</label>
                            <asp:GridView ID="GridCashPosition1" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Physical Cash" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_PCash" runat="server" Width="100"  Text='<%# Eval("Name") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);"  >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="System Cash" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_SCash" runat="server" Width="100" Text='<%# Eval("Status") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);"  AutoPostBack="True" OnTextChanged="txt_SCash_TextChanged">
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Difference" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Diff" runat="server" Width="70" Text='<%# Eval("Diff") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="170">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="150" Text='<%# Eval("Remarks") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="170px" />
                                       </asp:TemplateField>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                            
                                <br />
                            <asp:GridView ID="GridCashPosition2" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Physical Cash" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_PCash" runat="server" Width="100" Text='<%# Eval("Name") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);"  AutoPostBack="True">
                                               </asp:TextBox>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Registerwise" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_SCash" runat="server" Width="100" Text='<%# Eval("Status") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);"  AutoPostBack="True" OnTextChanged="txt_SCash_TextChanged1">
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Difference" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Diff" runat="server" Width="70" Text='<%# Eval("Diff") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="100">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="150" Text='<%# Eval("Remarks") %>' MaxLength="10" OnKeyPress=" return isNumberKey(this);" >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="170px" />
                                       </asp:TemplateField>

                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                                
                                <br />
                                   <label id="Label4" for="exampleInputEmail1" class="form-label" runat="server">KEY STATUS</label>
                                <asp:GridView ID="GridKeyStatus" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Key Name" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Name") %>' Width="150"></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Count" ItemStyle-Width="250">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Count" runat="server" Width="250" Text='<%# Eval("Status") %>' >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="250px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Missing" ItemStyle-Width="200">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Mis" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="200px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="200">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="200" Text='<%# Eval("Remarks") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="200px" />
                                       </asp:TemplateField>

                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>

                                <br />
                             <label id="Label9" for="exampleInputEmail1" class="form-label" runat="server">REGISTERS</label>
                                <asp:GridView ID="GridRegisters" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Updating Registers" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Upd" runat="server" Text='<%# Eval("Name") %>' Width="150"></asp:Label>
                                           </ItemTemplate>
                                       <ItemStyle Width="150px"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Status" ItemStyle-Width="250">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Status" runat="server" Width="250" Text='<%# Eval("Status") %>' >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="250px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="200">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="200px" />
                                       </asp:TemplateField>
 
                                      <%-- <asp:TemplateField ItemStyle-Width="100" ShowHeader="False">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lnk_select" runat ="server" CommandArgument='<%#Eval("AMB_CONDTNID")%>' Text ='Select' CommandName ="Select">
                                                   </asp:LinkButton>
                                           </ItemTemplate>
                                       </asp:TemplateField>--%>
                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                                <br />
                                <label id="Label3" for="exampleInputEmail1" class="form-label" runat="server">ASSET VERIFICATION</label>
                                    <br />
                                <label id="Label5" for="exampleInputEmail1" class="form-label" runat="server">MISSING ASSET</label>
    <asp:gridview ID="GridMisAsset"  runat="server"  ShowFooter="true"  
                             AutoGenerateColumns="false"  
                             OnRowCreated="Gridview1_RowCreated">  
    <Columns>  
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="False"/>  
        <asp:TemplateField HeaderText="Asset ID" ItemStyle-Width="250">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_asset" runat="server" Width="250" Text='<%# Eval("Name") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Item" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_item" runat="server" Width="200" Text='<%# Eval("Status") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Make" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_make" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Model" ItemStyle-Width="200">  
            <ItemTemplate>  
                <asp:TextBox ID="txt_model" runat="server" Width="200" Text='<%# Eval("Remarks") %>'>
                 </asp:TextBox>  
            </ItemTemplate>  
        
          
            <FooterStyle HorizontalAlign="Right" />  
            <FooterTemplate>  
                <asp:Button ID="ButtonAdd" runat="server"   
                                     Text="Add New Row"   
                                     onclick="ButtonAdd_Click" />  
            </FooterTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField>  
            <ItemTemplate>  
                <asp:LinkButton ID="LinkButton1" runat="server"   
                                        onclick="LinkButton1_Click">Remove</asp:LinkButton>  
            </ItemTemplate>  
        </asp:TemplateField>  
    </Columns>  
    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
</asp:gridview>  
                            <br />
                                <label id="Label6" for="exampleInputEmail1" class="form-label" runat="server">DAMAGE ASSET</label>

                             <asp:gridview ID="GridDamageAset"  runat="server"  ShowFooter="true"  
                             AutoGenerateColumns="false"  
                             OnRowCreated="Gridview2_RowCreated">  
    <Columns>  
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="False"/>  
        <asp:TemplateField HeaderText="Asset ID" ItemStyle-Width="250">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_asset" runat="server" Width="250" Text='<%# Eval("Name") %>' >
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Item" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_item" runat="server" Width="200" Text='<%# Eval("Status") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Make" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_make" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Model" ItemStyle-Width="200">  
            <ItemTemplate>  
                <asp:TextBox ID="txt_model" runat="server" Width="200" Text='<%# Eval("Remarks") %>'>
                 </asp:TextBox>  
            </ItemTemplate>  
        
          
            <FooterStyle HorizontalAlign="Right" />  
            <FooterTemplate>  
                <asp:Button ID="ButtonAdd" runat="server"   
                                     Text="Add New Row"   
                                     onclick="ButtonAdd_Click1" />  
            </FooterTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField>  
            <ItemTemplate>  
                <asp:LinkButton ID="LinkButton1" runat="server"   
                                        onclick="LinkButton1_Click1">Remove</asp:LinkButton>  
            </ItemTemplate>  
        </asp:TemplateField>  
    </Columns>  
    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
</asp:gridview>
                             <br />
                                <label id="Label7" for="exampleInputEmail1" class="form-label" runat="server">EXCESS ASSET</label>

                             <asp:gridview ID="GridExcessAst"  runat="server"  ShowFooter="true"  
                             AutoGenerateColumns="false"  
                             OnRowCreated="Gridview3_RowCreated">  
    <Columns>  
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="False" />  
        <asp:TemplateField HeaderText="Asset ID" ItemStyle-Width="250">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_asset" runat="server" Width="250" Text='<%# Eval("Name") %>' >
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Item" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_item" runat="server" Width="200" Text='<%# Eval("Status") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Make" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_make" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Model" ItemStyle-Width="200">  
            <ItemTemplate>  
                <asp:TextBox ID="txt_model" runat="server" Width="200" Text='<%# Eval("Remarks") %>'>
                 </asp:TextBox>  
            </ItemTemplate>  
        
          
            <FooterStyle HorizontalAlign="Right" />  
            <FooterTemplate>  
                <asp:Button ID="ButtonAdd" runat="server"   
                                     Text="Add New Row"   
                                     onclick="ButtonAdd_Click2" />  
            </FooterTemplate>  
        </asp:TemplateField>


        <asp:TemplateField>  
            <ItemTemplate>  
                <asp:LinkButton ID="LinkButton1" runat="server"   
                                        onclick="LinkButton1_Click2">Remove</asp:LinkButton>  
            </ItemTemplate>  
        </asp:TemplateField>  
    </Columns> 
    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
</asp:gridview>

                             <br />
                                <label id="Label8" for="exampleInputEmail1" class="form-label" runat="server">BANK RECONCILIATION</label>

                             <asp:gridview ID="GridBank"  runat="server"  ShowFooter="true"  
                             AutoGenerateColumns="false"  
                             OnRowCreated="Gridview4_RowCreated">  
    <Columns>  
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="False" />  
        <asp:TemplateField HeaderText="Asset ID" ItemStyle-Width="250">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_Name" runat="server" Width="250" Text='<%# Eval("Name") %>' >
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Item" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_item" runat="server" Width="200" Text='<%# Eval("Status") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Make" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_make" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
               </asp:TextBox>
            </ItemTemplate>  
  
            <FooterStyle HorizontalAlign="Right" />  
            <FooterTemplate>  
                <asp:Button ID="ButtonAdd" runat="server"   
                                     Text="Add New Row"   
                                     onclick="ButtonAdd_Click3" />  
            </FooterTemplate>  
        </asp:TemplateField>


        <asp:TemplateField>  
            <ItemTemplate>  
                <asp:LinkButton ID="LinkButton1" runat="server"   
                                        onclick="LinkButton1_Click3">Remove</asp:LinkButton>  
            </ItemTemplate>  
        </asp:TemplateField>  
    </Columns> 
    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
</asp:gridview>

                                                         <br />
                                <label id="Label10" for="exampleInputEmail1" class="form-label" runat="server">DOCTORS AVAILABILITY</label>

                             <asp:gridview ID="GridDoctors"  runat="server"  ShowFooter="true"  
                             AutoGenerateColumns="false"  
                             OnRowCreated="Gridview5_RowCreated">  
    <Columns>  
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="False" />  
        <asp:TemplateField HeaderText="Name" ItemStyle-Width="250">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_Name" runat="server" Width="250" Text='<%# Eval("Name") %>' >
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Department" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_dept" runat="server" Width="200" Text='<%# Eval("Status") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Specialist" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_Spcl" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
               </asp:TextBox>
            </ItemTemplate>  
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Visit Day" ItemStyle-Width="200">  
            <ItemTemplate>  
               <asp:TextBox ID="txt_Remarks" runat="server" Width="200" Text='<%# Eval("Remarks") %>'>
               </asp:TextBox>
            </ItemTemplate>  
  
            <FooterStyle HorizontalAlign="Right" />  
            <FooterTemplate>  
                <asp:Button ID="ButtonAdd" runat="server"   
                                     Text="Add New Row"   
                                     onclick="ButtonAdd_Click4" />  
            </FooterTemplate>  
        </asp:TemplateField>


        <asp:TemplateField>  
            <ItemTemplate>  
                <asp:LinkButton ID="LinkButton1" runat="server"   
                                        onclick="LinkButton1_Click4">Remove</asp:LinkButton>  
            </ItemTemplate>  
        </asp:TemplateField>  
    </Columns> 
    <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
</asp:gridview>
                              <br />
                            <label id="Label11" for="exampleInputEmail1" class="form-label" runat="server">VERTICAL WISE STATUS</label>
                                <asp:GridView ID="GridVertical" runat="server"  Width="880px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" BorderStyle="Solid">
                                <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Service" ItemStyle-Width="150">
                                           <ItemTemplate>
                                               <asp:Label ID="lbl_Service" runat="server" Text='<%# Eval("Name") %>' Width="150"></asp:Label>
                                           </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Machine Status" ItemStyle-Width="250">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_MStatus" runat="server" Width="250" Text='<%# Eval("Status") %>' >
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="250px" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Working Condition" ItemStyle-Width="200">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_WrkCondtn" runat="server" Width="200" Text='<%# Eval("Diff") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="200px" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="200">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txt_Remarks" runat="server" Width="200" Text='<%# Eval("Remarks") %>'>
                                               </asp:TextBox>
                                           </ItemTemplate>
                                           <ItemStyle Width="200px" />
                                       </asp:TemplateField>

                                    </Columns>
                                 
                                   <HeaderStyle BackColor="#1C5E55" ForeColor="White" />
                                   <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>

                                <br />
                            <script type="text/javascript" charset="utf-8">

                                 function isNumberKey(evt) {
                                     var charCode = (evt.which) ? evt.which : evt.keyCode;
                                     if (charCode != 46 && charCode > 31
                                         && (charCode < 48 || charCode > 57))
                                         return false;

                                     return true;
                                 }
                            </script>
                            <br /><br />
                            <asp:Button ID="Btn_Submit1" class="btn btn-primary" runat="server" Text="Confirm" BackColor="#1C5E55" Visible="false" OnClick="Btn_Submit1_Click"/>
                            <asp:Button ID="Btn_Submit2" class="btn btn-primary" runat="server" Text="Confirm" BackColor="#1C5E55" OnClick="Btn_Submit2_Click" />

                         </div>
                    </div>
                </div>
             </div>
</asp:Content>
