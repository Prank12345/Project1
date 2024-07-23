<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewDistCenter.aspx.cs" Inherits="SuperAdminBackend_ViewDistCenter" %>

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
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Centers Introduced By <asp:Label runat="server" ID="lblName" ForeColor="Red"></asp:Label></h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
      
          <div class="row">
                            <div class="col-12">
                                <!-- The Modal -->
                                <div class="modal" id="ModalView">
                                    <div class="modal-dialog" style="max-width:60%!important;">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Center's Student Details</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <asp:HiddenField ID="hfID" runat="server" />
                                                   <div class="col-12">
                                                        <asp:GridView ID="gvstudent" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table table-responsive" 
                                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="bg-dark" RowStyle-CssClass="bg-info" 
                                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="1">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderText="Student ID">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnCenterLogin" runat="server" CssClass="bg-cyan" OnClick="lnkbtnCenterLogin_Click"><%# Eval("StudentID") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                            
                                           
                                            <asp:TemplateField HeaderText="Student Details">
                                                <ItemTemplate>
                                                    Name: <%# Eval("StudentName") %><br />
                                                    Father's Name:<%# Eval("FatherHusbandName") %><br />
                                                    Gender: <%# Eval("Gender") %><br />
                                                    Date of Birth: <%# Eval("DateOfBirth") %><br />
                                                    Phone Number: <%# Eval("StudentPhone") %><br />
                                                    Email:<%# Eval("StudentEmail") %><br />
                                                    Password: <%# Eval("Password") %><br />
                                                    Address: <%# Eval("Address") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Image">
                                                <ItemTemplate>
                                                    Student Pic -<asp:HyperLink target="_blank" NavigateUrl='<%# "~/Student-Image/" + Eval("StudentImage") %>' runat="server" ><asp:Image ID="imgStuImg" runat="server" ImageUrl='<%# "~/Student-Image/" + Eval("StudentImage") %>' style="width:100px;height:100px;" /></asp:HyperLink><br />
                                                 Id-Proof-<br /><asp:HyperLink target="_blank" NavigateUrl='<%# "~/ID-Image/" + Eval("IDImage") %>' runat="server" ><asp:Image ID="imgID" runat="server" ImageUrl='<%# "~/ID-Image/" + Eval("IDImage") %>' style="width:100px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                          
                                              <asp:TemplateField HeaderText="Payment Scrrenshot">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Payment-Screenshot/" + Eval("PaymentScreenshot") %>' runat="server" ><asp:Image ID="imgPay" runat="server" ImageUrl='<%# "~/Payment-Screenshot/" + Eval("PaymentScreenshot") %>' style="width:80px;height:100px;" /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             
                                              <asp:TemplateField HeaderText="Marksheet Image">
                                                <ItemTemplate>
                                                    <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Marksheet/" + Eval("Marksheet") %>' runat="server" ><asp:Image ID="imgMarksheet" runat="server" ImageUrl='<%# "~/Marksheet/" + Eval("Marksheet") %>' style="width:80px;height:100px;" /></asp:HyperLink>
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
                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table rounded-corners" RowStyle-CssClass="bg-info"
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" AlternatingRowStyle-CssClass="table-secondary" 
                        HeaderStyle-HorizontalAlign="Center" Width="100%">
                         <AlternatingRowStyle/>
                       
                        <Columns>
                         
                            <asp:TemplateField HeaderText="Center Links">
                                <ItemTemplate>
                                     
                             <asp:HyperLink target="_blank" NavigateUrl='<%# "~/Center-Document/" + Eval("passportpic") %>' runat="server" ><asp:Image ID="imgPic" runat="server" ImageUrl='<%# "~/Center-Document/" + Eval("passportpic") %>' style="width:75px;height:100px;" /></asp:HyperLink><br /><br />
                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Center Head Details" HeaderStyle-Width="50px" ControlStyle-Width="50px">
                                          <ItemTemplate>
                                              
                                              Name:-<%# Eval("PersonName") %><br />
                                              Email:-<%# Eval("Email") %><br />
                                              Phone Number:- <%# Eval("PhoneNumber") %>
                                               </ItemTemplate>
                                      </asp:TemplateField>
                           <asp:TemplateField HeaderText="Center Details">
                               <ItemTemplate>
                                   Center Name:-<%# Eval("InstituteName") %><br />
                                   Address:-<%# Eval("Address") %><br />
                                   Pin Code:-<%# Eval("PinCode") %>
                                  
                               </ItemTemplate>
                           </asp:TemplateField>
                       
                            
                           <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                               <ItemTemplate>
                                   
                                    <asp:Button ID="hlView" runat="server" CssClass="btn btn-block btn-warning" Text="View" OnClick="hlView_Click" />
                                
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
    </asp:UpdatePanel>
</asp:Content>

