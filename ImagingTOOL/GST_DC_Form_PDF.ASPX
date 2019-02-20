<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="GST_DC_Form_PDF.aspx.cs" Inherits="GST_DC_Form_PDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("[id$='_ddlGSTnumber']").customselect();
            });
        });

    </script>


    <%--body content starts --%>

    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">GST</h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>
                            <a href="#">GST</a><span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="GST_Delivery_Challan.aspx">GST Delivery Challan</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>GST Delivery Challan</h4>
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
                                        <td style="width: 10%">GST DC Number:-
                                        </td>
                                        <td style="width: 10%">
                                            <asp:DropDownList ID="ddlGSTnumber" runat="server" AppendDataBoundItems="true" name='standard' CssClass="custom-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%" align="left">
                                            <asp:Button ID="btnExport_GST" runat="server" Text="Export" OnClick="btnExport_GST_Click" />
                                        </td>
                                    </tr>
                                </table>
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

                                    .style17 {
                                        color: #FFFFFF;
                                        width: 500px;
                                    }

                                    .style18 {
                                        color: #FFFFFF;
                                        width: 3000px;
                                    }

                                    .style7 {
                                        font-size: x-large;
                                        font-family: "Comic Sans MS";
                                        width: 792px;
                                    }

                                    .style21 {
                                        width: 35px;
                                    }
                                </style>



                                <asp:Panel ID="Panel1" Width="80px" runat="server">
                                    <br />
                                    <div style="width: 76%;" id="divexcel" runat="server">
                                        &nbsp;&nbsp;
                                 <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;">
                                     <tr style="height: 20px">
                                         <td align="center" colspan="2">
                                             <span style="font-size: 11; font-family: Times New Roman; font-weight: 900">Form GST Delivery Challan</span>
                                         </td>
                                     </tr>
                                 </table>
                                        <br />

                                        <table border="1">
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">Serial No. of delivery challan : </span></td>

                                                <td>
                                                    &nbsp;&nbsp;<asp:Label ID="LblSRDCNum" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>

                                                <td><span style="font-family: Arial; font-size: 9px">Mode of Transport : </span></td>

                                                <td >
                                                    <asp:Label ID="LblTrans" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">GSTIN: </span></td>
                                                <td >
                                                    <asp:Label ID="LblGST" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                                <td><span style="font-family: Arial; font-size: 9px">Vehicle No : </span></td>
                                                <td >
                                                    <asp:Label ID="LblVehical" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">Place of Supply: </span></td>
                                                <td >
                                                    <asp:Label ID="Lblsupply" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                                <td><span style="font-family: Arial; font-size: 9px">Date of DC: </span></td>
                                                <td >
                                                    <asp:Label ID="LblDate" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                            </tr>
                                            --
                                        </table>
                                        <br />

                                        <table id="Tbl_Second" cellpadding="0" cellspacing="0" width="100%" height="100%" border="1" style="padding:1px">
                                            <tr>
                                                <td colspan="2">
                                                    <span style="font-family: Arial; font-size: 9px">&nbsp;&nbsp;Details of Receiver : </span>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">&nbsp;&nbsp;Name: </span></td>
                                               
                                                <td>
                                                    <asp:Label ID="LblName" runat="server" font-size="9px" font-family="Arial" ></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px;">&nbsp;&nbsp;Address : </span></td>
                                                <td>
                                                    <asp:Label ID="LblAddress" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">&nbsp;&nbsp;State: </span></td>
                                                <td>
                                                    <asp:Label ID="LblState" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">&nbsp;&nbsp;Place of Supply: </span></td>
                                                <td>
                                                    <asp:Label ID="Lbl_Place_Suply" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><span style="font-family: Arial; font-size: 9px">&nbsp;&nbsp;GSTIN/Unique ID: </span></td>
                                                <td>
                                                    <asp:Label ID="LblGst_Uniq" runat="server" font-size="9px" font-family="Arial"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <br />

                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"                                            
                                            ShowHeaderWhenEmpty="True" CssClass="table-responsive"   >
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL.No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text='<%# Eval("SL No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description of Goods">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblDescriptionGoods" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label>
                                                     
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="HSN Code" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblHSNCode" runat="server" align="Center" Width="20px" Text='<%# Eval("HSN_SAC_NUM") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQty" runat="server" align="Center" Width="20px" Text='<%# Eval("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblUnit" runat="server" align="Center" Text='<%# Eval("Unit") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rate" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblRate" runat="server" align="Center" Width="10px" Text='<%# Eval("Rate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbltotal" align="Center" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Discount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblDiscount" align="Center" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblAmount" align="Center" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>



                                        <table id="Tbl_CGST_SGST" runat="server" border="1">
                                            <tr>
                                                <td style="width: 50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblAmountBeforetext" runat="server" Text="Total Amount before Tax"></asp:Label>
                                                </span></td>

                                                <td style="width: 25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="LblAmountBeforeTax" runat="server"></asp:Label>
                                                </span></td>
                                            </tr>
                                            <tr  id="trcgstigst" runat="server" visible="false">
                                                <td style="width: 50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblCGSTIGST" runat="server" ></asp:Label>
                                                </span></td>
                                                
                                                <td style="width: 25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblAddCGST" runat="server"></asp:Label>
                                                </span></td>
                                                
                                            </tr>
                                            <tr id="trsgst" runat="server" visible="false">
                                                <td style="width: 50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblSGST" runat="server" ></asp:Label>
                                                </span></td>
                                                <td style="width: 25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="LblAddSGST" runat="server"></asp:Label>
                                                </span></td>
                                            </tr>
                                            <tr  id="trnull" runat="server" visible="false">
                                                <td style="width: 50%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="lblExumpted" runat="server"></asp:Label>
                                                </span></td>
                                                 <td style="width: 25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="LblAddExumpted" runat="server"></asp:Label>
                                                </span></td>

                                            </tr>

                                            <tr>
                                                <td style="width: 25%"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="LblAmountaftertaxtext" runat="server" Text="Total Amount after Tax:"></asp:Label>
                                                </span></td>
                                                <td style="width: 25%" align="right"><span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                    <asp:Label ID="LblAmountAfterTax" runat="server"></asp:Label>
                                                </span></td>

                                            </tr>

                                        </table>
                                        <br />

                                        <table border="1">
                                            <tr>
                                                <td>
                                                    <span style="font-family: Arial; font-size: 9px">NAME: </span>
                                                    <br />
                                                    <asp:Label ID="LblNameTerm" runat="server"></asp:Label>
                                                </td>


                                                <td align="right"><span style="font-family: Arial; font-size: 9px">For Centillion Solutons & Services Pvt Ltd</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" align="left" style="margin-top: -3px;">
                                                    <span style="font-family: Arial; font-size: 9px; text-align: left; padding: 0px;">Term & Conditions: </span>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                </td>
                                                <br/>
                                                <br/>
                                                <br />
                                                <br />
                                                <br />
                                                <td align="right">

                                                    <span style="font-family: Arial; font-size: 9px; text-align: right; align-content: center;">Name of the Authorized Representative</span>
                                                    <br />
                                                    <br />
                                                    <span style="font-family: Arial; font-size: 9px">Designation/Status </span>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <span style="font-family: Arial; font-size: 9px">Authorised Signatory</span>
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

