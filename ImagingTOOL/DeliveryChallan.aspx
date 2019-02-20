<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="DeliveryChallan.aspx.cs" Inherits="DeliveryChallan" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 

 <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Sales
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                          <a href="#">Sales</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li><a href="DeliveryChallan.aspx">Delivery Challan</a> <span class="divider-last">&nbsp;</span></li>
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
                            <h4>Delivery Challan</h4>
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
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        From Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate" 
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                    </td>
                                    <td>
                                        To Date
                                    </td>
                                    <td>
                                        <div class="controls">
                                            <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate" 
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        </div>
                                    </td>
                                    <td>
                                    <asp:Button id="BtnSearch" class="btn-success" runat ="server" Text="Search" 
                                            onclick="BtnSearch_Click" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                       
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="GvwSalesManagerChecking" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                                ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="SO_ID" 
                                onrowcommand="GvwSalesManagerChecking_RowCommand" AllowPaging="True" 
                                AllowSorting="True" 
                                onpageindexchanging="GvwSalesManagerChecking_PageIndexChanging">
                                <Columns>
                                  <%--  <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="SO NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("SO_Number") %>'></asp:Label>
                                               
                                            <asp:Label ID="hidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("SoDate") %>'></asp:Label>
                                            <asp:HiddenField ID="HidCatagory" runat="server" />
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Vertical">
                                        <ItemTemplate>
                                            <asp:Label ID="LblVertical" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                        </ItemTemplate>
                                          
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Tax">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTax" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                        </ItemTemplate>
                                   
                                    </asp:TemplateField>
                                  --%>
                                    <asp:TemplateField HeaderText="Total Price">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("SO_NetAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Entered By">
                                        <ItemTemplate>
                                            <asp:Label ID="LblEnteredby" runat="server" Text='<%# Eval("Enteredby") %>'></asp:Label>
                                        </ItemTemplate>
                                   
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SO_Entered On">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSO_EnteredOn" runat="server" Text='<%# Eval("SO_EnteredOn") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                           <%-- <asp:LinkButton ID="lnkLink" runat="server" 
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Edit1" 
                                                ToolTip="Edit"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>--%>
                                                  <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                            CommandName="Edit1">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         
                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="input-mini" style="width: 18px">
                                                So No
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtSoNo" runat="server" ReadOnly="True" Width="176px"></asp:TextBox>
                                            </td>
                                             <td>
                                                CustomerOrderNo
                                            </td>
                                            
                                      <td >
                                                <asp:TextBox ID="TxtCustomerOrderNo" runat="server" ReadOnly="True" 
                                                    Width="176px"></asp:TextBox>
                                            </td>
                                            <td>
                                                CustomerOrderdate
                                            </td>
                                            
                                      <td >
                                                <asp:TextBox ID="TxtCustomerOrderdate" runat="server" ReadOnly="True" 
                                                    Width="149px"></asp:TextBox>
                                            </td>
                                        </tr>
                                   
                                    </table>
                                    <br />
                                    <asp:GridView ID="GvwDCDetails" runat="server" 
        AutoGenerateColumns="False"  DataKeyNames="ID"
        class="table table-striped table-bordered table-advance table-hover" 
       ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="True" AllowSorting="True" 
                                        onpageindexchanging="GvwDCDetails_PageIndexChanging" 
                                        onrowcommand="GvwDCDetails_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Delivery Challan No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDC_no" runat="server"  Text='<%# Eval("[DC_no]") %>'></asp:Label>
                                                   <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                                   <asp:Label ID="lblhidenndeliveryID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery Challan Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDC_Date" runat="server"  Text='<%# Eval("DC_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Name Of The Customer">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblNameOfTheCustomer" runat="server" Text='<%# Eval("[NameOfTheTransporter]") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dispatch Details">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDispatcDetails" runat="server" Text='<%# Eval("[DispatcDetails]") %>'></asp:Label>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dispatch Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDispatchDate" runat="server"  Text='<%# Eval("DispatchDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Date Of Delivery">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDateOfDelivery" runat="server" Text='<%# Eval("DateOfDelivery") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Of Installation">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDateOfInstallation" runat="server" Text='<%# Eval("DateOfInstallation") %>'></asp:Label>
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                           <%-- <asp:LinkButton ID="lnkLink" runat="server" 
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Edit1" 
                                                ToolTip="Edit"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>--%>
                                                  <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                            CommandName="Edit2">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="row-fluid" style="width:100%">
                            
                                <div class="span4 invoice-block pull-right" style="width:100%">
                                    <ul class="unstyled amounts">
                                        <li style="height:35px">  </li>
                                        <li style="height:272px"> <div class="span4 invoice-block pull-left"  
                                                style="width:99%; height: 57px;"> 
                                            <table style="width: 100%; height: 80px">
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        Delivery Cahllan Date</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:TextBox ID="Txt_DC_Date" runat="server" ReadOnly="True"></asp:TextBox>
                                                        <rjs:PopCalendar ID="PopCalendar4" runat="server" Control="Txt_DC_Date" 
                                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" Move="True" />
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Delivery Challan No</td>
                                                    <td>
                                                        <asp:TextBox ID="Txt_DC_NO" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        Name Of Transporter</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:DropDownList ID="DrpTransporter" runat="server" AppendDataBoundItems="true">
                                                            <asp:ListItem Text="--Select--" Value="-1" Selected="true"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Dispatch Details</td>
                                                    <td>
                                                        <asp:DropDownList ID="DrpDispatchDetails" runat="server" AppendDataBoundItems="true">
                                                          <asp:ListItem Text="--Select--" Value="-1" Selected="true"></asp:ListItem>
                                                        </asp:DropDownList>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        Dispatch Date</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:TextBox ID="Txt_Dispatch_Date" runat="server" ReadOnly="True"></asp:TextBox>
                                                        <rjs:PopCalendar ID="PopCalendar5" runat="server" Control="Txt_Dispatch_Date" 
                                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Date Of Delivery</td>
                                                    <td>
                                                        <asp:TextBox ID="Txt_DateOfDelivery" runat="server" ReadOnly="True"></asp:TextBox>
                                                        <rjs:PopCalendar ID="PopCalendar6" runat="server" Control="Txt_DateOfDelivery" 
                                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        Date Of Installation</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:TextBox ID="Txt_DateOf_Installation" runat="server" ReadOnly="True"></asp:TextBox>
                                                        <rjs:PopCalendar ID="PopCalendar7" runat="server" 
                                                            Control="Txt_DateOf_Installation" Format="dd mmm yyyy" Separator="-" 
                                                            ShowErrorMessage="False" />
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 170px">
                                                        <asp:Button ID="BtnSave" runat="server" onclick="BtnSave_Click" Text="Save" 
                                                            Width="60px" />
                                                        &nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="BtnUpdate" runat="server"  Text="Update" 
                                                            onclick="BtnUpdate_Click" />
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="input-small" style="width: 102px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 175px">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            </div> 
                                            &nbsp;&nbsp; </li>
                                         
                                        
                                    </ul>
                                </div>
                            </div>
                            <asp:HiddenField ID="hidDetails_ID" runat="server" />
                     <asp:HiddenField ID="familyhidden" runat="server" />  <asp:HiddenField ID="hidDetails_Deleivery_ID" runat="server" />
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                         
                            <br />
                         
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

