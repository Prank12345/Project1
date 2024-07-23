<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" CodeFile="ManageCourse.aspx.cs" Inherits="Center_AddCourse" %>

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
        <section class="content">
                <div class="container-fluid">
                    <div class="row"></div>
        <div class="row mt-3">
            <div class="col-10"></div>
            <div class="col-2">
              
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-12">
                <div style="width:99%; overflow:scroll; height:450px;">
                <asp:GridView ID="gvcourse" DataKeyNames="id" Width="100%" AutoGenerateColumns="false" OnRowDeleting="gvcourse_RowDeleting" runat="server" CellPadding="3"
                     GridLines="None" CssClass="table rounded-corners" style= "-moz-border-radius: 25px;border-radius: 25px;" HeaderStyle-CssClass="table-sm bg-dark" 
                    RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                            <asp:BoundField DataField="FullCourseName" HeaderText="Full Course Name" />
                                            <asp:BoundField DataField="ShortName" HeaderText="Abbrivation" />
                                            <asp:BoundField DataField="CourseDetail" HeaderText="Course Detail" />
                                            <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                            <asp:BoundField DataField="Eligibility" HeaderText="Eligibility" />
                                            <asp:BoundField DataField="Medium" HeaderText="Medium" />
                                            <asp:BoundField DataField="InstructionMode" HeaderText="Instruction Mode" />
                        
                    </Columns>
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

        </section>
    </div>

</asp:Content>

