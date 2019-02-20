<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SalesInvoiceCreditNotePDF.aspx.cs" Inherits="SalesInvoiceCreditNotePDF" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type= "text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("[id$='_ddlSONumber']").customselect();
            });
        });

 </script>

    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Sales
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>
                            <a href="#">Sales</a><span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="SOInvoicePDF.aspx">Sales Invoice Credit Note(PDF)</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Sales Invoice Credit Note(PDF)</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">

                            <!-- BEGIN FORM-->
                            <form action="#" class="form-horizontal">

                                
                                <table width="30%">
                                    <tr>
                                        <td style="width:10%"> Sales Invoice Number:-
                                        </td>
                                        <td style="width:10%">
                                            <asp:DropDownList ID="ddlSONumber" runat="server" AppendDataBoundItems="true" name='standard' CssClass="custom-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:10%" align="left">
                                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
                                        </td>
                                    </tr>
                                </table>

                             <%--   SO Number:-
                                    <asp:DropDownList ID="ddlSONumber" runat="server" AppendDataBoundItems="true" CssClass="custom-select">       
                                    </asp:DropDownList>
                                <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />--%>
                                <style type="text/css">
                                    .style1 {
                                        width: 100%;
                                    }

                                    .style4 {
                                        width: 999px;
                                    }

                                    .style5 {
                                        width: 918px;
                                    }

                                    .style16 {
                                        color: #FFFFFF;
                                        width: 1066px;
                                    }

                                    .style7 {
                                        font-size: x-large;
                                        font-family: "Comic Sans MS";
                                        width: 792px;
                                    }

                                    .style21 {
                                        width: 35px;
                                    }

                                    .logotxt {
                                        color: #666;
                                        font-size: 9px;
                                        position: relative;
                                        top: -50px;
                                    }

                                    .img-responsive, .thumbnail > img, .thumbnail a > img, .carousel-inner > .item > img, .carousel-inner > .item > a > img {
                                        display: block;
                                        max-width: 100%;
                                        height: auto;
                                    }
                                </style>



                                <asp:Panel ID="Panel1" Width="80px" runat="server">
                                  
                                    <br />                                   
                                    <div style="width: 76%; border:thin" id="divexcel" runat="server">
                                        &nbsp;&nbsp;
                                    <%-- <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;">
                                         <tr>
                                             <td align="left">
                                                 <img src="images/logo_tagline.png" class="img-responsive" title="Centillion" alt="Centillion Logo" />                                     
                                             </td>
                                             <td align="left">
                                                 <span style="font-size: 11; font-family: Times New Roman; font-weight: 900">Centillion Solutions and Services Private Limited </span>

                                             </td>
                                         </tr>
                                     </table>--%>
                                        <table border="1">
                                            <tr style="height: 20px">
                                                <td align="center" colspan="2">
                                                    <span style="font-size: 11; font-family: Times New Roman; font-weight: 1000">CREDIT NOTE</span>
                                                </td>
                                            </tr>
                                        </table>
        
                                       
                                        <br /> 
                                         <table style="width: 100%; border:1" id="TabScanner" runat="server" visible="true">                                            
                                            <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblInvno" Text="Invoice No :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                  <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHCustPoNum" Text="Customer PO No :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                <td>
                                                                                 
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblCustPoNum" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>   
                                                                                        
                                                
                                            </tr>
                                                <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="Label1" Text="Invoice Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td>
                                                     <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHCustPOdate" Text="Customer PO Date :" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblCustPOdate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>                                               
                                            </tr>
                                              <tr>
                                                   <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHReverseCharge" Text="Reverse Charge (Y/N) :" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td>
                                                   <td>                                                  
                                                    <span style="font-size:9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblReverseCharge" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td>
                                                  <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHTransportMode" Text="Transport Mode :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                <td>
                                                                                 
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblTransportMode" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>    
                                                                                                                                      
                                            </tr>

                                               <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHGSTIN" Text="GSTIN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblGSTIN" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>

                                                    <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHDCNum" Text="DC number :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblDCNum" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td>
                                               
                                                
                                            </tr>

                                             <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHSate" Text="State :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>                                                
                                                     <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblSate" runat="server"></asp:Label>
                                                    </span>
                                                       <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">-</span>
                                                      <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter"> Code:</span>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                       <asp:Label ID="lblStatecode" runat="server"></asp:Label>    
                                                       </span>                                               
                                                    </td>
                                                   <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHDateofSupply" Text="Date of Supply :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>                                                                                                      
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblDateofSupply" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>       

                                            </tr>  
                                             <tr>
                                                <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHPaymentterm" Text="Payment Terms  :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>                                                                                                      
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblPaymentterm" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td>  
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHPlaceofSupply" Text="Place of Supply :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>                                                
                                                     <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblPlaceofSupply" runat="server"></asp:Label>
                                                    </span>
                                                       <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">-</span>
                                                       <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter"> Code: </span>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                       <asp:Label ID="lblSupplyCode" runat="server"></asp:Label> 
                                                       </span>                                                  
                                                    </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHWarrenty" Text="Warranty/Period :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>                                                                                                      
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblWarrenty" runat="server"></asp:Label>
                                                    </span>                                                   
                                                    </td> 
                                                
                                                  <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblHNatureofSupply" Text="" runat="server"></asp:Label>
                                                    </span>
                                                    </td>
                                                   <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblNatureofSupply" runat="server"></asp:Label>
                                                    </span>
                                                    </td>
                                             </tr>
                                                                                       
                                             <tr>
                                                 <td></td>
                                                 <td></td>
                                             </tr>

                                        </table>                                  
                                        <br />
                                         <table style="width: 100%" border="1" >                                            
                                            <tr>
                                                <td> <span style="font-size:9; font-family: Times New Roman;">
                                                     <b>Bill To Party:</b>
                                                     </span>
                                                    </td>
                                                <td>
                                                    <span style="font-size:9; font-family: Times New Roman;">
                                                   <b> Ship To Party:</b>
                                                     </span>
                                                 </td>
                                            </tr>
                                             <tr>                                                 
                                                <td>
                                                     <%--<table>
                                                       <tr>
                                                            <td colspan="2">--%>
                                                                <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">Name:
                                                                    <asp:Label ID="LblBilName" runat="server"></asp:Label>
                                                                </span><br />
                                                           <%-- </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">--%>
                                                                <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">Address:<asp:Label ID="lbl_Bill_Address" runat="server"></asp:Label>
                                                                </span><br /><br />
                                                            <%--</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">--%>
                                                                <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">GSTIN:<asp:Label ID="lblBilGSTIN" runat="server"></asp:Label>
                                                                </span><br />
                                                          <%--  </td>
                                                        </tr>
                                                         <tr>
                                                            <td>--%>
                                                    <table border="0">
                                                        <tr>
                                                            <td>
                                                                <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">State:<asp:Label ID="lblBilState" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                 <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">Code:<asp:Label ID="lblBilStateCode" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>                                                                
                                                     
                                                            <%--</td>
                                                             <td>--%>
                                                                
                                                             <%--</td>
                                                        </tr>
                                                    </table> --%>                                                   
                                                </td>
                                                <td>
                                                    <%-- <table>
                                                         <tr>
                                                             <td colspan="2">--%>
                                                                 <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">Name: <asp:Label ID="lblShipName" runat="server"></asp:Label></span><br />
                                                           <%--  </td>
                                                         </tr>
                                                        <tr>
                                                            <td colspan="2">--%>
                                                                <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">Address: <asp:Label ID="lbl_Ship_Address" runat="server"></asp:Label>
                                                                </span><br /><br />
                                                          <%--  </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">--%>
                                                                <%--<span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">GSTIN:<asp:Label ID="lblShipGSTIN" runat="server"></asp:Label>
                                                                </span>--%><br />
                                                          <%--  </td>
                                                        </tr>
                                                         <tr>
                                                            <td>--%>
                                                   <%-- <table border="0">
                                                        <tr>
                                                            <td>
                                                                 <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">State: <asp:Label ID="lblShipState" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                 <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">Code: <asp:Label ID="lblShipStateCode" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>  --%>                                                             
                                                            <%--</td>
                                                             <td>--%>
                                                               
                                                            <%-- </td>
                                                        </tr>
                                                    </table>  --%>                                                
                                                </td>
                                           </tr>
                                        </table>
                                       
                                        <br />
                                       <%-- OnRowCreated="grvMergeHeader_RowCreated" OnRowDataBound="GvSalesInvcDet_RowDataBound"--%>
                                        <asp:GridView ID="GvSalesInvcDet" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GvSalesInvcDet_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product Description">
                                                    <ItemTemplate>
                                                         <asp:Label ID="LblProductDescr" runat="server" align="center" Text='<%#Eval("Description")%>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text="" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80%" />
                                                    <HeaderStyle Width="80%" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="HSN code">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblHSNcode" runat="server" align="center" Text='<%#Eval("HSN_SAC_NUM")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="UOM" Visible="false">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblUOM" runat="server" align="center" Text='<%#Eval("UOM")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblQTY" runat="server" align="center" Text='<%#Eval("QTY")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Rate">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblRate" runat="server" align="center" Text='<%#Eval("Rate")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblAmount" runat="server" align="center" Text='<%#Eval("Amount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Discount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblDiscount" runat="server" align="center" Text='<%#Eval("Discount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Taxable Value">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblTaxableValue" runat="server" align="center" Text='<%#Eval("TaxableValue")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                              
                                                  <asp:TemplateField HeaderText="CGST Rate">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblCGSTRate" runat="server" align="center" Text='<%#Eval("CGST")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="CGST Amount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblCGSTAmount" runat="server" align="center" Text='<%#Eval("SO_CGST_TaxAmount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                
                                                  <asp:TemplateField HeaderText="SGST Rate">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblSGSTRate" runat="server" align="center" Text='<%#Eval("SGST")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="SGST Amount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblSGSTAmount" runat="server" align="center" Text='<%#Eval("SO_SGST_TaxAmount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                              <%-- <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                <asp:Label ID="lblH1CGST" runat="server" Text="CGST"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Rate
                                                                </td>
                                                                <td>
                                                                    Amount
                                                                </td>
                                                            </tr>

                                                        </table>                                                 
                                                   </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <td>
                                                            <asp:Label ID="lblCGSTRate" runat="server" Text='<%#Eval("CGST")%>'></asp:Label>
                                                        </td>
                                                         <td>
                                                            <asp:Label ID="lblCGSTAmount" runat="server" Text='<%#Eval("SO_CGST_TaxAmount")%>'></asp:Label>
                                                        </td>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                               <%--  <asp:TemplateField>
                                                    <HeaderTemplate>
                                                    <th colspan="2">SGST</th>
                                                      <tr>
                                                          <th>Rate</th>
                                                           <th>Amount</th>
                                                      </tr>
                                                   </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <td>
                                                            <asp:Label ID="lblSGSTRate" runat="server" Text='<%#Eval("SGST")%>'></asp:Label>
                                                        </td>
                                                         <td>
                                                            <asp:Label ID="lblSGSTAmount" runat="server" Text='<%#Eval("SO_SGST_TaxAmount")%>'></asp:Label>
                                                        </td>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Total">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("SO_TotalAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                                                             
                                         <asp:GridView ID="GVSalesInvcDetIGST" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GVSalesInvcDetIGST_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product Description">
                                                    <ItemTemplate>
                                                         <asp:Label ID="LblProductDescr" runat="server" align="center" Text='<%#Eval("Description")%>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text="" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80%" />
                                                    <HeaderStyle Width="80%" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="HSN code">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblHSNcode" runat="server" align="center" Text='<%#Eval("HSN_SAC_NUM")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="UOM" Visible="false">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblUOM" runat="server" align="center" Text='<%#Eval("UOM")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblQTY" runat="server" align="center" Text='<%#Eval("QTY")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Rate">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblRate" runat="server" align="center" Text='<%#Eval("Rate")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblAmount" runat="server" align="center" Text='<%#Eval("Amount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Discount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblDiscount" runat="server" align="center" Text='<%#Eval("Discount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Taxable Value">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblTaxableValue" runat="server" align="center" Text='<%#Eval("TaxableValue")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                              
                                                  <asp:TemplateField HeaderText="IGST Rate">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblIGSTRate" runat="server" align="center" Text='<%#Eval("IGST")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="IGST Amount">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblIGSTAmount" runat="server" align="center" Text='<%#Eval("SO_IGST_TaxAmount")%>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                               
                                                <asp:TemplateField HeaderText="Total">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("SO_TotalAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                                                                    
                                           
                                        <table id="TblCgst" runat="server" border="1">
                                           <tr>
                                                <td style="width:75%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblHTotalinrs" runat="server" Text="Total Invoice amount in words"></asp:Label>
                                                </span></td>
                                               <td style="width:15%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblHAmountbeforeTax" runat="server" Text="Total Amount before Tax" ></asp:Label>
                                                </span></td>
                                               <td style="width:10%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblAmountbeforeTax" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>                                           
                                            <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblTotalinrs" runat="server" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblHCGST" runat="server" Text="Add: CGST 9%" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblCGST" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>
                                            <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label4" runat="server" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblHSGST" runat="server" Text="Add: SGST 9%" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblSGST" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>
                                            <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label5" runat="server" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" ><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblHTotalTaxAmnt" runat="server" Text="Total Tax Amount" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblTotalTaxAmnt" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>
                                            <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label2" runat="server" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblHTotalAmntafterTax" runat="server" Text="Total Amount after Tax:" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblTotalAmntafterTax" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>
                                       
                                            </table>
                                        
                                        <table id="tblIGST" runat="server" border="1">
                                           <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label6" runat="server" Text="Total Invoice amount in words"></asp:Label>
                                                </span></td>
                                               <td style="width:25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label7" runat="server" Text="Total Amount before Tax" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label10" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>                                           
                                            <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblTotalinrs1" runat="server" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label12" runat="server" Text="Add: IGST 18%" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label13" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>                                            
                                            <tr>
                                                <td style="width:50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label14" runat="server" ></asp:Label>
                                                </span></td>
                                               <td style="width:25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label15" runat="server" Text="Total Amount after Tax:" ></asp:Label>
                                                </span>
                                               </td>
                                               <td style="width:25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label16" runat="server" ></asp:Label>
                                                </span></td>
                                           </tr>
                                       
                                            </table>

                                            <table border="1">
                                                <tr>
                                                    <td><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="Label11" runat="server" Text="Bank Details"></asp:Label>
                                                    </span>
                                                    </td>  
                                                    <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="Label17" runat="server" Text="GST on Reverse Charge"></asp:Label>
                                                    </span>
                                                    </td>
                                                    <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="LblReverseChargevalue" runat="server"></asp:Label>
                                                    </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td  colspan="2"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="Label18" runat="server" Text="Name : Centillion Solutions & Services Pvt Ltd"></asp:Label>
                                                    </span>
                                                    </td>
                                                    <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                            <asp:Label ID="Label19" runat="server" Text="Ceritified that the particulars given above are true and correct"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="2"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="Label20" runat="server" Text="Bank A/c No : 913020013227679"></asp:Label>
                                                    </span>
                                                    </td>
                                                    <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                            <asp:Label ID="Label21" runat="server" Text="For Centillion Solutions & Services Pvt Ltd"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                </table>
                                                <table border="1">
                                                  <%--  <tr>
                                                        <td>
                                                            <table border="0">--%>
                                                                <tr>
                                                                    <td><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                                        <asp:Label ID="Label22" runat="server" Text="Bank IFSC: UTIB0000052"></asp:Label>
                                                                    </span>
                                                                    </td>   
                                                                    <td></td>                                                                
                                                                </tr>
                                                                <tr>
                                                                    <td><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                                        <asp:Label ID="Label24" runat="server" Text="Bank Branch: Jayanagar, Bangalore (KT), Bangalore - 560041"></asp:Label>
                                                                    </span>
                                                                    </td>
                                                                     <td></td>   
                                                                </tr>
                                                    <tr>
                                                    <td align="center"><span style="font-size: 10; font-family: Times New Roman; font-weight:bold">
                                                        <asp:Label ID="Label26" runat="server" Text="Terms & conditions">  </asp:Label></span><br />  
                                                        <span style="font-size: 8; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lblcondition" runat="server" Text="The Kodak Alaris Terms and Conditions which are available at https://legal.kodakalaris.com/en-us/business-to-business-terms-and-conditions (“Terms”) are 
                                                            incorporated by reference and shall apply to all products and/or services supplied by Kodak Alaris to you unless and to the extent that separate terms have 
                                                            been expressly agreed to in writing and signed by Kodak Alaris. By proceeding with your purchase, you confirm reading, understanding and acceptance of the relevant Terms. "></asp:Label>
                                                      </span>
                                                  
                                                    </td>
                                                        <td rowspan="3">
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                            <asp:Label ID="Label25" runat="server" Text="This is an electronically generated Invoice and needs no signature" ></asp:Label>
                                                        </span>
                                                        </td>
                                                      </tr>
                                               
                                                    <%--<td >
                                                        <span style="font-size: 10; font-family: Times New Roman; font-weight: lighter">
                                                            <asp:Label ID="Label27" runat="server"></asp:Label>
                                                        </span>
                                                    </td>--%>
                                               <%-- </tr>
                                                            </table>
                                                        </td>--%>
                                                        
                                                  
                                                
                                            </table>

                                        
                                       <%-- <table border="1">
                                            <tr>
                                                <td><span style="font-size: 10; font-family: Times New Roman; font-weight: bold">
                                                    <asp:Label ID="Label29" runat="server" Text="Note: Materials will be dispatched from our Kamothe warehouse"></asp:Label>
                                                </span></td>
                                            </tr>

                                        </table>--%>

                                     <%--   <table border="1">
                                            <tr>
                                                <td><span style="font-size: 11; font-family: Times New Roman; font-weight: bold">
                                                    <asp:Label ID="Label3" runat="server" Text="Declaration"></asp:Label>
                                                </span></td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td><span style="font-size: 8; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="Label8" runat="server" Text="We declare that our registration certificate under the Maharashtra Value Added Tax, 2002, is in force on the date on which sale of goods specified is made by us and that transaction of sales covered by tax invoice has been effected by us and it shall be accounted for in turnover of sales while filing return and the due tax if any payable on the sale has been paid / shall be paid."></asp:Label>
                                                </span></td>
                                                <td>
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="Label9" runat="server" Text="This is an electronically generated Invoice and needs no signature"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td align="center">
                                                    <span style="font-size: 9; font-family: Times New Roman;">Please issue a cheque in favor of
                                                   <br />
                                                        <b>"Centillion Solutions and Services Private Limited"</b>
                                                        <br />
                                                        OR
                                                    <br />
                                                        Transfer the Fund to<br />
                                                        <br />

                                                        <b>Axis Bank Ltd.
                                                     <br />
                                                            Jayanagar, Bangalore (KT), Bangalore - 560041
                                                   <br />
                                                            Current A/c No.913020013227679
                                                  <br />

                                                            IFS Code: UTIB0000052</b>
                                                    </span>
                                                </td>

                                                <td align="left">

                                                    <span style="font-size: 10; font-family: Times New Roman;">
                                                        <b>STATUTORY REGISTRATION NUMBERS</b><br />

                                                        <br />
                                                        PAN: AACCC9440P
    <br />
                                                        VAT: 27760972828V
    <br />
                                                        CST: 27760972828C
    <br />
                                                        Service Tax: AACCC9440PST001
        <br />
                                                        Service Tax Category:Maintenance or
    <br />
                                                        Repairs;BusinessAuxiliary;Business Support Service
    <br />
                                                        Corporate Identity Number:U72400KA2006PTC039877
                                                    </span>

                                                </td>
                                            </tr>
                                        </table>--%>
                                        <br />
                                      <%--  <table border="1">
                                              <tr>
                                                  <td align="center">
                                                        <span style="font-size:11; font-family: Times New Roman;"">
                                                       <b> Centillion Solutions and Services Private Limited</b>
                                                        </span><br /><span style="font-size:9; font-family: Times New Roman;""><b>Contact Address: </b>A 1111 - 1116, Kailash Business Park, Hiranandani Link Road, Park site, Vikhroli West, Mumbai - 400 079.                                                
                                                           </span><br />
                                                      <span style="font-size:9; font-family: Times New Roman;"">
                                                    Phone: +91-: 022-25197700 :: Fax: +91-22-40085915 :: www.centillioncosmos.com.
                                                        </span><br />
                                                      <span style="font-size:9; font-family: Times New Roman;"">
                                                    <b>Warehouse: </b>Kailash Towers CHS, Shop No.14, Plot No.60,61 & 62, Sector 35, Kamothe - 410209.
                                                       </span><br />
                                                      <span style="font-size:9; font-family: Times New Roman;"">
                                                    <b>Registered Office:  </b> No 354, 1st Floor, 14th Cross, Indira Nagar, Bengaluru 560038. 
                                                    </span><br /> <span style="font-size:9; font-family: Times New Roman;"">
                                                    Phone: +91-80-22489260, +91-80-66960400 . Dir: +91-80-66960410.
                                                   </span><br /><br />
                                                      <span style="font-size:9; font-family: Times New Roman;""> <b>SUBJECT TO MUMBAI (INDIA) JURISDICTION</b></span>
                                                 </td>
                                              </tr>
                                               
                                        </table> --%>
                                    </div>
                                    
                                </asp:Panel>
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

