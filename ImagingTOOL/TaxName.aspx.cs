using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

public partial class TaxName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTaxName(); btnCreate.Enabled = true;
        }
    }

    public void BindTaxName()
    {
        try
        {
            DataTable Dt = BusinessServices.BindTaxName(txtSearch.Text.Trim());
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
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable Dt = BusinessServices.ExistingTaxName(txtTaxname.Text.Trim());
            if (Dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Tax Name already Exist');</script>", false);
            }
            else
            {
                bool result = BusinessServices.InsertTaxName(txtTaxname.Text.Trim(),Convert.ToInt32(ddlStatus.SelectedValue),Convert.ToInt32(TxtRank.Text));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Tax Name Created Successfully..');</script>", false);
                    txtTaxname.Text = "";TxtRank.Text = "";
                    ddlStatus.SelectedValue = "1";
                    BindTaxName();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);
                    BindTaxName();
                }
            }
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
                Session["Tid"] = id;
                DataTable dt = BusinessServices.GetTaxName(Convert.ToInt32(Session["Tid"]));
                if (dt.Rows.Count > 0)
                {
                    txtTaxname.Text = dt.Rows[0]["TaxName"].ToString();
                    TxtRank.Text= dt.Rows[0]["Rank"].ToString();
                    ddlStatus.SelectedValue= dt.Rows[0]["Status"].ToString();

                }
            }
            if (e.CommandName == "Deleted")
            {
                btnContinue.Visible = true;
                btnDisContinue.Visible = true;
                int Taxid = Convert.ToInt32(e.CommandArgument);
                Session["TaxId"] = Taxid;
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
        BindTaxName();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            btnUpdate.Enabled = false;
            BindTaxName();
            
        }
        catch (Exception Ex)
        {
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearch.Text = ""; txtTaxname.Text = "";TxtRank.Text = "";
            BindTaxName(); btnUpdate.Enabled = false; btnCreate.Enabled = true;
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnCancel_click(object sender, EventArgs e)
    {
        try
        {
            
            BindTaxName(); btnUpdate.Enabled = false; txtSearch.Text = "";txtTaxname.Text = ""; ddlStatus.SelectedValue = "1"; btnCreate.Enabled = true;TxtRank.Text = "";
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_click(object Sender, EventArgs e)
    {
        try
        {
            DataTable Dt = BusinessServices.ExistingTaxNameForUpdate(Convert.ToInt32(Session["Tid"]),txtTaxname.Text.Trim());

           // if(Convert.ToInt32(Session["id"])==Convert.ToInt32(Dt.Rows[0]["TaxNameID"].ToString()))
            if (Dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Tax Name already Exist');</script>", false);
            }
            else
            {
                bool result = BusinessServices.UpdateTaxName(Convert.ToInt32(Session["Tid"]), txtTaxname.Text.Trim(),Convert.ToInt32(ddlStatus.SelectedValue),Convert.ToInt32(TxtRank.Text));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Tax Name Updated Successfully..');</script>", false);
                    txtTaxname.Text = ""; ddlStatus.SelectedValue = "1"; BindTaxName();btnUpdate.Enabled = false;btnCreate.Enabled = true;TxtRank.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Update Failed..');</script>", false);
                    BindTaxName();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = BusinessServices.DeleteTaxName(Convert.ToInt32(Session["TaxId"]));
            string msg =  "Tax Name is deleted.";
            string script = "<script type='text/javascript' language='javascript'>";
            script += "alert('" + msg.ToString() + "' );"; script += "</script>";
            if (script != "<script type='text/javascript' language='javascript'></script>")
                if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                    Page.RegisterStartupScript("clientScript2", script);
           
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
            BindTaxName();

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnDisContinue_Click(object sender, EventArgs e)
    {
        try
        {
            BindTaxName();
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }

}