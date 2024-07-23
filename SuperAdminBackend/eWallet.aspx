<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="eWallet.aspx.cs" Inherits="SuperAdminBackend_eWallet" %>

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
     <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
              <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">E-Wallet</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">E-Wallet</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <%--<div class="col-2"></div>
            <div class="col-6">
                <div class="row">
                    <div class="col-12">
                        <span>Enter Amount</span><br />
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                  
                </div>
            </div>--%>
            <div class="col-12" style="text-align:center">
                <%--<span>
                <img src="../Image/coins1.gif" alt="" style="height:150px;" /><br /><br />
                    <span style="" class="btn btn-primary">Balance:
                    <asp:Label ID="lblBalance" runat="server" Text="0"></asp:Label></span>
                </span>--%>
            </div>
            <div class="col-12">
                  <div class="modal" id="ModalCenter">
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
                                                    <div class="col-6"><asp:Label ID="lblCenID" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center Name</div>
                                                    <div class="col-6"><asp:Label ID="lblCenterName" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center Address</div>
                                                    <div class="col-6"><asp:Label ID="lblCAddr" runat="server"></asp:Label></div>
                                                    <div class="col-6">Mobile Number</div>
                                                    <div class="col-6"><asp:Label ID="lblMN" runat="server"></asp:Label></div>
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
           <div class="col-12">
                <div style="overflow: scroll; height:500px;">
                  <asp:GridView ID="gvTransact" runat="server" Width="100%"  DataKeyNames="ID" CssClass="table rounded-corners"  style= "-moz-border-radius: 25px;border-radius: 25px;" 
                            HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" AutoGenerateColumns="false" 
                      OnRowDataBound="gvTransact_RowDataBound" OnRowDeleting="gvTransact_RowDeleting">
                                 <Columns>
                                      <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                                <asp:HiddenField ID="HFISActive" runat="Server" Value='<%# Eval("Credit") %>' />
                                                 <asp:HiddenField ID="hfDebit" runat="Server" Value='<%# Eval("Debit") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Center Name">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnCenterDetail" runat="server" CssClass="bg-cyan" OnClick="lnkbtnCenterDetail_Click"><%# Eval("InstituteName") %></asp:LinkButton>
                                </ItemTemplate>
                                         </asp:TemplateField>
                                    
                                     <asp:BoundField HeaderText="Amount" DataField="Amount"/>
                                     <asp:BoundField HeaderText="Payment Date" DataField="PayDate"/>
                                     <asp:BoundField HeaderText="Transaction Description" DataField="Particulars"/>
                                       <asp:TemplateField HeaderText="Payment Screenshot">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/CenterPayment/" + Eval("PaySlip") %>' runat="server" ><asp:Image ID="imgPic" runat="server" ImageUrl='<%# "~/CenterPayment/" + Eval("PaySlip") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Verify Transaction">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnVerify" runat="server" Text="Verify" CssClass="btn-success" OnClick="btnVerify_Click"/>
                                                    <asp:Label ID="lblText" runat="server" ForeColor="SpringGreen"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete">
                                         <ItemTemplate>
                                             <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-danger mt-2" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fa fa-trash"></i> </asp:LinkButton>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                    </div>
           </div>
            </div>
          </div>
        </section>
        </div>
             <script type="text/javascript">
                function openCenter() {
                    $('#ModalCenter').modal('show');
                  
                }

            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

