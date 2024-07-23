<%@ Page Title="" Language="C#" MasterPageFile="~/Center/CenterAdminMasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ManageStudent.aspx.cs" Inherits="Center_ManageStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function printdiv(printpage) {
            var headstr = "<html><head></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
     <script type="text/javascript">
         function confirmDel() {
             return confirm("Are you sure to DELETE this?");
         }
    </script>
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
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
             <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
              <div class="row mb-2">
            <div class="col-8"></div>
                   <div class="col-2 mt-2">
                <asp:HyperLink ID="hlOldStudent" runat="server" NavigateUrl="~/Center/AddOldStudent.aspx" CssClass="btn btn-primary btn-block">Add Old Student +</asp:HyperLink>
            </div>
            <div class="col-2 mt-2">
                <a href="Student.aspx" class="btn btn-info btn-block">Add New Student +</a>
            </div>
        </div>
                <div class="row">
                    <div class="col-8" style="font-size:14px;">
                        <asp:Button ID="btnExport" runat="server" Text="Export To Excell" OnClick="btnExport_Click"/>
                        <asp:Button ID="btnpdf" runat="server" Text="Save As PDf" OnClick="btnpdf_Click"/>
                    
                        <asp:Button ID="btnprint" runat="server" Text="Print Here"  OnClientClick="printdiv('div_print');" />
                    </div>
                    <div class="col-1">
                        <asp:Label ID="lblsearch" runat="server" Text="Search"></asp:Label>
                    </div>
                    <div class="col-3" style="text-align:left;">
                        <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                   
                        </div>
                <div class="row">
                    <div class="col-12">
                    
                         <div id="ModalFees" class="modal fade" role="dialog" runat="server">
        <div class="modal-dialog" runat="server">
            <div class="modal-content" runat="server">
                <div class="modal-header" runat="server">
                    <h4>Fees Payment Details</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                     
                 </div>
                 <div class="modal-body" runat="server">
                     <div class="row">
                        
                         <div class="col-12">
                             Transaction Description:
                             <asp:TextBox ID="txtTranDesc" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                      
                         <div class="col-12">
                             <asp:HiddenField ID="hfID" runat="server" />
                             Amount To Be Paid:
                             <asp:TextBox ID="txtAmt" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                        
                         <div class="col-12">
                             Date:
                             <asp:TextBox ID="txtDate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                        
                         <div class="col-12">
                             Fees Paid For:
                             <asp:GridView ID="gvSems" Width="100%" runat="server" DataKeyNames="ID" CssClass="table rounded-corners"  style= "-moz-border-radius: 25px;border-radius: 25px;" 
                            HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" AutoGenerateColumns="false">
                                 <Columns>
                                     <asp:TemplateField>
                                          <HeaderTemplate><asp:CheckBox ID="checkAll" Text="Select" onclick="checkAll(this);" runat="server" /></HeaderTemplate>
                                         <ItemTemplate>
                                             <asp:CheckBox ID="chkSelect" runat="server" CommandArgument='<%# Eval("ID") %>' OnCheckedChanged="chkSelect_CheckedChanged"/>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:BoundField HeaderText="Semesters" DataField="Semester" />

                                 </Columns>
                             </asp:GridView>
                             
                         </div>
                         <div class="col-12 mt-2" style="text-align:center;">
                             <asp:Button ID="btnAddFees" runat="server" CssClass="btn bg-info" Text="Add Fees" OnClick="btnAddFees_Click" />
                             
                         </div>
                           <div class="col-12">
                             Transaction History
                             <asp:GridView ID="gvTransact" runat="server" Width="100%"  DataKeyNames="ID" CssClass="table table-responsive"  style= "-moz-border-radius: 25px;border-radius: 25px;" 
                            HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary" AutoGenerateColumns="false">
                                 <Columns>
                                     
                                     <asp:BoundField HeaderText="Semesters" DataField="Semester" />
                                     <asp:BoundField HeaderText="Amount" DataField="Amount"/>
                                     <asp:BoundField HeaderText="Payment Date" DataField="InvoiceDate"/>
                                     <asp:BoundField HeaderText="Transaction Description" DataField="Narration"/>
                                      <asp:TemplateField HeaderText="Generate receipt">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="btn-success" OnClick="btnGenerate_Click1"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                             
                         </div>
                     </div>
                  </div>
                  <div class="modal-footer" runat="server">

                      <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Close</button>
                 </div>
              </div>
          </div>
      </div>
                    </div>
                </div>
                <div class="row mt-2">
                    
                    <div class="col-12">
                        <div style="width:99%; overflow:scroll; height:500px;" id="div_print">
                        <asp:GridView ID="gvstudent" DataKeyNames="id" AutoGenerateColumns="false" OnRowDeleting="gvstudent_RowDeleting" OnRowDataBound="gvstudent_RowDataBound" 
                            runat="server" CellPadding="4" GridLines="None" CssClass="table table-responsive"  style= "-moz-border-radius: 25px;border-radius: 25px;" 
                            HeaderStyle-CssClass="table-sm bg-dark" RowStyle-CssClass="bg-info" AlternatingRowStyle-CssClass="table-secondary">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:ImageField DataImageUrlField="StudentImage" DataImageUrlFormatString="~/Student-Image/{0}" ControlStyle-Width="100px" ItemStyle-Width="100px" HeaderText="Student Image"></asp:ImageField>
                               <asp:TemplateField HeaderText="Student Name">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkbtnCenterLogin" runat="server" CssClass="bg-cyan" OnClick="lnkbtnCenterLogin_Click"><%# Eval("StudentName") %></asp:LinkButton>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Student Details">
                                    <ItemTemplate>
                                        <b>Father's Name</b>: <%# Eval("FatherHusbandName") %><br />
                                        <b>Gender</b>: <%# Eval("Gender") %><br />
                                        <b>Date Of Birth</b>: <%# Eval("DateOfBirth") %><br />
                                        <b>Address</b>: <%# Eval("Address") %><br />
                                        <b>Phone Number</b>: <%# Eval("StudentPhone") %><br />
                                        <b>Email-ID</b>: <%# Eval("StudentEmail") %>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Session">
                                    <ItemTemplate>
                                      Session:  <%# Eval("SessionFrom") %> to <%# Eval("SessionTo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                <asp:BoundField HeaderText="Status" DataField="isrequest"/>
                               <asp:TemplateField HeaderText="ID-Card"> 
                               <ItemTemplate>
                                   <asp:HyperLink runat="server" ID="btnGenerate" Text="Download" CssClass="btn btn-success" NavigateUrl='<%#"~/SuperAdminBackend/pdfs/"+ Eval("ICard") %>'></asp:HyperLink> 
                               </ItemTemplate>
                           </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fees Payment">
                                    <ItemTemplate>
                                        <asp:Button ID="btnFeesPay" CssClass="btn bg-gradient-purple" runat="server" Text="Fees" OnClick="btnFeesPay_Click" /></ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                      
                                        <asp:HyperLink ID="hledit" class="btn btn-primary" runat="server" NavigateUrl='<%# "EditStudent.aspx?ID=" + Eval("id")%>'><i class="fas fa-edit"></i></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Form">
                                    <ItemTemplate>
                                      
                                        <asp:HyperLink ID="lbldownload" runat="server" class="btn btn-warning" NavigateUrl='<%#"StudentForm.aspx?ID="+Eval("ID") %>'><i class="fas fa-download"></i></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                

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
        </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnExport" />
             <asp:PostBackTrigger ControlID="btnpdf" />
         </Triggers>
    </asp:UpdatePanel>
   
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
      <script type="text/javascript">
        function openFeesModal() {
            $('#ContentPlaceHolder1_ModalFees').modal('show');
           }

        </script>
    
</asp:Content>

