<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="OurBestPerformer.aspx.cs" Inherits="OurBestPerformer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
                <div class="row">
                    <div class="col-12 m-0 p-0">
                        <img src="Image/slider1.jpg" class="img-fluid" alt="" style="height:350px;width:100%;" />
                    </div>
                </div>
            </div>
       <div class="container mb-3">
           <div class="row">
               <div class="col-lg-12 col-sm-12" style="text-align:center; ">
                   <h2 style="font-size:45px;">Our Best Performers</h2>
               </div>
           </div>
           <div class="row">
            <asp:Repeater ID="rptCenterName" runat="server">
                <ItemTemplate>
                  <div class="col-lg-12 col-sm-12 mt-2" style="background-color:aqua; border-radius:20px;">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-lg-4 col-sm-12">
                                              <asp:Image runat="server" ImageUrl='<%#"~/Center-Document/"+Eval("passportpic") %>' Height="200px" Width="200px" style="border-radius:35px;" />
                                        </div>
                                        <div class="col-lg-8 col-sm-12">
                                            <div class="row mt-5">
                                                <div class="col-lg-6 col-sm-12">
                                                    <p style="color:midnightblue; font-weight:bold;">Center ID : <span style="color:maroon"><%#Eval("CenterID") %></span></p>
                                                    <hr />
                                                    <p style="color:midnightblue; font-weight:bold;">Center Director Name : <span style="color:maroon"> <%#  Eval("PersonName") %></span></p>
                                                    <hr />
                                                </div>
                                                <div class="col-lg-6 col-sm-12">
                                                   <p style="color:midnightblue; font-weight:bold;">Center Name : <asp:Label ID="lblc" runat="server" style="color:maroon"><%# Eval("InstituteName") %></asp:Label> </p>
                                                    <hr />
                                                     <p style="color:midnightblue; font-weight:bold;">Center Address : <span style="color:maroon"> <%#Eval("Address") %></span></p>
                                                    <hr />
                                                </div>
                                            </div>
                                           
                                        </div>
                                    </div>
                                </div>
                      </div>
                           
                   
                  
                </ItemTemplate>
            </asp:Repeater>
           </div>
            </div>
</asp:Content>

