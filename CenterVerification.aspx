<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="CenterVerification.aspx.cs" Inherits="CenterVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-12 m-0 p-0">
            <img src="Image/3.jpg" style="width:100%; height:300px;" />
        </div>
    </div>
      
    <div class="row mt-3">
        <div class="col-lg-2"></div>
        <div class="col-lg-8 col-sm-12">
            <span>Center-ID</span><br />
            <asp:TextBox ID="txtCenterID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-2"></div>
       </div>
   
    <div class="row mt-3 mb-3">
        <div class="col-lg-4"></div>
        <div class="col-lg-4 col-sm-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-info btn-block" Text="Submit" OnClick="btnSubmit_Click" runat="server"/>
        </div>
        <div class="col-lg-4"></div>
    </div>
    <div class="card" runat="server" id="divShow" visible="false">
                    <div class="card-header text-center" style="background-color:midnightblue;">
                        <asp:Image ID="img" runat="server" CssClass="img-fluid" style="height:150px;width:150px;" />
                        <h3 style="color:white;"><asp:Label ID="lblCName" runat="server"></asp:Label></h3>
                        </div>
          <div class="card-body">
    <div class="row mt-3 mb-3" >
        <div class="col-12">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                          <div class="row">
                                    <div class="col-12" style="text-align:center"> 
                                        <h4>Center Details</h4>
                                    </div>
                                    
                                </div>
                        <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4"><h6>Center ID</h6></div>
                                    <div class="col-5">
                                        <asp:Label ID="lblCenerID" runat="server"></asp:Label>
                                    </div>

                                </div>
                        <hr />
                                 <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4"><h6>Center Head Name</h6></div>
                                    <div class="col-5">
                                        <asp:Label ID="lblCHeadName" runat="server"></asp:Label>
                                    </div>

                                </div>
                        <hr />
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4"><h6>Center Address</h6></div>
                                    <div class="col-5">
                                        <asp:Label ID="lblCAddress" runat="server"></asp:Label>
                                    </div>

                                </div>
                        <hr />
                                 <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-4"><h6>Center State</h6></div>
                                    <div class="col-5">
                                        <asp:Label ID="lblCState" runat="server"></asp:Label>
                                    </div>

                                </div>
                                  <hr />
                </div>
            </div>
            
        </div>
    </div>
        </div>
              </div>
        </div>
</asp:Content>

