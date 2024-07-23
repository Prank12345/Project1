<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageStudent.aspx.cs" Inherits="SuperAdminBackend_ManageStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">     
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Student Verification</h1>
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
           <div class="col-12">
                <div id="MyModal" class="modal fade" role="dialog" runat="server">
        <div class="modal-dialog" runat="server">
            <div class="modal-content" runat="server">
                <div class="modal-header" runat="server">
                    <h4>Message</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                     
                 </div>
                 <div class="modal-body" runat="server">Successfully Verified
                  </div>
                  <div class="modal-footer" runat="server">
                      <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                 </div>
              </div>
          </div>
      </div>
          <div id="Reject" class="modal fade" role="dialog" runat="server">
        <div class="modal-dialog" runat="server">
            <div class="modal-content" runat="server">
                <div class="modal-header" runat="server">
                    <h4>Message</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                     
                 </div>
                 <div class="modal-body" runat="server">Request Rejected
                  </div>
                  <div class="modal-footer" runat="server">
                      <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                 </div>
              </div>
          </div>
      </div>    
      
           </div>
             <%--<div class="col-lg-4 col-md-4">
                                   Name
                                  <asp:TextBox ID="txtSearchName" runat="server" CssClass="form-control"></asp:TextBox>
                                  </div>--%>
                             
                           
                <div class="col-lg-12 col-md-12 mt-3">
                    <div style="width:99%; height:370px; overflow:scroll;">
                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table table-responsive" 
                                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="bg-dark" RowStyle-CssClass="bg-info" 
                                        AlternatingRowStyle-CssClass="table-secondary"
                        HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="4"  BorderStyle="Solid" BorderWidth="2px" OnRowDataBound="gvCenter_RowDataBound"
                         OnRowDeleting="gvCenter_RowDeleting">
                         <AlternatingRowStyle BackColor="#F7F7F7" />
                       
                        <Columns>
                           <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Payment Scrrenshot">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Payment-Screenshot/" + Eval("PaymentScreenshot") %>' runat="server" ><asp:Image ID="imgPay" runat="server" ImageUrl='<%# "~/Payment-Screenshot/" + Eval("PaymentScreenshot") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                             </asp:TemplateField>  
                       
                            <asp:TemplateField HeaderText="Verify/Reject">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlVerification" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVerification_SelectedIndexChanged">
                                        <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Accept" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Reject" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                 
                                </ItemTemplate>
                                </asp:TemplateField>
                             <asp:BoundField DataField="CourseFee" HeaderText="Amount"/>
                              <asp:TemplateField HeaderText="Student Pic">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Student-Image/" + Eval("StudentImage") %>' runat="server" ><asp:Image ID="imgStuImg" runat="server" ImageUrl='<%# "~/Student-Image/" + Eval("StudentImage") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>       
                               <asp:TemplateField HeaderText="Student Details">
                                                <ItemTemplate>
                                                    Name: <%# Eval("StudentName") %><br />
                                                    Father's Name:<%# Eval("FatherHusbandName") %><br />
                                                    Gender: <%# Eval("Gender") %><br />
                                                    Date of Birth: <%# Eval("DateOfBirth") %><br />
                                                    Phone Number: <%# Eval("StudentPhone") %><br />
                                                    Email:<%# Eval("StudentEmail") %><br />
                                                    Address: <%# Eval("Address") %><br />
                                                    <%# Eval("IDType") %> :  <%# Eval("IDNumber") %><br />
                                                    Image:
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/ID-Image/" + Eval("IDImage") %>' runat="server" ><asp:Image ID="imgID" runat="server" ImageUrl='<%# "~/ID-Image/" + Eval("IDImage") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                               
                           <%-- <asp:BoundField DataField="Course" HeaderText="Course"/>--%>
                                
                                <asp:BoundField DataField="SessionFrom" HeaderText="Session From"/>
                                <asp:BoundField DataField="SessionTo" HeaderText="Session To"/>
                            <asp:TemplateField HeaderText="Marksheet Image">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Marksheet/" + Eval("Marksheet") %>' runat="server" ><asp:Image ID="imgMarksheet" runat="server" ImageUrl='<%# "~/Marksheet/" + Eval("Marksheet") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Fees Reciept">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnFees" runat="server" Text="View" CssClass="btn-info" />
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
        function openModal() {
            $('#ContentPlaceHolder1_MyModal').modal('show');
           }

        </script> 
    <script type="text/javascript">
        function openPop() {
            $('#ContentPlaceHolder1_Reject').modal('show');
           }
        </script>
         
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

