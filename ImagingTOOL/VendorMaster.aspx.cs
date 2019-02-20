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

public partial class VendorMaster : System.Web.UI.Page
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
            DT = BusinessServices.Get_VendorName(txtSearch.Text.Trim());
            GvVendor.DataSource = DT;
            GvVendor.DataBind();            
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
        txtVendor.Text = "";
        ddlActive.SelectedIndex = 0;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DTVendorNameExists = BusinessServices.Check_VendorName_Exists(txtVendor.Text.Trim());

            if (DTVendorNameExists.Rows.Count > 0)
            {
                lbl_msg.Text = "VendorName Already Exists";
                return;
            }

            bool result = BusinessServices.Insert_VendorName(txtVendor.Text.Trim(), Convert.ToInt32(ddlActive.SelectedValue));
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
    protected void GvVendor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            GridViewRow row = GvVendor.Rows[e.NewEditIndex];
            int index = Int32.Parse(row.RowIndex.ToString());

            int_TSID = Convert.ToInt32(((Label)(GvVendor.Rows[index].FindControl("lblVendore_Id"))).Text);

            Session["VID"] = int_TSID;           
            txtVendor.Text = ((Label)(GvVendor.Rows[index].FindControl("lbl_VendorName"))).Text;
            string Activestatus = ((Label)(GvVendor.Rows[index].FindControl("lblActive"))).Text;

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
    protected void GvVendor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GvVendor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvVendor.PageIndex = e.NewPageIndex;
        GetGrd();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DTTaxExists = BusinessServices.VendorName_Existsupdate(Convert.ToInt32(Session["VID"]), txtVendor.Text.Trim());
            if (DTTaxExists.Rows.Count > 0)
            {
                lbl_msg.Text = "Vendor Name Already Exists";
                return;
            }
            bool result = BusinessServices.Update_VedorName(Convert.ToInt32(Session["VID"]), txtVendor.Text.Trim(), Convert.ToInt32(ddlActive.SelectedValue));

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