<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="Downloads.aspx.cs" Inherits="SuperAdminBackend_Downloads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
    <style>
        .rounded-corners {
  border: 1px solid black;
  -webkit-border-radius: 8px;
  -moz-border-radius: 8px;
  border-radius: 8px;
  overflow: hidden;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-lg-12 col-md-12 mb-2">
                                <h1 class="m-0">Downloads</h1>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-12 col-md-12 mb-2" style="text-align:center">
                                <h4 class="m-0">Add File</h4>
                            </div>
                           
                        </div>
                          <div class="row mb-2">
                            <div class="col-lg-3 col-sm-12 mb-2">
                                File Name
                            </div>
                            <div class="col-lg-9 col-sm-12 mb-2">
                             <asp:TextBox runat="server" ID="txtfileName" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-3 col-sm-12 mb-2">
                                File Upload
                            </div>
                            <div class="col-lg-9 col-sm-12 mb-2">
                               <asp:FileUpload ID="fup" runat="server" />
                            </div>
                           
                        </div>
                      
                        <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                            <div class="col-lg-4 col-sm-12 mb-2" style="text-align:center;">
                               <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-success btn-block" Text="Upload" OnClick="btnUpload_Click"/>
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                           
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </div>
                <section class="content">
                    <div class="container-fluid">
                        <div class="row">

                            <div class="col-lg-12 col-md-12 mt-3">
                                <div style="width: 99%; height:350px; overflow: scroll;">
                                    <asp:GridView ID="gvDownloads" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" 
                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="8" BorderStyle="Solid" 
                                        BorderWidth="2px" OnRowDeleting="gvDownloads_RowDeleting">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:BoundField DataField="FileName" HeaderText="File Name" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="File" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlDown" CssClass="btn btn-success" runat="server" NavigateUrl='<%#"~/Downloads/"+Eval("UploadFile") %>' Target="_blank"><i class="fas fa-download"></i></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbRemove" runat="server" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fa fa-trash"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                          <FooterStyle BackColor="#b5dedc" ForeColor="#3d8c3c" />
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#e5e1fc" Font-Bold="True"
                                            ForeColor="#3d1d1d" BorderColor="#ddd"></HeaderStyle>
                                        <PagerStyle BackColor="#ddf2d8" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                        <RowStyle VerticalAlign="Top" BackColor="#f5edfc" ForeColor="#4A3C8C" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#f0f9fc" />
                                            </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            
</asp:Content>