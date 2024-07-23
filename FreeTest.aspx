<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="FreeTest.aspx.cs" Inherits="FreeTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        .polaroid {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            /*padding:20px;*/
            height:250px;
        }
       
        .button{

        }
        .button:hover{
             box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
           width:100%;
         
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12 m-0 p-0">
            <img src="Image/online2.jpg" style="width: 100%; height: 400px;" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="container-fluid">
                <div class="row mt-3 mb-3">
                    <asp:Repeater ID="rptTest" runat="server" OnItemDataBound="rptTest_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-12 m-2 polaroid" style="text-align:center; background-image:url('Image/test1.gif'); background-size:cover;">
                               
                             <div class="row">
                                 <div class="col-lg-6 col-md-12">
                                     <%--<i class="fas fa-clipboard-list" style="font-size:50px; color:midnightblue;"></i><br />--%>
                                        <asp:Label ID="lblShowName" runat="server" Font-Size="18px" Style="font-family: Verdana, Geneva, Tahoma, sans-serif; color: #030976;"><%#Eval("ExamName") %></asp:Label>
                                     </div>
                                 <div class="col-lg-6 col-md-12">
                                         <span style="color:black; font-weight:bold;"> Questions -</span> <asp:Label ID="lblqueistion" runat="server"></asp:Label>
                                 </div>
                             </div>
                                <br />
                                         <asp:HyperLink ID="hlLink" Text="Take Test"  CssClass="btn btn-warning button" runat="server" NavigateUrl='<%#"FreeTestQuestions.aspx?TID="+Eval("ID") %>' Style="text-decoration: none; border-radius:20px; margin-top:150px;">
                                         
                                        </asp:HyperLink>
                                <asp:HiddenField ID="hf" runat="server" Value='<%#Eval("ID") %>' />
                                  
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

