using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtusername.Focus();
        

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtusername.Text.Trim() != string.Empty && txtusername.Text.Trim() != "Username" && txtpassword.Text.Trim() != string.Empty && txtpassword.Text.Trim() != "password")
        {

           
                string userName = txtusername.Text.Trim();
                string password = txtpassword.Text.Trim();
                DataTable dt = BusinessServices.Imaging_Login(userName, password);
            if (dt.Rows.Count > 0)
            {
                Session["Id"] = dt.Rows[0]["Id"].ToString();
                Session["FullName"] = dt.Rows[0]["FullName"].ToString();
                Session["LoginName"] = dt.Rows[0]["LoginName"].ToString();
                Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                Session["EmailId"] = dt.Rows[0]["EmailId"].ToString();
                Session["IsAdminFlag"] = dt.Rows[0]["IsAdminFlag"].ToString();
                Session["IsActive"] = dt.Rows[0]["IsActive"].ToString();
                Session["IsAprovalFlag"] = dt.Rows[0]["IsAprovalFlag"].ToString();
                if (Session["RetrivalValue"] == null)
                {
                    Response.Redirect("Workflow.aspx", false);
                }
                else
                {
                    Response.Redirect("PurchaseOrderInvoiceApproval.aspx", false);
                }
            }
            else
            {
                AlertPageHelper.ShowAlert(this.Page, "User Name or Password not matching..");
                txtpassword.Text = "";
                txtusername.Text = "";
            }
          
        }
        else if( (txtusername.Text.Trim() == "Username" || txtusername.Text.Trim() == "" )&& (txtpassword.Text.Trim() == "Password" ||txtpassword.Text.Trim() == ""))
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Fill UserName and Password");
        }
        else if (txtusername.Text.Trim() == "Username" || txtusername.Text.Trim() == "")
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Fill UserName");
        }
        else if (txtpassword.Text.Trim() == "Password" || txtpassword.Text.Trim() == "")
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Fill Password");
        }

        else
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Fill UserName and Password");
        }
    }
}