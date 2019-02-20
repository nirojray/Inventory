<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ServiceAttachApprovalUpload.aspx.cs" Inherits="ServiceAttachApprovalUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>
    <style type="text/css">
        .GridDock {
            overflow-x: auto;
            overflow-y: auto;
            width: 200px;
            height: 400px;
            padding: 0 0 17px 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth').width($('#dvScreenWidth').width());
        });
    </script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">

        function askConfirm() {

            if (confirm("are you sure")) {

                alert("Clicked Yes");

            }

            else {

                alert("Clicked No");

                return false;

            }

        }

    </script>

    <script type="text/javascript">
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

    <script type="text/javascript">
        function CheckValidation() {
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

            var TxtWarrantyDate = document.getElementById('<%=TxtWarrantyDate.ClientID %>')

            if (txtUPSWOutdcntDistributorprice.value == "") {
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
            } else if (TxtWarrantyDate.value == "") {
                alert("Please select date prices valid for Warranty until");
                document.getElementById('<%=TxtWarrantyDate.ClientID %>').focus();
                return false;
            }
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
                            <a href="ServiceAttachApprovalUpload.aspx">Service Attach Approval Upload</a><span class="divider-last">&nbsp;</span>
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
                            <h4>Service Attach Approval Upload</h4>
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
                            <div id ="DivInf" runat="server" visible="false">
                                <asp:UpdatePanel ID="Up1" runat="server">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSubmit" />
                                         <asp:PostBackTrigger ControlID="btnCancel" />
                                    </Triggers>
                                       
                                    <ContentTemplate>
                                        <table width="100%" border="1">
                                            <tr id="tr0" runat="server">
                                                <td>SA NO
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSANO" runat="server"></asp:Label>
                                                </td>
                                                <td>Name of End User
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblEndusername" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr1" runat="server" >
                                                
                                                <td>Name of Reseller
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblResellerName" runat="server"></asp:Label>
                                                </td>
                                                 <td>Name of Distributor
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblDistributorName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr2" runat="server">
                                               
                                                <td>Supplier <span style="color: Red"></span>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSupplier" runat="server">
                                                    </asp:Label>
                                                </td>  
                                                <td>Type <span style="color: Red"></span>
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                                </td>                                             
                                            </tr>
                                            <tr>
                                                  <td>Catagory <span style="color: Red"></span></td>
                                                <td>  <asp:Label ID="lblCatagory" runat="server">
                                                    </asp:Label>
                                                </td>
                                                 <td>Product</td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Total Quantity<span style="color: Red"></span></td>
                                                <td>
                                                    <asp:Label ID="lblQuantity" runat="server" onkeypress="return isNumberKey(event)"></asp:Label>
                                                </td>
                                                <td>Total Period including Standard One year (INR)<span style="color: Red"></span></td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblperiodStdYear" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Name of nearest Competitor offering Service Attach<span style="color: Red"></span></td>
                                                <td>
                                                    <asp:Label ID="lblCompetitorname" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3"><span style="color: Red"></span></td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                       <%-- </table>
                                        <table style="width: 100%" border="1">--%>
                                           
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
                                                    <asp:TextBox ID="txtUPSWOutdcntDistributorprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUPSWOutdcntResellerPrice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUPSWOutdcntEndUserPrice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Unit Product Sales Price With Discount<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUPSWithdcntDistributorprice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUPSWithdcntResellerPrice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUPSWithdcntEndUserPrice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Unit Service Attach Without Discount<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUSAWOutdcntDistributorprice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUSAWOutdcntResellerPrice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUSAWOutdcntEndUserPrice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Unit Service Attach With Discount<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUSAWithdcntDistributorprice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUSAWithdcntResellerPrice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUSAWithdcntEndUserPrice" runat="server" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);"></asp:TextBox>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td>Above prices valid for Warranty until (dd/mm/yyyy) <span style="color: Red">*</span>
                                                </td>
                                                <td colspan="4">&nbsp&nbsp&nbsp
                                        <asp:TextBox ID="TxtWarrantyDate" runat="server" Width="100px" ReadOnly="false"></asp:TextBox>
                                                    <asp:CalendarExtender ID="clndrWarrantyDate" runat="server" TargetControlID="TxtWarrantyDate"
                                                        Format="dd-MM-yyyy" CssClass="Cal_Theme" PopupPosition="BottomLeft" PopupButtonID="ImgWrntyTo">
                                                    </asp:CalendarExtender>
                                                    <asp:Image ID="ImgWrntyTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                </td>
                                            </tr>--%>
                                            <tr id="tr3" runat="server" >
                                                <td>Service Attach No
                                                </td>
                                                <td colspan="4">
                                                    <asp:DropDownList ID="ddlSANo" runat="server"></asp:DropDownList>
                                                    <%--  <asp:TextBox ID="txtSANo" runat="server" Width="210px"></asp:TextBox> --%>                                                                                                      
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Above prices valid for Warranty until (dd/mm/yyyy) <span style="color: Red">*</span>
                                                </td>
                                                <td colspan="4">&nbsp&nbsp&nbsp
                                                    <asp:TextBox ID="TxtWarrantyDate" runat="server" Width="100px" ReadOnly="false"></asp:TextBox>
                                                    <asp:CalendarExtender ID="clndrWarrantyDate" runat="server" TargetControlID="TxtWarrantyDate"
                                                        Format="dd-MMM-yyyy" CssClass="Cal_Theme" PopupPosition="BottomLeft" PopupButtonID="ImgWrntyTo">
                                                    </asp:CalendarExtender>
                                                    <asp:Image ID="ImgWrntyTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                </td>
                                            </tr>

                                            <tr id="tr4" runat="server" visible="false">
                                                <td><b>Upload File  </b>
                                                </td>
                                                <td colspan="4">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <%-- <asp:FileUpload ID="FlUp" runat="server" />--%>
                                                    <%--<asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />--%>
                                                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server" />
                                                </td>
                                            </tr>                                          
                                            <tr>
                                                <td align="center" style="width: 50px" colspan="5">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" Font-Bold="true" Text="submit" BackColor="#3399ff" OnClick="btnSubmit_Click" OnClientClick="return CheckValidation();"/>
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btnStyle" Font-Bold="true" Text="Cancel" BackColor="#3399ff" OnClick="btnCancel_Click"/>
                                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Small"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <hr />
                            <div id ="DivInfDet" runat="server" visible="false">
                            <div id="dvScreenWidth" visible="false" style="width: 100%">
                                <div class="GridDock" id="dvGridWidth" style="width: 100%">
                                    <asp:GridView ID="GvSA" runat="server" class="table table-striped table-bordered table-advance table-hover" Width="100%" 
                                        AutoGenerateColumns="false" OnRowDataBound="GvSA_RowDataBound" DataKeyNames="Id,SA_Number,SAFilepath" onrowcommand="GvSA_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Attach No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSANO" runat="server" Text='<%# Eval("SA_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Enduser Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEndUserName" runat="server" Text='<%# Eval("Enduser_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reseller Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResellerName" runat="server" Text='<%# Eval("Reseller_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Distributor Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistributeName" runat="server" Text='<%# Eval("Distributor_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Model">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModel" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Cat No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatNo" runat="server" Text='<%# Eval("Product_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Attach File">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSAAFile" runat="server" ToolTip="download" OnClientClick="return askConfirm();" OnClick="lnkSAAFile_OnClick"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edited" CommandArgument='<%# Eval("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTENT-->
            </div>
            <!-- END PAGE CONTAINER-->
        </div>
    </div>

</asp:Content>

