using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using System.IO;

public partial class RptReorderLevel : System.Web.UI.Page
{
   ReorderLevelRpt objR = new ReorderLevelRpt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                //TxtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                //TxtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

            }
        }
    }

    //Creating the Table in Excel Dynamically  
    public string ConvertDataTableToHTML(DataTable dt, string name)
    {
        int count = dt.Columns.Count;
        string html = "<table   align='center' style='width: 100%; border: 1px solid #000000'><tr><th style='background-color:#A2B9F7' align='center' colspan='" + count + "'>" + name.ToString() + "</th></tr> </table><table border='1'>";
        // string html = "<table border='1' ><tr><td align='center'></td></tr> ";

        //add header row
        html += "<tr>";
        for (int i = 0; i < dt.Columns.Count; i++)
            html += "<th style='background-color:#A2B9F7'>" + dt.Columns[i].ColumnName + "</th>";
        html += "</tr>";
        //add rows
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            for (int j = 0; j < dt.Columns.Count; j++)
                html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        return html;
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime FromDate = Convert.ToDateTime(TxtFromDate.Text.ToString());
           // DateTime ToDate = Convert.ToDateTime(TxtToDate.Text.ToString());
            DataTable DTSO = objR.Get_ReorderLevel();
            if (DTSO.Rows.Count > 1)
            {
                lblmsg.Text = "";
                string ss = "";
                StringWriter sw1 = new StringWriter();
                HtmlTextWriter hw1 = new HtmlTextWriter(sw1);
                string rptHeading = "INVENTORY RE-ORDER LEVEL";
                ss = ConvertDataTableToHTML(DTSO, rptHeading);

                Response.AppendHeader("content-disposition", "attachment;filename=ReorderLevel.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                this.EnableViewState = false;
                //Exporting the Chart control into excel
                string sw = "<table><tr>" + "<td>" + ss + "</td> </tr></table>";
                Response.Write(sw);
                Response.End();

            }
            else
            {
                lblmsg.Text = "No Records...";
            }
        }
        catch (Exception ex)
        {

        }


    }
}
