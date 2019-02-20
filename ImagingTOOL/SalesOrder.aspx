<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SalesOrder.aspx.cs" Inherits="Sales_Order" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />
    <link href="Styles/black.css" rel="stylesheet" />
    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>
    <style type="text/css">
        .GridDock {
            overflow-x: auto;
            overflow-y: hidden;
            width: 200px;
            padding: 0 0 17px 0;
        }
       input[type="checkbox"]+label{
            display:inline!important;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("[id$='_ddlBillingAddress']").customselect();
            });
        });

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth').width($('#dvScreenWidth').width());
        });
    </script>


    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(SendMails);
            SendMails();
        });

        function SendMails() {
            $("input[id*=BtnAdd]").click(function () {
                $("input[id*=GvwPurchaseOrder] tr").after('<tr><td>column1 value</td><td>column2 value</td></tr>');
            });
        }
    </script>
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

        }

        function isNumberKey1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            else {
                var len = $('.CssTxtPrice').val().length;
                var index = $('.CssTxtPrice').val().indexOf('.');

                if (index > 0 && charCode == 46) {
                    return false;
                }
                if (index > 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 3) {
                        return false;
                    }
                }

            }
            return true;
        }





        function DrpTaxValueChanged() {
            var e = document.getElementById("DrpTaxType");
            var v = e.options[e.selectedIndex].value;
            alert("The value is: " + v);
        }
        function validateMandatoryADD() {
            if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {
                alert("Please Select State");
                document.getElementById('<%=ddlState.ClientID %>').focus();
                return false;
            }

            else if (document.getElementById('<%=DrpLocation.ClientID%>').selectedIndex == 0) {
                alert("Please Select Location");
                document.getElementById('<%=DrpLocation.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddltype.ClientID%>').selectedIndex == 0) {
                alert("Please Select Type");
                document.getElementById('<%=ddltype.ClientID %>').focus();
                return false;
            }

            else if (document.getElementById('<%=ddlSalesType.ClientID%>').selectedIndex == 0) {

                alert("Please Select Sales Type");
                document.getElementById('<%=ddlSalesType.ClientID %>').focus();
                return false;
            }
        }
        function validateMandatory() {
            if (document.getElementById('<%=DrpSupplier.ClientID%>').selectedIndex == 0) {

                alert("Please Select Customer");
                document.getElementById('<%=DrpSupplier.ClientID %>').focus();
                return false;
            }            
            else if (document.getElementById('<%=txtSO_Date.ClientID %>').value == "") {
                alert("Please Enter Sales Order Date");
                document.getElementById('<%=txtSO_Date.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=DrpVertical.ClientID%>').selectedIndex == 0) {
                alert("Please Select Vertical");
                document.getElementById('<%=DrpVertical.ClientID %>').focus();
                return false;
            }
            <%--else if (document.getElementById('<%=txtVatCst.ClientID %>').value == "") {
                alert("Please Enter GST No");
                document.getElementById('<%=txtVatCst.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtPAN.ClientID %>').value == "") {
                alert("Please Enter PAN");
                document.getElementById('<%=txtPAN.ClientID %>').focus();
                return false;
            }--%>
            else if (document.getElementById('<%=ddlCreditPeriod.ClientID%>').selectedIndex == 0) {

                alert("Please Select CreditPeriod");
                document.getElementById('<%=ddlCreditPeriod.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {
                alert("Please Select State");
                document.getElementById('<%=ddlState.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=DrpLocation.ClientID%>').selectedIndex == 0) {
                alert("Please Select Location");
                document.getElementById('<%=DrpLocation.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=Txt_CusOrdno.ClientID %>').value == "") {
                alert("Please Enter Customer Order Number");
                document.getElementById('<%=Txt_CusOrdno.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtcustordDate.ClientID %>').value == "") {
                alert("Please Enter Customer Order Date");
                document.getElementById('<%=txtcustordDate.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddltype.ClientID%>').selectedIndex == 0) {
                alert("Please Select Main Category");
                document.getElementById('<%=ddltype.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlSalesType.ClientID%>').selectedIndex == 0) {

                alert("Please Select Sales Type");
                document.getElementById('<%=ddlSalesType.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlRepresentative.ClientID%>').selectedIndex == 0) {
                alert("Please Select Representative");
                document.getElementById('<%=ddlRepresentative.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlWarranty.ClientID%>').selectedIndex == 0) {

                alert("Please Select Warranty");
                document.getElementById('<%=ddlWarranty.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtBillingAddress.ClientID %>').value == "") {
                alert("Please Enter Billing Address");
                document.getElementById('<%=txtBillingAddress.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtShippingAddress.ClientID %>').value == "") {
                alert("Please Enter Shipping Address");
                document.getElementById('<%=txtShippingAddress.ClientID %>').focus();
                return false;
            }

        }
    </script>
    <script type="text/javascript">

        function Sum(thisctrol) {

            var $row = $(thisctrol).parent().parent();
            var Rebate = $("[id*='TxtQuantity']", $row).val();
            var Sales = $("[id*='TxtPrice']", $row).val();

            if (Rebate != '' || Sales != '') {

                var x = parseFloat(Rebate);
                var y = parseFloat(Sales);
                $("[id*='LblfttotalPrice']", $row).html((x * y).toFixed(2));
            }

        }

    </script>





    <script src="web/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script>
        function validate_this() {

            return confirm('Do you wish to continue');
        }
    </script>
    <style type="text/css">
        .dropmenuScroll {
            overflow-y: scroll;
            width: 300px;
        }

        .scrollable {
            overflow: auto;
            width: 250px; /* adjust this width depending to amount of text to display */
            height: 60px; /* adjust height depending on number of options to display */
            border: 1px silver solid;
        }

        .scrollable1 {
            overflow: auto;
            width: 500px; /* adjust this width depending to amount of text to display */
            height: 70px; /* adjust height depending on number of options to display */
            border: 1px silver solid;
        }
    </style>
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

                        <li><a href="SalesOrder.aspx">&nbsp;Sales Order</a><span class="divider-last">&nbsp;</span></li>
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
                                Sales Order</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>

                            </span>
                        </div>
                        <div class="widget-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                             <td>Customer Name<span style="color: Red">*</span></td>
                                            <td style="margin-left: 40px">
                                                <asp:DropDownList ID="DrpSupplier" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DrpSupplier_SelectedIndexChanged">
                                                   <%-- <asp:ListItem Text="--Select Customer--" Value="0" Selected="true"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td>Sales Order Date<span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <form action="#" class="form-horizontal form-row-seperated">

                                                    <div class="controls">

                                                        <asp:TextBox ID="txtSO_Date" runat="server" MaxLength="50" Width="100px" ReadOnly="True"></asp:TextBox>
                                                        <asp:CalendarExtender ID="PopCalendar1" runat="server" TargetControlID="txtSO_Date"
                                                            Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgSO_Date">
                                                        </asp:CalendarExtender>
                                                        <asp:Image ID="ImgSO_Date" runat="server" ImageUrl="~/images/calendar.png" />
                                                        <%--<rjs:PopCalendar ID="PopCalendar1" runat="server" ShowErrorMessage="False" Separator="-"
                                                            Format="dd mmm yyyy" Control="txtSO_Date"></rjs:PopCalendar>--%>
                                                    </div>
                                                </form>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Vertical<span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DrpVertical" Width="220px" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="DrpVertical_SelectedIndexChanged" AutoPostBack="false" Enabled="false">
                                                   <%-- <asp:ListItem Text="--Select Vertical--" Value="0" Selected="true"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtVertical" Visible="false" runat="server" MaxLength="50" Width="30%"></asp:TextBox>
                                            </td>

                                           
                                            <td>Customer State</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustState" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>GST No</td>
                                            <td>
                                                <asp:TextBox ID="txtVatCst" runat="server" ReadOnly="true"></asp:TextBox>

                                            </td>
                                            <td>PAN</td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="txtPAN" runat="server" MaxLength="50" Width="100px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Reverse Charge</td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="txtReverseCharge" runat="server" MaxLength="50" Width="100px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Mode Of/Term Of Payment/Credit Period<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlCreditPeriod" runat="server" Width="180px">
                                                </asp:DropDownList>

                                            </td>
                                        </tr>

                                        <tr>

                                            <td>State<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlState" Width="220px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>Location<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="DrpLocation" Width="180px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>CustomerOrder No<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="Txt_CusOrdno" runat="server"></asp:TextBox>
                                            </td>
                                            <td>CustomerOrder Date<span style="color: Red">*</span></td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="txtcustordDate" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                <asp:CalendarExtender ID="PopCalendar2" runat="server" TargetControlID="txtcustordDate"
                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgcustordDate">
                                                </asp:CalendarExtender>
                                                <asp:Image ID="ImgcustordDate" runat="server" ImageUrl="~/images/calendar.png" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Main Category<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddltype" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>Sales Type<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlSalesType" Width="180px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Representative<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlRepresentative" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td id="tdwarrenty" runat="server">Warranty<span style="color: Red">*</span></td>
                                            <td style="margin-left: 40px" id="tdwarrenty1" runat="server">
                                                <asp:DropDownList ID="ddlWarranty" runat="server" Width="220px">
                                                </asp:DropDownList>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td runat="server">Terms Of Delivery<span style="color: Red">*</span></td>
                                            <td style="margin-left: 40px" id="td2" runat="server">
                                                <%-- <asp:DropDownList ID="ddlTermsOfDelievery" runat="server" Width="220px">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="TxtTermsOfDelivery" runat="server" Width="220px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHSN_SAC_Code" runat="server"></asp:Label>
                                            </td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="TxtHSN_SAC_Code" runat="server" MaxLength="50" Width="100px" Visible="false" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>

                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div id="dvScreenWidth" visible="false" style="width: 100%">
                                        <div class="GridDock" id="dvGridWidth" style="width: 100%">
                                            <asp:GridView ID="GvwSalesOrder" class="table table-striped table-bordered table-advance table-hover"
                                                runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                                ShowFooter="True" OnRowDeleting="GvwPurchaseOrder_RowDeleting" OnSelectedIndexChanged="GvwPurchaseOrder_SelectedIndexChanged" OnRowDataBound="GvwSalesOrder_RowDataBound">
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
                                                            <asp:DropDownList ID="DrpCatagory" runat="server" Width="175px" AppendDataBoundItems="True" OnSelectedIndexChanged="DrpCatagory_SelectedIndexChanged" AutoPostBack="True">
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
                                                            <div class="scrollable">
                                                                <asp:DropDownList ID="DrpProduct" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DrpProduct_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Current Stock">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurntStock" runat="server" Text='<%#Eval("CurntStock") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblFtCurntStock" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Product Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("SO_Product_Description") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TxtDescription" runat="server" Width="211px" Height="60px" TextMode="MultiLine" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="10%" />
                                                        <ItemStyle Width="10%" />
                                                    </asp:TemplateField>

                                                    <%--  narender added on 30 May 2017--%>

                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblFrmDate" runat="server" Width="130px" Text='<%# Eval("FromDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TxtFrmDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                            <asp:CalendarExtender ID="clndrStdFrmDate" runat="server" TargetControlID="TxtFrmDate"
                                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgFrom">
                                                            </asp:CalendarExtender>
                                                            <asp:Image ID="ImgFrom" runat="server" ImageUrl="~/images/calendar.png" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100%" />
                                                        <ItemStyle Width="60%" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblToDate" runat="server" Width="130px" Text='<%# Eval("ToDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TxtToDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                            <asp:CalendarExtender ID="clndrStdToDate" runat="server" TargetControlID="TxtToDate"
                                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgTo">
                                                            </asp:CalendarExtender>
                                                            <asp:Image ID="ImgTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                        </FooterTemplate>
                                                        <FooterStyle Width="100%" />
                                                        <ItemStyle Width="60%" />
                                                    </asp:TemplateField>
                                                    <%-- End narender added on 30 May 2017--%>

                                                    <asp:TemplateField HeaderText="Quantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TxtQuantity" runat="server" Width="50px" onkeypress="return isNumberKey(event)" onkeyup='Sum(this)' onchange="Sum(this)" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Price">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TxtPrice" runat="server" Width="100px" CssClass="CssTxtPrice" onkeypress="javascript:return isNumberKey1(event)" onkeyup='Sum(this)' onchange="Sum(this)" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Price">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LbltotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="LblfttotalPrice" runat="server"></asp:Label>
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
                                                            <div class="scrollable">
                                                                <asp:DropDownList ID="DrpTaxType" runat="server">
                                                                </asp:DropDownList>
                                                                <%-- <asp:CascadingDropDown ID="DrpTaxType_CascadingDropDown" runat="server" Category="Supplier"
                                                TargetControlID="DrpTaxType" ParentControlID="DrpCatagory" LoadingText="Loading Tax..."
                                                ServiceMethod="BindSTAX" ServicePath="~/WebService.asmx">
                                            </asp:CascadingDropDown>--%>
                                                            </div>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Price">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TotalAmountPrice") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button ID="BtnAdd" class="btn-success" runat="server" Text="Add" OnClick="BtnAdd_Click" OnClientClick="return validateMandatoryADD();"
                                                                ToolTip=" Add New Product" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="40px"  /></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                        <FooterStyle Width="10%" />
                                                        <ItemStyle Width="90px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="row-fluid" style="width: 100%">
                            <div class="span4 invoice-block pull-right" style="width: 100%">
                                <ul class="unstyled amounts">
                                    <li style="height: 35px">

                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td><strong>Total&nbsp; :</strong>
                                                            <asp:Label ID="LblSubTotal" runat="server" Text="0.00"></asp:Label>
                                                          
                                                        </td>
                                                        <td align="center">

                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="CheckBox1" style="display:inline;" runat="server" Text=" Is shipping address same as billing address" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                        </td>
                                                    </tr>

                                                </table>

                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                           <table><tr>
                                               <td> </td>
                                                  </tr></table>
                                         
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                    </li>
                              
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 100%" border="1">
                                                <tr>
                                                    <td>
                                                        <div class="scrollable1">
                                                            <b>Billing Address</b>
                                                            <asp:DropDownList ID="ddlBillingAddress" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBillingAddress_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="scrollable1">
                                                            <b>Shipping Address</b>
                                                            <asp:DropDownList ID="ddlShippingAddress" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShippingAddress_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtBillingAddress" runat="server" ReadOnly="false" TextMode="MultiLine" Width="60%" Height="80px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtShippingAddress" runat="server" ReadOnly="false" TextMode="MultiLine" Width="60%" Height="80px"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <li style="height: 35px">
                                        <div class="span4 invoice-block pull-left" style="width: 50%">
                                            <asp:Button ID="BtnPurchaseOrderSave" runat="server" ForeColor="Black" class="btn-success"
                                                Text="Save Sales Order" OnClientClick="return validateMandatory();" OnClick="BtnPurchaseOrderSave_Click1" />
                                            &nbsp;
                                            <asp:Button ID="BtnPurchaseOrderClear" runat="server" ForeColor="Black" class="btn-success"
                                                Text="Clear Sales Order" OnClick="BtnPurchaseOrderClear_Click" />


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

