<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-8 col-md-8 mt-2" id="div1" runat="server">

                </div>
            </div>
        </div>
        <asp:Button ID="btn" runat="server" Text="send" OnClick="btn_Click" />
     <%--<asp:PlaceHolder id="placeholder1" runat="server"></asp:PlaceHolder>
                    <asp:Button ID="btnAddSubject" CssClass="" runat="server" Text="Add" OnClick="btnAddSubject_Click"/>--%>
    </div>
    </form>
</body>
</html>
