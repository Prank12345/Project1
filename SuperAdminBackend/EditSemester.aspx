<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditSemester.aspx.cs" Inherits="SuperAdminBackend_EditSemester" %>

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
                                <h1 class="m-0">Edit Semester</h1>
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
            
             <div class="col-lg-4 col-sm-12 mb-2">
                                Semester Name
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:TextBox ID="txtSemName" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                           <div class="col-lg-4 col-sm-12 mb-2">
                               Exam Fees For This Semester
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:TextBox ID="txtExamFees" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
      
                <div class="col-lg-3 col-sm-3"  runat="server">
                    Semesters
            </div>
                         <div class="col-lg-9 col-sm-9"  runat="server">
                    Subjects
            </div>
                          <div class="col-lg-3 col-sm-3" id="div3" runat="server">
            </div>
           <div class="col-lg-9 col-sm-9" id="div1" runat="server">
            </div>
                         <div class="col-lg-12 col-sm-12" id="div2" runat="server">
                         <div class="row mb-2">
                            <div class="col-lg-1"></div>
                                  <div class="col-lg-5 col-sm-6">
                  
                      <asp:Button ID="btnAdd" runat="server" Text="Add Subject+" CssClass="btn btn-warning btn-block" OnClick="AddTextBox" />
            </div>
                 <div class="col-lg-5 col-sm-6">
                      <asp:Button ID="btnRemove" causesvalidation="false" runat="server" Text="Remove subject-" CssClass="btn btn-danger btn-block" OnClick="btnRemove_Click1"/>
            </div>
                              <div class="col-lg-1"></div>
                  </div>
             <div class="row">
           <div class="col-lg-4 col-sm-12 mb-2"></div>
                            <div class="col-lg-4 col-sm-12 mb-2" style="text-align:center;">
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary btn-block" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </div>
                 <div class="col-lg-4 col-sm-12 mb-2"></div>
        </div>
                             </div>
                    </div>
            </section>
        </div>
            </ContentTemplate>
         
         </asp:UpdatePanel>
</asp:Content>

