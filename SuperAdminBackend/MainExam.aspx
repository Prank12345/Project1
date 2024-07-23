<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="MainExam.aspx.cs" Inherits="SuperAdminBackend_MainExam" %>

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
                                                <div class="row mb-2 mt-2">
                    
                        <asp:Repeater ID="rptQuestion" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12">
                                            <h5>Question: <asp:Label ID="lblQues" runat="server"><%#Eval("Question")%></asp:Label></h5>
                                    
                                   <hr />
                                            </div>
                                        
                                        <div class="col-lg-6 col-md-6">
                                            <p>A <asp:Label ID="lblAns1" runat="server"><%#Eval("Option1") %></asp:Label></p>
                                   
                                            </div>
                                        <div class="col-lg-6 col-md-6">
                                             <p>B <asp:Label ID="lblAns2" runat="server"><%#Eval("Option2") %></asp:Label></p>
                                   
                                            </div>
                                        <div class="col-lg-6 col-md-6">
                                             <p>C <asp:Label ID="lblAns3" runat="server"><%#Eval("Option3") %></asp:Label></p>
                                  
                                            </div>
                                        <div class="col-lg-6 col-md-6">
                                              <p>D <asp:Label ID="lblAns4" runat="server"><%#Eval("Option4") %></asp:Label></p>
                                            </div>
                                       
                                          <div class="col-lg-12 col-md-12 mb-5">
                                              <hr />
                                               <h5><asp:Label ID="Label1" runat="server">Correct Answer:  <%# Eval("CorrectAnswer") %></asp:Label></h5>
                                            </div>
                                    </div>
                                    <br />
                                    </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
                                        <asp:Label ID="Label4" runat="server" Text="Select Subject Type"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:DropDownList ID="ddlSubjectType" CssClass="form-control" runat="server">
                                            <asp:ListItem Selected="True" disabled="disabled" Text="--Select--" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Theory" Value="Theory"></asp:ListItem>
                                            <asp:ListItem  Text="Practical" Value="Practical"></asp:ListItem>
                                        </asp:DropDownList>
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
                                        <div style="height:700px; overflow: scroll;">
                                            <asp:GridView ID="gvExam" Width="100%" DataKeyNames="id" CssClass="table rounded-corners" style= "border:1px solid black;border-radius:25px;"
                                                 HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" runat="server"
                                                AutoGenerateColumns="false" OnRowDeleting="gvExam_RowDeleting" CellPadding="10" GridLines="None" OnRowDataBound="gvExam_RowDataBound">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                            <asp:HiddenField ID="HFISActive" runat="server" Value='<%#Eval("ExamType") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Semester Name" DataField="SemesterName" />
                                                    <asp:BoundField HeaderText="Subject Name" DataField="SubjectName" />
                                                    <asp:BoundField HeaderText="Exam Type" DataField="ExamType" />
                                                    <asp:BoundField HeaderText="Created on" DataField="CreatedOn" />
                                                      <asp:TemplateField HeaderText="Change Exam type">
                                                        <ItemTemplate>
                                                          <asp:DropDownList ID="ddlExType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExType_SelectedIndexChanged">
                                                              <%--<asp:ListItem Text="--Select--" Value="0"></asp:ListItem>--%>
                                                             <asp:ListItem Text="Theory" Value="Theory"></asp:ListItem>
                                                             <asp:ListItem  Text="Practical" Value="Practical"></asp:ListItem>
                                                          </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View Question">
                                                        <ItemTemplate>
                                                           <asp:Button ID="btnViewObj" runat="server" Text="View" CssClass="btn btn-primary" OnClick="btnView_Click" CommandArgument='<%#Eval("ID") %>'/>
                                                           <%-- <asp:Button ID="btnViewSbj" runat="server" Text="View" CssClass="btn btn-info" OnClick="btnViewSbj_Click" CommandArgument='<%#Eval("ID") %>'/>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Add Question" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                           <%-- <asp:HyperLink ID="hlAddSub" runat="server" CssClass="btn btn-success" NavigateUrl='<%#"AddSubjQuesMain.aspx?ID=" + Eval("ID") %>'><i class="fas fa-plus-circle"></i></asp:HyperLink>--%>
                                                            <asp:HyperLink ID="hlAddObj" runat="server" CssClass="btn btn-success" NavigateUrl='<%#"MainExQuesAdd.aspx?ID=" + Eval("ID") %>'><i class="fas fa-plus-circle"></i></asp:HyperLink>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbdelete" runat="server" CssClass="btn btn-danger" Text="Delete" CommandName="delete" OnClientClick="return confirmDel();"><i class="fas fa-trash-alt"></i></asp:LinkButton>
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
                 <%--   <script type="text/javascript">
                 function OpenViewSbj() {
                    
                     $('#ModalViewSub').modal('show');
                  
                }

            </script>--%>
            </div>
            </section>
                </div>
            
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>