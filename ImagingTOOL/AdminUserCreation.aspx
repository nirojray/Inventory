<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AdminUserCreation.aspx.cs" Inherits="AdminUserCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript">

         function validateTextBoxBlank() {
             debugger
             var txtUSername = document.getElementById('<%=txtUSername.ClientID %>').value; 
             var txtFullname = document.getElementById('<%=txtFullname.ClientID %>').value;            
            var ddlUserType = document.getElementById('<%=ddlUserType.ClientID %>'); 
             var ddlUserTypeValue = ddlUserType.options[ddlUserType.selectedIndex].value;
              var TxtEmail = document.getElementById('<%=txtEmailID.ClientID %>').value;
             //var ddlStatusvalue = ddlStatus.options[ddlStatus.selectedIndex].value;
             var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            
             var reg1 = /^([\w-\.]+@(?!centillionss.com)([\w-]+\.)+[\w-]{2,4})?$/

             if (txtUSername == "") {
                 alert("Please Enter Name");
                 document.getElementById('<%=txtUSername.ClientID %>').focus();
                 return false;
             } else if (txtFullname == "") {
                 alert("Please Enter User Name");
                 document.getElementById('<%=txtFullname.ClientID %>').focus();
                 return false;
             }
             else if (ddlUserTypeValue == "0") {
                 alert("Please Select User Type");
                 document.getElementById('<%=ddlUserType.ClientID %>').focus();
                 return false;
             }     
             else if (TxtEmail == "") {
                 alert("Please Enter Email");
                 document.getElementById('<%=txtEmailID.ClientID %>').focus();
                 return false;
             }
             else if (reg.test(TxtEmail) == false) {
                 alert('Please provide a valid email address');
                 document.getElementById("<%=txtEmailID.ClientID %>").focus();
                 return false;
             }

     <%--         else if (reg1.test(TxtEmail) == true) {
                 alert('Please provide a Centillion email address');
                 document.getElementById("<%=txtEmailID.ClientID %>").focus();
                 return false;
             }      --%>  
           
         }
    </script>

    <script type="text/javascript">
function validateFreeEmail(email) 
{
 var reg = /^([\w-\.]+@(?!gmail.com)(?!yahoo.com)(?!hotmail.com)([\w-]+\.)+[\w-]{2,4})?$/
 if (reg.test(email)){
 return true;
 }
 else{
 return false;
 }
} 
</script> 
    <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Admin
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                           <a href="#">Admin</a><span class="divider">&nbsp;</span>
                       </li>
                       
                       <li> <a href="AdminUserCreation.aspx">Admin </a>User Creation<span class="divider-last">&nbsp;</span></li>
                   </ul>
               </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>User Creation</h4>
                                        <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                        <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                        </div>
                            <table style="width: 100%">
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                         Name</td>
                                    <td>
                                        <asp:TextBox ID="txtUSername" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
                                  <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                       User Name</td>
                                    <td>
                                        <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
                                 <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        User Type</td>
                                    <td>
                                        <asp:DropDownList ID="ddlUserType" runat="server" Width="180px"></asp:DropDownList>&nbsp;

                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        Email ID</td>
                                    <td>
                                        <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
                                        
                                        
                                        
                                        &nbsp;</td>
                                </tr>
                               <%-- <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        <asp:Button ID="btnCreate" runat="server" Text="Create" type="submit" 
                                            class="btn btn-success" onclick="btnCreate_Click" OnClientClick="return validateTextBoxBlank();" />
                                             &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" type="submit"  Visible="false"
                                            class="btn btn-success" onclick="btnUpdate_Click" OnClientClick="return validateTextBoxBlank();" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  type="submit" 
                                            class="btn btn-success" onclick="btnCancel_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td class="input-medium"  colspan="3">
                                       <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        &nbsp;</td>                                   
                                </tr>
                                <tr>
                                    <td class="input-medium"  colspan="3">
                                        Search with User Name:<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> &nbsp 
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />&nbsp
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" onclick="btnClear_Click"  />
                                        &nbsp;</td>                                   
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px" colspan="3">
                                        <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="false" Width="80%"
                                            AllowPaging="True" PageSize="10"
                                        EmptyDataText="No Record Found" CssClass="content-grid"
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                        OnPageIndexChanging="gvSearch_PageIndexChanging"
                                             OnRowCommand="gvSearch_rowcommand" >
                                           <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.no">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Full Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Login Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLoginName" runat="server" Text='<%# Eval("LoginName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmailId" runat="server" Text='<%# Eval("EmailId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                               
                                                  <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                       <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edited" ForeColor="Black" CommandArgument='<%#Eval("Id") %>' />&nbsp
                                                        
                                                    </ItemTemplate>
                                                     
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        &nbsp;</td>
                                    
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>

            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
      </div>
  
</asp:Content>

