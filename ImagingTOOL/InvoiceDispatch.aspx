<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="InvoiceDispatch.aspx.cs" Inherits="InvoiceDispatch" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function validateMandatory() {
            if (document.getElementById('<%=ddlDispatchDetails.ClientID%>').selectedIndex == 0) {
                alert("Please Select Dispatch Details");
                document.getElementById('<%=ddlDispatchDetails.ClientID %>').focus();
                return false;
            }


            else if (document.getElementById('<%=Txt_Dispatch_Date.ClientID %>').value == "") {
                alert("Please Enter Dispatch Date");
                document.getElementById('<%=Txt_Dispatch_Date.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtAWBNo.ClientID %>').value == "") {
                alert("Please Enter AWBNo");
                document.getElementById('<%=txtAWBNo.ClientID %>').focus();
                return false;
            }
           <%-- else if (document.getElementById('<%=Txt_DateOfDelivery.ClientID %>').value == "") {
                alert("Please Enter Date Of Delivery");
                document.getElementById('<%=Txt_DateOfDelivery.ClientID %>').focus();
                return false;
            }--%>

           <%-- else if (document.getElementById('<%=txtdateofinst.ClientID %>').value == "") {
                alert("Please Enter Date Of Installation");
                document.getElementById('<%=txtdateofinst.ClientID %>').focus();
                return false;
            }--%>



            var DateofDispatch = document.getElementById('<%=Txt_Dispatch_Date.ClientID %>').value

            var DateofDelivery = document.getElementById('<%=Txt_DateOfDelivery.ClientID %>').value

            var DateofInst = document.getElementById('<%=txtdateofinst.ClientID %>').value

            var DateofSO = document.getElementById('<%=TxtSODate.ClientID %>').value

            var DispatchDate = new Date(DateofDispatch);
            var DeliveryDate = new Date(DateofDelivery);
            var InstallationDate = new Date(DateofInst);
            var SODate = new Date(DateofSO);
            if (DispatchDate != '' && DeliveryDate != '' && InstallationDate != '') {

                if (SODate > DispatchDate) {
                    alert("Please ensure that the Dispatch Date is greater than or equal to the SO Date.");
                    return false;
                }

                else if (DispatchDate > DeliveryDate) {
                    alert("Please ensure that the Delivery Date is greater than or equal to the Dispatch Date.");
                    return false;
                }

                else if (DeliveryDate > InstallationDate) {
                    alert("Please ensure that the Installation Date is greater than or equal to the Dispatch Date and Delivery Date.");
                    return false;
                }

                //}
                if (document.getElementById('<%=ddlDispatchDetails.ClientID%>').selectedIndex != 0) {
                    if (document.getElementById('<%=ddlTransporter.ClientID%>').selectedIndex == 0) {
                        alert("Please Select Transporter");
                        document.getElementById('<%=ddlTransporter.ClientID %>').focus();
                        return false;
                    }
                }
            }
        }
    </script>
     <style type="text/css">        
        .GridDock1 {
            overflow-x: auto;
            overflow-y: auto;
            width: 200px;
            height:400px;
            padding: 0 0 17px 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth1').width($('#dvScreenWidth1').width());
        });
    </script>
    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Billing
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>
                            <a href="#">Billing</a><span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="InvoiceDispatch.aspx">Invoice Dispatch Details</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Invoice Dispatch Details</h4>
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
                                    <td>From Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" Width="30%" ReadOnly="True"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                    </td>
                                    <td>To Date
                                    </td>
                                    <td>
                                        <div class="controls">
                                            <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" Width="30%" ReadOnly="True"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate"
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnSearch" class="btn-success" runat="server" Text="Search"
                                            OnClick="BtnSearch_Click" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td></td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <asp:Panel ID="Panel2" runat="server">
                                <div id="dvScreenWidth1" visible="false" style="width: 100%">
                              <div class="GridDock1" id="dvGridWidth1" style="width: 100%">
                                <asp:GridView ID="GvwMatDispatch" runat="server" AutoGenerateColumns="False"
                                    class="table table-striped table-bordered table-advance table-hover"
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="SO_ID"
                                    AllowPaging="false"
                                    AllowSorting="True" OnRowCommand="GvwMatDispatch_RowCommand" OnPageIndexChanging="GvwMatDispatch_PageIndexChanging">
                                    <Columns>
                                        <%--  <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="SO NO" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("SO_Number") %>'></asp:Label>

                                                <asp:Label ID="hidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SO Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("SoDate") %>'></asp:Label>
                                                <asp:HiddenField ID="HidCatagory" runat="server" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DC No" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDCNO" runat="server" Text='<%# Eval("DC_no") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DC Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDCdate" runat="server" Text='<%# Eval("DC_Date") %>'></asp:Label>

                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvNO" runat="server" Text='<%# Eval("Invoice_Number") %>'></asp:Label>
                                                 <asp:Label ID="hidennInvcID" runat="server" Text='<%# Eval("Invoice_Id") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvdate" runat="server" Text='<%# Eval("InvocieDate") %>'></asp:Label>

                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vertical" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblVertical" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblstate" runat="server" Text='<%# Eval("[State]") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("[Location]") %>'></asp:Label>
                                                <%--       <asp:HiddenField ID="HidLocationID" runat="server"  value='<%# Eval("locationID") %>'/>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Type" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSalesType" runat="server" Text='<%# Eval("SalesType") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <asp:Label ID="LblCustomer" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Order No">
                                            <ItemTemplate>
                                                <asp:Label ID="LblCustomerOrderNo" runat="server" Text='<%# Eval("CusutomerOrderNO") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Order Date">
                                            <ItemTemplate>
                                                <asp:Label ID="LblCustomerOrderDate" runat="server" Text='<%# Eval("CusutomerOrderdate") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Price">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("SO_NetAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Entered By">
                                            <ItemTemplate>
                                                <asp:Label ID="LblEnteredby" runat="server" Text='<%# Eval("Enteredby") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entered On">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSO_EnteredOn" runat="server" Text='<%# Eval("SO_EnteredOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <%-- <asp:LinkButton ID="lnkLink" runat="server" 
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Edit1" 
                                                ToolTip="Edit"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>--%>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                    CommandName="Edit1">Edit</asp:LinkButton>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                  </div></div>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                             <td>Customer</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustomer" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Sales Order Date
                                            </td>
                                            <td>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtSOID" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="TxtSODate" runat="server" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>State<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                            <td>Location</td>
                                            <td>
                                                <asp:TextBox ID="TxtLocation" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Sales Type</td>
                                            <td>
                                                <asp:TextBox ID="txtsalesType" runat="server" ReadOnly="True"></asp:TextBox>

                                            </td>
                                            <td>Vertical
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtVertical" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                            <td>Customer Order No</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustmerOrderno" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Customer Order Date</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustmerOrderdate" runat="server" ReadOnly="True"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Credit Period<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtCreditPeriod" runat="server" ReadOnly="True"></asp:TextBox>


                                            </td>
                                            <td>Warranty<span style="color: Red">*</span></td>
                                            <td>

                                                <asp:TextBox ID="txtWarranty" runat="server" ReadOnly="True"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Representative<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtRepresentative" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Type<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txttype" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>DC Number<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtDCNo" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>DC Date<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtDCDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Invoice Number<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtInvNo" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Invoice Date<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtInvDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <table border="1">
                                        <tr>
                                            <td style="height: 22px; width: 75px;">Billing Adress</td>
                                            <td style="width: 75px">ShippingAddress</td>
                                        </tr>
                                        <tr>
                                            <td><span class="style4">
                                                <asp:TextBox ID="TxtBillingAddress" runat="server" ReadOnly="True" Width="60%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                            </span>
                                            </td>
                                            <td>
                                                <span class="style4">
                                                    <asp:TextBox ID="TxtShippingAddress" runat="server" ReadOnly="True" Width="60%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <asp:GridView ID="GvwSaleseOrderDetails" runat="server"
                                        AutoGenerateColumns="False" DataKeyNames="SO_ID"
                                        class="table table-striped table-bordered table-advance table-hover"
                                        ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="false"  AllowSorting="True" OnRowDataBound="GvwSaleseOrderDetails_OnRowDataBound" OnPageIndexChanging="GvwSaleseOrderDetails_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Catagory">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidCatagory0" runat="server"
                                                        Value='<%# Eval("SO_Catagory_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidProduct0" runat="server"
                                                        Value='<%# Eval("SO_Product_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Product Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("SO_Product_Description") %>'></asp:Label>
                                                    </ItemTemplate>                                                   
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="From Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                                                    </ItemTemplate>                                                   
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="To Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                                                    </ItemTemplate>                                                   
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SO Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Unit Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSOPrice" runat="server" Text='<%# Eval("SubTot") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTaxName" runat="server" Text='<%# Eval("TaxName") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle Width="20%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tax Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTaxAmount" runat="server" Text='<%# Eval("TaxAmt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TotalAmt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="row-fluid" style="width: 100%">

                                    <div class="span4 invoice-block pull-right" style="width: 100%">
                                        <ul class="unstyled amounts">

                                            <li>Total Amount:<asp:Label ID="Lbl_TotalAmount" runat="server" Text="0.00"></asp:Label>&nbsp;
                                                <table border="1px" frame="box">
                                                </table>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table border="1">

                                            <tr>

                                                <td class="input-medium" style="width: 120px">Dispatch Details</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlDispatchDetails" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDispatchDetails_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </td>
                                                <td class="input-small" style="width: 120px">Dispatch Date</td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Dispatch_Date" runat="server" ReadOnly="True"></asp:TextBox>
                                                    <rjs:PopCalendar ID="PopCalendar5" runat="server" Control="Txt_Dispatch_Date"
                                                        Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="input-small" style="width: 100px">AWB Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtAWBNo" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="input-medium" style="width: 100px">Date Of Delivery</td>
                                                <td>
                                                    <asp:TextBox ID="Txt_DateOfDelivery" runat="server" ReadOnly="True"></asp:TextBox>
                                                    <rjs:PopCalendar ID="PopCalendar6" runat="server" Control="Txt_DateOfDelivery"
                                                        Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="input-medium" style="width: 100px">Date Of Installation</td>
                                                <td>
                                                    <asp:TextBox ID="txtdateofinst" runat="server" ReadOnly="True"></asp:TextBox>
                                                    <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="txtdateofinst"
                                                        Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                                </td>
                                                <td class="input-small" style="width: 160px" id="td1" runat="server" visible="false">Name Of Transporter</td>
                                                <td id="td2" runat="server" visible="false">
                                                    <asp:DropDownList ID="ddlTransporter" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>

                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />
                                <table>
                                    <tr>

                                        <td align="center" class="input-medium" style="width: 170px">
                                            <asp:Button ID="BtnSave" runat="server" Text="Save"
                                                Width="60px" OnClick="BtnSave_Click" OnClientClick="return validateMandatory();" />
                                            &nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                        </td>

                                    </tr>

                                </table>
                                <br />
                                <asp:HiddenField ID="hidDetails_ID" runat="server" />
                                <asp:HiddenField ID="familyhidden" runat="server" />

                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            </asp:Panel>

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



