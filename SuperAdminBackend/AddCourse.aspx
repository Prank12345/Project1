<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="SuperAdminBackend_AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Add Course Details</h1>
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
                 
       
                    <div class="row">
            
            <div class="col-lg-10 col-md-10 mb-3">
                <asp:TextBox ID="txtcourse" required placeholder="Enter Course Name" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
      </div>
                     <div class="row">
            
            <div class="col-lg-10 col-md-10 mb-3">
                <asp:TextBox ID="txtFees" required placeholder="Enter Course Fees(pa)" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
      </div>
             <div class="row">
            <div class="col-lg-10 col-md-10 mb-3">
                <asp:Label ID="lbldetails" runat="server" Text="Brief Details of Course"></asp:Label></div>
       
          
            <div class="col-lg-10 col-md-10 mb-3">
                <asp:TextBox ID="txtdetails" required CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>
             <div class="row">
                 <div class="col-lg-10 col-md-10 mb-2">
                      <asp:TextBox ID="txtSubject1" required CssClass="form-control" runat="server" placeholder="Enter Subject"></asp:TextBox>
            </div>
           <div class="col-lg-10 col-md-10" id="div1" runat="server">
            </div>
                  <div class="col-lg-3 col-md-3">
                      <asp:Button ID="btnAdd" runat="server" Text="Add+" CssClass="btn btn-warning btn-block" OnClick="AddTextBox" />
            </div>
                 <div class="col-lg-3 col-md-3">
                      <asp:Button ID="btnRemove" causesvalidation="false" runat="server" Text="Remove-" CssClass="btn btn-danger btn-block" OnClick="btnRemove_Click" />
            </div>
                  </div>
             <div class="row">
           <div class="col-lg-10 col-md-10 mb-3 mt-3">
                <asp:Button ID="btnaddcourse" CssClass="btn btn-primary btn-block" runat="server" Text="Add Course" OnClick="btnaddcourse_Click" />
            </div>
        </div>
                    </div>
            </section>
        </div>
            
            </ContentTemplate>
         
         </asp:UpdatePanel>
    
</asp:Content>

