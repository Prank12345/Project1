<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="MainExQuesAdd.aspx.cs" Inherits="Center_MainExQuesAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
       .rbl input[type="radio"]
{
   margin-left: 40px;
   margin-right: 10px;
}
   </style>
      <script type="text/javascript">
        function confirmDel() {
            return confirm("Are you sure to DELETE this?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <p style="font-size:40px;">Add Question</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <p>Question</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <asp:TextBox ID="txtquestion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row mt-4">
                                    <div class="col-6">
                                        <asp:TextBox ID="txtop1" placeholder="Enter Option" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="txtop2" placeholder="Enter Option" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                  <div class="row mt-4">
                                    <div class="col-6">
                                        <asp:TextBox ID="txtop3" placeholder="Enter Option" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="txtop4" placeholder="Enter Option" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                              
                                <div class="row mt-3">
                                     <div class="col-2">
                                        <div>Correct Answer:</div>
                                    </div>
                                    <div class="col-10">
                                        <asp:RadioButtonList ID="rbanswer" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                                            <asp:ListItem Text="Option A" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="Option B" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="Option C" Value="C"></asp:ListItem>
                                            <asp:ListItem Text="Option D" Value="D"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-2"></div>
                                    <div class="col-8">
                                       <asp:Button ID="btnadd" runat="server" CssClass="form-control btn btn-primary"  Text="Add Question +" OnClick="btnadd_Click" />
                                    </div>
                                    <div class="col-2"></div>
                                </div>
                                
                                <div class="row mt-5">

                                    <div class="col-12 mt-5">
                                        <div style="width:99%; overflow:scroll;">
                                        <asp:GridView ID="gvaddquestion" runat="server" CssClass="Grid" Width="100%" DataKeyNames="id" CellPadding="8" ForeColor="#333333" 
                                            AutoGenerateColumns="false" HeaderStyle-Wrap="false" GridLines="None" OnRowDeleting="gvaddquestion_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Question" DataField="Question"/>
                                                <asp:BoundField HeaderText="Option1" DataField="Option1" />
                                                <asp:BoundField HeaderText="Option2" DataField="Option2" />
                                                <asp:BoundField HeaderText="Option3" DataField="Option3" />
                                                <asp:BoundField HeaderText="Option4" DataField="Option4" />
                                                <asp:BoundField HeaderText="CorrectAnswer" DataField="CorrectAnswer" />
                                               <asp:TemplateField HeaderText="Edit">
                                                   <ItemTemplate>
                                                      <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%#"EditObQues.aspx?EID=" + Eval("ID") %>' Text="Edit" CssClass="btn btn-warning"></asp:HyperLink>
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
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

