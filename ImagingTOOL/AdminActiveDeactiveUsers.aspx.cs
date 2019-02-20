using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class AdminActiveDeactiveUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadControlsActive();
            loadControlsDeActive();
        }
    }

    private void loadControlsActive()
    {
        DataTable dt = BusinessServices.Imaging_Admin_GetUserNameList_Active();
        ddl_USernameActivate.DataSource = dt;
        ddl_USernameActivate.DataTextField = "LoginName";
        ddl_USernameActivate.DataValueField = "Id";
        ddl_USernameActivate.DataBind();
        ddl_USernameActivate.Items.Insert(0, new ListItem("-----Select-----", "0"));
        ddl_USernameActivate.SelectedIndex = 0;
    }
    private void loadControlsDeActive()
    {
        DataTable dt = BusinessServices.Imaging_Admin_GetUserNameList_DEActive();
        ddl_USernameDeActive.DataSource = dt;
        ddl_USernameDeActive.DataTextField = "LoginName";
        ddl_USernameDeActive.DataValueField = "Id";
        ddl_USernameDeActive.DataBind();
        ddl_USernameDeActive.Items.Insert(0, new ListItem("-----Select-----", "0"));
        ddl_USernameDeActive.SelectedIndex = 0;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(ddl_USernameActivate.SelectedValue);
        bool result = BusinessServices.Imaging_Admin_ActivateUser(userId); //.deActivateUser(userId);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Selected User has been Activated..');</script>", false);
        loadControlsActive();
        loadControlsDeActive();
    }
    protected void btnResetdeact_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(ddl_USernameDeActive.SelectedValue);
        bool result = BusinessServices.Imaging_Admin_DeActivateUser(userId);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Selected User has been De-Activated..');</script>", false);
        loadControlsActive();
        loadControlsDeActive();
    }
}