using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class Admin_Location : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetState();
            GetGrd();
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }

    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin__LLocation(txtSearch.Text.Trim());
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();            
        }
        catch (Exception ex)
        {
        }

    }
    private void GetState()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = BusinessServices.BindState();
            if (dt.Rows.Count > 0)
            {
                ddlState.Items.Clear();
                ddlState.DataSource = dt;
                ddlState.DataTextField = "State_Name";
                ddlState.DataValueField = "State_ID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("-- Select State --", "0"));
            }

        }
        catch (Exception ex)
        {
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txt_Name.Text != string.Empty && txtClient.Text != string.Empty && txtShort.Text != string.Empty && ddlType.SelectedValue != "0" && ddlState.SelectedIndex != 0 && ddlStatus.SelectedValue != "-1" && txtBillingAddr.Text != string.Empty && txtShipping.Text != string.Empty)
        //{
        DataTable DtDup = BusinessServices.Imaging_CheckDuplicateLocClient(txt_Name.Text.Trim(), int.Parse(ddlState.SelectedValue), txtClient.Text.Trim(), ddlType.SelectedValue);
        if(DtDup.Rows.Count >0)
        {
            lbl_msg.Text = "Location and Client already exists";
            return;
        }
            bool result = BusinessServices.Imaging_Admin_Location_Insert(txt_Name.Text.Trim(), txtShort.Text.Trim(), txtClient.Text.Trim(), int.Parse(ddlState.SelectedValue), ddlType.SelectedValue, int.Parse(ddlStatus.SelectedValue), txtBillingAddr.Text.Trim(), txtShipping.Text.Trim());
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                txt_Name.Text = "";
                lbl_msg.Text = "";
                txtClient.Text = "";
                txtShort.Text = "";
                GetState();
                ddlType.SelectedValue = "0";
                ddlStatus.SelectedValue = "-1";
                txtBillingAddr.Text = "";
                txtShipping.Text = "";
                GetGrd();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);
            }

        //}

        //else
        //{
        //    AlertPageHelper.ShowAlert(this.Page, "Please Fill the Required Fields");
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txt_Name.Text = ""; txtClient.Text = ""; txtShort.Text = "";
        GetState();
        ddlType.SelectedValue = "0";
        ddlStatus.SelectedValue = "-1";


    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        // lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[8].Visible = false;
    }
    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Contaclbl_Nametid")).Text;
        string Name = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_lbl_Name")).Text;
        string ContactName = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_ContactName")).Text;
        string ContactPhoneNO = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtContactPhoneNO")).Text;
        string BillingAddress = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtBillingAdrress")).Text;
        string ShippingAddress = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtShippingAddress")).Text;
        int stateId = int.Parse(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditState")).SelectedValue);
        int Status = int.Parse(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlLocationActive")).SelectedValue);
        string Type = ((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlType")).SelectedValue;


        DataTable DtDup = BusinessServices.Imaging_CheckDuplicateLocClientUpdate(Convert.ToInt32(ID),Name, stateId, ContactPhoneNO, Type);
        if (DtDup.Rows.Count > 0)
        {
            //lbl_msg.Text = "Location and Client already exists";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Location and Client already exists..');</script>", false);
            return;
        }

        bool result = false;
        if (Name != string.Empty && ContactName != string.Empty && ContactPhoneNO != string.Empty && Type != "0" && BillingAddress != string.Empty && ShippingAddress != string.Empty && stateId != 0 && Status != -1)
        {
            result = BusinessServices.Imaging_Admin_Location_update(Convert.ToInt32(ID), Name, ContactName, ContactPhoneNO, stateId, BillingAddress, ShippingAddress, Status, Type);
            lbl_msg.Text = result ? "Updated successful" : "Updation failed";
            GvwCustomer.EditIndex = -1;
            // Display status message

            // Reload the grid
            GetGrd(); GvwCustomer.Columns[8].Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill All Fields..');</script>", false);
        }

    }
    protected void GvwCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwCustomer.PageIndex = e.NewPageIndex;
        GetGrd();
    }
    protected void GvwCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        // Cancel edit mode
        GvwCustomer.EditIndex = -1;
        // Set status message
        // lbl_msg.Text = "Editing canceled";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[8].Visible = true;
    }
    protected void GvwCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        btnContinue.Visible = true;
        btnDisContinue.Visible = true;
        string str = "Do you want to delete?";
        string script = "<script type='text/javascript' language='javascript'>";
        script += "if (confirm('" + str.ToString() + "')) {document.getElementById('" + btnContinue.ClientID + "').click(); }else{ document.getElementById('" + btnDisContinue.ClientID + "').click();  };"; script += "</script>";
        if (script != "<script type='text/javascript' language='javascript'></script>")
            if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                Page.RegisterStartupScript("clientScript2", script);


        // Get the ID of the record to be deleted
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Supplier_Id1")).Text;
        Session["ID"] = ID;


    }
    protected void GvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GvwCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlEditState = (DropDownList)e.Row.FindControl("ddlEditState");
                DropDownList ddlLocationActive = (DropDownList)e.Row.FindControl("ddlLocationActive");
                DropDownList ddlType = (DropDownList)e.Row.FindControl("ddlType");
                DataTable dt = new DataTable();
                dt = BusinessServices.BindState();
                if (dt.Rows.Count > 0)
                {
                    ddlEditState.Items.Clear();
                    ddlEditState.DataSource = dt;
                    ddlEditState.DataTextField = "State_Name";
                    ddlEditState.DataValueField = "State_ID";
                    ddlEditState.DataBind();
                    ddlEditState.Items.Insert(0, new ListItem("Select", "0"));
                }
                DataRowView dr = e.Row.DataItem as DataRowView;
                ddlEditState.Items.FindByText(dr["State_Name"].ToString()).Selected = true;
                //ddlLocationActive.Items.FindByText(dr["Location_Active"].ToString()).Selected = true;
                if (dr["Location_Active"].ToString() == "True")
                {
                    ddlLocationActive.SelectedValue = "1";
                }
                else if (dr["Location_Active"].ToString() == "False")
                {
                    ddlLocationActive.SelectedValue = "0";
                }
                else
                {
                    ddlLocationActive.SelectedValue = "-1";
                }
                // ddlType.Items.FindByText(dr["type"].ToString()).Selected = true;
                if (dr["type"].ToString() == "P")
                {
                    ddlType.SelectedValue = "P";
                }
                else if (dr["type"].ToString() == "S")
                {
                    ddlType.SelectedValue = "S";
                }
                //else
                //{
                //    ddlType.SelectedValue = "0";
                //}
            }
            else
            {
                Label lblLocationActive = (Label)e.Row.FindControl("LocationActive");
                Label lblType = (Label)e.Row.FindControl("lblType");
                if (lblLocationActive.Text.Trim() == "True")
                {
                    lblLocationActive.Visible = true;
                    lblLocationActive.Text = "Active";
                }
                else
                {
                    lblLocationActive.Visible = true;
                    lblLocationActive.Text = "Deactive";
                }
                if (lblType.Text.Trim() == "P")
                {
                    lblType.Visible = true;
                    lblType.Text = "Purchage";
                }
                else
                {
                    lblType.Visible = true;
                    lblType.Text = "Sales";
                }
            }
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = BusinessServices.Imaging_Admin_Location_delete(Convert.ToInt32(Session["ID"].ToString()));

            string msg = "The Address Details is deleted.";
            string script = "<script type='text/javascript' language='javascript'>";
            script += "alert('" + msg.ToString() + "' );"; script += "</script>";
            if (script != "<script type='text/javascript' language='javascript'></script>")
                if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                    Page.RegisterStartupScript("clientScript2", script);

            // Cancel edit mode
            GvwCustomer.EditIndex = -1;
            // Display status message
            lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
            // Reload the grid
            GetGrd(); GvwCustomer.Columns[8].Visible = true;
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnDisContinue_Click(object sender, EventArgs e)
    {
        try
        {
            GvwCustomer.EditIndex = -1;
            GetGrd(); GvwCustomer.Columns[8].Visible = true;
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {
           
        }
    }

    protected void btnsearch_click(object sender, EventArgs e)
    {
        try
        {
            GetGrd();
        }
        catch (Exception ex)
        {
        }
    }
}