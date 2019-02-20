<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PurchaseOrderPDF.aspx.cs" EnableEventValidation="false" Inherits="PurchaseOrderPDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type= "text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />
 
	<script type="text/javascript">
	    $(document).ready(function () {
	        $(function () {
	            $("[id$='_ddlPonumber']").customselect();
	        });
	    });

 </script>
   
    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Purchase
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>
                            <a href="#">Purchase</a><span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="testrep.aspx">Purchase Order(PDF)</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Purchase Order(PDF)</h4>
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
                                        <td style="width:10%">PO Number:-
                                        </td>
                                        <td style="width:10%">
                                            <asp:DropDownList ID="ddlPonumber" runat="server" AppendDataBoundItems="true" name='standard' CssClass="custom-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:10%" align="left">
                                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
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
                                   <%-- <br />--%>
                                    <div style="width: 76%;" id="divexcel" runat="server">
                                        &nbsp;&nbsp;
                                 <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;">
                                     <%--<tr>
                                         <td align="left">
                                         </td>
                                         <td>
                                         </td>
                                     </tr>--%>
                                     <tr style="height: 20px">
                                         <td align="center" colspan="2">
                                             <span style="font-size: 11; font-family: Times New Roman; font-weight: 900">PURCHASE ORDER</span>
                                         </td>
                                     </tr>
                                 </table>
                                        <%-- <span style="font-size: 11;text-align:center; font-family: Times New Roman; font-weight: 900">PURCHASE ORDER</span>--%>
                                        <br /> 
                                        <%--<br />  --%>                                
                                        <table>
                                            <tr>
                                          <td></td>
                                                <td>
                                                    <table border="1" style="" width="100%">
                                                        <tr>
                                                            <td class="style17">
                                                                <span style="font-family: Arial; font-size: 9px">P.O.NO </span>
                                                            </td>
                                                            <td class="style18" style="font-stretch: expanded">
                                                                <asp:Label ID="lbl_Ponumber" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style17">
                                                                <span style="font-family: Arial; font-size: 9px">Dated</span>
                                                            </td>
                                                            <td class="style18">
                                                                <span class="style4">
                                                                    <asp:Label ID="lbl_PoDate" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style17">
                                                                <span style="font-family: Arial; font-size: 9px">SPA</span>
                                                            </td>
                                                            <td class="style18">
                                                                <span class="style4">
                                                                    <asp:Label ID="lblSPA" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>                                  
                                        <table class="style1" style="width: 854%">
                                            <tr>
                                                <td class="style16">
                                                    <span style="font-size: 9; font-family: Arial; font-weight: lighter">TO,<br />

                                                       <%-- Millennium Business Machines Pvt limited.<br />
                                                        701/ A wing,  Dipti Classic, Suren Road<br />
                                                        Off Andheri Kurla Road, <br />
                                                        Near Western Express Highway Metro Station<br />
                                                        Andheri ( East ), Mumbai 400 093--%>
                                                        <%--Rama Infotech<br />--%>
                                                        Kodak Alaris India Pvt Ltd,<br />
                                                        272, Solitaire Corporate Park,<br />
                                                        Andheri East,Mumbai – 400093. <br />
                                                    </span>                                                  
                                                </td>                                                
                                            </tr>                                            

                                        </table>                                       
                                        <span style="font-size: 9; font-family: Arial; font-weight: lighter">Kind Attn:Mr. Vivek Naidu. <%--Mr. Viren Reshamwala--%>  <%--V.Ramesh--%>
                                          <asp:Label ID="lbl_PO_RaisedTO" runat="server" Visible="false"></asp:Label>
                                            <br />
                                         <%--  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Information Management</span><br />--%>
                                        <br />

                                       <table style="width: 100%" border="1">
                                            <tr>
                                                <td><span style="font-size: 10; font-family: Arial; font-weight: lighter">Bill To
                                                </span>
                                                </td>
                                                <td>
                                                    <span style="font-size: 10; font-family:Arial; font-weight: lighter">Ship To
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 9; font-family: Arial; font-weight: lighter">
                                                        <asp:Label ID="lbl_Bill_Address" runat="server"></asp:Label><br />
                                                        <br />
                                                        PAN :<asp:Label ID="lblBillPAN" runat="server"></asp:Label><br />
                                                        GST :<asp:Label ID="lblBillGST" runat="server"></asp:Label><br />
                                                    </span>

                                                </td>
                                                <td>
                                                    <span style="font-size: 9; font-family: Arial; font-weight: lighter">
                                                        <asp:Label ID="lbl_Ship_Address" runat="server"></asp:Label>
                                                         <br /><br />
                                                        PAN :<asp:Label ID="lblShipPAN" runat="server"></asp:Label><br />
                                                       <%-- GST :<asp:Label ID="lblShipGST" runat="server"></asp:Label><br />--%>
                                                    </span></td>
                                            </tr>
                                        </table>
                                        <asp:GridView ID="GvwSaleseOrderDetails" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="PO_ID"
                                            ShowHeaderWhenEmpty="True" Width="100%">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server" align="left" Text='<%# Eval("Product") %>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProductcode" runat="server" align="Center" Width="20px" Text='<%# Eval("Product_Code") %>'></asp:Label>
                                                    </ItemTemplate>                                                  
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Qty." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" align="Center" Width="10px" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit Price(INR)" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" align="right" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                              

                                                <asp:TemplateField HeaderText="Amount(INR)" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblAmount" runat="server" align="right" Text='<%# Eval("PO_TotalPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tax Amount" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltaxAmount" runat="server" align="right" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Price" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltotalAmount" runat="server" align="right" Text='<%# Eval("TT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="PO_ID" OnDataBound="GridView1_DataBound"
                                            ShowHeaderWhenEmpty="True" CssClass="table-responsive">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Slno">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>                                               
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server"  Text='<%# Eval("Product") %>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>                                                   
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="HSN." HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblHSNCode" runat="server" align="Center" Width="20px" Text='<%# Eval("HSN_SAC_NUM") %>'></asp:Label>
                                                    </ItemTemplate>                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProductcode" runat="server" align="Center" Width="20px" Text='<%# Eval("Product_Code") %>'></asp:Label>
                                                    </ItemTemplate>                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" align="Center" Width="10px" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit Price(INR)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" align="Center" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Total Price(INR)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltotalAmount" align="Center" runat="server" Text='<%# Eval("tt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                      
                                        <table class="style1" style="width: 100%">
                                            <tr>
                                                <td align="left">
                                                    <span style="font-size: 9px; font-family: Times New Roman; font-weight: 900">Terms:</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span style="font-size: 9px; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lbl_Term1" runat="server"
                                                            Text="1.Price: Taxes Extra As per GST."></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span style="font-size: 9px; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lbl_Term2" runat="server"
                                                            Text="2. Payment : 60 days from the date of Invoice. "></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span style="font-size: 9px; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lbl_Term3" runat="server" Text="3. Delivery : Within 2-3 weeks."></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span style="font-size: 9px; font-family: Times New Roman; font-weight: lighter">
                                                        <asp:Label ID="lbl_Term4" runat="server" Text="4. Warranty : Three year onsite."></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                     
                                        <span style="font-size: 9; font-family: Arial; font-weight: lighter"">For Centillion Solutions and Services Private Limited.</span>
                                        <br />
                                        <br />
                                        <img src="images/Binu Sign.png" alt=""/>
                                                           
                                        <span style="font-size: 9; font-family: Arial; font-weight: lighter"">Authorised Signatory</span>
                                        
                                    </div>
                                </asp:Panel>


                                <asp:Panel ID="Panel2" Width="80px" runat="server">
                                   <%-- <br />--%>
                                    <div style="width: 76%;" id="div1" runat="server">
                                        &nbsp;&nbsp;
                                   <%--  <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;">
                                        <tr>
                                             <td align="left">
                                                  
                                             </td>
                                             <td></td>
                                         </tr>
                                     </table>--%>
                                       <%-- <br />--%>
                                        <table border="1" style="background-color: burlywood">
                                            <tr style="height: 10px">
                                                <td align="center" colspan="2" style="background-color: silver">
                                                    <span style="font-size: 10; font-family: Arial; font-weight: 900">PURCHASE ORDER</span>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <table border="1" style="" width="100%">
                                                        <tr>
                                                            <td class="style17">
                                                                <span style="font-family: Arial; font-size: 9px">P.O.NO </span>
                                                            </td>
                                                            <td class="style18" style="font-stretch: expanded">
                                                                <asp:Label ID="lbl_PonumberSupport" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style17">
                                                                <span style="font-family: Arial; font-size: 9px">Dated</span>
                                                            </td>
                                                            <td class="style18">
                                                                <span class="style4">
                                                                    <asp:Label ID="lbl_PoDateSupport" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                </span>
                                                            </td>
                                                        </tr>

                                                    </table>

                                                </td>
                                            </tr>
                                        </table>
                                        <%--<br />--%>
                                        <span style="font-size: 9; font-family: Arial; font-weight: lighter">TO,</span>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;
                                         <span style="font-size: 9; font-family: Arial; font-weight: lighter">
                                                                           Kodak Alaris India Pvt Ltd ,<br />
                                                                            272, Solitaire Corporate Park,<br />
                                                                            Andheri East,Mumbai – 400093.
                                         </span>
                                        <br />
                                       <%-- <br />       --%>                                
                                        <span style="font-size: 9; font-family: Arial; font-weight: lighter">Kind Attn:
                                       <asp:Label ID="Label5" runat="server" Text="Mr.Neil Falcao"></asp:Label>
                                             <br />
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Information Management
                                        </span>
                                        <br />
                                        <br />
                                        <table style="width: 100%" border="1">
                                            <tr>
                                                <td><span style="font-size: 10; font-family: Arial; font-weight: lighter">Bill To
                                                </span>                                                    
                                                </td>
                                                <td>
                                                    <span style="font-size: 10; font-family: Arial; font-weight: lighter">Ship To
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 9; font-family: Arial; font-weight: lighter">
                                                        <asp:Label ID="lbl_Bill_Address_Support" runat="server"></asp:Label>
                                                        <br />
                                                        PAN :<asp:Label ID="lblSupBilPAN" runat="server"></asp:Label><br />
                                                        GST :<asp:Label ID="lblSupBilGST" runat="server"></asp:Label><br />
                                                    </span>

                                                </td>
                                                <td>
                                                    <span style="font-size: 9; font-family:Arial; font-weight: lighter">
                                                        <asp:Label ID="lbl_Ship_Address_Support" runat="server"></asp:Label>
                                                    </span></td>
                                            </tr>
                                        </table>
                                        <asp:GridView ID="GvwSaleseOrderDetailsSupport" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="PO_ID"
                                            ShowHeaderWhenEmpty="True" Width="100%">
                                            <Columns>

                                                <asp:TemplateField HeaderText="S.NO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text='<%#Eval("SLNO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server" align="left" Text='<%# Eval("Product") %>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProductcode" runat="server" align="Center" Width="20px" Text='<%# Eval("Product_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Qty." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" align="Center" Width="10px" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit Price(INR)" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" align="right" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                              


                                                <asp:TemplateField HeaderText="Amount(INR)" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblAmount" runat="server" align="right" Text='<%# Eval("PO_TotalPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tax Amount" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltaxAmount" runat="server" align="right" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Price(INR)" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltotalAmount" runat="server" align="right" Text='<%# Eval("TT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="PO_ID" OnDataBound="GridView3_DataBound"
                                            ShowHeaderWhenEmpty="True" ShowFooter="false" Width="100%">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Slno">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2px" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                        <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>                                                   
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="SAC." HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSACCode" runat="server" align="Center" Width="20px" Text='<%# Eval("HSN_SAC_NUM") %>'></asp:Label>
                                                    </ItemTemplate>                                                    
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProductcode" runat="server" align="Center" Width="20px" Text='<%# Eval("Product_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Qty." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" align="Center" Width="10px" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit Price(INR)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                 <%--<asp:TemplateField HeaderText="Amount(INR)" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblAmount" runat="server" align="right" Text='<%# Eval("PO_TotalPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Amount" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltaxAmount" runat="server" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Total Price(INR)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>                                     


                                        <table class="style1" style="width: 100%">
                                            <tr>

                                                <td align="left">
                                                    <span style="font-size: 9; font-family: Arial; font-weight: 900">Terms:</span>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td align="left">
                                                    <span style="font-size: 9; font-family: Arial; font-weight: lighter">
                                                        <asp:Label ID="Label8" runat="server"
                                                            Text="1. Price: Taxes Extra As per GST"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span style="font-size: 9; font-family:Arial; font-weight: lighter">
                                                        <asp:Label ID="Label9" runat="server"
                                                            Text="2. Payment : 60 days from the date of Invoice. "></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                             <tr>

                                                <td align="left">
                                                    <span style="font-size: 9; font-family: Arial; font-weight: lighter">
                                                        <asp:Label ID="Label1" runat="server"
                                                            Text="3. Within 2-3 weeks. "></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>

                                        </table>
                                        <%--<br />--%>
                                        <span style="font-size: 9; font-family: Arial; font-weight: 900">For Centillion Solutions and Services Pvt Ltd.</span>
                                       <br />
                                        <br />                                                                            
                                      <img src="images/Binu Sign.png" alt=""/>
                                        <span style="font-size: 9; font-family: Arial; font-weight: 900">Authorised Signatory</span><%--<br />--%>
                                       <%-- <br />--%>
                                        <%--<span style="font-size: 9; font-family: Times New Roman; font-weight: 900">This is an electronically generated Invoice and needs no signature.</span>
                                        <br />
                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">Renjith A</span><br />
                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">Dy.Manager - Imaging Services</span>

                                        <br />--%>
                                       <%-- <br />--%>
                                       
                                 <%--       <img alt="" src="http://www.centillioncosmos.com/HRMS/gui/img/Redline.png" />
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="3" style="width: 100%">
                                                    <img alt="" src="http://www.centillioncosmos.com/HRMS/gui/img/Redline.png" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">Centillion Solutions and Services Pvt Ltd.</span><br />
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">A 1111 - 1116, Kailash Business Park,Hiranandani Link Road, Parksite, Vikhroli West, Mumbai - 400 079</span>
                                                    <br />
                                                    <span style="font-size: 9; font-family: Times New Roman; font-weight: 900">CIN:U72400KA2006PTC039877</span></td>

                                            </tr>

                                        </table>--%>

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

