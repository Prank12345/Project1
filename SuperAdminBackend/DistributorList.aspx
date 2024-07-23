<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="DistributorList.aspx.cs" Inherits="SuperAdminBackend_DistributorList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function printdiv(printpage) {
            var headstr = "<html><head></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
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
     <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Verified Distributor Details</h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
           
          
                    <div class="col-8" style="font-size:14px;">
                        <asp:Button ID="btnExport" runat="server" Text="Export To Excell" OnClick="btnExport_Click"/>
                   
                        
                    
                        <asp:Button ID="btnpdf" runat="server" Text="Save As PDf" OnClick="btnpdf_Click"/>
                    
                        <asp:Button ID="btnprint" runat="server" Text="Print Here"  OnClientClick="printdiv('div_print');" />
                    </div>
            <div class="col-lg-1 col-md-1">Search</div>
                    <div class="col-2">
                      <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Center Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click"><i class="fas fa-search"></i></asp:LinkButton>
                    </div>
                  
                       </div>
          <div class="row">
               <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-info btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbAll" runat="server" Text="All Distributors" ForeColor="White" OnClick="lbAll_Click"></asp:LinkButton></span>
                            </div>
                            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-warning btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbVerify" runat="server" ForeColor="White" Text="Distributor Verification Required" OnClick="lbVerify_Click"></asp:LinkButton>
                                    (<asp:Label ID="lblVerification" runat="server"></asp:Label>)</span>
                            </div>
                            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-success btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbVerified" runat="server" ForeColor="White" Text="Verified Distributors" OnClick="lbVerified_Click"></asp:LinkButton>
                                    (<asp:Label ID="lblVerified" runat="server"></asp:Label>)</span>
                            </div>
                            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-danger btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbRejected" runat="server" ForeColor="White" Text="Rejected Distributors" OnClick="lbRejected_Click"></asp:LinkButton>
                                    (<asp:Label ID="lblRejected" runat="server"></asp:Label>)</span>
                            </div>
          </div>
        
          <div class="row">
                <div class="col-lg-12 col-md-12 mt-3">
                    <div style="overflow:scroll;height:1200px;" id="div_print">
                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" 
                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%" OnRowDataBound="gvCenter_RowDataBound" OnRowDeleting="gvCenter_RowDeleting">
                         <AlternatingRowStyle/>
                       
                        <Columns>
                           <%-- <asp:TemplateField HeaderText="Center ID" HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                <ItemTemplate> 
                                   
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Distributor ID">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HFISActive" runat="Server" Value='<%# Eval("IsLogin") %>' />
                                     <asp:LinkButton ID="lbDistributor" runat="server" ForeColor="Black" OnClick="lnkbtnCenterLogin_Click"><%# Eval("DistributorID") %> </asp:LinkButton><br />
                                    <asp:Button ID="hlDeActivate" runat="server" Text="Deactive" CssClass="btn btn-danger" OnClick="hlDeActivate_Click" />
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Distributor's Image">
                                <ItemTemplate>
                                   
                            <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Distributor-Docs/" + Eval("PassportImage") %>' runat="server" ><asp:Image ID="imgPic" runat="server" ImageUrl='<%# "~/Distributor-Docs/" + Eval("PassportImage") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Distributor Details">
                                          <ItemTemplate>
                                               Name:-<%# Eval("FullName") %><br />
                                              Father's Name:<%# Eval("FatherName") %><br />
                                              Email:-<%# Eval("EmailID") %><br />
                                              Address:-<%# Eval("FullAddress") %>, State:-<%# Eval("State") %><br />
                                              DOB:- <%# Eval("DOB") %><br />
                                              Phone Number:- <%# Eval("PhoneNumber") %><br />
                                            
                                          </ItemTemplate>
                                      </asp:TemplateField>
                         <asp:TemplateField HeaderText="Distributor Documents" >
                                          <ItemTemplate>
                                              Cancelled Check:<br />
                                                <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Distributor-Docs/" + Eval("CancelledChk") %>' runat="server" ><asp:Image ID="imgSignature" runat="server" ImageUrl='<%# "~/Distributor-Docs/" + Eval("CancelledChk") %>' style="width:75px;height:100px;" /></asp:HyperLink><br />
                                               <%# Eval("IDProofType") %> Image:- <br /><asp:HyperLink target="_blank" NavigateUrl='<%# "~/Distributor-Docs/" + Eval("IDProofImg") %>' runat="server" ><asp:Image ID="imgID" runat="server" ImageUrl='<%# "~/Distributor-Docs/" + Eval("IDProofImg") %>' style="width:65px;height:100px;" /></asp:HyperLink><br />
                                  </ItemTemplate>
                                      </asp:TemplateField>
                           <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                               <ItemTemplate>   
                                   <asp:Button ID="btnCertificate" runat="server" Text="Generate Certificate" CssClass="btn btn-block btn-outline-warning bg-dark" style="border: solid 1px blue;" OnClick="lbCertificate_Click" />                                
                                   <asp:HyperLink ID="hlView" runat="server" CssClass="btn btn-block btn-warning" NavigateUrl='<%# "ViewDistCenter.aspx?DID="+Eval("id") %>'> View </asp:HyperLink>
                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-block btn-success" NavigateUrl='<%# "EditDistributor.aspx?DID="+Eval("id") %>'> Edit </asp:HyperLink>
                                    <asp:Button ID="hlResendEmail" runat="server" CssClass="btn btn-block btn-outline-success bg-gradient-gray-dark" ForeColor="White" BackColor="#159e32" Text="Resend Email" OnClick="hlResendEmail_Click"/>
                                    <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-block btn-danger" Text="Remove" CommandName="Delete" OnClientClick="return confirmDel();"> </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                        </Columns>
                        <FooterStyle />
                                        <HeaderStyle></HeaderStyle>
                                        <PagerStyle/>
                                        <RowStyle/>
                                        <SelectedRowStyle/>
                    </asp:GridView>

                </div>
            </div>
            </div>
          </div>
            </section>
        
        </div>
             
         
        </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnExport" />
             <asp:PostBackTrigger ControlID="btnpdf" />
         </Triggers>
    </asp:UpdatePanel>
      
</asp:Content>

