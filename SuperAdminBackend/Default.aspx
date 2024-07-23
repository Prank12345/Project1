<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SuperAdminBackend_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="container-fluid">
            <div class="row">
                <div class="col-lg-8 col-md-8 mt-2" id="div1" runat="server">

                </div>
            </div>
          <div class="row mb-2">
                            <div class="col-lg-2"></div>
                                  <div class="col-lg-4 col-sm-6">
                  
                      <asp:Button ID="btnAdd" runat="server" Text="Add Subject+" CssClass="btn btn-warning btn-block" OnClick="AddTextBox" />
            </div>
                 <div class="col-lg-4 col-sm-6">
                      <asp:Button ID="btnRemove" causesvalidation="false" runat="server" Text="Remove subject-" CssClass="btn btn-danger btn-block" OnClick="btnRemove_Click" />
            </div>
                              <div class="col-lg-2"></div>
                  </div>
        </div>

    </div>
    </form>
</body>
</html>
