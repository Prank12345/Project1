<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentRequestCertificate.aspx.cs" Inherits="Center_StudentRequestCertificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Add Offline Marks</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Add Offline Marks</li>
            </ol>
          </div><!-- /.col -->
        </div>
            </div>
        </div>
        <div class="content">
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
                  <%--  <div class="row mt-2">
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
            
          <%--<div class="row mt-2">
                 <div class="col-1"></div>
                <div class="col-3">
                    <p>Semester</p>
                </div>
                <div class="col-6">
                    <asp:TextBox ID="txtSem" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="col-2"></div>
            </div>--%>
           
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
         <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Student Certificate Request</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">              
              <li class="breadcrumb-item active">Student Certificate Request</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
       <section class="content">
             <div class="container-fluid">
                <div class="card">
                    <div class="card-body">
                    <asp:Label ID="lblTest" runat="server"></asp:Label>
                      <%--  <div class="row">


                            <div class="col-lg-3 col-sm-3">Enter Student ID to Search</div>
                            <div class="col-lg-3 col-sm-3">
                                <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-sm-2">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click"><i class="fas fa-search"></i></asp:LinkButton>
                            </div>

                        </div>--%>
    <div class="row">
                            <div class="col-12">
                                <p style="font-size: 20px;">Certificate Request</p>
                                <asp:GridView ID="gvCertificate" runat="server" CellPadding="4" DataKeyNames="ID" AutoGenerateColumns="false" GridLines="None"  CssClass="table rounded-corners" 
                        style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" 
                        AlternatingRowStyle-CssClass="table-secondary" HeaderStyle-HorizontalAlign="Center" Width="100%">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField HeaderText="Student ID" DataField="StudentID" />
                                        <asp:ImageField DataImageUrlField="StudentImage" DataImageUrlFormatString="~/Student-Image/{0}" ControlStyle-Width="100px" ItemStyle-Width="100px" HeaderText="Student Pic"></asp:ImageField>
                                         <asp:BoundField HeaderText="Student Name" DataField="StudentName" />
                                        <asp:BoundField HeaderText="Father Name" DataField="FatherHusbandName" />
                                         <asp:BoundField HeaderText="Gender" DataField="Gender" />
                                        
                                          <asp:BoundField HeaderText="Marks Obtained" DataField="ObtainedMarks" />
                                         
                                        <asp:TemplateField HeaderText="Request">
                                            <ItemTemplate>
                                               <asp:Button ID="btnRequest" runat="server" CssClass="btn btn-success" Text="Request" OnClick="btnRequest_Click"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reject">
                                            <ItemTemplate>
                                                <asp:Button ID="btnReject" CssClass="btn btn-danger" runat="server" Text="Reject" OnClick="btnReject_Click"/>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
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
           </section>
    </div>
</asp:Content>

