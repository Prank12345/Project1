<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageTeam.aspx.cs" Inherits="SuperAdminBackend_ManageTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
    <style>
        .rounded-corners {
  /*border: 1px solid black;*/
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
                            <div class="col-lg-12 col-sm-12 mb-2">
                                <h1 class="m-0">Our Awsome Team</h1>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-12 col-sm-12 mb-2" style="text-align:center">
                                <h4 class="m-0">Add Team Member</h4>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2">
                                Member Name
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                           
                        </div>
                         <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2">
                                Designation
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:TextBox ID="txtDesig" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                           
                        </div>
                         <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2">
                                Image
                            </div>
                            <div class="col-lg-8 col-sm-12 mb-2">
                                <asp:FileUpload ID="fupImage" runat="server" />
                            </div>
                            
                           
                        </div>
                          <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                            <div class="col-lg-4 col-sm-12 mb-2" style="text-align:center;">
                               <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click"/>
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                           
                        </div>
                    <!-- /.container-fluid -->
                </div>
                    </div>
                <section class="content">
                    <div class="container-fluid"> 
                    <div class="row">
                      
                            <div class="col-lg-4 col-sm-8">
                                <span>Our Team Member Name</span><br />
                                 <asp:TextBox ID="txtSearch" placeholder="Search" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            <div class="col-lg-2 col-sm-2">
                                <br />
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" ><i class="fas fa-search"></i></asp:LinkButton>
                            </div>
                         <div class="col-lg-6 col-sm-1">
                           
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="20px"></asp:Label>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-12 col-sm-12 mt-3">
                                <div style="height:1400px; overflow: scroll;">
                                    <asp:GridView ID="gvCenter" CssClass="table rounded-corners" style= "-moz-border-radius: 25px;border-radius: 25px;" 
                                        HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" 
                                        runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" 
                                        Width="100%" CellPadding="8" OnRowDeleting="gvCenter_RowDeleting">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:BoundField DataField="TeamName" HeaderText="Name" />
                                            <asp:BoundField DataField="TeamDesig" HeaderText="Designation" />
                                           <asp:TemplateField HeaderText="Image">
                                                <ItemTemplate>
                                                   <asp:HyperLink target="_blank" NavigateUrl='<%# "~/images/" + Eval("ImageUpload") %>' runat="server" ><asp:Image ID="imgPic" runat="server" ImageUrl='<%# "~/images/" + Eval("ImageUpload") %>' style="width:150px;height:170px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%#"EditTeam.aspx?TID="+Eval("ID") %>' CssClass="btn btn-warning"> <i class="fa fa-edit"></i></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbRemove" runat="server" CommandName="Delete" OnClientClick="return confirmDel();" CssClass="btn btn-danger"><i class="fa fa-trash"></i></asp:LinkButton>
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

