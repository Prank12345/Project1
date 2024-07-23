<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .marquee {
  /*width: 100%;*/
  overflow: hidden;
  border: 1px solid #ccc;
  background: #F6F7FF;
  height:270px;
}
        .marq {
 
  height:290px;
  overflow: hidden;
  border-left: 5px solid #003a6a;
  border-bottom: 5px solid #003a6a;
  border-right: 5px solid #003a6a;
  
}
        .changecolor {
  animation: color-change 3s infinite;
}

@keyframes color-change {
  0% {background-color: red; }
  25% {background-color: blue; }
  50%{background-color: green;}
  75%{background-color:#f30cef;}
  100% {background-color: darkorange; }
}
 .changecolor1 {
  animation: color-change1 3s infinite;
}

@keyframes color-change1 {
  0% {background-color: blue; }
  25% {background-color: darkorange; }
  50%{background-color: red;}
  75%{background-color:green;}
  100% {background-color: #f30cef; }
}
 .changecolor2 {
  animation: color-change2 3s infinite;
}

@keyframes color-change2 {
  0% {background-color: green; }
  25% {background-color: darkmagenta; }
  50%{background-color: blue;}
  75%{background-color:red;}
  100% {background-color: #4a0be9; }
}

h3 {
  animation: color-change4 4s infinite;
}

@keyframes color-change4 {
  0% {color: red; }
  25% {color: purple; }
  50%{color: blue;}
  75%{color:green;}
  100% {color: yellow; }
}

.changecolorh2 {
  animation: color-changeh2 3s infinite;
  text-decoration:none;
}

@keyframes color-changeh2 {
  0% {color: red; }
  25% {color: blue; }
  50%{color: magenta;}
  75%{color:forestgreen;}
  100% {color: deeppink; }
}
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script type='text/javascript' src='//cdn.jsdelivr.net/jquery.marquee/1.4.0/jquery.marquee.min.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
  
            <asp:UpdatePanel ID="upd" runat="server">
                <ContentTemplate>
                     <div class="row">
        <div class="col-12 m-0 p-0">
        <div id="demo" class="carousel slide" data-ride="carousel">

  <!-- Indicators -->
  <ul class="carousel-indicators">
    <li data-target="#demo" data-slide-to="0" class="active"></li>
    <li data-target="#demo" data-slide-to="1"></li>
    <li data-target="#demo" data-slide-to="2"></li>
       <li data-target="#demo" data-slide-to="3"></li>
       <li data-target="#demo" data-slide-to="4"></li>
  </ul>
                    <div class="carousel-inner">
    <div class="carousel-item active">
        <asp:Image ID="img1" CssClass="img-fluid" runat="server" style="height:400px; width:100%" />
     
    </div>
    <div class="carousel-item">
        <asp:Image ID="img2" CssClass="img-fluid" runat="server" style="height:400px; width:100%" />
     
    </div>

    <div class="carousel-item">
        <asp:Image ID="img3" CssClass="img-fluid" runat="server" style="height:400px; width:100%" />
     
    </div>
      <div class="carousel-item">
        <asp:Image ID="img4" CssClass="img-fluid" runat="server" style="height:400px; width:100%" />
     
    </div>
      <div class="carousel-item">
        <asp:Image ID="img5" CssClass="img-fluid" runat="server" style="height:400px; width:100%" />
      
    </div>
  </div>
  
  <!-- Left and right controls -->
  <a class="carousel-control-prev" href="#demo" data-slide="prev">
    <span class="carousel-control-prev-icon"></span>
  </a>
  <a class="carousel-control-next" href="#demo" data-slide="next">
    <span class="carousel-control-next-icon"></span>
  </a>

        </div>
            </div>
        </div>
                    <div class="row">
                        <div class="col-12">
                            <div id="MyModal" class="modal fade" role="dialog" runat="server">
        <div class="modal-dialog" runat="server">
            <div class="modal-content" runat="server">
                <div class="modal-header" runat="server">
                   
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                     
                 </div>
                 <div class="modal-body" runat="server">
                   
                      <asp:Image ID="imgImage" runat="server" /><br />
                    <h4>  <asp:Label ID="lblpopH2" runat="server"></asp:Label></h4>
                  </div>
                  <div class="modal-footer" runat="server">
                      <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                 </div>
              </div>
          </div>
      </div>
                        </div>
                    </div>
        <div class="row">
            <div class="col-12 p-0 m-0">
                <marquee style="background-color:#003a6a; color:yellow; font-weight:bold; font-size:18px;"><asp:Label ID="lblMsg" runat="server"></asp:Label> </marquee>
            </div>
        </div>
    
        <div class="row mt-2">
            <div class="col-lg-5 col-md-12" >
                <h1 class="m-0 p-0" style="color:white;background-color:#003a6a; text-align:center;">Latest News</h1>
                <%--style="background-image:url('GIFs/gif-history-dvdp-2.gif'); background-repeat:no-repeat; background-size:cover;"--%>
                <div class="marq m-0 p-0" data-duplicated='true' data-direction='up'>
                    <div class="row pl-2">
                    <asp:Repeater ID="rptLatestNew" runat="server">
                        <ItemTemplate>
                            <div class="col-12 m-1" style="text-align:left;">
                                
                            <span style="background-color:#003a6a; border-radius:5px;"><i class="fa fa-check" style="color:white; font-size:12px; padding-left:4px;padding-right:4px;"></i></span>
                            <asp:Label ID="lblShowSubMessage" runat="server" Font-Size="16px" style="font-family:Verdana" ForeColor="Black"><%# Eval("NotifMessage") %></asp:Label><br />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                        </div>
                </div>
            </div>
             <div class="col-lg-7 col-md-12">
                  <p style="font-size:20px; text-align:center; font-weight:bold;">राष्ट्रीय पैरामेडिकल कॉउन्सिल  एंड वोकेशनल बोर्ड कौशल विकास <br />
NATIONAL PARAMEDICAL COUNCIL AND VOCATIONAL BOARD SKILL DEVELOPMENT</p>
                <p style="text-align:justify;" >
              An Autonomous institution(<b>Regd. Under sec.8 Rac, Act 2013</b>) for Industrial and vocational Education incorporated under Ministry of Corporate Affairs Govt. Of India, Regd. Under Trust Act. 1882, Regd. By Department of Labour NCT Delhi, MSME, NITI AAYOG, QCI, NBQP, ISO-QRO, IAF, Govt. Of India, 
Authorised Member:- Indian Yoga Association
                    
Authorised By:- Ministry of Skill Development and Entrepreneurship, Ministry Of Electronics and Information Technology, Ministry of Home Affairs, Ministry of Youth Affairs and Sports, Ministry of Women and Child Development, Ministry of Ayush Govt. Of India | Running Under Guideline National Education Policy, 1986 Guideline (MHRD) Govt. Of India
</p><br /><a href="AboutUs.aspx" class="badge badge-warning" style="text-decoration-line:none; padding:5px; font-size:14px; float:right;">Read More</a>

             </div>
        </div>
    <div class="row mt-3 mb-3" style="">
       <div class="col-lg-6 col-sm-12 p-0">
          <a href="CenterRegister.aspx" style="text-decoration:none; width:100%;">  <div style="background-image:url('Image/f3.jpg'); background-size:cover; background-repeat:no-repeat; text-align:center;font-family: 'Lobster', cursive; width:100%; padding-top:140px!important;">
            <h3 style="font-size:45px;background-color:rgba(255,255,255,0.5);">100% Free of Cost</h3>
              <span style="font-size:45px;background-color:rgba(255,255,255,0.5); padding-left:39px; padding-right:39px;" class="changecolorh2">  Click Here To Apply For Franchise</span>
         </div></a>
        </div>
         <div class="col-lg-6 col-sm-12 p-0">
             <a href="FreeTest.aspx" style="text-decoration: none; ">
                 <div  style="background-image:url('Image/addFreeTest4.jpg'); background-size:cover; padding-top:200px!important; text-align:center;font-family: 'Lobster', cursive; width:100%;">
                 <h2 style="font-size:45px;background-color:rgba(255,255,255,0.5);">Online Examination</h2>
                     </div>
             </a>
         </div>
      
    </div>
        <div class="row">
           
            <div class="col-lg-4 col-6 mt-1">
                <a href="StudentLogin.aspx" class="btn btn-block changecolor" style="font-size:14px;font-family: 'Libre Baskerville', serif; color:white;">Student Login Panel</a>
            </div>
            <div class="col-lg-4 col-6 mt-1">
                <a href="StudentVerification.aspx" class="btn btn-block changecolor1" style="font-size:14px;font-family: 'Libre Baskerville', serif; color:white;">Online Result & Student Details</a>
            </div>
            <div class="col-lg-4 col-6 mt-1">
                <a href="Ceritficates.aspx" class="btn btn-block changecolor2" style="font-size:14px;font-family: 'Libre Baskerville', serif; color:white;">Student Verification</a>
            </div>
            <div class="col-lg-4 col-6 mt-1">
                <a href="Marksheet.aspx" class="btn btn-block changecolor2" style="font-size:14px;font-family: 'Libre Baskerville', serif; color:white;">Marksheet Verification</a>
            </div>
            <div class="col-lg-4 col-6 mt-1">
                <a href="CenterLogin.aspx" class="btn btn-block changecolor" style="font-size:14px;font-family: 'Libre Baskerville', serif;color:white;">Center Login Panel</a>
            </div>
            <div class="col-lg-4 col-6 mt-1">
                <a href="CenterVerification.aspx" class="btn btn-block changecolor1" style="font-size:14px;font-family: 'Libre Baskerville', serif;color:white;">Center Verification</a>
            </div>
        </div>
     
        <div class="row mb-2 mt-4">
            <div class="col-12 p-0 m-0">
                <h4 style="color:#003a6a; text-align:center;">OUR RELATIONSHIPS</h4>
            </div>
            </div>

        <div class="row">
            <div class="col-12 p-0 m-0">
                <div class="marquee" data-duplicated='true' data-direction='left'>
                <table class="table pt-2 pb-2">
                    <tr>
                            <asp:Repeater ID="rptCenter" runat="server">
                            <ItemTemplate>
                            <td style="text-align:center;border:solid 1px gray;background-color:#eff0f1;">
                                <asp:HyperLink ID="hlShow" runat="server" NavigateUrl='<%#"ViewCenterDetail.aspx?CID="+Eval("ID") %>' style="text-decoration:none;">
                                <asp:Image ID="imgShow" runat="server" CssClass="img-fluid" style="height:180px; width:180px;" ImageUrl='<%# "~/Center-Document/"+ Eval("passportpic")  %>' />
                                <br />
                                <asp:Label ID="ShowName" runat="server" Font-Bold="true"><%#Eval("InstituteName").ToString().PadRight(140).Substring(0,14).TrimEnd() %></asp:Label><br />
                                     <asp:Label ID="lblCenterID" runat="server" ><%#Eval("CenterID") %></asp:Label><br />
                                     <asp:Label ID="ShowState" runat="server" ><%#Eval("State") %></asp:Label>
                                </asp:HyperLink>
                            </td>
                            </ItemTemplate>
                    </asp:Repeater>
                        </tr>
                    </table>
                </div>
                  
            </div>
        </div>
    <div class="row mt-2 mb-2">
        <div class="col-12 m-0 p-0">
            <a href="DistributorRegistration.aspx" style="text-decoration:none;"><img src="Image/distributor.png" alt="" class="img-fluid" /></a>
            
        </div>
    </div>
      <script>
           $('.marq').marquee({
               direction: 'up',
               duration:'8000'
           });
       </script>
      
       <script>
           $('.marquee').marquee({
               direction: 'left',
               duration:'20000'
                
           });
       </script>

                   <%-- <script type="text/javascript">
    $(window).on('load', function() {
        $('#myModal').modal('show');
    });
</script>--%>
                    <script type="text/javascript">
    //                  $(document).ready(function(){
    //    $("#myModal").modal('show');
    //});
                    
                    //   $(window).load(function () {
                      //      $('#myModal').modal('show');
                       // });
               setTimeout(function () {
                   $("#MyModal").show();
               }, 1000);
          
    </script>
                </ContentTemplate>
            </asp:UpdatePanel>
  <!-- The slideshow -->
  
    
</asp:Content>

