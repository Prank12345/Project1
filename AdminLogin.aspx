<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NPCVB Skill Development | Login</title>
      <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
 <meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
</head>
<body>
    
  <div class="limiter">
		<div class="container-login100" style="background-image:url('GIFs/login.gif'); background-size:cover;">
           
            <div style=" position: fixed; top: 7%; font-size:25px;"> <span class="login100-form-title"> National Paramedical Council And Vocational Board Skill Development</span></div>
			<div class="wrap-login100" style="background-color:rgba(255, 255, 255, 0.3);">
               
				<div class="login100-pic js-tilt" data-tilt>
                    <a href="Default.aspx">
					<img src="Image/nlogo.png" alt="LOGO" />
                        </a>
				</div>

				<form class="login100-form validate-form" runat="server">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
					<span class="login100-form-title">
						Admin Login
					</span>
                    
					<div class="wrap-input100 validate-input" data-validate = "Valid email is required">
                        <asp:TextBox runat="server" CssClass="input100" placeholder="Email" ID="txtUserName"></asp:TextBox>
						
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-envelope" aria-hidden="true"></i>
						</span>
					</div>

					<div class="wrap-input100 validate-input" data-validate = "Password is required">
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" placeholder="Password" CssClass="input100"></asp:TextBox> 
						<%--<input class="input100" type="password" name="pass" placeholder="Password">--%>
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-lock" aria-hidden="true"></i>
						</span>
					</div>
					
					<div class="container-login100-form-btn">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login100-form-btn" OnClick="btnSignin_Click" />
						<%--<button class="login100-form-btn">
							Login
						</button>--%>
					</div>

					<div class="text-center p-t-12">
						<span class="txt1" style="color:black">
							Forgot
						</span>
						<a class="txt2" href="AdminForgotPassword.aspx" style="color:red;">
							 Password?
						</a>
					</div>
                    
					<div class="text-center p-t-136">
						
					</div>
					
				</form>
			</div>
		</div>
	</div>
    
   <!--===============================================================================================-->	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/tilt/tilt.jquery.min.js"></script>
	<script >
		$('.js-tilt').tilt({
			scale: 1.1
		})
	</script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

</body>
</html>
