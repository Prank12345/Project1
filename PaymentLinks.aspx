<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="PaymentLinks.aspx.cs" Inherits="PaymentLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .cld{

        }
        .cld:hover{
            background-color:#f1fff0;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="row">
        <div class="col-12 m-0 p-0">
            <img src="images/payment.jpg" style="width:100%; height:425px;" />
        </div>
    </div>
    <div class="container">
            <div class="row mt-3 mb-3">
        <div class="col-12">
            <div class="row">
                <div class="col-lg-6 col-sm-12 mt-3 mb-3 cld" style="border:double green 8px;">
                    <div class="row">
                        <div class="col-12 mt-3" style="text-align:center;">
                            <img src="images/hdfcBank.png" class="img-fluid" style="width:70%;" />
                        </div>
                         <div class="col-12 mb-3 mt-3" style="text-align:left;">
                             <div class="row">
                                 <div class="col-6 float-left">
                                     Account Holder Name:-
                                 </div>
                                 <div class="col-6">
                                     <b>NPC AND VB SKILL DEVELOPMENT</b>
                                 </div>
                             </div>
                             <div class="row">
                                 <div class="col-6 float-left">
                                    Account Number:-
                                 </div>
                                 <div class="col-6 float-left">
                                     <b>50200058292464</b>
                                 </div>
                             </div>
                            
                             <div class="row">
                                 <div class="col-6 float-left">
                                    IFSC:-
                                 </div>
                                 <div class="col-6 float-left">
                                     <b>HDFC0000657</b>
                                 </div>
                             </div>
                             <div class="row">
                                 <div class="col-6 float-left">
                                   BANK:-
                                 </div>
                                 <div class="col-6 float-left">
                                     <b>HDFC BANK </b>
                                 </div>
                             </div>
                             <div class="row">
                                 <div class="col-6 float-left">
                                   BRANCH:-
                                 </div>
                                 <div class="col-6 float-left">
                                     <b>ROORKEE</b>
                                 </div>
                             </div>
                            
                             
                        </div>
                    </div>
                    
                </div>
                <div class="col-1"></div>
                <div class="col-lg-5 col-sm-12 mt-3 mb-3 cld" style="border:double green 8px;">
                    <div class="row">
                        <div class="col-6 mt-2 pt-4"> <img src="images/qrcode.jpg" class="img-fluid"/></div>
                        <div class="col-6 mt-2 pt-4"> <img src="images/qrcode.jpg" class="img-fluid"/></div>
                       <%-- <div class="col-6 mt-2"> <img src="images/qrPay3.jpg" class="img-fluid"/></div>--%>
                    </div>
                   
                   
                   
                </div>
            </div>
            </div>
        </div>

    </div>
</asp:Content>