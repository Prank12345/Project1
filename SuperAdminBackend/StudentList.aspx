<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="StudentList.aspx.cs" Inherits="SuperAdminBackend_StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>

            
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-12">
                                <h1 class="m-0">Verified Student Details</h1>
                            </div>
                            <!-- /.col -->

                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
                <section class="content">
                    <div class="container-fluid">
                        <!-- Small boxes (Stat box) -->
                        <div class="row">


                            <div class="col-7" style="font-size: 14px;">
                                <asp:Button ID="btnExport" runat="server" Text="Export To Excell" OnClick="btnExport_Click"/>
                        <asp:Button ID="btnpdf" runat="server" Text="Save As PDf" OnClick="btnpdf_Click"/>

                                <asp:Button ID="btnprint" runat="server" Text="Print Here" OnClientClick="printdiv('div_print');" />
                            </div>
                            <div class="col-lg-1 col-md-1">Search</div>
                            <div class="col-3">
                                <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Name of student" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-1">
                                <asp:LinkButton runat="server" CssClass="btn btn-primary" style="" Text="" ID="lbSearch" OnClick="lbSearch_Click"><i class="fas fa-search"></i></asp:LinkButton>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-12">
                                <!-- The Modal -->
                                <div class="modal" id="myModal">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Student Details</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-6">Name</div>
                                                    <div class="col-6"><asp:Label ID="lblName" runat="server"></asp:Label></div>
                                                    <div class="col-6">Student ID</div>
                                                    <div class="col-6"><asp:Label ID="lblStuID" runat="server"></asp:Label></div>
                                                </div>
                                                
                                            </div>

                                            <!-- Modal footer -->
                                            <div class="modal-footer">
                                                <asp:Button ID="btnDownload" CssClass="btn btn-info" Text="Generate" runat="server" OnClick="btnDownload_Click"  />
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                   <div class="modal" id="ModalCourse">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Course Details</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-6"><span style="font-weight:bold;">Course Name</span></div>
                                                    <div class="col-6"><asp:Label ID="lblCName" runat="server"></asp:Label></div>
                                                    <div class="col-12">
                                                        <div class="row">
                                                        <asp:Repeater ID="rptSems" runat="server">
                                                        <ItemTemplate>
                                                             <div class="col-12">
                                                        <div class="row">
                                                            <div class="col-4" style="font-weight:bold;">semester Name</div>
                                                    <div class="col-8"><asp:Label ID="lblID" runat="server"><%# Eval("Semester") %></asp:Label></div>
                                                    <div class="col-6" style="font-weight:bold;">Subjects</div>
                                                    <div class="col-12">
                                                       <asp:Label ID="lblShow" runat="server"><%# Eval("Subjects") %></asp:Label>
                                                         <hr style="border:solid black 1px;" />
                                                    </div>
                                                           
                                                        </div>
                                                                 </div>
                                                            
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                            </div>
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
                                                    <div class="col-6">Center Name</div>
                                                    <div class="col-6"><asp:Label ID="lblCenterName" runat="server"></asp:Label></div>
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
                            </div>
                        </div>
                        <div class="row">
                             
         
                             <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-info btn-block" style="text-align: center;"><asp:LinkButton ID="lbAll" runat="server" Text="All Student" ForeColor="White" OnClick="lbAll_Click"></asp:LinkButton></span>
                            </div> 
            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-warning btn-block" style="text-align: center;"><asp:LinkButton ID="lbVerify" runat="server" ForeColor="White" Text="Student Verification Required" OnClick="lbVerify_Click"></asp:LinkButton> (<asp:Label ID="lblVerification" runat="server"></asp:Label>)</span>
                            </div> 
            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-success btn-block" style="text-align: center;"><asp:LinkButton ID="lbVerified" runat="server" ForeColor="White" Text="Verified Student" OnClick="lbVerified_Click"></asp:LinkButton> (<asp:Label ID="lblVerified" runat="server"></asp:Label>)</span>
                            </div> 
            <div class="col-lg-3 col-md-3 mt-3">
                                <span class="badge-btn badge-danger btn-block" style="text-align: center;"><asp:LinkButton ID="lbRejected" runat="server" ForeColor="White" Text="Rejected Student" OnClick="lbRejected_Click"></asp:LinkButton> (<asp:Label ID="lblRejected" runat="server"></asp:Label>)</span>
                            </div> 
                            <div class="col-lg-12 col-md-12 mt-3">
                                <div style="overflow: scroll; height:500px;" id="div_print">
                                    <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" CssClass="table table-responsive" 
                                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="bg-dark" RowStyle-CssClass="bg-info" 
                                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="1" OnRowDeleting="gvCenter_RowDeleting">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Enrollment Number">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnCenterLogin" runat="server" CssClass="bg-cyan" OnClick="lnkbtnCenterLogin_Click"><%# Eval("StudentID") %></asp:LinkButton>
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
                                                    Password: <%# Eval("Password") %><br />
                                                    Address: <%# Eval("Address") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Image">
                                                <ItemTemplate>
                                                    Student Pic -<asp:HyperLink target="_blank" NavigateUrl='<%# "~/Student-Image/" + Eval("StudentImage") %>' runat="server" ><asp:Image ID="imgStuImg" runat="server" ImageUrl='<%# "~/Student-Image/" + Eval("StudentImage") %>' style="width:100px;height:100px;" /></asp:HyperLink><br />
                                                 Id-Proof-<asp:HyperLink target="_blank" NavigateUrl='<%# "~/ID-Image/" + Eval("IDImage") %>' runat="server" ><asp:Image ID="imgID" runat="server" ImageUrl='<%# "~/ID-Image/" + Eval("IDImage") %>' style="width:100px;height:100px;" /></asp:HyperLink>
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
                                            <asp:TemplateField HeaderText="View Details">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnCourse" runat="server" Text="Courses" OnClick="btnCourse_Click" CssClass="btn-block btn-success mb-1" />
                                                    <asp:Button ID="btnCenterID" runat="server" Text="Center-ID" OnClick="btnCenterID_Click" CssClass="btn-block btn-success mb-1" />
                                                    
                                                    <asp:Button ID="btnStudentID" runat="server" Text="ID-Card" CssClass="btn-block btn-success" OnClick="btnStudentID_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                           
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-warning" NavigateUrl='<%#"EditStudent.aspx?SID="+ Eval("ID") %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                                    <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-danger mt-2" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fa fa-trash"></i> </asp:LinkButton>
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
                    </div>
                </section>

            </div>
            <script type="text/javascript">
                function openMod() {
                    $('#myModal').modal('show');
                    //alert("sdfsdfsd");
                }

            </script>
            <script type="text/javascript">
                function openCourse() {
                    $('#ModalCourse').modal('show');
                  
                }

            </script>
            <script type="text/javascript">
                function openCenter() {
                    $('#ModalCenter').modal('show');
                  
                }

            </script>
        </ContentTemplate>
       <Triggers>
             <asp:PostBackTrigger ControlID="btnExport" />
             <asp:PostBackTrigger ControlID="btnpdf" />
         </Triggers>
    </asp:UpdatePanel>
</asp:Content>

