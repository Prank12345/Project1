<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="GalleryImage.aspx.cs" Inherits="SuperAdminBackend_GalleryImage" %>

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
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Gallery Image</h1>
                            </div>
                            <!-- /.col -->

                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
        <section class="content">
             <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:Label ID="lblGalleryImage" runat="server" Text="Choose Image For Gallery"></asp:Label>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                 <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:FileUpload ID="fupUloadImage" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                 <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Add" CssClass="btn btn-success btn-block" OnClick="btnSubmit_Click" />
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                   <div class="row mt-5">
                                    <div class="col-12">
                                         <div style="width:99%; overflow:scroll;">
                                             <asp:GridView ID="gvGallery" Width="100%" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table rounded-corners"
                                                 Style="-moz-border-radius: 25px; border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info"
                                                 AlternatingRowStyle-CssClass="table-secondary" runat="server" CellPadding="10" ForeColor="#333333" GridLines="None" 
                                                 OnRowDeleting="gvGallery_RowDeleting" HeaderStyle-HorizontalAlign="Center">
                                                 <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" />
                                                 <EditRowStyle BackColor="#2461BF" />
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                                         <ItemTemplate>
                                                             <%#Container.DataItemIndex+1 %>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>

                                                     <asp:ImageField HeaderText="Image Of The Gallery" ControlStyle-Height="200px" ControlStyle-Width="400px" DataImageUrlFormatString="~\GalleryImage\{0}" DataImageUrlField="GalleryImage" ItemStyle-HorizontalAlign="Center"></asp:ImageField>
                                                     <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                         <ItemTemplate>
                                                             <asp:LinkButton ID="lbdelete" runat="server" CssClass="btn btn-danger" CommandName="delete" OnClientClick="return confirmDel();"><i class="fas fa-trash"></i></asp:LinkButton>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                 </Columns>
                                                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                 <RowStyle BackColor="#EFF3FB" />
                                                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                             </asp:GridView>
                                             </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                        </div>
                 </div>

        </section>
    </div>
</asp:Content>

