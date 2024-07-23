<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Student_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Dashboard: Welcome <asp:Label runat="server" ID="lblStudentName"></asp:Label></h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->
  
       <section class="content">
    <div class="container-fluid">
        <div class="card">
            <div class="card-header">
                <div class="row"> 
                      <div class="col-lg-4 col-6">
            <!-- small box -->
            <div class="small-box bg-primary">
              <div class="inner">

               <div class="icon">
                <i class="ion ion-android-clipboard"></i>
              </div>

                <p>Tests</p>
                   <h4><asp:Label ID="lblTest" runat="server" Text="2"></asp:Label></h4>
              </div>
             <a href="TakeTests.aspx" class="small-box-footer">Details<i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>               
           <div class="col-lg-4 col-6">
            <!-- small box -->
            <div class="small-box bg-gradient-fuchsia">
              <div class="inner">
             <div class="icon">
                <i class="ion ion-bag"></i>
              </div>
                <p>Courses</p>
                     <h4><asp:Label ID="lblcourse" runat="server" Text="Course"></asp:Label></h4>
              </div>
             <a href="#" class="small-box-footer">Details <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
             <div class="col-lg-4 col-6">
            <!-- small box -->
            <div class="small-box bg-gradient-purple">
              <div class="inner">
                  <div class="icon">
                <i class="ion ion-android-bookmark"></i>
              </div>
                <p>ID-Card</p>
                <h4>&nbsp;<%--<asp:Label ID="lblID" runat="server" Text="test"></asp:Label>--%></h4>
              </div>
                <asp:HiddenField ID="hfDate1" runat="server" />
                <asp:HiddenField ID="hfDate2" runat="server" />
                <asp:HiddenField ID="hfCenterName" runat="server" />
                <asp:HiddenField ID="hfCenterAddr" runat="server" />
                <asp:HiddenField ID="hfCourse" runat="server" />
                <asp:HiddenField ID="hfImageName" runat="server" />
                <asp:HiddenField ID="hfStudentID" runat="server" />
             <asp:LinkButton runat="server" ID="lnkbtnDownload" OnClick="lnkbtnDownload_Click" CssClass="small-box-footer" Text="">Download <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
            </div>
          </div>
            <div class="col-lg-4 col-6">
            <!-- small box -->
            <div class="small-box bg-secondary">
              <div class="inner">
                <div class="icon">
                <i class="ion ion-android-archive"></i>
              </div>
                <p>New Notification</p>
                    <h4><asp:Label ID="lblNotif" runat="server" Text="2"></asp:Label></h4>
              </div>
              
              <a href="studentnotification.aspx" class="small-box-footer">Details<i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
        </div>
            </div>
        </div>
        <div class="card-body">
             <div class="row">
            <div class="col-12">
                <h3>Frequently Asked Questions</h3>
                <hr />
            </div>
        </div>
        </div>
       </div>
           </section>
    
    <!-- /.content -->
  </div>

</asp:Content>

