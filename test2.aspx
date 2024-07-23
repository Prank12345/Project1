<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnlTextBoxes" runat="server">
</asp:Panel>
<hr />
<asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="AddTextBox" />
<asp:Button ID="btnGet" runat="server" Text="Get Values" OnClick="GetTextBoxValues" />
    </div>
    </form>
</body>
</html>
