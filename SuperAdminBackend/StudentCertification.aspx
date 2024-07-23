<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentCertification.aspx.cs" Inherits="SuperAdminBackend_StudentCertification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
          <div class="col-sm-6">
            <h1 class="m-0">Pending Student Certificate</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Pending Student Certificate</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
            <div class="container-fluid">
                        <!-- Small boxes (Stat box) -->
                        <div class="row">


                            <div class="col-lg-3 col-sm-3">Enter Student ID to Search</div>
                            <div class="col-lg-3 col-sm-3">
                                <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-2">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click"><i class="fas fa-search"></i></asp:LinkButton>
                            </div>

                        </div>
                <div class="row">
                            <div class="col-12">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="20px"></asp:Label>
                            </div>
                        </div>
                <div class="row">
                      <div class="col-lg-12 col-md-12 mt-3">
                                <div style="width: 99%; height:350px; overflow: scroll;" id="div_print">
                                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table rounded-corners" 
                                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="bg-dark" RowStyle-CssClass="bg-info" 
                                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="8">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Center Details">
                                                <ItemTemplate>
                                                    
                                                    <asp:Button ID="btnCenters" runat="server" Text="View" CssClass="btn-info" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Generate">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="btn-success" OnClick="btnGenerate_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reject" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn-danger" OnClick="btnReject_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Details" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnStuDetails" runat="server" Text="View" CssClass="btn-info" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                             <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks" />
                                          
                                        </Columns>
                                        <EmptyDataTemplate>
                                        No Record found!!
                                    </EmptyDataTemplate>
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

