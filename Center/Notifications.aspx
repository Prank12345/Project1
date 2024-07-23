<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="Notifications.aspx.cs" Inherits="Center_Notifications" %>

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
    <asp:UpdatePanel ID="upd" runat="server">

        <ContentTemplate>
             <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Notifications</h1>
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
                    <div class="row mt-3">
                        <div class="col-12">
                             <div id="ModalView" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Attachment Preview</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                     
                 </div>
                 <div class="modal-body">
                     <asp:Image ID="imgPreview" runat="server" CssClass="img-fluid" />
                     <asp:Label ID="lblShowAttachName" runat="server"></asp:Label>
                  </div>
                  <div class="modal-footer">
                     <%-- <asp:Button runat="server" ID="btnDownload" CssClass="btn btn-success" Text="Download" />--%>
                      <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                 </div>
              </div>
          </div>
      </div>
                        </div>
                        <div class="col-12" style="width:99%;height:300px; overflow:scroll;">
                            <asp:GridView ID="gvNotification" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" 
                        AlternatingRowStyle-CssClass="table-secondary" Width="100%" CellPadding="8">
                              
                                 <Columns>
                                      <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="ID" DataField="MsgID" />
                                      <asp:BoundField HeaderText="Notification" DataField="NotifMessage" />
                                    <asp:TemplateField HeaderText="Attachment">
                                         <ItemTemplate>
                                             <asp:Button ID="lnkView" runat="server" Text="View" CssClass="btn btn-primary" OnClick="lnkView_Click"/>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     
                                    
                                     </Columns>
                              
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                   
                            </asp:GridView>
                        </div>
                    </div>
                    </div>
                </section>
          </div>
            <script type="text/javascript">
         function ViewAttach() {
             
             $('#ModalView').modal('show');
           }

        </script> 
        </ContentTemplate>
    </asp:UpdatePanel>
     
</asp:Content>

