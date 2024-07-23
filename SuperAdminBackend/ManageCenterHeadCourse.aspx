<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageCenterHeadCourse.aspx.cs" Inherits="SuperAdminBackend_ManageCenterHeadCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-lg-12 col-md-12 mb-2">
                                <h1 class="m-0">Center Head Course</h1>
                            </div>
                            <!-- /.col -->
                            <div class="col-lg-8 col-sm-8"></div>
                            <div class="col-lg-4 col-sm-4" style="text-align:right;">
                                <a href="#" class="btn btn-info">Add Course+</a>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
                <section class="content">
                    <div class="container-fluid">
                        <!-- Small boxes (Stat box) -->
                        <div class="row">

                            <div class="col-lg-12 col-md-12 mt-3">
                                <div style="width: 99%; overflow: scroll;">
                                    <asp:GridView ID="gvCourse" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false"
                                        HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="8" BorderStyle="Solid" BorderWidth="2px" OnRowDeleting="gvCourse_RowDeleting">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         
                                            <asp:BoundField DataField="Course" HeaderText="Course" />
                                            
                                            <asp:BoundField DataField="Subject" HeaderText="Subject" />
                                          <asp:TemplateField HeaderText="Edit">
                                              <ItemTemplate>
                                                  <asp:HyperLink ID="hlEdit" Text="Edit" runat="server"></asp:HyperLink>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="lbRemove" Text="Remove" CommandName="Delete" OnClientClick="return confirmDel();" runat="server"></asp:LinkButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>