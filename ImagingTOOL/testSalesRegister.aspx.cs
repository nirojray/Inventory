using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class testSalesRegister : System.Web.UI.Page
{
    bool result1 = false; bool result2;
    double SubTotal;
    double TaxAmount;
    double TotalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
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
            ds = ClsSalesRegister.Get_SalesOrderForSaleRegister(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            GvwSalesManagerChecking.DataSource = ds;
            GvwSalesManagerChecking.DataBind();
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSalesManagerChecking.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


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

    private void SoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsSalesRegister.Get_SalesOrderforInvocie(id);
        GvwPurchaseInvocie.DataSource = ds;
        GvwPurchaseInvocie.DataBind();

    }
    protected void BtnInvoiceSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (Txt_InvoiceDate.Text != "" && Txt_InvoiceNo.Text != "")
            {

                //Check point
                //--t_purchase order detail and t_purchareinvoicedetail
                //string pono = TxtPoNo.Text;
                foreach (GridViewRow row in GvwPurchaseInvocie.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string HidProduct0 = ((HiddenField)row.Cells[3].FindControl("HidProduct0")).Value;
                        DataTable DT = ClsCheck.Get_SalesCheck(TxtPoNo.Text.Trim(), Convert.ToInt32(HidProduct0));
                        int POQUANTITY = Convert.ToInt32(DT.Rows[0]["SO_QUANTITY"].ToString());
                        int PURCHASEIN = Convert.ToInt32(DT.Rows[0]["SALES_INVOICE"].ToString());
                        int TxtInQuantity = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("TxtInQuantity")).Text);
                        if (POQUANTITY < PURCHASEIN + TxtInQuantity)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "<script type=text/javascript>alert('Check Invoice Quantity')</script>");
                            return;
                        }
                    }
                }


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
                result2 = ClsSalesRegister.InsertSalesInvoice(out invoiceid, Convert.ToInt32(asd), ponumber, PODATE,
                  invoiceno, invoicedate, Convert.ToDouble(totalAmount), Convert.ToInt32(Session["Id"]));
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

                        string loaction = TxtSoLocation.Text.Trim(); 

                        result1 = ClsSalesRegister.InsertSalesInvoicedetails(invoiceid, Convert.ToInt32(asd), HidCatagory0, HidProduct0,
                            LblQuantity, LblPrice, POTaxPrice, pototalamount,
                            Convert.ToInt32(TxtInQuantity), Convert.ToDouble(TxtInPrice), InvoiceTaxPrice, invoicetotalamount, Convert.ToInt32(Session["Id"].ToString()), loaction, LblProduct, invoicedate);





                    }

                }



                Txt_InvoiceNo.Text = "";
                Txt_InvoiceDate.Text = "";
                Txt_SubTotal.Text = "0.00";

                TxtInTotalAmount.Text = "0.00";
                GetSalesManager();
                Panel1.Visible = false; Panel2.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
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


    protected void GvwPurchaseInvocie_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwPurchaseInvocie.PageIndex = e.NewPageIndex;
        SoDetails(Convert.ToInt64(ID));
    }
    protected void GvwSalesManagerChecking_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit1")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesManagerChecking.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("SO_ID='" + ID + "'");


                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();

                    TxtVertical.Text = dtNew.Rows[0]["Vertical"].ToString();
                    TxtPoDate.Text = dtNew.Rows[0]["SoDate"].ToString();
                    TxtSoLocation.Text = dtNew.Rows[0]["Location"].ToString();
                    TxtSoSupplier.Text = dtNew.Rows[0]["Supplier"].ToString();
                    TxtPoNo.Text = dtNew.Rows[0]["SO_Number"].ToString();
                    TxtTotalAmount.Text = dtNew.Rows[0]["SO_NetAmount"].ToString();
                    Txt_SubTotal.Text = dtNew.Rows[0]["SO_NetAmount"].ToString();
                    TxtInTotalAmount.Text = dtNew.Rows[0]["SO_NetAmount"].ToString();
                    TxtCustomerOrderDate.Text = dtNew.Rows[0]["CusutomerOrderdate"].ToString();
                    TxtCustomerOrderNo.Text = dtNew.Rows[0]["CusutomerOrderNO"].ToString();
                    TxtBillingAdress.Text = dtNew.Rows[0]["biling"].ToString();
                    
                }


                SoDetails(Convert.ToInt64(ID));
                GetSalesManager();
                DataTable dt = ClsSalesManagerChecking.get_address_ID(Convert.ToInt64(ID));
                if (dt.Rows.Count > 0)
                {
                    string conString = null;
                    //foreach(DataRow r in dt.Rows)
                    //{
                    //    address = Items["AddressID"].ToString(); // .ToString();
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        string address = dt.Rows[i]["Addr"].ToString();
                        if (conString != null) conString += "," + address;
                        else conString = address;

                    }
                    TxtshippingAdress.Text = conString;
                }
                ViewState["PageINdex"] = GvwSalesManagerChecking.PageIndex;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void GvwSalesManagerChecking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSalesManagerChecking.PageIndex = e.NewPageIndex;
        GetSalesManager();
    }
    protected void GvwPurchaseInvocie_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("category");
        dt.Columns.Add("catagoryid");
        dt.Columns.Add("Product");
        dt.Columns.Add("productid");
        dt.Columns.Add("SO_Quantity");
        dt.Columns.Add("SO_UnitPrice");
        dt.Columns.Add("taxID");
        dt.Columns.Add("TT");
        dt.Columns.Add("SO_Quantity1");
        dt.Columns.Add("SO_UnitPrice1");
        dt.Columns.Add("taxID1");
        dt.Columns.Add("TT1");
        foreach (GridViewRow gvRow in GvwPurchaseInvocie.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["catagoryid"] = ((HiddenField)gvRow.FindControl("HidCatagory0")).Value;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["productid"] = ((HiddenField)gvRow.FindControl("HidProduct0")).Value;
            dr["SO_Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["SO_UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["taxID"] = ((Label)gvRow.FindControl("Lbltaxid")).Text;
            dr["TT"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
            dr["SO_Quantity1"] = ((TextBox)gvRow.FindControl("TxtInQuantity")).Text;
            dr["SO_UnitPrice1"] = ((TextBox)gvRow.FindControl("TxtInPrice")).Text;

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
            dr["SO_Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["SO_UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["taxID"] = ((Label)gvRow.FindControl("Lbltaxid")).Text;
            dr["TT"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
            dr["SO_Quantity1"] = ((TextBox)gvRow.FindControl("TxtInQuantity")).Text;
            dr["SO_UnitPrice1"] = ((TextBox)gvRow.FindControl("TxtInPrice")).Text;

            dr["taxID1"] = ((TextBox)gvRow.FindControl("txttaxid")).Text;
            dr["TT1"] = ((Label)gvRow.FindControl("LblInvocietotalPrice")).Text;

            tt = Convert.ToDouble(((Label)gvRow.FindControl("LblInvocietotalPrice")).Text) + tt;
        }

        Txt_SubTotal.Text = tt.ToString();

    }
}