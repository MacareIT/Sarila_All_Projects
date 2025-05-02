<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Add_SOP_KRA.aspx.cs" Inherits="SOP_and_KRA.Add_SOP_KRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
  <div class="col-xl-12">
    <!-- Basic Examples -->
    <div class="card card-default">
      <div class="card-header">
        <h2>ADD NEW SOP AND KRA</h2>
      </div>
      <div class="card-body">
        <div class="collapse" id="collapse-basic-input">
          <pre class="language-html mb-4">
          </pre>
        </div>
          <div class="form-group">
            <label for="exampleFormControlInput2">Department</label>
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control"></asp:DropDownList>
          </div>
          <div class="form-group">
            <label for="exampleFormControlPassword">Designation</label>
            <asp:TextBox ID="txt_designation" runat="server" CssClass="form-control"></asp:TextBox>
          </div>

          <div class="row">
            <div class="col-sm-6">
              <div class="form-group">
                <label for="exampleFormControlPassword">Upload SOP</label>
                <asp:FileUpload ID="file_sop" runat="server" CssClass="form-control-file form-control" />
              </div>
            </div>
            <div class="col-sm-6">
              <div class="form-group">
                <label for="exampleFormControlPassword">Upload KRA</label>
                <asp:FileUpload ID="file_kra" runat="server" CssClass="form-control-file form-control" />
              </div>
            </div>
          </div>

          <div class="form-footer mt-6">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-pill" Text="SUBMIT" OnClick="Button1_Click" />
            <%--<button type="submit" class="btn btn-primary btn-pill">Submit</button>
            <button type="submit" class="btn btn-light btn-pill">Cancel</button>--%>
          </div>

      </div>
    </div>
      </div>


  </div>

</asp:Content>
