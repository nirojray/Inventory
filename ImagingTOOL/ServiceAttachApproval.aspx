<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ServiceAttachApproval.aspx.cs" Inherits="ServiceAttachApproval_" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .btnStyle {
            border-radius: 12px;
            height: 200px;
            width: 120px;
        }
    </style>
    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>

    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <%--<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });   

</script>--%>

    <script type="text/javascript">
        function CheckValidation() {
            var txtEndusername = document.getElementById('<%=txtEndusername.ClientID %>')
            var txtResellerName = document.getElementById('<%=txtResellerName.ClientID %>')
            var txtDistributorName = document.getElementById('<%=txtDistributorName.ClientID %>')
            var ddlSupplier = document.getElementById('<%=ddlSupplier.ClientID %>')
            var ddlType = document.getElementById('<%=ddlType.ClientID %>')
            var ddlCatagory = document.getElementById('<%=ddlCatagory.ClientID %>')
            var ddlproduct = document.getElementById('<%=ddlproduct.ClientID %>')
            var txtQuantity = document.getElementById('<%=txtQuantity.ClientID %>')
            var txtperiodStdYear = document.getElementById('<%=txtperiodStdYear.ClientID %>')
            var txtCompetitorname = document.getElementById('<%=txtCompetitorname.ClientID %>')

            var txtUPSWOutdcntDistributorprice = document.getElementById('<%=txtUPSWOutdcntDistributorprice.ClientID %>')
            var txtUPSWOutdcntResellerPrice = document.getElementById('<%=txtUPSWOutdcntResellerPrice.ClientID %>')
            var txtUPSWOutdcntEndUserPrice = document.getElementById('<%=txtUPSWOutdcntEndUserPrice.ClientID %>')

            var txtUPSWithdcntDistributorprice = document.getElementById('<%=txtUPSWithdcntDistributorprice.ClientID %>')
            var txtUPSWithdcntResellerPrice = document.getElementById('<%=txtUPSWithdcntResellerPrice.ClientID %>')
            var txtUPSWithdcntEndUserPrice = document.getElementById('<%=txtUPSWithdcntEndUserPrice.ClientID %>')

            var txtUSAWOutdcntDistributorprice = document.getElementById('<%=txtUSAWOutdcntDistributorprice.ClientID %>')
            var txtUSAWOutdcntResellerPrice = document.getElementById('<%=txtUSAWOutdcntResellerPrice.ClientID %>')
            var txtUSAWOutdcntEndUserPrice = document.getElementById('<%=txtUSAWOutdcntEndUserPrice.ClientID %>')

            var txtUSAWithdcntDistributorprice = document.getElementById('<%=txtUSAWithdcntDistributorprice.ClientID %>')
            var txtUSAWithdcntResellerPrice = document.getElementById('<%=txtUSAWithdcntResellerPrice.ClientID %>')
            var txtUSAWithdcntEndUserPrice = document.getElementById('<%=txtUSAWithdcntEndUserPrice.ClientID %>')

          <%--  var TxtWarrantyDate = document.getElementById('<%=TxtWarrantyDate.ClientID %>')--%>



            if (txtEndusername.value == "") {
                alert("Please Enter EndUser Name");
                document.getElementById('<%=txtEndusername.ClientID %>').focus();
                 return false;
             }
             else if (txtResellerName.value == "") {
                 alert("Please Enter Reseller Name");
                 document.getElementById('<%=txtResellerName.ClientID %>').focus();
                 return false;
             }
             else if (txtDistributorName.value == "") {
                 alert("Please Enter Distributor Name");
                 document.getElementById('<%=txtDistributorName.ClientID %>').focus();
                 return false;
             }
             else if (ddlSupplier.selectedIndex == 0) {
                 alert("Please Select Supplier");
                 document.getElementById('<%=ddlSupplier.ClientID %>').focus();
                 return false;
             }
             else if (ddlType.selectedIndex == 0) {
                 alert("Please Select Main Category");
                 document.getElementById('<%=ddlType.ClientID %>').focus();
                 return false;
             }
             else if (ddlCatagory.selectedIndex == 0) {
                 alert("Please Select Category");
                 document.getElementById('<%=ddlCatagory.ClientID %>').focus();
                 return false;
             }
             else if (ddlproduct.selectedIndex == 0) {
                 alert("Please Select Product");
                 document.getElementById('<%=ddlproduct.ClientID %>').focus();
                 return false;
             }
             else if (txtQuantity.value == "") {
                 alert("Please Enter Quantity");
                 document.getElementById('<%=txtQuantity.ClientID %>').focus();
                 return false;
             }
             else if (txtperiodStdYear.value == "") {
                 alert("Please Enter Total Period including Standard One year (INR)");
                 document.getElementById('<%=txtperiodStdYear.ClientID %>').focus();
                 return false;
             }
             else if (txtCompetitorname.value == "") {
                 alert("Please Enter Name of nearest Competitor offering Service Attach");
                 document.getElementById('<%=txtCompetitorname.ClientID %>').focus();
                 return false;
             }
             else if (txtUPSWOutdcntDistributorprice.value == "") {
                 alert("Please Enter Unit Product Sales Price Without Discount of Distributor Price(INR)");
                 document.getElementById('<%=txtUPSWOutdcntDistributorprice.ClientID %>').focus();
                 return false;
             }
             else if (txtUPSWOutdcntResellerPrice.value == "") {
                 alert("Please Enter Unit Product Sales Price Without Discount of Reseller Price(INR)");
                 document.getElementById('<%=txtUPSWOutdcntResellerPrice.ClientID %>').focus();
                 return false;
             }
             else if (txtUPSWOutdcntEndUserPrice.value == "") {
                 alert("Please Enter Unit Product Sales Price Without Discount of End User Price(INR)");
                 document.getElementById('<%=txtUPSWOutdcntEndUserPrice.ClientID %>').focus();
                 return false;
             }
             else if (txtUPSWithdcntDistributorprice.value == "") {
                 alert("Please Enter Unit Product Sales Price With Discount of Distributor Price(INR)");
                 document.getElementById('<%=txtUPSWithdcntDistributorprice.ClientID %>').focus();
                 return false;
             }
             else if (parseFloat(txtUPSWOutdcntDistributorprice.value) < parseFloat(txtUPSWithdcntDistributorprice.value)) {
                 alert("please Enter The Unit Product Sales Price With Discount of Distributor Price(INR) value is Less Than the Unit Product Sales Price Without Discount of Distributor Price(INR)   ");
                 document.getElementById('<%=txtUPSWithdcntDistributorprice.ClientID %>').focus();
                 return false;
             }

             else if (txtUPSWithdcntResellerPrice.value == "") {
                 alert("Please Enter Unit Product Sales Price With Discount of Reseller Price(INR)");
                 document.getElementById('<%=txtUPSWithdcntResellerPrice.ClientID %>').focus();
                 return false;
             }
             else if (parseFloat(txtUPSWOutdcntResellerPrice.value) < parseFloat(txtUPSWithdcntResellerPrice.value)) {
                 alert("Please Enter the Unit Product Sales Price With Discount of Reseller Price(INR) value is Less Than the  Unit Product Sales Price Without Discount of Reseller Price(INR)");
                 document.getElementById('<%=txtUPSWithdcntResellerPrice.ClientID %>').focus();
                 return false;
             }
             else if (txtUPSWithdcntEndUserPrice.value == "") {
                 alert("Please Enter Unit Product Sales Price With Discount of End User Price(INR)");
                 document.getElementById('<%=txtUPSWithdcntEndUserPrice.ClientID %>').focus();
                 return false;
             }
             else if (parseFloat(txtUPSWOutdcntEndUserPrice.value) < parseFloat(txtUPSWithdcntEndUserPrice.value)) {
                 alert("Please Enter the Unit Product Sales Price With Discount of End User Price(INR) value is Less Than the  Unit Product Sales Price Without Discount of End User Price(INR)");
                 document.getElementById('<%=txtUPSWithdcntEndUserPrice.ClientID %>').focus();
                 return false;
             }

             else if (txtUSAWOutdcntDistributorprice.value == "") {
                 alert("Please Enter Unit Service Attach Without Discount of Distributor Price(INR)");
                 document.getElementById('<%=txtUSAWOutdcntDistributorprice.ClientID %>').focus();
                 return false;
             }
             else if (txtUSAWOutdcntResellerPrice.value == "") {
                 alert("Please Enter Unit Service Attach Without Discount of Reseller Price(INR)");
                 document.getElementById('<%=txtUSAWOutdcntResellerPrice.ClientID %>').focus();
                 return false;
             }
             else if (txtUSAWOutdcntEndUserPrice.value == "") {
                 alert("Please Enter Unit Service Attach Without Discount of End User Price(INR)");
                 document.getElementById('<%=txtUSAWOutdcntEndUserPrice.ClientID %>').focus();
                 return false;
             }
             else if (txtUSAWithdcntDistributorprice.value == "") {
                 alert("Please Enter Unit Service Attach With Discount of Distributor Price(INR)");
                 document.getElementById('<%=txtUSAWithdcntDistributorprice.ClientID %>').focus();
                 return false;
             }
             else if (parseFloat(txtUSAWOutdcntDistributorprice.value) < parseFloat(txtUSAWithdcntDistributorprice.value)) {
                 alert("Please Enter Unit Service Attach With Discount of Distributor Price(INR) Value is Less then the Unit Service Attach Without Discount of Distributor Price(INR)");
                 document.getElementById('<%=txtUSAWithdcntDistributorprice.ClientID %>').focus();
                 return false;
             }

             else if (txtUSAWithdcntResellerPrice.value == "") {
                 alert("Please Enter Unit Service Attach With Discount of Reseller Price(INR)");
                 document.getElementById('<%=txtUSAWithdcntResellerPrice.ClientID %>').focus();
                 return false;
             }
             else if (parseFloat(txtUSAWOutdcntResellerPrice.value) < parseFloat(txtUSAWithdcntResellerPrice.value)) {
                 alert("Please Enter Unit Service Attach With Discount of Reseller Price(INR) Value is Less then the Unit Service Attach Without Discount of Reseller Price(INR)");
                 document.getElementById('<%=txtUSAWithdcntResellerPrice.ClientID %>').focus();
                 return false;
             }

             else if (txtUSAWithdcntEndUserPrice.value == "") {
                 alert("Please Enter Unit Service Attach With Discount of End User Price(INR)");
                 document.getElementById('<%=txtUSAWithdcntEndUserPrice.ClientID %>').focus();
                 return false;
             }
             else if (parseFloat(txtUSAWOutdcntEndUserPrice.value) < parseFloat(txtUSAWithdcntEndUserPrice.value)) {
                 alert("Please Enter Unit Service Attach With Discount of End User Price(INR) Value is Less then the Unit Service Attach Without Discount of End User Price(INR)");
                 document.getElementById('<%=txtUSAWithdcntEndUserPrice.ClientID %>').focus();
                 return false;
             }

           <%-- else if (TxtWarrantyDate.value == "") {
                 alert("Please select date prices valid for Warranty until");
                 document.getElementById('<%=TxtWarrantyDate.ClientID %>').focus();
                 return false;
             }--%>

}
    </script>
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
        }
        function isNumberKey1(evt, element) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && !(charCode == 46 || charCode == 8 || charCode == 45))
                return false;
            else {
                var len = $(element).val().length;

                // Validation Point
                var index = $(element).val().indexOf('.');
                if ((index > 0 && charCode == 46) || len == 0 && charCode == 46) {
                    return false;
                }
                //if (index > 0) {
                //    var CharAfterdot = (len + 1) - index;
                //    if (CharAfterdot > 3) {
                //        return false;
                //    }
                //}

                //// Validating Negative sign
                //index = $(element).val().indexOf('-');
                //if ((index > 0 && charCode == 45) || (len > 0 && charCode == 45)) {
                //    return false;
                //}
            }
            return true;
        }
    </script>

    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">

                <div class="span12">

                    <h3 class="page-title">Purchase Requisition Note
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li><a href="SPA.aspx">SPA</a><span class="divider">&nbsp;</span></li>
                        <li>
                            <a href="ServiceAttachApproval.aspx">Service Attach Approval</a><span class="divider-last">&nbsp;</span>
                        </li>

                    </ul>
                </div>

            </div>
            <br />
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Service Attach Approval</h4>
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
                            <asp:UpdatePanel ID="Up1" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%" border="1">
                                        <tr>
                                            <td>Name of End User <span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEndusername" runat="server" Width="210px"></asp:TextBox>
                                            </td>
                                            <td>Name of Reseller <span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResellerName" runat="server" Width="210px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Name of Distributor <span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDistributorName" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>Supplier <span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSupplier" runat="server" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Type <span style="color: Red">*</span>
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlType" runat="server" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%" border="1">
                                        <tr>
                                            <td>Catagory <span style="color: Red">*</span>
                                                <asp:DropDownList ID="ddlCatagory" runat="server" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>Product <span style="color: Red">*</span>
                                                <asp:DropDownList ID="ddlproduct" runat="server" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>Total Quantity<span style="color: Red">*</span>
                                                <asp:TextBox ID="txtQuantity" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                            </td>
                                            <td>Total Period including Standard One year (INR)<span style="color: Red">*</span>
                                                <asp:TextBox ID="txtperiodStdYear" runat="server"></asp:TextBox>
                                            </td>
                                            <td>Name of nearest Competitor offering Service Attach<span style="color: Red">*</span>
                                                <asp:TextBox ID="txtCompetitorname" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                            <td>Distributor Price(INR)<span style="color: Red">*</span>
                                            </td>
                                            <td>Reseller  Price(INR)<span style="color: Red">*</span>

                                            </td>
                                            <td>End User Price(INR)<span style="color: Red">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Unit Product Sales Price Without Discount   <span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUPSWOutdcntDistributorprice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUPSWOutdcntResellerPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUPSWOutdcntEndUserPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Unit Product Sales Price With Discount<span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUPSWithdcntDistributorprice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUPSWithdcntResellerPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUPSWithdcntEndUserPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Unit Service Attach Without Discount<span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSAWOutdcntDistributorprice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSAWOutdcntResellerPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSAWOutdcntEndUserPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Unit Service Attach With Discount<span style="color: Red">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSAWithdcntDistributorprice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSAWithdcntResellerPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSAWithdcntEndUserPrice" runat="server" onkeypress="return isNumberKey1(event,this)"></asp:TextBox>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td>Above prices valid for Warranty until (dd/mm/yyyy) <span style="color: Red">*</span>
                                            </td>
                                            <td colspan="4">&nbsp&nbsp&nbsp
                                        <asp:TextBox ID="TxtWarrantyDate" runat="server" Width="100px" ReadOnly="false"></asp:TextBox>
                                                <asp:CalendarExtender ID="clndrWarrantyDate" runat="server" TargetControlID="TxtWarrantyDate"
                                                    Format="dd-MMM-yyyy" CssClass="Cal_Theme" PopupPosition="BottomLeft" PopupButtonID="ImgWrntyTo">
                                                </asp:CalendarExtender>
                                                <asp:Image ID="ImgWrntyTo" runat="server" ImageUrl="~/images/calendar.png" />
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="center" style="width: 50px" colspan="5">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" Font-Bold="true" Text="submit" BackColor="#3399ff" OnClick="btnSubmit_click" OnClientClick="return CheckValidation();" />
                                                <asp:Button ID="btnClear" runat="server" CssClass="btnStyle" Font-Bold="true" Text="Clear" OnClick="btnClear_Click" BackColor="#3399ff" />
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Small"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTENT-->
            </div>
            <!-- END PAGE CONTAINER-->
        </div>
    </div>
</asp:Content>

