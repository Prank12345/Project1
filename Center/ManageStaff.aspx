<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageStaff.aspx.cs" Inherits="Center_ManageStaff" %>

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
                                <asp:BoundField DataField="MyProfile" HeaderText="My Profile?"/>
                               <asp:TemplateField HeaderText="My Profile">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkProfile" runat="server" AutoPostBack="true" OnCheckedChanged="chkProfile_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StaffManagement" HeaderText="Staff Management?"/>
                                <asp:TemplateField HeaderText="Staff Management">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStaff" runat="server" AutoPostBack="true" OnCheckedChanged="chkStaff_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Student" HeaderText="Student Management?"/>
                                <asp:TemplateField HeaderText="Student Management">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStudMgmt" runat="server" AutoPostBack="true" OnCheckedChanged="chkStudMgmt_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="courses" HeaderText="Courses?"/>
                                <asp:TemplateField HeaderText="Courses">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCourses" runat="server" AutoPostBack="true" OnCheckedChanged="chkCourses_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Test" HeaderText="Test?"/>
                                <asp:TemplateField HeaderText="Test">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkTest" runat="server" AutoPostBack="true" OnCheckedChanged="chkTest_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StudentCertificateReq" HeaderText="Student Certificate Request?"/>
                                <asp:TemplateField HeaderText="Student Certificate Request">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStuCerReq" runat="server" AutoPostBack="true" OnCheckedChanged="chkStuCerReq_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SetMainExam" HeaderText="Set Main Exam?"/>
                                <asp:TemplateField HeaderText="Set Main Exam">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSetExam" runat="server" AutoPostBack="true" OnCheckedChanged="chkSetExam_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  
                                 <asp:BoundField DataField="eWallet" HeaderText="E- Wallet?"/>
                                <asp:TemplateField HeaderText="E- Wallet">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkWallet" runat="server" AutoPostBack="true" OnCheckedChanged="chkWallet_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="SendStudPass" HeaderText="Send Student Password?"/>
                                <asp:TemplateField HeaderText="Send Student Password">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSendPass" runat="server" AutoPostBack="true" OnCheckedChanged="chkSendPass_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="MyQueries" HeaderText="My Queries?"/>
                                <asp:TemplateField HeaderText="My Queries">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkMyQry" runat="server" AutoPostBack="true" OnCheckedChanged="chkMyQry_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Notifications" HeaderText="Notifications?"/>
                                <asp:TemplateField HeaderText="Notifications">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkNotif" runat="server" AutoPostBack="true" OnCheckedChanged="chkNotif_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InternalMarks" HeaderText="Internal Marks?"/>
                                <asp:TemplateField HeaderText="Internal Marks">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkInternalMarks" runat="server" AutoPostBack="true" OnCheckedChanged="chkInternalMarks_CheckedChanged" />
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
