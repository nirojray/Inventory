<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Admin_Customer.aspx.cs" Inherits="Admin_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

    <script type="text/javascript">
        function validateTextBoxBlank() {
            var txtEmailID = document.getElementById('<%=txtEmail.ClientID %>').value;

            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (document.getElementById('<%=ddl_Type.ClientID%>').selectedIndex == 0) {
                alert("Please Select Type");
                document.getElementById('<%=ddl_Type.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddl_Type.ClientID%>').selectedIndex == 1) {

                if (document.getElementById('<%=txt_Name.ClientID %>').value == "") {
                    alert("Please Enter Name");
                    document.getElementById('<%=txt_Name.ClientID %>').focus();
                       return false;
                   }
                   else if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {

                    alert("Please Select State");
                    document.getElementById('<%=ddlState.ClientID %>').focus();
                    return false;
                }
                else if (document.getElementById('<%=txtContactName.ClientID %>').value == "") {
                 alert("Please Enter Contact Name");
                 document.getElementById('<%=txtContactName.ClientID %>').focus();
                         return false;
                     }
                     else if (document.getElementById('<%=txtContactPhoneNo.ClientID %>').value == "") {
                       alert("Please Enter Contact Number");
                       document.getElementById('<%=txtContactPhoneNo.ClientID %>').focus();
                        return false;
                    }
                    else if (document.getElementById('<%=txtEmail.ClientID %>').value == "") {
                          alert("Please Enter Email");
                          document.getElementById('<%=txtEmail.ClientID %>').focus();
                       return false;
                   }
                   else if (reg.test(txtEmailID) == false) {
                       alert('Please provide a valid email address');
                       document.getElementById("<%=txtEmail.ClientID %>").focus();
                       return false;
                   }
                   <%--else if (document.getElementById('<%=txtVATCST.ClientID %>').value == "") {
                       alert("Please Enter GSTTIN NUM.");
                       document.getElementById('<%=txtVATCST.ClientID %>').focus();
                       return false;

                   }--%> else if (document.getElementById('<%=Drreversecharge.ClientID%>').selectedIndex == 0) {

                       alert("Please Select Reverse Charge");
                       document.getElementById('<%=Drreversecharge.ClientID %>').focus();
                       return false;
                   }
                   else if (document.getElementById('<%=txtPAN.ClientID %>').value == "") {
                       alert("Please Enter PAN");
                       document.getElementById('<%=txtPAN.ClientID %>').focus();
                       return false;
                   }
                   else if (document.getElementById('<%=ddlPaymentTerms.ClientID%>').selectedIndex == 0) {

                           alert("Please Select Payment Terms");
                           document.getElementById('<%=ddlPaymentTerms.ClientID %>').focus();
                       return false;
                   }
            }
else if (document.getElementById('<%=ddl_Type.ClientID%>').selectedIndex == 2) {

                if (document.getElementById('<%=txt_Name.ClientID %>').value == "") {
                    alert("Please Enter Name");
                    document.getElementById('<%=txt_Name.ClientID %>').focus();
                    return false;
                      } else if (document.getElementById('<%=ddlVertical.ClientID%>').selectedIndex == 0) {

                       alert("Please Select Vertical");
                       document.getElementById('<%=ddlVertical.ClientID %>').focus();
                         return false;
                      }
                     else if (document.getElementById('<%=ddlReprsnt.ClientID%>').selectedIndex == 0) {
                         alert("Please Select Representative");
                       document.getElementById('<%=ddlReprsnt.ClientID %>').focus();
                         return false;
                     }
             else if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {
                    alert("Please Select State");
                    document.getElementById('<%=ddlState.ClientID %>').focus();
                             return false;
                    }
             else if (document.getElementById('<%=txtContactName.ClientID %>').value == "") {
        alert("Please Enter Contact Name");
        document.getElementById('<%=txtContactName.ClientID %>').focus();
        return false;
    }
    else if (document.getElementById('<%=txtContactPhoneNo.ClientID %>').value == "") {
                         alert("Please Enter Contact Number");
                         document.getElementById('<%=txtContactPhoneNo.ClientID %>').focus();
                          return false;
                      }
                      else if (document.getElementById('<%=txtEmail.ClientID %>').value == "") {
                        alert("Please Enter Email");
                        document.getElementById('<%=txtEmail.ClientID %>').focus();
                         return false;
                     }
                     else if (reg.test(txtEmailID) == false) {
                         alert('Please provide a valid email address');
                         document.getElementById("<%=txtEmail.ClientID %>").focus();
                      return false;
                  }
                  else if (document.getElementById('<%=txtBillingAddr.ClientID %>').value == "") {
                      alert("Please Enter  Billing Adrress");
                      document.getElementById('<%=txtBillingAddr.ClientID %>').focus();
                        return false;
                    }

                    else if (document.getElementById('<%=txtShipping.ClientID %>').value == "") {
                        alert("Please Enter Shipping Address");
                        document.getElementById('<%=txtShipping.ClientID %>').focus();
                        return false;
                    }

                 <%--   else if (document.getElementById('<%=txtVATCST.ClientID %>').value == "") {
                        alert("Please Enter GSTTIN NUM.");
                        document.getElementById('<%=txtVATCST.ClientID %>').focus();
                       return false;

                   }--%>
                  <%-- else if (document.getElementById('<%=Drreversecharge.ClientID%>').selectedIndex == 0) {

                       alert("Please Select Reverse Charge");
                       document.getElementById('<%=Drreversecharge.ClientID %>').focus();
                       return false;
                   }--%>
                   else if (document.getElementById('<%=txtPAN.ClientID %>').value == "") {
                           alert("Please Enter PAN");
                           document.getElementById('<%=txtPAN.ClientID %>').focus();
                       return false;
                   }

                   else if (document.getElementById('<%=ddlPaymentTerms.ClientID%>').selectedIndex == 0) {
                       alert("Please Select Payment Terms");
                       document.getElementById('<%=ddlPaymentTerms.ClientID %>').focus();
                       return false;
                   }
}
else {
    if (document.getElementById('<%=txt_Name.ClientID %>').value == "") {
        alert("Please Enter Name");
        document.getElementById('<%=txt_Name.ClientID %>').focus();
        return false;
    }

    else if (document.getElementById('<%=txtContactName.ClientID %>').value == "") {
        alert("Please Enter Contact Name");
        document.getElementById('<%=txtContactName.ClientID %>').focus();
        return false;
    }
    else if (document.getElementById('<%=txtContactPhoneNo.ClientID %>').value == "") {
        alert("Please Enter Contact Number");
        document.getElementById('<%=txtContactPhoneNo.ClientID %>').focus();
        return false;
    }

    else if (document.getElementById('<%=txtEmail.ClientID %>').value == "") {
        alert("Please Enter Email");
        document.getElementById('<%=txtEmail.ClientID %>').focus();
        return false;
    }
    else if (reg.test(txtEmailID) == false) {
        alert('Please provide a valid email address');
        document.getElementById("<%=txtEmail.ClientID %>").focus();
                       return false;
                   }
}

        <%--  else if (document.getElementById('<%=txtBillingAddr.ClientID %>').value == "") {
              alert("Please Enter Billing Address");
             document.getElementById('<%=txtBillingAddr.ClientID %>').focus();
             return false;
         }
        else if (document.getElementById('<%=txtShipping.ClientID %>').value == "") {
              alert("Please Enter Shipping Address");
             document.getElementById('<%=txtShipping.ClientID %>').focus();
             return false;
        }--%>



        }




        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57)) {

                alert("Please Enter Numeric Values")
                document.getElementById('<%=txtContactPhoneNo.ClientID %>').focus();
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

                    <h3 class="page-title">Master Data
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>Master Data<span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="Admin_Customer.aspx">Customer/Supplier/Transporter</a><span class="divider-last">&nbsp;</span></li>
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
                                Search Name:&nbsp&nbsp<asp:TextBox ID="txtSearch" runat="server" Width="150px" Height="20px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="X" OnClick="Button1_Click" />&nbsp&nbsp<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnsearch_click" />
                            </div>
                            <div class="row-fluid">
                                <div id="dvScreenWidth" visible="false" style="width: 100%">
                                    <div class="GridDock" id="dvGridWidth" style="width: 100%">

                                        <asp:GridView ID="GvwCustomer" runat="server" Width="90%" AutoGenerateColumns="False" PageSize="7"
                                            EmptyDataText="No Record Found" CssClass="content-grid"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True"
                                            OnRowEditing="GvwCustomer_RowEditing"
                                            OnRowUpdating="GvwCustomer_RowUpdating"
                                            OnPageIndexChanging="GvwCustomer_PageIndexChanging"
                                            OnRowCancelingEdit="GvwCustomer_RowCancelingEdit"
                                            OnRowDeleting="GvwCustomer_RowDeleting" OnSelectedIndexChanged="GvwCustomer_SelectedIndexChanged" OnRowDataBound="GvwCustomer_RowDataBound">
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>

                                                <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="180px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Supplier_Name") %>'></asp:Label>
                                                        <asp:Label ID="lbl_Supplier_Id1" runat="server" Text='<%# Eval("Supplier_Id") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_Contaclbl_Nametid" runat="server" Text='<%# Eval("Supplier_Id") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtbox_lbl_Name" runat="server" Text='<%#Eval("Supplier_Name")%>' Width="150px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Type" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Vertical" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblItemVertical" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_VerticalID" runat="server" Text='<%# Eval("verticalid") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlEditddlVertical" runat="server">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Representative" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblItemRepresentative" runat="server" Text='<%# Eval("Representative") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_RepresentativeID" runat="server" Text='<%# Eval("RepresentativeId") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlEditddlRepresentative" runat="server">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="State" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="State" runat="server" Text='<%# Eval("State_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_StateID" runat="server" Text='<%# Eval("StateID") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlEditState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEditState_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Contact Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ContactName" runat="server" Text='<%# Eval("Supplier_Contact_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_ContactName" runat="server" Text='<%# Eval("Supplier_Contact_Name") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtbox_ContactName" runat="server" Text='<%#Eval("Supplier_Contact_Name")%>' Width="150px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact PhoneNO" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ContactPhoneNO" runat="server" Text='<%# Eval("Supplier_Contact_PhoneNO") %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_ContactPhoneNOID" runat="server" Text='<%# Eval("Supplier_Contact_PhoneNO") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtContactPhoneNO" runat="server" Text='<%#Eval("Supplier_Contact_PhoneNO")%>' Width="100px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact Email" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ContactEmail" runat="server" Text='<%# Eval("Supplier_Email") %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl_ContactEmailID" runat="server" Text='<%# Eval("Supplier_Email") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtContactEmail" runat="server" Text='<%#Eval("Supplier_Email")%>' Width="200px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Billing Address" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBillingAddress" runat="server" Text='<%# Eval("BillingAddress") %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEdit_BillingAddress" runat="server" Text='<%# Eval("BillingAddress") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtBillingAdrress" runat="server" Text='<%#Eval("BillingAddress")%>' Width="100px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Shipping Address" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShippingAddress" runat="server" Text='<%# Eval("ShippingAddress") %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEdit_ShippingAddress" runat="server" Text='<%# Eval("ShippingAddress") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtShippingAddress" runat="server" Text='<%#Eval("ShippingAddress")%>' Width="100px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>




                                                <asp:TemplateField HeaderText="GSTNTIN NUMBER" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVATCST" runat="server" Text='<%# Eval("VATCST") %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEdit_VATCST" runat="server" Text='<%# Eval("VATCST") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtVATCST" runat="server" Text='<%#Eval("VATCST")%>' Width="150px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="PAN" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPAN" runat="server" Text='<%# Eval("PAN") %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblPAN" runat="server" Text='<%# Eval("PAN") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtPAN" runat="server" Text='<%#Eval("PAN")%>' Width="100px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="ServiceTaxNumber" ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblServiceTaxNumbers" runat="server" Text='<%# Eval("ServiceTaxNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEdit_ServiceTaxNumbers" runat="server" Text='<%# Eval("ServiceTaxNumber") %>' Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtServiceTaxNumber" runat="server" Text='<%#Eval("ServiceTaxNumber")%>' Width="100px" Height="50px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Terms" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaymentterms" runat="server" Text='<%# Eval("PaymentTerm") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEdit_Paymentterms" runat="server" Text='<%# Eval("PaymentTermId") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlEditPaymentterms" runat="server">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <%-- ADDED BY KUSHAL PATIL--%>
                                                <asp:TemplateField HeaderText="Reverse charge" ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="100px" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblReverseCharge" runat="server" Text='<%# Eval("ReverseCharge")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:Label ID="LblEdit_Reverserecharge" runat="server" Text='<%# Eval("ReverseChargeId")%>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="dr_Reverse_charge" runat="server"></asp:DropDownList>
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
                                    </div>
                                </div>

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
                                <asp:UpdatePanel ID="up1" runat="server">

                                    <ContentTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 185px">Type<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_Type" runat="server" Width="152px" AutoPostBack="True" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Name<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Name" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="TrVertical" runat="server" visible="false">
                                                <td style="width: 185px">Vertical <span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlVertical" runat="server" Width="152px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="TrReprsnt" runat="server" visible="false">
                                                <td style="width: 185px">Regional representative <span style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlReprsnt" runat="server" Width="222px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="TrState" runat="server" visible="false">
                                                <td style="width: 185px">State<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlState" runat="server" Width="222px" AutoPostBack="false" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Contact Name<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txtContactName" runat="server" Width="222px"> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Contact PhoneNO<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txtContactPhoneNo" runat="server" Width="222px" onkeypress="javascript:return isNumber(event)" MaxLength="10" Wrap="False" onkeydown="return (event.keyCode!=13)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 185px">Email<span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>


                                            <tr id="TrBilling" runat="server" visible="false">
                                                <td style="width: 185px">Billing address<span style="color: Red"></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtBillingAddr" runat="server" TextMode="MultiLine" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="TrShipping" runat="server" visible="false">
                                                <td style="width: 185px">Shipping  address<span style="color: Red"></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtShipping" runat="server" TextMode="MultiLine" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="TrVATCST" runat="server" visible="false">
                                                <td style="width: 185px">GSTTIN<span style="color: Red"></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtVATCST" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%-- ADDED BY KUSHAL PATIL--%>
                                            <tr id="TrReverscharge" runat="server" visible="false">
                                                <td style="width: 185px">Reverse charge<span style="color: Red"></span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Drreversecharge" runat="server">
                                                        <%-- <asp:ListItem Text="--Select--" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>

                                                </td>
                                            </tr>
                                            <tr id="TrPAN" runat="server" visible="false">
                                                <td style="width: 185px">PAN<span style="color: Red"></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtPAN" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="TrServiceTaxNumber" runat="server" visible="false">
                                                <td style="width: 185px">Service Tax Number <span style="color: Red"></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtServiceTaxNumber" runat="server" Width="222px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="TrPaymentterms" runat="server" visible="false">
                                                <td style="width: 185px">Payment Terms <span style="color: Red">*</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPaymentTerms" runat="server" Width="222px">
                                                        <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Single Term" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2 Terms" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3 Terms" Value="3"></asp:ListItem> --%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>

                                        <table style="width: 100%">
                                            <tr class="style4">
                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                             <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return validateTextBoxBlank();"></asp:Button>

                                             &nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                             OnClick="btnCancel_Click"></asp:Button>
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

