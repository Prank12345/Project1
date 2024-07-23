<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test3.aspx.cs" Inherits="test3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/1120310c44.js" crossorigin="anonymous"></script>
    <link rel="preconnect" href="https://fonts.gstatic.com">
     <link href="https://fonts.googleapis.com/css2?family=Philosopher&display=swap" rel="stylesheet">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <asp:Panel ID="pnlPerson" runat="server">
    <table border="1" style="font-family: Arial; font-size: 10pt; width: 200px;background-image:url('../templateImage/usman%20bhai%20certificate.jpg'); background-repeat:no-repeat;background-size:contain;">
        <tr>
            <td colspan="2" style="background-color: #18B5F0; height: 18px; color: White; border: 1px solid white">
                <b>Personal Details</b>
            </td>
        </tr>
        <tr>
            <td><b>Name:</b></td>
            <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Age:</b></td>
            <td><asp:Label ID="lblAge" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><b>City:</b></td>
            <td><asp:Label ID="lblCity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Country:</b></td>
            <td><asp:Label ID="lblCountry" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
            </div>
        </form>
</body>
</html>
