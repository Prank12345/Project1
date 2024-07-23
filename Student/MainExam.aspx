<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="MainExam.aspx.cs" Inherits="Student_MainExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Main Exam</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-lg-12 col-md-12" style="text-align:center;">
                <h2 style="color:mediumseagreen;">BEST OF LUCK</h2>
                </div>
            <div class="col-3"></div>
            <div class="col-6"><p>Instructions Before Main Exam</p></div>
            <div class="col-3"></div>
                
                
            <div class="col-3"></div>
            <div class="col-6">
                <ul>
                    
                    <li>
                        You Can Skip Questions By Clicking On Next Button
                    </li>
                    <li>
                        Do Not Refresh Question Page
                    </li>
                    <li>
                       If We Found You Cheated Your Id Will Be Ban Forever
                    </li>
                    <li>
                        This Exam Should Be Taken In Front Of Center Head
                    </li>
                </ul>
            </div>
            <div class="col-6" id="webcam"></div>
            <div class="col-6"><img id="imgCapture" /></div>
            <div class="col-6"><input type="button" id="btnCapture" value="Capture"/></div>
            <div class="col-6"> <input type="button" id="btnUpload" value="Upload" disabled="disabled" /></div>
            <div class="col-3"></div>
            <div class="col-3"></div>
            <div class="col-6"><asp:CheckBox ID="chk" runat="server" Text="Agree With All Terms And Conditions" Checked="true" Enabled="false" /></div>
            <div class="col-3"></div>
                
            </div>
          <div class="row">
              <div class="col-3"></div>
              <div class="col-6"><asp:Button ID="btnExm" runat="server" CssClass="btn btn-success btn-block" Text="Click Here To Start The Exam" OnClick="btnExm_Click" /></div>
              <div class="col-3"></div>
          </div>
          </div>
            </section>
         </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/webcamjs/1.0.25/webcam.js"></script>
    
    <script src="webcam/jquery.webcam.js"></script>
<script type="text/javascript">
    $(function () {
        Webcam.set({
            width: 320,
            height: 240,
            image_format: 'jpeg',
            jpeg_quality: 90
        });
        Webcam.attach('#webcam');
        $("#btnCapture").click(function () {
            Webcam.snap(function (data_uri) {
                $("#imgCapture")[0].src = data_uri;
                $("#btnUpload").removeAttr("disabled");
            });
        });
        $("#btnUpload").click(function () {
            $.ajax({
                type: "POST",
                url: "MainExam.aspx/SaveCapturedImage",
                data: "{data: '" + $("#imgCapture")[0].src + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) { }
            });
        });
    });
</script>
</asp:Content>

