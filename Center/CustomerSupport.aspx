<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="CustomerSupport.aspx.cs" Inherits="Center_CustomerSupport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">New Query:</h1><p style="color:red;font-size:12px;">* Make sure read all our FAQs before asking any questions</p>
                            </div>
                            <!-- /.col -->

                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
        <section class="content">
            <div class="container-fluid">
                 <div class="card ml-xl-5 mr-xl-5">
                     <div class="card-body">

                         <div class="row">
                             <div class="col-lg-2 col-md-2 mb-1" style="text-align:left;">
                                 <span >Subject</span>
                             </div>
                            
                             <div class="col-lg-10 col-md-10 mb-1" style="text-align:left">
                                 <asp:TextBox ID="txtSubject" required CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             
                             <div class="col-lg-2 col-md-3 mb-1" style="text-align:left"> 
                                 <span >Message</span>
                             </div>
                           
                             <div class="col-lg-10 col-md-9 mb-1">
                                 <asp:TextBox ID="txtDesc" TextMode="MultiLine" Height="70" required CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                             
                             <div class="col-4"></div>
                             <div class="col-4">
                                 <asp:LinkButton ID="lbSubmit" runat="server" Text="Send" CssClass="btn btn-primary btn-block" OnClick="lbSubmit_Click"></asp:LinkButton>
                             </div>
                             <div class="col-4"></div>
                         </div>
                     </div>
                     
                  <div class="card-footer">
                      <div class="row">
                          <div class="col-12">
                                <div id="ModalViewAnswer" class="modal fade" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Answer</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-6">Question</div>
                                                    <div class="col-6"><asp:Label ID="lblViewques" runat="server"></asp:Label></div>
                                                   
                                                    <div class="col-6">Answer</div>
                                                    <div class="col-6">
                                                       <asp:Label ID="lblViewAns" runat="server"></asp:Label>
                                                    </div>
                                                   
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
                            <div class="col-12">
                                <p style="font-size: 20px;">Queries</p>
                                <div style="width:99%;height:300px; overflow:scroll;">
                                <asp:GridView ID="gvquery" runat="server" CellPadding="4" Width="100%" DataKeyNames="ID" AutoGenerateColumns="false" GridLines="None" 
                                    OnRowDataBound="gvquery_RowDataBound" CssClass="table rounded-corners" style= "-moz-border-radius: 25px;border-radius: 25px;" 
                                    HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                               <asp:HiddenField ID="HFISActive" runat="Server" Value='<%# Eval("isReply") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:BoundField HeaderText="Query" DataField="Subject" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Brief Description" DataField="Problemdetails" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="View Answers" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnViewAns" runat="server" CssClass="btn-info" Text="View" OnClick="btnViewAns_Click" formnovalidate  />
                                                <asp:Label ID="lblTextView" runat="server" ForeColor="Red"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
            </section>
        </div>
             <script type="text/javascript">
                 function OpenViewAnswer() {
                    
                     $('#ModalViewAnswer').modal('show');
                  
                }

            </script>
            </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

