<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .polaroid {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            padding:20px;
        }

        .pol {
           box-shadow: 10px 10px 10px rgba(0, 0, 0, 0.2);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   <div class="row">
       <div class="col-12 m-0 p-0">
           <img src="Image/Contact us-01.jpg" alt="" class="img-fluid"/>
       </div>
   </div>
    <div class="container">
        <div class="row mt-3 polaroid">
             <div class="col-lg-12 text-center" style="color:white; background-color:midnightblue;padding:10px;">
                <h1><i class="fas fa-map-marker-alt" ></i> We Are Just A Phone Call Away</h1>
            </div>
            <div class="col-lg-6 col-12 mt-3 mb-3" style="padding:10px; background-color:#e5e9fe;">
            
                <form action="">
                    <div class="form-group">
      <label for="pwd">Name</label>
      <input type="text" class="form-control" id="name" placeholder="Enter Name" runat="server">
    </div>
    <div class="form-group">
      <label for="email">Email</label>
      <input type="text" class="form-control" id="email" placeholder="Enter email" runat="server">
    </div>
    <div class="form-group">
      <label for="pwd">Phone</label>
      <input type="text" class="form-control" id="phone" placeholder="Enter phone" runat="server">
    </div>
      <div class="form-group">
      <label for="pwd">message</label>
      <input type="text" class="form-control" id="message" placeholder="Enter message" runat="server">
    </div>
    
    <asp:Button ID="txtsubmit" runat="server" CssClass="btn btn-primary btn-block" Text="Submit"/>
  </form>
            </div>
             <div class="col-lg-6 col-12 mt-3 mb-3" style="text-align:left; background-color:aquamarine; padding:10px;">
             
                <p class="mt-4" style="font-size:20px; background-color:white;padding-top:10px;padding-bottom:10px;">
                    &nbsp;<i class="fas fa-mobile"></i>  +91-7017650600 <br /> &nbsp;&nbsp;&nbsp;&nbsp;+91-9368332335</p>
                  <p style="font-size:20px; background-color:white;padding-top:10px;padding-bottom:10px;">
                    &nbsp; <i class="fas fa-envelope"style="color:orange;"></i> help@npcvb.com</p>
                  <p style="font-size:20px; background-color:white;padding-top:10px;padding-bottom:10px;">
                   &nbsp; <i class="fab fa-whatsapp"></i> 9368332335</p>
                  <p style="font-size:20px; background-color:white;padding-top:10px;padding-bottom:10px;">
                   &nbsp; Calling Timing:- Morning 10:00 Am To Evening 06:00 Pm</p>
                  <p style="font-size:20px; background-color:white;padding-top:10px;padding-bottom:10px;">
                  &nbsp;<i class="fas fa-map"></i> <b> NPCVB :</b>  Green Park Colony Near Rampur Chungi <br />&nbsp;Roorkee, Distt Haridwar Uttarakhand 247667
                    </p>
                    <br />
                      <br />
                            
            </div>
            </div>
        <div class="row mt-3">
              <div class="col-12 pol mb-3 mt-3">
                <div class="row">
                       <div class="col-lg-4 col-sm-12 bg-warning text-black-50 border-right" style=";padding:10px;">
               <i class="fas fa-envelope"></i> INFO: info@npcvb.com
            </div>
              <div class="col-lg-4 col-sm-12 bg-warning text-black-50 border-right" style="padding:10px;">
               <i class="fas fa-envelope"></i> Technical Support: technical_support@npcvb.com
            </div>
              <div class="col-lg-4 col-sm-12 bg-warning text-black-50 border-right" style="padding:10px;">
               <i class="fas fa-envelope"></i> Director : director@npcvb.com
            </div>
                </div>
                <div class="row">
                       <div class="col-lg-4 col-sm-12 bg-primary text-white border-right" style="padding:10px;">
               <i class="fas fa-envelope"></i> Exam: exam@npcvb.com
            </div>
              <div class="col-lg-4 col-sm-12 bg-primary text-white border-right" style="padding:10px;">
               <i class="fas fa-envelope"></i> Executive: executive@npcvb.com
            </div>
              <div class="col-lg-4 col-sm-12 bg-primary text-white border-right" style="padding:10px;">
               <i class="fas fa-envelope"></i> Certificate: certificate@npcvb.com
            </div>
                </div>
            </div>
            <div class="col-lg-12 col-12 mt-3 mb-3 polaroid">
                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d432.54401084022055!2d77.8883017!3d29.8541183!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x9231378f666e73a2!2sNPCVB%20SKILL%20DEVELOPMENT%20PVT%20Ltd!5e0!3m2!1sen!2sin!4v1605953983350!5m2!1sen!2sin" width="100%" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
            </div>
         
        </div>
   </div>
</asp:Content>

