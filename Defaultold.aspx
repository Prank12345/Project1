<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultold.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NPCVB</title>
        <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<!-- Popper JS -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>
<body >
    <form id="form1" runat="server">
    <div class="container">
    <div class="row mt-4">
        <div class="col-2">
           <a href="Default2.aspx"> <asp:Image ImageUrl="~/Image/ProjectLogo.jpeg" runat="server" style="width:50%;"/></a>
        </div>
        <div class="col-10" style="color:#050b7c; font-size:25px; text-align:center;">
            <strong>National Paramedical Council and Vocational Board <br /><span style="">Skill Development</span></strong>
        </div>
        <div class="row">
            <div class="col-8 mt-2 m-0">
            <asp:Image ImageUrl="~/Image/e-UnderConstruction.png" runat="server" style="width:90%;" />
        </div>
            <div class="col-4">
                <div class="row">
                    <div class="col-12 mt-2 m-0" style="text-align:center;">
                        <asp:Image ImageUrl="~/Image/AA.jpg" runat="server" style="width:30%;" /><br />
            <a href="AdminLogin.aspx" style="text-decoration-line:none; font-size:30px;"> Admin Login</a>
        </div>
        
        <div class="col-12 mt-2 m-0" style="text-align:center;">
             <asp:Image ImageUrl="~/Image/user-icon.jpg" runat="server" style="width:20%;" /><br />
            <a href="CenterLogin.aspx" style="text-decoration-line:none; font-size:30px;"> Center Login</a>
        </div>
      
           
         <div class="col-12 mt-2 m-0" style="text-align:center;">
             <asp:Image ImageUrl="~/Image/user-icon.jpg" runat="server" style="width:20%;" /><br />
             <a href="StudentLogin.aspx" style="text-decoration-line:none; font-size:30px;">Student Login</a>
         </div>
                </div>
            </div>
             <div class="col-12 mt-2 m-0" style="text-align:center;">
            <p><b>For Further Details Please Contact Us @9999999999</b></p>
         </div>
        </div>
        
        
        
        
        </div>
    </div>
    </form>
</body>
</html>
