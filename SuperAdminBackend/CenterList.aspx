<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="CenterList.aspx.cs" EnableEventValidation="false" Inherits="SuperAdminBackend_CenterList" %>

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
            <h1 class="m-0">Verified Center Details</h1>
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
                                    <asp:LinkButton ID="lbAll" runat="server" Text="All Center" ForeColor="White" OnClick="lbAll_Click"></asp:LinkButton></span>
                            </div>
                            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-warning btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbVerify" runat="server" ForeColor="White" Text="Center Verification Required" OnClick="lbVerify_Click"></asp:LinkButton>
                                    (<asp:Label ID="lblVerification" runat="server"></asp:Label>)</span>
                            </div>
                            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-success btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbVerified" runat="server" ForeColor="White" Text="Verified Centers" OnClick="lbVerified_Click"></asp:LinkButton>
                                    (<asp:Label ID="lblVerified" runat="server"></asp:Label>)</span>
                            </div>
                            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-danger btn-block" style="text-align: center;">
                                    <asp:LinkButton ID="lbRejected" runat="server" ForeColor="White" Text="Rejected Centers" OnClick="lbRejected_Click"></asp:LinkButton>
                                    (<asp:Label ID="lblRejected" runat="server"></asp:Label>)</span>
                            </div>
          </div>
          <div class="row">
                            <div class="col-12">
                                <!-- The Modal -->
                                <div class="modal" id="ModalView">
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
                                                    <div class="col-6">Center Head Name</div>
                                                    <div class="col-6"><asp:Label ID="lblHeadName" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center ID</div>
                                                    <div class="col-6"><asp:Label ID="lblCenterID" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center Name</div>
                                                    <div class="col-6"><asp:Label ID="lblCenName" runat="server"></asp:Label></div>
                                                    <div class="col-6">Center Details</div>
                                                    <div class="col-6"><asp:Label ID="lblDetails" runat="server"></asp:Label></div>
                                                     <div class="col-6"><asp:Label ID="lblQualification" runat="server"></asp:Label></div>
                                                    <div class="col-6"><asp:Image ID="imgqual" runat="server" CssClass="img-fluid" /></div>
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
                    <div style="overflow:scroll;height:1200px;" id="div_print">
                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table table-responsive" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" 
                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%" OnRowDataBound="gvCenter_RowDataBound" OnRowDeleting="gvCenter_RowDeleting">
                         <AlternatingRowStyle/>
                       
                        <Columns>
                           
                            <asp:TemplateField HeaderText="Center ID">
                                <ItemTemplate>
                                     <asp:LinkButton ID="lnkbtnCenterLogin" runat="server" ForeColor="Black" OnClick="lnkbtnCenterLogin_Click"><%# Eval("CenterID") %></asp:LinkButton><br />
                                     <asp:HiddenField ID="HFISActive" runat="Server" Value='<%# Eval("IsLogin") %>' />
                             <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("passportpic") %>' runat="server" ><asp:Image ID="imgPic" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("passportpic") %>' style="width:75px;height:100px;" /></asp:HyperLink><br /><br />
                                   <asp:Button ID="hlDeActivate" runat="server" Text="Deactive" CssClass="btn btn-danger" OnClick="hlDeActivate_Click" /><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Center Head Details" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                          <ItemTemplate>
                                              
                                              Name:-<%# Eval("PersonName") %><br />
                                              Email:-<%# Eval("Email") %><br />
                                              Password:-<%# Eval("Password") %><br />
                                              Phone Number:- <%# Eval("PhoneNumber") %><br />
                                              Signature:<br />
                                                <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("Signature") %>' runat="server" ><asp:Image ID="imgSignature" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("Signature") %>' style="width:75px;height:100px;" /></asp:HyperLink><br />
                                               Id-Proof:- <br /><asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("AadharCard") %>' runat="server" ><asp:Image ID="imgID" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("AadharCard") %>' style="width:65px;height:100px;" /></asp:HyperLink><br />
                                   Qualification certificate: <br />
                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("Marksheet") %>' runat="server" ><asp:Image ID="imgMarksheet" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("Marksheet") %>' style="width:75px;height:100px;" /></asp:HyperLink>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                           <asp:TemplateField HeaderText="Center Details">
                               <ItemTemplate>
                                   Center Name:-<%# Eval("InstituteName") %><br />
                                   Address:-<%# Eval("Address") %><br />
                                   Pin Code:-<%# Eval("PinCode") %><br />
                                   Total PCs:- <%# Eval("TotalPC") %><br />
                                   Total Staff:-<%# Eval("Staffs") %><br />
                                   Practical Lab:  <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("LabPicture") %>' runat="server" ><asp:Image ID="imgLab" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("LabPicture") %>' style="width:75px;height:100px;" /></asp:HyperLink><br />
                                                   Theory Room <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("TheoryRoomPic") %>' runat="server" ><asp:Image ID="imgTheory" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("TheoryRoomPic") %>' style="width:75px;height:100px;" /></asp:HyperLink><br />
                                                    Office Room <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("OfficePic") %>' runat="server" ><asp:Image ID="imgOfficePic" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("OfficePic") %>' style="width:75px;height:100px;" /></asp:HyperLink>
                                  
                               </ItemTemplate>
                           </asp:TemplateField>
                       
                            <asp:BoundField DataField="IsActiveBackDate" HeaderText="Permission?" />
                            <asp:TemplateField HeaderText="Add Old Student" ItemStyle-HorizontalAlign="Center">
                               <ItemTemplate>

                                  <asp:CheckBox id="chkAdd" runat="server" AutoPostBack="true" OnCheckedChanged="chkAdd_CheckedChanged"/>
                               </ItemTemplate>
                           </asp:TemplateField> 
                             <asp:BoundField DataField="IsShowPerformer" HeaderText="Show Center?" />
                            <asp:TemplateField HeaderText="Show Performer Centers" ItemStyle-HorizontalAlign="Center">
                               <ItemTemplate>
                                  <asp:CheckBox id="chkShow" runat="server" AutoPostBack="true" OnCheckedChanged="chkShow_CheckedChanged"/>
                               </ItemTemplate>
                           </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                               <ItemTemplate>
                                   <asp:Button ID="btnCertificate" runat="server" Text="Generate Certificate" CssClass="btn btn-block btn-outline-warning bg-dark" style="border: solid 1px blue;" OnClick="lbCertificate_Click" />
                                   <asp:HyperLink ID="hlCenterForm" runat="server" Text="Generate CenterForm" NavigateUrl='<%#"CenterForm.aspx?ID="+Eval("ID") %>' CssClass="btn btn-block btn-outline-warning bg-gradient-fuchsia" style="border: solid 1px blue;" ></asp:HyperLink>
                               
                                    <asp:Button ID="hlView" runat="server" CssClass="btn btn-block btn-warning" Text="View" OnClick="hlView_Click" />
                                
                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-block btn-success" NavigateUrl='<%# "CenterEdit.aspx?ID="+Eval("id") %>'> Edit </asp:HyperLink>
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
             <script type="text/javascript">
                function openMod() {
                    $('#ModalView').modal('show');                    
                }

            </script>
         
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport"  />
            <asp:PostBackTrigger ControlID="btnpdf" />
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
      
</asp:Content>

