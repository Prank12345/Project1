<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="SendNotifocation.aspx.cs" Inherits="SuperAdminBackend_SendNotifocation" %>

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
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
     <div class="content-wrapper">
         <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Notification Center</h1>
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
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="nav flex-column nav-tabs nav-tabs-right h-100" id="vert-tabs-right-tab" role="tablist" aria-orientation="vertical">
                  <a class="nav-link active p-xl-5" id="vert-tabs-right-home-tab" data-toggle="pill" href="#vert-tabs-home" role="tab" aria-controls="vert-tabs-right-home" aria-selected="true">General Notification</a>
                  <a class="nav-link p-xl-5" id="vert-tabs-right-profile-tab" data-toggle="pill" href="#vert-tabs-profile" role="tab" aria-controls="vert-tabs-right-profile" aria-selected="false">Custom Notification</a>
                  </div>
                        </div>
                        <div class="col-12 col-sm-9">
                <div class="tab-content" id="vert-tabs-tabContent">
                  <div class="tab-pane text-left fade show active" id="vert-tabs-home" role="tabpanel" aria-labelledby="vert-tabs-home-tab">
                      <p class="mt-1">Notification To</p>
                     <asp:DropDownList ID="ddlNotificationTo" runat="server" CssClass="form-control">
                         <asp:ListItem Text="Choose Category" Value="0" Selected="True" disabled="disabled"></asp:ListItem>
                         <asp:ListItem Text="Center" Value="1"></asp:ListItem>
                         <asp:ListItem Text="Student" Value="2"></asp:ListItem>
                         <asp:ListItem Text="Website" Value="3"></asp:ListItem>
                     </asp:DropDownList>
                      <asp:TextBox ID="txtMessage" placeholder="Enter Your Notification Text Here.." runat="server" CssClass="form-control mt-4" TextMode="MultiLine" Height="100"></asp:TextBox>
                      <asp:LinkButton ID="lnkbtnSend" runat="server" Text="Send" CssClass="btn btn-block btn-success mt-4" OnClick="lnkbtnSend_Click"></asp:LinkButton>
                  </div>
                  <div class="tab-pane fade" id="vert-tabs-profile" role="tabpanel" aria-labelledby="vert-tabs-profile-tab">
                    <div style="width:100%; height:250px; overflow:scroll;">
                        <asp:GridView ID="gvCenterNotif" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" CssClass="table rounded-corners" 
                            HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" 
                            style= "-moz-border-radius: 25px;border-radius: 25px;" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate><asp:CheckBox ID="checkAll" Text="Select Center" onclick="checkAll(this);" runat="server" /></HeaderTemplate>
                                    <ItemTemplate>
                                         <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" CommandArgument='<%# Eval("ID") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Notification To" DataField="InstituteName" />
                                
                            </Columns>
                        </asp:GridView>
                    </div>
                      <asp:FileUpload ID="fup" runat="server" CssClass="mt-2" />

                      <asp:TextBox ID="txtMsg" placeholder="Enter Your Notification Text Here.." runat="server" CssClass="form-control mt-4" TextMode="MultiLine" Height="100"></asp:TextBox>
                      <asp:LinkButton ID="lnkbtnSendCenter" runat="server" Text="Send" CssClass="btn btn-block btn-success mt-4" OnClick="lnkbtnSendCenter_Click"></asp:LinkButton>
                  </div>
                 
                </div>
              </div>
                        </div>
                    <div class="row mt-3">
                        <div class="col-12">
                            <div id="ModalEdit" class="modal fade" role="dialog" >
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Edit</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                     
                 </div>
                 <div class="modal-body">
                   
                     <asp:Label ID="lblShowSendTo" runat="server"></asp:Label><br />
                     <asp:Label ID="lblMsgID" runat="server"></asp:Label><br />
                     <asp:TextBox ID="txtUpdateMessage" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Message to be editted for Notification"></asp:TextBox>
                  </div>
                  <div class="modal-footer">
                      <asp:Button CssClass="btn btn-success" ID="btnUdate" runat="server" Text="Update" OnClick="btnUdate_Click" />
                      <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                 </div>
              </div>
          </div>
      </div>
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
                    </div>
                    <div class="row mt-3">
                        <div class="col-12" style="height:300px; overflow:scroll;">
                            <asp:GridView ID="gvNotification" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table rounded-corners" HeaderStyle-CssClass="table-sm bg-dark" 
                                RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" style= "-moz-border-radius: 25px;border-radius: 25px;" 
                                HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="8"  OnRowDataBound="gvNotification_RowDataBound" OnRowDeleting="gvNotification_RowDeleting" 
                                HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">
                                 <AlternatingRowStyle BackColor="#F7F7F7" />
                                 <Columns>
                                      <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <asp:BoundField HeaderText="Notification" DataField="NotifMessage" />
                                     <asp:BoundField HeaderText="For" DataField="SubmittedTo"/>
                                    
                                    <asp:TemplateField HeaderText="Attachment">
                                         <ItemTemplate>
                                             <asp:Button ID="lnkView" runat="server" Text="View" CssClass="btn btn-success" OnClick="lnkView_Click" />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Edit">
                                         <ItemTemplate>
                                             <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-warning" Text="Edit" />
                                             
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete">
                                         <ItemTemplate>
                                             <asp:LinkButton ID="lbRemove" runat="server" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fas fa-trash"></i></asp:LinkButton>
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
            </section>
         </div>
    
     <script type="text/javascript">
         function openEditModal() {
             
             $('#ModalEdit').modal('show');
           }

        </script> 
            <script type="text/javascript">
         function ViewAttach() {
             
             $('#ModalView').modal('show');
           }

        </script> 
               <script type = "text/javascript">

    function checkAll(objRef) {

        var GridView = objRef.parentNode.parentNode.parentNode;

        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {

            //Get the Cell To find out ColumnIndex

            var row = inputList[i].parentNode.parentNode;

            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                if (objRef.checked) {

                   

                    inputList[i].checked = true;

                }

                else {

                    

                    if (row.rowIndex % 2 == 0) {

                       

                    }

                    else {

                       

                    }

                    inputList[i].checked = false;

                }

            }

        }

    }

</script> 
            </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="lnkbtnSendCenter" />
         </Triggers>
         </asp:UpdatePanel>

</asp:Content>

