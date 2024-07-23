<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="ViewCenterDetail.aspx.cs" Inherits="ViewCenterDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <div class="row">
        <div class="col-12">
            <img src="Image/StudyCenter.png" alt="" class="img-fluid" style="" />
        </div>
    </div>
    <div class="row mt-3 mb-3">
        <div class="col-12">
            <div class="container">

                <div class="card polaroid">
                    <div class="card-header" style="background-color:midnightblue;">
                        <div class="row">
                                
                            <div class="col-12 mt-3" style="text-align: center;">
                               <h3><asp:Label ID="lblCName" style="color:white;" runat="server"></asp:Label></h3>
                            </div>
                           
                                    
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4 col-sm-12">
                                 <asp:Image ID="imgCenterHeadImg" runat="server" CssClass="img-fluid" />
                            </div>
                            <div class="col-lg-8 col-sm-12">
                               
                               <div class="row">
                                    <div class="col-2"></div>
                                    <div class="col-4"><h6>Center Address</h6></div>
                                    <div class="col-6">
                                        <asp:Label ID="lblCAddress" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <hr />
                                 <div class="row">
                                    <div class="col-2"></div>
                                    <div class="col-4"><h6>Center State</h6></div>
                                    <div class="col-6">
                                        <asp:Label ID="lblCState" runat="server"></asp:Label>
                                    </div>

                                </div>
                                 <hr />
                                 <div class="row">
                                    <div class="col-2"></div>
                                    <div class="col-4"><h6>Center Head Name</h6></div>
                                    <div class="col-6">
                                        <asp:Label ID="lblCHeadName" runat="server"></asp:Label>
                                    </div>

                                </div>
                                <hr />
                                 <div class="row">
                                    <div class="col-2"></div>
                                    <div class="col-4"><h6>Center ID</h6></div>
                                    <div class="col-6">
                                        <asp:Label ID="lblCenterID" runat="server"></asp:Label>
                                    </div>
                                     
                                </div>
                                <hr />
                                
                                
                                  
                            </div>

                        </div>
                    </div>
                    <div class="card-footer" >
                        <div class="row">
                            <div class="col-4"></div>
                           
                            <div class="col-4">
                                <a id="btnBack" class="btn btn-info btn-block button" href="Default.aspx">Back</a>
                            </div>
                            <div class="col-4"></div>
                        </div>
                    </div>
                </div>

            </div>
            
        </div>
    </div>
</asp:Content>

