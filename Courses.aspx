<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=EB+Garamond&display=swap" rel="stylesheet">
    <style>
        .fancy {
  position: relative;
  background-color: #FFC;
  padding: 2rem;
  text-align: center;
  max-width: 100%;
}
.fontnew
{
    font-family: 'EB Garamond', serif;
}
.fancy::before {
  content: "";

  position : absolute;
  z-index  : -1;
  bottom   : 15px;
  right    : 5px;
  width    : 50%;
  top      : 80%;
  max-width: 200px;

  box-shadow: 0px 13px 10px black;
  transform: rotate(4deg);
}
.changecolor {
  animation: color-change 3s infinite;
}

@keyframes color-change {
  0% {color: palevioletred; }
  25% {color: white; }
  50%{color: fuchsia;}
  75%{color:greenyellow;}
  100% {color: yellow; }
}
.w3-animate-input{transition:width 0.4s ease-in-out}
.w3-animate-input:focus{width:100%!important}                                                
.w3-input{padding:8px;display:block;border:none;border-bottom:1px solid #ccc;width:100%}
.w3-border{border:1px solid #ccc!important}
.w3-display-topmiddle{position:absolute;left:50%;top:0;transform:translate(-50%,0%);-ms-transform:translate(-50%,0%)}
.w3-card{box-shadow:0 2px 5px 0 rgba(0,0,0,0.16),0 2px 10px 0 rgba(0,0,0,0.12)}
.w3-border-indigo,.w3-hover-border-indigo:hover{border-color:#3f51b5!important}
.w3-text-indigo,.w3-hover-text-indigo:hover{color:#3f51b5!important}
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
             <div class="container-fluid">
        <div class="row">
            <div class="col-12 m-0 p-0">
                <img src="Image/courses.jpg" class="img-fluid" style="height:400px; width:100%;" alt="" />
            </div>
        </div>
    </div>
     <div class="container">
        <div class="row">
            <div class="col-12 mt-5" style="text-align:center;">
                <h1>Courses</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid mb-3">
        <div class="row">
                <div class="col-lg-12 col-md-12 mb-4">
                                <span>Course Type</span><br />
                                 <asp:TextBox ID="txtSearch" placeholder="Search" CssClass="w3-input w3-animate-input w3-border w3-display-topmiddle w3-card w3-border-indigo w3-hover-text-indigo" style="width:40%;" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                                </div>
                       
            </div>
         <div class="row">
                            <div class="col-12">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="20px"></asp:Label>
                            </div>
                        </div>
        </div>
      <div class="container-fluid mb-3">
          <div class="row">
              
                     <asp:Repeater ID="rptCourseType" runat="server" OnItemDataBound="rptCourseType_ItemDataBound">
              <ItemTemplate>
                  <div class="col-lg-6 col-12">
                   <div id="accordionCT<%= getIndexct() %>" style="background-image:url('');">
                        <div class="card mt-2">
                            <!--#d7e2ff;-->
                            <div class="card-header" style="text-align: center; background-color: midnightblue;">
                                <div class="card-link" style="color: white;">
                                <div class="row">
                                    <div class="col-lg-2 col-6" style="text-align: left;">
                                        <asp:Image runat="server" ImageUrl='<%#"~/CourseTypeImage/"+ Eval("ImageUpload") %>' Height="90px" Width="90px" style="border-radius:10px;" />
                                           
                                            
                                    </div>
                                     <div class="col-lg-10 col-6" style="text-align: left;">
                                          <asp:Label ID="lblcenterType" runat="server" CssClass="uppercase"><%# Eval("CourseType") %></asp:Label> <i class="fas fa-book-reader fa-2x changecolor" style="float:right;"></i><br /><br />
                                         <a class="btn btn-block btn-outline-info" data-toggle="collapse" href="#collapseCT<%= getIndexct() %>" >See More</a>
                                         </div>
                                </div>
                                    </div>
                                     
                            </div>

                            <div id="collapseCT<%= getIndexct() %>" class="collapse" data-parent="#accordionCT<%= getIndexct() %>" style="background-image:url('Image/imageedit_1_9137610113.png'); background-size:cover; background-size:100% 100%; background-repeat:no-repeat; ">
                                <div class="card-body">
                                    <div class="row">
                                       
                                            <asp:HiddenField ID="hfIDCT" runat="server" Value='<%# Eval("ID") %>' />
                                         <asp:Repeater ID="rprcourse" runat="server" OnItemDataBound="rprcourse_ItemDataBound">
                <ItemTemplate>
                     <div class="col-lg-12 col-12">
                    <div id="accordion<%= getIndex() %>" style="background-image:url('');">
                        <div class="card mt-2">
                            <!--#d7e2ff;-->
                            <div class="card-header" style="text-align: center; background-color: #003a6a;">
                                <a class="card-link" data-toggle="collapse" href="#collapse<%= getIndex() %>" style="color: white;">
                                <div class="row">
                                    <div class="col-12" style="text-align: center;">
                                        
                                            <asp:Label ID="lblcenter" runat="server" CssClass="uppercase" style="float:left !important;"><%# Eval("FullCourseName") %></asp:Label>
                                            <asp:Label ID="shortName" runat="server" style="float:right !important;" ><%# Eval("ShortName") %></asp:Label>
                                    </div>

                                </div>
                                     </a>
                            </div>

                            <div id="collapse<%= getIndex() %>" class="collapse" data-parent="#accordion<%= getIndex() %>" style="background-image:url('Image/imageedit_1_9137610113.png'); background-size:cover; background-size:100% 100%; background-repeat:no-repeat; ">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-lg-3 col-sm-12" style="text-align:left;">
                                            <h4><%# Eval("ShortName") %></h4>
                                                    <hr />
                                         
                                        </div>
                                        <div class="col-lg-9 col-sm-12">
                                            <div class="row">
                                                <div class="col-lg-5 col-sm-12">
                                                    <h4>About Course</h4>                                                   
                                                    <hr />
                                                    <p style="color:midnightblue; font-size:22px; font-weight:bold;">Course Code :<span style="color:maroon;"> <%#Eval("CourseCode") %></span></p>
                                                    <p style="color:midnightblue; font-weight:bold;">Eligibility :<span style="color:maroon;"> <%#Eval("Eligibility") %> </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:midnightblue">Duration</span> : <span style="color:maroon"><%#Eval("Duration") %></span></p>
                                                    <p style="color:midnightblue; font-weight:bold;">Reg Fees : <span style="color:maroon"><%#Eval("RegFeesUniv") %></span></p>                                                    
                                                    <p style="color:midnightblue; font-weight:bold;">Course Fees : <span style="color:maroon"><%#Eval("ProgFeesUniv") %></span></p>
                                                    <p style="color:midnightblue; font-weight:bold;">Exam Fees : <asp:Label ID="lblExm" runat="server" style="color:maroon"></asp:Label></p>
                                                    <p style="color:midnightblue; font-weight:bold;">Instruction Mode : <span style="color:maroon"><%# Eval("InstructionMode") %></span></p>
                                                    <p style="color:midnightblue; font-weight:bold;">Exam Attendant :<span style="color:maroon"> <%# Eval("ExamAttendant") %></span></p>
                                                    <p style="color:midnightblue; font-weight:bold;">Medium : <span style="color:maroon"><%# Eval("Medium") %></span></p>
                                                </div>
                                                <div class="col-lg-7 col-sm-12">
                                                  <h4>Course contains</h4>
                                                    <hr />
                                                   <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                                                    <asp:GridView ID="gvSemester" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" Width="100%" GridLines="Horizontal" BorderStyle="None" OnRowDataBound="gvSemester_RowDataBound">
                                                        
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Semesters" HeaderStyle-CssClass="fontnew" ItemStyle-CssClass="fontnew" ItemStyle-Font-Size="20px" ControlStyle-CssClass="fontnew" ItemStyle-ForeColor="MidnightBlue" ItemStyle-Font-Bold="true">
                                                                <ItemTemplate>
                                                                    <%# Eval("Semester") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Paper Code" HeaderStyle-CssClass="fontnew" ItemStyle-Font-Bold="true" ItemStyle-CssClass="fontnew" ControlStyle-CssClass="fontnew" ItemStyle-ForeColor="Maroon">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hfCode" runat="server" Value='<%# Eval("PaperCode") %>' />
                                                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subjects" HeaderStyle-CssClass="fontnew" ItemStyle-Font-Bold="true" ItemStyle-CssClass="fontnew" ControlStyle-CssClass="fontnew" ItemStyle-ForeColor="#013902">
                                                            <ItemTemplate>
                                                                    <asp:HiddenField ID="hfSubject" runat="server" Value='<%# Eval("Subjects") %>' />
                                                                  <asp:Label ID="lblSubject" runat="server"></asp:Label>  
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                          
                                        </div>




                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                          </div>
                    <% incrementIndex(); %>
                </ItemTemplate>
            </asp:Repeater>
                                     
                                    </div>
                                </div>
                            </div>
                        
                
                            </div>
                   </div>
                    <% incrementIndexct(); %>
                      </div>
              </ItemTemplate>
          </asp:Repeater>
              
          </div>
       
            

            </div>    
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="txtSearch"  />
        </Triggers>
    </asp:UpdatePanel>
   
</asp:Content>

