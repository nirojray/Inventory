﻿<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" enableeventvalidation="false" inherits="PurchaseOrder, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        //        $(document).ready(function () {
        //            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(SendMails);
        //            SendMails();
        //        });

        //        function SendMails() {
        //            $("input[id*=BtnAdd]").click(function () {
        //                $("input[id*=GvwPurchaseOrder] tr").after('<tr><td>column1 value</td><td>column2 value</td></tr>');
        //            });
        //        }
    </script>
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

        }
        function DrpTaxValueChanged() {
            var e = document.getElementById("DrpTaxType");
            var v = e.options[e.selectedIndex].value;
            alert("The value is: " + v);
        }
  
    </script>
    <script type="text/javascript">
        function validate_this() {

            return confirm('Do you wish to continue');
        }
    </script>
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
                        <li><a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li><a href="#">Purchase</a><span class="divider">&nbsp;</span> </li>
                        <li><a href="PurchaseOrder.aspx">Purchase Order</a><span class="divider-last">&nbsp;</span></li>
                    </ul>
                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title" style="height: 50px">
                            <h4>
                                <img src="img/shopping_cart.png" width="32" height="32" />
                                Purchase Order</h4>
                            <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                        </div>
                        <div class="widget-body">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        Reason For Purchase<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DrpReason" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="--Select Reason--" Value="-1" Selected="true"></asp:ListItem>
                                        </asp:DropDownList>
                                      

                                    </td>
                                    <td>
                                        Purchase Order Date<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <form action="#" class="form-horizontal form-row-seperated">
                                        <div class="controls">
                                            <asp:TextBox ID="txtLoggedIn_Date" runat="server" MaxLength="50" Width="30%"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" ShowErrorMessage="False" Separator="-"
                                                Format="dd mmm yyyy" Control="txtLoggedIn_Date" KeepInside="False"></rjs:PopCalendar>
                                        </div>
                                        </form>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Location<span style="color: Red">*</span>
                                
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DrpLocation" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="--Select Location--" Value="-1" Selected="true"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Supplier<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DrpSupplier" runat="server" >
                                        
                                        </asp:DropDownList>
                                          <asp:CascadingDropDown ID="CascadingSupplier" runat="server" Category="Supplier" TargetControlID="DrpSupplier" ParentControlID="DrpLocation" 
                                 LoadingText="Loading Supplier..."  ServiceMethod="BindSupplier" ServicePath="~/WebService.asmx"></asp:CascadingDropDown>
                                        
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="GvwPurchaseOrder" class="table table-striped table-bordered table-advance table-hover"
                                runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                ShowFooter="True" OnRowDeleting="GvwPurchaseOrder_RowDeleting" OnSelectedIndexChanged="GvwPurchaseOrder_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CatagoryID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCatagoryID" runat="server" Text='<%# Eval("CatagoryID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Catagory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("Catagory") %>'></asp:Label>
                                            <asp:HiddenField ID="HidCatagory" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="DrpCatagory" runat="server" Width="175px" AppendDataBoundItems="True">
                                               <asp:ListItem Text="--Select Category--" Value="-1" Selected="true"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ProductID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product" ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="DrpProduct" runat="server" Width="100%"  >
                                            
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="CascadingProduct" runat="server" Category="Supplier" TargetControlID="DrpProduct"
                                                ParentControlID="DrpCatagory" LoadingText="Loading Product..." ServiceMethod="BindProduct"
                                                ServicePath="~/WebService.asmx">
                                            </asp:CascadingDropDown>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtQuantity" runat="server" Width="50px" onkeypress="return isNumberKey(event)" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtPrice" runat="server" Width="100px"  onkeypress="return isNumberKey(event)" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LbltotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TaxID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTaxID" runat="server" Text='<%# Eval("TaxID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTaxAmount" runat="server" Text='<%# Eval("TaxAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                             <asp:DropDownList ID="DrpTaxType" runat="server" AutoPostBack="False">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="DrpTaxType_CascadingDropDown" runat="server" Category="Supplier"
                                            TargetControlID="DrpTaxType" ParentControlID="DrpCatagory" LoadingText="Loading Tax..."
                                            ServiceMethod="BindTAX" ServicePath="~/WebService.asmx">
                                        </asp:CascadingDropDown>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TotalAmountPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                           <asp:Button ID="BtnAdd" class="btn-success" runat="server" Text="Add" OnClick="AddNewGridRow"
                                                ToolTip=" Add New Product" /> 
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="row-fluid" style="width: 100%">
                            <div class="span4 invoice-block pull-right" style="width: 100%">
                                <ul class="unstyled amounts">
                                    <li style="height: 35px"><strong>Total&nbsp; :</strong>
                                        <asp:Label ID="LblSubTotal" runat="server" Text="0.00"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
                                             <li style="height: 135px">
                                             
                                                 <table style="width: 100%">
                                                     <tr>
                                                         <td colspan="4">
                                                             Raised To:<span style="color: Red">*</span><asp:TextBox ID="txt_PO_RaisedTo" runat="server"></asp:TextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td style="width: 1083px">
                                                             &nbsp;</td>
                                                         <td style="width: 147px">
                                                             &nbsp;</td>
                                                         <td class="input-small" style="width: 204px">
                                                             Shipping Address:<span style="color: Red">*</span></td>
                                                         <td>
                                                             <asp:DropDownList ID="drp_Shipping" runat="server" AppendDataBoundItems="True">
                                                              <asp:ListItem Text="--Select Shipping Address--" Value="-1" Selected="true"></asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td style="height: 22px; width: 1083px">
                                                             </td>
                                                         <td style="height: 22px; width: 147px">
                                                             </td>
                                                         <td style="height: 22px; width: 204px">
                       
                                                             Billing Address:<span style="color: Red">*</span></td>
                                                         <td style="height: 22px">
                                      <asp:DropDownList ID="drp_Biiling" runat="server" AppendDataBoundItems="True">
                                       <asp:ListItem Text="--Select Billing Address--" Value="-1" Selected="true"></asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td style="width: 1083px">
                                                             &nbsp;</td>
                                                         <td style="width: 147px">
                                                             &nbsp;</td>
                                                         <td class="input-small" style="width: 204px">
                                                             &nbsp;</td>
                                                         <td>
                                                             &nbsp;</td>
                                                     </tr>
                                                 </table>
                                             
                                             </li>
                                    <li style="height: 35px">
                                        <div class="span4 invoice-block pull-left" style="width: 50%">
                                            <asp:Button ID="BtnPurchaseOrderClear" runat="server" ForeColor="Black" class="btn-success"
                                                Text="Clear Purchase Order" OnClick="BtnPurchaseOrderClear_Click" />
                                            &nbsp;
                                            <asp:Button ID="BtnPurchaseOrderSave" runat="server" ForeColor="Black" class="btn-success"
                                                Text="Save Purchase Order" 
                                                OnClick="BtnPurchaseOrderSave_Click" />
                                        </div>
                                        </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>
            <!-- END PAGE CONTENT-->
        </div>
        <!-- END PAGE CONTAINER-->
        <!-- END JAVASCRIPTS -->
    </div>
</asp:Content>
