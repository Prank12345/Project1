<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditStaff.aspx.cs" Inherits="SuperAdminBackend_EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style>
       .rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 10px;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
        <section class="content">
            <div class="card">
                <div class="card-body">
    <div class="container-fluid">
        <div class="row">
            
            <div class="col-8 ml-3 mt-2" style="font-size:30px;">
                Add Staff
            </div>
        </div>
      
         <div class="row mt-2">
            <div class="col-2">
                 <asp:label  runat="server" text="Initial"></asp:label>
                <asp:DropDownList ID="ddlInitial" runat="server" CssClass="form-control">
                    <asp:ListItem Text="--Select--" Selected="True" disabled="disabled"></asp:ListItem>
                    <asp:ListItem Text="Mr." Value="MR"></asp:ListItem>
                    <asp:ListItem Text="Mrs." Value="MRS"></asp:ListItem>
                    <asp:ListItem Text="Miss." Value="MISS"></asp:ListItem>
                </asp:DropDownList>
                </div>
            <div class="col-5">
                <asp:label  runat="server" text="Name"></asp:label>
                <asp:textbox ID="txtsname" placeholder="Enter Name" required cssclass="form-control" runat="server"></asp:textbox>
            </div>
         <div class="col-5">
                <asp:label  runat="server" text="Marital Status"></asp:label>
                 <asp:DropDownList ID="ddlMarital" runat="server" CssClass="form-control">
                    <asp:ListItem Text="--Select--" Selected="True" disabled="disabled"></asp:ListItem>
                    <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                    <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                    <asp:ListItem Text="Divorced" Value="Divorced"></asp:ListItem>
                     <asp:ListItem Text="Widow" Value="Widow"></asp:ListItem>
                </asp:DropDownList>
            </div>
          
        </div>
         <div class="row mt-2">
             
            <div class="col-6">
                <asp:Label ID="lblgender" runat="server" required Text="Gender"></asp:Label><br />
                <asp:RadioButtonList ID="rbgender" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                </asp:RadioButtonList>             
            </div>
      
            <div class="col-6">
                <asp:Label ID="lbldob" runat="server" Text="Date Of Birth"></asp:Label>
                <asp:TextBox ID="txtdob" TextMode="Date" required CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        
        
            <div class="col-6">
                <asp:Label ID="lglQualification" runat="server" Text="Qualification"></asp:Label>                
                <asp:TextBox ID="txtQual"  placeholder="Enter Qualification" TextMode="MultiLine" required CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            </div>
         
         
        <div class="row mt-2">
            
            <div class="col-12">
                <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="txtaddress" CssClass="form-control" required TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>
       
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblphone" runat="server" Text="Phone"></asp:Label>
                <asp:TextBox ID="txtphone" required TextMode="Number"  placeholder="Enter Phone Number" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        
            <div class="col-6">
                <asp:Label ID="lblemail" runat="server" Text="Email ID"></asp:Label>
                <asp:TextBox ID="txtemail" required  placeholder="Enter Email Address" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUsername" required  placeholder="Enter Username" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        
            <div class="col-6">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" required  placeholder="Enter Password" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblManagePopupBanner" runat="server" Text="Manage Popup Banner"></asp:Label>
                 <asp:RadioButtonList ID="rblPopUp" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                    
                </asp:RadioButtonList>   
            </div>
        
            <div class="col-6">
                 <asp:Label ID="staff" runat="server" Text="Staff Management"></asp:Label>
                 <asp:RadioButtonList ID="rblStaffMgmt" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="MainSliderImage" runat="server" Text="Main Slider Image"></asp:Label>
                 <asp:RadioButtonList ID="rblMainSliderImage" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="SlidingStatement" runat="server" Text="Sliding Statement"></asp:Label>
                 <asp:RadioButtonList ID="rblSlidingStatement" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
               <asp:Label ID="Gallery" runat="server" Text="Gallery"></asp:Label>
                 <asp:RadioButtonList ID="rblGallery" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
                <asp:Label ID="lblDownload" runat="server" Text="Download"></asp:Label>
                 <asp:RadioButtonList ID="rblDownload" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblAddFreeTest" runat="server" Text="Add Free Test"></asp:Label>
                 <asp:RadioButtonList ID="rblAddFreeTest" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                    
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="lblCenterVerification" runat="server" Text="Center Verification"></asp:Label>
                 <asp:RadioButtonList ID="rblCenterVerification" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
               <asp:Label ID="lblDistributorVerification" runat="server" Text="Distributor Verification"></asp:Label>
                 <asp:RadioButtonList ID="rblDistributorVerification" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="lblVerifyStudent" runat="server" Text="Verify Student"></asp:Label>
                 <asp:RadioButtonList ID="rblVerifyStudent" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblPendingStudent" runat="server" Text="Pending Student"></asp:Label>
                 <asp:RadioButtonList ID="rblPendingStudent" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
         <div class="col-6">
                <asp:Label ID="lblCourseType" runat="server" Text="Course Type"></asp:Label>
                 <asp:RadioButtonList ID="rblCourseType" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>

         <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="NewCourse" runat="server" Text="New Course"></asp:Label>
                 <asp:RadioButtonList ID="rblNewCourse" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="eWallet" runat="server" Text="E-Wallet"></asp:Label>
                 <asp:RadioButtonList ID="rbleWallet" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
               <asp:Label ID="StudentCertification" runat="server" Text="Student Certification"></asp:Label>
                 <asp:RadioButtonList ID="rblStudentCertification" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
                <asp:Label ID="CenterList" runat="server" Text="Center List"></asp:Label>
                 <asp:RadioButtonList ID="rblCenterList" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="DistributorList" runat="server" Text="Distributor List"></asp:Label>
                 <asp:RadioButtonList ID="rblDistributorList" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                    
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="StudentList" runat="server" Text="Student List"></asp:Label>
                 <asp:RadioButtonList ID="rblStudentList" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
               <asp:Label ID="Exams" runat="server" Text="Exams"></asp:Label>
                 <asp:RadioButtonList ID="rblExams" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="CenterRenewal" runat="server" Text="Center Renewal"></asp:Label>
                 <asp:RadioButtonList ID="rblCenterRenewal" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="ViewCenterQuerries" runat="server" Text="View CenterQuerries"></asp:Label>
                 <asp:RadioButtonList ID="rblViewCenterQuerries" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
         <div class="col-6">
                <asp:Label ID="SendNotification" runat="server" Text="Send Notification"></asp:Label>
                 <asp:RadioButtonList ID="rblSendNotification" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
           <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="ChangePassword" runat="server" Text="Change Admin Password"></asp:Label>
                 <asp:RadioButtonList ID="rblChangePassword" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        
        </div>
        <div class="row">
            
            <div class="col-12">
                <asp:Button ID="btnUpdate" CssClass="form-control btn-warning" runat="server" Text="Update" OnClick="btnUpdate_Click"  />
            </div>
        </div>
            
        
    </div>
                    </div>
                </div>
            </section>
        </div>
</asp:Content>

