<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PurchaseCommittee.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="main-content">
        <div class="row">
            <div class="col-lg-4">
                <div class="card">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-layout-grid2 color-pink border-pink"></i>
                        </div>
                        <div class="stat-content dib">
                            <div class="stat-text"><asp:LinkButton ID="LinkBtn_system" runat="server" OnClick="Pending_Click">Requested</asp:LinkButton></div>
                            <div class="stat-digit"><asp:Label ID="lbl_requested" runat="server"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="color-primary border-primary ti-calendar"></i>
                        </div>
                        <div class="stat-content dib">
                            <div class="stat-text"><asp:LinkButton ID="LinkBtn_manufacture" runat="server" OnClick="Scheduled_Click">Scheduled</asp:LinkButton></div>
                            <div class="stat-digit"><asp:Label ID="lbl_scheduled" runat="server"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>                        
            <div class="col-lg-4">
                <div class="card">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="color-danger border-danger ti-close"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text"><asp:LinkButton ID="LinkBtn_expiry" runat="server" OnClick="rejected_Click">Rejected</asp:LinkButton></div>
                            <div class="stat-digit"><asp:Label ID="lbl_rejected" runat="server"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>                    
    </section>

</asp:Content>
