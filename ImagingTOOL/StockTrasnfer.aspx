<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="StockTrasnfer.aspx.cs" Inherits="StockTrasnfer"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

        }
         function validateMandatoryADD() {
            if (document.getElementById('<%=ddlFromLoc.ClientID%>').selectedIndex == 0) {
                alert("Please Select From Location");
                document.getElementById('<%=ddlFromLoc.ClientID %>').focus();
                return false;
            }

            else if (document.getElementById('<%=ddlToLoc.ClientID%>').selectedIndex == 0) {
                alert("Please Select To Location");
                document.getElementById('<%=ddlToLoc.ClientID %>').focus();
                return false;
            }
                 else if (document.getElementById('<%=ddlToLoc.ClientID%>').selectedIndex == document.getElementById('<%=ddlFromLoc.ClientID%>').selectedIndex) {
                alert("To Location should be different from From Location");
                document.getElementById('<%=ddlToLoc.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlMainCategory .ClientID%>').selectedIndex == 0) {
                alert("Please Select Main Category");
                document.getElementById('<%=ddlMainCategory .ClientID %>').focus();
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

                    <h3 class="page-title">Inventory
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>Inventory<span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="StockTrasnfer.aspx">Stock Transfer</a><span class="divider-last">&nbsp;</span></li>
                    </ul>
                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">

                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form class="form-horizontal">
                            </form>
                            <!-- END FORM-->
                           
                            <div class="row-fluid">
                               
                              
                             <%--   <asp:UpdatePanel ID="up1" runat="server">

                                    <ContentTemplate>--%>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 185px">From Location<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFromLoc" runat="server" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td style="width: 185px">To Location<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlToLoc" runat="server" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td style="width: 185px">Main Category<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMainCategory" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlMainCategory_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>

                                           
                                        </table>
                                        <%-- </ContentTemplate>
                                </asp:UpdatePanel>
                                 <br />--%>
                           <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <table><tr><td></td></tr></table>--%>
                                    <div id="dvScreenWidth" visible="false" style="width: 100%">
                                        <div class="GridDock" id="dvGridWidth" style="width: 100%">
                                                 <asp:GridView ID="GvStockTransfer" class="table table-striped table-bordered table-advance table-hover"
                                                runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                                ShowFooter="True" OnRowDeleting="GvStockTransfer_RowDeleting" OnSelectedIndexChanged="GvStockTransfer_SelectedIndexChanged" OnRowDataBound="GvStockTransfer_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Slno">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CatagoryID" Visible="false">
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
                                                            <asp:DropDownList ID="DdlCatagory" runat="server" Width="175px" AppendDataBoundItems="True" OnSelectedIndexChanged="DdlCatagory_SelectedIndexChanged" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ProductID"  Visible="false">
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
                                                                <asp:DropDownList ID="DdlProduct" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlProduct_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="From Location Available Stock">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFCurntStock" runat="server" Text='<%#Eval("FCurentStock") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblFFtCurntStock" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                              <asp:TemplateField HeaderText="To Location Available Stock">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTCurntStock" runat="server" Text='<%#Eval("TCurentStock") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTFtCurntStock" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                           

                                                    <asp:TemplateField HeaderText="Transfer Quantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TxtQuantity" runat="server" Width="50px" onkeypress="return isNumberKey(event)"/>
                                                        
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                  
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                  
                                                            
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
                                    

                                <%--</ContentTemplate>
                            </asp:UpdatePanel>
                                <br />--%>

<%--                                   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>--%>
                                        <table style="width: 100%">
                                            <tr class="style4">
                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                             <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return validateMandatoryADD();"></asp:Button>

                                             &nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                             OnClick="btnCancel_Click"></asp:Button>
                                         </span>
                                                    <asp:Label ID="lbl_msg" runat="server" BackColor="Black" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                  <%-- </ContentTemplate>
                                       </asp:UpdatePanel>--%>

                            </div>

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

