using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
public partial class PurchaseOrderInvoiceApproval : System.Web.UI.Page
{
    bool result1 = false; bool result2;
    double SubTotal;
    double TaxAmount;

    int int_LocationId;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["LoginName"] != null)
            {                
                string currentDate = GetDefaultEndDate();
                Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
                Txt_ToDate.Text = currentDate;
                GetSalesManager();
               // Session["RetrivalValuePOID"] = Request.QueryString["Page"].ToString();
                Panel1.Visible = false;
            }
            else
            {
                Session["RetrivalValue"] = Request.QueryString["Page"].ToString();
                Response.Redirect("Login.aspx", false);
            }
        }
       
    }
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsPurchaseInvoice.Get_PurchaseOrderForPurchaseInvoiceApproval(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            if (ds.Rows.Count > 0)
            {
                GvwSalesRegister.Visible = true;
                GvwSalesRegister.DataSource = ds;
                GvwSalesRegister.DataBind();
                ViewState["Data"] = ds;
                ds.Dispose();
                if (ViewState["PageINdex"] != null)
                    GvwSalesRegister.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
                lblmsg.Text = "";
            }
            else
            {
                GvwSalesRegister.Visible = false;
                lblmsg.Text = "NO Data Found...";
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
                Panel1.Visible = true;
                Panel2.Visible = false;
                tbldate.Visible = false;
                ddlInvoiceApproval.SelectedIndex = 0;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesRegister.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("PO_ID='" + ID + "'");


                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();


                    TxtPoDate.Text = dtNew.Rows[0]["PO_Date"].ToString();
                    TxtPoNo.Text = dtNew.Rows[0]["PO_Number"].ToString();
                    TxtPoLocation.Text = dtNew.Rows[0]["Location"].ToString();
                    TxtPoSupplier.Text = dtNew.Rows[0]["Supplier"].ToString();
                    TxtTotalAmount.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    Txt_SubTotal.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    TxtInTotalAmount.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    Txt_shippingAdress.Text = dtNew.Rows[0]["ShippingAddress"].ToString();
                    int_LocationId = Convert.ToInt32(dtNew.Rows[0]["locationID"].ToString());
                    Session["int_LocationId"] = Convert.ToInt32(dtNew.Rows[0]["locationID"].ToString());
                }


                PoDetails(Convert.ToInt64(ID));
                GetSalesManager();

                double SubTotal = 0;

                double Total = 0;


                foreach (GridViewRow row1 in GvwPurchaseInvocie.Rows)
                {
                    if (row1.RowType == DataControlRowType.DataRow)
                    {
                        Label LblInvocietotalPrice = (Label)row1.FindControl("LblInvocietotalPrice");
                        //Int32 Quantity = Convert.ToInt32(((TextBox)row1.Cells[2].FindControl("TxtInQuantity")).Text);
                        //double totalprice = Convert.ToDouble(((TextBox)row1.Cells[2].FindControl("TxtInPrice")).Text);
                        //double tax = Convert.ToDouble(((TextBox)row1.Cells[2].FindControl("txttaxid")).Text);
                        //Total = (((Convert.ToDouble(totalprice * Quantity)) * tax) / 100) + (((Convert.ToDouble(totalprice * Quantity))));

                        //Label lbl1 = (Label)(row1.Cells[2].FindControl("LblInvocietotalPrice"));
                        //lbl1.Text = Total.ToString();
                        
                        SubTotal = SubTotal + Convert.ToDouble(LblInvocietotalPrice.Text);
                    }

                }

                Txt_SubTotal.Text = Convert.ToDouble(SubTotal).ToString(".00");
                ViewState["PageINdex"] = GvwSalesRegister.PageIndex;
            }
        }
        catch (Exception ex)
        { }

    }
    private void PoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoiceInInvoiceApproval(id);
        GvwPurchaseInvocie.DataSource = ds;
        GvwPurchaseInvocie.DataBind();
        if (ds.Rows.Count > 0)
        {
            Txt_InvoiceNo.Text = ds.Rows[0]["InvoiceNumber"].ToString();
            string Invoicedate = ds.Rows[0]["InvoiceDate"].ToString();
            Txt_InvoiceDate.Text = GetDefaultStartDate(Convert.ToDateTime(Invoicedate));
        }

    }
    protected void BtnInvoiceSave_Click(object sender, EventArgs e)
    {
        try
        {
            ClsPurchaseInvoice objclsinvc = new ClsPurchaseInvoice();
            if (Txt_InvoiceNo.Text != string.Empty && Txt_InvoiceDate.Text != string.Empty)
            {

                if (ddlInvoiceApproval.SelectedValue == "1")
                {
                    string asd = hidDetails_ID.Value;
                    DateTime PODATE = Convert.ToDateTime(TxtPoDate.Text);
                    string ponumber = TxtPoNo.Text;

                    int invoiceid;
                    DateTime invoicedate = DateTime.Now;
                    string invoiceno = ""; string totalAmount = "";
                    invoicedate = Convert.ToDateTime(Txt_InvoiceDate.Text.Trim());
                    invoiceno = Txt_InvoiceNo.Text.Trim();

                    totalAmount = Txt_SubTotal.Text.Trim();
                    //taxid = Convert.ToInt32(DrpTaxType.SelectedItem.Value);

                    result2 = ClsPurchaseInvoice.InsertPurchaseInvoiceFromInvoiceApproval(out invoiceid, Convert.ToInt32(asd), ponumber, PODATE,
                      invoiceno, invoicedate, Convert.ToDouble(totalAmount), Convert.ToInt32(Session["Id"]), Convert.ToInt32(ddlInvoiceApproval.SelectedValue));
                    if (result2)
                    {
                        //Panel1.Visible = false;
                        //Panel2.Visible = true;
                        //tbldate.Visible = true;
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
                            result1 = ClsPurchaseInvoice.InsertPurchaseInvoicedetails1(invoiceid, Convert.ToInt32(asd), HidCatagory0, HidProduct0,
                                LblQuantity, LblPrice, POTaxPrice, pototalamount,
                                Convert.ToInt32(TxtInQuantity), Convert.ToDouble(TxtInPrice), InvoiceTaxPrice, invoicetotalamount, Convert.ToInt32(Session["Id"].ToString()), loaction, LblProduct, invoicedate, MainLocation,Convert.ToInt32(Session["int_LocationId"]));
                            
                        }

                    }
                }
                else
                {
                    bool Reject;
                    string HPOID = hidDetails_ID.Value;
                    Reject=ClsPurchaseInvoice.PurchaseOrderInvoiceQuantityReject(Convert.ToInt32(HPOID),ddlInvoiceApproval.SelectedValue);
                    if (Reject)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('invoice Rejected...');</script>", false);
                    }
                }
                //if(ddlInvoiceApproval.SelectedValue=="1")
                //{
                    string pono = TxtPoNo.Text;
                DataTable dtPOInvoice = new DataTable();
                //foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
                //{
                //    if (row.RowType == DataControlRowType.DataRow)
                //    {
                //        string HidProduct0 = ((HiddenField)row.Cells[3].FindControl("HidProduct0")).Value;
                //        DataTable DT = ClsCheck.Get_PurchaseCheck(TxtPoNo.Text.Trim(), Convert.ToInt32(HidProduct0));
                //        int POQUANTITY = Convert.ToInt32(DT.Rows[0]["PO_QUANTITY"].ToString());
                //        int PURCHASEIN = Convert.ToInt32(DT.Rows[0]["PURCHASE_INVOICE"].ToString());
                //        int TxtInQuantity = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text);

                        // DataTable dtPOInvoice = new DataTable();

                        dtPOInvoice.Columns.Add("Catagory", typeof(string));
                                dtPOInvoice.Columns.Add("Product", typeof(string));
                                dtPOInvoice.Columns.Add("POQuantity", typeof(string));
                                dtPOInvoice.Columns.Add("POPrice", typeof(string));
                                dtPOInvoice.Columns.Add("POTax", typeof(string));
                                dtPOInvoice.Columns.Add("POTotalPrice", typeof(string));
                                dtPOInvoice.Columns.Add("InvoicQuantity", typeof(string));
                                dtPOInvoice.Columns.Add("InvoicePrice", typeof(string));
                                dtPOInvoice.Columns.Add("InvoiceTax", typeof(string));
                                dtPOInvoice.Columns.Add("InvoiceTotalPrice", typeof(string));

                                foreach (GridViewRow gvRow in GvwPurchaseInvocie.Rows)
                                {
                                    DataRow drInvDet = dtPOInvoice.NewRow();
                                    drInvDet["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                                    drInvDet["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                                    drInvDet["POQuantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                                    int PO_Quantity = Convert.ToInt32(((Label)gvRow.FindControl("LblQuantity")).Text);
                                    drInvDet["POPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                                    drInvDet["POTax"] = ((Label)gvRow.FindControl("Lbltaxid")).Text;
                                    drInvDet["POTotalPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                                    drInvDet["InvoicQuantity"] = ((TextBox)gvRow.FindControl("TxtInQuantity")).Text;
                                    int InvoiceQuantity = Convert.ToInt32(((TextBox)gvRow.FindControl("TxtInQuantity")).Text);
                                    drInvDet["InvoicePrice"] = ((TextBox)gvRow.FindControl("TxtInPrice")).Text;
                                    drInvDet["InvoiceTax"] = ((TextBox)gvRow.FindControl("txttaxid")).Text;
                                    drInvDet["InvoiceTotalPrice"] = ((Label)gvRow.FindControl("LblInvocietotalPrice")).Text;
                                    dtPOInvoice.Rows.Add(drInvDet);
                                                                       
                                }
                               // int i = objclsinvc.PurchaseOrderInvoiceQuantityApproval_RejectStatusFromPOM(TxtPoNo.Text, TxtPoLocation.Text, TxtPoDate.Text, dtPOInvoice,ddlInvoiceApproval.SelectedValue,Txt_InvoiceNo.Text);
                               // this.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "<script type=text/javascript>alert('Check Invoice Quantity')</script>");                               
                            
                       // }
                   // }
                int i = objclsinvc.PurchaseOrderInvoiceQuantityApproval_RejectStatusFromPOM(TxtPoNo.Text, TxtPoLocation.Text, TxtPoDate.Text, dtPOInvoice, ddlInvoiceApproval.SelectedValue, Txt_InvoiceNo.Text);

                // }

                Txt_InvoiceNo.Text = "";
                Txt_InvoiceDate.Text = "";
                Txt_SubTotal.Text = "0.00";

                TxtInTotalAmount.Text = "0.00";
                GetSalesManager();
                Panel1.Visible = false; Panel2.Visible = true;tbldate.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Fill Invoice Number and Invoice Date...');</script>", false);
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

                Int32 Quantity = Convert.ToInt32(((TextBox)row.Cells[2].FindControl("TxtInQuantity")).Text);
                double totalprice = Convert.ToDouble(((TextBox)row.Cells[2].FindControl("TxtInPrice")).Text);
                double tax = Convert.ToDouble(((TextBox)row.Cells[2].FindControl("txttaxid")).Text);
                Total = (((Convert.ToDouble(totalprice * Quantity)) * tax) / 100) + (((Convert.ToDouble(totalprice * Quantity))));

                Label lbl = (Label)(row.Cells[2].FindControl("LblInvocietotalPrice"));
                lbl.Text = Total.ToString();
                SubTotal = SubTotal + Total;
            }

        }

        Txt_SubTotal.Text = Convert.ToDouble(SubTotal).ToString(".00");

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

    protected void BtnCancel_Click(object sender,EventArgs e)
    {
        tbldate.Visible = true;
        Panel2.Visible = true;
        string currentDate = GetDefaultEndDate();
        Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
        Txt_ToDate.Text = currentDate;
        GetSalesManager();
        Panel1.Visible = false;
    }
}