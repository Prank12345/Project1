<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="TakeTests.aspx.cs" Inherits="Student_Image_TakeTests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Test by Centers</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
        <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <asp:Repeater ID="rptTestList" runat="server">
                <ItemTemplate>
                    <div class="col-3 p-5 ml-3" style="border:solid black; border-radius: 5px;">
                        <asp:HyperLink ID="hlQuestion" runat="server" NavigateUrl='<%#"TestPaper.aspx?TID="+Eval("id") %>'>
                            <i class="ion ion-android-clipboard" style="font-size: 40px;"></i>&nbsp; 
                            <asp:Label ID="lblShowTestName" runat="server" Font-Size="25px" ForeColor="Black"><%#Eval("ExamName") %></asp:Label>
                        </asp:HyperLink>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div>
          </div>
            </section>
           </div>
</asp:Content>

