<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PORejectedData.aspx.cs" Inherits="PORejectedData" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>   
       <link href="Styles/black.css" rel="stylesheet" />
    
          <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type= "text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />
    
    <style type="text/css">
        .GridDock {
            overflow-x: auto;
            overflow-y: hidden;
            width: 200px;
            padding: 0 0 17px 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth').width($('#dvScreenWidth').width());
        });
    </script>
    <style type="text/css">
        .dropmenuScroll {
            overflow-y: scroll;
            width: 300px;
        }

        .scrollable {
            overflow: auto;
            width: 200px; /* adjust this width depending to amount of text to display */
            height: 60px; /* adjust height depending on number of options to display */
            border: 1px silver solid;
        }
    </style>

    <script type="text/javascript">

        function Sum(thisctrol) {
            debugger
            var txtShippingAddress = document.getElementById('<%=txtShippingAddress.ClientID %>')
            var $row = $(thisctrol).parent().parent();
            var Rebate = $("[id*='TxtQuantity']", $row).val();
            var Sales = $("[id*='TxtPrice']", $row).val();
            var DrpCatagory = $("[id*='DrpCatagory']", $row).val();
            if (Rebate != '' || Sales != '') {

                var x = parseInt(Rebate);
                var y = parseFloat(Sales);
                $("[id*='LblfttotalPrice']", $row).html((x * y).toFixed(2));
            }
            if (DrpCatagory == '5' || DrpCatagory == '6') {
                txtShippingAddress.value = '';
            }
        }

    </script>

     <script type="text/javascript">

        function SumEdit(thisctrol) {
            debugger
            var txtShippingAddress = document.getElementById('<%=txtShippingAddress.ClientID %>')
            var $row = $(thisctrol).parent().parent();
            var Rebate = $("[id*='TxtEditQuantity']", $row).val();
            var Sales = $("[id*='TxtEditPrice']", $row).val();
            var DrpCatagory = $("[id*='DrpEditCatagory']", $row).val();
            if (Rebate != '' || Sales != '') {

                var x = parseInt(Rebate);
                var y = parseFloat(Sales);
                $("[id*='LblEditfttotalPrice']", $row).html((x * y).toFixed(2));
            }
            if (DrpCatagory == '5' || DrpCatagory == '6') {
                txtShippingAddress.value = '';
            }
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

    </script>

    <style  type="text/css">
     .ontop {
         z-index: 100;
         width: 100%;
         height: 100%;
         top: 0;
         left: 0;
         display: none; 
        
     }

     #popup {
         width: 60%;
         height: 700px;
         position: absolute;
         color: #535E81;
         background-color:#f2f2f2; /* To align popup window at the center of screen  #f2f2f2 */
         top: 25%;
         left: 38%;
         margin-top: -100px;
         margin-left: -150px;
          box-shadow: 0 5px 10px 0 rgba(0, 0, 0, 11), 0 6px 20px 0 rgba(0, 0, 0, 12);
     }

     #popup1 {
        width: 60%;
         height: 700px;
         position: absolute;
         color: #535E81;
         background-color:#f2f2f2; /* To align popup window at the center of screen  #f2f2f2 */
         top: 25%;
         left: 38%;
         margin-top: -100px;
         margin-left: -150px;
          box-shadow: 0 5px 10px 0 rgba(0, 0, 0, 11), 0 6px 20px 0 rgba(0, 0, 0, 12);
     }

     .content a {
         text-decoration: none;
     }

     .content {
         min-width: 600px;
         width: 600px;
         min-height: 150px;
         margin: 100px auto;
         background: #f3f3f3;
         position: relative;
         z-index: 103;
         padding: 10px;
         border-radius: 5px;
         box-shadow: 0 2px 5px #000;
     }

         .content p {
             clear: both;
             color: #555555;
             text-align: justify;
         }

             .content p a {
                 color: #d91900;
                 font-weight: bold;
             }

         .content .x {
             float: right;
             height: 35px;
             left: 22px;
             position: relative;
             top: -25px;
             width: 34px;
         }

             .content .x:hover {
                 cursor: pointer;
             }            
            .InputText {
                width: 30%;
                background: transparent;
                border: none;
                border-bottom: 1px solid #000000;
            }
            .btnStyle {
                border-radius: 12px;
                height:80px;
                width:90px;
            }

 </style>

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

                        <li><a href="PORejectedData.aspx">PRN Rejected Data</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>PRN Rejected Data</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <table id="tbldate" runat="server">
                                <tr>
                                    <td style="height: 38px">&nbsp&nbsp&nbsp From Date &nbsp&nbsp                                   
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" Width="30%" ReadOnly="true"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" Move="True" />
                                    </td>
                                    <td style="height: 38px">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp To Date                                
                                         <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" Width="30%" ReadOnly="true"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        &nbsp&nbsp&nbsp&nbsp
                                        <asp:Button ID="BtnSearch" runat="server" Text="Search"
                                            OnClick="BtnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server">
                                <asp:GridView ID="GvPOReject" runat="server" AutoGenerateColumns="False"
                                    class="table table-striped table-bordered table-advance table-hover"
                                    ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="PO_ID"
                                    AllowPaging="false" AllowSorting="True" PageSize="5" OnRowCommand="GvPOReject_RowCommand">
                                    <Columns>
                                        <%--  <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="PRN NO">
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
                                                <asp:HiddenField ID="HidLocationID" runat="server" Value='<%# Eval("locationID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vendor">
                                            <ItemTemplate>
                                                <asp:Label ID="LblVendor" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("PO_NetAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="PRN_Entered On">
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
                                <asp:UpdatePanel ID="Up1" runat="server">
                                    <ContentTemplate>

                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    PRN Number
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="lblPoNumber" ReadOnly="true" runat="server" Width="210px"></asp:TextBox>
                                                    <%--<asp:Label ID="lblPoNumber" runat="server" ></asp:Label>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Reason For Purchase<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReason" runat="server" Width="210px"></asp:TextBox>
                                                </td>
                                                <td>PRN Date<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtLoggedIn_Date" runat="server" MaxLength="50" Width="200px" Enabled="true"></asp:TextBox>                                            
                                            <asp:CalendarExtender ID="PopCalendar3" runat="server" TargetControlID="txtLoggedIn_Date"
                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgStdTo">
                                            </asp:CalendarExtender>     
                                            <asp:Image ID="ImgStdTo" runat="server" ImageUrl="~/images/calendar.png" />                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Supplier<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DrpSupplier" runat="server"  Width="220px" AutoPostBack="true" OnSelectedIndexChanged="DrpSupplier_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </td>
                                                <td>Supplier State<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtSupplierState" ReadOnly="true" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Supplier GST No<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="TxtVatCst" ReadOnly="true" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                                                </td>
                                                 <td>Payment Terms<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtPaymentTerm" ReadOnly="true" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                                                </td>                                    
                                            </tr>
                                            <tr>
                                                 <td>Reverse Charge<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtrevers" ReadOnly="true" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                                                </td>
                                                 <td>PAN Num<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="TxtPANNum" ReadOnly="true" runat="server" MaxLength="50" Width="210px"></asp:TextBox>
                                                </td>
                                                
                                            </tr>

                                            <tr>
                                                <td>State<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlState" Width="220px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </td>
                                                <td>Location<span style="color: Red">*</span>

                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DrpLocation" runat="server" AppendDataBoundItems="True" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select Location--" Value="-1" Selected="true"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                            <tr>    
                                                <td>Terms Of Delivery<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtTermsOfDelievery" runat="server"  Width="210px"></asp:TextBox>

                                                    <%--<asp:DropDownList ID="ddlTermsOfDelievery" runat="server" Width="220px"></asp:DropDownList>--%>
                                                </td>                                            
                                                <td>Main Category<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlType" runat="server" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                </tr>
                                            <tr>
                                                 <td>
                                                    Purchase Type
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPurchaseType" runat="server"></asp:DropDownList>
                                                </td>
                                                <td id="tdwr" runat="server">Warranty<span style="color: Red">*</span></td>
                                                <td style="margin-left: 40px" id="tdddlwr" runat="server">
                                                    <asp:DropDownList ID="ddlWarranty" runat="server" Width="220px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="td1" runat="server">
                                                     <asp:Label ID="lblHSN_SAC_Code" runat="server"></asp:Label></td>
                                                <td style="margin-left: 40px" id="td2" runat="server">
                                                   <asp:TextBox ID="TxtHSN_SAC_Code" runat="server" Enabled="false"></asp:TextBox>
                                                </td>                                                

                                                <td>SPA Number<span style="color: Red">*</span></td>
                                                <td style="margin-left: 40px">
                                                    <asp:TextBox ID="TxtSpa" runat="server" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVndr" runat="server">Vendor<span style="color: Red">*</span></td>
                                                <td style="margin-left: 40px" id="tdddlvndr" runat="server">
                                                    <asp:DropDownList ID="ddlVendor" runat="server" Width="220px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <%--<tr>
                                                <td id="tdVndr" runat="server">Vendor<span style="color: Red">*</span></td>
                                                <td style="margin-left: 40px" id="td4" runat="server">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="220px">
                                                    </asp:DropDownList>
                                                </td>
                                              </tr>--%>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <asp:UpdatePanel ID="Up2" runat="server">
                                    <ContentTemplate>
                                        <div id="dvScreenWidth" visible="false" style="width: 100%">
                                            <div class="GridDock" id="dvGridWidth" style="width: 100%;">
                                                <%-- OnRowDeleting="GvwPurchaseOrder_RowDeleting" OnSelectedIndexChanged="GvwPurchaseOrder_SelectedIndexChanged" OnRowDataBound="GvwPurchaseOrder_RowDataBound"--%>
                                                <asp:GridView ID="GvwPurchaseOrder" class="table table-striped table-bordered table-advance table-hover"
                                                    runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                                    ShowFooter="True" OnRowDeleting="GvwPurchaseOrder_RowDeleting" OnRowDataBound="GvwPurchaseOrder_RowDataBound" OnRowCommand="GvwPurchaseOrder_RowCommand">
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
                                                                <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("catagory") %>'></asp:Label>
                                                                <asp:HiddenField ID="HidCatagory" runat="server" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="DrpEditCatagory" runat="server" Width="175px" AppendDataBoundItems="True" AutoPostBack="true"  OnSelectedIndexChanged="DrpEditCatagory_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="DrpCatagory" runat="server" Width="175px" AppendDataBoundItems="True" AutoPostBack="true" onchange='Sum(this)' OnSelectedIndexChanged="DrpCatagory_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProductID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Product">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <div class="scrollable">
                                                                    <asp:DropDownList ID="DrpEditProduct" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <div class="scrollable">
                                                                    <asp:DropDownList ID="DrpProduct" runat="server">
                                                                        <%--  <asp:ListItem Text="--Select Product--" Value="-1" Selected="true"></asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </FooterTemplate>
                                                            <FooterStyle Width="60%" />
                                                            <ItemStyle Width="60%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Product Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("PO_Product_Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TxtEditDescription" runat="server" Width="211px" Height="60px" TextMode="MultiLine" />
                                                               <asp:HiddenField ID="HfdEditDescription" runat="server" Value='<%# Eval("PO_Product_Description") %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtDescription" runat="server" Width="211px" Height="60px" TextMode="MultiLine" />
                                                            </FooterTemplate>
                                                            <FooterStyle Width="10%" />
                                                            <ItemStyle Width="10%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TxtEditQuantity" runat="server" Width="30px" onkeypress="return isNumberKey(event)" onkeyup="SumEdit(this)" onchange="SumEdit(this)" />
                                                                  <asp:HiddenField ID="HfdEditQuantity" runat="server" Value='<%# Eval("Quantity") %>' />
                                                                 </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtQuantity" runat="server" Width="30px" onkeypress="return isNumberKey(event)" onkeyup="Sum(this)" onchange="Sum(this)" />
                                                            </FooterTemplate>
                                                            <FooterStyle Width="10%" />
                                                            <ItemStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Price">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TxtEditPrice" runat="server" Width="80px" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);" onkeyup="SumEdit(this)" onchange="SumEdit(this)" />
                                                                  <asp:HiddenField ID="HfdEditPrice" runat="server" Value='<%# Eval("Price") %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtPrice" runat="server" Width="80px" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);" onkeyup="Sum(this)" onchange="Sum(this)" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Price">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LbltotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                                                            </ItemTemplate> 
                                                            <EditItemTemplate>
                                                                <asp:Label ID="LblEditfttotalPrice" runat="server"></asp:Label>
                                                              <asp:HiddenField ID="HfdEditfttotalPrice" runat="server" Value='<%# Eval("TotalPrice") %>' />
                                                            </EditItemTemplate>                                                           
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
                                                            <EditItemTemplate>
                                                                <div class="scrollable">
                                                                    <asp:DropDownList ID="DrpEditTaxType" runat="server" AutoPostBack="False">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="HfdEditTaxID" runat="server" Value='<%# Eval("TaxID") %>' />
                                                                </div>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <div class="scrollable">
                                                                    <asp:DropDownList ID="DrpTaxType" runat="server" AutoPostBack="False">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </FooterTemplate>
                                                            <FooterStyle Width="60%" />
                                                            <ItemStyle Width="60%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="STD Warranty From Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblStdFrmDate" runat="server" Width="130px" Text='<%# Eval("STDFromDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TxtEditStdFrmDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrStdFrmDate" runat="server" TargetControlID="TxtEditStdFrmDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgEditStdFrom">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgEditStdFrom" runat="server" ImageUrl="~/images/calendar.png" />
                                                                    <asp:HiddenField ID="HfdEditSTDFromDate" runat="server" Value='<%# Eval("STDFromDate") %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtStdFrmDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrEditStdFrmDate" runat="server" TargetControlID="TxtStdFrmDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgStdFrom">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgStdFrom" runat="server" ImageUrl="~/images/calendar.png" />
                                                            </FooterTemplate>
                                                            <FooterStyle Width="100%" />
                                                            <ItemStyle Width="60%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="STD Warranty To Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblStdToDate" runat="server" Width="130px" Text='<%# Eval("STDToDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TxtEditStdToDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrEditStdToDate" runat="server" TargetControlID="TxtEditStdToDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgEditStdTo">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgEditStdTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                                <asp:HiddenField ID="HfdEditSTDToDate" runat="server" Value='<%# Eval("STDToDate") %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtStdToDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrStdToDate" runat="server" TargetControlID="TxtStdToDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgStdTo">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgStdTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                            </FooterTemplate>
                                                            <FooterStyle Width="100%" />
                                                            <ItemStyle Width="60%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Extended Warranty From Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblExtndFrmDate" runat="server" Width="130px" Text='<%# Eval("ExtndFrmDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                 <asp:TextBox ID="TxtEditExtndFrmDate" runat="server" Enabled="false" Width="85px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrEditExtndFrmDate" runat="server" TargetControlID="TxtEditExtndFrmDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgEditExtndFrm">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgEditExtndFrm" runat="server" ImageUrl="~/images/calendar.png" />
                                                                 <asp:HiddenField ID="HfdEditExtndFrmDate" runat="server" Value='<%# Eval("ExtndFrmDate") %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtExtndFrmDate" runat="server" Enabled="false" Width="85px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrExtndFrmDate" runat="server" TargetControlID="TxtExtndFrmDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgExtndFrm">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgExtndFrm" runat="server" ImageUrl="~/images/calendar.png" />
                                                            </FooterTemplate>
                                                            <FooterStyle Width="100%" />
                                                            <ItemStyle Width="60%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Extended Warranty To Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblExtndToDate" runat="server" Width="130px" Text='<%# Eval("ExtndToDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                 <asp:TextBox ID="TxtEditExtndToDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrEditExtndToDate" runat="server" TargetControlID="TxtEditExtndToDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgEditExtndTo">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgEditExtndTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                                <asp:HiddenField ID="HfdEditExtndToDate" runat="server" Value='<%# Eval("ExtndToDate") %>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="TxtExtndToDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="clndrExtndToDate" runat="server" TargetControlID="TxtExtndToDate"
                                                                    Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgExtndTo">
                                                                </asp:CalendarExtender>
                                                                <asp:Image ID="ImgExtndTo" runat="server" ImageUrl="~/images/calendar.png" />
                                                            </FooterTemplate>
                                                            <FooterStyle Width="100%" />
                                                            <ItemStyle Width="60%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Price">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TotalAmountPrice") %>'></asp:Label>
                                                            </ItemTemplate>
                                                             <EditItemTemplate>
                                                                <asp:Label ID="LblEdittotalAmount" runat="server"></asp:Label>                                                             
                                                            </EditItemTemplate>  
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                 <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>" ToolTip="Edit" CommandName="Edited">
                                                                     <img src="img/Edit.png" height="18" width="18"  />
                                                                </asp:LinkButton>
                                                                <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                                    ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>                                                               
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="lnkUpdate" runat="server" Font-Bold="true" Font-Italic="true" ToolTip="Update"
                                                                    ForeColor="Blue" CommandName="Updated" ><img src="img/Update.png" height="18" width="18"  /></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" Font-Bold="true" Font-Italic="true" ToolTip="Cancel"
                                                                    ForeColor="Blue" CommandName="Canceled"><img src="img/cancel.png" height="18" width="18"  /></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <%--     OnClick="AddNewGridRow"--%>
                                                                <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClientClick="return validateMandatory();" OnClick="AddNewGridRow"
                                                                    ToolTip=" Add New Product" class="btn-success" />
                                                            </FooterTemplate>
                                                            <ItemStyle Width="20%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="Up3" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%" border="1">
                                            <tr>
                                                <td><b>Billing Address</b></td>
                                                 <td><asp:CheckBox ID="chkShipping" runat="server" style="display:inline;" AutoPostBack="true" OnCheckedChanged="chkShipping_CheckedChanged" />Is shipping address same as billing address<br /> <b> Shipping Address</b></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtBillingAddress" runat="server" TextMode="MultiLine" Width="60%" Height="80px"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtShippingAddress" runat="server" TextMode="MultiLine" Width="60%" Height="80px"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <strong>Total&nbsp; :</strong>
                                                    <asp:Label ID="LblSubTotal" runat="server" Text="0.00"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                  <div class="row-fluid" style="width: 100%">
                            <div class="span4 invoice-block pull-right" style="width: 100%">
                                <ul class="unstyled amounts">                                 
                                    <li style="height: 135px">
                                        <table>
                                            <tr>
                                                <td>Raised To:<span style="color: Red">*</span><asp:TextBox ID="txt_PO_RaisedTo" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                     <asp:Button ID="BtnPRN" runat="server" ForeColor="Black" class="btn-success" OnClientClick="return validateMandatory();"
                                                Text="Save PRN" OnClick="BtnPurchaseOrderSave_Click" /> &nbsp;
                                                    <asp:Button ID="BtnClear" runat="server" ForeColor="Black" class="btn-success" OnClick="BtnClear_Click"  Text="Clear PRN" />                                                
                                               </td>
                                            </tr>

                                        </table>

                                    </li>
                                 
                                </ul>
                            </div>
                        </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

