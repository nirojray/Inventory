using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class GeneratePurchaseOrder : System.Web.UI.Page
{
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
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsPurchaseOrder.GetPO_ApprovedDetails(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            if (ds.Rows.Count > 0)
            {
                GvwSalesRegister.Visible = true;
                GvwSalesRegister.DataSource = ds;
                GvwSalesRegister.DataBind();
                ViewState["Data"] = ds;
                ds.Dispose();
                if (ViewState["PageINdex"] != null)
                    GvwSalesRegister.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
            }
            else
            {
                lblmsg.Text = "NO Data Found...";
                GvwSalesRegister.Visible = false;
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('NO Data Found...');</script>", false);
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
               // DrpAppRej.SelectedIndex = 0; Txt_AppRejReason.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesRegister.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                ViewState["POID"] = ID;
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

                    int supp_id = Convert.ToInt32(dtNew.Rows[0]["suppilerid"]);
                    DataTable dtsup = BusinessLogicLayer.ClsSalesManagerChecking.get_reversecharges(supp_id);

                   
                    TxtPoDate.Text = dtNew.Rows[0]["PO_Date"].ToString();
                    TxtPoNo.Text = dtNew.Rows[0]["PO_Number"].ToString();
                    TxtPoLocation.Text = dtNew.Rows[0]["Location"].ToString();
                    TxtPoSupplier.Text = dtNew.Rows[0]["Supplier"].ToString();
                    TxtType.Text = dtNew.Rows[0]["M_CategoryName"].ToString();
                   // TxtTotalAmount.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    TxtGST.Text = dtNew.Rows[0]["Sup_Vat_Cst"].ToString();
                    txtPaymentterms.Text = dtNew.Rows[0]["Sup_PaymentTerms"].ToString();
                    txtTermsOfDelivery.Text = dtNew.Rows[0]["TermOfDelv"].ToString();
                    TxtPoSupplierState.Text = dtNew.Rows[0]["State_Name"].ToString();
                    txtSupplierState.Text= dtNew.Rows[0]["Sup_StateName"].ToString();
                    txt_hsnac.Text = dtNew.Rows[0]["HSN_SAC_NUM"].ToString();
                    TxtPurchaseType.Text= dtNew.Rows[0]["Purchase_Type"].ToString();
                    txtrevers.Text = dtsup.Rows[0]["Reverse_Charge"].ToString();
                    TxtPanNum.Text = dtsup.Rows[0]["PAN"].ToString();
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
                    TxtShippingAddress.Text = dtNew.Rows[0]["PO_Shipping_TO"].ToString();
                    TxtBillingAddress.Text = dtNew.Rows[0]["PO_Billing_TO"].ToString();
                    TxtSPANumber.Text= dtNew.Rows[0]["SPANumber"].ToString();
                    if(TxtSPANumber.Text!="")
                    {
                        trSpaNum.Visible = true;
                    }
                    else
                    {
                        trSpaNum.Visible = false;
                    }
                }


                PoDetails(Convert.ToInt64(ID));
               // GetSalesManager();

               // ViewState["PageINdex"] = GvwSalesRegister.PageIndex;
            }
        }
        catch (Exception ex)
        { }

    }
    private void PoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(id);
        GvwPurchaseInvocie.DataSource = ds;
        GvwPurchaseInvocie.DataBind();

    }
    protected void BtnGeneratePO_Click(object sender, EventArgs e)
    {
        //if (TxtPoDate.Text.Trim() != string.Empty)
        //{
            ClsPurchaseOrder objClsPur = new ClsPurchaseOrder();
            int Id = objClsPur.Generate_PurchaseOrder(Convert.ToInt32(ViewState["POID"].ToString()));
        if (Id > 0)
        {
            tbldate.Visible = true;
            Panel2.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Purchase Order Generated Successfully....');</script>", false);
            GetSalesManager();
            Panel1.Visible = false;
        }

        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Not Selected...');</script>", false);
        //}

    }
    protected void btnCancel_Click(object Sender, EventArgs e)
    {
        try
        {
            tbldate.Visible = true;
            Panel2.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();
            Panel1.Visible = false;
        }
        catch (Exception)
        {

            throw;
        }

    }
}