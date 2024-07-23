<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewQuestion.aspx.cs" Inherits="Center_ViewQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
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
                
                 Student Name: <b><asp:Label ID="lblStuName" runat="server"></asp:Label> <%# Eval("StudentName") %></b>
              </div>
                 <div class="col-6" style="text-align:right;">
                <b>Total Questions : 35</b>
           <br /><br />
              </div>
               
               <div class="col-6">
                
                 Father's Name: <b><asp:Label ID="lblstuFName" runat="server"></asp:Label><%# Eval("FatherHusbandName") %></b>
              </div>
                 <div class="col-6" style="text-align:right;">
                     
                <b>Total Marks : 70</b>
         <br /><br />
              </div>
                
                <div class="col-6">
                
                 Enrolment Number: <b><asp:Label ID="lblStuEnroll" runat="server"></asp:Label><%# Eval("StudentID") %></b>
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
                <div class="row">
                    <div class="col-lg-12 col-md-12 mb-2">
                                <h1 class="m-0">Question Paper</h1>
                            </div>
                </div>
                <div class="row mb-2 mt-2">
                    
                        <asp:Repeater ID="rptQuestion" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12">
                                            <h5>Question: <asp:Label ID="lblQues" runat="server"><%#Eval("Question")%></asp:Label></h5>
                                    
                                   <hr />
                                            </div>
                                        
                                        <div class="col-lg-6 col-md-6">
                                            <p>A <asp:Label ID="lblAns1" runat="server"><%#Eval("Option1") %></asp:Label></p>
                                   
                                            </div>
                                        <div class="col-lg-6 col-md-6">
                                             <p>B <asp:Label ID="lblAns2" runat="server"><%#Eval("Option2") %></asp:Label></p>
                                   
                                            </div>
                                        <div class="col-lg-6 col-md-6">
                                             <p>C <asp:Label ID="lblAns3" runat="server"><%#Eval("Option3") %></asp:Label></p>
                                  
                                            </div>
                                        <div class="col-lg-6 col-md-6">
                                              <p>D <asp:Label ID="lblAns4" runat="server"><%#Eval("Option4") %></asp:Label></p>
                                            </div>
                                       
                                          <div class="col-lg-12 col-md-12 mb-5">
                                              <hr />
                                               <h5><asp:Label ID="Label1" runat="server">Correct Answer:  <%# Eval("CorrectAnswer") %></asp:Label></h5>
                                            </div>
                                    </div>
                                    <br />
                                    </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                
                </div>
            </section>
        </div>
</asp:Content>

