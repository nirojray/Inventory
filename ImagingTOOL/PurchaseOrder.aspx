<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="PurchaseOrder.aspx.cs" Inherits="PurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>   
       <link href="Styles/black.css" rel="stylesheet" />
    
          <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-customselect-1.9.1.js" type= "text/javascript"></script>
    <script src="Scripts/jquery-customselect-1.9.1.min.js" type="text/javascript"> </script>
    <link href="Styles/jquery-customselect-1.9.1.css" rel="stylesheet" />

	<script type="text/javascript">
	    $(document).ready(function () {
	        var prm = Sys.WebForms.PageRequestManager.getInstance();

	        prm.add_endRequest(function () {
	            $(function () {
	                $("#ctl00_ContentPlaceHolder1_GvwPurchaseOrder_ctl03_DrpProduct").customselect();
	            });
	        });
     });

 </script>   

    <style type="text/css">
        .GridDock {
            overflow-x: auto;
            overflow-y: hidden;                     
            padding: 0 0 17px 0;           
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth').width($('#dvScreenWidth').width());
        });
</script>
    
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
    <script type="text/javascript">
        function validate_this() {

            return confirm('Do you wish to continue');
        }
    </script>
    <script type="text/javascript">
        function YourChangeFun(ddl) {
            var txt_PO_RaisedTo = document.getElementById('<%=txt_PO_RaisedTo.ClientID %>')
          var selectedText = ddl.options[ddl.selectedIndex].innerHTML;
          txt_PO_RaisedTo.value = selectedText;

      }
    </script>

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
     <script language="javascript" type="text/javascript">
         function validateMandatory() {
             if (document.getElementById('<%=txtReason.ClientID %>').value == "") {
                 alert("Please Enter Reason For Purchage");
                 document.getElementById('<%=txtReason.ClientID %>').focus();
                 return false;
             }
             else if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {
                 alert("Please Select State");
                 document.getElementById('<%=ddlState.ClientID %>').focus();
                 return false;
             }
             else if (document.getElementById('<%=DrpLocation.ClientID %>').selectedIndex == 0) {
                 alert("Please Enter Location");
                 document.getElementById('<%=DrpLocation.ClientID %>').focus();
                 return false;
             }
             else if (document.getElementById('<%=DrpSupplier.ClientID %>').selectedIndex == 0) {
                 alert("Please Enter Supplier");
                 document.getElementById('<%=DrpSupplier.ClientID %>').focus();
                 return false;
             }
             else if (document.getElementById('<%=ddlType.ClientID %>').selectedIndex == 0) {
                 alert("Please Enter Type");
                 document.getElementById('<%=ddlType.ClientID %>').focus();
                 return false;
             }
             else if (document.getElementById('<%=ddlVendor.ClientID%>').selectedIndex == 0) {
                 alert("Please Select Vendor");
                 document.getElementById('<%=ddlVendor.ClientID %>').focus();
                 return false;
             }
             else if (document.getElementById('<%=ddlWarranty.ClientID%>').selectedIndex == 0) {
                 alert("Please Select Warranty");
                 document.getElementById('<%=ddlWarranty.ClientID %>').focus();
                 return false;
             }
         }
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
                            <asp:UpdatePanel ID="Up1" runat="server">
                                <ContentTemplate>
                              
                            <table style="width: 100%">
                                <tr>
                                    <td>Reason For Purchase<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <%-- <asp:DropDownList ID="DrpReason" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="--Select Reason--" Value="-1" Selected="true"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                        <asp:TextBox ID="txtReason" runat="server" Width="210px"></asp:TextBox>

                                    </td>
                                    <td>Purchase Order Date<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <form action="#" class="form-horizontal form-row-seperated">
                                            <div class="controls">
                                                <asp:TextBox ID="txtLoggedIn_Date" ReadOnly="true" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                                <rjs:PopCalendar ID="PopCalendar1" runat="server" ShowErrorMessage="False" Separator="-"
                                                    Format="dd mmm yyyy" Control="txtLoggedIn_Date" KeepInside="False"></rjs:PopCalendar>
                                            </div>
                                        </form>
                                    </td>
                                </tr>
                                <tr>
                                     <td>State<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                         <asp:DropDownList ID="ddlState" Width="220px" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
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
                                    <td>Supplier<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DrpSupplier" runat="server" onchange="YourChangeFun(this);" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="DrpSupplier_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <%--<asp:CascadingDropDown ID="CascadingSupplier" runat="server" Category="Supplier" TargetControlID="DrpSupplier" ParentControlID="DrpLocation"
                                            LoadingText="Loading Supplier..." ServiceMethod="BindSupplier" ServicePath="~/WebService.asmx">
                                        </asp:CascadingDropDown>--%>

                                    </td>
                                     <td>Type<span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server"  Width="220px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <%--<asp:CascadingDropDown ID="CascadingSupplier" runat="server" Category="Supplier" TargetControlID="DrpSupplier" ParentControlID="DrpLocation"
                                            LoadingText="Loading Supplier..." ServiceMethod="BindSupplier" ServicePath="~/WebService.asmx">
                                        </asp:CascadingDropDown>--%>

                                    </td>
                                </tr>
                                <tr>
                                    <td id="tdVndr" runat="server">Vendor<span style="color: Red">*</span></td>
                                    <td style="margin-left: 40px" id="tdddlvndr" runat="server">
                                        <asp:DropDownList ID="ddlVendor" runat="server" Width="220px" >
                                        </asp:DropDownList>
                                    </td>

                                   <td id="tdwr" runat="server">Warranty<span style="color: Red">*</span></td>
                                    <td style="margin-left: 40px" id="tdddlwr" runat="server">
                                        <asp:DropDownList ID="ddlWarranty" runat="server" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                </tr> 
                                                                                   
                            </table>        

                                 </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <%--OnRowDataBound="GvwPurchaseOrder_RowDataBound"--%>
                             <asp:UpdatePanel ID="Up2" runat="server">
                                <ContentTemplate>
                                    <div id="dvScreenWidth" visible="false" style="width:100%">
                                        <div class="GridDock" id="dvGridWidth" style="width:100%;" >
                             <asp:GridView ID="GvwPurchaseOrder" class="table table-striped table-bordered table-advance table-hover"
                                runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                ShowFooter="True" OnRowDeleting="GvwPurchaseOrder_RowDeleting" OnSelectedIndexChanged="GvwPurchaseOrder_SelectedIndexChanged" OnRowDataBound="GvwPurchaseOrder_RowDataBound">
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
                                            <asp:DropDownList ID="DrpCatagory" runat="server" Width="175px" AppendDataBoundItems="True" onchange='Sum(this)' AutoPostBack="true" OnSelectedIndexChanged="DrpCatagory_SelectedIndexChanged">
                                                <%--<asp:ListItem Text="--Select Category--" Value="-1" Selected="true"></asp:ListItem>--%>
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
                                        <FooterTemplate>
                                            <div class="scrollable">
                                            <asp:DropDownList ID="DrpProduct" runat="server" >
                                              <%--  <asp:ListItem Text="--Select Product--" Value="-1" Selected="true"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <%--<asp:CascadingDropDown ID="CascadingProduct" runat="server"  Category="Supplier" TargetControlID="DrpProduct"
                                                ParentControlID="DrpCatagory" LoadingText="Loading Product..." ServiceMethod="BindProduct"
                                                ServicePath="~/WebService.asmx">
                                            </asp:CascadingDropDown>--%>
                                                </div>
                                        </FooterTemplate>
                                        <FooterStyle Width="40%" />
                                        <ItemStyle Width="40%" />
                                    </asp:TemplateField> 
                                     
                                    <asp:TemplateField HeaderText="Product Description">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("PO_Product_Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtDescription" runat="server" Width="211px" Height="60px"  TextMode="MultiLine"/>
                                        </FooterTemplate>
                                        <FooterStyle Width="10%" />
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                                                     
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtQuantity" runat="server" Width="30px" onkeypress="return isNumberKey(event)" onkeyup="Sum(this)"  onchange="Sum(this)"/>
                                        </FooterTemplate>
                                        <FooterStyle Width="10%" />
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtPrice" runat="server" Width="80px" CssClass="CssTxtPrice" onkeypress="return isNumberKey1(event);" onkeyup="Sum(this)" onchange="Sum(this)" />
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
                                            <asp:DropDownList ID="DrpTaxType" runat="server" AutoPostBack="False">
                                            </asp:DropDownList>
                                                </div>
                                           <%-- <asp:CascadingDropDown ID="DrpTaxType_CascadingDropDown" runat="server" Category="Supplier"
                                                TargetControlID="DrpTaxType" ParentControlID="DrpCatagory" LoadingText="Loading Tax..."
                                                ServiceMethod="BindTAX" ServicePath="~/WebService.asmx">
                                            </asp:CascadingDropDown>--%>
                                        </FooterTemplate>
                                        <FooterStyle Width="60%" />
                                        <ItemStyle Width="60%" />
                                    </asp:TemplateField> 
                                     <asp:TemplateField HeaderText="STD Warranty From Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblStdFrmDate" runat="server"  Width="130px" Text='<%# Eval("STDFromDate") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtStdFrmDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>                                            
                                            <asp:CalendarExtender ID="clndrStdFrmDate" runat="server" TargetControlID="TxtStdFrmDate"
                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgStdFrom">
                                            </asp:CalendarExtender>     
                                            <asp:Image ID="ImgStdFrom" runat="server" ImageUrl="~/images/calendar.png" />                                       
                                        </FooterTemplate>
                                        <FooterStyle Width="100%"/>
                                        <ItemStyle Width="60%" />
                                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="STD Warranty To Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblStdToDate" runat="server"  Width="130px" Text='<%# Eval("STDToDate") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtStdToDate" runat="server" Width="85px" Enabled="false"></asp:TextBox>                                            
                                            <asp:CalendarExtender ID="clndrStdToDate" runat="server" TargetControlID="TxtStdToDate"
                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgStdTo">
                                            </asp:CalendarExtender>     
                                            <asp:Image ID="ImgStdTo" runat="server" ImageUrl="~/images/calendar.png" />                                       
                                        </FooterTemplate>
                                        <FooterStyle Width="100%"/>
                                        <ItemStyle Width="60%" />
                                    </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Extended Warranty From Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblExtndFrmDate" runat="server"  Width="130px" Text='<%# Eval("ExtndFrmDate") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtExtndFrmDate" runat="server" Enabled="false" Width="85px"></asp:TextBox>                                            
                                            <asp:CalendarExtender ID="clndrExtndFrmDate" runat="server" TargetControlID="TxtExtndFrmDate"
                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgExtndFrm">
                                            </asp:CalendarExtender>     
                                            <asp:Image ID="ImgExtndFrm" runat="server" ImageUrl="~/images/calendar.png" />                                       
                                        </FooterTemplate>
                                        <FooterStyle Width="100%"/>
                                        <ItemStyle Width="60%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Extended Warranty To Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblExtndToDate" runat="server"  Width="130px" Text='<%# Eval("ExtndToDate") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TxtExtndToDate" runat="server" Width="85px"  Enabled="false"></asp:TextBox>                                            
                                            <asp:CalendarExtender ID="clndrExtndToDate" runat="server" TargetControlID="TxtExtndToDate"
                                                Format="dd-MMM-yyyy" CssClass="black" PopupPosition="BottomLeft" PopupButtonID="ImgExtndTo">
                                            </asp:CalendarExtender>     
                                            <asp:Image ID="ImgExtndTo" runat="server" ImageUrl="~/images/calendar.png" />                                       
                                        </FooterTemplate>
                                        <FooterStyle Width="100%"/>
                                        <ItemStyle Width="60%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TotalAmountPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>
                                        </ItemTemplate>
                                       <FooterTemplate>
                                            <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="AddNewGridRow" OnClientClick="return validateMandatory();" 
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
                                    
                                     </div>
                         <asp:UpdatePanel ID="Up3" runat="server">
                                <ContentTemplate>
                        <table style="width: 100%" border="1">
                            <tr>
                                <td><b>Billing Address</b></td>
                                <td><b>Shipping Address</b></td>
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
<strong>Total&nbsp; :</strong> <asp:Label ID="LblSubTotal" runat="server" Text="0.00"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
</table>
 </ContentTemplate>
                            </asp:UpdatePanel>
                        <div class="row-fluid" style="width: 100%">
                            <div class="span4 invoice-block pull-right" style="width: 100%">
                                <ul class="unstyled amounts">
                                  <%--  <li style="height: 35px"><strong>Total&nbsp; :</strong>
                                        <asp:Label ID="LblSubTotal" runat="server" Text="0.00"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>--%>
                                    <li style="height: 135px">

                                        <table>
                                            <tr>
                                                <td>Raised To:<span style="color: Red">*</span><asp:TextBox ID="txt_PO_RaisedTo" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                     <asp:Button ID="Button2" runat="server" ForeColor="Black" class="btn-success" OnClientClick="return validateMandatory();"
                                                Text="Save Purchase Order"
                                                OnClick="BtnPurchaseOrderSave_Click" /> &nbsp;
                                                    <asp:Button ID="Button1" runat="server" ForeColor="Black" class="btn-success"
                                                        Text="Clear Purchase Order" OnClick="BtnPurchaseOrderClear_Click" />                                                  
                                           
                                               </td>
                                            </tr>
                                            <%-- <tr>
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
                                                     </tr>--%>
                                            <%--<tr>
                                                <td style="width: 1083px">

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1083px">
                                                    <asp:Button ID="BtnPurchaseOrderClear" runat="server" ForeColor="Black"
                                                        Text="Clear Purchase Order" OnClick="BtnPurchaseOrderClear_Click" />
                                                    &nbsp;
                                            <asp:Button ID="BtnPurchaseOrderSave" runat="server" ForeColor="Black"
                                                Text="Save Purchase Order"
                                                OnClick="BtnPurchaseOrderSave_Click" />
                                                     </td>
                                            </tr>--%>
                                        </table>

                                    </li>
                                    <%--<li style="height: 35px">
                                        <div class="span4 invoice-block pull-left" style="width: 50%">
                                            <asp:Button ID="BtnPurchaseOrderClear" runat="server" ForeColor="Black" 
                                                Text="Clear Purchase Order" OnClick="BtnPurchaseOrderClear_Click" />
                                            &nbsp;
                                            <asp:Button ID="BtnPurchaseOrderSave" runat="server" ForeColor="Black"
                                                Text="Save Purchase Order" 
                                                OnClick="BtnPurchaseOrderSave_Click" />
                                        </div>
                                        </li>--%>
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
