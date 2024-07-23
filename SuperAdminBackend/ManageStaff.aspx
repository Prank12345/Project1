<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageStaff.aspx.cs" Inherits="SuperAdminBackend_ManageStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
    <style>
        .rounded-corners {
  /*border: 1px solid black;*/
  -webkit-border-radius: 8px;
  -moz-border-radius: 8px;
  border-radius: 8px;
  overflow: hidden;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
              <div class="row mb-2">
            <div class="col-10"></div>
                  
            <div class="col-2 mt-2">
                <a href="AddStaff.aspx" class="btn btn-info btn-block">Add Staff +</a>
            </div>
        </div>
               
                <div class="row mt-2">
                    
                    <div class="col-12">
                        <div style="width:99%; overflow:scroll; height:500px;">
                        <asp:GridView ID="gvStaff" DataKeyNames="id" AutoGenerateColumns="false" OnRowDeleting="gvStaff_RowDeleting" runat="server" CellPadding="4" GridLines="None" 
                            OnRowDataBound="gvStaff_RowDataBound" CssClass="table" style= "-moz-border-radius: 25px;border-radius: 25px;" 
                            HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                                
                                <asp:BoundField DataField="FullName" HeaderText="Name"/>
                                <asp:TemplateField HeaderText="Staff Details">
                                    <ItemTemplate>
                                        <b>Address</b>: <%# Eval("Address") %><br />
                                        <b>Phone Number</b>: <%# Eval("PhoneNumber") %><br />
                                        <b>Email ID</b>: <%# Eval("EmailID") %><br />
                                        <b>Qualification</b>: <%# Eval("Qualification") %><br />
                                        <b>Date Of Birth</b>: <%# Eval("DOB") %><br />
                                        <b>Gender</b>: <%# Eval("Gender") %><br />
                                        <b>Marital Status</b>: <%# Eval("MaritalStatus") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="UserName" HeaderText="Username"/>
                               <asp:BoundField DataField="Password" HeaderText="Password"/>
                                <asp:BoundField DataField="ManagePopupBanner" HeaderText="Manage Popup Banner?"/>
                               <asp:TemplateField HeaderText="Manage Popup Banner">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBanner" runat="server" AutoPostBack="true" OnCheckedChanged="chkBanner_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StaffManagement" HeaderText="Staff Management?"/>
                                <asp:TemplateField HeaderText="Staff Management">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStaff" runat="server" AutoPostBack="true" OnCheckedChanged="chkStaff_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MainSliderImage" HeaderText="Main Slider Image ?"/>
                                <asp:TemplateField HeaderText="Main Slider Image">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkMainSlider" runat="server" AutoPostBack="true" OnCheckedChanged="chkMainSlider_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SlidingStatement" HeaderText="Sliding Statement?"/>
                                <asp:TemplateField HeaderText="Sliding Statement">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSlidStatement" runat="server" AutoPostBack="true" OnCheckedChanged="chkSlidStatement_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Gallery" HeaderText="Gallery?"/>
                                <asp:TemplateField HeaderText="Gallery">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGallery" runat="server" AutoPostBack="true" OnCheckedChanged="chkGallery_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Download" HeaderText="Download?"/>
                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDownload" runat="server" AutoPostBack="true" OnCheckedChanged="chkDownload_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AddFreeTest" HeaderText="Add Free Test?"/>
                                <asp:TemplateField HeaderText="Add Free Test">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAddFreeTest" runat="server" AutoPostBack="true" OnCheckedChanged="chkAddFreeTest_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  
                                 <asp:BoundField DataField="CenterVerification" HeaderText="Center Verification?"/>
                                <asp:TemplateField HeaderText="Center Verification">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCenterVerify" runat="server" AutoPostBack="true" OnCheckedChanged="chkCenterVerify_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="DistributorVerification" HeaderText="Distributor Verification?"/>
                                <asp:TemplateField HeaderText="Distributor Verification">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDistributorVerification" runat="server" AutoPostBack="true" OnCheckedChanged="chkDistributorVerification_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="VerifyStudent" HeaderText="Verify Student?"/>
                                <asp:TemplateField HeaderText="Verify Student">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkVerifyStudent" runat="server" AutoPostBack="true" OnCheckedChanged="chkVerifyStudent_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="PendingStudent" HeaderText="Pending Student?"/>
                                <asp:TemplateField HeaderText="Pending Student">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPendingStudent" runat="server" AutoPostBack="true" OnCheckedChanged="chkPendingStudent_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CourseType" HeaderText="Course Type?"/>
                                <asp:TemplateField HeaderText="Course Type">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCourseType" runat="server" AutoPostBack="true" OnCheckedChanged="chkCourseType_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="NewCourse" HeaderText="New Course?"/>
                                <asp:TemplateField HeaderText="New Course">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkNewCourse" runat="server" AutoPostBack="true" OnCheckedChanged="chkNewCourse_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="eWallet" HeaderText="E-Wallet?"/>
                                <asp:TemplateField HeaderText="E-Wallet">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkeWallet" runat="server" AutoPostBack="true" OnCheckedChanged="chkeWallet_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StudentCertification" HeaderText="Student Certification ?"/>
                                <asp:TemplateField HeaderText="Student Certification">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStudentCertification" runat="server" AutoPostBack="true" OnCheckedChanged="chkStudentCertification_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CenterList" HeaderText="Center List?"/>
                                <asp:TemplateField HeaderText="Center List">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCenterList" runat="server" AutoPostBack="true" OnCheckedChanged="chkCenterList_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DistributorList" HeaderText="Distributor List?"/>
                                <asp:TemplateField HeaderText="DistributorList">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDistributorList" runat="server" AutoPostBack="true" OnCheckedChanged="chkDistributorList_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StudentList" HeaderText="Student List?"/>
                                <asp:TemplateField HeaderText="Student List">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStudentList" runat="server" AutoPostBack="true" OnCheckedChanged="chkStudentList_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Exams" HeaderText="Exams?"/>
                                <asp:TemplateField HeaderText="Exams">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkExams" runat="server" AutoPostBack="true" OnCheckedChanged="chkExams_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                                
                                 <asp:BoundField DataField="CenterRenewal" HeaderText="Center Renewal?"/>
                                <asp:TemplateField HeaderText="Center Renewal">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCenterRenew" runat="server" AutoPostBack="true" OnCheckedChanged="chkCenterRenew_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="ViewCenterQuerries" HeaderText="View Center Querries?"/>
                                <asp:TemplateField HeaderText="View Center Querries">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkViewCenterQuerries" runat="server" AutoPostBack="true" OnCheckedChanged="chkViewCenterQuerries_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                 <asp:BoundField DataField="SendNotification" HeaderText="Send Notification?"/>
                                <asp:TemplateField HeaderText="Send Notification">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSendNotification" runat="server" AutoPostBack="true" OnCheckedChanged="chkSendNotification_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="ChangePassword" HeaderText="Change Admin Password?"/>
                                <asp:TemplateField HeaderText="Change Admin Password">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChangePassword" runat="server" AutoPostBack="true" OnCheckedChanged="chkChangePassword_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               

                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hledit" CssClass="btn btn-success" runat="server" NavigateUrl='<%# "EditStaff.aspx?SID=" + Eval("id")%>'> <i class="fas fa-edit"></i></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbRemove" CssClass="btn btn-danger" runat="server" CommandName="Delete" OnClientClick="return confirmDel();"><i class="fa fa-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                            </div>
                    </div>
                </div>

            </div>
        </section>
    </div>
</asp:Content>

