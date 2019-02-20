<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="testrep, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Purchase
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                          <a href="#">Purchase</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> <a href="testrep.aspx">Purchase Order(PDF)</a><span class="divider-last">&nbsp;</span></li>
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
                               PO Number:-
    <asp:DropDownList ID="ddlPonumber" runat="server" AppendDataBoundItems="true">
       <asp:ListItem Text="--Select PO Number--" Value="-1" Selected="true"></asp:ListItem>
    </asp:DropDownList>  <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 999px;
        }
        .style5
        {
            width: 918px;
        }
        .style16
        {
            color: #FFFFFF;
            width: 1066px;
        }
          .style7
        {
            font-size: x-large;
            font-family: "Comic Sans MS";
            width: 792px;
        }
        .style21
        {
            width: 35px;
        }
    </style>

    

      <asp:Panel ID="Panel1" Width="80px" runat="server" >
   <br />
   <div style="width:76%;" id="divexcel" runat="server" >
      
         &nbsp;&nbsp;
         <table style="font-family: Arial; font-size: 10pt;  margin-right: 0px;">
             <tr>
                 <td align="left" >
                     <img   src="images/logo.jpg" >
                 </td>
                 <td > 
               <%--   <span style="font-size:13px!important;font-style:italic;font-weight:700; font-family:calibri;color:#959595"> Centillion's - Strategic Partnership to Engage and Enhance Delivery </span>
      --%>
                 </td>
             </tr>
             <tr style="height: 20px">
                 <td align="center" colspan="2">
                     <span style="font-size:11; font-family:Times New Roman; font-weight:900">
                     PURCHASE ORDER</span>
                 </td>
             </tr>
         </table>
         <table class="style1" style="width: 854%">
             <tr>
                 <td class="style16">
                     <span style="font-size:9; font-family:Times New Roman; font-weight:900">
                     <asp:Label ID="lbl_LocationName" runat="server"></asp:Label>
                     </span>
                 </td>
                 <td >
                     &nbsp; <span style="font-size:9; font-family:Times New Roman; font-weight:900"></span></td>
                 <td class="text-left" class="style16"> 
                    
                     <span style="font-size:9; font-family:Times New Roman; font-weight:900">
                     Order No:<asp:Label ID="lbl_Ponumber" runat="server"></asp:Label>
                     </span>
                 </td>
             </tr>
               
                     
                     <tr>
                         <td class="style16">
                             <span style="font-size:9; font-family:Times New Roman; font-weight:900">
                             <asp:Label ID="lbl_Location" runat="server"></asp:Label>
                             </span>
                         </td>
                         <td>
                             <span style="font-size:9; font-family:Times New Roman; font-weight:900">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             </span>
                         </td>
                         <td class="text-left">
                             <span class="style4">
                             <span style="font-size:9; font-family:Times New Roman; font-weight:900">Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<asp:Label 
                                 ID="lbl_PoDate" runat="server" style="text-align: left"></asp:Label>
                             </span></span>
                         </td>
                     </tr>
               
         </table>
         <br />
         <span style="font-size:9; font-family:Times New Roman; font-weight:900">Kind 
         Attn:
         <asp:Label ID="lbl_PO_RaisedTO" runat="server"></asp:Label>
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Document Imaging</span><br /><br />
      
            <asp:GridView ID="GvwSaleseOrderDetails" runat="server" AutoGenerateColumns="False"
            DataKeyNames="PO_ID"
            ShowHeaderWhenEmpty="True"  >
            <Columns>
            
               <%-- <asp:TemplateField HeaderText="Catagory">
                    <ItemTemplate>
                        <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                         
                    </ItemTemplate>
                  
                </asp:TemplateField>--%>
                <%-- <asp:TemplateField HeaderText="Sr." HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSlno" runat="server" Text='<%# Eval("SLNO") %>'></asp:Label>
                    </ItemTemplate>
                 
                   
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="700px" >
                    <ItemTemplate>
                        <asp:Label ID="LblProduct" runat="server" align="left" Width="700px" Text='<%# Eval("Product") %>' ></asp:Label>
                         <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="LblProductcode" runat="server" align="Center" Width="20px"  Text='<%# Eval("Product_Code") %>'></asp:Label>
                    </ItemTemplate>
                 
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px"  >
                    <ItemTemplate>
                        <asp:Label ID="LblQuantity" runat="server" align="Center"  Width="10px" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                    </ItemTemplate>
                   
                 
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Price" HeaderStyle-HorizontalAlign="Center"> 
                    <ItemTemplate>
                        <asp:Label ID="LblPrice" runat="server" align="right" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                    </ItemTemplate>
                 
                   
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tax Amount" HeaderStyle-HorizontalAlign="Center">
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
            DataKeyNames="PO_ID" 
            ShowHeaderWhenEmpty="True" ShowFooter="false">
            <Columns>
            
             
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                         <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tax Amount">
                    <ItemTemplate>
                        <asp:Label ID="LbltaxAmount" runat="server" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Amount">
                    <ItemTemplate>
                        <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("tt") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       
       <table  style="width: 1644%">
            <tr>
                <td class="style7" align="left">
                      <span style="font-size:9; font-family:Times New Roman; font-weight:900">  Bill To:</span></td>
                <td align="left">
                       <span style="font-size:9; font-family:Times New Roman; font-weight:900"> Ship To:</span></td>
            </tr>
            <tr>
                <td class="style7" align="left">
                     <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Bill_Address" runat="server"></asp:Label>
                    </span>
                </td>
                <td align="left">
                     <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                   <asp:Label ID="lbl_Ship_Address" runat="server"></asp:Label>
                   </span>
                   </td>
            </tr>
            <tr>
                <td class="style7" align="left">
                  <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Bill_Address1" runat="server"></asp:Label>
                    </span>
                </td>
                <td align="left">
                   <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                     <asp:Label ID="lbl_Ship_Address1" runat="server"></asp:Label>
                     </span>
                     </td>
            </tr>
            <tr>
                <td class="style7" align="left">
                   <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Bill_Address2" runat="server"></asp:Label>
                    </span>
                </td>
                <td align="left">
                     <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Ship_Address2" runat="server"></asp:Label>
                    </span>
                    </td>
            </tr>
            <tr>
                <td class="style7" align="left">
                  <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Bill_Address3" runat="server" Text=""></asp:Label>
                    </span>
                </td>
                <td align="left">
                      <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Ship_Address3" runat="server" Text=""></asp:Label>
                    </span>
                    </td>
            </tr>
            <tr>
                <td class="style7" align="left">
                   <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    TIN:<asp:Label ID="lbl_Bill_TIN" runat="server" Text=""></asp:Label>
                    </span>
                </td>
                 <td class="style7" align="left">
                   <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    TIN:<asp:Label ID="lbl_ship_TIN" runat="server" Text=""></asp:Label>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="style7" align="left">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
        <table class="style1" style="width: 100%">
         <tr>
               
                <td align="left">
                <span style="font-size:9; font-family:Times New Roman; font-weight:900"> Terms:</span>
                </td>
            </tr>
            <tr>
               
                <td align="left">
                <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Term1" runat="server" 
                        Text="1. Tax : As Mentioned Above."></asp:Label>
                        </span>
                </td>
            </tr>
            <tr>
               
                <td align="left">
                 <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Term2" runat="server" 
                        Text="2. Payment : 60 days from the date of receipt Shipment. "></asp:Label>
                         </span>
                </td>
            </tr>
            <tr>
                
                <td align="left">
                 <span style="font-size:9; font-family:Times New Roman; font-weight:lighter">
                    <asp:Label ID="lbl_Term3" runat="server" Text="3. Delivery : Within 2-3 weeks."></asp:Label>
                     </span>
                </td>
            </tr>
     
        </table>
        <br />
          <span style="font-size:9; font-family:Times New Roman; font-weight:900"> For Centillion Solution And Service (P)Ltd.</span><br />
        <br />
        <br />
           <br />
        <br />
         <span style="font-size:9; font-family:Times New Roman; font-weight:900">  Authorised Signatory</span><br />
          <img alt="" src="http://www.centillioncosmos.com/HRMS/gui/img/Redline.png" />
        <table style="width: 100%">
            <tr>
                <td colspan="3" style="width: 100%">
                  <img alt="" src="http://www.centillioncosmos.com/HRMS/gui/img/Redline.png" />
          
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">                    
                     <span style="font-size:9; font-family:Times New Roman; font-weight:900">  Centillion Solution And Service (P)Ltd.</span>
                  
                         <br />
                         <span style="font-size:9; font-family:Times New Roman; font-weight:900">CIN:U72400KA2006PTC039877</span></td>
              
            </tr>
            <tr>
                <td align="left">
                   <span style="font-size:8;"> Imaging Division:
                    <br />
                    <asp:Label ID="lbl_Footer_Address1" runat="server"></asp:Label>
                    ,
                    <br />
                    &nbsp;<asp:Label ID="lbl_Footer_Address2" runat="server"></asp:Label>
                    ,<asp:Label ID="lbl_Footer_Address3" runat="server"></asp:Label>
                    <br />
                    Tel: 91 22 40085999 Fax: 91 22 40085915
                    <br />
                    Email:sales.imaging@indecommglobal.com</span>
                </td>
                <td></td>
                <td   >
                   <span style="font-size:9; font-family:Cambria">  Regd. Office:
                    <br />
                    Indecomm House, #30, LaskarHosur Road,
                    <br />
                    Adugodi, Bangalore -560 030, India.
                    <br />
                    Tel: 91 80 66960400, 22489260 
                    <br />
                    Fax: 91 80 22227974
                    <br />
                    Web: www.centillioncosmos.com</span>
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
