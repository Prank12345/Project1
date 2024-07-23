<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="CenterRegister.aspx.cs" Inherits="CenterRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Dosis&display=swap" rel="stylesheet">
     <style>
         .polaroid {
             box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
         
             background-image: url('Image/background8.png');
             background-position:50%;
             background-repeat:no-repeat;
             background-size:cover;
             /*background-color:rgba(219, 84, 255, 0.3);*/
           
         }
             .yourclass {
    display: inline-block;
    font-size:13px;
    margin-left:7px;
    font-family: 'Libre Baskerville', serif;
    color:black;
    margin-bottom:5px;
}
             .fancy::before {
  content: "";

  position : absolute;
  z-index  : -1;
  bottom   : 15px;
  right    : 5px;
  width    : 50%;
  top      : 80%;
  max-width: 200px;

  box-shadow: 0px 13px 10px black;
  transform: rotate(4deg);
}
        .form-control{
            border-radius:20px;
            
        }
          .file-upload {
    
    font-family: Arial, Helvetica, sans-serif;
    border: 1px solid #c4c4c4;
    background: #c4c4c4;
    color: #fff;
    font-size:11px;
    padding:10px;
   
    text-shadow: #000 1px 1px 2px;
    -webkit-border-radius: 6px;
   
    
}
          
       .rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 10px;
}
        .fancy {
  position: relative;
  background-color: #FFC;
  padding: 2rem;
  text-align: center;
  max-width: 100%;
}
        div { box-sizing: border-box; }

.wrap {
  margin: 0 auto;
  width: 600px;
}

.shadow {
  position: relative;
  margin: 3em auto;
  padding-top: 2em;
  width: 100%;
  height: 100%;
  border-radius: 5px;
  background-color:rgba(175,239,254,0.3); 
  text-align: center;
  box-shadow: 0 0 25px 0 rgba(50,50,50,.3) inset;
}

.shadow:after {
  content: "";
  position: relative;
}

.curved:after, .curved-2:after {
  position: relative;
  z-index: -2;
}

.curved:after {
  position: absolute;
  top: 50%;
  left: 12px;
  right: 12px;
  bottom: 0;
  box-shadow: 0 0px 10px 7px rgba(100,100,100,0.5);
  border-radius: 450px / 15px
}

