using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class LockScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {

            lbldownname.Text = Session["FullName"].ToString();
            lblUpName.Text = Session["FullName"].ToString();
            lblemailid.Text = Session["EmailId"].ToString();
        }


    }
    protected void btncheck_Click(object sender, EventArgs e)
    {
        if (txtpassword.Text.Trim() != string.Empty)
        {
            DataTable dt = BusinessServices.Imaging_LockScreen_GetPassword(txtpassword.Text.Trim(), Convert.ToInt32(Session["Id"].ToString()));

            if (dt.Rows.Count > 0)
            {

                Response.Redirect("Workflow.aspx");

            }
            else
            {
                AlertPageHelper.ShowAlert(this.Page, "Please Enter Correct Password");
            }


        }
        else
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Enter the Password");
        }
    }
}