<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AdminPasswordReset.aspx.cs" Inherits="AdminPasswordReset" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function validateMandatory() {
            if (document.getElementById('<%=ddlUserType.ClientID%>').selectedIndex == 0) {
                alert("Please Select User Type");
                document.getElementById('<%=ddlUserType.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddl_USername.ClientID%>').selectedIndex == 0) {
                alert("Please Select User Name");
                document.getElementById('<%=ddl_USername.ClientID %>').focus();
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
                       
                       <li> <a href="AdminPasswordReset.aspx">Admin Password Reset</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Password Reset</h4>
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
                                        User Type</td>
                                    <td>
                                        <asp:DropDownList ID="ddlUserType" runat="server" Width="144px" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        User Name</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_USername" runat="server" Width="144px">
                                        </asp:DropDownList>
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
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" type="submit" OnClientClick="return validateMandatory();"
                                            class="btn btn-success" onclick="btnReset_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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

