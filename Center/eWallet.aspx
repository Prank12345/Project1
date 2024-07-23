<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="eWallet.aspx.cs" Inherits="Center_eWallet" %>

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
            <div class="col-2"></div>
            <div class="col-6">
                <div class="row">
                    <div class="col-12">
                        <span>Enter Amount</span><br />
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-12">
                        <span>Narration</span><br />
                        <asp:TextBox ID="txtNarrate" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class="col-12">
                        <span>Date of Payment</span><br />
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                     <div class="col-12">
                        <span>Payment Screenshot</span><br />
                        <asp:FileUpload ID="fupPaySlip" runat="server" />
                    </div>
                     
                </div>
            </div>
            <div class="col-4">
                <span>
                <img src="../Image/coins1.gif" alt="" style="height:150px;" />
                    <span style="" class="btn btn-primary">Balance:
                    <asp:Label ID="lblBalance" runat="server" Text="0"></asp:Label></span>
                </span>
            </div>
             <div class="col-4 mt-3"></div>
            <div class="col-4 mt-3" style="text-align:center">
                       
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
            <div class="col-4 mt-3"></div>
            </div>
          <div class="row">
              <div class="col-12">
                  <div style="overflow: scroll; height:500px;">
                  <asp:GridView ID="gvTransact" runat="server" Width="100%"  DataKeyNames="ID" CssClass="table rounded-corners" HeaderStyle-CssClass="table-sm bg-dark"
                      style= "-moz-border-radius: 25px;border-radius: 25px;" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" 
                      AutoGenerateColumns="false" OnRowDataBound="gvTransact_RowDataBound">
                                 <Columns>
                                      <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>                                    
                                     <asp:BoundField HeaderText="Amount" DataField="Amount"/>
                                     <asp:BoundField HeaderText="Payment Date" DataField="PayDate"/>
                                      <asp:BoundField HeaderText="Credit?" DataField="Credit"/>
                                     <asp:BoundField HeaderText="Debit?" DataField="Debit"/>
                                     <asp:BoundField HeaderText="Transaction Description" DataField="Particulars"/>
                                      <asp:TemplateField HeaderText="Transaction Image">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/CenterPayment/" + Eval("PaySlip") %>' runat="server" ><asp:Image ID="imgPic" runat="server" ImageUrl='<%# "~/CenterPayment/" + Eval("PaySlip") %>' style="width:100px;height:100px;" /></asp:HyperLink>
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
</asp:Content>