.curved-2:after {
  position: absolute;
  top: 0;
  left: 12px;
  right: 12px;
  bottom: 0;
  box-shadow: 0 0px 10px 7px rgba(100,100,100,0.5);
  border-radius: 450px / 15px;
}


 

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row mt-1 mb-2">
            <div class="col-12 m-0" style="text-align:center;">

               <img src="Image/Register-Now.gif" class="img-fluid" height="100px" />
            </div>
        </div>
         <div class="row shadow curved-2">
            
          <%--<div class="col-12" style=""><h4>Apply For Center</h4></div>--%>
            <div class="col-12 mt-2 mb-3" style="text-align:center;">
                <span style="color:black;font-size:14px; font-family: 'Dosis', sans-serif;"> Note:- </span><br />
                <span style="color:red; font-size:14px;font-family: 'Dosis', sans-serif;"><i class="fas fa-star"></i>  Mandatory Fields </span><br />
                <span style="color:#8c1be5;font-size:14px; font-family: 'Dosis', sans-serif;"><i class="fas fa-star"></i> Email-ID, Phone Number, Center Name Should Be Unique </span><br />
                <span style="color:blue;font-size:14px;font-family: 'Dosis', sans-serif;"> <i class="fas fa-star"></i> Size Of Images ( Passport Size Photo, Full Aadhar Card, Signature, Qualification Certificate ) Should Be 500kb </span><br />
                <span style="color:aqua;font-size:14px;font-family: 'Dosis', sans-serif;"><i class="fas fa-star"></i> Height And Width Of Passport Size Photo Should Be 400px X 400px </span><br />
                <span style="color:springgreen;font-size:14px;font-family: 'Dosis', sans-serif;"><i class="fas fa-star"></i> Height And Width Of Signature Image Should Be 200px X 100px </span><br />
                <span style="color:black;font-size:14px;font-family: 'Dosis', sans-serif;"> <i class="fas fa-star"></i> Full Address Character Length Should Not Exceed 75 Characters </span>
            </div>
        </div>
    </div>
    <div class="container">  
       <div class="polaroid mt-2 mb-3" style=" padding:60px;">

       
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Full Name <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Enter Email-ID<span style="color:red;"><i class="fas fa-star"></i></span> <span style="color:#8c1be5;"><i class="fas fa-star"></i></span></span>
            </div>
        </div>
     
        <div class="row mt-3">
            <div class="col-6">
                <asp:TextBox ID="txtname" CssClass="form-control" required placeholder="Full Name" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:TextBox ID="txtemail" CssClass="form-control" required placeholder="Enter Email" runat="server"></asp:TextBox>
            </div>
        </div>
           <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Full Adhaar Card<span style="color:red;"><i class="fas fa-star"></i></span> <span style="color:blue;"><i class="fas fa-star"></i></span> </span>
            </div>
            <div class="col-6">
                <span class="yourclass">Passport Size Photo<span style="color:red;"><i class="fas fa-star"></i></span> <span style="color:blue;"><i class="fas fa-star"></i></span> <span style="color:aqua;"><i class="fas fa-star"></i></span> </span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:FileUpload ID="fuAdhaar" CssClass="file-upload" required runat="server" />
            </div>
            <div class="col-6">
                <asp:FileUpload ID="fuPhoto" CssClass="file-upload" required runat="server" />
            </div>
        </div>
         <div class="row mt-3">
           <div class="col-6">
                <span class="yourclass">Signature<span style="color:red;"><i class="fas fa-star"></i></span> <span style="color:blue;"><i class="fas fa-star"></i></span> <span style="color:springgreen;"><i class="fas fa-star"></i></span> </span>
            </div>
              <div class="col-6">
                <span class="yourclass">Name of Institute<span style="color:red;"><i class="fas fa-star"></i></span> <span style="color:#8c1be5;"><i class="fas fa-star"></i></span></span>
            </div>
             </div>
        
        <div class="row mt-3">
            <div class="col-6">
                <asp:FileUpload ID="fuSign" required CssClass="file-upload" runat="server" />
            </div>
        <div class="col-6">
            <asp:TextBox ID="txtinstit" CssClass="form-control" required placeholder="Name of Institute" runat="server"></asp:TextBox>
        </div>
            </div>
          <div class="row mt-3">
            <div class="col-12">
                <span class="yourclass">Full Address<span style="color:red;"><i class="fas fa-star"></i></span><span style="color:black;"><i class="fas fa-star"></i></span></span>
            </div>
          <div class="col-12"><asp:TextBox ID="txtaddress" required CssClass="form-control" TextMode="MultiLine" placeholder="Address of Your Center" onkeypress="return this.value.length<=75" runat="server"></asp:TextBox>
            </div>
        </div>
       
        <div class="row mt-3">
           
            <div class="col-6">
                <span class="yourclass">Pin Code<span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
           <div class="col-6">
               <span class="yourclass">State<span style="color:red;"><i class="fas fa-star"></i></span></span>
           </div>
        </div>
         <div class="row mt-3">
            
            <div class="col-6">
                <asp:TextBox ID="txtpin" CssClass="form-control" required placeholder="PinCode" runat="server"></asp:TextBox>
            </div>
               <div class="col-6">
                 <asp:DropDownList ID="ddlState" CssClass="form-control" required runat="server">
                     <asp:ListItem Text="Select State" Value="0" Selected="True" Disabled="Diabled"></asp:ListItem>
                     <asp:ListItem Text="Andaman and Nicobar Island" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Andra Pradesh" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Arunachal Pradesh" Value="3"></asp:ListItem>
                     <asp:ListItem Text="Assam" Value="4"></asp:ListItem>
                     <asp:ListItem Text="Bihar" Value="5"></asp:ListItem>
                     <asp:ListItem Text="Chandigarh" Value="6"></asp:ListItem>
                     <asp:ListItem Text="Chhatisgarh" Value="7"></asp:ListItem>
                     <asp:ListItem Text="Dadar and Nagar Haveli" Value="8"></asp:ListItem>
                     <asp:ListItem Text="Daman and Diu" Value="9"></asp:ListItem>
                     <asp:ListItem Text="Delhi" Value="10"></asp:ListItem>
                     <asp:ListItem Text="Goa" Value="11"></asp:ListItem>
                     <asp:ListItem Text="Gujrat" Value="12"></asp:ListItem>
                     <asp:ListItem Text="Haryana" Value="13"></asp:ListItem>
                     <asp:ListItem Text="Himachal Pradesh" Value="14"></asp:ListItem>
                     <asp:ListItem Text="Jammu and Kashmir" Value="15"></asp:ListItem>
                     <asp:ListItem Text="Jharkhand" Value="16"></asp:ListItem>
                     <asp:ListItem Text="Karnataka" Value="17"></asp:ListItem>
                     <asp:ListItem Text="Kerala" Value="18"></asp:ListItem>
                     <asp:ListItem Text="Lakshdeep" Value="19"></asp:ListItem>
                     <asp:ListItem Text="Madhya Pradesh" Value="20"></asp:ListItem>
                     <asp:ListItem Text="Maharashtra" Value="21"></asp:ListItem>
                     <asp:ListItem Text="Manipur" Value="22"></asp:ListItem>
                     <asp:ListItem Text="Meghalaya" Value="23"></asp:ListItem>
                     <asp:ListItem Text="Mizoram" Value="24"></asp:ListItem>
                     <asp:ListItem Text="Nagaland" Value="25"></asp:ListItem>
                     <asp:ListItem Text="Odisha" Value="26"></asp:ListItem>
                     <asp:ListItem Text="Pondicherry" Value="27"></asp:ListItem>
                     <asp:ListItem Text="Punjab" Value="28"></asp:ListItem>
                     <asp:ListItem Text="Rajasthan" Value="29"></asp:ListItem>
                     <asp:ListItem Text="Sikkim" Value="30"></asp:ListItem>
                     <asp:ListItem Text="Tamil Nadu" Value="31"></asp:ListItem>
                     <asp:ListItem Text="Telangana" Value="32"></asp:ListItem>
                     <asp:ListItem Text="Tripura" Value="33"></asp:ListItem>
                     <asp:ListItem Text="Uttar Pradesh" Value="34"></asp:ListItem>
                     <asp:ListItem Text="Uttarakhand" Value="35"></asp:ListItem>
                     <asp:ListItem Text="West Bengal" Value="36"></asp:ListItem>
                 </asp:DropDownList>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Total Number of P.C.<span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Staffs<span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-6">
                <asp:TextBox ID="txtpcs" CssClass="form-control" required placeholder="Total no. of PC's" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:TextBox ID="txtstaff" CssClass="form-control" required placeholder="Staffs" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Qualification <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Qualification Certificate (Graduation)<span style="color:red;"><i class="fas fa-star"></i></span> <span style="color:blue;"><i class="fas fa-star"></i></span></span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:TextBox ID="txtQualification" CssClass="form-control" required placeholder="Qualification" runat="server"></asp:TextBox>
            </div>
           <%-- <div class="col-3">
                <span style="color:#647f96;">Qualification Certificate(Graduation) </span>
            </div>--%>
            <div class="col-6">
                <asp:FileUpload ID="fuMarsht" CssClass="file-upload" required runat="server" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Total Number of Practical Labs <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Practical Lab Picture</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:TextBox ID="txtTotalPracticalLab" CssClass="form-control" required placeholder="Total no. of Practical Lab*" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:FileUpload ID="fuLab" CssClass="file-upload" runat="server" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Total Number of Theory Rooms <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Theory Room Picture</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:TextBox ID="txtTotalTheoryRoom" CssClass="form-control" required placeholder="Total no. of Theory Room" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:FileUpload ID="fuRoom" CssClass="file-upload" runat="server" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Office? <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Office Picture</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:RadioButtonList ID="rblOffice" CssClass="yourclass rbl" runat="server" RepeatDirection="Horizontal" reqiuired CellPadding="1">
                    
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-6">
                <asp:FileUpload ID="fuOffice" CssClass="file-upload" runat="server" />
            </div>
        </div>
           <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Toilet? <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
            <div class="col-6">
                <span class="yourclass">Work Experience <span style="color:red;"><i class="fas fa-star"></i></span></span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:RadioButtonList ID="rblToilet" runat="server" CssClass="yourclass rbl" RepeatDirection="Horizontal" reqiuired CellPadding="1">
                    
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-6">
                <asp:TextBox ID="txtWorkExp" runat="server" required CssClass="form-control" placeholder="Work Experience"></asp:TextBox>
            </div>
        </div>
             <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Distributor?</span>
            </div>
            <div class="col-6">
                <asp:Label ID="lbldistNum" runat="server" CssClass="yourclass">Referal Code<span style="color:red;"><i class="fas fa-star"></i></span></asp:Label>
            </div>
        </div>
             <div class="row mt-3">
            <div class="col-6">
                <asp:RadioButtonList ID="rblDistributor" runat="server" CssClass="yourclass rbl" RepeatDirection="Horizontal" CellPadding="1" AutoPostBack="true" OnSelectedIndexChanged="rblDistributor_SelectedIndexChanged">
                    
                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-6">
                <asp:TextBox ID="txtDistNumber" runat="server" CssClass="form-control" placeholder="Referal Code"></asp:TextBox>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-6">
                <asp:TextBox ID="txtphone" CssClass="form-control" required placeholder="Phone Number*" runat="server"></asp:TextBox>
            </div>
            
            <%--<div class="col-4">
                <asp:TextBox ID="txtvafify" CssClass="form-control" required placeholder="Varification Code*" runat="server"></asp:TextBox>
            </div>
                <div class="col-2">
                  <asp:Button ID="btnotp" runat="server" Text="Send OTP" CssClass="form-control btn-warning" />
              </div>--%>
        </div>
        <div class="row mt-3">
            <div class="col-12">
                <asp:CheckBox ID="CheckBox1" runat="server" />
               <span style="color:white;">I agreed to all <a href="TermsAndCondition.aspx" style="text-decoration:none;color:red;">TERMS & CONDITIONS</a> &<a href="PrivacyPolicy.aspx" style="text-decoration:none;color:red;"> PRIVACY POLICY </a> of NATIONAL PARAMEDICAL COUNCIL AND VOCATIONAL BOARD SKILL DEVELOPEMENT</span>
            </div>
        </div>
        <div class="row mt-3 mb-3">
            <div class="col-12"><asp:Button ID="btnregister" runat="server" Text="REGISTER" CssClass="form-control btn-primary" OnClick="btnregister_Click" />   
            </div>
        </div>
    </div>
  </div>
</asp:Content>

