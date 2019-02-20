<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="GRNPDF.aspx.cs" Inherits="GRNPDF" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type= "text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />

    <script type="text/javascript">
 $(document).ready(function() {
     $(function () {
         $("[id$='_ddlGRN']").customselect();
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

                        <li><a href="testrep.aspx">GRN(PDF)</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>GRN(PDF)</h4>
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
                                        <td style="width:10%">GRN Number:-
                                        </td>
                                        <td style="width:10%">
                                            <asp:DropDownList ID="ddlGRN" runat="server" AppendDataBoundItems="true" name='standard' CssClass="custom-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:10%" align="left">
                                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click"/>
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
                                    .img-responsive, .thumbnail > img, .thumbnail a > img, .carousel-inner > .item > img, .carousel-inner > .item > a > img {
                                        display: block;
                                        max-width: 100%;
                                        height: auto;
                                    }
                                </style>

                                <asp:Panel ID="Panel1" Width="80px" runat="server">                                   
                                        <div style="width: 76%;" id="divexcel" runat="server">                      

                                              <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;">
                                                  <tr>
                                                      <td align="left">
                                                          <img src="images/logo_tagline.png" class="img-responsive" title="Centillion" alt="Centillion Logo" />
                                                          <%--  <img src="images/logo.jpg">--%>
                                                          <%--<span class="logotxt">Strategic Partnership to Engage and Enhance Delivery</span>--%>
                                                      </td>
                                                      <td align="right">
                                                          <span style="font-family: Arial; font-size: 11px"> Date:</span> 
                                                          <asp:Label ID="LblDate" runat="server" Style="text-align: left; font-family: Arial; font-size: 10px"></asp:Label><br /><br />
                                                        <span style="font-family: Arial; font-size: 11px">Location / Warehouse:</span> 
                                                           <asp:Label ID="lblLocation" runat="server" Style="text-align: left; font-family: Arial; font-size: 10px"></asp:Label><br />

                                                      </td>
                                                  </tr>
                                              </table>
                                            <br />
                                            <table border="1">
                                                <tr style="height: 20px">
                                                    <td align="center" colspan="2">
                                                        <span style="font-size: 11; font-family: Times New Roman; font-weight: 900">GOODS RECEIVED NOTE (GRN)</span>
                                                    </td>
                                                </tr>
                                            </table>

                                   <%--  <table style="font-family: Arial; font-size: 10pt; margin-right: 0px;">
                                         <tr>
                                             <td align="left">
                                            
                                             </td>
                                             <td>
                                            
                                             </td>
                                         </tr>
                                         <tr style="height: 20px">
                                             <td align="center" colspan="2">
                                                 <span style="font-size: 11; font-family: Times New Roman; font-weight: 900">GOODS RECEIVED NOTE (GRN)</span>
                                             </td>
                                         </tr>
                                     </table>--%>
                                            <br />                                       
                                                     <table style="border-width:thin" width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <span style="font-family: Arial; font-size: 9px">GRN NO: </span>
                                                                </td>
                                                                <td style="font-stretch: expanded">
                                                                    <asp:Label ID="lbl_GRNnumber" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <span style="font-family: Arial; font-size: 9px">AWB NO: </span>
                                                                </td>
                                                                 <td style="font-stretch: expanded">
                                                                    <asp:Label ID="Lbl_AwbNum" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span style="font-family: Arial; font-size: 9px">Transport Co:</span>
                                                                </td>
                                                                <td >
                                                                    <span>
                                                                        <asp:Label ID="lbl_Transport" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <span style="font-family: Arial; font-size: 9px">Vehicle No:</span>
                                                                </td>
                                                                <td >
                                                                    <span>
                                                                        <asp:Label ID="lbl_VehicleNo" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >
                                                                    <span style="font-family: Arial; font-size: 9px">Supplier Name:</span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="lbl_SupplierName" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                 <td >
                                                                    <span style="font-family: Arial; font-size: 9px">Invoice / Delivery Challan No : </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="lblInvoiceNum" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                         <tr>
                                                                <td >
                                                                    <span style="font-family: Arial; font-size: 9px">Invoice / Delivery Challan Date : </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="lblInvoiceDate" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                 <td >
                                                                    <span style="font-family: Arial; font-size: 9px">PO Number: </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="lblPoNumber" runat="server" Style="text-align: left; font-family: Arial; font-size: 9px"></asp:Label>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                        </table>                                                                               
                                            <br />    <br /> 
                                           
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"                                                 
                                                    ShowHeaderWhenEmpty="True" Width="100%">
                                                    <Columns>
                                                        <%--<asp:TemplateField HeaderText="Slno">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="2px" />
                                                            <ItemStyle Width="2px" />
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Commodity Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblProduct" runat="server"  Text='<%# Eval("Description") %>'></asp:Label>                                                               
                                                            </ItemTemplate>                                                   
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="PO QTY." HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblPOQTY" runat="server" align="Center" Width="20px" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                            </ItemTemplate>                                                    
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit QTY According to AWB" HeaderStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblUnitQTY" runat="server" align="Center" Width="20px" Text='<%# Eval("GRN_Quantity") %>'></asp:Label>
                                                            </ItemTemplate>                                                    
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Qty. received in Good Condition">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblQtyreceived" runat="server" align="Center" Text='<%# Eval("QtyreceivedinGoodCondition") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Missing / Short-Landed Units." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblMissingUnits" runat="server" align="Center" Width="10px" Text='<%# Eval("MissinglendedUnits") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                               

                                                        <asp:TemplateField HeaderText="Broken, Torn or Leaking Containers">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblBrokenContainers" align="Center" runat="server" Text='<%# Eval("BrokenContainer") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Damaged Units (wet, crushed, etc.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDamagedUnits" align="Center" runat="server" Text='<%# Eval("DamagedUnits") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Empty and Light Units">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblEmptyUnits" align="Center" runat="server" Text='<%# Eval("LightUnits") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Total Damaged & Missing">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblTotalDamaged" align="Center" runat="server" Text='<%# Eval("TotalDamaged") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            <br />
                                            <br />                                      

                                            <table class="style1" style="width: 100%">
                                                <tr>

                                                    <td align="left">
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                            We the undersigned declare that we concur that the products & commodities listed above were determined to be in such condition as noted:
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                           NOTE: By signing, individuals verify the authenticity of this document; it is not an admission of responsibility for loss or damage. 
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <span style="font-size: 9; font-family: Times New Roman; font-weight: lighter">
                                                           If the Driver is no longer present at the time of completion of reconditioning, then have transport company representative sign in recognition. 
                                                        </span>
                                                    </td>
                                                </tr>                                                
                                            </table>
                                            <br />                                           
                                            <br /> 
                                            <br />
                                        <table width="100%">
                                            <tr>
                                                <td style="height:700px"> <span style="font-size: 9; font-family: Arial; height:100px; font-weight: lighter">Signature Warehouse Mgr :</span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial;  height:100px; font-weight: lighter">Driver/Rep : </span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial;   height:100px;font-weight: lighter"> Date : </span>
                                                      <asp:Label ID="lblbtmDate" runat="server" Style="text-align: left; font-family: Arial; font-size: 10px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr  style="height:700px">
                                                <td style="height:700px"> <span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"> </span></td>
                                            </tr>
                                             <tr  style="height:700px">
                                                <td style="height:700px"> <span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"> </span></td>
                                            </tr>
                                             <tr  style="height:700px">
                                                <td style="height:700px"> <span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"> </span></td>
                                            </tr>
                                             <tr  style="height:700px">
                                                <td style="height:700px"> <span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"> </span></td>
                                            </tr>
                                             <tr  style="height:700px">
                                                <td style="height:700px"> <span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"></span></td>
                                                <td style="height:700px"><span style="font-size: 9; font-family: Arial; font-weight: lighter"> </span></td>
                                            </tr>
                                            
                                            <tr>
                                                <td><span style="font-size: 9; font-family: Arial; font-weight: lighter">Authorised Signatory :</span></td>
                                                <td><span style="font-size: 9; font-family: Arial; font-weight: lighter">Procurement Dept:</span>                                                  
                                                </td>
                                                <td></td>
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

