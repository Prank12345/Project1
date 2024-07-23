<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminBackend/SuperAdminMasterPage.master" AutoEventWireup="true" CodeFile="SetMainExam.aspx.cs" Inherits="SuperAdminBackend_SetMainExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
        function openModal() {
           $('#MyModal').modal('show');
           }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="row"></div>
                <div class="row mt-3">
                    <div class="col-12">
                        <p style="font-size:30px;">Set Main Exam</p>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                         <div class="row mt-3" style="font-size:15px;">
                             <div class="col-3">
                                 <asp:Label ID="Label1" runat="server" Text="Select Course"></asp:Label>
                             </div>
                        <div class="col-9">
                            
                            <asp:DropDownList ID="ddlCourse" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                   </asp:DropDownList>
                        </div>
                     
                        </div>
                         <div class="row mt-3" style="font-size:15px;">
                             <div class="col-3">
                                 <asp:Label ID="Label2" runat="server" Text="Select Semester"></asp:Label>
                             </div>
                        <div class="col-9">
                            
                           <asp:DropDownList ID="ddlSemster" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSemster_SelectedIndexChanged">
                   </asp:DropDownList>
                        </div>
                     
                        </div>
                        <div class="row mt-3" style="font-size:15px;">
                             <div class="col-3">
                                 <asp:Label ID="lblmainexam" runat="server" Text="Select Main Exam"></asp:Label>
                             </div>
                        <div class="col-9">
                            
                            <asp:DropDownList ID="ddlmainexam" CssClass="form-control" runat="server">
                                
                            </asp:DropDownList>
                        </div>
                     
                        </div>
                        <div class="row mt-3" style="font-size:15px;">
                            <div class="col-3"><asp:Label ID="lblExammode" runat="server" Text="Select Exam Mode"></asp:Label></div>
                            <div class="col-9">
                             
                                <asp:DropDownList ID="ddlexammode" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Select Exam Mode" Selected="True" disabled="disabled"></asp:ListItem>
                                    <asp:ListItem Text="ONLINE" Value="Online"></asp:ListItem>
                                    <asp:ListItem Text="OFFLINE" Value="Offline"></asp:ListItem>
                                </asp:DropDownList>
                            </div> 
                            
                        </div>
                          <div class="row mt-2 pl-3 pr-3">
                                    <div class="col-3">
                                        <asp:Label ID="Label5" runat="server" Text="Exam Date"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:TextBox ID="txtExDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                   
                                </div>
                        <div class="row mt-3" style="font-size:15px;">
                            <div class="col-3"></div>
                            <div class="col-6" >
                                <asp:Label ID="lblselectstd" runat="server" Text="Student"></asp:Label>
                                <div style="width:99%;height:200px; overflow:scroll;">
                                <asp:GridView ID="gvStudents" runat="server" CssClass="Grid" Width="100%" DataKeyNames="ID" AutoGenerateColumns="false" GridLines="Both">
                                    <AlternatingRowStyle />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate><asp:CheckBox ID="checkAll" Text="Select Student" onclick="checkAll(this);" runat="server" /></HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" CommandArgument='<%# Eval("ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Student Name" DataField="StudentName" />
                                    </Columns>
                                    <RowStyle />
                                    <FooterStyle />
                                    <HeaderStyle />
                                </asp:GridView>
                                    </div>
                            </div>
                            <div class="col-3"></div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-3"></div>
                            <div class="col-6">
                                <asp:Button ID="btnaddexam" CssClass="form-control btn btn-primary" runat="server" Text="Set Exam" OnClick="btnaddexam_Click" />
                            </div>
                            <div class="col-3"></div>
                        </div>
                       
                    </div>
                    <div class="row mt-2 mb-3">
                        <div class="col-lg-12 col-md-12">
                             <div style="width: 99%; height:350px; overflow: scroll;">
                                 <asp:GridView ID="gvCenter" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HeaderStyle-Wrap="false"
                                        HeaderStyle-HorizontalAlign="Center" Width="100%" CellPadding="8" BorderStyle="Solid" BorderWidth="2px">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
                                            <asp:ImageField DataImageUrlField="StudentImage" DataImageUrlFormatString="~/Student-Image/{0}" ControlStyle-Width="100px" ItemStyle-Width="100px" HeaderText="Student Pic"></asp:ImageField>                                            
                                             <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                            <asp:BoundField DataField="FatherHusbandName" HeaderText="Father/Husband Name" />
                                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                             <asp:BoundField DataField="StudentPhone" HeaderText="Phone Number" />
                                            <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" />
                                            <%--<asp:TemplateField HeaderText="Question Paper">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlQuestions" runat="server" NavigateUrl='<%#"ViewQuestion.aspx?QID="+Eval("EListid") %>'><i class="fas fa-eye"></i></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                          <%--  <asp:TemplateField HeaderText="Question Paper">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbPop" runat="server" OnClick="lbPop_Click"><i class="fas fa-eye"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="ExamMode" HeaderText="Exam Mode" />
                                           
                                            
                                        </Columns>
                                        <FooterStyle BackColor="#b5dedc" ForeColor="#3d8c3c" />
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#e5e1fc" Font-Bold="True"
                                            ForeColor="#3d1d1d" BorderColor="#ddd"></HeaderStyle>
                                        <PagerStyle BackColor="#ddf2d8" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                        <RowStyle VerticalAlign="Top" BackColor="#f5edfc" ForeColor="#4A3C8C" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#f0f9fc" />


                                    </asp:GridView>
                                 </div>
                        </div>
                    </div>
                </div>
  <%--              <div id="MyModal" class="modal fade" role="dialog" runat="server">
                    <div class="modal-dialog" runat="server">
                        <div class="modal-content" runat="server">
                            <div class="modal-header" runat="server">
                                <h4>Question Paper</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                            </div>
                            <div class="modal-body" runat="server">



                                <div class="row mb-2 mt-2">

                                    <asp:Repeater ID="rptQuestion" runat="server">
                                        <ItemTemplate>
                                            <div class="col-lg-12 col-md-12">
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12">
                                                        <h5>Question:
                                                            <asp:Label ID="lblQues" runat="server"><%#Eval("Question")%></asp:Label></h5>


                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <p>A
                                                            <asp:Label ID="lblAns1" runat="server"><%#Eval("Option1") %></asp:Label></p>

                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <p>B
                                                            <asp:Label ID="lblAns2" runat="server"><%#Eval("Option2") %></asp:Label></p>

                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <p>C
                                                            <asp:Label ID="lblAns3" runat="server"><%#Eval("Option3") %></asp:Label></p>

                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <p>D
                                                            <asp:Label ID="lblAns4" runat="server"><%#Eval("Option4") %></asp:Label></p>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12 mb-5">
                                                        <h5>
                                                            <asp:Label ID="Label1" runat="server">Correct Answer:  <%# Eval("CorrectAnswer") %></asp:Label></h5>
                                                    </div>
                                                </div>

                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>


                            </div>
                            <div class="modal-footer" runat="server">
                                <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </section>
         <script type = "text/javascript">

    function checkAll(objRef) {

        var GridView = objRef.parentNode.parentNode.parentNode;

        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {

            //Get the Cell To find out ColumnIndex

            var row = inputList[i].parentNode.parentNode;

            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                if (objRef.checked) {

                   

                    inputList[i].checked = true;

                }

                else {

                    

                    if (row.rowIndex % 2 == 0) {

                       

                    }

                    else {

                       

                    }

                    inputList[i].checked = false;

                }

            }

        }

    }

</script> 
    </div>
</asp:Content>