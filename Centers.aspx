<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Centers.aspx.cs" Inherits="Centers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        .fancy {
  position: relative;
  background-color:#FFC;
  padding: 2rem;
  text-align: center;
  max-width: 100%;
}
.fancy::before {
  content: "";
  position : absolute;
  z-index  : -1;
  bottom   : 15px;
  right    : 5px;
  width    : 50%;
  top      : 80%;
  max-width: 200px;
  box-shadow: 0px 13px 10px black;
  transform: rotate(4deg);
}
.uppercase
{
    text-transform: uppercase;
}
.w3-animate-input{transition:width 0.4s ease-in-out}
.w3-animate-input:focus{width:100%!important}                                                
.w3-input{padding:8px;display:block;border:none;border-bottom:1px solid #ccc;width:100%}
.w3-border{border:1px solid #ccc!important}
.w3-display-topmiddle{position:absolute;left:50%;top:0;transform:translate(-50%,0%);-ms-transform:translate(-50%,0%)}
.w3-card{box-shadow:0 2px 5px 0 rgba(0,0,0,0.16),0 2px 10px 0 rgba(0,0,0,0.12)}
.w3-border-indigo,.w3-hover-border-indigo:hover{border-color:#3f51b5!important}
.w3-text-indigo,.w3-hover-text-indigo:hover{color:#3f51b5!important}
    </style>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12 m-0 p-0">
                        <img src="Image/slider1.jpg" class="img-fluid" alt="" />
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-12 mt-5" style="text-align: center;">
                        <h1>Centers</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                         <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">                                               
                                                <h4 class="modal-title" id="H1">
                                                   Admission Enquiry</h4>
                                                 <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">×</span></button>
                                            </div>
                                            <div class="modal-body">
                                                <label>
                                                    Name</label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                                 
                                                <label>
                                                    Email
                                                </label>
                                                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                                                <label>
                                                    City</label>
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                                                <label>
                                                    Message</label>
                                                <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control"></asp:TextBox>
                                                <div style="max-height: 300px; overflow: auto; margin-bottom: 20px;">
                                                </div>
                                                <br class="clear" />
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnmoveconfirm" runat="server" Text="Send Enquiry" CssClass="btn btn-success" OnClick="btnmoveconfirm_Click" />
                                                <asp:Button ID="btnmovecancel" runat="server" Text="Cancel" data-dismiss="modal" CssClass="btn btn-danger" />
                                            </div>
                                        </div>
                                    </div>
                    </div>
                </div>
            </div>
                </div>
            <div class="container-fluid mb-4">
        <div class="row">
                <div class="col-lg-12 col-md-12 mb-5">
                               
                                  <asp:DropDownList ID="ddlState" CssClass="w3-input w3-border w3-animate-input w3-display-topmiddle w3-card w3-border-indigo w3-hover-text-indigo" style="width:40%;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                     <asp:ListItem Text="Select State" Value="0" Selected="True" Disabled="Diabled"></asp:ListItem>
                     <asp:ListItem Text="Andaman and Nicobar Island" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Andra Pradesh" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Arunachal Pradesh" Value="3"></asp:ListItem>
                     <asp:ListItem Text="Assam" Value="4"></asp:ListItem>
                     <asp:ListItem Text="Bihar" Value="5"></asp:ListItem>
                     <asp:ListItem Text="Chandigarh" Value="6"></asp:ListItem>
                     <asp:ListItem Text="Chhatisgarh" Value="7"></asp:ListItem>
                     <asp:ListItem Text="Dadar and Nagar Haveli" Value="8"></asp:ListItem>
                     <asp:ListItem Text="Daman and Diu" Value="9"></asp:ListItem>
                     <asp:ListItem Text="Delhi" Value="10"></asp:ListItem>
                     <asp:ListItem Text="Goa" Value="11"></asp:ListItem>
                     <asp:ListItem Text="Gujrat" Value="12"></asp:ListItem>
                     <asp:ListItem Text="Haryana" Value="13"></asp:ListItem>
                     <asp:ListItem Text="Himachal Pradesh" Value="14"></asp:ListItem>
                     <asp:ListItem Text="Jammu and Kashmir" Value="15"></asp:ListItem>
                     <asp:ListItem Text="Jharkhand" Value="16"></asp:ListItem>
                     <asp:ListItem Text="Karnataka" Value="17"></asp:ListItem>
                     <asp:ListItem Text="Kerala" Value="18"></asp:ListItem>
                     <asp:ListItem Text="Lakshdeep" Value="19"></asp:ListItem>
                     <asp:ListItem Text="Madhya Pradesh" Value="20"></asp:ListItem>
                     <asp:ListItem Text="Maharashtra" Value="21"></asp:ListItem>
                     <asp:ListItem Text="Manipur" Value="22"></asp:ListItem>
                     <asp:ListItem Text="Meghalaya" Value="23"></asp:ListItem>
                     <asp:ListItem Text="Mizoram" Value="24"></asp:ListItem>
                     <asp:ListItem Text="Nagaland" Value="25"></asp:ListItem>
                     <asp:ListItem Text="Odisha" Value="26"></asp:ListItem>
                     <asp:ListItem Text="Pondicherry" Value="27"></asp:ListItem>
                     <asp:ListItem Text="Punjab" Value="28"></asp:ListItem>
                     <asp:ListItem Text="Rajasthan" Value="29"></asp:ListItem>
                     <asp:ListItem Text="Sikkim" Value="30"></asp:ListItem>
                     <asp:ListItem Text="Tamil Nadu" Value="31"></asp:ListItem>
                     <asp:ListItem Text="Telangana" Value="32"></asp:ListItem>
                     <asp:ListItem Text="Tripura" Value="33"></asp:ListItem>
                     <asp:ListItem Text="Uttar Pradesh" Value="34"></asp:ListItem>
                     <asp:ListItem Text="Uttarakhand" Value="35"></asp:ListItem>
                     <asp:ListItem Text="West Bengal" Value="36"></asp:ListItem>
                 </asp:DropDownList>
                  
                                </div>                        
            </div>
         <div class="row">
                            <div class="col-12">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="20px"></asp:Label>
                            </div>
                        </div>
        </div>
          <div class="container-fluid mb-3">
            <asp:Repeater ID="rptCenterName" runat="server" OnItemDataBound="rptCenterName_ItemDataBound">
                <ItemTemplate>
                    <div id="accordion<%= getIndex() %>">
                        <div class="card mt-2">
                            <div class="card-header" style="text-align: center; background-color: #003a6a;">
                                <div class="row">
                                    <div class="col-12" style="text-align: center;">
                                        <a class="card-link" data-toggle="collapse" href="#collapse<%= getIndex() %>" style="color: white;">
                                            <asp:Label ID="lblcenter" runat="server" CssClass="uppercase"><%# Eval("InstituteName") %></asp:Label>                                            
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div id="collapse<%= getIndex() %>" class="collapse" data-parent="#accordion<%= getIndex() %>" style="background-image:url('Image/imageedit_1_9137610113.png'); background-size:cover; background-size:100% 100%; background-repeat:no-repeat;">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-lg-2 col-sm-12">
                                            <%--<img src="ncvb.jpeg" style="height:200px;width:200px;" />--%>
                                            <asp:Image runat="server" ImageUrl='<%#"~/Center-Document/"+Eval("passportpic") %>' Height="200px" Width="200px" style="border-radius:35px;" />
                                        </div>
                                        <div class="col-lg-10 col-sm-12">
                                            <div class="row">
                                                <div class="col-lg-6 col-sm-12">
                                                    <p style="color:midnightblue; font-weight:bold;">Center ID :<span style="color:maroon"><%#Eval("CenterID") %></span></p>
                                                    <hr />
                                                    <p style="color:midnightblue; font-weight:bold;">Center Director Name :<span style="color:maroon"> <%#  Eval("PersonName") %></span></p>
                                                    <hr />
                                                </div>
                                                <div class="col-lg-6 col-sm-12">
                                                   <p style="color:midnightblue; font-weight:bold;">Center Name :<asp:Label ID="lblc" runat="server" style="color:maroon"><%# Eval("InstituteName") %></asp:Label> </p>
                                                    <hr />
                                                     <p style="color:midnightblue; font-weight:bold;">Center Address :<span style="color:maroon"> <%#Eval("Address") %></span></p>
                                                    <hr />
                                                </div>
                                            </div>
                                            <div class="row" style="text-align: center;">
                                                <div class="col-4">
                                                    <%--<asp:Button ID="btnadminssion" runat="server" CssClass="btn btn-primary" Text="Admission Inquiry" />--%>
                                                </div>
                                                <div class="col-4">
                                                    <%--<asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Text="Center Google Location" />--%>
                                                </div>
                                                <div class="col-lg-4 col-sm-12">
                                                    <%--<input type="hidden" runat="server" value='<%#Eval("Email") %>' id='hfEmail' />--%>
                                                    <asp:HiddenField ID="hfEmail" runat="server" Value='<%#Eval("Email") %>' />
                                                    <a id="btnadminssion" runat="server" class="btn btn-primary btn-block"  data-toggle="modal" data-target="#myModal">Admission Inquiry</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <% incrementIndex(); %>
                </ItemTemplate>
            </asp:Repeater>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlState" />
        </Triggers>
    </asp:UpdatePanel>  
</asp:Content>

