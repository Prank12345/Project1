<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Center_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="content-wrapper">
        <div class="content">
            <div class="row p-3">
                <div class="col-4">
                    <div class="card">
                        <div class="card-body">
                           <asp:Image ID="imglogo" runat="server" /><br />
                            <p class="mt-3">Your Center Logo:</p><br />
                            <p style="font-size:14px;">Choose Logo</p>
                            <asp:FileUpload ID="fulogo" runat="server" />
                            <asp:Button ID="btnchnglogo" runat="server" CssClass="mt-3 btn btn-primary" Text="Change Logo" OnClick="btnchnglogo_Click" /><br />
                            <p style="color:red; font-size:12px;">Newly Updated logo wont appear in already generated Certificates and Marksheets .</p>
                        </div>
                    </div>
                </div>
                <div class="col-8">
                    <div class="card">
                        <div class="card-body">
                            <p class="card-header">Change Password</p>
                                <asp:TextBox ID="txtoldpass" CssClass="form-control mt-3" placeholder="Old Password" runat="server"></asp:TextBox>
                           <div class="row">
                                <div class="col-6">
                                <asp:TextBox ID="txtnewpass" CssClass="form-control mt-3" placeholder="New Password" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                 <asp:TextBox ID="txtpasscofrm" CssClass="form-control mt-3" placeholder="Confirm Password" runat="server"></asp:TextBox>
                            </div>
                               <div class="col-12">
                                 <asp:Label ID="Label1" runat="server"></asp:Label>
                            </div>
                           </div>
                            <div class="row mt-5">
                                <div class="col-10"></div>
                                <div class="col-2"><asp:Button ID="btnupdate" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnupdate_Click" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           
              </div> 
 </div>
</asp:Content>

