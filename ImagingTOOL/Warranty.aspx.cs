using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogicLayer;

public partial class Warranty : System.Web.UI.Page
{
    int int_TSID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGrd();
        }
    }
    private void GetGrd()
    {
        DataTable DT = new DataTable();
        try
        {
            string Cust = txtSearch.Text;
            DT = BusinessServices.Get_WarrantyName(txtSearch.Text.Trim());
            GvWarranty.DataSource = DT;
            GvWarranty.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    private void Clear()
    {
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        lbl_msg.Text = "";
        txtWarranty.Text = "";
        ddlActive.SelectedIndex = 0;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DTWarrantyNameExists = BusinessServices.Check_WarrantyName_Exists(txtWarranty.Text.Trim());

            if (DTWarrantyNameExists.Rows.Count > 0)
            {
                lbl_msg.Text = "WarrantyName Already Exists";
                return;
            }

            bool result = BusinessServices.Insert_WarrantyName(txtWarranty.Text.Trim(), Convert.ToInt32(ddlActive.SelectedValue));
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                Clear();
                GetGrd();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearch.Text = "";
            GetGrd();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnsearch_click(object sender, EventArgs e)
    {
        try
        {
            GetGrd();
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void GvWarranty_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            GridViewRow row = GvWarranty.Rows[e.NewEditIndex];
            int index = Int32.Parse(row.RowIndex.ToString());

            int_TSID = Convert.ToInt32(((Label)(GvWarranty.Rows[index].FindControl("lblWarranty_Id"))).Text);

            Session["VID"] = int_TSID;
            txtWarranty.Text = ((Label)(GvWarranty.Rows[index].FindControl("lbl_WarrantyName"))).Text;
            string Activestatus = ((Label)(GvWarranty.Rows[index].FindControl("lblActive"))).Text;

            if (Activestatus == "Active")
            {
                ddlActive.SelectedValue = "1";

            }
            else
            {
                ddlActive.SelectedValue = "0";
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DTTaxExists = BusinessServices.WarrantyName_Existsupdate(Convert.ToInt32(Session["VID"]), txtWarranty.Text.Trim());
            if (DTTaxExists.Rows.Count > 0)
            {
                lbl_msg.Text = "Warranty Name Already Exists";
                return;
            }
            bool result = BusinessServices.Update_WarrantyName(Convert.ToInt32(Session["VID"]), txtWarranty.Text.Trim(), Convert.ToInt32(ddlActive.SelectedValue));

            if (result)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Updated Successfully..');</script>", false);
                Clear();
                GetGrd();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Updation Failed..');</script>", false);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
}