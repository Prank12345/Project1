<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="AddSemester.aspx.cs" Inherits="SuperAdminBackend_AddSemester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
    <style>
        .rounded-corners {
  /*border: 1px solid black;*/
  -webkit-border-radius: 8px;
  -moz-border-radius: 8px;
  border-radius: 8px;
  overflow: hidden;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-lg-12 col-md-12 mb-2">
                                <h1 class="m-0">Semesters</h1>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-12 col-md-12 mb-2" style="text-align:center">
                                <h4 class="m-0">Add Semester</h4>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
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
                                <asp:TextBox ID="txtExamFees" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="col-lg-12 col-sm-12 mb-2">
                                Subjects
                            </div>
                            <div class="col-lg-12 col-sm-12 mb-2" id="div1" runat="server">
                                
                            </div>
                            
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-2"></div>
                                  <div class="col-lg-4 col-sm-6">
                      <asp:Button ID="btnAdd" runat="server" Text="Add Subject+" CssClass="btn btn-warning btn-block" OnClick="AddTextBox" />
            </div>
                 <div class="col-lg-4 col-sm-6">
                      <asp:Button ID="btnRemove" causesvalidation="false" runat="server" Text="Remove subject-" CssClass="btn btn-danger btn-block" OnClick="btnRemove_Click" />
            </div>
                                 <div class="col-lg-2"></div>
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                            <div class="col-lg-4 col-sm-12 mb-2" style="text-align:center;">
                               <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click"/>
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                           
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </div>
                
               
                </div>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

