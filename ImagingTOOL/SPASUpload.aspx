<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SPASUpload.aspx.cs" Inherits="SPASUpload" EnableEventValidation="false" %>

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

            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function CheckValidation() {
            debugger
            var TxtSPA = document.getElementById('<%=TxtSPA.ClientID %>')

            var txtUPPWOutDcnt_Dstbtrprice = document.getElementById('<%=txtUPPWOutDcnt_Dstbtrprice.ClientID %>')
            var txtUPPWOutDcnt_Rsprice = document.getElementById('<%=txtUPPWOutDcnt_Rsprice.ClientID %>')
            var txtUPPWOutDcnt_EUprice = document.getElementById('<%=txtUPPWOutDcnt_EUprice.ClientID %>')

            var txtCUPP_Dstbtrprice1 = document.getElementById('<%=txtCUPP_Dstbtrprice1.ClientID %>')
            var txtCUPP_Rsprice1 = document.getElementById('<%=txtCUPP_Rsprice1.ClientID %>')
            var txtCUPP_Euprice1 = document.getElementById('<%=txtCUPP_Euprice1.ClientID %>')

            var txtCUPP_Dstbtrprice2 = document.getElementById('<%=txtCUPP_Dstbtrprice2.ClientID %>')
            var txtCUPP_Rsprice2 = document.getElementById('<%=txtCUPP_Rsprice2.ClientID %>')
            var txtCUPP_Euprice2 = document.getElementById('<%=txtCUPP_Euprice2.ClientID %>')
            var txtSUPReq_Dstbtrprice = document.getElementById('<%=txtSUPReq_Dstbtrprice.ClientID %>')
            var txtSUPReq_Rsprice = document.getElementById('<%=txtSUPReq_Rsprice.ClientID %>')
            var txtSUPReq_Euprice = document.getElementById('<%=txtSUPReq_Euprice.ClientID %>')
            var txtAUP_Dstbtrprice = document.getElementById('<%=txtAUP_Dstbtrprice.ClientID %>')
            var txtAUP_Rsprice = document.getElementById('<%=txtAUP_Rsprice.ClientID %>')
            var txtAUP_Euprice = document.getElementById('<%=txtAUP_Euprice.ClientID %>')
            var txtVSP_Dstbtrprice = document.getElementById('<%=txtVSP_Dstbtrprice.ClientID %>')
            var txtVSP_Rsprice = document.getElementById('<%=txtVSP_Rsprice.ClientID %>')
            var txtVSP_Euprice = document.getElementById('<%=txtVSP_Euprice.ClientID %>')
            var TxtValidforPO = document.getElementById('<%=TxtValidforPO.ClientID %>')
            var ChkSPR = document.getElementById('<%=ChkSPR.ClientID %>')

            if (TxtSPA.value == "") {
                alert("Please Enter SPA Number.");
                document.getElementById('<%=TxtSPA.ClientID %>').focus();
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
                <%-- else if (txtCUPP_Dstbtrprice1.value == "") {
                alert("Please Enter Competitor Unit Product Price Quoted  of Distributor Price (INR) as per applicable slab ");
                document.getElementById('<%=txtCUPP_Dstbtrprice1.ClientID %>').focus();
                return false;
            }
            else if (txtCUPP_Rsprice1.value == "") {
                alert("Please Enter Competitor Unit Product Price Quoted  of Reseller Price (INR)");
                document.getElementById('<%=txtCUPP_Rsprice1.ClientID %>').focus();
                return false;
            }
            else if (txtCUPP_Euprice1.value == "") {
                alert("Please Enter Competitor Unit Product Price Quoted  of End User Price (INR)");
                document.getElementById('<%=txtCUPP_Euprice1.ClientID %>').focus();
                return false;
            }
            else if (txtCUPP_Dstbtrprice2.value == "") {
                alert("Please Enter Competitor Unit Product Price Quoted of Distributor Price (INR) as per applicable slab");
                document.getElementById('<%=txtCUPP_Dstbtrprice2.ClientID %>').focus();
                return false;
            }
            else if (txtCUPP_Rsprice2.value == "") {
                alert("Please Enter Competitor Unit Product Price Quoted of Reseller Price (INR)");
                document.getElementById('<%=txtCUPP_Rsprice2.ClientID %>').focus();
                return false;
            }
            else if (txtCUPP_Euprice2.value == "") {
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
            else if (TxtValidforPO.value == "") {
                alert("Please Select Date prices valid for PO placement until");
                document.getElementById('<%=TxtValidforPO.ClientID %>').focus();
                return false;
            }
            <%-- else if (txtVSP_Dstbtrprice.value == "") {
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
                            <a href="SPASUpload.aspx">Special Price Approval Upload</a><span class="divider-last">&nbsp;</span>
                        </li>

                    </ul>
                </div>

            </div>
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Special Price Approval Upload</h4>
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
                            <asp:UpdatePanel ID="Up1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="DivSPAInfo" runat="server" Visible="false">

                                        <table width="100%" border="1">
                                            <tr id="tr0" runat="server">
                                                <td>SPA NO
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtSPA" runat="server"></asp:TextBox>
                                                </td>
                                                <td>Name of End User
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblEndusername" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="tr1" runat="server">
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
                                                <td>Supplier
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSupplier" runat="server"></asp:Label>
                                                </td>
                                                <td>Type
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Category
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                </td>
                                                <td>Product
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                                </td>
                                            </tr>

                                            <%--  </table>
                                        <table style="width: 100%" border="1">--%>
                                            <tr>
                                                <td colspan="2"></td>
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
                                                    <asp:TextBox ID="txtUPPWOutDcnt_Dstbtrprice" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUPPWOutDcnt_Rsprice" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtUPPWOutDcnt_EUprice" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Quantity  
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                                </td>

                                            </tr>

                                            <tr>
                                                <td colspan="2">Competitor Unit Product Price Quoted<br />
                                                    Make1 :<asp:Label ID="lblCompUPP_Make1" runat="server"></asp:Label><br />
                                                    Model1 :<asp:Label ID="lblCompUPP_Model1" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCUPP_Dstbtrprice1" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCUPP_Rsprice1" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCUPP_Euprice1" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Competitor Unit Product Price Quoted<br />
                                                    Make2:
                                            <asp:Label ID="lblCompUPP_Make2" runat="server"></asp:Label>
                                                    <br />
                                                    Model2:
                                            <asp:Label ID="lblCompUPP_Model2" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCUPP_Dstbtrprice2" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCUPP_Rsprice2" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCUPP_Euprice2" runat="server" ReadOnly="true" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
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
                                                <td colspan="2">Service Attach ? (Y/N)
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblServiceAttach" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Service Attach Number
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblSANumber" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Service Attach Approval Form filled and appended? (Y/N)
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblSAAppended" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Above prices valid for PO placement until (dd/mm/yyyy) <span style="color: Red">*</span>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="TxtValidforPO" runat="server" Width="100px" Enabled="true"></asp:TextBox>
                                                    <asp:CalendarExtender ID="clndrValidforPO" runat="server" TargetControlID="TxtValidforPO"
                                                        Format="dd-MMM-yyyy" CssClass="Cal_Theme" PopupPosition="BottomLeft" PopupButtonID="ImgWrntyTo">
                                                    </asp:CalendarExtender>
                                                    <%-- Format="dd-MM-yyyy"--%>
                                                    <asp:Image ID="ImgWrntyTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                </td>
                                            </tr>
                                        </table>                                      
  <%--                                   </asp:Panel>
                               </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSubmit" />

                                </Triggers>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
                                <ContentTemplate>

                                    <asp:Panel runat="server" ID="DivSPAInfo1">--%>
                                        <table width="100%" border="1">
                                            <tr>
                                                <td colspan="2"><b>Upload File  </b><span style="color: Red">*</span>
                                                </td>
                                                <td colspan="3">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <%-- <asp:FileUpload ID="FlUp" runat="server" />--%>
                                                    <asp:Label ID="lblupload" ForeColor="Green" runat="server" />
                                                    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
                                                    <asp:Label ID="lblUploadMsg" runat="server" ForeColor="Red"></asp:Label>
                                                </td>

                                            </tr>
                                        </table>
                                   <%-- </asp:Panel>--%>
                          <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
                                <ContentTemplate>--%>
                                    <%--<asp:Panel runat="server" ID="DivSPAInfo2">--%>
                                        <table width="100%" border="1">
                                            <tr>
                                                <td colspan="5" align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnStyle" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click" BackColor="#3399ff" OnClientClick="return CheckValidation();" />
                                                    <asp:Button ID="btnClear" runat="server" CssClass="btnStyle" Font-Bold="true" Text="Clear" BackColor="#3399ff" OnClick="btnClear_Click" Visible="true" />
                                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Small"></asp:Label>

                                                </td>
                                            </tr>
                                        </table>
                                   <%-- </asp:Panel>--%>
                                         </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                                     <%--<asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />--%>
                                    <asp:postbacktrigger controlid="btnUpload" />
                                </Triggers>
                            </asp:UpdatePanel>
                           
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>



                                    <asp:Panel ID="DivSPAData" runat="server" Visible="false">

                                        <asp:GridView ID="GvSPA" runat="server" class="table table-striped table-bordered table-advance table-hover" Width="100%"
                                            AutoGenerateColumns="false" DataKeyNames="Id,SANumber,SPAAttachFilePath" OnRowDataBound="GvSPA_RowDataBound" OnRowCommand="GvSPA_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Service Attach No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSANO" runat="server" Text='<%# Eval("SANumber") %>'></asp:Label>
                                                        <asp:HiddenField ID="HDFSPAId" runat="server" Value='<%# Eval("Id") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Enduser Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEndUserName" runat="server" Text='<%# Eval("EndUser_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reseller Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblResellerName" runat="server" Text='<%# Eval("Reseller_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Distributor Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDistributeName" runat="server" Text='<%# Eval("Distributer_Name") %>'></asp:Label>
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
                                                        <asp:LinkButton ID="lnkSPAAFile" runat="server" ToolTip="download" OnClientClick="return askConfirm();" OnClick="lnkSAAFile_OnClick"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edited" CommandArgument='<%# Eval("Id") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                        <table>
                                            <tr id="tr4" runat="server">
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Font-Bold="true" />
                                                </td>
                                            </tr>
                                        </table>

                                    </asp:Panel>

                                </ContentTemplate>
                                <%-- <Triggers>
                                    <asp:PostBackTrigger ControlID="btnEdit"  />
                                 
                                </Triggers>--%>
                            </asp:UpdatePanel>


                        </div>

                        <!-- END PAGE CONTENT-->
                    </div>
                    <!-- END PAGE CONTAINER-->
                </div>
            </div>
        </div>
    </div>

    </div>

    </div>

</asp:Content>

