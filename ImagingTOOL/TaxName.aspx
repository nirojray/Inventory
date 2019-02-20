<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="TaxName.aspx.cs" Inherits="TaxName" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function validateTextBoxBlank() {
            var txtTaxname = document.getElementById('<%=txtTaxname.ClientID %>').value;
            var TxtRank = document.getElementById('<%=TxtRank.ClientID %>').value;
            if (txtTaxname == "") {
                alert("Please Enter Tax Name");
                document.getElementById('<%=txtTaxname.ClientID %>').focus();
                return false;
            }
            if (TxtRank == "") {
                alert("Please Enter Rank");
                document.getElementById('<%=TxtRank.ClientID %>').focus();
                return false;
            }
        }

    </script>
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

        }
        </script>
    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Master data
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>Master data
                            <a href="#"></a><span class="divider">&nbsp;</span>
                        </li>
                         <li> <a href="TaxName.aspx">Tax Names</a><span class="divider-last">&nbsp;</span></li>                        
                    </ul>
                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <%--<div class="widget-title">
                            <h4>Tax Name Creation</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>--%>
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
                        <table style="width: 100%">
                            <tr>
                                <td class="input-medium" style="width: 134px">&nbsp;</td>
                                <td style="width: 80px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp Tax Name</td>
                                <td>
                                    <asp:TextBox ID="txtTaxname" TextMode="MultiLine" Width="285px" Height="60px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp Rank
                                </td>
                                <td>
                           <asp:TextBox ID="TxtRank" runat="server" Width="30px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                </td>
                            </tr>                           
                             <tr>
                                <td>&nbsp Status</td>
                                <td>
                                   <asp:DropDownList ID="ddlStatus" runat="server">
                                       <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="De-Active" Value="0"></asp:ListItem>
                                   </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="input-medium" style="width: 134px">&nbsp;</td>
                                <td style="width: 80px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" align="left">
                                    &nbsp <asp:Button ID="btnCreate" runat="server" Text="Save" type="submit" OnClick="btnCreate_Click"
                                        OnClientClick="return validateTextBoxBlank();" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnUpdate" runat="server" Text="Update" type="submit" Enabled="false" OnClick="btnUpdate_click" OnClientClick="return validateTextBoxBlank();" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" type="submit" OnClick="btnCancel_click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="input-medium" style="width: 134px">&nbsp;</td>
                                <td style="width: 80px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="input-medium" style="width: 134px">&nbsp;</td>
                                <td style="width: 80px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="input-medium" colspan="3">
                                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="input-medium" colspan="3">&nbsp  Search Name:<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                    &nbsp 
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />&nbsp
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <%--  <div style="height:350px; overflow:scroll;">--%>
                                     <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="false" Width="80%" AllowPaging="True" PageSize="10"
                                        EmptyDataText="No Record Found" CssClass="content-grid"
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                        OnPageIndexChanging="gvSearch_PageIndexChanging" OnRowCommand="gvSearch_rowcommand">
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.no">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaxName" runat="server" Text='<%# Eval("TaxName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rank">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRank" runat="server" Text='<%# Eval("Rank") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edited" ForeColor="Black" CommandArgument='<%#Eval("TaxNameId") %>' />&nbsp
                                                    <asp:LinkButton ID="BtnDelete" runat="server" Text="Delete" CommandName="Deleted" ForeColor="Black" CommandArgument='<%#Eval("TaxNameId") %>' />
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp;
                                           <%-- </div>--%>
                                </td>

                            </tr>
                        </table>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>

            <!-- END PAGE CONTENT-->
        </div>
        <!-- END PAGE CONTAINER-->
    </div>
</asp:Content>

