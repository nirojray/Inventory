﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PurchaseOrderInvoiceApproval.aspx.cs" EnableEventValidation="false" Inherits="PurchaseOrderInvoiceApproval" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

                        <li><a href="PurchaseInvoice.aspx">Purchase Invoice Approval</a><span class="divider-last">&nbsp;</span></li>
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
                            <table id="tbldate" runat="server">
                                <tr>
                                    <td style="height: 38px">&nbsp;&nbsp;&nbsp; From Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                         <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" Width="30%"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" Move="True" />
                                    </td>
                                    <td style="height: 38px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        To Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" Width="30%"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        &nbsp&nbsp
                                        <asp:Button ID="BtnSearch" runat="server" Text="Search"
                                            OnClick="BtnSearch_Click" />
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                         <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red" Font-Size="Medium" ></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server">
                                <asp:GridView ID="GvwSalesRegister" runat="server" AutoGenerateColumns="False"
                                    class="table table-striped table-bordered table-advance table-hover"
                                    ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="PO_ID"
                                    OnRowCommand="GvwSalesRegister_RowCommand" AllowPaging="True" AllowSorting="True"
                                    OnPageIndexChanging="GvwSalesRegister_PageIndexChanging" PageSize="5">
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
                                              <%--  <asp:HiddenField ID="HidLocationID" runat="server" Value='<%# Eval("locationID") %>' />--%>
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
                                    <table>
                                        <tr>
                                            <td class="input-mini" style="width: 75px">PO No.  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 
                                                <asp:TextBox ID="TxtPoNo" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                            <td style="width: 77px" class="input-mini">PO Date  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TxtPoDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="width: 168px">Total Amount &nbsp;
                                                 <asp:TextBox ID="TxtTotalAmount" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 75px">Location  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                                 <asp:TextBox ID="TxtPoLocation" runat="server" ReadOnly="True"
                                                     OnTextChanged="TxtLocation_TextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 77px">Supplier  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                                 <asp:TextBox ID="TxtPoSupplier" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                            <td style="width: 168px">Shipping Address
                                                <asp:TextBox ID="Txt_shippingAdress" runat="server" ReadOnly="True" TextMode="MultiLine" Width="60%" Height="80px"></asp:TextBox>
                                            </td>

                                        </tr>

                                    </table>
                                </div>


                                <asp:GridView ID="GvwPurchaseInvocie" runat="server" AutoGenerateColumns="False"
                                    class="table table-striped table-bordered table-advance table-hover"
                                    ShowHeaderWhenEmpty="True" Width="100%" ShowFooter="false" PageSize="5"
                                    AllowPaging="true" AllowSorting="true"
                                    OnPageIndexChanging="GvwPurchaseInvocie_PageIndexChanging"
                                    OnRowDeleting="GvwPurchaseInvocie_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Slno">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Catagory">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                <asp:HiddenField ID="HidCatagory0" runat="server" Value='<%# Eval("catagoryid") %>' />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                <asp:HiddenField ID="HidProduct0" runat="server" Value='<%# Eval("productid") %>' />
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
                                         <asp:TemplateField HeaderText="PO Price">
                                            <ItemTemplate>
                                                <asp:Label ID="LblPOPrice" runat="server" Text='<%# Eval("PoPrice") %>'></asp:Label>
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
                                                <asp:TextBox ID="TxtInQuantity" runat="server" Text='<%# Eval("PO_Quantity1") %>' Width="30Px" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice unit Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtInPrice" runat="server" Text='<%# Eval("PO_UnitPrice1") %>' Width="60Px" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Invoice Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtPrice" runat="server" Text='<%# Eval("InvcPrice") %>' Width="75Px" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Invoice Tax">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txttaxid" Width="75px" runat="server" Text='<%# Eval("taxID1") %>' ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Total Price">
                                            <ItemTemplate>
                                                <asp:Label ID="LblInvocietotalPrice" runat="server" Text='<%# Eval("TT1") %>' ReadOnly="true"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="BtnAdd" runat="server" OnClick="AddNewGridRow" Text="Update" ToolTip=" Add New Product" />

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
                                <br />
                                <div class="row-fluid" style="width: 100%">
                                    <div class="span4 invoice-block pull-right" style="width: 100%">
                                        <ul class="unstyled amounts">
                                            <li style="height: 150px">
                                                <div class="span4 invoice-block pull-left" style="width: 100%; height: 57px;">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>Invoice No &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="Txt_InvoiceNo" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                            <td>Invoice Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="Txt_InvoiceDate" runat="server" ReadOnly="True" ></asp:TextBox>                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>PO Total Amount &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="TxtInTotalAmount" runat="server"
                                                                         onkeypress="return isNumberKey(event)" Text="0.00" ReadOnly="True"></asp:TextBox>
                                                            </td>

                                                            <td>Invoice Total&nbsp; Amount &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="Txt_SubTotal" runat="server" Text="0.00" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"> Approve/Reject &nbsp;&nbsp;
                                                                <asp:DropDownList ID="ddlInvoiceApproval" runat="server" >
                                                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                                      <asp:ListItem Text="Approve" Value="1"></asp:ListItem>
                                                                      <asp:ListItem Text="Reject" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Button ID="BtnInvoiceSave0" runat="server" Width="80px"
                                                                    ForeColor="Black" OnClick="BtnInvoiceSave_Click" Text="Save" class="btn-success" />
                                                                 <asp:Button ID="BtnCancel" runat="server" Width="80px"
                                                                    ForeColor="Black" OnClick="BtnCancel_Click" Text="Cancel" class="btn-success" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <br />

                                                    &nbsp;&nbsp;
                                                </div>
                                                &nbsp;&nbsp; </li>
                                        </ul>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <asp:HiddenField ID="hidDetails_ID" runat="server" />

                           
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

