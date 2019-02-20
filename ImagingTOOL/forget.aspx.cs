using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class forget : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
            if (txtEmailID.Text.Trim() != string.Empty)
            {
                DataTable dt = BusinessServices.Imaging_forgotPassword_GetData(txtEmailID.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    string email = dt.Rows[0][1].ToString();
                    if (email == null || email == "")
                    {
                        AlertPageHelper.ShowAlert(this.Page, "Please contact IT team for your password");
                        txtEmailID.Text = "";
                    }
                    else
                    {
                        if (BusinessServices.Imaging_ForgotPassword_Insert(Convert.ToInt32(dt.Rows[0][0].ToString()), email))
                        {
                            AlertPageHelper.ShowAlert(this.Page, "Login credentials has been sent to your email address..");
                            txtEmailID.Text = "";


                        }
                        else
                        {
                            AlertPageHelper.ShowAlert(this.Page, "Please try again, To get our password.");

                        }
                    }
                }
                else
                {
                    AlertPageHelper.ShowAlert(this.Page, "Email ID not registered,Please Enter Correct Email ID.");
                   // txtEmailID.Text = "";
                }


            }
            else
                {
                    AlertPageHelper.ShowAlert(this.Page, "Please Enter Email Address.");
                    
                }
    }
    
}