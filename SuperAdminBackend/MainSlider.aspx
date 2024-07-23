<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="MainSlider.aspx.cs" Inherits="SuperAdminBackend_MainSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function confirmDel() {
            return confirm("Are you sure to DELETE this?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Main Slider Images</h1>
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
                                        <asp:Label ID="lblGalleryImage" runat="server" Text="Choose Image For Slider"></asp:Label>
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
                                        <asp:FileUpload ID="fupImage2" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                  <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:FileUpload ID="fupImage3" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                  <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:FileUpload ID="fupImage4" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                  <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:FileUpload ID="fupImage5" runat="server" CssClass="form-control" />
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
                                         <div style="height:1000px; overflow:scroll;">
                                             <asp:GridView ID="gvMainSlider" Width="100%" DataKeyNames="id" AutoGenerateColumns="false" HeaderStyle-Wrap="false" runat="server" CellPadding="10"
                                                 ForeColor="#333333" GridLines="None" OnRowDeleting="gvMainSlider_RowDeleting" HeaderStyle-HorizontalAlign="Center" CssClass="table table-responsive"
                                                 Style="-moz-border-radius: 25px; border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info"
                                                 AlternatingRowStyle-CssClass="table-secondary">
                                                 <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" />
                                                 <EditRowStyle BackColor="#2461BF" />
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                                         <ItemTemplate>
                                                             <%#Container.DataItemIndex+1 %>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>

                                                     <asp:ImageField HeaderText="Slider Image 1" ControlStyle-Height="150px" ControlStyle-Width="158px" DataImageUrlFormatString="~\MainSlider\{0}" DataImageUrlField="Image1" ItemStyle-HorizontalAlign="Center"></asp:ImageField>
                                                     <asp:ImageField HeaderText="Slider Image 2" ControlStyle-Height="150px" ControlStyle-Width="158px" DataImageUrlFormatString="~\MainSlider\{0}" DataImageUrlField="Image2" ItemStyle-HorizontalAlign="Center"></asp:ImageField>
                                                     <asp:ImageField HeaderText="Slider Image 3" ControlStyle-Height="150px" ControlStyle-Width="158px" DataImageUrlFormatString="~\MainSlider\{0}" DataImageUrlField="Image3" ItemStyle-HorizontalAlign="Center"></asp:ImageField>
                                                     <asp:ImageField HeaderText="Slider Image 4" ControlStyle-Height="150px" ControlStyle-Width="158px" DataImageUrlFormatString="~\MainSlider\{0}" DataImageUrlField="Image4" ItemStyle-HorizontalAlign="Center"></asp:ImageField>
                                                     <asp:ImageField HeaderText="Slider Image 5" ControlStyle-Height="150px" ControlStyle-Width="158px" DataImageUrlFormatString="~\MainSlider\{0}" DataImageUrlField="Image5" ItemStyle-HorizontalAlign="Center"></asp:ImageField>
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

