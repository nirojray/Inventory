using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class AdminUserCreation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserType();
            BindUserNameDetails();
        }
    }

    public void GetUserType()
    {
        DataTable dt = BusinessServices.BindUserType();
        ddlUserType.Items.Clear();
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

    public void BindUserNameDetails()
    {
        DataTable DT = BusinessServices.BindUserNameDetails(txtSearch.Text.Trim());
        gvSearch.DataSource = DT;
        gvSearch.DataBind();
        if (DT.Rows.Count > 0)
        {
           
        }
        else
        {
           // ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Username not exists..');</script>", false);

        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {

        string Demo = txtEmailID.Text.Trim();
        string[] tokens = Demo.Split('@');
        string last = tokens[tokens.Length - 1].ToUpper();
        string last1 = tokens[tokens.Length - 1];
        string Direct = "CENTILLIONSS.COM";
            if (last !=Direct)
        {
            lblMsg.Text = "Please provide a Centillion email addres";
            return;
        }

        lblMsg.Text = "";
        //string newemail = txtEmailID.Text.ToString();
        //DataTable dt = BusinessServices.Imaging_forgotPassword_GetData(txtEmailID.Text.Trim());

        //if (dt.Rows.Count > 0)
        //{
        //    string email = dt.Rows[0][1].ToString();
        //    if (newemail == email)
        //    {
        //        this.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "<script type=text/javascript>alert('Email Id Aldeary Registered in IMG Inventory Application')</script>");
        //        return;
        //    }

        //}
        //else
        //{
        DataTable Dt = BusinessServices.CheckExistUserLoginNameForInsert(txtFullname.Text.Trim(), txtEmailID.Text.Trim(), ddlUserType.SelectedItem.Text.Trim());
        if (Dt.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('UserName Exists..');</script>", false);
            BindUserNameDetails();
        }
        else
        {
            

            bool result = BusinessServices.Imaging_UserID_CREATION_Insert(txtUSername.Text.Trim(), txtFullname.Text.Trim(), txtEmailID.Text.Trim(), ddlUserType.SelectedItem.Text.Trim());
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('User Name Details Created Successfully..');</script>", false);
                clear(); BindUserNameDetails();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);
                BindUserNameDetails();
            }
        }
        //}
    }     
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCreate.Visible = true;btnUpdate.Visible = false;
        clear(); BindUserNameDetails();
    }
    public void clear()
    {
        txtUSername.Text = "";
        txtFullname.Text = "";
        txtEmailID.Text = "";
        txtSearch.Text = "";

        lblMsg.Text = "";
        GetUserType();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindUserNameDetails();
    }
    protected void btnClear_Click(object Sender, EventArgs e)
    {
        clear(); btnCreate.Visible = true; btnUpdate.Visible = false;
        BindUserNameDetails();

    }
    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearch.PageIndex = e.NewPageIndex;
        BindUserNameDetails();
    }
    protected void gvSearch_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edited")
            {
                btnUpdate.Visible = true; btnCreate.Visible = false;
                int id = Convert.ToInt32(e.CommandArgument);
                Session["Uid"] = id;
                DataTable dt = BusinessServices.GetUserNameDetails(Convert.ToInt32(Session["Uid"]));
                if (dt.Rows.Count > 0)
                {
                    txtUSername.Text= dt.Rows[0]["FullName"].ToString();
                    txtFullname.Text = dt.Rows[0]["LoginName"].ToString();
                    GetUserType();               
                    ddlUserType.SelectedValue = dt.Rows[0]["UTypeId"].ToString();                   
                    txtEmailID.Text = dt.Rows[0]["EmailId"].ToString();                    
                }
            }           
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string Demo = txtEmailID.Text.Trim();
            string[] tokens = Demo.Split('@');
            string last = tokens[tokens.Length - 1].ToUpper();
            string last1 = tokens[tokens.Length - 1];
            string Direct = "CENTILLIONSS.COM";
            if (last != Direct)
            {
                lblMsg.Text = "Please provide a Centillion email addres";
                return;
            }

            lblMsg.Text = "";
            DataTable Dt = BusinessServices.CheckExistUserLoginNameForUpdate(Convert.ToInt32(Session["Uid"]), txtFullname.Text.Trim(), txtEmailID.Text.Trim(), ddlUserType.SelectedItem.Text.Trim());
            if (Dt.Rows.Count > 0)
            {
                btnUpdate.Visible = true; btnCreate.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('already UserName Exists..');</script>", false);
                BindUserNameDetails();
            }
            else
            {
                bool result = BusinessServices.Imaging_UserID_CREATION_Update(Convert.ToInt32(Session["Uid"]), txtUSername.Text.Trim(), txtFullname.Text.Trim(), txtEmailID.Text.Trim(), ddlUserType.SelectedItem.Text.Trim());
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('User Name Details Updated Successfully..');</script>", false);
                    clear();
                    btnUpdate.Visible = false; btnCreate.Visible = true;
                    BindUserNameDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Update Failed..');</script>", false);
                    btnUpdate.Visible = true; btnCreate.Visible = false;
                    BindUserNameDetails();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
     
    }
}