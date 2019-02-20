<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="RptConsolidatedStock.aspx.cs" Inherits="RptConsolidatedStock" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                     Consolidated Stock Report
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                          <a href="#">Consolidated Stock Report</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> <a href="RptConsolidatedStock.aspx">Consolidated Stock Statement Report</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Consolidated Stock Statement Report</h4>
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
                            <br />
                            <br />
                            <table style="width: 100%">
                               <%-- <tr>
                                    <td colspan="2">
                                       Stock Statement</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 79px">
                                      From Date </td>
                                    <td style="width: 217px">
                                        <asp:TextBox ID="TxtFromDate" runat="server" ReadOnly="true"></asp:TextBox>
                                        <popcalendar id="PopCalendar1" runat="server" control="TxtFromDate" 
                                            format="dd mmm yyyy" separator="-" showerrormessage="False">
                        <rjs:PopCalendar ID="PopCalendar3" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtFromDate"></rjs:PopCalendar>
                                            
                                        </popcalendar>
                                    </td>
                                    <td style="width: 79px">
                                      &nbsp;
                                      To Date </td>
                                    <td style="width: 217px">
                                        <asp:TextBox ID="txtTodate" runat="server" ReadOnly="true"></asp:TextBox>
                                        <popcalendar id="PopCalendar2" runat="server" control="txtTodate" 
                                            format="dd mmm yyyy" separator="-" showerrormessage="False">
                        <rjs:PopCalendar ID="PopCalendar4" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="txtTodate"></rjs:PopCalendar>
                                            
                                        </popcalendar>
                                    </td>
                                     <td style="width: 79px">&nbsp;&nbsp;<asp:Button ID="BtnExport" runat="server" onclick="BtnExport_Click" Text="Export" />
                                    </td>
                                       <td style="width: 79px">
                                       </td>
                                    <td style="width: 117px">
                                    
                                    </td>
                                   
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 79px">
                                        &nbsp;</td>
                                    <td style="width: 217px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Label ID="lblmsg" Text="" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                </table>
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

