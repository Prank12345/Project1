<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditObQues.aspx.cs" Inherits="Center_EditObQues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                                       <asp:Button ID="btnUpdate" runat="server" CssClass="form-control btn btn-success" Text="Update" OnClick="btnUpdate_Click"/>
                                    </div>
                                    <div class="col-2"></div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

