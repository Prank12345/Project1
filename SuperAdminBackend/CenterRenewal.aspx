<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="CenterRenewal.aspx.cs" Inherits="SuperAdminBackend_CenterRenewal" %>

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
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Center Renewal Request</h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        
          <div class="row">
                <div class="col-lg-12 col-md-12 mt-3">
                    <div style="overflow:scroll; width:99%;" id="div_print">
                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false"  CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" BorderStyle="Solid"
                        AlternatingRowStyle-CssClass="table-secondary" Width="100%" HeaderStyle-HorizontalAlign="Center" CellPadding="8"
                        BorderWidth="2px" OnRowDataBound="gvCenter_RowDataBound">
                         <AlternatingRowStyle BackColor="#F7F7F7" />
                       
                        <Columns>
                            
                            <asp:BoundField HeaderText="Center ID" DataField="CenterID" />
                            <asp:TemplateField HeaderText="Center Head Pic">
                               <ItemTemplate>
                             <asp:Image runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("passportpic") %>' ImageAlign="Middle" Width="100px" Height="100px"></asp:Image><br />
                                   
                                   </ItemTemplate>
                                </asp:TemplateField>
                            <asp:BoundField HeaderText="Name" DataField="PersonName" />
                            
                            <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />
                         <asp:BoundField HeaderText="Institute Name" DataField="InstituteName" />
                           
                            <asp:BoundField HeaderText="State" DataField="State" />
                           <asp:BoundField HeaderText="Verified on" DataField="VerifyDate" />
                            <asp:BoundField HeaderText="Renewal date" DataField="RenewalDate" />
                             <asp:BoundField DataField="IsLogin" HeaderText="Renewed?" />
                            <asp:TemplateField HeaderText="Renew">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRenew" runat="server" AutoPostBack="True" OnCheckedChanged="chkRenew_CheckedChanged" />
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
</asp:Content>

