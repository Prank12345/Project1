<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="EditStudent.aspx.cs" Inherits="Center_EditStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
       .rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 10px;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content-wrapper">
        <div class="content">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12">
                            <p style="font-size:20px;">Edit Student</p>
                        </div>
                    </div>
                    <div class="row mt-3">
                       <div class="col-12">
                            <asp:label  runat="server" text="Student Name"></asp:label>
                            <asp:textbox ID="txtsname" placeholder="Enter Student Name" required cssclass="form-control" runat="server"></asp:textbox>
                       </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12">
                                 <asp:label  runat="server" text="Father/Husband Name"></asp:label>
                                 <asp:textbox ID="txtfhname"  placeholder="Enter Father/Husband Name" required cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                        </div>
                      <div class="row mt-3">
                            <div class="col-lg-12 col-sm-12">
                                 <asp:label  runat="server" text="Mother's Name"></asp:label>
                                 <asp:textbox ID="txtMName"  placeholder="Enter Mother Name" required cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                        </div>
                      <div class="row mt-3">
                            <div class="col-lg-12 col-sm-12">
                                 <asp:label  runat="server" text="Father's Occupation"></asp:label>
                                 <asp:textbox ID="txtOccupation"  placeholder="Enter Occupation" required cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                        </div>
                    <div class="row mt-3">
                            <div class="col-lg-12 col-sm-12">
                                 <asp:label  runat="server" text="Student Occupation"></asp:label>
                                 <asp:textbox ID="txtSOccupation"  placeholder="Enter Student Occupation" required cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                        </div>
                     <div class="row mt-3">
                            <div class="col-lg-12 col-sm-12">
                                 <asp:label  runat="server" text="Student Phone"></asp:label>
                                 <asp:textbox ID="txtPhone"  placeholder="Enter Student Phone" required cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-12 col-md-12">
                                 <asp:Label ID="lbldob" runat="server" Text="Date Of Birth"></asp:Label>
                                 <asp:TextBox ID="txtdob" TextMode="Date" required CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-12 col-md-12">
                                 <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label><br />
                                 <asp:RadioButtonList ID="rbgender" RepeatDirection="Horizontal" CssClass="rbl" runat="server">
                                 <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                 <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                 <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                 </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-12 col-md-12">
                                 <asp:Button ID="btnUpdate" CssClass="form-control btn-primary" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

