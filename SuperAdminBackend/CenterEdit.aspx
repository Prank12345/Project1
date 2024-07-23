<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="CenterEdit.aspx.cs" Inherits="SuperAdminBackend_CenterEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Change Center Details</h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
            <div class="container-fluid">
        
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span style="">Full Name</span>
            </div>
            <div class="col-lg-6 col-6">
                <span style="">Enter Email-ID </span>
            </div>
        </div>
     
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtname" CssClass="form-control" required placeholder="Full Name*" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtemail" CssClass="form-control" required placeholder="Enter Email*" runat="server"></asp:TextBox>
                <asp:HiddenField ID="hfID" runat="server" />
            </div>
        </div>
           <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span>Full Adhaar Card*</span>
            </div>
            <div class="col-lg-6 col-6">
                <span>Passport Size Photo*</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <asp:Image ID="imgAadhar" runat="server" style="width:200px;height:200px;" />
                <asp:Label ID="lblAadhar" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuAdhaar" CssClass="form-control-file" runat="server" />
            </div>
            <div class="col-lg-6 col-6">
                 <asp:Image ID="imgPic" runat="server" style="width:200px;height:200px;" />
                <asp:Label ID="lblPic" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuPhoto" CssClass="form-control-file" runat="server" />
            </div>
        </div>
         <div class="row mt-3">
           <div class="col-lg-6 col-6">
                <span style="">Signature</span>
            </div>
              <div class="col-lg-6 col-6">
                <span style="">Name of Institute</span>
            </div>
             </div>
        
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                 <asp:Image ID="imgSign" runat="server" style="width:200px;height:100px;" />
                <asp:Label ID="lblSign" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuSign" CssClass="form-control-file" runat="server" />
            </div>
        <div class="col-lg-6 col-6">
            <asp:TextBox ID="txtinstit" CssClass="form-control" required placeholder="Name of Institute*" runat="server"></asp:TextBox>
        </div>
            </div>
          <div class="row mt-3">
            <div class="col-lg-12 col-12">
                <span style="">Full Address</span>
            </div>
          <div class="col-lg-12 col-12"><asp:TextBox ID="txtaddress" required CssClass="form-control" TextMode="MultiLine" placeholder="Address of Your Center*" runat="server"></asp:TextBox>
            </div>
        </div>
       
        <div class="row mt-3">
           
            <div class="col-lg-6 col-6">
                <span style="">Pin Code</span>
            </div>
            <div class="col-lg-6 col-6">
                <span style="">State</span>
            </div>

        </div>
         <div class="row mt-3">
            
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtpin" CssClass="form-control" required placeholder="PinCode*" runat="server"></asp:TextBox>
            </div>
             <div class="col-lg-6 col-6">
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
            <div class="col-lg-6 col-6">
                <span style="">Total Number of P.C.</span>
            </div>
            <div class="col-lg-6 col-6">
                <span style="">Staffs</span>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtpcs" CssClass="form-control" required placeholder="Total no. of PC's*" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtstaff" CssClass="form-control" required placeholder="Staffs*" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span style="">Qualification</span>
            </div>
            <div class="col-lg-6 col-6">
               <span style="">Total Number of Practical Labs</span> 
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtQualification" CssClass="form-control" required placeholder="Qualification*" runat="server"></asp:TextBox>
            </div>
           
            <div class="col-lg-6 col-6">
                 <asp:TextBox ID="txtTotalPracticalLab" CssClass="form-control" required placeholder="Total no. of Practical Lab*" runat="server"></asp:TextBox>
                 
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span style="">Qualification Certificate (Graduation)</span>
            </div>
            <div class="col-lg-6 col-6">
                <span style="">Practical Lab Picture</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
               <asp:Image ID="imgMarksheet" runat="server" style="width:200px;height:200px;" />
                <asp:Label ID="lblMarksheet" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuMarsht" CssClass="form-control-file" runat="server" />
            </div>
            <div class="col-lg-6 col-6">
                 <asp:Image ID="imgLab" runat="server" style="width:200px;height:200px;" />
                <asp:Label ID="lblLab" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuLab" CssClass="form-control-file" runat="server" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span style="">Total Number of Theory Rooms</span>
            </div>
            <div class="col-lg-6 col-6">
               <span style="">Office?*</span> 
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtTotalTheoryRoom" CssClass="form-control" required placeholder="Total no. of Theory Room*" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-6">
                <asp:RadioButtonList ID="rblOffice" runat="server" RepeatDirection="Horizontal" reqiuired CellPadding="1">
                    
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
                
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span style="">Theory Room Picture</span>
            </div>
            <div class="col-lg-6 col-6">
                <span style="">Office Picture</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                 <asp:Image ID="imgRoom" runat="server" style="width:200px;height:200px;" />
                <asp:Label ID="lblRoom" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuRoom" CssClass="form-control-file" runat="server" />
            </div>
            <div class="col-lg-6 col-6">
                 <asp:Image ID="imgOffice" runat="server" style="width:200px;height:200px;"  />
                <asp:Label ID="lblOffice" runat="server"></asp:Label><br />
                <asp:FileUpload ID="fuOffice" CssClass="form-control-file" runat="server" />
            </div>
        </div>
           <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <span style="">Toilet?*</span>
            </div>
            <div class="col-lg-6 col-6">
                <span style="">Work Experience</span>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-lg-6 col-6">
                <asp:RadioButtonList ID="rblToilet" runat="server" RepeatDirection="Horizontal" reqiuired CellPadding="1">
                    
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-lg-6 col-6">
                <asp:TextBox ID="txtWorkExp" runat="server" required CssClass="form-control" placeholder="Work Experience*"></asp:TextBox>
            </div>
        </div>
      
            
            <div class="row mt-3">
            <div class="col-lg-12 col-12">
                Order Sequence For Best Perfomer
            </div>
            <div class="col-lg-12 col-12">
                <asp:TextBox ID="txtPerform" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
       
        <div class="row mt-3 mb-3">
            <div class="col-lg-6 col-6"><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="form-control btn-success" OnClick="btnUpdate_Click"/></div>
             <div class="col-lg-6 col-6"><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="form-control btn-danger" OnClick="btnBack_Click"/></div>
        </div>
    </div>
      </section>
        </div>
</asp:Content>

