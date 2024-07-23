<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ExamList.aspx.cs" Inherits="SuperAdminBackend_ExamList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
              <div class="content-wrapper">
    <!-- Content Header (Page header) -->
     <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Exam List</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Student Verification</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
         <div class="row">
           
          
                    <div class="col-8" style="font-size:14px;">
                        
                    </div>
            <div class="col-lg-1 col-md-1">Search</div>
                    <div class="col-2">
                      <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary"><i class="fas fa-search"></i></asp:LinkButton>
                    </div>
                  
                       </div>
           <div class="row">
                            <div class="col-12">
                                <div id="ModalCen" class="modal fade" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Center Details</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-6">Center ID</div>
                                                    <div class="col-6"><asp:Label ID="lblCenterID" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center Name</div>
                                                    <div class="col-6"><asp:Label ID="lblCenterName" runat="server"></asp:Label></div>
                                                     <div class="col-6">Center Head Name</div>
                                                    <div class="col-6"><asp:Label ID="lblPersonName" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center Address</div>
                                                    <div class="col-6"><asp:Label ID="lblCAddr" runat="server"></asp:Label></div>
                                                </div>
                                                
                                            </div>

                                            <!-- Modal footer -->
                                            <div class="modal-footer">
                                                
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div id="modelques" class="modal fade" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Center Details</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <asp:Repeater ID="rptQues" runat="server">
                                                        <ItemTemplate>
                                                            <div class="col-12">
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        <asp:Label ID="lblQues" runat="server"><%# Eval("Question") %></asp:Label>
                                                                    </div>
                                                                    <div class="col-6">
                                                                        <asp:Label ID="lblans1" runat="server"><%# Eval("Option1") %></asp:Label>
                                                                    </div>
                                                                     <div class="col-6">
                                                                        <asp:Label ID="lblans2" runat="server"><%# Eval("Option2") %></asp:Label>
                                                                    </div>
                                                                     <div class="col-6">
                                                                        <asp:Label ID="lblans3" runat="server"><%# Eval("Option3") %></asp:Label>
                                                                    </div>
                                                                     <div class="col-6">
                                                                        <asp:Label ID="lblans4" runat="server"><%# Eval("Option4") %></asp:Label>
                                                                    </div>
                                                                     <div class="col-12">
                                                                         Correct Answer &nbsp;
                                                                        <asp:Label ID="lblcorrectans" runat="server"><%# Eval("CorrectAnswer") %></asp:Label>
                                                                    </div>
                                                                </div>
                                                                
                                                                
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                   
                                                </div>
                                                
                                            </div>

                                            <!-- Modal footer -->
                                            <div class="modal-footer">
                                                
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
          <div class="row">
                <div class="col-lg-12 col-md-12 mt-3">
                    <div style="width:99%; overflow:scroll;">
                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false"
                        HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="8"  BorderStyle="Solid" BorderWidth="2px">
                         <AlternatingRowStyle BackColor="#F7F7F7" />
                       
                        <Columns>
                           <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:BoundField DataField="ID" HeaderText="Exam ID"/>
                            <asp:BoundField DataField="ExamName" HeaderText="Exam Name"/>
                            <asp:BoundField DataField="ExamType" HeaderText="Type"/>
                            <asp:BoundField DataField="CreatedOn" HeaderText="Created On"/>
                            <asp:TemplateField HeaderText="Questions" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                   
                                    <asp:Button  ID="lbques" runat="server" CssClass="btn-info" Text="View" OnClick="lbques_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Center Details" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    
                                    <asp:Button ID="lbCenDetail" runat="server" CssClass="btn-info" OnClick="lbCenDetail_Click" Text="View"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#b5dedc" ForeColor="#3d8c3c" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="#e5e1fc" Font-Bold="True" 
                            ForeColor="#3d1d1d" BorderColor="#ddd" ></HeaderStyle>
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
      <script type="text/javascript">
                 function openCer() {
                    
                    $('#ModalCen').modal('show');
                  
                }

            </script>
             <script type="text/javascript">
                 function openQues() {
                    
                     $('#modelques').modal('show');
                  
                }

            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

