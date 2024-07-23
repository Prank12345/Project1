<%@ Page Title="" Language="C#" MasterPageFile="~/Distributor/DistributorMasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Distributor_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
          <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Dashboard</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Dashboard</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
         <section class="content">
             <div class="container-fluid">
       
        <div class="row" id="dd" runat="server">    
              
            <div class="col-lg-4 col-6">
            <!-- small box -->
            <div class="small-box bg-gradient-fuchsia">
              <div class="inner">
             <div class="icon">
                <i class="ion ion-bag"></i>
              </div>
                <p>Centers</p>
                     <h4><asp:Label ID="lblcenter" runat="server" Text="0"></asp:Label></h4>
              </div>
             <a href="DCenterList.aspx" class="small-box-footer">Details <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
             <div class="col-lg-4 col-6">
            <!-- small box -->
            <%--<div class="small-box bg-gradient-purple">
              <div class="inner">
                  <div class="icon">
                <i class="ion ion-android-list"></i>
              </div>
                <p>Tests</p>
                <h4><asp:Label ID="lbltest" runat="server" Text="test"></asp:Label></h4>
              </div>
             <a href="#" class="small-box-footer">Details<i class="fas fa-arrow-circle-right"></i></a>
            </div>--%>
          </div>
              <div class="col-lg-4 col-6">
            <!-- small box -->
           <%-- <div class="small-box bg-danger">
              <div class="inner"> 
                  <div class="icon">
                <i class="ion ion-android-alert"></i>
              </div>              
                <p>Unread Answered Queries</p> 
                  <h4><asp:Label ID="lblQryreq" runat="server" Text="0"></asp:Label></h4>

              </div>
             <a href="CustomerSupport.aspx" class="small-box-footer">Details<i class="fas fa-arrow-circle-right"></i></a>
            </div>--%>

          </div>
            <div class="col-lg-4 col-6">
            <!-- small box -->
           <%-- <div class="small-box bg-secondary">
              <div class="inner">
                <div class="icon">
                <i class="ion ion-android-archive"></i>
              </div>
                <p>New Notification</p>
                    <h4><asp:Label ID="lblNotif" runat="server" Text="2"></asp:Label></h4>
              </div>
              
              <a href="Notifications.aspx" class="small-box-footer">Details<i class="fas fa-arrow-circle-right"></i></a>
            </div>--%>
          </div>
             <div class="col-lg-4 col-6">
            <!-- small box -->
          <%--  <div class="small-box bg-success">
              <div class="inner">
                  <div class="icon">
                <i class="ion ion-checkmark-circled"></i>
              </div>
                <p>My Wallet</p>
                <h4><asp:Label ID="lblmoney" runat="server" Text="10000"></asp:Label></h4>
              </div>
              <a href="#" class="small-box-footer">Details<i class="fas fa-arrow-circle-right"></i></a>
            </div>--%>
          </div>
            
            </div>
        </div>
         </section>
         </div>
</asp:Content>

