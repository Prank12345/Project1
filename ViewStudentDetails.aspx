<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="ViewStudentDetails.aspx.cs" Inherits="ViewStudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-12 m-0 p-0">
            <img src="Image/StudDetails.png" alt="" class="img-fluid" style="" />
        </div>
    </div>
    <div class="row mt-3 mb-3">
        <div class="col-12">
            <div class="container">

                <div class="card">
                    <div class="card-header">
                        <div class="row">
                                
                            <div class="col-12 mt-3" style="text-align: center; background-color:midnightblue;">
                                <h3 style="color:white;"><asp:Label ID="lblSName" runat="server"></asp:Label></h3>
                            </div>      
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4 col-sm-12">
                                <asp:Image ID="imgImageStudent" runat="server" CssClass="img-fluid" />
                            </div>
                            <div class="col-lg-8 col-sm-12">
                                  <div class="row">
                                   
                                    <div class="col-4"><h6>Student ID</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblStuID" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <hr />
                                <div class="row">
                                    
                                    <div class="col-4"><h6>Session</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblSesion" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <hr />
                                <div class="row">
                                    
                                    <div class="col-4"><h6>Date of Birth</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <hr />

                                <div class="row">
                                    
                                    <div class="col-4"><h6>Mother's Maiden Name</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblMomName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <hr />
                                <div class="row">
                                    
                                    <div class="col-4"><h6>Father's/Husbands's Name</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblDadName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <hr />
                                 <div class="row">
                                
                                    <div class="col-4"><h6>Center Name</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblCName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <hr />
                                <div class="row">
                                    
                                    <div class="col-4"><h6>Center Address</h6></div>
                                    <div class="col-8">
                                        <asp:Label ID="lblCAddress" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <hr />
                            </div>

                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="row">
                            <div class="col-4"></div>
                           
                            <div class="col-4">
                                <a id="btnBack" class="btn btn-info btn-block" href="Default.aspx">Back</a>
                            </div>
                            <div class="col-4"></div>
                        </div>
                    </div>
                </div>

            </div>
            
        </div>
    </div>
</asp:Content>

