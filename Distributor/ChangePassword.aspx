<%@ Page Title="" Language="C#" MasterPageFile="~/Distributor/DistributorMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Distributor_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
     <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Change Password</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Change Password</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>

     <section class="content">
      <div class="container-fluid">
          <div class="row mt">
          <div class="col-lg-12">
         
            <!-- /row -->
          </div>
          <!-- /col-lg-12 -->
          <div class="col-lg-12 mt">
                
               <div class="row">
                   <div class="col-xs-4"></div>
                   <div class="col-xs-4">
                       <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                   </div>
                   <div class="col-xs-4"></div>

               </div>
                    <div class="row mb-3">
                       
                        <div class="col-xs-6 col-md-4"></div>
                        </div>
                 <div class="row mb-3">
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>Old Password</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:TextBox ID="txtOld" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
                     <div class="col-xs-1"></div>
          </div>
               <div class="row mb-3">
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>New Password</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:TextBox ID="txtNew" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
                   <div class="col-xs-1"></div>
          </div>
               <div class="row mb-3">
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>Confirm Password</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:TextBox ID="txtConfirm" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
                   <div class="col-xs-1"></div>
          </div>
              <div class="row">
                  <div class="col-xs-5 col-md-5"></div>
                  <div class="col-xs-2 col-md-2">
                      <asp:LinkButton runat="server" ID="lnkbtnSubmit" CssClass="btn btn-success" OnClick="lnkbtnSubmit_Click" Autopostback="true"> Submit</asp:LinkButton>
                  </div>
                  <div class="col-xs-2 col-md-2">
                      <a href="Dashboard.aspx" class="btn btn-danger"> CLOSE</a>
                  </div>
                  <div class="col-xs-2 col-md-2"></div>
              </div>
              </div>
            </div>

          </div>
         </section>
        </div>
</asp:Content>

