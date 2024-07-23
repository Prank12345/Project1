<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="FrogotPassword" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>AdminLTE 3 | Log in</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <!-- Font Awesome -->
  
    <link href="Center/plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="Center/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="Center/dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition login-page">
    
        <div class="login-box">
  <div class="login-logo">
    <a href="CenterLogin.aspx"><b>NPCVB <br />Skill Development</b></a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">You are only one step a way from your new password, recover your password now.</p>

      <form action="../../index3.html" method="post" runat="server">
        <div class="input-group mb-3">
          <%--<input type="email" class="form-control" placeholder="Email">--%>
        <asp:TextBox ID="txtid" CssClass="form-control" required placeholder="Center ID" runat="server"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <%--<input type="password" class="form-control" placeholder="Password">--%>
            <asp:TextBox ID="txtemail" CssClass="form-control" required placeholder="Email" runat="server"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <%--<div class="icheck-primary">
              <%--<input type="checkbox" id="remember">--%>
              <%--<label for="remember">
                Remember Me
              </label>--%>
            <%--</div>--%>
          </div>
          <!-- /.col -->
          <div class="col-12">
            <%--<button type="submit" class="btn btn-primary btn-block">Sign In</button>--%>
              <asp:Button ID="btnsubmit" CssClass="btn btn-primary btn-block" runat="server" Text="Send Password" OnClick="btnsubmit_Click"/>
          </div>
          <!-- /.col -->
        </div>
      </form>

    
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->
</body>
   
</html>
