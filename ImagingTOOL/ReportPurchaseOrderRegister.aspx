<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ReportPurchaseOrderRegister.aspx.cs" Inherits="ReportPurchaseOrderRegister" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
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
                       
                    <li> <a href="ReportSalesOrderRegister.aspx">Purchase Order Register</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Purchase Order Register Report</h4>
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
                                        Purchase Order Details</td>
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
                           <%-- <table style="width: 100%">
                                <tr>
                                    <td colspan="2">
                                        Purchase Order Summary</td>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 227px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 79px; height: 30px;">
                                        From Date</td>
                                    <td style="width: 219px; height: 30px;">
                                        <asp:TextBox ID="TxtFromDate0" runat="server"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar3" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtFromDate0"></rjs:PopCalendar>
                                            
                                    </td>
                                    <td style="width: 64px; height: 30px;">
                                        To Date</td>
                                    <td style="width: 227px; height: 30px;">
                                        <asp:TextBox ID="TxtToDate0" runat="server"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar4" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtToDate0"></rjs:PopCalendar>
                                            
                                    </td>
                                    <td style="height: 30px">
                                        <asp:Button ID="BtnExportSummary" runat="server" Text="Export" 
                                            onclick="BtnExportSummary_Click1"/>
                                    </td>
                                    <td style="height: 30px">
                                        </td>
                                </tr>
                            </table>
                            <br />--%>
                           <%-- <asp:GridView ID="GvwSalesOrder" runat="server" AutoGenerateColumns="False" 
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
                                            <asp:Label ID="LblSO_Date" runat="server" Text='<%# Eval("[PO_Date]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SO Number">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_Number" runat="server" Text='<%# Eval("PO_Number") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    
                                   
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Supplier">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTax" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_Amount" runat="server" Text='<%# Eval("[PO_Amount]]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_TaxAmount" runat="server" Text='<%# Eval("[PO_TaxAmount]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_NetAmount" runat="server" Text='<%# Eval("[PO_NetAmount]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entered By">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblenteredby" runat="server" Text='<%# Eval("[PO_EnteredOn]") %>'></asp:Label>
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
                            </asp:GridView>--%>
                          <%--  <asp:GridView ID="GvwSalesOrdeSummary" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                                BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno0" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Po No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsonumber" runat="server" Text='<%# Eval("ponumber") %>'></asp:Label>
                                           
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="PO Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_Date" runat="server" Text='<%# Eval("[PO_Date]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="category">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblcategory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_UnitPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("[PO_Quantity]") %>'></asp:Label>
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
                            </asp:GridView>--%>
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

