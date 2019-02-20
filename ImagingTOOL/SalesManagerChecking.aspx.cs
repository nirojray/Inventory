using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class SalesManagerChecking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();

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
                Panel2.Visible = true;
                Panel1.Visible = false;
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
    protected void GvwSalesManagerChecking_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "Edit1")
            {
                Panel2.Visible = false;
                Panel1.Visible = true;
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
                    TxtSODate.Text = dtNew.Rows[0]["SoDate"].ToString();
                    txtState.Text = dtNew.Rows[0]["State"].ToString();
                    TxtLocation.Text = dtNew.Rows[0]["Location"].ToString();
                    txtsalesType.Text = dtNew.Rows[0]["SalesType"].ToString();
                    TxtCustomer.Text = dtNew.Rows[0]["Customer"].ToString();
                    TxtCustmerOrderno.Text = dtNew.Rows[0]["CusutomerOrderNO"].ToString();
                    TxtCustmerOrderdate.Text = dtNew.Rows[0]["CusutomerOrderdate"].ToString();
                    txtCreditPeriod.Text = dtNew.Rows[0]["CreditPeriod"].ToString();                    
                    txtWarranty.Text = dtNew.Rows[0]["Warranty"].ToString();
                    txtRepresentative.Text = dtNew.Rows[0]["Representative"].ToString();
                    txttype.Text = dtNew.Rows[0]["MainCategoryType"].ToString();
                    Lbl_TotalAmount.Text = dtNew.Rows[0]["SO_NetAmount"].ToString();
                    TxtShippingAddress.Text = dtNew.Rows[0]["ShippingAddress"].ToString();
                    TxtBillingAddress.Text = dtNew.Rows[0]["BillingAddress"].ToString();
                    DataTable Dt = BusinessServices.Imaging_GetBillShipAddCustomer(int.Parse(dtNew.Rows[0]["CustomerId"].ToString()));
                    TxtCustState.Text = Dt.Rows[0]["State_Name"].ToString();
                    txtVatCst.Text= Dt.Rows[0]["VATCST"].ToString();
                    txtPAN.Text = Dt.Rows[0]["PAN"].ToString();
                    txtReverseCharge.Text = Dt.Rows[0]["REVERSECharge"].ToString();
                    DataTable dt = BusinessLogicLayer.ClsSalesOrder.BindHSN_SAC_Code(Convert.ToInt32(dtNew.Rows[0]["MainCategoryTypeID"]));
                    if (txttype.Text == "Scanners" || txttype.Text == "Consumable" || txttype.Text == "Software")
                    {
                        lblHSN_SAC_Code.Text = ""; TxtHSN_SAC_Code.Text = "";
                        lblHSN_SAC_Code.Text = "HSN Code";
                        TxtHSN_SAC_Code.Visible = true;
                        TxtHSN_SAC_Code.Text = dt.Rows[0]["HSN_SAC_NUM"].ToString();
                    }
                    else
                    {
                        lblHSN_SAC_Code.Text = ""; TxtHSN_SAC_Code.Text = "";
                        lblHSN_SAC_Code.Text = "SCA Code";
                        TxtHSN_SAC_Code.Visible = true;
                        TxtHSN_SAC_Code.Text = dt.Rows[0]["HSN_SAC_NUM"].ToString();
                    }
                    
                }              
                
                SoDetails(Convert.ToInt64(ID));
                GetSalesManager();

                if (txttype.Text== "Service" || txttype.Text == "Support" || txttype.Text == "Rental" || txttype.Text == "Any other services")
                {
                    GvwSaleseOrderDetails.Columns[3].Visible = false;
                }
                else
                {
                    GvwSaleseOrderDetails.Columns[3].Visible = true;
                }


                //DataTable dt=ClsSalesManagerChecking.get_address_ID( Convert.ToInt64(ID));
                //if (dt.Rows.Count > 0)
                //{
                //    string conString = null;
                //   //foreach(DataRow r in dt.Rows)
                //   //{
                //   //    address = Items["AddressID"].ToString(); // .ToString();
                //   //}
                //   for (int i=0; i < dt.Rows.Count; i++)
                //   {

                //       string address = dt.Rows[i]["Addr"].ToString();
                //           if (conString != null) conString += "," + address;
                //           else conString = address;

                //   }
                //   lblmsg2.Text = conString;
                //}
            }
                ViewState["PageINdex"] = GvwSalesManagerChecking.PageIndex;
            
        }
        catch (Exception ex)
        {
        

        
        }

    }
    private DataTable fillDataTable(DataTable dt)
    {
        return dt;
    }
    private void SoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsSalesManagerChecking.Get_SalesOrderforApproval(id);
        GvwSaleseOrderDetails.DataSource = ds;
        GvwSaleseOrderDetails.DataBind();
        for (int i = 0; i < ds.Rows.Count; i++)
        {
            if (ds.Rows.Count > 0)
            {
                GvwSaleseOrderDetails.Rows[i].Cells[3].BackColor = System.Drawing.Color.Yellow;
            }
        }

    }

    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsSalesManagerChecking.Get_SalesOrder(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            GvwSalesManagerChecking.DataSource = ds;
            GvwSalesManagerChecking.DataBind();

            if(ds.Rows.Count>0)
            {
                lblmessage.Text = "";
            }
            else {
                lblmessage.Text = "No Records Found...";

            }
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
           GvwSalesManagerChecking.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
           

        }
        catch (Exception ex)
        {
        }

    }
    protected void BtnAppRejSave_Click(object sender, EventArgs e)
    {
        ClsSalesOrder clsSalses = new ClsSalesOrder();
        if (!string.IsNullOrEmpty(hidDetails_ID.Value))
        {

            //For Mails

            DataTable dtPODetMail = new DataTable();
            dtPODetMail.Columns.Add("CatagoryName", typeof(string));
            dtPODetMail.Columns.Add("ProductName", typeof(string));
            dtPODetMail.Columns.Add("Current_Stock", typeof(int));
            dtPODetMail.Columns.Add("Quantity", typeof(int));

            foreach (GridViewRow gvRow in GvwSaleseOrderDetails.Rows)
            {
                if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                {
                    int PendingQuantity = Convert.ToInt16(((Label)gvRow.FindControl("LblPendingQuantity")).Text);
                    int Current_Stock = Convert.ToInt16(((Label)gvRow.FindControl("LblCurrentStock")).Text);
                    if (Current_Stock < PendingQuantity)
                    {
                        DataRow drDetMail = dtPODetMail.NewRow();
                        drDetMail["CatagoryName"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                        drDetMail["ProductName"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                        drDetMail["Current_Stock"] = Convert.ToInt16(((Label)gvRow.FindControl("LblCurrentStock")).Text);
                        drDetMail["Quantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblPendingQuantity")).Text);
                        dtPODetMail.Rows.Add(drDetMail);
                    }
                }
            }
            DataRow[] drModel = dtPODetMail.Select("Current_Stock=0");

            DataTable dtNew = new DataTable();
            dtNew = dtPODetMail.Clone();
            if (drModel.Length > 0)
            {
                foreach (DataRow dr in drModel)
                {
                    dtNew.ImportRow(dr);
                }
                dtNew.AcceptChanges();
            }

           if (dtNew.Rows.Count == GvwSaleseOrderDetails.Rows.Count)
            {
                if (txttype.Text != "Service" && txttype.Text != "Support" && txttype.Text != "Rental" && txttype.Text != "Any other services")
                {
                    int SentMailResult = clsSalses.Send_Mail_ZeroStock_So_ProductDetails(dtPODetMail, txtState.Text.Trim(), TxtLocation.Text.Trim());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Stock is not available...');</script>", false);
                    Txt_AppRejReason.Text = "";
                    DrpAppRej.SelectedIndex = 0;
                    GetSalesManager();

                    Panel2.Visible = true; Panel1.Visible = false;
                }
                else
                {
                    string asd = hidDetails_ID.Value;
                    bool result = ClsSalesManagerChecking.Update_SO_AppReject(Convert.ToInt32(asd), Convert.ToInt32(DrpAppRej.SelectedValue.Trim()), Txt_AppRejReason.Text.Trim(), Convert.ToInt32(Session["Id"]));

                    if (result)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);
                        Txt_AppRejReason.Text = "";
                        DrpAppRej.SelectedIndex = 0;
                        GetSalesManager();

                        Panel2.Visible = true; Panel1.Visible = false;

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
                    }
                }
            }
            else
            {
                string asd = hidDetails_ID.Value;
                bool result = ClsSalesManagerChecking.Update_SO_AppReject(Convert.ToInt32(asd), Convert.ToInt32(DrpAppRej.SelectedValue.Trim()), Txt_AppRejReason.Text.Trim(), Convert.ToInt32(Session["Id"]));
                if (txttype.Text != "Service" && txttype.Text != "Support" && txttype.Text != "Rental" && txttype.Text != "Any other services")
                {
                    if (dtPODetMail.Rows.Count > 0)
                    {
                        int SentMailResult = clsSalses.Send_Mail_ZeroStock_So_ProductDetails(dtPODetMail, txtState.Text.Trim(), TxtLocation.Text.Trim());
                    }
                }
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);
                    Txt_AppRejReason.Text = "";
                    DrpAppRej.SelectedIndex = 0;
                    GetSalesManager();

                    Panel2.Visible = true; Panel1.Visible = false;

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
                }
            }
        }
       
    }
    protected void GvwSalesManagerChecking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSalesManagerChecking.PageIndex = e.NewPageIndex;
        GetSalesManager();
    }
    protected void GvwSaleseOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSaleseOrderDetails.PageIndex = e.NewPageIndex;
        SoDetails(Convert.ToInt64(ID));
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            Txt_AppRejReason.Text = "";
            DrpAppRej.SelectedIndex = 0;
            GetSalesManager();
                       
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void GvwSaleseOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblProduct = (Label)e.Row.FindControl("LblProduct");
                Label LblCurrentStock = (Label)e.Row.FindControl("LblCurrentStock");
                HiddenField HfdProductId = (HiddenField)e.Row.FindControl("HidProduct0");
                DataTable DtStock = BusinessServices.Get_ProductStock(TxtLocation.Text, Convert.ToInt32(HfdProductId.Value));
                LblCurrentStock.Text = DtStock.Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}