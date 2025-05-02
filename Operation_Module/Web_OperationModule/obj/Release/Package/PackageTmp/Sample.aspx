<%@ Page Title="" Language="C#" MasterPageFile="~/Users_master.Master" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="Web_OperationModule.Sample" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row g-4">
                    <div class="col-sm-12 col-xl-6" style="width:900px;">
                        <div class="mb-3">
                            <asp:Label ID="Label1" runat="server" class="form-label" Text="Branch Name"></asp:Label>
                            <asp:DropDownList ID="cmb_branch" class="form-control" runat="server" DataTextField="Name" DataValueField="Branch_Id"></asp:DropDownList>
                            <br />
                            <asp:Label ID="Label2" runat="server" class="form-label" Text="Month"></asp:Label>
                            <asp:DropDownList ID="cmbMonth" class="form-control" runat="server" DataTextField="MonthName" DataValueField="MonthNo">
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="Label3" runat="server" class="form-label" Text="Year"></asp:Label>
                            <asp:DropDownList ID="cmbYear" class="form-control" runat="server" DataTextField="Year" DataValueField="Year">
                            </asp:DropDownList>
                            <br />
                            <asp:Button ID="BtnSubmit" class="btn btn-primary" runat="server" Text="Submit" BackColor="#1C5E55" OnClick="BtnSubmit_Click" />
                            <br /><br />
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="950px">
                                <LocalReport ReportPath="Reports\Report1.rdlc">
                                </LocalReport>
                            </rsweb:ReportViewer>
                         </div>
                    </div>
                </div>
             </div>
</asp:Content>
