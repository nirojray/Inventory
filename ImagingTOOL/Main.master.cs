using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            master.Visible = false;
            admin.Visible = false;
            lpurchase.Visible = false;
            LPRN.Visible = false;
            lSales.Visible = false;
            lBilling.Visible = false;
            lSalesReport.Visible = false;
           // lBillingReport.Visible = false;
            lPurchaseReport.Visible = false;
            PCM.Visible = false;
           // PINVA.Visible = false;
            SMC.Visible = false;
            LiStrpt.Visible = true;
           // PO.Visible = false;
           // PRN.Visible = false;
            SPA.Visible = false;
            SAAU.Visible = false;
            SPAU.Visible = false;
            PRN1.Visible = false;
            GPO.Visible = false;
            GRN.Visible = false;
            GRNPDF.Visible = false;
            PRD.Visible = false;
            POPDF.Visible = false;
            POINV.Visible = false;
           // PINVA.Visible = false;
            SO.Visible = false;
            SOTINV.Visible = false;
            SORD.Visible = false;
            SIC.Visible = false;
            SICNPDF.Visible = false;
            lblUserName.Text = Session["FullName"].ToString();

            if ((Convert.ToString(Session["IsAdminFlag"]) == "True"))
            {
                master.Visible = true;
                admin.Visible = true;               
                lSales.Visible = true;
                lpurchase.Visible = true;
                LPRN.Visible = true;
                lBilling.Visible = true;
                lSalesReport.Visible = true;
               // lBillingReport.Visible = true;
                lPurchaseReport.Visible = true;
                SO.Visible = true;
                SOTINV.Visible = true;
                SORD.Visible = true;
                SIC.Visible = true;
                SICNPDF.Visible = true;
                // PO.Visible = true;
                // PRN.Visible = true;
                SPA.Visible = true;
                SAAU.Visible = true;
                SPAU.Visible = true;
                PRN1.Visible = true;
                GPO.Visible = true;
                GRN.Visible = true;
                GRNPDF.Visible = true;
                PRD.Visible = true;
                POPDF.Visible = true;
                POINV.Visible = true;
              //  PINVA.Visible = true;

                //}

                //if ((Convert.ToString(Session["IsAprovalFlag"]) == "True") && (Convert.ToString(Session["IsAdminFlag"]) == "True"))
                //{                
                PCM.Visible = true;
               // PINVA.Visible = true;
                SMC.Visible = true;
            }
           else if (Convert.ToString(Session["UserType"]) == "SM")
            {
                lSales.Visible = true;
                SO.Visible = false;
                SOTINV.Visible = false;
                SORD.Visible = false;
                SIC.Visible = false;
                SICNPDF.Visible = false;
                //lBilling.Visible = true;
                //SO.Visible = true;
                //SOTINV.Visible = true;
                lSalesReport.Visible = true;
               // lBillingReport.Visible = true;

                //if (Convert.ToString(Session["IsAprovalFlag"]) == "True")
                //{
                SMC.Visible = true;
                //}

            }
            else if (Convert.ToString(Session["UserType"]) == "SR")
            {
                lSales.Visible = true;
                //lBilling.Visible = true;
                lSalesReport.Visible = true;
                SO.Visible = true;
                SOTINV.Visible = true;
                SORD.Visible = true;
                SIC.Visible = true;
                SICNPDF.Visible = true;
            }
            else if (Convert.ToString(Session["UserType"]) == "BILLING")
            {                
                lBilling.Visible = true;
                lSalesReport.Visible = true;
                //lBillingReport.Visible = true;
            }
            else if ( (Convert.ToString(Session["UserType"]) == "PM") )
            {
               lpurchase.Visible = true;
                LPRN.Visible = true;
                lPurchaseReport.Visible = true;
               // PO.Visible = false;
               // PRN.Visible = false;
                SPA.Visible = false;
                SAAU.Visible = false;
                SPAU.Visible = false;
                PRN1.Visible = false;
                GPO.Visible = false;
                GRN.Visible = false;
                GRNPDF.Visible = false;
                PRD.Visible = false;
                POPDF.Visible = false;
                POINV.Visible = false;

                //if (Convert.ToString(Session["IsAprovalFlag"]) == "True")
                //{
                PCM.Visible = true;
                  //  PINVA.Visible = true;
                //}
            }
            else if (Convert.ToString(Session["UserType"]) == "PR")
            {
                lpurchase.Visible = true;
                LPRN.Visible = true;
                lPurchaseReport.Visible = true;
               // PO.Visible = true;
               // PRN.Visible = true;
                SPA.Visible = true;
                SAAU.Visible = true;
                SPAU.Visible = true;
                PRN1.Visible = true;
                GPO.Visible = true;
                GRN.Visible = true;
                GRNPDF.Visible = true;
                PRD.Visible = true;
                POPDF.Visible = true;
                POINV.Visible = true;

            }


        }
    }
}
