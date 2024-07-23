<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="PopupBanner.aspx.cs" Inherits="SuperAdminBackend_PopupBanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div class="content-wrapper">
      <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Manage Popup Banner</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Manage Popup Banner</li>
            </ol>
          </div>
        </div>
      </div>
    </div>
            <section class="content">
      <div class="container-fluid">
        
       
           <div class="row mt-3 mb-3">
            <div class="col-lg-2 col-sm-12 ">Image</div>
            <div class="col-lg-10 col-sm-12">
                <asp:Image ID="imgImage" runat="server" Width="400px" Height="400px" /><br />
                
                <asp:Label ID="lblImg" runat="server"></asp:Label><br />
                <asp:FileUpload runat="server" ID="fup" />
            </div>
            </div>
           <div class="row">
            <div class="col-lg-2 col-sm-12">Text</div>
            <div class="col-lg-10 col-sm-12">
                <asp:TextBox ID="txtH2" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            </div>
          </div>
                 <div class="row mt-3">
           
            <div class="col-lg-12 col-sm-12">
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="btn btn-success btn-block" Text="Update" />
            </div>
            </div>
                </section>
            </div>
            
</asp:Content>

