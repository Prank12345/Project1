<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CenterForm.aspx.cs" Inherits="SuperAdminBackend_CenterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/1120310c44.js" crossorigin="anonymous"></script>
    <link rel="preconnect" href="https://fonts.gstatic.com">
     <link href="https://fonts.googleapis.com/css2?family=Philosopher&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnSave" runat="server" Text="Generate Form" OnClick="btnSave_Click"/>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
               Center ID: 
                <asp:Label ID="lblCenterID" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Center name: 
                <asp:Label ID="lblCenterName" runat="server"></asp:Label>
            </div>
           
           <div class="col-6">
              Center Head Name
                <asp:Label ID="lblCenterHeadName" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Center Head Photo: 
                <asp:Label ID="lblCenterHeadPhoto" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Center Head Sign: 
                <asp:Label ID="lblSign" runat="server"></asp:Label>
            </div>
            <div class="col-6"> Address: 
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </div>
          
            <div class="col-6">
                State: 
                <asp:Label ID="lblState" runat="server" ></asp:Label>
            </div>
         
             <div class="col-6">
                 Pin Code: 
                <asp:Label ID="lblPinCode" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                Email: 
                <asp:Label ID="lblEmail" runat="server" ></asp:Label>
            </div>


            <div class="col-6">
               Phone Number: 
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </div>
           
           <div class="col-6">
            Staff
                <asp:Label ID="lblStaff" runat="server"></asp:Label>
            </div>
             <div class="col-6">
            Computers
                <asp:Label ID="lblComp" runat="server"></asp:Label>
            </div>

              <div class="col-6">
          join date
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </div>

            <%-- <div class="col-6">
         Sign
                <asp:Label ID="lblSign" runat="server"></asp:Label>
            </div>--%>
            
                      
        </div>
       </div>
    </form>
</body>
</html>
