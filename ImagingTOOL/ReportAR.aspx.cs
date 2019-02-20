using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using HelperClass;

public partial class ReportAR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        if (TxtFromDate.Text != string.Empty && TxtToDate.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            DateTime StartDate = Convert.ToDateTime(TxtFromDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(TxtToDate.Text.ToString());
           
            //GvwAR.DataSource = dt_values;
            //GvwAR.DataBind();
            if (StartDate <= EndDate)
            {
                DataTable dt_values = ClsReportAR.Report_AR(StartDate, EndDate);

                if (dt_values.Rows.Count > 0)
                {
                    ds.Tables.Add(dt_values);


                    ds.Tables[0].TableName = "Agewise Receivables";


                    ExcelHelper.ToExcel(ds, "AgewiseReceivables.xls", Page.Response);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found...');</script>", false);
                }
                //    grid();
                //    if (GvwAR.Rows.Count > 0)
                //    {
                //        Response.Clear();
                //        Response.Buffer = true;
                //        Response.AddHeader("content-disposition", "attachment;filename=AgewiseReceivables.xls");
                //        Response.Charset = "";
                //        Response.ContentType = "application/vnd.ms-excel";
                //        using (StringWriter sw = new StringWriter())
                //        {
                //            HtmlTextWriter hw = new HtmlTextWriter(sw);

                //            //To Export all pages
                //            GvwAR.AllowPaging = false;
                //            this.grid();
                //            GvwAR.HeaderRow.Style.Add("background-color", "#FFFFFF");

                //            foreach (TableCell cell in GvwAR.HeaderRow.Cells)
                //            {
                //                cell.BackColor = GvwAR.HeaderStyle.BackColor;
                //            }
                //            foreach (GridViewRow row in GvwAR.Rows)
                //            {
                //                row.Style.Add("background-color", "white");
                //                //row.BackColor = Color.White;
                //                foreach (TableCell cell in row.Cells)
                //                {
                //                    if (row.RowIndex % 2 == 0)
                //                    {
                //                        cell.BackColor = GvwAR.AlternatingRowStyle.BackColor;
                //                    }
                //                    else
                //                    {
                //                        cell.BackColor = GvwAR.RowStyle.BackColor;
                //                    }
                //                    cell.CssClass = "textmode";
                //                }
                //            }

                //            GvwAR.RenderControl(hw);

                //            //style to format numbers to string
                //            string style = @"<style> .textmode { } </style>";
                //            Response.Write(style);
                //            Response.Output.Write(sw.ToString());
                //            Response.Flush();
                //            Response.End();
                //        }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found');</script>", false);
                //}
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    public void grid()
    {

        DateTime StartDate = Convert.ToDateTime(TxtFromDate.Text);
        DateTime EndDate = Convert.ToDateTime(TxtToDate.Text);

        DataTable dt_values = ClsReportAR.Report_AR(StartDate, EndDate);
        GvwAR.DataSource = dt_values;
        GvwAR.DataBind();


    }
}