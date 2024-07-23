<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="MainExamPaper.aspx.cs" Inherits="Student_MainExamPaper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
       .rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 10px;
}
       
   </style>
    <style>
        .polaroid {
 
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
 
}
.button{
    box-shadow: 0 25px 60px rgba(0, 0, 0, .2);
        }
        .button:hover{
            /*background: #20a6f5;*/
             box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Questions</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container">
          <div class="row polaroid mb-2 pt-3">
          <div class="col-lg-3"></div>
        <!-- Small boxes (Stat box) -->
              <div class="col-lg-6 col-sm-12">
          <div class="card">
             
              <div class="card-body">

             
        <div class="row">
            
            <div class="col-lg-12 col-sm-12" id="wizard_container" runat="server">
                
            </div>
            
            </div>
                   </div>
            
          </div>
                  </div>
          <div class="col-lg-3"></div>
              </div>
          </div>
            </section>
         </div>
</asp:Content>

