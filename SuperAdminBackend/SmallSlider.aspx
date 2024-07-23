<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="SmallSlider.aspx.cs" Inherits="SuperAdminBackend_SmallSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function confirmDel() {
            return confirm("Are you sure to DELETE this?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Slider Statement</h1>
                            </div>
                            <!-- /.col -->

                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
        <section class="content">
             <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                
                                <div class="row">
                                  
                                    <div class="col-12">
                                        <asp:Label ID="lblGalleryImage" runat="server" Text="Statement"></asp:Label>
                                    </div>
                                  
                                </div>
                                 <div class="row mt-2">
                                   
                                    <div class="col-12">
                                        <asp:TextBox ID="txtStatement" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                 <div class="row mt-2">
                                    <div class="col-4"></div>
                                    <div class="col-lg-4 col-md-12">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-block" OnClick="btnUpdate_Click" />
                                    </div>
                                    <div class="col-4"></div>
                                </div>
                                   
                                </div>
                            </div>
                        </div>
                 </div>

        </section>
    </div>
</asp:Content>

