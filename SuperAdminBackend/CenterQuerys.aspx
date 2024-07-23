<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="CenterQuerys.aspx.cs" Inherits="SuperAdminBackend_CenterQuerys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="updpnl1">
        <ContentTemplate>

        
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card">
                    <div class="card-body">
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

                                <div id="ModalSendAnswer" class="modal fade" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Send Answer</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-6">Question</div>
                                                    <div class="col-6"><asp:Label ID="lblQuestion" runat="server"></asp:Label></div>
                                                    <div class="col-6">Brief Detail of Query</div>
                                                    <div class="col-6"><asp:Label ID="lblqryAns" runat="server"></asp:Label></div>
                                                    <div class="col-6">Answer</div>
                                                    <div class="col-6">
                                                        <asp:HiddenField ID="HFISActive" runat="Server" />
                                                        <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                   
                                                </div>
                                                
                                            </div>

                                            <!-- Modal footer -->
                                            <div class="modal-footer">
                                                <asp:Button runat="server" CssClass="btn btn-success" Text="Send" ID="btnSendAns" OnClick="btnSendAns_Click" />
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
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
                                                    <div class="col-6">Brief Detail of Query</div>
                                                    <div class="col-6"><asp:Label ID="lblViewProb" runat="server"></asp:Label></div>
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
                                <p style="font-size: 20px;">Center Queries</p>
                                <asp:GridView ID="gvquery" runat="server" CellPadding="4" Width="100%" AutoGenerateColumns="false" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info"  DataKeyNames="ID" 
                        AlternatingRowStyle-CssClass="table-secondary"  ForeColor="#333333" GridLines="None" OnRowDataBound="gvquery_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                                <asp:HiddenField ID="HFISActive" runat="Server" Value='<%# Eval("isReply") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Center Details" ItemStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                              
                                               <asp:Button ID="btnCenter" runat="server" CssClass="btn-info" Text="View" OnClick="btnCenter_Click" />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:BoundField HeaderText="Query" DataField="Subject" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Brief Description" DataField="Problemdetails" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="View Answers" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnViewAns" runat="server" CssClass="btn-info" Text="View" OnClick="btnViewAns_Click" />
                                                 <asp:Label ID="lblTextView" runat="server" ForeColor="Red"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Answers" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" CssClass="btn-success" Text="Reply"/>
                                                <asp:Label ID="lblText" runat="server" ForeColor="Green"></asp:Label>
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
        </section>
    </div>
             <script type="text/javascript">
                 function openCer() {
                    
                    $('#ModalCen').modal('show');
                  
                }

            </script>
             <script type="text/javascript">
                 function openAnswerSend() {
                    
                     $('#ModalSendAnswer').modal('show');
                  
                }

            </script>
            <script type="text/javascript">
                 function OpenViewAnswer() {
                    
                     $('#ModalViewAnswer').modal('show');
                  
                }

            </script>
            </ContentTemplate>
       <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCenter" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>

