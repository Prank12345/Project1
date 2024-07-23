<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentCertificate.aspx.cs" Inherits="SuperAdminBackend_StudentCertificate" %>

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
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnSave" runat="server" Text="Generate Cetificate PDF" OnClick="btnSave_Click" />
                <asp:Button ID="btnMark" runat="server" Text="Generate Marksheet PDF" OnClick="btnMark_Click" />
                <asp:Button ID="BtnNoc" runat="server" Text="Generate NOC PDF" OnClick="BtnNoc_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <asp:Label ID="lblCenterName" runat="server"></asp:Label>
            </div>
             <div class="col-6">
                <asp:Label ID="lblCenterAddress" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblStudentName" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblFathersName" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblMothersName" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblDate1" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblDate2" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblEnrollmentNumber" runat="server"></asp:Label>
            </div>
             <div class="col-6">
                <asp:Label ID="lblRollNumber" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="imgStudentImg" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="imgCenterSign" runat="server" ></asp:Label>
            </div>
          <div class="col-6">
                <asp:Label ID="lblDOB" runat="server" ></asp:Label>
            </div>
             <div class="col-6">
                <asp:Label ID="lblDuration" runat="server" ></asp:Label>
            </div>
             <div class="col-6">
                <asp:Label ID="lblCourseName" runat="server" ></asp:Label>
            </div>
              <div class="col-6">
                <asp:Label ID="lblCourseType" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemester" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemesterName1" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemesterName2" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemesterName3" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemesterName4" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemesterName5" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblSemesterName6" runat="server" ></asp:Label>
            </div>
                <div class="col-6">
                <asp:Label ID="lblTotSem1MArks" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblTotSem2MArks" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblTotSem3MArks" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblTotSem4MArks" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblTotSem5MArks" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblTotSem6MArks" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblOBMArks1" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblOBMArks2" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblOBMArks3" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblOBMArks4" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblOBMArks5" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblOBMArks6" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblGTot" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblGObtTot" runat="server" ></asp:Label>
            </div>
             <div class="col-6">
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </div>
             <div class="col-6">
                <asp:Label ID="lblSpace" runat="server"></asp:Label>
            </div>
        </div>
       </div>
    </form>
</body>
</html>
