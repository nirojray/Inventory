<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="RptPurchaseOutStanding.aspx.cs" EnableEventValidation="false" Inherits="RptPurchaseOutStanding" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript">
         function validateMandatoryFields() {

            if (document.getElementById('<%=TxtFromDate.ClientID %>').value == "") {

                alert("Please Select From Date");
                document.getElementById('<%=TxtFromDate.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=TxtToDate.ClientID %>').value == "") {
                alert("Please Select To Date");
                document.getElementById('<%=TxtToDate.ClientID %>').focus();

                return false;
            }
            var FromDate = document.getElementById('<%=TxtFromDate.ClientID %>').value;
            var ToDate = document.getElementById('<%=TxtToDate.ClientID %>').value;
            if (Date.parse(FromDate) > Date.parse(ToDate)) {
                alert("Invalid Date Range!\nFrom Date can't be greather than To Date!")
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
                      Report
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                          <a href="#">Report</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> <a href="RptPurchaseOutStanding.aspx">Purchase Order Outstanding Summary</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Purchase Order Outstanding Summary Report</h4>
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
                                    <td colspan="2">
                                      </td>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 229px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 79px">
                                        From Date</td>
                                    <td style="width: 217px">
                                        <asp:TextBox ID="TxtFromDate" runat="server" ReadOnly="true"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtFromDate"></rjs:PopCalendar>
                                            
                                    </td>
                                    <td style="width: 64px">
                                        To Date</td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="TxtToDate" runat="server"  ReadOnly="true"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar2" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtToDate"></rjs:PopCalendar>
                                            
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnExport" runat="server" Text="Export" OnClientClick="return validateMandatoryFields();" 
                                            onclick="BtnExport_Click" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td  colspan="4" align="center">
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                                                        Height="20px" Style="margin-left: 0px"  Width="233px"></asp:Label></td>
                                    <td style="width: 217px">
                                        &nbsp;</td>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                   <td style="width: 229px">
                                        &nbsp;</td>
                                   <%--  <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>--%>
                                </tr>
                                <tr>
                                    <td style="width: 79px">
                                        &nbsp;</td>
                                    <td style="width: 217px">
                                        &nbsp;</td>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 229px">
                                        &nbsp;</td>
                                    <td>
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

