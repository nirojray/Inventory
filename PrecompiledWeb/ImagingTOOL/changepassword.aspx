<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="changepassword, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      &nbsp;</h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                           <a href="changepassword.aspx">Change Password</a><span class="divider">&nbsp;</span>
                       </li>
                       
                      
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
                            <h4>Change Password</h4>
                                        <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                        <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                        </div>
                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form action="#" class="form-horizontal">
                              
                            </form>
                            <!-- END FORM-->
                            &nbsp;&nbsp;
                    
                            <table cellpadding="5" cellspacing="5"
                                width="50%">
                                <tr>
                                    <td class="style1" colspan="3">
                                        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Change Password</strong></td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 44%">
                                        &nbsp;</td>
                                    <td style="width: 1%">
                                        &nbsp;</td>
                                    <td align="left" style="width: 55%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 44%">
                                        Old Password <span style="color: Red">*</span>
                                    </td>
                                    <td style="width: 1%">
                                        :
                                    </td>
                                    <td align="left" style="width: 55%">
                                        <asp:TextBox ID="txtbox_OldPassword" runat="server" TextMode="Password" 
                                            Width="185px"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right" style="width: 44%">
                                        &nbsp;</td>
                                    <td style="width: 1%">
                                        &nbsp;</td>
                                    <td align="left" style="width: 55%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        New Password <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtbox_newPassword1" runat="server" TextMode="Password" 
                                             Width="185px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 44%">
                                        &nbsp;</td>
                                    <td style="width: 1%">
                                        &nbsp;</td>
                                    <td align="left" style="width: 55%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Confirm Password <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtbox_newPassword2" runat="server" TextMode="Password" 
                                             Width="185px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <br />
                                        <asp:Button ID="btn_Save" runat="server" Height="39px" OnClick="btn_Save_Click" 
                                            OnClientClick="return validatePassword()" Text="Change Password" Width="120px" />
                                    </td>
                                </tr>
                            </table>
                    
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>

            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
      </div>
</asp:Content>

