﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using HelperClass;

public partial class SORejectedReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        try
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
                    DataTable dt1 = ClsReportSalesRegister.ReportSalesOrderRejected(StartDate, EndDate);
                    if (dt1.Rows.Count > 0)
                    {
                        ds.Tables.Add(dt1);


                        ds.Tables[0].TableName = "Sales Order Reject";


                        ExcelHelper.ToExcel(ds, "Sales_Order_Reject.xls", Page.Response);
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
        catch (Exception ex)
        { }

    }
}