<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Marksheet.aspx.cs" Inherits="Marksheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function printdiv(printpage) {
            var headstr = "<html><head></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
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
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-block" Text="Submit" OnClick="btnSubmit_Click" runat="server"/>
        </div>
        
        <div class="col-lg-4"></div>
    </div>
    <div class="row mt-3 mb-3" runat="server" id="divShow" visible="false">
        <div class="col-12 mb-2 text-center">
            <asp:Label ID="lblShow" runat="server" Font-Size="25px" ForeColor="Red" Text="Exams Should Be Given" Visible="false"></asp:Label>
           
        </div>
        <div class="col-lg-4 col-sm-6 mb-2">
            <asp:Button ID="btnSem1" CssClass="btn btn-info btn-block" Text="1st Semester" runat="server" Visible="false" OnClick="btnSem1_Click"/>
        </div>
        <div class="col-lg-4 col-sm-6 mb-2">
            <asp:Button ID="btnSem2" CssClass="btn btn-info btn-block" Text="2nd Semester" runat="server" Visible="false" OnClick="btnSem2_Click"/>
        </div>
        <div class="col-lg-4 col-sm-6 mb-2">
            <asp:Button ID="btnSem3" CssClass="btn btn-info btn-block" Text="3rd Semester" runat="server" Visible="false" OnClick="btnSem3_Click"/>
        </div>
        <div class="col-lg-4 col-sm-6 mb-2">
            <asp:Button ID="btnSem4" CssClass="btn btn-info btn-block" Text="4th Semester" runat="server" Visible="false" OnClick="btnSem4_Click"/>
        </div>
        <div class="col-lg-4 col-sm-6 mb-2">
            <asp:Button ID="btnSem5" CssClass="btn btn-info btn-block" Text="5th Semester" runat="server" Visible="false" OnClick="btnSem5_Click"/>
        </div>
        <div class="col-lg-4 col-sm-6 mb-2">
            <asp:Button ID="btnSem6" CssClass="btn btn-info btn-block" Text="6th Semester" runat="server" Visible="false" OnClick="btnSem6_Click"/>
        </div>
    </div>

        <div class="row mt-3 mb-3" runat="server" id="div1" visible="false">
        <div class="col-12">
            <div class="container">

                <div class="card" id="div_print">
                    <div class="card-header">
                        <div class="row">
                             <div class="col-12 mt-3" style="">
                               <div class="row">
                                    <div class="col-12" style="text-align: center; color: #003a6a;">
                                <h4>Personal Details</h4>
                            </div>
                            <div class="col-lg-4 col-sm-12">
                                <asp:Image ID="imgStudentImg" runat="server" />
                            </div>
                            <div class="col-lg-8 col-sm-12">
                                <div class="row">
                                   <div class="col-3 mt-3"></div>
                                    <div class="col-4 mt-3" style=""><span>Name:</span></div>
                                    <div class="col-5 mt-3" style="">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </div>
                               </div>
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4" style="">Father's Name</div>
                                    <div class="col-5">
                                        <asp:Label ID="lblFName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4" style="">Gender</div>
                                    <div class="col-5">
                                        <asp:Label ID="lblGen" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4" style="">Date of Birth</div>
                                    <div class="col-5">
                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                    </div>

                                </div>
                           
                            </div>
                               </div>
                           </div>
                        </div>
                    </div>
                    <div class="card-body" >
                        <div class="row">
                              
                            <div class="col-12 text-center">
                              <h3>  <asp:Label ID="lblSems" runat="server"></asp:Label></h3>
                            </div>

                        </div>
                        <div class="row pb-2"  style="border:1px solid black;">
                             <div class="col-12">
                                 <div class="row" style="border-bottom:1px solid black;">
                                           
                                            <div class="col-5" style="border-right:black 1px solid;">Subjects</div>
                                            <div class="col-1" style="border-right:black 1px solid;">Max Marks</div>
                                            <div class="col-1" style="border-right:black 1px solid;">Marks Obtained</div>
                                            <div class="col-1" style="border-right:black 1px solid;">Max Marks</div>
                                            <div class="col-1" style="border-right:black 1px solid;">Marks Obtained</div>
                                            <div class="col-1" style="border-right:black 1px solid;">Total Max Marks</div>
                                     <div class="col-1" style="border-right:black 1px solid;">Total Min Marks</div>
                                            <div class="col-1">Total Obtained Marks</div>
                                            
                                        </div>
                             </div>
                          <b class="mt-2"> Theory Exams </b>
                            <asp:Repeater ID="rptMarks" runat="server">
                                <ItemTemplate>
                                   <div class="col-12" >
                                        
                                 <div class="row">
                                            
                                            <div class="col-5" style="border-right:black 1px solid;"><%# Eval("SubjectName") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("MaxMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("ObtainedMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("InternalMaxMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("InternalObtainedMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("TotMaxMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("MinMarks") %></div>
                                            <div class="col-1" ><%# Eval("TotMarksObtained") %></div>
                                           
                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <b class="mt-2 mb-2">Practical Exams</b>

                            <asp:Repeater ID="rptPrac" runat="server">
                                <ItemTemplate>
                                   <div class="col-12">
                                        
                                 <div class="row">
                                            
                                            <div class="col-5" style="border-right:black 1px solid;"><%# Eval("SubjectName") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("MaxMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("ObtainedMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("InternalMaxMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("InternalObtainedMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("TotMaxMarks") %></div>
                                            <div class="col-1" style="border-right:black 1px solid;"><%# Eval("MinMarks") %></div>
                                            <div class="col-1"><%# Eval("TotMarksObtained") %></div>
                                           
                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            </div>
                        <div class="row pb-2"  style="border:1px solid black;">
                            <div class="col-2">
                                <span style="font-weight:bold;">In Words</span>
                                 </div>
                            <div class="col-5">
                                <asp:Label ID="lblMarksWords" runat="server"></asp:Label>
                            </div>
                            <div class="col-2">
                                <span style="font-weight:bold;">Total Marks</span>
                                </div>
                            <div class="col-3">
                                <asp:Label ID="lblMarks" runat="server"></asp:Label>
                            </div>

                        </div>
                         <div class="row pb-2"  style="border:1px solid black;">
                            <div class="col-6">
                                <span style="font-weight:bold;">Result Declared</span>
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                                 </div>
                          
                            <div class="col-6">
                                <span style="font-weight:bold;">Result</span>
                                <asp:Label ID="lblRes" runat="server"></asp:Label>
                            </div>

                        </div>
                        
                    </div>
                    <div class="card-footer" >
                        <div class="row pb-2" style="border:1px solid gray;">
                            <div class="col-6 pl-5 pt-2">
                              <img src="images/NCVB-removebg-preview.png" alt="" class="img-fluid" style="width:25%;" />
                            </div>
                              <div class="col-6 pl-5 pt-2" style="background-color:white;">
                              <img src="images/passed.jpg" alt="" class="img-fluid" style="width:25%;" id="im" runat="server" visible="false"/>
                                   <img src="images/fail_stamp-100717316-large.jpg" alt="" class="img-fluid" style="width:25%;" id="imf" runat="server" visible="false" />
                            </div>

                        </div>
                    </div>
                </div>
                 <div class="row pb-2 mt-3">
                            <div class="col-12 text-center">
                               <asp:Button runat="server" ID="btnPrint" Text="Print" OnClientClick="printdiv('div_print');" />
                            </div>

                        </div>
            </div>
            
        </div>
    </div>

</asp:Content>

