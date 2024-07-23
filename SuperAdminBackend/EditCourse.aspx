<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditCourse.aspx.cs" Inherits="SuperAdminBackend_EditCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Edit Course Details</h1>
                            </div>
                            <!-- /.col -->

                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
        <section class="content ml-xl-5 pl-xl-5">
            <div class="container-fluid">
                         <div class="row mb-2">
                             <div class="col-lg-2 col-sm-12 mb-2">
                                Course Type
                            </div>
                            <div class="col-lg-10 col-sm-12 mb-2">
                                <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Course Name
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Short Name of course
                            </div>
                           
                            
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:TextBox ID="txtShortName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                        </div>
                      <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                About Course
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtcoursedetails" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                           <div class="col-lg-2 col-sm-12 mb-2">
                                Course Attendant
                            </div>
                            
                             <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtAttendant" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Duration of Full Course
                            </div>
                             <div class="col-lg-2 col-sm-12 mb-2">
                                <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                                <asp:DropDownList ID="ddldurationType" runat="server" CssClass="form-control" required>
                                    <asp:ListItem Value="0" Text="--Year/Months" Selected="True" disabled="disabled"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Year"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Months"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                               Eligibility
                            </div>
                           
                           
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:TextBox ID="txtEligibility" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                        </div>

                          <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Registration Fees
                            </div>
                              <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtRegFees" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                               Course Fees
                            </div>
                           
                            
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:TextBox ID="txtProgFees" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                        </div>
                       
                          <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Instruction Mode
                            </div>
                               <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtInstructionMode" runat="server" CssClass="form-control" ReadOnly="true" Text="Online & Offline"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                               Medium
                            </div>
                           
                           
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:DropDownList ID="ddlLang" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="--Select--" Value="0" Selected="True" Disabled="Disabled"></asp:ListItem>
                                    <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                    <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                     <asp:ListItem Text="Official Language" Value="OfficialLanguage"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-3 col-sm-12 mb-2"></div>
                            <div class="col-lg-3 col-sm-6 mb-2" style="text-align:center;">
                               <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success btn-block" Text="Update" OnClick="btnUpdate_Click1"/>
                            </div>
                            <div class="col-lg-3 col-sm-6 mb-2" style="text-align:center;">
                               <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger btn-block" Text="Back" OnClick="btnBack_Click"/>
                            </div>
                            <div class="col-lg-3 col-sm-12 mb-2"></div>
                           
                        </div>
                    </div>
                </section>
        </div>
            
            
</asp:Content>

