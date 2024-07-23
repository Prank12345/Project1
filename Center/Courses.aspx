<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Center_Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-3"></div>
            <div class="col-8 ml-4" style="font-size:30px;">
             Add Course   
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-3"></div>
            <div class="col-8 ml-4">
                <asp:TextBox ID="txtcourse" required placeholder="Enter Course Name" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>
          <div class="row mt-2">
            <div class="col-3"></div>
            <div class="col-8 ml-4">
                <asp:Label ID="lbldetails" runat="server" Text="Brief Details of Course"></asp:Label></div>
        </div>
          <div class="row mt-3">
            <div class="col-3"></div>
            <div class="col-8 ml-4">
                <asp:TextBox ID="txtdetails" required CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-3 mr-4"></div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-4">
                <asp:TextBox ID="txtsubject1" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-3 mr-4"></div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject2" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject3" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="row mt-3">
            <div class="col-3 mr-4"></div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject4" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-4">
                <asp:TextBox ID="txtsubject5" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-3 mr-4"></div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject6" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-4">
                <asp:TextBox ID="txtsubject7" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-3 mr-4"></div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject8" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-4">
                <asp:TextBox ID="txtsubject9" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="row mt-3">
            <div class="col-3 mr-4"></div>
            <div class="col-4">
                <asp:TextBox ID="txtsubject10" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-4">
                <asp:TextBox ID="txtsubject11" required placeholder="Enter Subject Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-3"></div>
            <div class="col-8 ml-4">
                <asp:Button ID="btnaddcourse" CssClass="btn btn-primary btn-block" runat="server" Text="Add Course" OnClick="btnaddcourse_Click" />
            </div>
        </div>
    </div>

</asp:Content>

