<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="DistributorRegistration.aspx.cs" Inherits="DistributorRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Dosis&display=swap" rel="stylesheet">
     <style>
         .polaroid {
             box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
         
             background-image: url('Image/backgound12.png');
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
       <div class="polaroid mt-2 mb-3" style=" padding:60px;">

       
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Full Name</span><br />
                <asp:TextBox ID="txtname" CssClass="form-control" required placeholder="Full Name" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <span class="yourclass">Father's Name</span><br />
                <asp:TextBox ID="txtFatherName" CssClass="form-control" required placeholder="Enter Father's Name" runat="server"></asp:TextBox>
            </div>
        </div>
     
      
           <div class="row mt-3">
               <div class="col-6">
                <span class="yourclass"> ID-Proof</span><br />
                   <asp:DropDownList ID="ddlIdProof" required runat="server" CssClass="form-control">
                       <asp:ListItem Selected="True" disabled="disabled" Value="0" Text="--Select--"></asp:ListItem>
                       <asp:ListItem Value="1" Text="Pan Card"></asp:ListItem>
                       <asp:ListItem Value="2" Text="Adhaar Card"></asp:ListItem>
                       <asp:ListItem Value="3" Text="Passport"></asp:ListItem>
                       <asp:ListItem Value="4" Text="Driving Licence"></asp:ListItem>
                       <asp:ListItem Value="5" Text="Voter Card"></asp:ListItem>
                   </asp:DropDownList>
            </div>
            <div class="col-6">
                <span class="yourclass">Upload ID-Proof</span><br />
                 <asp:FileUpload ID="fuAdhaar" required CssClass="file-upload" runat="server" />
            </div>
            
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Passport Size Photo</span><br />
                <asp:FileUpload ID="fuPhoto" CssClass="file-upload" runat="server" />
            </div>
            <div class="col-6">
               <span class="yourclass">Cancelled Check</span><br />
                <asp:FileUpload ID="fuCancelled" CssClass="file-upload" runat="server" />
            </div>
        </div>
       
        
          
        <div class="row mt-3">  
            <div class="col-6">
                 <span class="yourclass">Date Of Birth</span><br />
                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>                     
           <div class="col-6">
               <span class="yourclass">State</span><br />
                <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
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
            <div class="col-12">
                <span class="yourclass">Full Address</span><br />
            <asp:TextBox ID="txtaddress" required CssClass="form-control" TextMode="MultiLine" placeholder="Address of Your Center" runat="server"></asp:TextBox>
            </div>
        </div>
       
         <div class="row mt-3">
            <div class="col-6">
                 <span class="yourclass">Phone Number</span><br />
                <asp:TextBox ID="txtphone" CssClass="form-control" required placeholder="Phone Number*" runat="server"></asp:TextBox>
            </div>
             <div class="col-6">
                <span class="yourclass">Enter Email-ID</span><br />
                <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Enter Email" runat="server"></asp:TextBox>
            </div>
           
        </div>
      
        <div class="row mt-3 mb-3">
            <div class="col-12"><asp:Button ID="btnregister" runat="server" Text="REGISTER" CssClass="form-control btn-primary" OnClick="btnregister_Click" />   
            </div>
        </div>
    </div>
  </div>
</asp:Content>

