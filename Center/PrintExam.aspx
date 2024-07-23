<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="PrintExam.aspx.cs" Inherits="Center_PrintExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function printdiv(printpage) {
            var headstr = "<html><head></head><body>";
            var footstr = "</body></html>";
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
     <div class="content-wrapper">
          
            <section class="content">
                  <div class="container-fluid">
                      <div class="row" id="div_print">
        <asp:Repeater ID="rptShowData" runat="server" OnItemDataBound="rptShowData_ItemDataBound">
            <ItemTemplate>
                <div class="col-12" style="page-break-after:auto;">
                    <div class="row mb-2">
           
          <div class="col-2">
           <img src="../Image/logo.png" class="img-fluid" />
          </div>
            <div class="col-9 mt-2 text-center">
                <h1 style="text-decoration:underline; font-size:50px; font-weight:bold;">NPCVB Skill Development</h1>
                 <h2>AN ISO 9001:2015 Certified</h2>
            </div><!-- /.col -->
         
        </div>
          <hr />
                      <div style="background-image:url('../Image/imageedit_1_9137610113.png'); background-repeat:no-repeat;">
           <div class="row" style="font-size:22px; ">
             
              <div class="col-6">
                
                 Student Name: <b><%# Eval("StudentName") %></b>
              </div>
                 <div class="col-6" style="text-align:right;">
                <b>Total Questions : 35</b>
           <br /><br />
              </div>
               
               <div class="col-6">
                
                 Father's Name: <b><%# Eval("FatherHusbandName") %></b>
              </div>
                 <div class="col-6" style="text-align:right;">
                     
                <b>Total Marks : 70</b>
         <br /><br />
              </div>
                
                <div class="col-6">
                
                 Enrolment Number: <b><%# Eval("StudentID") %></b>
              </div>
                 <div class="col-6" style="text-align:right;">
                   
                <b>Marks Obtained : ___</b>
           
              </div>
               
          </div>
          <div class="row" style="font-size:22px;">
              
              <div class="col-sm-12 mt-5">
                  <h4><%# Eval("InstituteName") %></h4>
              </div>
          </div>
          <div class="row mb-5" style="font-size:22px;">
              
              <div class="col-sm-12 mt-5">
                  Subject Name :  <b><asp:Label ID="lblSubName" runat="server"></asp:Label></b>
                 
              </div>
          </div>
          <hr class="mt-0 mb-1" style="border: 1px black solid;" />
          <hr class="mt-0 mb-1" style="border: 1px black solid;"/>
                       <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   
           <div class="row pt-5" style="font-size:22px;">
            
               <div class="col-4 mt-5">
                   <p style="text-decoration:underline; font-weight:bold;">Center Seal</p>
               </div>
                 <div class="col-4 mt-5 text-center">
               <p style="text-decoration:underline; font-weight:bold;">Center Head Signature</p>
            <br />
                 
              </div>
                <div class="col-4 mt-5"  style="text-align:right;">
                <p style="text-decoration:underline; font-weight:bold;">Student Signature</p>
            <br />
                  
              </div>
               
          </div>
             <div class="row" style="font-size:22px;">
              
               <div class="col-12">
                   <h2><b>General Instructions</b></h2>
                   <ol>
                       <li><b>There are 35 questions in all question paper.</b></li>
                       <li><b>All questions are compulsory.</b></li>
                       <li><b>Every question consist of 2 marks only.</b></li>
                       <li><b>Read the instructions and questions carefully.</b></li>
                   </ol>
                   <hr />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   <br />
                   
               </div>
                
          </div>
         </div>
     <div class="row" style="font-size:22px;">
              
               <div class="col-12 text-center">
                   
                   <h2>Questions</h2>
                   
               </div>
                
          </div>
        <div class="row" style="background-image:url('../Image/imageedit_1_9137610113.png');">
            <asp:Repeater ID="rpt" runat="server">
                <ItemTemplate>
                    <div class="col-12">
                        <div class="row">
                            <div class="col-12"  style="font-size:22px;">
                              Question <%# Eval("Question") %><br /><br />
                            </div>
                            <div class="col-6" style="font-size:15px;">Option A: <%# Eval("Option1") %></div>
                            <div class="col-6" style="font-size:15px;">Option B: <%# Eval("Option2") %><br /><br /></div>
                           <div class="col-6" style="font-size:15px;">Option C: <%# Eval("Option3") %></div>
                           <div class="col-6" style="font-size:15px;">Option D: <%# Eval("Option4") %></div>

                        </div>
                        <hr />
                                </div>
                </ItemTemplate>
            </asp:Repeater>
                            
       
            </div>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
                          </div>
        
                       <div class="row">
              <div class="col-12">
                  <asp:Button runat="server" ID="btnGenerate" Text="Print" OnClientClick="printdiv('div_print');"/>
              </div>
          </div>
                    </div>
                </section>
          
                </div>
    
</asp:Content>

