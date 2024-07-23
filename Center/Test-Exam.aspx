<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="Test-Exam.aspx.cs" Inherits="Center_Test_Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>

    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-primary card-outline">
                    <div class="card-header">
                        <h3 class="card-title">Add Test</h3>
                    </div>
                    <div class="card-body" >
                        
                                <div class="row">
                    <div class="col-12 mt-3">
                       
                                <div class="row pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="lblcourse" runat="server" Text="Select Course"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:DropDownList ID="ddlcourse" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    
                                </div>
                               
                                <div class="row mt-2 pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="lblexmname" runat="server" Text="Enter Test Name"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:TextBox ID="txtexmname" placeholder="Enter Test Name" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>
                               
                                <div class="row mt-3 pb-3">
                                    <div class="col-4"></div>
                                    <div class="col-4">
                                        <asp:Button ID="tbnadd" CssClass="form-control btn btn-primary" runat="server" Text="Add Test" OnClick="tbnadd_Click" />
                                    </div>
                                    <div class="col-4"></div>
                                </div>
                          <div class="row mt-5">
                                    <div class="col-12">
                                        <div style="width: 99%; overflow: scroll;">
                                            <asp:GridView ID="gvtestexam" Width="100%" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" CellPadding="3" GridLines="None"
                        AlternatingRowStyle-CssClass="table-secondary" OnRowDeleting="gvtestexam_RowDeleting" runat="server">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Exam Name" DataField="ExamName" />
                                                    <asp:BoundField HeaderText="Exam/Test Type" DataField="ExamType" />
                                                    <asp:BoundField HeaderText="Created on" DataField="CreatedOn" />
                                                    <asp:TemplateField HeaderText="View Question">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="lbview" Text="view" runat="server" CssClass="btn btn-info" NavigateUrl='<%#"ViewQuestion.aspx?ID=" +Eval("id") %>'></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Add Question">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hladd" runat="server" CssClass="btn btn-success" NavigateUrl='<%# "AddQuestions.aspx?ID=" + Eval("id")%>'><i class="fas fa-plus-circle"></i></asp:HyperLink>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbdelete" runat="server" CssClass="btn btn-danger" CommandName="delete" OnClientClick="return confirmDel();"><i class="fas fa-trash"></i></asp:LinkButton>
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
                    </div>
                </div>
            </div>
            
        </section>
    </div>
    
        </ContentTemplate>
        
    </asp:UpdatePanel>
</asp:Content>

