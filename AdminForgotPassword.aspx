<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminForgotPassword.aspx.cs" Inherits="AdminForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="SuperAdminBackend/plugins/fontawesome-free/css/all.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="SuperAdminBackend/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="SuperAdminBackend/dist/css/adminlte.min.css">
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
   <div class="login-box">
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
      <a href="AdminLogin.aspx" class="h1" ><b>NPCVB</b><br /><span class="h3"> Skill Development </span></a>
    </div>
    <div class="card-body">
      <p class="login-box-msg">You are only one step a way from your new password, recover your password now.</p>
      <form>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email ID"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-mail-bulk"></span>
            </div>
          </div>
        </div>       
        <div class="row">
          <div class="col-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-block" runat="server" Text="Send New Password" OnClick="btnSubmit_Click" />
          </div>
          <!-- /.col -->
        </div>
      </form>

      <p class="mt-3 mb-1">
        <a href="AdminLogin.aspx">Back</a>
      </p>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="SuperAdminBackend/plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="SuperAdminBackend/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="SuperAdminBackend/dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
