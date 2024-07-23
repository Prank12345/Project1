<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="FreeTestQuestions.aspx.cs" Inherits="FreeTestQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
       .rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 10px;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-12 m-0 p-0">
            <img src="Image/Exam-Preparation.jpg" style="width:100%; height:350px;" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="container">
                <div class="row">
                     <div class="col-12" id="wizard_container" runat="server">
                
            </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

