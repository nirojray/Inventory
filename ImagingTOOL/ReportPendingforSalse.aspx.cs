using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using HelperClass;
using System.Data;

public partial class ReportPendingforSalse : System.Web.UI.Page
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

                DateTime StartDate = Convert.ToDateTime(TxtFromDate.Text);
                DateTime EndDate = Convert.ToDateTime(TxtToDate.Text);
                DataTable dt1 = ClsReportOrderPending.Get_OrderPendingsalse(StartDate, EndDate);
                if (dt1.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt1);
                    ds.Tables[0].TableName = "OrderPendingDetails(Salse)";
                    ExcelHelper.ToExcel(ds, "Order_Pending_From_Supplier(Sales).xls", Page.Response);
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