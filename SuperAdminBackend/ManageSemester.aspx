<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageSemester.aspx.cs" Inherits="SuperAdminBackend_ManageSemester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-lg-12 col-md-12 mb-2">
                                <h1 class="m-0">Manage Semesters</h1>
                            </div>
                           
                        </div>
                        </div>
                    </div>
     <section class="content">
                    <div class="container-fluid">
                        <!-- Small boxes (Stat box) -->
                        <div class="row">
                            <div class="col-8"></div>
                            <div class="col-4">
                                <asp:Button runat="server" ID="btnAdd" CssClass="btn-primary btn-block" OnClick="btnAdd_Click" Text="Add +" />
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-12 col-md-12 mt-3">
                                <div style="width: 99%; height:350px; overflow: scroll;">
                                    <asp:GridView ID="gvSemester" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" Width="100%"
                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center"  CellPadding="2" OnRowDeleting="gvSemester_RowDeleting">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:BoundField DataField="PaperCode" HeaderText="Paper Code" />
                                            <asp:BoundField DataField="ExamFees" HeaderText="Exam Fees" />
                                            <asp:BoundField DataField="Semester" HeaderText="Semester Name" />
                                            <asp:BoundField DataField="Subjects" HeaderText="Full Subjects" />
                                            
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-success" NavigateUrl='<%#"EditSemester.aspx?CID="+Eval("ID") %>'> <i class="fa fa-edit"></i></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                     <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-block btn-danger" Text="Remove" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fa fa-trash"></i></asp:LinkButton>
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

