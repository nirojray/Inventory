<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="ReportAR.aspx.cs" Inherits="ReportAR" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                       
                    <li> <a href="ReportAR.aspx">Agewise Receivables</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Agewise Receivables Report</h4>
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
                                    <td style="width: 79px">
                                        From Date</td>
                                    <td style="width: 217px">
                                        <asp:TextBox ID="TxtFromDate" runat="server"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtFromDate"></rjs:PopCalendar>
                                            
                                    </td>
                                    <td style="width: 64px">
                                        To Date</td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="TxtToDate" runat="server"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar2" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtToDate"></rjs:PopCalendar>
                                            
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnExport" runat="server" Text="Export" 
                                            onclick="BtnExport_Click" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
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
                            <asp:GridView ID="GvwAR" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                                BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SO Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_Date" runat="server" Text='<%# Eval("sodate") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SO Number">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_Number" runat="server" Text='<%# Eval("[sonum]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvociedate" runat="server" Text='<%# Eval("invociedate") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Invoice No">
                                        <ItemTemplate>
                                            <asp:Label ID="LblInvoiceNo" runat="server" Text='<%# Eval("[InvoiceNo]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Name Of The Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="LblNameOfTheCustomer" runat="server" Text='<%# Eval("[NameOfTheCustomer]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="LblInvoiceAmount" runat="server" Text='<%# Eval("[InvoiceAmount]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount Received">
                                        <ItemTemplate>
                                            <asp:Label ID="LblAmountReceived" runat="server" Text='<%# Eval("AmountReceived") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance For Collection">
                                        <ItemTemplate>
                                            <asp:Label ID="LblBalanceForCollectiont" runat="server" Text='<%# Eval("BalanceForCollection") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Credit Period">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCreditPeriod" runat="server" Text='<%# Eval("CreditPeriod") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Days">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDays" runat="server" Text='<%# Eval("[Days]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                 
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
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

