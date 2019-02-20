<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="TestPurchaseInvoice, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                       
                    <li> <a href="PurchaseInvoice.aspx">Purchase Invoice</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Purchase Invoice</h4>
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
                                    <td style="height: 38px">
                                        From Date
                                    </td>
                                    <td style="height: 38px">
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate" 
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" Move="True" />
                                    </td>
                                    <td style="height: 38px">
                                        To Date
                                    </td>
                                    <td style="height: 38px">
                                        <div class="controls">
                                            <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate" 
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        </div>
                                    </td>
                                    <td style="height: 38px">
                                    <asp:Button id="BtnSearch" class="btn-success" runat ="server" Text="Search" 
                                            onclick="BtnSearch_Click" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                       
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server">
                               <asp:GridView ID="GvwSalesRegister" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                              ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="PO_ID" 
                                onrowcommand="GvwSalesRegister_RowCommand" AllowPaging="True" AllowSorting="True"
                                onpageindexchanging="GvwSalesRegister_PageIndexChanging" PageSize="5">
                                <Columns>
                                    <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("[PO_Number]") %>'></asp:Label>
                                               
                                          <asp:Label ID="hidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("[PO_Date]") %>'></asp:Label>
                                            <asp:HiddenField ID="HidCatagory" runat="server" />
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                            <asp:HiddenField ID="HidLocationID" runat="server"  value='<%# Eval("locationID") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Tax">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTax" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                              <asp:HiddenField ID="HidtaxID" runat="server"  value='<%# Eval("taxid") %>'/>
                                        </ItemTemplate>
                                   
                                    </asp:TemplateField>--%>
                                  
                                    <asp:TemplateField HeaderText="Total Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("PO_NetAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                   
                                    <asp:TemplateField HeaderText="PO_Entered On">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_EnteredOn" runat="server" Text='<%# Eval("PO_EnteredOn") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                      <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                            CommandName="Edit1">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                               
                                </Columns>
                            </asp:GridView>
                         
                            </asp:Panel>
                            <br />
                         
                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                           
                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="input-mini" style="width: 75px">
                                                PO No. 
                                            </td>
                                            <td style="width: 156px">
                                                <asp:TextBox ID="TxtPoNo" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 77px" class="input-mini">
                                                &nbsp;&nbsp;&nbsp;&nbsp; PO Date
                                            </td>
                                            <td style="width: 155px">
                                                <div class="controls">
                                                    <asp:TextBox ID="TxtPoDate" runat="server" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td style="width: 168px">
                                               Total Amount</td>
                                            <td>
                                                <span class="style4">
                                                <asp:TextBox ID="TxtTotalAmount" runat="server" ReadOnly="True"></asp:TextBox>
                                                </span></td>
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 75px">
                                                &nbsp;</td>
                                            <td style="width: 156px">
                                                &nbsp;</td>
                                            <td class="input-mini" style="width: 77px">
                                                &nbsp;</td>
                                            <td style="width: 155px">
                                                &nbsp;</td>
                                            <td style="width: 168px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 75px">
                                                Location</td>
                                            <td style="width: 156px">
                                                <asp:TextBox ID="TxtPoLocation" runat="server" ReadOnly="True" 
                                                    ontextchanged="TxtLocation_TextChanged"></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 77px">
                                                &nbsp;&nbsp;&nbsp;&nbsp; Supplier</td>
                                            <td style="width: 155px">
                                                <asp:TextBox ID="TxtPoSupplier" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 168px" >
                                                Shipping Address</td>
                                            <td style="width: 250px">
                                              <asp:TextBox ID="Txt_shippingAdress" runat="server" ReadOnly="True" 
                                                    Width="231px" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px; width: 75px;">
                                            </td>
                                            <td style="width: 156px; height: 22px">
                                            </td>
                                            <td class="input-small" style="width: 77px; height: 22px;">
                                            </td>
                                            <td style="height: 22px; width: 155px;">
                                            </td>
                                            <td style="height: 22px; width: 168px;">
                                                </td>
                                            <td style="height: 22px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 75px">
                                                &nbsp;</td>
                                            <td style="width: 156px">
                                                &nbsp;</td>
                                            <td class="input-mini" style="width: 77px">
                                                &nbsp;</td>
                                            <td style="width: 155px">
                                                &nbsp;</td>
                                            <td style="width: 168px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                             <%--       <asp:GridView ID="GvwPurchaseInvocie" runat="server" AutoGenerateColumns="False" 
                                        class="table table-striped table-bordered table-advance table-hover" 
                                       ShowHeaderWhenEmpty="True" Width="100%" ShowFooter="True"  PageSize="5" 
                                        AllowPaging="true" AllowSorting="true"
                                        onpageindexchanging="GvwPurchaseInvocie_PageIndexChanging" 
                                        onrowdeleting="GvwPurchaseInvocie_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Catagory">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                    
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CatagoryID">
                                                <ItemTemplate>
                                                    <asp:Label ID="HidCatagory0" runat="server" Text='<%# Eval("catagoryid") %>'></asp:Label>
                                               
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                 
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Productid">
                                                <ItemTemplate>
                                                    <asp:Label ID="HidProduct0" runat="server" Text='<%# Eval("productid") %>'></asp:Label>
                                                  
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Product Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                          
                                             <asp:TemplateField HeaderText="PO Tax">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbltaxid" runat="server" Text='<%# Eval("taxID") %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="PO Total Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtInQuantity" runat="server"  Text='<%# Eval("PO_Quantity1") %>' Width="30Px"></asp:TextBox>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Price">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtInPrice" runat="server" Text='<%# Eval("PO_UnitPrice1") %>' Width="60Px"></asp:TextBox>
                                                </ItemTemplate>
                                             

                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Invoice Tax">
                                                <ItemTemplate>
                                                <asp:TextBox ID="txttaxid" runat="server" Text='<%# Eval("taxID1") %>'></asp:TextBox>
                                                    
                                                   
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Total Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblInvocietotalPrice" runat="server" Text='<%# Eval("TT1") %>'></asp:Label>
                                                </ItemTemplate>
                                                   </asp:TemplateField>
                                              <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                         <asp:Button id="BtnAdd" class="btn-success" runat ="server" OnClick="AddNewGridRow" Text="Update" ToolTip=" Add New Product"/>
                                       
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
--%>

                                    
               <asp:GridView ID="GvwPurchaseInvocie" runat="server" AutoGenerateColumns="False" 
                                        class="table table-striped table-bordered table-advance table-hover" 
                                       ShowHeaderWhenEmpty="True" Width="100%" ShowFooter="True"  PageSize="5" 
                                        AllowPaging="true" AllowSorting="true"
                                        onpageindexchanging="GvwPurchaseInvocie_PageIndexChanging" 
                                        onrowdeleting="GvwPurchaseInvocie_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Catagory">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidCatagory0" runat="server"  value='<%# Eval("catagoryid") %>'/>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                     <asp:HiddenField ID="HidProduct0" runat="server"  value='<%# Eval("productid") %>'/>
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Product Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                          
                                             <asp:TemplateField HeaderText="PO Tax">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbltaxid" runat="server" Text='<%# Eval("taxID") %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="PO Total Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtInQuantity" runat="server"  Text='<%# Eval("PO_Quantity") %>' Width="30Px"></asp:TextBox>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Price">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtInPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>' Width="60Px"></asp:TextBox>
                                                </ItemTemplate>
                                             

                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Invoice Tax">
                                                <ItemTemplate>
                                                <asp:TextBox ID="txttaxid" Width="35%"  runat="server" Text='<%# Eval("taxID") %>'></asp:TextBox>
                                                    
                                                   
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Total Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblInvocietotalPrice" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                       <asp:Button id="BtnAdd" class="btn-success" runat ="server" OnClick="AddNewGridRow" Text="Update" ToolTip=" Add New Product"/>
                                       
                                                </FooterTemplate>
                                                   </asp:TemplateField>
                                           <%--   <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                  
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>

                                     <div class="row-fluid" style="width: 100%">
                                         <div class="span4 invoice-block pull-right" style="width: 100%">
                                             <ul class="unstyled amounts">
                                                 <li style="height: 150px">
                                                     <div class="span4 invoice-block pull-left" style="width: 99%; height: 57px;">
                                                         <table style="width: 100%">
                                                             <tr>
                                                                 <td class="input-mini" style="width: 166px">
                                                                     Invoice No</td>
                                                                 <td style="width: 240px">
                                                                     <asp:TextBox ID="Txt_InvoiceNo" runat="server"></asp:TextBox>
                                                                 </td>
                                                                 <td colspan="3">
                                                                     Invoice Date</td>
                                                                 <td style="width: 263px">
                                                                     <asp:TextBox ID="Txt_InvoiceDate" runat="server" ReadOnly="True"></asp:TextBox>
                                                                     <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="Txt_InvoiceDate" 
                                                                         Format="mm dd yyyy" Separator="-" ShowErrorMessage="False" />
                                                                 </td>
                                                                 <td>
                                                                     &nbsp;</td>
                                                             </tr>
                                                             <tr>
                                                                 <td class="input-mini" style="width: 166px">
                                                                     PO Total Amount</td>
                                                                 <td style="width: 240px">
                                                                     <span class="style4">
                                                                     <asp:TextBox ID="TxtInTotalAmount" runat="server" 
                                                                         onkeypress="return isNumberKey(event)" Text="0.00" ReadOnly="True"></asp:TextBox>
                                                                     </span>
                                                                 </td>
                                                                 <td style="width: 331px">
                                                                     &nbsp;</td>
                                                                 <td style="width: 331px">
                                                                     &nbsp;</td>
                                                                 <td style="width: 286px">
                                                                      Invoice Total&nbsp; Amount</td>
                                                                 <td style="width: 263px">
                                                                     <span class="style4">
                                                                     <asp:TextBox ID="Txt_SubTotal" runat="server" Text="0.00"></asp:TextBox>
                                                                     </span>
                                                                 </td>
                                                                 <td>
                                                                     &nbsp;</td>
                                                             </tr>
                                                             <tr>
                                                                 <td class="input-mini" style="width: 166px">
                                                                     &nbsp;</td>
                                                                 <td style="width: 240px">
                                                                     &nbsp;</td>
                                                                 <td style="width: 331px">
                                                                     <asp:Button ID="BtnInvoiceSave0" runat="server" class="btn-success" 
                                                                         ForeColor="Black" onclick="BtnInvoiceSave_Click" Text="Save" />
                                                                 </td>
                                                                 <td style="width: 331px">
                                                                     &nbsp;</td>
                                                                 <td style="width: 286px">
                                                                     &nbsp;</td>
                                                                 <td style="width: 263px">
                                                                     &nbsp;</td>
                                                                 <td>
                                                                     &nbsp;</td>
                                                             </tr>
                                                         </table>
                                                         <br />
                                                         <br />
                                                         
                                                         &nbsp;&nbsp;</div>
                                                     &nbsp;&nbsp; </li>
                                             </ul>
                                         </div>
                                    </div>
                                    <br />
                            </asp:Panel>
                                    <asp:HiddenField ID="hidDetails_ID" runat="server" />
                   
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
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
    </div>
</asp:Content>


