<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Admin_Location.aspx.cs" Inherits="Admin_Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function validateMandatory() {


            if (document.getElementById('<%=txt_Name.ClientID %>').value == "") {
                alert("Please Enter Location Name");
                document.getElementById('<%=txt_Name.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtShort.ClientID %>').value == "") {
                alert("Please Enter Short Name");
                document.getElementById('<%=txtShort.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=txtClient.ClientID %>').value == "") {
                    alert("Please Enter Client Name");
                    document.getElementById('<%=txtClient.ClientID %>').focus();
                return false;
            }
            else if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {
                alert("Please Select State");
                    document.getElementById('<%=ddlState.ClientID %>').focus();
                return false;
            }

            else if (document.getElementById('<%=ddlType.ClientID%>').selectedIndex == 0) {
                           alert("Please Select Type");
                           document.getElementById('<%=ddlType.ClientID %>').focus();
                return false;
            }
              else if (document.getElementById('<%=txtBillingAddr.ClientID %>').value == "") {
                  alert("Please Enter Billing Address");
                document.getElementById('<%=txtBillingAddr.ClientID %>').focus();
                return false;
              }
              else if (document.getElementById('<%=txtShipping.ClientID %>').value == "") {
                  alert("Please Enter Shipping Address");
                document.getElementById('<%=txtShipping.ClientID %>').focus();
                return false;
              }
             else if (document.getElementById('<%=ddlStatus.ClientID%>').selectedIndex == 0) {
                 alert("Please Select Status");
                           document.getElementById('<%=ddlStatus.ClientID %>').focus();
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

                        <li><a href="Admin_Location.aspx">Location</a><span class="divider-last">&nbsp;</span></li>
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
                                Search Short Name:&nbsp&nbsp<asp:TextBox ID="txtSearch" runat="server" Width="150px" Height="20px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnsearch_click" />
                            </div>
                            <div class="row-fluid">

                                <asp:GridView ID="GvwCustomer" runat="server" Width="90%" AutoGenerateColumns="False"
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
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Location_Name") %>'></asp:Label>
                                                <asp:Label ID="lbl_Supplier_Id1" runat="server" Text='<%# Eval("Location_ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_Contaclbl_Nametid" runat="server" Text='<%# Eval("Location_ID") %>' Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtbox_lbl_Name" runat="server" Text='<%#Eval("Location_Name")%>' Width="100px" Height="50px"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Short Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:Label ID="ContactName" runat="server" Text='<%# Eval("Location_Short") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_ContactName" runat="server" Text='<%# Eval("Location_Short") %>' Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtbox_ContactName" runat="server" Text='<%#Eval("Location_Short")%>' Width="100px" Height="50px"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="ContactPhoneNO" runat="server" Text='<%# Eval("Location_Company") %>'></asp:Label>

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_ContactPhoneNOID" runat="server" Text='<%# Eval("Location_Company") %>' Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtContactPhoneNO" runat="server" Text='<%#Eval("Location_Company")%>' Width="100px" Height="50px"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="State" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="State" runat="server" Text='<%# Eval("State_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_StateID" runat="server" Text='<%# Eval("Location_StateID") %>' Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlEditState" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_TypeID" runat="server" Text='<%# Eval("type") %>' Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlType" runat="server">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Purchage" Value="P"></asp:ListItem>
                                                    <asp:ListItem Text="Sales" Value="S"></asp:ListItem>
                                                </asp:DropDownList>
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

                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="LocationActive" runat="server" Text='<%# Eval("Location_Active") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_LocationActiveID" runat="server" Text='<%# Eval("Location_Active") %>' Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlLocationActive" runat="server">
                                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Deactive" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
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
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 185px">Location Name<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:TextBox ID="txt_Name" runat="server" Width="222px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 185px">Location Short<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:TextBox ID="txtShort" runat="server" Width="222px"> </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 185px">Client<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:TextBox ID="txtClient" runat="server" Width="222px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 185px">State<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlState" runat="server" Width="222px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 185px">Type<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlType" runat="server" Width="222px">
                                                <asp:ListItem Text="-- Select Type --" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Purchage" Value="P"></asp:ListItem>
                                                <asp:ListItem Text="Sales" Value="S"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 185px">Billing address<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:TextBox ID="txtBillingAddr" runat="server" TextMode="MultiLine" Width="222px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 185px">Shipping  address<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:TextBox ID="txtShipping" runat="server" TextMode="MultiLine" Width="222px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 185px">Status <span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server" Width="222px">
                                                <asp:ListItem Text="-- Select Status--" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Deactive" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                </table>
                                <table style="width: 100%">
                                    <tr class="style4">
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                             <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return validateMandatory();" />
                                             &nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                             OnClick="btnCancel_Click" />
                                         </span>
                                            <asp:Label ID="lbl_msg" runat="server" BackColor="Black" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>


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
