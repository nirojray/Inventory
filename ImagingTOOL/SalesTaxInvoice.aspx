<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="SalesTaxInvoice.aspx.cs" Inherits="SalesTaxInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

          <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type= "text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />

	<script type="text/javascript">
 $(document).ready(function() {
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

                        <li><a href="SalesTaxInvoice.aspx">Sales Tax Invoice(PDF)</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Sales Tax Invoice(PDF)</h4>
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
                                        <td style="width:10%"> SO Number:-
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
                                </style>



                                <asp:Panel ID="Panel1" Width="80px" runat="server">
                                  
                                    <br />
                                     
                                    <div style="width: 76%; border:thin" id="divexcel" runat="server">
                                        &nbsp;&nbsp;
         <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;" >
             <tr>
                 <td align="left">
                   <img src="images/logo_tagline.png" class="img-responsive" title="Centillion" alt="Centillion Logo"/>
                   <%--  <img src="images/logo.jpg">--%>
                     <%--<span class="logotxt">Strategic Partnership to Engage and Enhance Delivery</span>--%>
                 </td>
                 <td  align="left">
                        <span style="font-size: 11; font-family: Times New Roman; font-weight: 900"> Centillion Solutions and Services Private Limited </span>
                     
                 </td>
             </tr>
              </table>
                                          <table border="1">
             <tr style="height: 20px">
                 <td align="center" colspan="2">
                     <span style="font-size: 11; font-family: Times New Roman; font-weight: 900">TAX INVOICE</span>
                 </td>
             </tr>
                                              </table>
        
                                       
                                        <br /> 
                                         <table style="width: 100%" id="TabScanner" runat="server" visible="false">                                            
                                            <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblInvno" Text="Invoice No :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                  <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label4" Text="PO/Contract no :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                <td>
                                                                                 
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblCustomerNo" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                                <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label1" Text="Invoice Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label7" Text="PO/Contract Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblCustomerdate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label6" Text="Delivery Challan No :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblDCno" runat="server" Visible="false"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label11" Text="Credit Period :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblCreditPrediod" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>

                                               <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label2" Text="Delivery Challan Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblDCDate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label5" Text="Warranty :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblWarranty" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>

                                             <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label18" Text="Customer VAT/CST/TIN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblCustVAT" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label23" Text="Customer PAN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblCustPan" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label20" Text="Customer Service Tax NO :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblCustSerTax" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>
                                                   
                                                   
                                                    </td>
                                                   <td>                                                  
                                                   
                                                   
                                                    </td>
                                                
                                            </tr>


                                        </table>
                                        <table style="width: 100%" id="TabService" runat="server" visible="false">                                            
                                            <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label10" Text="Invoice No :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                  <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerInvoiceNo" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label13" Text="PO/Contract no :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                <td>
                                                                                 
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerCustomerNo" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                                <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label15" Text="Invoice Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerInvoiceDate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label17" Text="PO/Contract Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerContractDate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                               
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label21" Text="Credit Period :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerCreditPeriod" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                  <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label25" Text="Customer VAT/CST/TIN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerCustVAT" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                               
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label27" Text="Customer PAN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerCustPAN" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label30" Text="Customer Service Tax NO :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSerCustSerTax" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                             
</table>
                                         <table style="width: 100%" id="TabSupport" runat="server" visible="false">                                            
                                            <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label12" Text="Invoice No :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                  <td>
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupInvocieNO" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label16" Text="PO/Contract no :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                <td>
                                                                                 
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupCustomerNo" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                                <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label19" Text="Invoice Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupInvoicedate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label22" Text="PO/Contract Date :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupContractDate" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                               
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label24" Text="Credit Period / Term :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupCreditPeriod" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                  <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label14" Text="Warranty / AMC Period :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupWarranty" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label26" Text="Customer VAT/CST/TIN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupVAT" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label31" Text="Customer PAN :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                  
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupPAN" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                
                                            </tr>
                                              <tr>
                                                <td>

                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="Label33" Text="Customer Service Tax NO :" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                   <td>

                                                
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">
                                                        <asp:Label ID="lblSupSerTax" runat="server"></asp:Label>
                                                    </span>
                                                   
                                                    </td>
                                                 <td>
                                                   
                                                   
                                                    </td>
                                                   <td>                                                  
                                                   
                                                   
                                                    </td>
                                                
                                            </tr>
</table>
                                       
                                             <br />
                                         <table style="width: 100%" border="1">                                            
                                            <tr>
                                                <td> <span style="font-size:11; font-family: Times New Roman;">
                                                     <b>Bill To:</b>
                                                     </span>
                                                    </td>
                                                <td>
                                                    <span style="font-size:11; font-family: Times New Roman;">
                                                   <b> Ship To:</b>
                                                     </span>
                                                 </td>
                                            </tr><tr>
                                                <td>
                                                    <span style="font-size:9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lbl_Bill_Address" runat="server"></asp:Label>
                                                    </span>

                                                </td>
                                                <td>
                                                    <span style="font-size:9; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lbl_Ship_Address" runat="server"></asp:Label>
                                                    </span></td>
                                           </tr>
                                        </table>
                                       
                                        <br />
                                         <%-- <table>
                                               <tr>
                 <td>--%>
                                        <asp:GridView ID="GvwSaleseOrderDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                            DataKeyNames="SO_ID" OnDataBound="GvwSaleseOrderDetails_DataBound"
                                            ShowHeaderWhenEmpty="True" OnRowDataBound="GvwSaleseOrderDetails_RowDataBound" Font-Bold="True" Font-Size="Medium">
                                            <Columns>

                                                <asp:TemplateField HeaderText="NO." HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSlno" runat="server" Text='<%# Eval("Sr No") %>'></asp:Label>                                                       
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="5px" />
                                                    <ItemStyle Width="5px" />
                                                   <%-- <HeaderStyle Width="10%" /><ItemStyle Width="10%" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server" align="center" Text='<%# Eval("Description") %>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[SO_ID]") %>' Visible="false"></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                   <%-- <HeaderStyle HorizontalAlign="Center" Width="1000px" />--%>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Part No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProductCode" runat="server" align="center" Text='<%#Bind("Product_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                              
                                                 <asp:TemplateField HeaderText="Unit Price (INR)" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" align="center" Text='<%#Bind("SO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="QTY" HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" align="Center" Width="10px" Text='<%# Eval("QTY") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <%-- <HeaderStyle HorizontalAlign="Center" Width="10px" />--%>
                                                </asp:TemplateField>                                               
                                                 
                                                <asp:TemplateField HeaderText="Amount (INR)" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblAmount" runat="server" align="right" Text='<%# Eval("SO_TotalPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                            </Columns>
                                            <HeaderStyle Font-Bold="True" Font-Size="Large" />
                                        </asp:GridView>
                                             <br />
                                  <table>
                                      <tr>
                                          <td><span style="font-size:11; font-family: Times New Roman; font-weight:bold">
                                                        <asp:Label ID="lblTotalinrs" runat="server" Text="Total Amount:"></asp:Label>
                                                    </span></td>
                                      </tr>

                                  </table>
                                        <table border="1">
                                      <tr>
                                          <td><span style="font-size:10; font-family: Times New Roman; font-weight:bold">
                                                        <asp:Label ID="Label29" runat="server" Text="Note: Materials will be dispatched from our Kamothe warehouse"></asp:Label>
                                                    </span></td>
                                      </tr>

                                  </table>

                                         <table border="1">
                                      <tr>
                                           <td><span style="font-size:11; font-family: Times New Roman; font-weight:bold">
                                                        <asp:Label ID="Label3" runat="server" Text="Declaration"></asp:Label>
                                                    </span></td>
                                          <td>

                                          </td>
                                          </tr>

                                               <tr>
                                           <td><span style="font-size:8; font-family: Times New Roman; font-weight:lighter">
                                                        <asp:Label ID="Label8" runat="server" Text="We declare that our registration certificate under the Maharashtra Value Added Tax, 2002, is in force on the date on which sale of goods specified is made by us and that transaction of sales covered by tax invoice has been effected by us and it shall be accounted for in turnover of sales while filing return and the due tax if any payable on the sale has been paid / shall be paid."></asp:Label>
                                                    </span></td>
                                          <td>
<span style="font-size:9; font-family: Times New Roman; font-weight:lighter">
                                                        <asp:Label ID="Label9" runat="server" Text="This is an electronically generated Invoice and needs no signature"></asp:Label>
                                                    </span>
                                          </td>
                                          </tr>

                                             
                                               <tr>
                                           <td align="center">
                                              <span style="font-size:9; font-family: Times New Roman;">
                                                       Please issue a cheque in favor of
                                                   <br /> <b>"Centillion Solutions and Services Private Limited"</b>
                                                   <br /> 
                                                        OR
                                                    <br />
                                                        Transfer the Fund to<br />
                                                           <br />
                                                           
                                                                <b>
                                                        Axis Bank Ltd.
                                                     <br />
                                                       Jayanagar, Bangalore (KT), Bangalore - 560041
                                                   <br />
                                                       Current A/c No.913020013227679
                                                  <br />
                                                           
                                                        IFS Code: UTIB0000052</b>
                                                    </span>
                                         </td>
                                                   
                                                      <td align="left">
                                                      
<span style="font-size:10; font-family: Times New Roman;">
                                                        <b>STATUTORY REGISTRATION NUMBERS</b><br />
                                                   
                                                     <br />PAN: AACCC9440P
    <br />VAT: 27760972828V
    <br />CST: 27760972828C
    <br />Service Tax: AACCC9440PST001
        <br />Service Tax Category:Maintenance or
    <br />Repairs;BusinessAuxiliary;Business Support Service
    <br />Corporate Identity Number:U72400KA2006PTC039877
                                                    </span>
                                                         
                                          </td>
                                          </tr>
                                             </table> 
                                          <table border="1">
                                              <tr>
                                                  <td align="center">
<span style="font-size:11; font-family: Times New Roman;"">
   <b> Centillion Solutions and Services Private Limited</b>
    </span><br /><span style="font-size:9; font-family: Times New Roman;"">
                                                    <b>Contact Address: </b>A 1111 - 1116, Kailash Business Park, Hiranandani Link Road, Park site, Vikhroli West, Mumbai - 400 079.                                                
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
                                                      <span style="font-size:9; font-family: Times New Roman;"">
                                                    <b>SUBJECT TO RAIGAD (INDIA) JURISDICTION</b>
                         </span>
                                                          </td>
                                              </tr>
                                               
                                              </table> 
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

