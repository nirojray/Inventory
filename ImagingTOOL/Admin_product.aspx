<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Admin_product.aspx.cs" Inherits="Admin_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">
        function validateTextBoxBlank() {
            var MinBox = parseInt(document.getElementById('<%=Txt_Min_Qty.ClientID %>').value);
            var MaxBox = parseInt(document.getElementById('<%=Txt_Man_Qty.ClientID %>').value);

            
            if (document.getElementById('<%=ddlSupplier.ClientID%>').selectedIndex == 0) {
                alert("Please Select Supplier");
                document.getElementById('<%=ddlSupplier.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlType.ClientID%>').selectedIndex == 0) {
                alert("Please Select Type");
                document.getElementById('<%=ddlType.ClientID %>').focus();
                return false;
            }

            else if (document.getElementById('<%=ddl_Category.ClientID%>').selectedIndex == 0) {
                alert("Please Select Category");
                document.getElementById('<%=ddl_Category.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txt_Procode.ClientID %>').value == "") {
                alert("Please Enter Product code");
                document.getElementById('<%=txt_Procode.ClientID %>').focus();
                return false;
            }

            else if (document.getElementById('<%=txt_Name.ClientID %>').value == "") {
                alert("Please Enter Product Name");
                document.getElementById('<%=txt_Name.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=Txt_Record_level.ClientID %>').value == "") {
                alert("Please Enter Reorder level");
                document.getElementById('<%=Txt_Record_level.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=Txt_Min_Qty.ClientID %>').value == "") {
                alert("Please Enter Min Qty");
                document.getElementById('<%=Txt_Min_Qty.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=Txt_Man_Qty.ClientID %>').value == "") {
                alert("Please Enter Max Qty");
                document.getElementById('<%=Txt_Man_Qty.ClientID %>').focus();
                return false;
            }
            else if (MaxBox < MinBox) {
                alert('Min Qty cannot be greater than Max Qty');
                return false;
            }


        <%-- else if (document.getElementById('<%=txt_Mum_stock.ClientID %>').value == "") {
           alert("Please Enter Mumbai Stock");
             document.getElementById('<%=txt_Mum_stock.ClientID %>').focus();
             return false;
         }

          else if (document.getElementById('<%=txt_Dhl_stock.ClientID %>').value == "") {
              alert("Please Enter Delhi Stock");
             document.getElementById('<%=txt_Dhl_stock.ClientID %>').focus();
             return false;
          }
                else if (document.getElementById('<%=txt_Chn_stock.ClientID %>').value == "") {
              alert("Please Enter Chennai Stock");
             document.getElementById('<%=txt_Chn_stock.ClientID %>').focus();
             return false;
          }
           
         else if (document.getElementById('<%=txt_Blr_stock.ClientID %>').value == "") {
              alert("Please Enter Bangalore Stock");
             document.getElementById('<%=txt_Blr_stock.ClientID %>').focus();
             return false;
         }
        else if (document.getElementById('<%=Txt_Hyd_stock.ClientID %>').value == "") {
              alert("Please Enter Hyderabad Stock");
             document.getElementById('<%=Txt_Hyd_stock.ClientID %>').focus();
             return false;
        }
       else if (document.getElementById('<%=Txt_Kol_stock.ClientID %>').value == "") {
           alert("Please Enter kolkata Stock");
             document.getElementById('<%=Txt_Kol_stock.ClientID %>').focus();
             return false;
          }  --%>




        }



        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57)) {

                alert("Please Enter Numeric Values")

                return false;
            }



        }



    </script>

    <%-- Added by kushal patil--%>

    <script language="javascript" type="text/javascript">
        function CheckNumericKeyInfo(char1, mozChar) {

            if (mozChar != null) { // Look for a Mozilla-compatible browser
                if ((mozChar >= 48 && mozChar <= 57) || char1 == 8)
                    RetVal = true;
                else {
                    RetVal = false;
                }
            }
            else { // Must be an IE-compatible Browser
                if ((char1 >= 48 && char1 <= 57) || char1 == 8) RetVal = true;
                else {
                    RetVal = false;
                }
            }
            return RetVal;


        }
    </script>

    <script language="javascript" type="text/javascript">
        function Calculation() {
            var grid = document.getElementById("<%= GvwCustomer.ClientID%>");
              for (var i = 0; i < grid.rows.length - 1; i++) {
                  var txtAmountReceive = $("input[id*=txtQty]")
                  if (txtAmountReceive[i].value != '') {
                      alert(txtAmountReceive[i].value);
                  }
              }
          }


    </script>





    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Master Data
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>Master Data<span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="Admin_product.aspx">Product</a><span class="divider-last">&nbsp;</span></li>
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
                                Search Product:&nbsp&nbsp<asp:TextBox ID="txtSearch" runat="server" Width="150px" Height="20px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="X" OnClick="Button1_Click" />&nbsp&nbsp<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnsearch_click" />
                            </div>
                            <div class="row-fluid">


                                <asp:GridView ID="GvwCustomer" runat="server" Width="90%" AutoGenerateColumns="False"
                                    EmptyDataText="No Record Found" CssClass="content-grid"
                                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True"
                                    OnRowEditing="GvwCustomer_RowEditing"
                                    OnRowUpdating="GvwCustomer_RowUpdating"
                                    OnPageIndexChanging="GvwCustomer_PageIndexChanging"
                                    OnRowCancelingEdit="GvwCustomer_RowCancelingEdit" OnRowDeleting="GvwCustomer_RowDeleting">
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <RowStyle HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="180px">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label>
                                                <asp:Label ID="lbl_Supplier_Id1" runat="server" Text='<%# Eval("Product_ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_Contaclbl_Nametid" runat="server" Text='<%# Eval("Product_ID") %>' Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtbox_lbl_Name" runat="server" Text='<%#Eval("Product_Name")%>' Width="150px" Height="50px"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Prodouct Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="ProCode" runat="server" Text='<%# Eval("Product_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtbox_ProCode" runat="server" Text='<%#Eval("Product_Code")%>' Width="150px" Height="50px"></asp:TextBox>

                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("Supplier_Name") %>'></asp:Label>
                                                <asp:Label ID="lbl_Edit_SupplierId" runat="server" Text='<%# Eval("Supplier_Id") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMainCategory" runat="server" Text='<%# Eval("M_CategoryName") %>'></asp:Label>
                                                <asp:Label ID="lbl_Edit_MainCategoryId" runat="server" Text='<%# Eval("M_CategoryId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubCategory" runat="server" Text='<%# Eval("Category_Name") %>'></asp:Label>
                                                <asp:Label ID="lbl_Edit_SubCategoryId" runat="server" Text='<%# Eval("Category_ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <%--Added by kushal patil --%>
                                        <asp:TemplateField HeaderText="Record level" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Record" runat="server" Text='<%# Eval("Reorder_level") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_record" runat="server" Text='<%#Eval("Reorder_level")%>' Width="150px" Height="50px" OnKeyPress="return CheckNumericKeyInfo(event.keyCode, event.which)" MaxLength="2"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Min Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Min" runat="server" Text='<%# Eval("Min_Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_Min" runat="server" Text='<%#Eval("Min_Qty")%>' Width="150px" Height="50px" MaxLength="2" OnKeyPress="return CheckNumericKeyInfo(event.keyCode, event.which)"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Max Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Max" runat="server" Text='<%# Eval("Max_Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_Max" runat="server" Text='<%#Eval("Max_Qty")%>' Width="150px" Height="50px" MaxLength="2" OnKeyPress="return CheckNumericKeyInfo(event.keyCode, event.which)"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>




                                        <asp:ButtonField CommandName="Delete" Text="Delete" HeaderText="Delete" HeaderStyle-Width="60px" />
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" HeaderStyle-Width="60px" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" CausesValidation="false" Visible="false"
                                                Width="0px" Height="0px" />
                                            <asp:Button ID="btnDisContinue" runat="server" OnClick="btnDisContinue_Click" CausesValidation="false" Visible="false"
                                                Width="0px" Height="0px" />
                                        </td>
                                    </tr>
                                </table>
                                <br />


                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 185px">Supplier<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSupplier" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Type<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 185px">Category<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_Category" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Product Code<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Procode" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Product Name<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Name" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%-- Added by kushal patil--%>

                                            <tr>
                                                <td style="width: 185px">Reorder level<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Record_level" runat="server" Width="222px" OnKeyPress="return CheckNumericKeyInfo(event.keyCode, event.which)" MaxLength="2"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Min Qty<span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Min_Qty" runat="server" Width="222px" OnKeyPress="return CheckNumericKeyInfo(event.keyCode, event.which)" MaxLength="2"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Max Qty<span style="color: red">*</span>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Man_Qty" runat="server" Width="222px" OnKeyPress="return CheckNumericKeyInfo(event.keyCode, event.which)" MaxLength="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--  <tr id="tr1" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(Mumbai)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Mum_stock" Text="0" runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)"> </asp:TextBox>
                                     </td>
                                 </tr>
                                  <tr id="tr2" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(Delhi)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Dhl_stock" Text="0"  runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)"> </asp:TextBox>
                                     </td>
                                 </tr>
                                    <tr id="tr3" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(Chennai)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Chn_stock" Text="0" runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)"> </asp:TextBox>
                                     </td>
                                 </tr>
                                    <tr id="tr4" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(Bangalore)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Blr_stock" Text="0" runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)"> </asp:TextBox>
                                     </td>
                                 </tr>                                 
                                    <tr id="tr5" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(Hyderabad)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="Txt_Hyd_stock" Text="0" runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)"> </asp:TextBox>
                                     </td>
                                   </tr>
                                   <tr id="tr6" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(kolkata)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="Txt_Kol_stock" Text="0" runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)"> </asp:TextBox>
                                     </td>
                                   </tr>
                                  <tr id="tr7" runat ="server" visible="false">
                                     <td style="width: 185px">
                                         Product Stock(Ahmedabad)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Ahm_stock" Text="0" runat="server" Width="222px"   onkeypress="javascript:return isNumber(event)" MaxLength="5" Wrap="False" onkeydown="return (event.keyCode!=13)" > </asp:TextBox>
                                     </td>
                                 </tr>--%>
                                        </table>

                                        <table style="width: 100%">
                                            <tr class="style4">
                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                             <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return validateTextBoxBlank();" />
                                             &nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                             OnClick="btnCancel_Click" />
                                         </span>
                                                    <asp:Label ID="lbl_msg" runat="server" BackColor="Black" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

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
