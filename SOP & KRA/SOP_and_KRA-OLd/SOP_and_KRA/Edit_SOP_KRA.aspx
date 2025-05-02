<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit_SOP_KRA.aspx.cs" Inherits="SOP_and_KRA.Edit_SOP_KRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
  <div class="col-xl-12">
    <!-- Basic Examples -->
    <div class="card card-default">
      <div class="card-header">
        <h2>UPDATE SOP AND KRA</h2>
      </div>
      <div class="card-body">
        <div class="collapse" id="collapse-basic-input">
          <pre class="language-html mb-4">
          </pre>
        </div>
          <div class="form-group">
            <label for="exampleFormControlInput2">Department</label>
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
          </div>
          <div class="form-group">
            <label for="exampleFormControlPassword">Designation</label>
            <asp:DropDownList ID="ddl_designation" runat="server" CssClass="form-control"></asp:DropDownList>
          </div>

          <div class="row">
          <div class="col-sm-6">
              <div class="form-group">
                  <label for="exampleFormControlPassword">Select Update Type</label>
                  <asp:DropDownList ID="ddl_update" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem>---Select---</asp:ListItem>
                      <asp:ListItem>Update SOP</asp:ListItem>
                      <asp:ListItem>Update KRA</asp:ListItem>
                      <asp:ListItem>Update Both SOP and KRA</asp:ListItem>
                  </asp:DropDownList>
              </div>
            </div>
              </div>

          <div class="row">
            <div class="col-sm-6" runat="server" id="div_sop">
              <div class="form-group">
                <label for="exampleFormControlPassword">Upload SOP</label>
                <asp:FileUpload ID="file_sop" runat="server" CssClass="form-control-file form-control" />
              </div>
            </div>
            <div class="col-sm-6" runat="server" id="div_kra">
              <div class="form-group">
                <label for="exampleFormControlPassword">Upload KRA</label>
                <asp:FileUpload ID="file_kra" runat="server" CssClass="form-control-file form-control" />
              </div>
            </div>
          </div>

          <div class="form-footer mt-6">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-pill" Text="SUBMIT" OnClick="Button1_Click"/>
            <%--<button type="submit" class="btn btn-primary btn-pill">Submit</button>
            <button type="submit" class="btn btn-light btn-pill">Cancel</button>--%>
          </div>

      </div>
    </div>
      </div>


  </div>
</asp:Content>
