<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Workflow.aspx.cs" Inherits="Workflow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Home 
                      Page</h3>

                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <%--    <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Work Flow</h4>
                                        <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                        <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                        </div>
                   <table>
            <tr>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700; width: 5px;" 
                    class="style52" >
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td  class="style35" style=" text-align: center; ">
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td  class="style35" style=" text-align: center; ">
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td  class="style35" style=" text-align: center; ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700; width: 5px;" 
                    class="style52" >
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                        <img alt="" src="img/PIR.jpg"  style="width: 129px; height: 136px"/><br /> 
                     
                    <span class="style55"> 
                 
                    <span class="style62">
                    Purchase &nbsp; Order</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                      <img alt="" src="img/PI.jpg"  style="width: 129px; height: 136px"/><br /> 
                     
                    <span class="style55"> 
                 
                    <span class="style62">
                    Purchase  &nbsp; Invoice</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                      <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                       <img alt="" src="img/PO.jpg"  style="width: 129px; height: 136px"/><br /> 
                     
                    <span class="style55"> 
                 
                    <span class="style62">
                    Purchase/Inward  &nbsp; Register</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                      <img alt="" src="img/SO.jpg"  style="width: 129px; height: 136px"/><br /> 
                     
                    <span class="style55"> 
                 
                    <span class="style62">
                    Sales &nbsp; Order</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                          &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                    <img alt="" src="img/SMC.jpg"  style="width: 129px; height: 136px"/><br /> 
                    <span class="style55"> 
                 
                    <span class="style62">
                    Sales Manager&nbsp; Checking</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                    <img alt="" src="img/SR.jpg"  style="width: 129px; height: 136px"/><br />  
                    <span class="style55"> 
                 
                    <span class="style62">
                    Sales&nbsp; Register</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                      <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                       <img alt="" src="img/AR.jpg"  style="width: 129px; height: 136px"/><br /> 
                     
                    <span class="style55"> 
                 
                    <span class="style62">
                    Agewise&nbsp; Receivables</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>
                <td  class="style35" style=" text-align: center; ">
                    <img alt="" src="img/right-arrow.png" style="width: 45px; height: 7px" /></td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                  <a href="LoginSheetUpload.aspx">
                      <img alt="" src="img/DC.jpg"  style="width: 129px; height: 136px"/><br /> 
                     
                    <span class="style55"> 
                 
                    <span class="style62">
                    Delivery&nbsp; Challan</span></span></a><span class="style55"><a href="LoginSheetUpload.aspx" class="style2"><strong>
                    </strong>
                    </a> </span> </td>

                </span></a>
                </span>
                
                </span></a>
                
            </tr>
            <tr>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700; width: 5px;" 
                    class="style52" >
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td  class="style35" style=" text-align: center; ">
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td  class="style35" style=" text-align: center; ">
                    &nbsp;</td>
                <td    style=" text-align: center; color: #000000; font-family: Cambria; font-size: small; font-weight: 700;" 
                    class="style52" >
                    &nbsp;</td>
                <td  class="style35" style=" text-align: center; ">
                    &nbsp;</td>
            </tr>
            </table>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>--%>
            </div>
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Work Flow</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form action="#" class="form-horizontal">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <!-- BEGIN CUSTOM BUTTONS WITH ICONS PORTLET-->
                                        <br />

                                        <div id="divPurchse" runat="server">
                                            <strong>Purchase</strong>
                                            <br />
                                            <div class="row-fluid">
                                               <%-- <a href="PurchaseOrder.aspx" id="PO" runat="server" class="icon-btn span2">
                                                    <i class="icon-indent-right"></i>
                                                    <div>Purchase Order</div>                                                  
                                                </a>--%>
                                                 <a href="PurchaseRequsitionNote.aspx" id="PO" runat="server" class="icon-btn span2">
                                                    <i class="icon-indent-right"></i>
                                                    <div>Purchase Requisition Note (PRN)</div>                                                  
                                                </a>
                                                <a class="icon-btn span2" href="PurchaseManagerChecking.aspx" id="PCMw" runat="server">
                                                    <i class="icon-bullhorn"></i>
                                                    <div>Manager Checking</div>
                                                    <span class="badge badge-important">
                                                        <asp:Label ID="wrk_PO_check" runat="server" Text=""></asp:Label></span>
                                                </a>

                                                 <a href="GeneratePurchaseOrder.aspx" id="GPO" runat="server" class="icon-btn span2">
                                                    <i class="icon-indent-right"></i>
                                                    <div>Generate Purchase Order</div>                                                  
                                                </a>

                                                <a href="PurchaseOrderPDF.aspx" class="icon-btn span2" id="POPDF" runat="server">
                                                    <i class="icon-tags"></i>
                                                    <div>Purchase Order(PDF)</div>
                                                    <%--<span class="badge badge-important">2</span>--%>
                                                </a>

                                                <a href="GoodsRequisitionNote.aspx" id="GRN" runat="server" class="icon-btn span2">
                                                    <i class="icon-indent-right"></i>
                                                    <div>Goods Receipt Note</div>                                                  
                                                </a>
                                                 <a href="GRNPDF.aspx" id="GRNPDF" runat="server" class="icon-btn span2">
                                                    <i class="icon-indent-right"></i>
                                                    <div>Goods Receipt Note PDF</div>                                                  
                                                </a>

                                               
                                               <%-- <a href="PORejectedData.aspx" class="icon-btn span2" id="PORD" runat="server">
                                                    <i class="icon-barcode"></i>
                                                    <div>Purchase Order Rejected Data</div>
                                                    </a>--%>

                                                    <%-- <span class="badge badge-success">4</span>--%>
                                              
                                                <%-- <a href="PurchaseOrderInvoiceApproval.aspx" id="PINVA" class="icon-btn span2" runat="server">
                               <i class="icon-barcode"></i>
                               <div>Purchase Invoice Approval</div>
                              <%-- <span class="badge badge-success">4</span>
                           </a>--%>


                                                <%--   <a href="#" class="icon-btn span2">
                               <i class="icon-bar-chart"></i>
                               <div>Purchase/Inward Register</div>
                           </a>--%>
                                            </div><br />
                                            <div class="row-fluid">
                                                 <a href="TestPurchaseInvoice.aspx" class="icon-btn span2" id="POINV" runat="server">
                                                    <i class="icon-barcode"></i>
                                                    <div>Purchase Invoice</div>
                                                     </a>
                                                <a href="PORejectedData.aspx" class="icon-btn span2" id="PORD" runat="server">
                                                    <i class="icon-barcode"></i>
                                                    <div>Purchase Order Rejected Data</div>
                                                    </a>
                                            </div>
                                        </div>
                                        <br />
                                        <div id="divSales" runat="server">
                                            <strong>Sales</strong>
                                            <br />
                                            <div class="row-fluid">
                                                <a href="SalesOrder.aspx" class="icon-btn span2" id="SO" runat="server">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Sales Order</div>
                                                </a>
                                                <a class="icon-btn span2" href="SalesManagerChecking.aspx" id="SCMw" runat="server">
                                                    <i class="icon-check-empty"></i>
                                                    <div>Sales Manager Checking</div>
                                                    <span class="badge badge-important">
                                                        <asp:Label ID="wrk_SO_check" runat="server" Text=""></asp:Label></span>
                                                </a>

                                                <a href="SOInvoicePDF.aspx" class="icon-btn span2" id="SOTINV" runat="server">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Sales Tax Invoice</div>
                                                </a>

                                                 <a href="SORejectedData.aspx" class="icon-btn span2" id="SORD" runat="server">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Sales Order Rejected Data</div>
                                                </a> 

                                                 <a href="InvoiceCreditNote.aspx" class="icon-btn span2" id="SIC" runat="server">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Sales Invoice Credit Note</div>
                                                </a> 

                                                 <a href="SalesInvoiceCreditNotePDF.aspx" class="icon-btn span2" id="SICNPDF" runat="server">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Sales Invoice Credit Note(PDF)</div>
                                                </a> 

                                            </div>
                                        </div>
                                        

                                        <br />
                                        <div id="divBilling" runat="server">
                                            <strong>Billing</strong>
                                            <br />
                                            <div class="row-fluid">
                                                <a href="MaterialDispatch.aspx" class="icon-btn span2">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Material Dispatch</div>
                                                </a>

                                                <a href="InvoiceDispatch.aspx" class="icon-btn span2">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Invoice Dispatch</div>
                                                </a>

                                                <a href="AgewiseReceivables.aspx" class="icon-btn span2">
                                                    <i class="icon-bullhorn"></i>
                                                    <div>Agewise Receivables</div>
                                                    <%-- <span class="badge badge-important">3</span>--%>
                                                </a>

                                            </div>
                                        </div>
                                        <br />
                                       <%-- <div id="divReject" runat="server">
                                            <strong>Rejected PO/SO Data</strong>
                                            <br />
                                            <div class="row-fluid">
                                                <a href="PORejectedData.aspx" class="icon-btn span2" id="PORD" runat="server">
                                                    <i class="icon-barcode"></i>
                                                    <div>Purchase Order Rejected Data</div>
                                                    </a>
                                                <a href="SORejectedData.aspx" class="icon-btn span2" id="SORD" runat="server">
                                                    <i class="icon-sitemap"></i>
                                                    <div>Sales Order Rejected Data</div>
                                                </a>                                               

                                            </div>
                                        </div>
                                        <br />--%>

                                        <div id="divpurchaserpt" runat="server">
                                            <strong>Purchase-Reports</strong>
                                            <br />

                                            <div class="row-fluid">

                                                <a href="ReportPurchaseOrderRegister.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Purchase Order Register Report</div>
                                                    <%--  <span class="badge badge-info">221</span>--%>
                                                </a>
                                                <a href="ReportPurchaseRegister.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Purchase Register Report</div>
                                                </a>
                                                <a href="ReportOrdersPendingFromSupplier.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Orders Pending Supplier Report</div>
                                                </a>

                                                <a href="ReportDiscrepancyBetweenPOandSupplierInvocie.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Discrepancy Report</div>
                                                </a>
                                                <a href="PORejectedReport.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Purchase Order Reject Report</div>
                                                </a>
                                            </div>
                                            <br />

                                            <div class="row-fluid">
                                                 <a href="RptPurchaseOutStanding.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Purchase Order outstanding Report</div>
                                                </a>
                                                <a href="Rpt_GoodsReceived_BillPending.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>Purchase Bill Pending Report</div>
                                                </a>
                                                 <a href="SPAReport.aspx" class="icon-btn span2">
                                                    <i class="icon-columns"></i>
                                                    <div>SPA Report</div>
                                                </a>
                                             </div>

                                        </div>
                                        <br />
                                        <div id="divsalesrpt" runat="server">

                                            <strong>Sales-Reports</strong>
                                            <br />
                                            <div class="row-fluid">
                                                <a href="ReportSalesOrderRegister.aspx" class="icon-btn span2">
                                                    <i class="icon-money"></i>
                                                    <div>Sales Order Register Report</div>

                                                </a>
                                                <a href="ReportSalesRegister.aspx" class="icon-btn span2">
                                                    <i class="icon-leaf"></i>
                                                    <div>Sales Register Report</div>

                                                </a>


                                                <%--                           </div></div>
                      
             
                        <br />
                       <div id="divbillingrpt" runat="server">

                            <strong>Billing-Reports</strong> 
                            <br />
                             <div class="row-fluid">--%>

                                                <a href="ReportAR.aspx" class="icon-btn span2">
                                                    <i class="icon-thumbs-up"></i>
                                                    <div>AR(Agewise Receivables) Report</div>

                                                </a>
                                                <a href="ReportDeliveryChallan.aspx" class="icon-btn span2">
                                                    <i class="icon-align-center"></i>
                                                    <div>Delivery Challan Report</div>

                                                </a>
                                                <a href="SORejectedReport.aspx" class="icon-btn span2">
                                                    <i class="icon-align-center"></i>
                                                    <div>Sales Order Reject Report</div>
                                                </a>
                                            </div>
                                            <br />
                                             <div class="row-fluid">
                                                  <a href="Rpt_SalesOutstanding.aspx" class="icon-btn span2">
                                                    <i class="icon-align-center"></i>
                                                    <div>Sales Order Outstanding Report</div>

                                                </a>
                                              
                                             </div>
                                        </div>
                                        <br />
                                        <div id="divSTRPT" runat="server">
                                            <strong>Stock Report</strong>
                                            <br />
                                            <div class="row-fluid">
                                                <%-- <a href="" class="icon-btn span2">
                               <i class="icon-cloud"></i>
                               <div>Statutoy Form Report</div>
                              <%-- <span class="badge badge-important">2</span></a>--%>
                                                <a href="ReportStockStatement.aspx" class="icon-btn span2">
                                                    <i class="icon-globe"></i>
                                                    <div>Stock Statement Report</div>
                                                </a>
                                                  <a href="RptReorderLevel.aspx" class="icon-btn span2">
                                                    <i class="icon-align-center"></i>
                                                    <div>Re-Order Level Report</div>
                                                </a>
                                                  <a href="RptConsolidatedStock.aspx" class="icon-btn span2">
                                                    <i class="icon-align-center"></i>
                                                    <div>Consolidate Stock Report</div>
                                                </a>
                                            </div>
                                        </div>

                                        <!-- END CUSTOM BUTTONS WITH ICONS PORTLET-->
                                    </div>
                                    <span class="space20">&nbsp;</span>
                                </div>
                            </form>
                            <!-- END FORM-->
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

