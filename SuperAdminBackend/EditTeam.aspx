<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditTeam.aspx.cs" Inherits="SuperAdminBackend_EditTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-lg-12 col-sm-12 mb-2">
                                <h1 class="m-0">Our Awsome Team</h1>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-12 col-sm-12 mb-2" style="text-align:center">
                                <h4 class="m-0">Add Team Member</h4>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2">
                                Member Name
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                           
                        </div>
                         <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2">
                                Designation
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:TextBox ID="txtDesig" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                           
                        </div>
                         <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2">
                                Image
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                 <asp:Image ID="imgImage" runat="server" CssClass="img-fluid" Width="150px" Height="170px" /><br />
                                <asp:Label ID="lblImageName" runat="server"></asp:Label><br />
                                <asp:FileUpload ID="fupImage" runat="server" />
                            </div>
                            
                           
                        </div>
                          <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                            <div class="col-lg-4 col-sm-12 mb-2" style="text-align:center;">
                               <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning btn-block" Text="Update" OnClick="btnUpdate_Click"/>
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                           
                        </div>
                    <!-- /.container-fluid -->
                </div>
                    </div>
               
                </div>
</asp:Content>

