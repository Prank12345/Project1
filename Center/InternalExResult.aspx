<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="InternalExResult.aspx.cs" Inherits="Center_InternalExResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
        <div class="container">
            <div class="row"></div>
              <div class="row mt-5">
                <div class="col-1"></div>
                <div class="col-3">
                    <p>Select Student</p>
                </div>
                <div class="col-6">
                    <asp:DropDownList ID="ddlStudent" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-2"></div>
            </div>
            <%--<div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Select Course</p>
                </div>
                <div class="col-6">
                   <asp:DropDownList ID="ddlCourse" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                   </asp:DropDownList>
                </div>
                 <div class="col-2"></div>
            </div>--%>
            <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Select Semester</p>
                </div>
                <div class="col-6">
                   <asp:DropDownList ID="ddlSemster" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSemster_SelectedIndexChanged">
                   </asp:DropDownList>
                </div>
                 <div class="col-2"></div>
            </div>
            <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Select Exam</p>
                </div>
                <div class="col-6">
                   <asp:DropDownList ID="ddlSubject" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
                   </asp:DropDownList>
                </div>
                 <div class="col-2"></div>
            </div>
          
            <div class="row mt-2">
                <div class="col-1"></div>
                <div class="col-3">
                    <p>Student Image</p>
                </div>
                <div class="col-6">
                   <asp:Image ID="imgStudentImg" runat="server" Width="200px" Height="200px" />
                </div>
                <div class="col-2"></div>
            </div>
             <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Student Name</p>
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtstuname" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col-2"></div>
            </div>
             <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Student Course</p>
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtcourse" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col-2"></div>
            </div>
            
          <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Semester</p>
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtSem" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col-2"></div>
            </div>
            <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Max Marks</p>
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtExMaxMarks" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col-2"></div>
            </div>
             <div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Marks Obtained</p>
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtMarksExObt" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col-2"></div>
            </div>
             <div class="row mt-2">
                 <div class="col-1"></div>
                 <div class="col-3">
                     Enter Marks
                 </div>
                 <div class="col-6">
                     <asp:TextBox ID="txtmarks" CssClass="form-control" runat="server" placeholder="Enter Marks"></asp:TextBox>
                 </div>
                 <div class="col-2"></div>
            </div>
            <div class="row mt-2">
                <div class="col-4"></div>
                <div class="col-6">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary form-control" OnClick="btnsubmit_Click" />
                </div>
                <div class="col-2"></div>
            </div>
            
        </div>
    </div>
</asp:Content>

