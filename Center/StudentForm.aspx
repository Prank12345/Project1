<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentForm.aspx.cs" Inherits="Center_StudentForm" %>

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
                <asp:Button ID="btnSave" runat="server" Text="Generate Student Form" OnClick="btnSave_Click"/>
            </div>
        </div>
        <div class="row">
           
            <div class="col-6">
                name: 
                <asp:Label ID="lblStudentName" runat="server"></asp:Label>
            </div>
           
           <div class="col-6">
               enrollment number: 
                <asp:Label ID="lblStudentID" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Center Name: 
                <asp:Label ID="lblCenterName" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Center Sign: 
                <asp:Label ID="lblSign" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Session: 
                <asp:Label ID="lblDate1" runat="server"></asp:Label>
            </div>
            <div class="col-6"> from: 
                <asp:Label ID="lblDate2" runat="server"></asp:Label>
            </div>
          
            <div class="col-6">
                Image: 
                <asp:Label ID="imgStudentImg" runat="server" ></asp:Label>
            </div>
         
             <div class="col-6">
                 Course: 
                <asp:Label ID="lblCourse" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                 Academy devision: 
                <asp:Label ID="lblCourseType" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                Address: 
                <asp:Label ID="lblAddress" runat="server" ></asp:Label>
            </div>


            <div class="col-6">
               Father name: 
                <asp:Label ID="lblFname" runat="server"></asp:Label>
            </div>
           
           <div class="col-6">
              Mother Name:
                <asp:Label ID="lblMName" runat="server"></asp:Label>
            </div>
            <div class="col-6">
               D O B
                <asp:Label ID="lblDOB" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Contact Number: 
                <asp:Label ID="lblMobile" runat="server"></asp:Label>
            </div>
            <div class="col-6"> Father Occupation": 
                <asp:Label ID="lblFJob" runat="server"></asp:Label>
            </div>
          
            <div class="col-6">
                Caste: 
                <asp:Label ID="lblCaste" runat="server" ></asp:Label>
            </div>
         
             <div class="col-6">
                 Gender: 
                <asp:Label ID="lblGender" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                Adhar Num: 
                <asp:Label ID="lblAadhar" runat="server" ></asp:Label>
            </div>
            <div class="col-6">
                Course Code: 
                <asp:Label ID="lblCode" runat="server"></asp:Label>
            </div>
           
           <div class="col-6">
               Email
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Category
                <asp:Label ID="lblCategoryBPL" runat="server"></asp:Label>
                <asp:Label ID="lblCategoryPH" runat="server"></asp:Label>
            </div>
            <div class="col-6">
                Course Duration: 
                <asp:Label ID="lblDuration" runat="server"></asp:Label>
                <asp:Label ID="lblTime" runat="server"></asp:Label>

            </div>
            <div class="col-6"> Medium": 
                <asp:Label ID="lblMEdium" runat="server"></asp:Label>
            </div>
                  <div class="col-6">
                      Marks Obtained
                      <asp:Label ID="lblOM10" runat="server"></asp:Label>
                      <asp:Label ID="lblOM12" runat="server"></asp:Label>
                      <asp:Label ID="lblOMGrads" runat="server"></asp:Label>
                      <asp:Label ID="lblOth" runat="server"></asp:Label>
                  </div> 
             <div class="col-6">
                      Grade
                      <asp:Label ID="lblGr10" runat="server"></asp:Label>
                      <asp:Label ID="lblGr12" runat="server"></asp:Label>
                      <asp:Label ID="lblGrGrads" runat="server"></asp:Label>
                      <asp:Label ID="lblGroth" runat="server"></asp:Label>
                  </div>    
            <div class="col-6">
                      Passing Year
                      <asp:Label ID="lblPass10" runat="server"></asp:Label>
                      <asp:Label ID="lblPass12" runat="server"></asp:Label>
                      <asp:Label ID="lblPassGrads" runat="server"></asp:Label>
                      <asp:Label ID="lblPassOth" runat="server"></asp:Label>
                  </div>
             <div class="col-6">
                      Board/University
                      <asp:Label ID="lblBoard10" runat="server"></asp:Label>
                      <asp:Label ID="lblBoard12" runat="server"></asp:Label>
                      <asp:Label ID="lblBoard1Grads" runat="server"></asp:Label>
                      <asp:Label ID="lblBoardOth" runat="server"></asp:Label>
                  </div>
        </div>
       </div>
    </form>
</body>
</html>
