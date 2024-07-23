<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feesReceipt.aspx.cs" Inherits="Center_feesReceipt" %>

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
                <asp:Button ID="btnSave" runat="server" Text="Generate Fees PDF" OnClick="btnSave_Click" />
              
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <asp:Label ID="lblStudentDetails" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblInvoiceNum" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblCenterID" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblNarration" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblAmount" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblAmtWords" runat="server"></asp:Label>
            </div>
        </div>
       </div>
    </form>
</body>
</html>
