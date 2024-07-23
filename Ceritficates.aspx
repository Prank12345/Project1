<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Ceritficates.aspx.cs" Inherits="Ceritficates" %>

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
        <div class="col-lg-4"></div>
        <div class="col-lg-4 col-sm-3">
            <asp:Button ID="btnSubmit" CssClass="btn btn-info btn-block" Text="Submit" OnClick="btnSubmit_Click" runat="server"/>
        </div>
        
        <div class="col-lg-4"></div>
    </div>
     <div class="row mt-3 mb-3" runat="server" id="divShow" visible="false">
        <div class="col-12">
           <div class="container">
                <div class="row pt-3">
                                    <div class="col-12" style="text-align: center;">
                                <h4>Candidate Certificate Online Verification</h4>
                            </div>
                            </div>
                    <div style="background-color:#eceeff; border-radius:20px;">
                      
                              
                         <div class="row pl-3 pb-3 pt-3">
                             <div class="col-3 pl-3" id="dv" runat="server" >
                                 <img src="images/NCVB-removebg-preview.png" class="img-fluid" alt="" style="width:40%; padding-top:60%; float:right;" />
                               <%-- <asp:Image ID="imgStudent" runat="server" CssClass="img-fluid" />--%>
                            </div>
                            <div class="col-9" >
                                <div class="row pt-3">
                                     <div class="col-12" style="text-align: left;">
                                <h4>Candidate Details</h4>
                            </div>
                                </div>
                                <div class="row">
                                   
                                    <div class="col-5 mt-3"><span>Student Name:</span></div>
                                    <div class="col-7 mt-3" style="">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </div>
                               </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1">Father's Name</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblFName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1">Mother's Name</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblMName" runat="server"></asp:Label>
                                    </div>

                                </div>
                               <%-- <div class="row">
                               
                                    <div class="col-5 mt-1">Gender</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblGen" runat="server"></asp:Label>
                                    </div>

                                </div>--%>
                                <div class="row">
                                
                                    <div class="col-5 mt-1">Date of Birth</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                    </div>

                                </div>
                                
                                <div class="row">
                                
                                    <div class="col-5 mt-1"> <asp:Label ID="lblIdProof" runat="server"></asp:Label></div>
                                    <div class="col-7">
                                        <asp:Label ID="lblIDNum" runat="server"></asp:Label>
                                    </div>

                                </div>
                                  <div class="row pt-3">
                                     <div class="col-12" style="text-align: left;">
                                <h4>Academic Details</h4>
                            </div>
                                </div>
                                <div class="row">
                                
                                    <div class="col-5 mt-1">Enrolment Number</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblEnNum" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <div class="row">
                                
                                    <div class="col-5 mt-1">Enrolment Date</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblEnDate" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1">Course Name</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                    </div>

                                </div> 
                                <div class="row">
                                
                                    <div class="col-5 mt-1">Status</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                    </div>

                                </div>
                                  <div class="row">
                                  
                                    <div class="col-5 mt-1">Adacemic Devision</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblAcDev" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <div class="row">
                                    
                                    <div class="col-5 mt-1">Course Duration</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCTime" runat="server"></asp:Label>
                                    </div>

                                </div>

                                <div class="row">
                                    
                                    <div class="col-5 mt-1">Total Marks Obtained</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblMarks" runat="server" Text="443/500"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                    
                                    <div class="col-5 mt-1">Final Result</div>
                                    <div class="col-2">
                                        <asp:Label ID="lblPass" runat="server" Text="Pass"></asp:Label>
                                    </div>
                                    <div class="col-5" style="text-align:left;">
                                        <img src="images/passed.jpg" alt="" class="img-fluid" style="width:20%;" />
                                    </div>
                                </div>
                               <%-- <div class="row">
                                    
                                    <div class="col-5 mt-1">Grade</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblRade" runat="server" Text="A"></asp:Label>
                                    </div>

                                </div>--%>
                              <%--<div class="row">
                                    
                                    <div class="col-5 mt-1">Certificate Issue Date</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCrIsuDate" runat="server" Text="29/10/2020"></asp:Label>
                                    </div>

                                </div>--%>
                                <div class="row">
                                  
                                    <div class="col-5 mt-1">Center(ASTC)</div>
                                    <div class="col-7">
                                        <asp:Label ID="lblCName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                                              
                          
                            </div>
                               </div>
                          
                    </div>
                   
            </div>
            </div>
         </div>
</asp:Content>

