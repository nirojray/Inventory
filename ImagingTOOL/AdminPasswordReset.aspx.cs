using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class AdminPasswordReset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            GetUserType();
            //loadControls();
          
        }
    }

    private void loadControls()
    {
        DataTable dt = BusinessServices.Imaging_Admin_GetUserNameList(ddlUserType.SelectedItem.Text);
        ddl_USername.DataSource = dt;
        ddl_USername.DataTextField = "LoginName";
        ddl_USername.DataValueField = "Id";
        ddl_USername.DataBind();
        ddl_USername.Items.Insert(0, new ListItem("------Select------", "0"));
        ddl_USername.SelectedIndex = 0;
    }

    public void GetUserType()
    {
        DataTable dt = BusinessServices.BindUserType();
        if (dt.Rows.Count > 0)
        {
            ddlUserType.Items.Clear();
            ddlUserType.DataSource = dt;
            ddlUserType.DataTextField = "UserType";
            ddlUserType.DataValueField = "Id";
            ddlUserType.DataBind();
            ddlUserType.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(ddl_USername.SelectedValue);

        bool result = BusinessServices.Imaging_Admin_passwordReset(userId,ddlUserType.SelectedItem.Text.Trim());
        bool result1 = BusinessServices.Imaging_Admin_passwordResetmailAlert(userId, ddlUserType.SelectedItem.Text.Trim());
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Selected User Password has been Reset..');</script>", false);
        GetUserType();
        loadControls();

    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadControls();
        }
        catch (Exception)
        {

            throw;
        }
    }
}