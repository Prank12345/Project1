<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Center_Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function confirmDel() {
            return confirm("Are you sure to DELETE this?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
    <div class="content-wrapper">
        <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-12">
            <h1 class="m-0">Add Main Exam</h1>
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
            <section class="content ml-xl-5 pl-xl-5">
                <div class="container-fluid"> 
        <div class="row">
                            <div class="col-12">
                              
                                  <div id="ModalView" class="modal fade" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <h4 class="modal-title">View</h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body">
                                                <div class="row">
                                                   <asp:HiddenField ID="hfVID" runat="server" />
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
                    <div class="col-12 mt-3">
                       
                                <div class="row pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="Label1" runat="server" Text="Select Course"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:DropDownList ID="ddlCourseMain" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseMain_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    
                                </div>
                               
                                <div class="row mt-2 pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="Label2" runat="server" Text="Select Semester"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:DropDownList ID="ddlSemester" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                   
                                </div>
                                <div class="row mt-2 pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="Label3" runat="server" Text="Select Subject"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:DropDownList ID="ddlSubject" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                   
                                </div>
                        <div class="row mt-2 pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="Label4" runat="server" Text="Exam Type"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" CellPadding="10">
                                            <asp:ListItem Text="Subjective" Value="Subjective" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Objective" Value="Objective"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                   
                                </div>
                                <div class="row mt-3 pb-3">
                                    <div class="col-4"></div>
                                    <div class="col-4">
                                        <asp:Button ID="btnAddExam" CssClass="form-control btn btn-primary" runat="server" Text="Add Exam" OnClick="btnAddExam_Click"  />                                        
                                    </div>

                                    <div class="col-4"></div>
                                </div>
                          <div class="row mt-5">
                                    <div class="col-12">
                                        <div style="width: 99%; overflow: scroll;">
                                            <asp:GridView ID="gvExam" Width="100%" DataKeyNames="id" CssClass="Grid" AutoGenerateColumns="false" HeaderStyle-Wrap="false" 
                                                OnRowDeleting="gvExam_RowDeleting" runat="server" CellPadding="10" ForeColor="#333333" GridLines="None" OnRowDataBound="gvExam_RowDataBound">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                            <asp:HiddenField ID="HFISActive" runat="server" Value='<%#Eval("ExamType") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Semester Name" DataField="SubjectName" />
                                                    <asp:BoundField HeaderText="Subject Name" DataField="SemesterName" />
                                                    <asp:BoundField HeaderText="Created on" DataField="CreatedOn" />
                                                   <%-- <asp:TemplateField HeaderText="View Question">
                                                        <ItemTemplate>
                                                           <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-info" OnClick="btnView_Click" CommandArgument='<%#Eval("ID") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Add Question">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hlAddSub" runat="server" Text="Add" CssClass="btn btn-success" NavigateUrl='<%#"AddSubjQuesMain.aspx?ID=" + Eval("ID") %>'></asp:HyperLink>
                                                            <asp:HyperLink ID="hlAddObj" runat="server" Text="Add" CssClass="btn btn-success" NavigateUrl='<%#"MainExQuesAdd.aspx?ID=" + Eval("ID") %>'></asp:HyperLink>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbdelete" runat="server" Text="Delete" CommandName="delete" OnClientClick="return confirmDel();"></asp:LinkButton>
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
                </div>  
   
           
            <script type="text/javascript">
                 function OpenView() {
                    
                     $('#ModalView').modal('show');
                  
                }

            </script>
            </div>
            </section>
                </div>
            
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

