<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="PurchaseManagerChecking, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>
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
                       
                    <li> <a href="TestPurchaseInvoice.aspx">Purchase Manager Checking</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Purchase Manager Checking</h4>
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
                                </table>
                            <asp:Panel ID="Panel2" runat="server">
                               <asp:GridView ID="GvwSalesRegister" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                              ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="PO_ID" 
                                onrowcommand="GvwSalesRegister_RowCommand" AllowPaging="True" AllowSorting="True"
                                onpageindexchanging="GvwSalesRegister_PageIndexChanging" PageSize="5">
                                <Columns>
                                  <%--  <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Total Amount</td>
                                            <td>
                                                <span class="style4">
                                                <asp:TextBox ID="TxtTotalAmount" runat="server" ReadOnly="True"></asp:TextBox>
                                                </span></td>
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 75px">
                                                Location</td>
                                            <td style="width: 156px">
                                                <asp:TextBox ID="TxtPoLocation" runat="server" ReadOnly="True" ></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 77px">
                                                &nbsp;&nbsp;&nbsp;&nbsp; Supplier</td>
                                            <td style="width: 155px">
                                                <asp:TextBox ID="TxtPoSupplier" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 168px" dir="rtl">
                                                ShippingAddress&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                <span class="style4">
                                                <asp:TextBox ID="TxtShippingAddress" runat="server" ReadOnly="True"></asp:TextBox>
                                                </span></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px; width: 75px;">
                                            </td>
                                            <td style="height: 22px" colspan="4">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Billing Adress <span class="style4">
                                                <asp:TextBox ID="TxtBillingAddress" runat="server" ReadOnly="True"></asp:TextBox>
                                                </span>
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
                                     <div class="row-fluid" style="width: 100%">
                                        
                                         <asp:GridView ID="GvwPurchaseInvocie" runat="server" AllowPaging="true" 
                                             AllowSorting="true" AutoGenerateColumns="False" 
                                             class="table table-striped table-bordered table-advance table-hover" 
                                             onpageindexchanging="GvwPurchaseInvocie_PageIndexChanging" PageSize="5" 
                                         ShowHeaderWhenEmpty="True" Width="100%">
                                             <Columns>
                                                 <%--<asp:TemplateField HeaderText="Slno">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>--%>
                                                 <%-- <asp:TemplateField HeaderText="CatagoryID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagoryID" runat="server" Text='<%# Eval("CatagoryID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Catagory">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                         <asp:HiddenField ID="HidCatagory0" runat="server" 
                                                             value='<%# Eval("catagoryid") %>' />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <%--  <asp:TemplateField HeaderText="ProductID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Product">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                         <asp:HiddenField ID="HidProduct0" runat="server" 
                                                             value='<%# Eval("productid") %>' />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Quantity">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Unit Price">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Tax Percentage">
                                                     <ItemTemplate>
                                                         <asp:Label ID="Lbltaxid" runat="server" Text='<%# Eval("taxID") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="PO TaxAmount">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LbltaxAmount" runat="server" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO TotalAmount">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LbltotalAmount" runat="server" 
                                                             Text='<%# Eval("TT") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                
                                             </Columns>
                                         </asp:GridView>
                                         
                                <div class="span4 invoice-block pull-right" style="width:100%">
                                    <ul class="unstyled amounts">
                                        
                                        <li style="height:85px"> <div class="span4 invoice-block pull-left"  
                                                style="width:99%; height: 57px;"> Approved/Reject:<asp:DropDownList 
                                                ID="DrpAppRej" runat="server" Width="95px">
                                                <asp:ListItem Value="1">Select</asp:ListItem>
                                                <asp:ListItem Value="20">Accepted</asp:ListItem>
                                                <asp:ListItem Value="30">Rejected</asp:ListItem>
                                            </asp:DropDownList>
&nbsp;
                                            <asp:TextBox ID="Txt_AppRejReason" runat="server" Height="77px" 
                                                TextMode="MultiLine" Width="186px"></asp:TextBox>
                                            <asp:Button  ID="BtnAppRejSave" runat="server" ForeColor="Black"  
                                                class="btn-success" Text ="Save" onclick="BtnAppRejSave_Click"/>  </div> 
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
</asp:Content>

