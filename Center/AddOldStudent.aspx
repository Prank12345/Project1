<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="AddOldStudent.aspx.cs" Inherits="Center_AddOldStudent" %>

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
                Add Student
            </div>
        </div>
        <div class="row mt-5">
            
            <div class="col-12">
                <asp:label  runat="server"  text="Select Candidate Course"></asp:label>
                <asp:DropDownList ID="ddlcourse" required CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged">
                    
                </asp:DropDownList>
            </div>
        
           
        </div>
         <div class="row mt-2">
             <div class="col-4">
                <asp:label  runat="server" text="Short Name"></asp:label>
                <asp:textbox ID="txtShortName" ReadOnly="true" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-4">
                <asp:label  runat="server" text="Course Duration(in Years)"></asp:label>
                <asp:textbox ID="txtDuration" ReadOnly="true" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-4">
                <asp:label  runat="server" text="Total Semesters"></asp:label>
                <asp:textbox ID="txtTotSem" ReadOnly="true" cssclass="form-control" runat="server"></asp:textbox>
            </div>
        </div>

        <div class="row mt-2">
             <div class="col-4">
                <asp:label  runat="server" text="Full Course Fee"></asp:label>
                <asp:textbox ID="txtfee" ReadOnly="true" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-4">
                <asp:label  runat="server" text="Registration Fees"></asp:label>
                <asp:textbox ID="txtRegisFees" placeholder="Enter Course Fee" ReadOnly="true" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-4">
                <asp:label  runat="server" text="Exam Fees for full course"></asp:label>
                <asp:textbox ID="txtExamFees" placeholder="Enter Course Fee" ReadOnly="true" cssclass="form-control" runat="server"></asp:textbox>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-6">
                <asp:label  runat="server" text="Instruction Mode"></asp:label>
                <asp:DropDownList ID="ddlInsMode" runat="server" CssClass="form-control">
                    <asp:ListItem Text="--Select--" Value="0" Selected="True" Disabled="Disabled"></asp:ListItem>
                    <asp:ListItem Text="Online" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Offline" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-6">
                <asp:label  runat="server" text="Medium"></asp:label>
                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="form-control">
                     <asp:ListItem Text="--Select--" Value="0" Selected="True" Disabled="Disabled"></asp:ListItem>
                                    <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                    <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                     <asp:ListItem Text="Official Language" Value="OfficialLanguage"></asp:ListItem>
                </asp:DropDownList>
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
                <asp:label  runat="server" text="Student Name"></asp:label>
                <asp:textbox ID="txtsname" placeholder="Enter Student Name" required cssclass="form-control" runat="server"></asp:textbox>
            </div>
        
            <div class="col-5">
                <asp:label  runat="server" text="Father/Husband Name"></asp:label>
                <asp:textbox ID="txtfhname"  placeholder="Enter Father/Husband Name" required cssclass="form-control" runat="server"></asp:textbox>
            </div>
        </div>
         <div class="row mt-2">
              <div class="col-6">
                <asp:label  runat="server" text="Mother Name"></asp:label>
                <asp:textbox ID="txtMName"  placeholder="Mother Name" required cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-6">
                <asp:Label ID="lblgender" runat="server" required Text="Gender"></asp:Label><br />
                <asp:RadioButtonList ID="rbgender" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                </asp:RadioButtonList>             
            </div>
        </div>
        <div class="row mt-2">
           
            <div class="col-6">
                <asp:Label ID="lbldob" runat="server" Text="Date Of Birth"></asp:Label>
                <asp:TextBox ID="txtdob" TextMode="Date" required CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        
        
            <div class="col-6">
                <asp:Label ID="lblEmer" runat="server" Text="Emergency Number"></asp:Label>
                <asp:TextBox ID="txtEmergency"  placeholder="Enter Emergency Number" required CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            </div>
         <div class="row mt-2">
              <div class="col-6">
                <asp:label  runat="server" text="Father Occupation"></asp:label>
                <asp:textbox ID="txtFOccupation"  placeholder="Father Occupation" required cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-6">
                <asp:Label ID="lblStuOccupation" runat="server" Text="Student Occupation"></asp:Label><br />
               <asp:textbox ID="txtSOccupation"  placeholder="Student Occupation" required cssclass="form-control" runat="server"></asp:textbox>
            </div>
        </div>
         <div class="row mt-2">
              <div class="col-6">
                <asp:label ID="lblCCat" runat="server" text="Caste Category"></asp:label>
                 <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="form-control">
                    <asp:ListItem Text="--Select--" Selected="True" disabled="disabled"></asp:ListItem>
                      <asp:ListItem Text="GEN" Value="GEN"></asp:ListItem>
                     <asp:ListItem Text="OBC" Value="OBC"></asp:ListItem>                  
                    <asp:ListItem Text="SBC" Value="SBC"></asp:ListItem>
                     <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                    <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-6">
                <asp:Label ID="lblCat" runat="server" Text="Category"></asp:Label><br />
               <asp:DropDownList ID="ddlCate" runat="server" CssClass="form-control">
                    <asp:ListItem Text="--Select--" Selected="True" disabled="disabled"></asp:ListItem>
                      <asp:ListItem Text="BPL" Value="BPL"></asp:ListItem>
                     <asp:ListItem Text="Physically Challenged" Value="PhyCh"></asp:ListItem>
                </asp:DropDownList>
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
                <asp:Label ID="lblid" runat="server" Text="ID Type"></asp:Label>
                <asp:DropDownList ID="ddid" required CssClass="form-control" runat="server">
                    <asp:ListItem Text="Select ID" Value="Select ID" ></asp:ListItem>
                    <asp:ListItem Text="Aadhar Card" Value="Aadhar Card"></asp:ListItem>
                    <asp:ListItem Text="Pan Card" Value="Pan Card"></asp:ListItem>
                    <asp:ListItem Text="Voter ID" Value="Voter ID"></asp:ListItem>
                    <asp:ListItem Text="Passport" Value="Passport"></asp:ListItem>
                    <asp:ListItem Text="Driving Licence" Value="Driving Licence"></asp:ListItem>
                </asp:DropDownList>
            </div>
        
        
            <div class="col-6">
                <asp:Label ID="lblidnum" runat="server" Text="ID Number"></asp:Label>
                <asp:TextBox ID="txtidnum" required placeholder="Enter ID Number" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-6">
                <asp:Label ID="lblphone" runat="server" Text="Student Phone"></asp:Label>
                <asp:TextBox ID="txtphone" required TextMode="Number"  placeholder="Enter Phone Number" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        
            <div class="col-6">
                <asp:Label ID="lblemail" runat="server" Text="Student Email"></asp:Label>
                <asp:TextBox ID="txtemail" required  placeholder="Enter Email Address" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-2">
            
            <div class="col-12">
                <asp:Label ID="lblsession" runat="server" Text="Session"></asp:Label><br />
               </div>
               <div class="col-6 mt-2">
                    <span>From-</span>
                <asp:TextBox ID="txtsessionfrom" required CssClass="form-control datepicker" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                 <div class="col-6 mt-2">
                     <span>To-</span>
                <asp:TextBox ID="txtsessionto" required CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                     
            
            </div>
            <div class="row mt-5">
                <div class="col-6">
                    <asp:Label ID="lblsdimage" runat="server" Text="Student Image"></asp:Label><br />
                    <asp:FileUpload ID="fustdimg" required runat="server" /><br />
                    <span style="font-size:12px;">make sure image is in .jpg , png or jpeg format and must be size of 200 X 200px</span>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblmarkst" runat="server" Text="Marksheet"></asp:Label><br />
                    <asp:FileUpload ID="fumarkst" required runat="server" /><br />
                    <span style="font-size:12px;">make sure image is in .jpg , png or jpeg format and must be under 500kb</span>
                </div>
                </div>
              

         <div class="row mt-5">
               
                
                <div class="col-6">
                    <asp:Label ID="lblidimage" runat="server" Text="ID Image"></asp:Label><br />
                    <asp:FileUpload ID="fuidimage" required runat="server" /><br />
                    <span style="font-size:12px;">make sure image is in .jpg , png or jpeg format and must be under 500kb</span>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblpaymnt" runat="server" Text="Payment screenshot"></asp:Label><br />
                    <asp:FileUpload ID="fupscreen" required runat="server" /><br />
                    <span style="font-size:12px;">make sure image is in .jpg , png or jpeg format and must be under 500kb</span>
                </div>
              </div>
        <div class="row mt-2">
             
             <div class="col-3">

                <asp:label  runat="server" text="Qualification"></asp:label>
                <asp:textbox ID="txtQualificationu10" ReadOnly="true" Text="Under 10th" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-3">
                <asp:label  runat="server" text="Board/University"></asp:label>
                <asp:textbox ID="txtBoardU10" placeholder="Enter Board/University" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Passing Year"></asp:label>
                <asp:textbox ID="txtPassU10" placeholder="Enter Passing Year" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Marks Obtained"></asp:label>
                <asp:textbox ID="txtMarksU10" placeholder="Enter Marks Obtained" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Percentage/Grade"></asp:label>
                <asp:textbox ID="txtPercentageU10" placeholder="Enter Percentage" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            
            </div>
        <div class="row mt-2">
             
             <div class="col-3">

                <asp:label  runat="server" text="Qualification"></asp:label>
                <asp:textbox ID="txtQual10" ReadOnly="true" Text="SSC/10th/Matric" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-3">
                <asp:label  runat="server" text="Board/University"></asp:label>
                <asp:textbox ID="txtBoard10" placeholder="Enter Board/University" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Passing Year"></asp:label>
                <asp:textbox ID="txtPass10" placeholder="Enter Passing Year" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Marks Obtained"></asp:label>
                <asp:textbox ID="txtMarks10" placeholder="Enter Marks Obtained" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Percentage/Grade"></asp:label>
                <asp:textbox ID="txtPer10" placeholder="Enter Percentage" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            
            </div>
        <div class="row mt-2">
             
             <div class="col-3">

                <asp:label  runat="server" text="Qualification"></asp:label>
                <asp:textbox ID="txtQual12th" ReadOnly="true" Text="Higher sr. Sec/12th/Inter" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-3">
                <asp:label  runat="server" text="Board/University"></asp:label>
                <asp:textbox ID="txtBoard12" placeholder="Enter Board/University" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Passing Year"></asp:label>
                <asp:textbox ID="txtPass12" placeholder="Enter Passing Year" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Marks Obtained"></asp:label>
                <asp:textbox ID="txtMarks12" placeholder="Enter Marks Obtained" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Percentage/Grade"></asp:label>
                <asp:textbox ID="txtPer12" placeholder="Enter Percentage" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            
            </div>
        <div class="row mt-2">
             
             <div class="col-3">

                <asp:label  runat="server" text="Qualification"></asp:label>
                <asp:textbox ID="txtQualGrad" ReadOnly="true" Text="Graduate" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-3">
                <asp:label  runat="server" text="Board/University"></asp:label>
                <asp:textbox ID="txtBoardGrad" placeholder="Enter Board/University" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Passing Year"></asp:label>
                <asp:textbox ID="txtPassGrad" placeholder="Enter Passing Year" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Marks Obtained"></asp:label>
                <asp:textbox ID="txtMarksGrad" placeholder="Enter Marks Obtained" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Percentage/Grade"></asp:label>
                <asp:textbox ID="txtPerGrad" placeholder="Enter Percentage" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            
            </div>
        <div class="row mt-2">
             
             <div class="col-3">

                <asp:label  runat="server" text="Qualification"></asp:label>
                <asp:textbox ID="txtPGQual" ReadOnly="true" Text="Post Graduate" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            <div class="col-3">
                <asp:label  runat="server" text="Board/University"></asp:label>
                <asp:textbox ID="txtBoardPG" placeholder="Enter Board/University" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Passing Year"></asp:label>
                <asp:textbox ID="txtPassPG" placeholder="Enter Passing Year" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Marks Obtained"></asp:label>
                <asp:textbox ID="txtMarksPG" placeholder="Enter Marks Obtained" cssclass="form-control" runat="server"></asp:textbox>
            </div>
             <div class="col-2">
                <asp:label  runat="server" text="Percentage/Grade"></asp:label>
                <asp:textbox ID="txtPerPG" placeholder="Enter Percentage" cssclass="form-control" runat="server"></asp:textbox>
            </div>
            
            </div>

        <div class="row mt-3">
            
            <div class="col-12 mt-2 text-center">
                <asp:CheckBox ID="cbagree" runat="server" required Text="&nbsp; Agree with terms and conditions" />
            </div>
        </div>
        <div class="row">
            
            <div class="col-12">
                <asp:Button ID="btnsubmit" CssClass="form-control btn-primary" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </div>
        </div>
            
        
    </div>
                    </div>
                </div>
            </section>
        </div>
  
</asp:Content>