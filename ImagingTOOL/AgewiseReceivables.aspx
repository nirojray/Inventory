﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="AgewiseReceivables.aspx.cs" Inherits="AgewiseReceivables" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    //TxtInvoiceAmount
    //TxtAmountReceived
    //TxtBalForCollection
    //TxtInvoiceNo
    //TxtInvoiceDate
    //txtnameofcust
    //TxtCreditPeriod
    //TxtDays

    function validateTextBoxBlank() {

           if (document.getElementById('<%=TxtAmountReceived.ClientID %>').value == "") {
                alert("Please Enter Amount Received");
                document.getElementById('<%=TxtAmountReceived.ClientID %>').focus();
                return false;
           }
                 else if (document.getElementById('<%=TxtBalForCollection.ClientID %>').value == "") {
                alert("Please Enter Balance For Collection");
                document.getElementById('<%=TxtBalForCollection.ClientID %>').focus();
                return false;
             }
       
         else if (document.getElementById('<%=TxtCreditPeriod.ClientID %>').value == "") {
             alert("Please Enter CreditPeriod");
                document.getElementById('<%=TxtCreditPeriod.ClientID %>').focus();
                return false;
         }
         else if (document.getElementById('<%=TxtDays.ClientID %>').value == "") {
                alert("Please Enter Days");
                document.getElementById('<%=TxtDays.ClientID %>').focus();
                return false;
            }
           
        }



function isNumber(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.keyCode
    if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57)) {

        alert("Please Enter Numeric Values")
       
                return false;
            }

        }
</script>
    <script type="text/javascript">
        function calculateBalAmt() {

            
            var PendingAmt = parseFloat(document.getElementById('<%=HiddenFieldbal.ClientID %>').value)
              if (document.getElementById('<%=TxtAmountReceived.ClientID %>').value != "")
                {
             var RecAmt = parseFloat(document.getElementById('<%=TxtAmountReceived.ClientID %>').value)
           
            document.getElementById('<%=TxtBalForCollection.ClientID %>').value = PendingAmt.toString();
            
            if (PendingAmt < RecAmt) {
             
                alert("Received amount should be less than or equal to the pending amount");
                document.getElementById('<%=TxtAmountReceived.ClientID %>').value = "";
        
                }
            else {

                var BalAmt = (PendingAmt - RecAmt).toFixed(2);
                    document.getElementById('<%=TxtBalForCollection.ClientID %>').value =BalAmt.toString();
            }
            }
            else
            {
 document.getElementById('<%=TxtBalForCollection.ClientID %>').value = PendingAmt.toString();
            }
           
                 
           
           
          
            
        }
