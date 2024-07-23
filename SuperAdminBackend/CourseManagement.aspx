<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="CourseManagement.aspx.cs" Inherits="SuperAdminBackend_CourseManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-lg-12 col-sm-12 mb-2">
                                <h1 class="m-0">Course Management</h1>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-12 col-sm-12 mb-2" style="text-align:center">
                                <h4 class="m-0">Add Courses</h4>
                            </div>
                           
                        </div>
                          <div class="row mb-2">
                             <div class="col-lg-2 col-sm-12 mb-2">
                                Course Type
                            </div>
                            <div class="col-lg-10 col-sm-12 mb-2">
                                <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="form-control" required></asp:DropDownList>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Course Name
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Short Name of course
                            </div>
                           
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:TextBox ID="txtShortName" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                About Course
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtcoursedetails" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                           <div class="col-lg-2 col-sm-12 mb-2">
                                Exam Attendant
                            </div>
                            
                             <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtAttendant" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Duration of Full Course
                            </div>
                             <div class="col-lg-2 col-sm-12 mb-2">
                                <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                                <asp:DropDownList ID="ddldurationType" runat="server" CssClass="form-control" required>
                                    <asp:ListItem Value="0" Text="--Year/Months" Selected="True" disabled="disabled"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Year"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Months"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                               Eligibility
                            </div>
                           
                           
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:TextBox ID="txtEligibility" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                        </div>

                          <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Registration Fees
                            </div>
                              <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtRegFees" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                               Course Fees
                            </div>
                           
                            
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:TextBox ID="txtProgFees" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                           
                        </div>
                      
                          <div class="row mb-2">
                            <div class="col-lg-2 col-sm-12 mb-2">
                                Instruction Mode
                            </div>
                              <div class="col-lg-4 col-sm-12 mb-2">
                                <asp:TextBox ID="txtInstructionMode" runat="server" CssClass="form-control" ReadOnly="true" Text="Online & Offline"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-12 mb-2">
                               Medium
                            </div>
                           
                            
                            <div class="col-lg-4 col-sm-12 mb-2">
                                 <asp:DropDownList ID="ddlLang" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="--Select--" Value="0" Selected="True" Disabled="Disabled"></asp:ListItem>
                                    <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                    <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                     <asp:ListItem Text="Official Language" Value="OfficialLanguage"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           
                        </div>
                        <div class="row mb-2">
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                            <div class="col-lg-4 col-sm-12 mb-2" style="text-align:center;">
                               <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click"/>
                            </div>
                            <div class="col-lg-4 col-sm-12 mb-2"></div>
                           
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </div>
                <section class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <div class="modal" id="Modalsubject">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">Semesters</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
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

                                            <!-- Modal footer -->
                                            <div class="modal-footer">
                                               
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        
                        <!-- Small boxes (Stat box) -->
                    <div class="row">
                      
                            <div class="col-lg-4 col-sm-8">
                                <span>Full Course Name/Short Name/Code</span><br />
                                 <asp:TextBox ID="txtSearch" placeholder="Search" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            <div class="col-lg-2 col-sm-2">
                                <br />
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" ><i class="fas fa-search"></i></asp:LinkButton>
                            </div>
                         <div class="col-lg-6 col-sm-1">
                           
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="20px"></asp:Label>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-12 col-sm-12 mt-3">
                                <div style="height:1400px; overflow: scroll;">
                                    <asp:GridView ID="gvCenter" CssClass="table table-responsive" style= "-moz-border-radius: 25px;border-radius: 25px;" 
                                        HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" 
                                        runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" 
                                        Width="100%" CellPadding="8" OnRowDeleting="gvCenter_RowDeleting">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                            <asp:TemplateField HeaderText="Course Name">
                                                <ItemTemplate>
                                                    <%# Eval("FullCourseName") %><br />
                                                    (abbr.- <%# Eval("ShortName") %>)
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Course Details">
                                                <ItemTemplate>
                                                    <%# Eval("CourseDetail") %><br />
                                                    (Duration- <%# Eval("Duration") %>
                                                    Eligibility- <%# Eval("Eligibility") %>)
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Fees Details">
                                                <ItemTemplate>
                                                    Registration Fees<%# Eval("RegFeesUniv") %><br />
                                                    Course Fees- <%# Eval("ProgFeesUniv") %>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="Medium" HeaderText="Medium" />
                                            <asp:BoundField DataField="InstructionMode" HeaderText="Instruction Mode" />
                                             <asp:TemplateField HeaderText="View Semester">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" Text='View' CssClass="btn-primary" OnClick="btnView_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Add Semester">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlSemester" runat="server" NavigateUrl='<%#"ManageSemester.aspx?Sem="+Eval("ID") %>'> <i class="fa fa-plus-circle"></i></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%#"EditCourse.aspx?CID="+Eval("ID") %>'> <i class="fa fa-edit"></i></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbRemove" runat="server" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fa fa-trash"></i></asp:LinkButton>
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
             </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function Modalsubject() {
                    $('#Modalsubject').modal('show');
                   
                }

            </script>
</asp:Content>

