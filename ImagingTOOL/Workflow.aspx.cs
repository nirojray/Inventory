using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class Workflow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetpurCount(); GetsaleCount();

        divPurchse.Visible = false;
        divSales.Visible = false;
        divBilling.Visible = false;
        divpurchaserpt.Visible = false;
        divsalesrpt.Visible = false;
       // divReject.Visible = false;
       // divbillingrpt.Visible = false;

        PCMw.Visible = false;
       // PINVA.Visible = false;
        SCMw.Visible = false;
        divSTRPT.Visible = true;
        PO.Visible = false;
        GPO.Visible = false;
        GRN.Visible = false;
        GRNPDF.Visible = false;
        POPDF.Visible = false;
        POINV.Visible = false;
       
        SO.Visible = false;
        SOTINV.Visible = false;
        SIC.Visible = false;
        SICNPDF.Visible = false;
        if ((Convert.ToString(Session["IsAdminFlag"]) == "True"))
        {
            divPurchse.Visible = true;
            divSales.Visible = true;
            divBilling.Visible = true;
            divpurchaserpt.Visible = true;
            divsalesrpt.Visible = true;
           // divbillingrpt.Visible = true;
            //}
            //if ((Convert.ToString(Session["IsAprovalFlag"]) == "True") && (Convert.ToString(Session["IsAdminFlag"]) == "True"))
            //{
            PCMw.Visible = true;
           // PINVA.Visible = true;
            SCMw.Visible = true;

            PO.Visible = true;

            GPO.Visible = true;
            GRN.Visible = true;
            GRNPDF.Visible = true;
            POPDF.Visible = true;
            POINV.Visible = true;

            SO.Visible = true;
            SOTINV.Visible = true;
            SIC.Visible = true;
            SICNPDF.Visible = true;
            // divReject.Visible = true;
        }


        else if (Convert.ToString(Session["UserType"]) == "SM")
        {
            divSales.Visible = true;
            // divBilling.Visible = true;
            divsalesrpt.Visible = true;
            //divbillingrpt.Visible = true;
            SO.Visible = false;
            SOTINV.Visible = false;
            SIC.Visible = false;
            SICNPDF.Visible = false;
            //if (Convert.ToString(Session["IsAprovalFlag"]) == "True")
            //{
            SCMw.Visible = true;
           // divReject.Visible = false;
            //}

        }
        else if (Convert.ToString(Session["UserType"]) == "SR")
        {
            divSales.Visible = true;
           // divBilling.Visible = true;
            divsalesrpt.Visible = true;
            SO.Visible = true;
            SOTINV.Visible = true;
            SIC.Visible = true;
            SICNPDF.Visible = true;
            SCMw.Visible = false;
          //  divReject.Visible = true;
            SORD.Visible = true;
            PORD.Visible = false;

        }
        else if (Convert.ToString(Session["UserType"]) == "BILLING")
        {           
            divBilling.Visible = true;
            divsalesrpt.Visible = true;
            //divbillingrpt.Visible = true;
            SCMw.Visible = false;
        }
        else if (Convert.ToString(Session["UserType"]) == "PM") 
        {
            divPurchse.Visible = true;
            divpurchaserpt.Visible = true;
           // divReject.Visible = false;         
            //if (Convert.ToString(Session["IsAprovalFlag"]) == "True")
            //{
            PCMw.Visible = true;
               // PINVA.Visible = true;
            PO.Visible = false;
            GPO.Visible = false;
            GRN.Visible = false;
            GRNPDF.Visible = false;
            POPDF.Visible = false;
            POINV.Visible = false;
            //}

        }
        else if (Convert.ToString(Session["UserType"]) == "PR")
        {
            divPurchse.Visible = true;
            divpurchaserpt.Visible = true;
            PO.Visible = true;
           // divReject.Visible = true;
            SORD.Visible = false;
            PORD.Visible = true;
            GPO.Visible = true;
            GRN.Visible = true;
            GRNPDF.Visible = true; 
            POPDF.Visible = true;
            POINV.Visible = true;
            PCMw.Visible = false;
           // PINVA.Visible = false;
        }

    }

    private void GetpurCount()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsCheck.Get_Purchase_apr_pending_count();

            wrk_PO_check.Text = ds.Rows[0]["count"].ToString();

        }
        catch (Exception ex)
        {
        }

    }
    private void GetsaleCount()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsCheck.Get_sales_apr_pending_count();

            wrk_SO_check.Text = ds.Rows[0]["count"].ToString();

        }
        catch (Exception ex)
        {
        }

    }
}