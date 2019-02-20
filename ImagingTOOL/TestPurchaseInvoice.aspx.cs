﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
public partial class TestPurchaseInvoice : System.Web.UI.Page
{

    bool result1 = false; bool result2;
    double SubTotal;
    double TaxAmount;
    double TotalAmount;
    double POTotalAmount;
    int int_LocationId;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();
            Panel1.Visible = false;
        }
    }
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {            
            ds = ClsPurchaseInvoice.Get_PurchaseOrderForPurchaseInvoice(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            if (ds.Rows.Count > 0)
            {
                lblMsg.Text = "";
                GvwSalesRegister.Visible = true;
                GvwSalesRegister.DataSource = ds;
                GvwSalesRegister.DataBind();
                ViewState["Data"] = ds;
                ds.Dispose();
                if (ViewState["PageINdex"] != null)
                    GvwSalesRegister.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());

                for(int i=0;i<ds.Rows.Count;i++)
                {
                   DataTable dtPartial = ClsPurchaseInvoice.GetPartialdataBasedOnPONum(ds.Rows[i]["GRN_Number"].ToString());
                    if (dtPartial.Rows.Count > 0)
                    {                 
                        GvwSalesRegister.Rows[i].Cells[1].BackColor = System.Drawing.Color.Yellow;
                    }
                }


            }
            else
            {
                GvwSalesRegister.Visible = false;
                lblMsg.Text = "No Records Found";
               // ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('NO Data Found...');</script>", false);
            }

        }
        catch (Exception ex)
        {
        }

    }
    private string GetCurrentMonth(int Month)
    {
        string month = null;
        switch (Month)
        {
            case 1:
                month = "Jan";
                break;
            case 2:
                month = "Feb";
                break;
            case 3:
                month = "Mar";
                break;
            case 4:
                month = "Apr";
                break;
            case 5:
                month = "May";
                break;
            case 6:
                month = "Jun";
                break;
            case 7:
                month = "Jul";
                break;
            case 8:
                month = "Aug";
                break;
            case 9:
                month = "Sep";
                break;
            case 10:
                month = "Oct";
                break;
            case 11:
                month = "Nov";
                break;
            case 12:
                month = "Dec";
                break;
        }
        return month;


    }
    private string GetDefaultStartDate(DateTime date)
    {
        return (date.Day + "-" + GetCurrentMonth(date.Month) + "-" + date.Year);
    }
    private string GetDefaultEndDate()
    {
        return (DateTime.Now.Day.ToString() + "-" + GetCurrentMonth(DateTime.Now.Month) + "-" + DateTime.Now.Year.ToString());
    }
    private string Dateformat(string date)
    {
        string[] myDate = null;
        myDate = date.Split(' ');
        return (myDate[0] + "-" + myDate[1] + "-" + myDate[2]);
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (Txt_FromDate.Text != string.Empty && Txt_ToDate.Text != string.Empty)
        {
            DateTime fromdate = Convert.ToDateTime(Txt_FromDate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(Txt_ToDate.Text.ToString());

            if (fromdate <= Todate)
            {
                tbldate.Visible = true;
                Panel2.Visible = true;
                Panel1.Visible = false;
                GetSalesManager();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Todate Should be Greater than or equal to Fromdate');</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Date');</script>", false);

        }
    }
    protected void GvwSalesRegister_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit1")
            {
                // TxtLorryRcptNum.Text = "";
                Txt_InvoiceNo.Text = "";
                Txt_InvoiceDate.Text = "";
                Panel1.Visible = true;
                Panel2.Visible = false;
                tbldate.Visible = false;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesRegister.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("GRN_ID='" + ID + "'");


                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();

                    int supp_id = Convert.ToInt32(dtNew.Rows[0]["suppilerid"]);
                    DataTable dtsup = BusinessLogicLayer.ClsSalesManagerChecking.get_reversecharges(supp_id);

                  
                    TxtPoDate.Text =  dtNew.Rows[0]["PO_Date"].ToString();
                    TxtPoNo.Text = dtNew.Rows[0]["PO_Number"].ToString();
                    TxtPoLocation.Text = dtNew.Rows[0]["Location"].ToString();
                    TxtPoSupplier.Text = dtNew.Rows[0]["Supplier"].ToString();
                   // TxtTotalAmount.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    Txt_SubTotal.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    TxtInTotalAmount.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    TxtType.Text= dtNew.Rows[0]["M_CategoryName"].ToString();

                    txt_hsnac.Text = dtNew.Rows[0]["HSN_SAC_NUM"].ToString();
                    TxtPurchaseType.Text= dtNew.Rows[0]["Purchase_Type"].ToString();

                    if (TxtType.Text.Trim() == "Service" || TxtType.Text.Trim() == "Support" || TxtType.Text.Trim() == "Rental")
                    {
                        lbl_hsnac.Text = "SAN Code";
                    }
                    else
                    {
                        lbl_hsnac.Text = "HSN Code";
                    }

                    if (TxtType.Text.Trim() == "Scanners" || TxtType.Text.Trim() == "Support" || TxtType.Text.Trim() == "Software")
                    {
                        TrWarranty.Visible = true;
                        TxtWarranty.Text = dtNew.Rows[0]["Warranty"].ToString();
                    }
                    else
                    {
                        TrWarranty.Visible = false;
                    }
                    if (TxtPoSupplier.Text.Trim() == "Others")
                    {
                        TrVendor.Visible = true;
                        TxtVendor.Text = dtNew.Rows[0]["VendorName"].ToString();
                    }
                    else
                    {
                        TrVendor.Visible = false;
                    }
                    Txt_BillingAddress.Text= dtNew.Rows[0]["BillingAddress"].ToString();
                    Txt_shippingAdress.Text = dtNew.Rows[0]["ShippingAddress"].ToString();
                    int_LocationId = Convert.ToInt32(dtNew.Rows[0]["locationID"].ToString());
                    Session["int_LocationId"] = int_LocationId;
                    TxtGRNNum.Text = dtNew.Rows[0]["GRN_Number"].ToString();
                    TxtGRNDate.Text = dtNew.Rows[0]["GRN_Date"].ToString();
                    TxtPoSupplierState.Text= dtNew.Rows[0]["State"].ToString();
                    TxtGST.Text = dtNew.Rows[0]["Sup_Vat_Cst"].ToString();
                    txtPaymentterms.Text = dtNew.Rows[0]["Sup_PaymentTerms"].ToString();
                    txtTermsOfDelivery.Text = dtNew.Rows[0]["TermOfDelv"].ToString();
                    txtlryRecptNum.Text = dtNew.Rows[0]["LORRYRECEIPTNUMBER"].ToString();
                    TxtSupplierState.Text= dtNew.Rows[0]["Sup_StateName"].ToString();
                    txtrevers.Text = dtsup.Rows[0]["Reverse_Charge"].ToString();
                    TxtPANNum.Text= dtsup.Rows[0]["PAN"].ToString();

                }


                PoDetails(Convert.ToInt64(ID));
                AddNewGridRow1();
                GetSalesManager();

                ViewState["PageINdex"] = GvwSalesRegister.PageIndex;
            }
        }
        catch (Exception ex)
        { }

    }
    private void PoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoiceInInvoice(id);       
        GvwPurchaseInvocie.DataSource = ds;
        GvwPurchaseInvocie.DataBind();


    }
    protected void BtnInvoiceSave_Click(object sender, EventArgs e)
    {
        try
        {        

            ClsPurchaseInvoice objclsinvc = new ClsPurchaseInvoice();
            if (Txt_InvoiceNo.Text != string.Empty && Txt_InvoiceDate.Text != string.Empty)
            {                

                    foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
                    {
                        if (((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please Enter Invoice Quantity.');</script>", false);
                            return;
                        }
                        double TxtInPriceUpdate = Convert.ToDouble(((TextBox)row.FindControl("TxtInPrice")).Text);
                        double TxtInTotalPriceUpdate = Convert.ToDouble(((TextBox)row.FindControl("TxtInTotalPrice")).Text);
                        Int32 TxtInQuantityUpdate = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text);
                        double Sum = Convert.ToDouble((TxtInPriceUpdate * TxtInQuantityUpdate).ToString("0.00"));
                        double prvSum = Convert.ToDouble(TxtInTotalPriceUpdate.ToString("0.00"));
                        if (Sum != prvSum)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "<script type=text/javascript>alert('Please click on Update Button..')</script>");
                            Button BtnAdd = (Button)GvwPurchaseInvocie.FooterRow.FindControl("BtnAdd");
                            BtnAdd.Focus();
                            return;
                        }

                    }
                    //Check point
                    //--t_purchase order detail and t_purchareinvoicedetail
                    //string pono = TxtPoNo.Text;
                    foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            string HidCatagory0 = ((HiddenField)row.Cells[3].FindControl("HidCatagory0")).Value;
                            string HidProduct0 = ((HiddenField)row.Cells[3].FindControl("HidProduct0")).Value;
                            DataTable DT = ClsCheck.Get_PurchaseCheck(TxtGRNNum.Text.Trim(), Convert.ToInt32(HidProduct0), Convert.ToInt32(HidCatagory0));
                            int POQUANTITY = Convert.ToInt32(((Label)row.Cells[2].FindControl("LblQuantity")).Text);

                            //int POQUANTITY = Convert.ToInt32(DT.Rows[0]["PO_QUANTITY"].ToString());
                            //int PURCHASEIN = Convert.ToInt32(DT.Rows[0]["PURCHASE_INVOICE"].ToString());
                            int TxtInQuantity = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text);

                            if (POQUANTITY < TxtInQuantity)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Invoice Quantity is greater than Purchase Quantity..');</script>", false);
                                return;
                            }
                        }
                    }

                    string asd = hidDetails_ID.Value;
                    DateTime PODATE = Convert.ToDateTime(TxtPoDate.Text);
                    string GRNnumber = TxtGRNNum.Text;

                    int invoiceid;
                    DateTime invoicedate = DateTime.Now;
                    string invoiceno = ""; string totalAmount = "";
                    invoicedate = Convert.ToDateTime(Txt_InvoiceDate.Text.Trim());
                    invoiceno = Txt_InvoiceNo.Text.Trim();
                    totalAmount = Txt_SubTotal.Text.Trim();


                    //taxid = Convert.ToInt32(DrpTaxType.SelectedItem.Value);
                    result2 = ClsPurchaseInvoice.InsertPurchaseGRNInvoice(out invoiceid, Convert.ToInt32(asd), GRNnumber, PODATE,
                      invoiceno, invoicedate, Convert.ToDouble(totalAmount), Convert.ToInt32(Session["Id"]),"");
                    if (result2)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('invoice Saved Successfully...');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('invoice Insertion Failed...');</script>", false);
                    }


                    foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            string LblSlno = ((Label)row.Cells[0].FindControl("LblSlno")).Text;
                            Int64 HidPODetId = Convert.ToInt32(((HiddenField)row.Cells[2].FindControl("HdfPODETID")).Value);
                            string lblCatagory = ((Label)row.Cells[1].FindControl("lblCatagory")).Text;
                            Int32 HidCatagory0 = Convert.ToInt32(((HiddenField)row.Cells[2].FindControl("HidCatagory0")).Value);
                            string LblProduct = ((Label)row.Cells[3].FindControl("LblProduct")).Text;
                            Int32 HidProduct0 = Convert.ToInt32(((HiddenField)row.Cells[4].FindControl("HidProduct0")).Value);
                            Int32 LblQuantity = Convert.ToInt32(((Label)row.Cells[3].FindControl("LblQuantity")).Text);
                            double LblPrice = Convert.ToDouble(((Label)row.Cells[3].FindControl("LblPrice")).Text);
                            double POTaxPrice = Convert.ToDouble(((Label)row.Cells[3].FindControl("Lbltaxid")).Text);
                            double pototalamount = Convert.ToDouble(((Label)row.Cells[3].FindControl("LbltotalAmount")).Text);

                            string TxtInQuantity = ((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text;
                            string TxtInPrice = ((TextBox)row.Cells[4].FindControl("TxtInPrice")).Text;
                            double invoicetotalamount = Convert.ToDouble(((Label)row.Cells[3].FindControl("LblInvocietotalPrice")).Text);
                            string InvoiceTaxPrice = ((TextBox)row.Cells[3].FindControl("txttaxid")).Text;

                            string loaction = Txt_shippingAdress.Text.Trim();
                            string MainLocation = TxtPoLocation.Text;

                            result1 = ClsPurchaseInvoice.InsertPurchaseGRNInvoicedetails(invoiceid, Convert.ToInt32(asd), HidCatagory0, HidProduct0,
                                LblQuantity, LblPrice, POTaxPrice, pototalamount,
                                Convert.ToInt32(TxtInQuantity), Convert.ToDouble(TxtInPrice), InvoiceTaxPrice, invoicetotalamount, Convert.ToInt32(Session["Id"].ToString()), loaction, LblProduct, invoicedate, MainLocation, Convert.ToInt32(Session["int_LocationId"]), HidPODetId);

                        }

                    }

                    Txt_InvoiceNo.Text = "";
                    Txt_InvoiceDate.Text = "";
                    Txt_SubTotal.Text = "0.00";

                    TxtInTotalAmount.Text = "0.00";
                    GetSalesManager();
                    Panel1.Visible = false; Panel2.Visible = true; tbldate.Visible = true;
             
            }
            else
            {
                if (Txt_InvoiceNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Enter Invoice Number.');</script>", false);
                    Txt_InvoiceNo.Focus();
                    return;

                }
                if (Txt_InvoiceDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Invoice Date.');</script>", false);
                    Txt_InvoiceDate.Focus();
                    return;

                }
                //if (Txt_InvoiceDate.Text != "")
                //{
                //    DateTime PODate = Convert.ToDateTime(TxtPoDate.Text);
                //    DateTime PO_date = Convert.ToDateTime(PODate.ToString("dd/MM/yyyy"));
                //    DateTime InvoiceDate = Convert.ToDateTime(Txt_InvoiceDate.Text);
                //    DateTime Invoice_Date = Convert.ToDateTime(InvoiceDate.ToString("dd/MM/yyyy"));
                //    if (PO_date > Invoice_Date)
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Invoice Date Should be Greater Than PO Date.');</script>", false);
                //        TxtPoDate.Focus();
                //        return;
                //    }
                //}
                //if (TxtLorryRcptNum.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Enter Lorry receipt number.');</script>", false);
                //    TxtLorryRcptNum.Focus();
                //    return;

                //}
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Fill Invoice Number and Invoice Date...');</script>", false);
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void TxtLocation_TextChanged(object sender, EventArgs e)
    {

    }

    protected void DrpTaxType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //double SubTotal;

        //SubTotal = 0.00;


        ////Txt_ToatlAmount.Text = SubTotal.ToString();
        //DataTable Ds = new DataTable();
        //int TAX1 = Convert.ToInt32(DrpTaxType.SelectedValue.ToString());
        //Ds = ClsPurchaseOrder.getTax(TAX1);
        //double TAX = Convert.ToDouble(Ds.Rows[0]["Percentage"].ToString());

        //TxtInTaxAmount.Text = Convert.ToString((SubTotal * Convert.ToDouble(TAX)) / 100);

        //TxtInTotalAmount.Text = Convert.ToString(SubTotal + (SubTotal * Convert.ToDouble(TAX)) / 100);

    }

    public void AddNewGridRow(object sender, EventArgs e)
    {
        BtnInvoiceSave0.Visible = true;
        double SubTotal = 0;

        double Total = 0;

        foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please Enter Invoice Quantity.');</script>", false);
                    return;
                }
                string HidProduct0 = ((HiddenField)row.Cells[3].FindControl("HidProduct0")).Value;
                string HidCatagory0 = ((HiddenField)row.Cells[3].FindControl("HidCatagory0")).Value;
                DataTable DT = ClsCheck.Get_PurchaseCheck(TxtPoNo.Text.Trim(), Convert.ToInt32(HidProduct0),Convert.ToInt32(HidCatagory0));
                //int POQUANTITY = Convert.ToInt32(DT.Rows[0]["PO_QUANTITY"].ToString());
                //int PURCHASEIN = Convert.ToInt32(DT.Rows[0]["PURCHASE_INVOICE"].ToString());
                int POQUANTITY = Convert.ToInt32(((Label)row.Cells[2].FindControl("LblPendingQuantity")).Text);
                int TxtInQuantity1 = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text);

                if (POQUANTITY < TxtInQuantity1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Invoice Quantity is greater than Purchase Quantity..');</script>", false);
                    return;
                }



                string PoNo = TxtPoNo.Text;
                int CategoryId = Convert.ToInt32(((HiddenField)row.FindControl("HidCatagory0")).Value);
                int ProductId = Convert.ToInt32(((HiddenField)row.FindControl("HidProduct0")).Value);
                Int32 Quantity = Convert.ToInt32(((TextBox)row.Cells[2].FindControl("TxtInQuantity")).Text);
                double totalprice = Convert.ToDouble(((TextBox)row.Cells[2].FindControl("TxtInPrice")).Text);

                // int lblSubTot = Convert.ToInt32(((TextBox)GvwPurchaseInvocie.FooterRow.FindControl("TxtInQuantity")).Text) * Convert.ToInt32(((TextBox)GvwPurchaseInvocie.FooterRow.FindControl("TxtInPrice")).Text);
                int TxtInQuantity = Convert.ToInt32(((TextBox)row.FindControl("TxtInQuantity")).Text);
                double TxtInPrice = Convert.ToDouble(((TextBox)row.FindControl("TxtInPrice")).Text);

                double lblSubTot = TxtInQuantity * Convert.ToDouble(TxtInPrice);

                TextBox TxtInTotalPrice = (TextBox)row.FindControl("TxtInTotalPrice");
                TxtInTotalPrice.Text = Convert.ToString(lblSubTot.ToString("0.00"));

                // int lblSubTot = Convert.ToInt32(((TextBox)row.FindControl("TxtInQuantity")).Text) * Convert.ToInt32(((TextBox)row.FindControl("TxtInPrice")).Text);

                DataTable DTTaxRate = new DataTable();
                DTTaxRate = ClsPurchaseInvoice.GetInvoiceTaxRateBaseValue(PoNo, CategoryId, ProductId);
                // Label lblSubTot = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");
                double TaxValue = 0;
                if (DTTaxRate.Rows.Count > 0)
                {
                    for (int i = 0; i <= DTTaxRate.Rows.Count - 1; i++)
                    {
                        double SubTotonBaseVal = Convert.ToDouble(lblSubTot) * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;

                        TaxValue = TaxValue + (SubTotonBaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);
                    }

                }
                TotalAmount = Convert.ToDouble(lblSubTot) + TaxValue;

                // double tax = Convert.ToDouble(((TextBox)row.Cells[2].FindControl("txttaxid")).Text);
                // Total = (((Convert.ToDouble(totalprice * Quantity)) * tax) / 100) + (((Convert.ToDouble(totalprice * Quantity))));
                TextBox TxtInvTax = (TextBox)row.FindControl("txttaxid");
                TxtInvTax.Text = Convert.ToString(TaxValue.ToString("0.00"));
                Label lbl = (Label)(row.Cells[2].FindControl("LblInvocietotalPrice"));
                lbl.Text = TotalAmount.ToString("0.00");
                SubTotal = SubTotal + TotalAmount;
            }

        }
       // Txt_SubTotal.Text = Math.Floor(SubTotal + .49).ToString("0.00");
        Txt_SubTotal.Text = Convert.ToDouble(SubTotal).ToString("0.00");

    }

    public void SendMailforInvoiceApproval()
    {
        try
        {

        }
        catch (Exception ex)
        {
        }
    }


    protected void GvwSalesRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSalesRegister.PageIndex = e.NewPageIndex;
        GetSalesManager();
    }
    protected void GvwPurchaseInvocie_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwPurchaseInvocie.PageIndex = e.NewPageIndex;
        PoDetails(Convert.ToInt64(ID));

    }
    protected void GvwPurchaseInvocie_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("category");
        dt.Columns.Add("catagoryid");
        dt.Columns.Add("Product");
        dt.Columns.Add("productid");
        dt.Columns.Add("PO_Quantity");
        dt.Columns.Add("PO_UnitPrice");
        dt.Columns.Add("taxID");
        dt.Columns.Add("TT");
        dt.Columns.Add("PO_Quantity1");
        dt.Columns.Add("PO_UnitPrice1");
        dt.Columns.Add("taxID1");
        dt.Columns.Add("TT1");
        foreach (GridViewRow gvRow in GvwPurchaseInvocie.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["catagoryid"] = ((HiddenField)gvRow.FindControl("HidCatagory0")).Value;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["productid"] = ((HiddenField)gvRow.FindControl("HidProduct0")).Value;
            dr["PO_Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["PO_UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["taxID"] = ((Label)gvRow.FindControl("Lbltaxid")).Text;
            dr["TT"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
            dr["PO_Quantity1"] = ((TextBox)gvRow.FindControl("TxtInQuantity")).Text;
            dr["PO_UnitPrice1"] = ((TextBox)gvRow.FindControl("TxtInPrice")).Text;

            dr["taxID1"] = ((TextBox)gvRow.FindControl("txttaxid")).Text;
            dr["TT1"] = ((Label)gvRow.FindControl("LblInvocietotalPrice")).Text;
            dt.Rows.Add(dr);

        }
        dt.Rows[e.RowIndex].Delete();
        GvwPurchaseInvocie.DataSource = dt;
        GvwPurchaseInvocie.DataBind();
        this.GvwPurchaseInvocie.Columns[2].Visible = false;
        this.GvwPurchaseInvocie.Columns[4].Visible = false;
        this.GvwPurchaseInvocie.Columns[0].Visible = false;
        double tt = 0.00;
        foreach (GridViewRow gvRow in GvwPurchaseInvocie.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["catagoryid"] = ((HiddenField)gvRow.FindControl("HidCatagory0")).Value;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["productid"] = ((HiddenField)gvRow.FindControl("HidProduct0")).Value;
            dr["PO_Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["PO_UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["taxID"] = ((Label)gvRow.FindControl("Lbltaxid")).Text;
            dr["TT"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
            dr["PO_Quantity1"] = ((TextBox)gvRow.FindControl("TxtInQuantity")).Text;
            dr["PO_UnitPrice1"] = ((TextBox)gvRow.FindControl("TxtInPrice")).Text;

            dr["taxID1"] = ((TextBox)gvRow.FindControl("txttaxid")).Text;
            dr["TT1"] = ((Label)gvRow.FindControl("LblInvocietotalPrice")).Text;

            tt = Convert.ToDouble(((Label)gvRow.FindControl("LblInvocietotalPrice")).Text) + tt;
        }

        Txt_SubTotal.Text = tt.ToString();

    }
    protected void GvwPurchaseInvocie_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
        }
        catch (Exception ex)
        {
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        tbldate.Visible = true;
        Panel2.Visible = true;
        string currentDate = GetDefaultEndDate();
        Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
        Txt_ToDate.Text = currentDate;
        GetSalesManager();
        Panel1.Visible = false;
    
        
    }

    protected void GvwSalesRegister_RowdataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label PoNum =(Label)e.Row.FindControl("lblSONO");
        //        DataTable DT = ClsPurchaseInvoice.GetPartialdataBasedOnPONum(PoNum.Text);
        //        if (DT.Rows.Count >= 1)
        //        {
        //            e.Row.BackColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
        //catch (Exception ex)
        //{

        //    throw;
        //}

    }


    public void AddNewGridRow1()
    {
        BtnInvoiceSave0.Visible = true;
        double SubTotal = 0; double POSubTotal = 0;

        double Total = 0;

        foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please Enter Invoice Quantity.');</script>", false);
                    return;
                }
                string HidCatagory0 = ((HiddenField)row.Cells[3].FindControl("HidCatagory0")).Value;
                string HidProduct0 = ((HiddenField)row.Cells[3].FindControl("HidProduct0")).Value;
                DataTable DT = ClsCheck.Get_PurchaseCheck(TxtPoNo.Text.Trim(), Convert.ToInt32(HidProduct0), Convert.ToInt32(HidCatagory0));
                int POQUANTITY = Convert.ToInt32(((Label)row.Cells[2].FindControl("LblPendingQuantity")).Text);
                double POPrice = Convert.ToDouble(((Label)row.Cells[2].FindControl("LblPrice")).Text);
                // int POQUANTITY = Convert.ToInt32(DT.Rows[0]["PO_QUANTITY"].ToString());
                // int PURCHASEIN = Convert.ToInt32(DT.Rows[0]["PURCHASE_INVOICE"].ToString());
                int TxtInQuantity1 = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text);

                if (POQUANTITY < TxtInQuantity1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Invoice Quantity is greater than Purchase Quantity..');</script>", false);
                    return;
                }

                string PoNo = TxtPoNo.Text;
                int CategoryId = Convert.ToInt32(((HiddenField)row.FindControl("HidCatagory0")).Value);
                int ProductId = Convert.ToInt32(((HiddenField)row.FindControl("HidProduct0")).Value);
                Int32 Quantity = Convert.ToInt32(((TextBox)row.Cells[2].FindControl("TxtInQuantity")).Text);
                double totalprice = Convert.ToDouble(((TextBox)row.Cells[2].FindControl("TxtInPrice")).Text);

                // int lblSubTot = Convert.ToInt32(((TextBox)GvwPurchaseInvocie.FooterRow.FindControl("TxtInQuantity")).Text) * Convert.ToInt32(((TextBox)GvwPurchaseInvocie.FooterRow.FindControl("TxtInPrice")).Text);
                int TxtInQuantity = Convert.ToInt32(((TextBox)row.FindControl("TxtInQuantity")).Text);
                double TxtInPrice = Convert.ToDouble(((TextBox)row.FindControl("TxtInPrice")).Text);

                double TotalPrice= POQUANTITY* Convert.ToDouble(POPrice);

                Label lblPototalPrice= (Label)row.FindControl("LblPOTotalPrice");
                lblPototalPrice.Text= Convert.ToString(TotalPrice.ToString("0.00"));

                double lblSubTot = TxtInQuantity * Convert.ToDouble(TxtInPrice);

                TextBox TxtInTotalPrice = (TextBox)row.FindControl("TxtInTotalPrice");
                TxtInTotalPrice.Text = Convert.ToString(lblSubTot.ToString("0.00"));

                // int lblSubTot = Convert.ToInt32(((TextBox)row.FindControl("TxtInQuantity")).Text) * Convert.ToInt32(((TextBox)row.FindControl("TxtInPrice")).Text);

                DataTable DTTaxRate = new DataTable();
                DTTaxRate = ClsPurchaseInvoice.GetInvoiceTaxRateBaseValue(PoNo, CategoryId, ProductId);
                // Label lblSubTot = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");
                double TaxValue = 0; double POTaxValue = 0;
                if (DTTaxRate.Rows.Count > 0)
                {
                    for (int i = 0; i <= DTTaxRate.Rows.Count - 1; i++)
                    {
                        double POSubTotalbaseVal= Convert.ToDouble(TotalPrice) * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;

                        double SubTotonBaseVal = Convert.ToDouble(lblSubTot) * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;

                        POTaxValue= POTaxValue + (POSubTotalbaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);

                        TaxValue = TaxValue + (SubTotonBaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);
                    }

                }

                POTotalAmount= Convert.ToDouble(TotalPrice) + POTaxValue;
                TotalAmount = Convert.ToDouble(lblSubTot) + TaxValue;

                // double tax = Convert.ToDouble(((TextBox)row.Cells[2].FindControl("txttaxid")).Text);
                // Total = (((Convert.ToDouble(totalprice * Quantity)) * tax) / 100) + (((Convert.ToDouble(totalprice * Quantity))));
                TextBox TxtInvTax = (TextBox)row.FindControl("txttaxid");
                TxtInvTax.Text = Convert.ToString(TaxValue.ToString("0.00"));

                Label Lbltaxid=(Label)row.FindControl("Lbltaxid");
                Lbltaxid.Text= Convert.ToString(POTaxValue.ToString("0.00"));

                Label LbltotalAmount=(Label)row.FindControl("LbltotalAmount");
                LbltotalAmount.Text= POTotalAmount.ToString("0.00");

                Label lbl = (Label)(row.Cells[2].FindControl("LblInvocietotalPrice"));
                lbl.Text = TotalAmount.ToString("0.00");
                POSubTotal = POSubTotal + POTotalAmount;
                SubTotal = SubTotal + TotalAmount;
            }

        }
       // TxtInTotalAmount.Text = Math.Floor(POSubTotal + .49).ToString("0.00");
         TxtInTotalAmount.Text = Convert.ToDouble(POSubTotal).ToString("0.00");
       // Txt_SubTotal.Text = Math.Floor(SubTotal + .49).ToString("0.00");
         Txt_SubTotal.Text = Convert.ToDouble(SubTotal).ToString("0.00");

    }
}
