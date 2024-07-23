<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="AddFreeTest.aspx.cs" Inherits="SuperAdminBackend_AddFreeTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function confirmDel() {
            return confirm("Are you sure to DELETE this?");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <p style="font-size: 30px; margin-left: 9px;" class="mt-3">Add new Test/Exam</p>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                
                                <div class="row">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:Label ID="lblexmname" runat="server" Text="Enter Name"></asp:Label>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:TextBox ID="txtexmname" placeholder="Enter Test/Exam Name" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:Label ID="lbltype" runat="server" Text="Select Type"></asp:Label>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="row mt-2">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:DropDownList ID="ddlexamtype" CssClass="form-control" runat="server">
                                            <asp:ListItem Text="Select Here" Selected="True" Value="0" disabled="disabled"></asp:ListItem>
                                            <asp:ListItem Text="Free Test" Value="Test"></asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <asp:Button ID="tbnadd" CssClass="form-control btn btn-primary" runat="server" Text="Add Free Test" OnClick="tbnadd_Click"/>
                                    </div>
                                    <div class="col-3"></div>
                                </div>

                                <div class="row mt-5">
                                    <div class="col-12">
                                         <div style="width:99%; overflow:scroll;">
                                        <asp:GridView ID="gvtestexam" Width="100%" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" 
                        AlternatingRowStyle-CssClass="table-secondary" runat="server" CellPadding="10" ForeColor="#333333" GridLines="None" 
                                            OnRowDeleting="gvtestexam_RowDeleting">
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
                                                <asp:BoundField HeaderText="Created on" DataField="CreatedOn"/>
                                               <%-- <asp:TemplateField HeaderText="View Question">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbview" Text="view" runat="server" CssClass="btn btn-info" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Add Question">
                                                    <ItemTemplate>
                                                         <asp:HyperLink ID="hladd" CssClass="btn btn-success" runat="server" NavigateUrl='<%# "AddQuestions.aspx?ID=" + Eval("id")%>'><i class="fas fa-plus"></i></asp:HyperLink>
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
</asp:Content>

