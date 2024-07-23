<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="newcenters.aspx.cs" Inherits="newcenters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<%= Center() %>--%>
    <div id="accordion">
        <div class="card mt-5 mb-5">
            <div class="card-header" style="text-align: center; background-color:mediumaquamarine;">
                <div class="row">
                    <div class="col-12" style="text-align:center;">
                          <a class="card-link" data-toggle="collapse" href="#collapseOne" style="color: black;">
                              <asp:Label ID="shortName" runat="server" Text="NPCVB" style="float:left !important;"></asp:Label>
                              <asp:Label ID="lblcenter" runat="server" Text="NPCVB Skill & Developement Board"></asp:Label>
                                </a>
                    </div>
                    
                </div>
            </div>
            <div id="collapseOne" class="collapse" data-parent="#accordion">
                <div class="card-body">
                   <div class="row">
                       <div class="col-2">
                           <img src="Image/AKSharma.jpg" height="200px" width="200px" />
                       </div>
                       <div class="col-10">
                           <div class="row">
                               <div class="col-6">
                           <p>Center ID : </p>
                           <hr />
                           <p>Center Director Name : </p>
                           <hr />
                            <p>Center Address : </p>
                           <hr />
                       </div>
                       <div class="col-6">
                           <p>Center Category : </p>
                           <hr />
                           <p>Center Location : </p>
                           <hr />
                            <p>Facilities : </p>
                           <hr />
                       </div>
                           </div>
                           <div class="row" style="text-align:center;">
                            <div class="col-4">
                           <asp:Button ID="btnadminssion" runat="server" CssClass="btn btn-primary" Text="Admission Inquiry" />
                       </div>
                                <div class="col-4">
                           <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Text="Center Google Location" />
                       </div>
                                <div class="col-4">
                           <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Center Photos" />
                       </div>
                               
                       </div>
                       </div>
                       
                       
                      
                      
                   </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

