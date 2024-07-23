<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="SendPassword.aspx.cs" Inherits="SuperAdminBackend_SendPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <div class="content-wrapper">
     <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Send Password</h1>
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
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>Center Name</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:DropDownList ID="ddlCenter" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
              </div>
                     <div class="col-xs-1"></div>
          </div>
                <div class="row mb-3">
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>Email Address</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
              </div>
                     <div class="col-xs-1"></div>
          </div>
               <div class="row mb-3">
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>Genrate Password</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:TextBox ID="txtPassGen" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
                   <div class="col-xs-1"></div>
          </div>
               <div class="row mb-3">
              <div class="col-xs-1"></div>
              <div class="col-xs-4 col-md-4"><label>Generate Center ID</label></div>
              <div class="col-xs-5 col-md-5">
                  <asp:TextBox ID="txtCenterIDGen" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
                   <div class="col-xs-1"></div>
          </div>
              <div class="row">
                  <div class="col-xs-5 col-md-5"></div>
                  <div class="col-xs-2 col-md-2">
                      <asp:LinkButton runat="server" ID="lnkbtnSend" CssClass="btn btn-success" OnClick="lnkbtnSend_Click" Autopostback="true"> Send</asp:LinkButton>
                  </div>
                  <div class="col-xs-2 col-md-2">
                      <a href="AdminDashboard.aspx" class="btn btn-danger"> CLOSE</a>
                  </div>
                  <div class="col-xs-2 col-md-2">
                       <asp:Button ID="btnClick" runat="server" Text="Click Me" CssClass="btn btn-danger"  OnClick="btnClickMe_Click"/>
                  </div>
              </div>
              </div>
            </div>

          </div>
      
         </section>
        </div>

</ContentTemplate>
        
        </asp:UpdatePanel>
</asp:Content>

