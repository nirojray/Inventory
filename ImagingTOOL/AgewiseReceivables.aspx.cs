using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
public partial class AgewiseReceivables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = Panel1.Enabled = false;

        if (!IsPostBack)
        {
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();
           // GetMasterList("CU", DrpCustomer);
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
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsAR.Get_SalesOrderForAR(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
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
    private void SoInvoiceDetails(Int64 id,string SoInvoiceNum)
    {

        DataTable ds = new DataTable();

        ds = ClsAR.Get_ARDetails(id, SoInvoiceNum);
        GvwARDetails.DataSource = ds;
        GvwARDetails.DataBind();

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
    protected void GvwSalesManagerChecking_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit1")
            {
                Panel1.Visible = Panel1.Enabled = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesManagerChecking.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                Label lblhidennInvcID = (Label)row.FindControl("hidennInvcID");

                string InvcId = lblhidennInvcID.Text;

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("SO_ID='" + ID + "' AND Invoice_Id='" + InvcId + "'");


                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();
                  
                    TxtSoNo.Text = dtNew.Rows[0]["SO_Number"].ToString();
                    TxtInvoiceNo.Text = dtNew.Rows[0]["Invoice_Number"].ToString();
                    TxtInvoiceDate.Text = dtNew.Rows[0]["Invocie_Date"].ToString();
                    double Invocie_TotalAmount = Convert.ToDouble(dtNew.Rows[0]["Invocie_TotalAmount"].ToString());
                   // TxtInvoiceAmount.Text = Math.Floor(Invocie_TotalAmount + 0.49).ToString("0.00");
                    TxtInvoiceAmount.Text = Invocie_TotalAmount.ToString("0.00");
                    // TxtInvoiceAmount.Text = dtNew.Rows[0]["Invocie_TotalAmount"].ToString();
                    txtnameofcust.Text = dtNew.Rows[0]["Customer"].ToString();
                    TxtCreditPeriod.Text = dtNew.Rows[0]["CreditPeriod"].ToString();
                    double BalAmt = Convert.ToDouble(dtNew.Rows[0]["BalAmt"].ToString());
                   // TxtBalForCollection.Text = Math.Floor(BalAmt + 0.49).ToString("0.00");
                    TxtBalForCollection.Text = BalAmt.ToString("0.00");
                   // HiddenFieldbal.Value = Math.Floor(BalAmt + 0.49).ToString("0.00");
                    HiddenFieldbal.Value = BalAmt.ToString("0.00");
                    // TxtBalForCollection.Text= dtNew.Rows[0]["BalAmt"].ToString();
                    // HiddenFieldbal.Value = dtNew.Rows[0]["BalAmt"].ToString();
                    TxtDays.Text = dtNew.Rows[0]["Days"].ToString();
                    TxtAmountReceived.Text = "";
                    //TxtSODate.Text = dtNew.Rows[0]["SoDate"].ToString();
                }


                SoInvoiceDetails(Convert.ToInt64(ID), TxtInvoiceNo.Text);
                GetSalesManager();

                ViewState["PageINdex"] = GvwSalesManagerChecking.PageIndex;
            }
        }
        catch (Exception ex)
        { }

    }
 
    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();

        }
        catch (Exception Ex)
        {

        }
    }
    private void clear()
    {
        TxtInvoiceDate.Text = "";
        txtnameofcust.Text = "";
        TxtAmountReceived.Text = "0.00";
        TxtCreditPeriod.Text = "0.00";
        TxtInvoiceNo.Text = "";
        TxtInvoiceAmount.Text = "0.00";
        TxtBalForCollection.Text = "0.00";
        TxtDays.Text = "";
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

       
            if (!string.IsNullOrEmpty(hidDetails_ID.Value))
            {

                string asd = hidDetails_ID.Value;
            decimal BalAmt = Convert.ToDecimal(HiddenFieldbal.Value.Trim()) - Convert.ToDecimal(TxtAmountReceived.Text.Trim());
                bool result = ClsAR.Insert_AR_Details(Convert.ToInt32(asd), Convert.ToDateTime(TxtInvoiceDate.Text.Trim()),TxtInvoiceNo.Text.Trim(), txtnameofcust.Text.Trim(), 
                    Convert.ToDecimal(TxtInvoiceAmount.Text.Trim()),Convert.ToDecimal(TxtAmountReceived.Text.Trim()), BalAmt,
                   TxtCreditPeriod.Text, Convert.ToInt32(TxtDays.Text.Trim()), Convert.ToInt32(Session["Id"]));
                if (result)
                {
                GetSalesManager();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);
                

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
                }


              
            }
       
    }
    protected void PopCalendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void GvwSalesManagerChecking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSalesManagerChecking.PageIndex = e.NewPageIndex;
        GetSalesManager();
    }
    protected void GvwARDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwARDetails.PageIndex = e.NewPageIndex;
       // SoInvoiceDetails(Convert.ToInt64(ID));
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

}