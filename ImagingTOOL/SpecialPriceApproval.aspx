<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SpecialPriceApproval.aspx.cs" Inherits="SpecialPriceApproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <style type="text/css">
        .btnStyle {
            border-radius: 12px;
            height: 200px;
            width: 120px;
        }
    </style>
    <script type="text/javascript">
        function VisibleddlSANo() {
            debugger
            var DropdownList = document.getElementById('<%=ddlServiceAttach.ClientID %>');
            var ddlSANumber = document.getElementById('<%=ddlSANumber.ClientID %>');
            var ddlSAappended = document.getElementById('<%=ddlSAappended.ClientID %>');
            var SelectedValue = DropdownList.options[DropdownList.selectedIndex].text;
            if (SelectedValue == 'Yes') {
                ddlSANumber.style.display = "block"
                ddlSAappended.options[1].selected = true;
            }
            else if(SelectedValue == 'No') {
                ddlSANumber.style.display = "none";
                ddlSAappended.options[2].selected = true;
            }
            else {
                ddlSANumber.style.display = "block"
                ddlSAappended.options[0].selected = true;
            }
         
        }
    </script>

        <script type="text/javascript">
        function isNumberKey(evt, element) {

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
        function isNumberKey1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

        }
    </script>

     <script type="text/javascript">
         function CheckValidation() {
             debugger
             var txtEndusername = document.getElementById('<%=txtEndusername.ClientID %>')
             var txtResellerName = document.getElementById('<%=txtResellerName.ClientID %>')
             var txtDistributorName = document.getElementById('<%=txtDistributorName.ClientID %>')
             var ddlSupplier = document.getElementById('<%=ddlSupplier.ClientID %>')
             var ddlType = document.getElementById('<%=ddlType.ClientID %>')
             var ddlCatagory = document.getElementById('<%=ddlCatagory.ClientID %>')
             var ddlproduct = document.getElementById('<%=ddlproduct.ClientID %>')
             var txtUPPWOutDcnt_Dstbtrprice = document.getElementById('<%=txtUPPWOutDcnt_Dstbtrprice.ClientID %>')
             var txtUPPWOutDcnt_Rsprice = document.getElementById('<%=txtUPPWOutDcnt_Rsprice.ClientID %>')
             var txtUPPWOutDcnt_EUprice = document.getElementById('<%=txtUPPWOutDcnt_EUprice.ClientID %>')
             var txtQuantity = document.getElementById('<%=txtQuantity.ClientID %>')
             // var txtCompUPP_Make1 = document.getElementById('<%=txtCompUPP_Make1.ClientID %>')
             //var txtCompUPP_Model1 = document.getElementById('<%=txtCompUPP_Model1.ClientID %>')
             //var txtCUPP_Dstbtrprice1 = document.getElementById('<%=txtCUPP_Dstbtrprice1.ClientID %>')
             // var txtCUPP_Rsprice1 = document.getElementById('<%=txtCUPP_Rsprice1.ClientID %>')
             //var txtCUPP_Euprice1 = document.getElementById('<%=txtCUPP_Euprice1.ClientID %>')
             //var txtCompUPP_Make2 = document.getElementById('<%=txtCompUPP_Make2.ClientID %>')
             // var txtCompUPP_Model2 = document.getElementById('<%=txtCompUPP_Model2.ClientID %>')
             // var txtCUPP_Dstbtrprice2 = document.getElementById('<%=txtCUPP_Dstbtrprice2.ClientID %>')
             //var txtCUPP_Rsprice2 = document.getElementById('<%=txtCUPP_Rsprice2.ClientID %>')
             // var txtCUPP_Euprice2 = document.getElementById('<%=txtCUPP_Euprice2.ClientID %>')
             var txtSUPReq_Dstbtrprice = document.getElementById('<%=txtSUPReq_Dstbtrprice.ClientID %>')
             var txtSUPReq_Rsprice = document.getElementById('<%=txtSUPReq_Rsprice.ClientID %>')
             var txtSUPReq_Euprice = document.getElementById('<%=txtSUPReq_Euprice.ClientID %>')
             var txtAUP_Dstbtrprice = document.getElementById('<%=txtAUP_Dstbtrprice.ClientID %>')
             var txtAUP_Rsprice = document.getElementById('<%=txtAUP_Rsprice.ClientID %>')
             var txtAUP_Euprice = document.getElementById('<%=txtAUP_Euprice.ClientID %>')
             var txtVSP_Dstbtrprice = document.getElementById('<%=txtVSP_Dstbtrprice.ClientID %>')
             var txtVSP_Rsprice = document.getElementById('<%=txtVSP_Rsprice.ClientID %>')
             var txtVSP_Euprice = document.getElementById('<%=txtVSP_Euprice.ClientID %>')
             <%-- var TxtValidforPO = document.getElementById('<%=TxtValidforPO.ClientID %>')--%>
             var ddlSANumber = document.getElementById('<%=ddlSANumber.ClientID %>')

             var ChkSPR = document.getElementById('<%=ChkSPR.ClientID %>')
             
             if (txtEndusername.value == "") {
                 alert("Please Enter EndUser Name");
                 document.getElementById('<%=txtEndusername.ClientID %>').focus();
                 return false;
             }
           <%--  else if (txtResellerName.value == "") {
                 alert("Please Enter Reseller Name");
                 document.getElementById('<%=txtResellerName.ClientID %>').focus();
                 return false;
             }--%>
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
             else if (txtUPPWOutDcnt_Dstbtrprice.value == "") {
                 alert("Please Enter Unit Product Price without Discount of Distributor Price (INR) as per applicable slab");
                 document.getElementById('<%=txtUPPWOutDcnt_Dstbtrprice.ClientID %>').focus();
                 return false;
             }
             else if (txtUPPWOutDcnt_Rsprice.value == "") {
                 alert("Please Enter Unit Product Price without Discount of Reseller Price (INR)");
                 document.getElementById('<%=txtUPPWOutDcnt_Rsprice.ClientID %>').focus();
                 return false;
             }
             else if (txtUPPWOutDcnt_EUprice.value == "") {
                 alert("Please Enter Unit Product Price without Discount of End User Price (INR)");
                 document.getElementById('<%=txtUPPWOutDcnt_EUprice.ClientID %>').focus();
                 return false;
             }
             else if (txtQuantity.value == "") {
                 alert("Please Enter Quantity");
                 document.getElementById('<%=txtQuantity.ClientID %>').focus();
                 return false;
             }
                 <%-- else if (txtCompUPP_Make1.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted Make1");
                 document.getElementById('<%=txtCompUPP_Make1.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCompUPP_Model1.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted Model1");
                 document.getElementById('<%=txtCompUPP_Model1.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCUPP_Dstbtrprice1.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted  of Distributor Price (INR) as per applicable slab ");
                 document.getElementById('<%=txtCUPP_Dstbtrprice1.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCUPP_Rsprice1.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted  of Reseller Price (INR)");
                 document.getElementById('<%=txtCUPP_Rsprice1.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCUPP_Euprice1.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted  of End User Price (INR)");
                 document.getElementById('<%=txtCUPP_Euprice1.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCompUPP_Make2.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted Make2");
                 document.getElementById('<%=txtCompUPP_Make2.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCompUPP_Model2.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted Model2");
                 document.getElementById('<%=txtCompUPP_Model2.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCUPP_Dstbtrprice2.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted of Distributor Price (INR) as per applicable slab");
                 document.getElementById('<%=txtCUPP_Dstbtrprice2.ClientID %>').focus();
                 return false;
             }--%>
                 <%--else if (txtCUPP_Rsprice2.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted of Reseller Price (INR)");
                 document.getElementById('<%=txtCUPP_Rsprice2.ClientID %>').focus();
                 return false;
             }--%>
                 <%-- else if (txtCUPP_Euprice2.value == "") {
                 alert("Please Enter Competitor Unit Product Price Quoted of End User Price (INR)");
                 document.getElementById('<%=txtCUPP_Euprice2.ClientID %>').focus();
                 return false;
             }--%>
             else if (txtSUPReq_Dstbtrprice.value == "") {
                 alert("Please Enter Special Unit Product Price Requested of Distributor Price (INR) as per applicable slab");
                 document.getElementById('<%=txtSUPReq_Dstbtrprice.ClientID %>').focus();
                 return false;
             }
             else if (txtSUPReq_Rsprice.value == "") {
                 alert("Please Enter Special Unit Product Price Requested of Reseller Price (INR)");
                 document.getElementById('<%=txtSUPReq_Rsprice.ClientID %>').focus();
                 return false;
             }
             else if (txtSUPReq_Euprice.value == "") {
                 alert("Please Enter Special Unit Product Price Requested of End User Price (INR)");
                 document.getElementById('<%=txtSUPReq_Euprice.ClientID %>').focus();
                 return false;
             }
             else if (txtAUP_Dstbtrprice.value == "") {
                 alert("Please Enter Approved Unit Product Price of Distributor Price (INR) as per applicable slab");
                 document.getElementById('<%=txtAUP_Dstbtrprice.ClientID %>').focus();
                 return false;
             }
             else if (txtAUP_Rsprice.value == "") {
                 alert("Please Enter Approved Unit Product Price of Reseller Price (INR)");
                 document.getElementById('<%=txtAUP_Rsprice.ClientID %>').focus();
                 return false;
             }
             else if (txtAUP_Euprice.value == "") {
                 alert("Please Enter Approved Unit Product Price of  End User Price (INR)");
                 document.getElementById('<%=txtAUP_Euprice.ClientID %>').focus();
                 return false;
             }
                 <%--else if (txtVSP_Dstbtrprice.value == "") {
                 alert("Please Enter % variation from standard price of Distributor Price (INR) as per applicable slab");
                 document.getElementById('<%=txtVSP_Dstbtrprice.ClientID %>').focus();
                 return false;
             }
             else if (txtVSP_Rsprice.value == "") {
                 alert("Please Enter % variation from standard price of Reseller Price (INR)");
                 document.getElementById('<%=txtVSP_Rsprice.ClientID %>').focus();
                 return false;
             }
             else if (txtVSP_Euprice.value == "") {
                 alert("Please Enter % variation from standard price of  End User Price (INR)");
                 document.getElementById('<%=txtVSP_Euprice.ClientID %>').focus();
                 return false;
             }--%>

             if (ChkSPR.checked) {

             }
             else {
                 if (parseFloat(txtUPPWOutDcnt_Dstbtrprice.value) < parseFloat(txtAUP_Dstbtrprice.value)) {
                     alert("Please Enter Approved Unit Product Price is less than the Unit Product Price without Discount of Distributor Price.");
                     document.getElementById('<%=txtAUP_Dstbtrprice.ClientID %>').focus();
                     return false;
                 }
                 else if (parseFloat(txtUPPWOutDcnt_Rsprice.value) < parseFloat(txtAUP_Rsprice.value)) {
                     alert("Please Enter Approved Unit Product Price is less than the Unit Product Price without Discount of Reseller Price.");
                     document.getElementById('<%=txtAUP_Rsprice.ClientID %>').focus();
                     return false;
                 }
                 else if (parseFloat(txtUPPWOutDcnt_EUprice.value) < parseFloat(txtAUP_Euprice.value)) {
                     alert("Please Enter Approved Unit Product Price is less than the Unit Product Price without Discount of End User Price.");
                     document.getElementById('<%=txtAUP_Euprice.ClientID %>').focus();
                     return false;
                 }
             }
         }
             <%--else if (ddlSANumber.selectedIndex == 0) {
                 alert("Please Select SANumber");
                 document.getElementById('<%=ddlSANumber.ClientID %>').focus();
                 return false;
             }
             else if (TxtValidforPO.value == "") {
                 alert("Please Select Date prices valid for PO placement until");
                 document.getElementById('<%=TxtValidforPO.ClientID %>').focus();
                 return false;
             }--%>
             

         
      </script>

    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>
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
                            <a href="SpecialPriceApproval.aspx">Special Price Approval</a><span class="divider-last">&nbsp;</span>
                        </li>

                    </ul>
                </div>

            </div>
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Special Price Approval</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <!-- END PAGE HEADER-->
                        <!-- BEGIN PAGE CONTENT-->
                      
                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form action="#" class="form-horizontal">
                            </form>
                            <!-- END FORM-->
                             <%--<asp:UpdatePanel ID="Up1" runat="server">
                                <ContentTemplate>--%>

                              <asp:UpdatePanel ID="Up1" runat="server">
                          <ContentTemplate>
                         <asp:Panel ID="pnl1" runat="server">                                   
                      <%--  <div id="div1" runat="server">--%>
                            <%--onrowcommand="GvSA_RowCommand"--%>
                            <asp:GridView ID="GvSA" runat="server" class="table table-striped table-bordered table-advance table-hover" Width="100%"
                                AutoGenerateColumns="false" DataKeyNames="Id,SA_Number" onrowcommand="GvSA_RowCommand">
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
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edited" CommandArgument='<%# Eval("SA_Number") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                  <%--      </div>--%>
                        <br />

                            <table style="width: 100%" border="1">
                                <tr>
                                    <td>Name of End User <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndusername" runat="server" Width="210px"></asp:TextBox>
                                    </td>
                                    <td>Name of Reseller
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
                                    <td>Distributor Price (INR) as per applicable slab<span style="color: Red">*</span>
                                    </td>
                                    <td>Reseller Price (INR)<span style="color: Red">*</span>
                                    </td>
                                    <td>End User Price (INR)<span style="color: Red">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Unit Product Price without Discount  <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUPPWOutDcnt_Dstbtrprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUPPWOutDcnt_Rsprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUPPWOutDcnt_EUprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Quantity   <span style="color: Red">*</span>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtQuantity" runat="server"  onkeypress="return isNumberKey1(event)"></asp:TextBox>
                                    </td>

                                </tr>

                                 <tr>
                                    <td colspan="2">Competitor Unit Product Price Quoted<br />
                                        Make1<asp:TextBox ID="txtCompUPP_Make1" runat="server"></asp:TextBox>
                                        Model1<asp:TextBox ID="txtCompUPP_Model1" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUPP_Dstbtrprice1" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUPP_Rsprice1" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUPP_Euprice1" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Competitor Unit Product Price Quoted<br />
                                        Make2<asp:TextBox ID="txtCompUPP_Make2" runat="server"></asp:TextBox>
                                        Model2<asp:TextBox ID="txtCompUPP_Model2" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUPP_Dstbtrprice2" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUPP_Rsprice2" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUPP_Euprice2" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">Special Unit Product Price Requested<span style="color: Red">*</span>
                                         <asp:CheckBox ID="ChkSPR" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="ChkSPR_CheckedChanged" /> 
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSUPReq_Dstbtrprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSUPReq_Rsprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td> 
                                        <asp:TextBox ID="txtSUPReq_Euprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Approved Unit Product Price<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAUP_Dstbtrprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAUP_Rsprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAUP_Euprice" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">% variation from standard price<span style="color: Red">*</span>
                                        <asp:CheckBox ID="ChkVariationPercnt" runat="server" AutoPostBack="true" OnCheckedChanged="ChkVariationPercnt_CheckedChanged" /> 
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVSP_Dstbtrprice" runat="server" onkeypress="return isNumberKey(event,this)" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVSP_Rsprice" runat="server" onkeypress="return isNumberKey(event,this)" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVSP_Euprice" runat="server" onkeypress="return isNumberKey(event,this)" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Service Attach ? (Y/N)<span style="color: Red">*</span>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlServiceAttach" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceAttach_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:DropDownList>                                       
                                    </td>
                                </tr>
                                   <tr>
                                    <td colspan="2">Service Attach Number<span style="color: Red">*</span>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlSANumber" runat="server">                                            
                                        </asp:DropDownList>                                       
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="2">Service Attach Approval Form filled and appended? (Y/N)<span style="color: Red">*</span>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlSAappended" runat="server" Width="100px">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:DropDownList>                                       
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="2">Above prices valid for PO placement until (dd/mm/yyyy) <span style="color: Red">*</span>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TxtValidforPO" runat="server" Width="100px" Enabled="true"></asp:TextBox>
                                        <asp:CalendarExtender ID="clndrValidforPO" runat="server" TargetControlID="TxtValidforPO"
                                           Format="dd-MM-yyyy" CssClass="Cal_Theme" PopupPosition="BottomLeft" PopupButtonID="ImgWrntyTo">
                                        </asp:CalendarExtender>                                     
                                        <asp:Image ID="ImgWrntyTo" runat="server" ImageUrl="~/images/calendar.png" />                                  
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="5" align="center">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click" BackColor="#3399ff" OnClientClick="return CheckValidation();"/>
                                         <asp:Button ID="btnClear" runat="server" CssClass="btnStyle" Font-Bold="true" Text="Clear" OnClick="btnClear_Click" BackColor="#3399ff" Visible="false" />
                                        <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Small"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                               <%-- </ContentTemplate>
                             </asp:UpdatePanel>  --%>     

                        </div>
                       </asp:Panel>
                         </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" /> 
                            </Triggers>
                        </asp:UpdatePanel>  
                        <!-- END PAGE CONTENT-->
                    </div>
                    <!-- END PAGE CONTAINER-->
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>

