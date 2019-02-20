using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
using HelperClass;

public partial class DiscrepancyBetweenPOandSupplierInvocie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        if (TxtFromDate.Text != string.Empty && TxtToDate.Text != string.Empty)
        {
            
            DateTime fromdate = Convert.ToDateTime(TxtFromDate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(TxtToDate.Text.ToString());

            if (fromdate <= Todate)
            {

                DataSet ds = new DataSet();
                DateTime StartDate = Convert.ToDateTime(TxtFromDate.Text);
                DateTime EndDate = Convert.ToDateTime(TxtToDate.Text);
                DataTable dt1 = ClsReportDiscrepancy.Get_TaxDifference(StartDate, EndDate);
                if (dt1.Rows.Count > 0)
                {
                    ds.Tables.Add(dt1);

                    ds.Tables[0].TableName = "TAX Difference";


                    ExcelHelper.ToExcel(ds, "TAX_Difference.xls", Page.Response);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found...');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Todate Should be Greater than or equal to Fromdate');</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Date...');</script>", false);
        }
        
    }
    protected void BtnExport0_Click(object sender, EventArgs e)
    {
        if (TxtFromDate0.Text != string.Empty && TxtToDate0.Text != string.Empty)
        {

            DateTime fromdate = Convert.ToDateTime(TxtFromDate0.Text.ToString());
            DateTime Todate = Convert.ToDateTime(TxtToDate0.Text.ToString());

            if (fromdate <= Todate)
            {

                DataSet ds = new DataSet();
                DateTime StartDate = Convert.ToDateTime(TxtFromDate0.Text);
                DateTime EndDate = Convert.ToDateTime(TxtToDate0.Text);
                DataTable dt1 = ClsReportDiscrepancy.Get_PriceDifference(StartDate, EndDate);
                if (dt1.Rows.Count > 0)
                {
                    ds.Tables.Add(dt1);


                    ds.Tables[0].TableName = "Price Difference";


                    ExcelHelper.ToExcel(ds, "Price_Difference.xls", Page.Response);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found...');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Todate Should be Greater than or equal to Fromdate');</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Date...');</script>", false);
        }
    }
}