</script>
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
                          <a href="#">Billing</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li><a href="AgewiseReceivables.aspx">AgeWise Receivables</a> <span class="divider-last">&nbsp;</span></li>
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
                            <h4>AgeWise Receivables</h4>
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
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" 
                                                onselectionchanged="PopCalendar1_SelectionChanged" />
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
                                    <asp:TemplateField HeaderText="SO NO" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("SO_Number") %>'></asp:Label>
                                               
                                            <asp:Label ID="hidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SO Date"  Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("SoDate") %>'></asp:Label>
                                            <asp:HiddenField ID="HidCatagory" runat="server" />
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Invoice NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblINVNO" runat="server" Text='<%# Eval("Invoice_Number") %>'></asp:Label>
                                              <asp:Label ID="hidennInvcID" runat="server" Text='<%# Eval("Invoice_Id") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvdate" runat="server" Text='<%# Eval("Invocie_Date") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="DC No" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDCNO" runat="server" Text='<%# Eval("DC_no") %>'></asp:Label>
                                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DC Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDCdate" runat="server" Text='<%# Eval("DC_Date") %>'></asp:Label>
                                           
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Vertical" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LblVertical" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                        </ItemTemplate>
                                          
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCustomerOrderNo" runat="server" Text='<%# Eval("CusutomerOrderNO") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Customer Order Date">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCustomerOrderDate" runat="server" Text='<%# Eval("CusutomerOrderdate") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="SO Amt">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("SO_NetAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Invoice Amt">
                                        <ItemTemplate>
                                            <asp:Label ID="LblInvprice" runat="server" Text='<%# Eval("Invocie_TotalAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amt Received">
                                        <ItemTemplate>
                                            <asp:Label ID="LblAmtrec" runat="server" Text='<%# Eval("AmtReceived") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Pending Amt">
                                        <ItemTemplate>
                                            <asp:Label ID="LblBalAmt" runat="server" Text='<%# Eval("BalAmt") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Entered By" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LblEnteredby" runat="server" Text='<%# Eval("Enteredby") %>'></asp:Label>
                                        </ItemTemplate>
                                   
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SO_Entered On" Visible="false">
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
                                            
                                            <td style="width: 146px">
                                                So.NO<asp:TextBox ID="TxtSoNo" runat="server" ReadOnly="True" Width="258px"></asp:TextBox>
                                            </td>
                                           
                                        </tr>
                                   
                                    </table>
                                    <br />
                                     <asp:GridView ID="GvwARDetails" runat="server" 
                                            AutoGenerateColumns="False"  DataKeyNames="SO_ID"
                                            class="table table-striped table-bordered table-advance table-hover" 
                                           ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="false" AllowSorting="True" 
                                        onpageindexchanging="GvwARDetails_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Invoice Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceDate" runat="server"  Text='<%# Eval("InvoiceDate") %>'></asp:Label>
                                                   <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceNo" runat="server"  Text='<%# Eval("InvoiceNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Name Of The Customer">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblNameOfTheCustomer" runat="server" Text='<%# Eval("NameOfTheCustomer") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="InvoiceAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblInvoiceAmount" runat="server" Text='<%# Eval("InvoiceAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount Received">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmountReceived" runat="server"  Text='<%# Eval("AmountReceived") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Balance For Collection">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblBalanceForCollection" runat="server" Text='<%# Eval("[BalanceForCollection]") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Credit Period">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCreditPeriod" runat="server" Text='<%# Eval("[CreditPeriod]") %>'></asp:Label>
                                                </ItemTemplate>
                                           
                                               </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Days">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDays" runat="server" Text='<%# Eval("[Days]") %>'></asp:Label>
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
                                                        Invoice Date</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:TextBox ID="TxtInvoiceDate" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Invoice No</td>
                                                    <td>
                                                        <asp:TextBox ID="TxtInvoiceNo" runat="server" ReadOnly="True"></asp:TextBox>
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
                                                        Name Of The Customer</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                         <asp:TextBox ID="txtnameofcust" runat="server" ReadOnly="True"></asp:TextBox>
                                                      <%--  <asp:DropDownList ID="DrpCustomer" runat="server" Width="134px" AppendDataBoundItems="true">
                                                          <asp:ListItem Text="--Select--" Value="-1" Selected="true"></asp:ListItem>
                                                        </asp:DropDownList>--%>
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Invoice Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="TxtInvoiceAmount" runat="server" ReadOnly="True"></asp:TextBox>
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
                                                        Amount Received</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:TextBox ID="TxtAmountReceived" runat="server"   onkeypress="javascript:return isNumber(event)" onkeyup="return calculateBalAmt();" ></asp:TextBox>
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Balance<br /> &nbsp;For Collection</td>
                                                    <td>
                                                         <asp:HiddenField ID="HiddenFieldbal" runat="server" />
                                                          <asp:TextBox ID="TxtBalForCollection" runat="server"  ReadOnly="True"></asp:TextBox>
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
                                                        Credit Period</td>
                                                    <td class="input-medium" colspan="2" style="width: 170px">
                                                        <asp:TextBox ID="TxtCreditPeriod"  runat="server"  ReadOnly="True"></asp:TextBox >
                                                    </td>
                                                    <td class="input-medium" style="width: 175px">
                                                        Days</td>
                                                    <td>
                                                        <asp:TextBox ID="TxtDays"  ReadOnly="True" runat="server"></asp:TextBox>
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
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 170px">
                                                        &nbsp;</td>
                                                    <td class="input-medium" style="width: 170px">
                                                        <asp:Button ID="BtnSave" runat="server" onclick="BtnSave_Click" OnClientClick="return validateTextBoxBlank();" Text="Save" />
                                                      &nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="BtnCancel" runat="server"  Text="Cancel" OnClick="BtnCancel_Click" />
                                                    
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
                     <asp:HiddenField ID="familyhidden" runat="server" />
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

