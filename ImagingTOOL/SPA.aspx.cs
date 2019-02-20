using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SPA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_click(object sender,EventArgs e)
    {
        try {
            if (drpSPA.SelectedValue != "0")
            {
                Session["SPA"] = drpSPA.SelectedValue;
                if (drpSPA.SelectedValue == "1")
                {
                    Response.Redirect("~/ServiceAttachApproval.aspx", true);
                }
                else
                {
                    Session["SANo"] = "0";
                    Session["SPAStatus"] = "0";
                    Response.Redirect("~/SpecialPriceApproval.aspx", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Special Price Approval Option.');</script>", false);
                return;
            }
        }
        catch (Exception ex)
        {

        }
    }
}