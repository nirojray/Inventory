using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class Regionalrepresentative : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetMasterList("LOS", ddlLocation);
            BindRepresentative(); btnCreate.Enabled = true;
        }
    }

    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DrpList.Items.Clear();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }
        catch (Exception Ex)
        {

        }
    }
    public void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable Dt = BusinessServices.ExistingRepresentativeName(Convert.ToInt32(ddlLocation.SelectedValue),Txtname.Text.Trim());
            if (Dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Representative Name already Exist');</script>", false);
                BindRepresentative();
            }
            else
            {
                bool result = BusinessServices.InsertRepresentativeName(Convert.ToInt32(ddlLocation.SelectedValue),Txtname.Text.Trim(),TxtDesignation.Text.Trim(),TxtEmail.Text.Trim(),Convert.ToInt32(ddlStatus.SelectedValue));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Representative Name Created Successfully..');</script>", false);
                    Clear(); BindRepresentative();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);
                    BindRepresentative();


                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void Clear()
    {
        ddlLocation.SelectedValue = "-1";
        Txtname.Text = "";
        TxtDesignation.Text = "";
        TxtEmail.Text = "";
        ddlStatus.SelectedValue = "1";
    }
    public void BindRepresentative()
    {
        try
        {
            DataTable Dt = BusinessServices.BindRepresentativeName(txtSearch.Text.Trim());
            if (Dt.Rows.Count > 0)
            {
                gvSearch.Visible = true;
                lblMsg.Text = "";
                gvSearch.DataSource = Dt;
                gvSearch.DataBind();
            }
            else
            {
                gvSearch.Visible = false;
                lblMsg.Text = "No recods found..";
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            btnUpdate.Enabled = false;
            BindRepresentative();
        }
        catch (Exception ex)
        {          
        }
    }
    public void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();txtSearch.Text = ""; btnUpdate.Enabled = false; btnCreate.Enabled = true;
            BindRepresentative();
           
        }
        catch (Exception ex)
        {
        }
    }
    public void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clear(); txtSearch.Text = "";
            BindRepresentative();
            btnUpdate.Enabled = false; btnCreate.Enabled = true;
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvSearch_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edited")
            {
                btnUpdate.Enabled = true; btnCreate.Enabled = false;
                int id = Convert.ToInt32(e.CommandArgument);
                Session["Repid"] = id;
                DataTable dt = BusinessServices.GetRepresentativeName(Convert.ToInt32(Session["Repid"]));
                if (dt.Rows.Count > 0)
                {
                   // GetMasterList("LOS", ddlLocation);
                    ddlLocation.SelectedValue= dt.Rows[0]["Location"].ToString();
                    Txtname.Text = dt.Rows[0]["Name"].ToString();
                    TxtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    TxtEmail.Text = dt.Rows[0]["Email"].ToString();
                    ddlStatus.SelectedValue= dt.Rows[0]["Status"].ToString();
                }
            }
            if (e.CommandName == "Deleted")
            {
                btnContinue.Visible = true;
                btnDisContinue.Visible = true;
                int Representid = Convert.ToInt32(e.CommandArgument);
                Session["Representid"] = Representid;
                string str = "Do you want to delete?";
                string script = "<script type='text/javascript' language='javascript'>";
                script += "if (confirm('" + str.ToString() + "')) {document.getElementById('" + btnContinue.ClientID + "').click(); }else{ document.getElementById('" + btnDisContinue.ClientID + "').click();  };"; script += "</script>";
                if (script != "<script type='text/javascript' language='javascript'></script>")
                    if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                        Page.RegisterStartupScript("clientScript2", script);
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearch.PageIndex = e.NewPageIndex;
        BindRepresentative();
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = BusinessServices.DeleteRepresentativeName(Convert.ToInt32(Session["Representid"]));
            string msg = "Representative Name is deleted.";
            string script = "<script type='text/javascript' language='javascript'>";
            script += "alert('" + msg.ToString() + "' );"; script += "</script>";
            if (script != "<script type='text/javascript' language='javascript'></script>")
                if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                    Page.RegisterStartupScript("clientScript2", script);

            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
            BindRepresentative();

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnDisContinue_Click(object sender, EventArgs e)
    {
        try
        {
            BindRepresentative();
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnUpdate_click(object Sender, EventArgs e)
    {
        try
        {
            //DataTable Dt = BusinessServices.ExistingRepresentativeName(Convert.ToInt32(ddlLocation.SelectedValue), Txtname.Text.Trim());

            //// if(Convert.ToInt32(Session["id"])==Convert.ToInt32(Dt.Rows[0]["TaxNameID"].ToString()))
            //if (Dt.Rows.Count > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Representative Name already Exist');</script>", false);
            //    BindRepresentative();
            //}
            //else
            //{
                bool result = BusinessServices.UpdateRepresentativeName(Convert.ToInt32(Session["Repid"]),Convert.ToInt32(ddlLocation.SelectedValue),Txtname.Text.Trim(),TxtDesignation.Text.Trim(),TxtEmail.Text.Trim(),Convert.ToInt32(ddlStatus.SelectedValue));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Representative Name Updated Successfully..');</script>", false);
                    BindRepresentative();Clear(); btnUpdate.Enabled = false; btnCreate.Enabled = true;
            }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Update Failed..');</script>", false);
                    BindRepresentative();
                }
           // }
        }
        catch (Exception ex)
        {
        }
    }
}