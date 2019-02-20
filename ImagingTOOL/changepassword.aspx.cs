using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

public partial class changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (txtbox_OldPassword.Text.Trim() != string.Empty && txtbox_newPassword1.Text.Trim() != string.Empty && txtbox_newPassword2.Text.Trim() != string.Empty)
        {
            string oldpassword = txtbox_OldPassword.Text.Trim();
            string newPassword = txtbox_newPassword1.Text.Trim();
            string confirmPassword = txtbox_newPassword2.Text.Trim();
            if (BusinessServices.Login_ChangePassword(Convert.ToInt32(Session["ID"]), oldpassword, newPassword))
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Password Changed Successfully..');</script>", false);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Old Password not Matching..');</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill All Fields..');</script>", false);
        }
    }
}