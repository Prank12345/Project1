<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="StudentVerification.aspx.cs" Inherits="StudentVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-12 m-0 p-0">
            <img src="Image/graduation.jpg" style="width:100%; height:300px;" />
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-lg-2"></div>
        <div class="col-lg-8 col-sm-12">
            <span>Enrolment Number</span><br />
            <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-2"></div>
       </div>
    <div class="row mt-3">
        <div class="col-lg-2"></div>
        <div class="col-lg-8 col-sm-12">
              <span>Date of Birth</span><br />
            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-lg-2"></div>
        </div>
    <div class="row mt-3 mb-3">
        <div class="col-lg-3"></div>
        <div class="col-lg-3 col-sm-3">
            <asp:Button ID="btnSubmit" CssClass="btn btn-info btn-block" Text="Submit" OnClick="btnSubmit_Click" runat="server"/>
        </div>
        <div class="col-lg-3 col-sm-3">
            <asp:Button ID="btnResult" CssClass="btn btn-info btn-block" Text="Online Result" runat="server" OnClick="btnResult_Click"/>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <div class="row mt-3 mb-3" runat="server" id="divShow" visible="false">
        <div class="col-12">
            <div class="container">

                    <div style="background-color:#eceeff; border-radius:20px;">
                      
                               <div class="row pt-3">
                                    <div class="col-12" style="text-align: center;">
                                <h4>Candidate Details</h4>
                            </div>
                            </div>
                         <div class="row pl-3 pb-3">
                             <div class="col-3 pl-3">
                                <asp:Image ID="imgStudent" runat="server" CssClass="img-fluid" />
                            </div>
                            <div class="col-9" >
                                <div class="row">
                                   
                                    <div class="col-5 mt-3" style="background-color:midnightblue; color:white;"><span>Student Name:</span></div>
                                    <div class="col-7 mt-3" style="">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </div>
                               </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Father's Name</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblFName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Mother's Name</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblMName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                               
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Gender</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblGen" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Date of Birth</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <div class="row">
                                
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">ID Proof</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblIdProof" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">ID Proof Number</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblIDNum" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Enrolment Numebr</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblEnNum" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <div class="row">
                                
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Enrolment Date</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblEnDate" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Status</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Course Name</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                    </div>

                                </div> 
                                 <div class="row">
                                    
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Course Duration</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCTime" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Adacemic Devision</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblAcDev" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1" style="background-color:midnightblue; color:white;">Center(ASTC)</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                    
                             <%--   <div class="row">
                                    
                                    <div class="col-4">Passing Year</div>
                                    <div class="col-5">
                                        <asp:Label ID="lblPassYear" runat="server"></asp:Label>
                                    </div>

                                </div>--%>
                          
                            </div>
                               </div>
                          
                    </div>
                   
            </div>
            
        </div>
    </div>

    <div class="row mt-3 mb-3" runat="server" visible="false" id="divResShow">
        <div class="col-12">
            <div class="container">
                 <div class="row">
              <div class="col-12">
                  <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4">Center Name</div>
                                    <div class="col-5">
                                        <asp:Label ID="lblCeNm" runat="server"></asp:Label>
                                    </div>

                                </div>
                   <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4">Course Name</div>
                                    <div class="col-5">
                                        <asp:Label ID="lblCoNm" runat="server"></asp:Label>
                                    </div>

                                </div>
              </div>
                <div class="col-12" runat="server" id="sem" visible="false">
                    <div class="container text-center">
                         <div class="row">
                                    <div class="col-12 mb-3"><h4>Result</h4></div>
                             <div class="col-4"></div>
                                    <div class="col-2"><b>Total Marks:</b> </div>
                                    <div class="col-2">
                                        <asp:Label ID="lblTotalMarks" runat="server"></asp:Label>
                                    </div>
                              <div class="col-4"></div>
                              <div class="col-4"></div>
                     <div class="col-2"> <b>Marks Obtained: </b></div>
                                    <div class="col-2">
                                        <asp:Label ID="lblMarks" runat="server"></asp:Label>
                                    </div>
                              <div class="col-4"></div>
                    </div>
                    </div>
               

                    </div>
                    <div class="col-12 mb-3 mt-5 text-center">
                    <h4>    <asp:Label ID="lblResult" runat="server"></asp:Label></h4>
                    </div>
                                
            </div>
            </div>
           
        </div>
    </div>
</asp:Content>

