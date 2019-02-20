<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="AdminUserCreation, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                        User Name</td>
                                    <td>
                                        <asp:TextBox ID="txtUSername" runat="server"></asp:TextBox>
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
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                       Login Name</td>
                                    <td>
                                        <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
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
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        Email ID</td>
                                    <td>
                                        <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>&nbsp;</td>
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
                                    <td colspan="2">
                                        <asp:Button ID="btnCreate" runat="server" Text="Create" type="submit" 
                                            class="btn btn-success" onclick="btnCreate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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

