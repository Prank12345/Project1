<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditDistributor.aspx.cs" Inherits="SuperAdminBackend_EditDistributor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content Header (Page header) -->
     <div class="content-wrapper">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Change Distributor Details</h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
            <div class="container-fluid">
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Full Name</span><br />
                <asp:TextBox ID="txtname" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <span class="yourclass">Father's Name</span><br />
                <asp:TextBox ID="txtFatherName" CssClass="form-control" placeholder="Enter Father's Name" runat="server"></asp:TextBox>
            </div>
        </div>
     
      
           <div class="row mt-3">
               <div class="col-6">
                <span class="yourclass"> ID-Proof</span><br />
                   <asp:DropDownList ID="ddlIdProof" runat="server" CssClass="form-control">
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
                 <asp:Image ID="imgIdProof" runat="server" style="width:200px;height:200px;" /><br />
                <asp:Label ID="lblIDProof" runat="server"></asp:Label><br />
                 <asp:FileUpload ID="fuAdhaar" CssClass="file-upload" runat="server" />
            </div>
            
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Passport Size Photo</span><br />
                
                <asp:Image ID="imgPic" runat="server" style="width:200px;height:200px;" /><br />
                <asp:Label ID="lblPic" runat="server"></asp:Label><br />
               <asp:FileUpload ID="fuPhoto" CssClass="file-upload" runat="server" />
            </div>
            <div class="col-6">
               <span class="yourclass">Cancelled Check</span><br />
                 <asp:Image ID="imgCancelled" runat="server" style="width:200px;height:200px;" /><br />
                <asp:Label ID="lblCancelled" runat="server"></asp:Label><br />
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
            <asp:TextBox ID="txtaddress" CssClass="form-control" TextMode="MultiLine" placeholder="Address of Your Center" runat="server"></asp:TextBox>
            </div>
        </div>
       
         <div class="row mt-3">
            <div class="col-6">
                 <span class="yourclass">Phone Number</span><br />
                <asp:TextBox ID="txtphone" CssClass="form-control" placeholder="Phone Number" runat="server"></asp:TextBox>
            </div>
             <div class="col-6">
                <span class="yourclass">Enter Email-ID</span><br />
                <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Enter Email" runat="server"></asp:TextBox>
            </div>
           
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <span class="yourclass">Comission in (%)</span><br />
            <asp:TextBox ID="txtComission" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3 mb-3">
            <div class="col-lg-6 col-6"><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="form-control btn-success" OnClick="btnUpdate_Click"/></div>
             <div class="col-lg-6 col-6"><a class="btn form-control btn-danger" href="Dashboard.aspx">Back</a></div>
        </div>
    </div>
      </section>
        </div>
</asp:Content>

