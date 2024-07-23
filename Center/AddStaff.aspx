<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="AddStaff.aspx.cs" Inherits="Center_AddStaff" %>

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
                <asp:Label ID="lblProfile" runat="server" Text="Profile"></asp:Label>
                 <asp:RadioButtonList ID="rblProfile" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
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
                <asp:Label ID="stud" runat="server" Text="Student Management"></asp:Label>
                 <asp:RadioButtonList ID="rblStudMgmt" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="Course" runat="server" Text="Courses"></asp:Label>
                 <asp:RadioButtonList ID="rblCourses" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
               <asp:Label ID="lbltest" runat="server" Text="Tests"></asp:Label>
                 <asp:RadioButtonList ID="rblTest" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                   
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
                <asp:Label ID="lblStudCertiReq" runat="server" Text="Student Certificate"></asp:Label>
                 <asp:RadioButtonList ID="rblStudCertiReq" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblSetExam" runat="server" Text="Set Main Exam"></asp:Label>
                 <asp:RadioButtonList ID="rblSetExam" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                    
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="lblEWallet" runat="server" Text="E-Wallet"></asp:Label>
                 <asp:RadioButtonList ID="rblEWallet" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
               <asp:Label ID="lblStuPass" runat="server" Text="Student Password"></asp:Label>
                 <asp:RadioButtonList ID="rblStuPass" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                  
                </asp:RadioButtonList>  
            </div>
        
            <div class="col-6">
               <asp:Label ID="lblMyqry" runat="server" Text="My Query"></asp:Label>
                 <asp:RadioButtonList ID="rblMyQry" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblNotif" runat="server" Text="Notification"></asp:Label>
                 <asp:RadioButtonList ID="rblNotif" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
         <div class="col-6">
                <asp:Label ID="lblInternalMarks" runat="server" Text="Internal Marks"></asp:Label>
                 <asp:RadioButtonList ID="rblIntrnalMarks" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                     <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>                 
                </asp:RadioButtonList>  
            </div>
        </div>
        <div class="row">
            
            <div class="col-12">
                <asp:Button ID="btnsubmit" CssClass="form-control btn-primary" runat="server" Text="Add" OnClick="btnsubmit_Click"  />
            </div>
        </div>
            
        
    </div>
                    </div>
                </div>
            </section>
        </div>
  
</asp:Content>