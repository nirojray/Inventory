using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
public partial class Admin_Customer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindtype(); GetGrd();
            GetState(); LoadCreditPeriod(); GetMasterList("VE", ddlVertical); bindRepresentativeOnLoc();
             GetReverseCharge();
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
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
                ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            }

        }
        catch (Exception ex)
        {
        }

    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            string Cust = txtSearch.Text;
            ds = BusinessServices.Imaging_Admin_CusSupTran(txtSearch.Text.Trim());
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();



        }
        catch (Exception ex)
        {
        }

    }
    public void bindtype()
    {
        DataTable dt = BusinessServices.Imaging_Admin_Type();
        ddl_Type.DataSource = dt;
        ddl_Type.DataTextField = "Supplier_Type_Desc";
        ddl_Type.DataValueField = "SupplierType_ID";
        ddl_Type.DataBind();

        ddl_Type.Items.Insert(0, new ListItem("--Select Type--", "-1"));
        ddl_Type.SelectedIndex = 0;
    }
    private void Clear()
    {
        txt_Name.Text = "";
        lbl_msg.Text = "";
        txtContactName.Text = "";
        txtContactPhoneNo.Text = "";
        txtEmail.Text = "";
        txtBillingAddr.Text = "";
        txtShipping.Text = "";
        txtPAN.Text = "";
        txtVATCST.Text = "";
        txtServiceTaxNumber.Text = "";
        ddlState.SelectedIndex = 0;
        ddl_Type.SelectedValue = "-1";
        ddlPaymentTerms.SelectedIndex = 0;
        ddlVertical.SelectedIndex = 0;
        Drreversecharge.SelectedIndex = 0;
        TrBilling.Visible = false;
        TrShipping.Visible = false;
        TrState.Visible = false;
        TrVATCST.Visible = false;
        TrPAN.Visible = false;
        TrServiceTaxNumber.Visible = false;
        TrPaymentterms.Visible = false;
        TrReverscharge.Visible = false;
        TrVertical.Visible = false;
        TrReprsnt.Visible = false;
        ddlReprsnt.SelectedIndex = 0;
    }

    // Binding Representative Dropdown
    public void bindRepresentativeOnLoc()
    {
        try
        {
            DataTable dt = BusinessServices.GetRepresentativeonLoc();
            ddlReprsnt.Items.Clear();
            ddlReprsnt.DataSource = dt;
            ddlReprsnt.DataTextField = "Name";
            ddlReprsnt.DataValueField = "Id";
            ddlReprsnt.DataBind();
            ddlReprsnt.Items.Insert(0, new ListItem("--Select Representative--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void LoadCreditPeriod()
    {
        DataTable DTCreditPeriod = BusinessServices.Imaging_GetCreditperiod();
        ddlPaymentTerms.DataSource = DTCreditPeriod;
        ddlPaymentTerms.DataValueField = "Id";
        ddlPaymentTerms.DataTextField = "CreditPeriod";
        ddlPaymentTerms.DataBind();
        ddlPaymentTerms.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txt_Name.Text != string.Empty && txtContactName.Text != string.Empty && ddl_Type.SelectedValue != "-1" && txtContactPhoneNo.Text!=string.Empty && txtEmail.Text!=string.Empty && txtBillingAddr.Text != string.Empty && txtShipping.Text != string.Empty)
        //{

        if (txtContactPhoneNo.Text.Length < 10)
        {
            lbl_msg.Text = "Please enter 10 digit contact number";
            return;
        }


        DataTable DTCustomer = BusinessServices.Imaging_Customer_Exists(txt_Name.Text.Trim(), Convert.ToInt32(ddl_Type.SelectedValue),Convert.ToInt32(ddlVertical.SelectedValue),Convert.ToInt32(ddlState.SelectedValue));
        //,Convert.ToInt32(ddlState.SelectedValue)
        if (DTCustomer.Rows.Count > 0)
        {
            lbl_msg.Text = ddl_Type.SelectedItem.ToString() + " Already Exists";
            return;
        }
        //else
        //{
        //    if (ddl_Type.SelectedValue == "2")
        //    {
        //        DataTable DTVATCST = BusinessServices.Imaging_VATCST_Exists(txtVATCST.Text.Trim(), Convert.ToInt32(ddl_Type.SelectedValue), txt_Name.Text.Trim());
        //        if (DTVATCST.Rows.Count > 0)

        //        {
        //            //MODIFIED BY KUSHAL PATIL
        //            lbl_msg.Text = txtVATCST.Text + "  GSTTIN NUMBER Already Exists";
        //            return;

        //        }
        //    }
        //    if (ddl_Type.SelectedValue == "1")
        //    {
        //        DataTable DTVATCST = BusinessServices.Imaging_VATCST_Exists(txtVATCST.Text.Trim(), Convert.ToInt32(ddl_Type.SelectedValue), txt_Name.Text.Trim());
        //        if (DTVATCST.Rows.Count > 0)

        //        {
        //            //MODIFIED BY KUSHAL PATIL
        //            lbl_msg.Text = txtVATCST.Text + "  GSTTIN NUMBER Already Exists";
        //            return;

        //        }
        //    }

            lbl_msg.Text = "";
            int ReverseCharge = 1;
            if(txtVATCST.Text!="")
            {
                ReverseCharge = 2;
            }
            else
            {
                ReverseCharge = 1;
            }
           
            bool result = BusinessServices.Imaging_Admin_CusSupTrans_Insert(txt_Name.Text.Trim(), Convert.ToInt32(ddl_Type.SelectedItem.Value.ToString()), txtContactName.Text.Trim(), txtContactPhoneNo.Text.Trim(), txtEmail.Text.Trim(), txtBillingAddr.Text.Trim(), txtShipping.Text.Trim(), txtVATCST.Text.Trim(), txtPAN.Text.Trim(), txtServiceTaxNumber.Text.Trim(), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(Session["Id"]), Convert.ToInt32(ddlPaymentTerms.SelectedValue), ReverseCharge, Convert.ToInt32(ddlVertical.SelectedValue), Convert.ToInt32(ddlReprsnt.SelectedValue));
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
        //}

        //}

        //else
        //{
        //    AlertPageHelper.ShowAlert(this.Page, "Please Fill the Required Fields");
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();

    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[15].Visible = false;

    }
    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Contaclbl_Nametid")).Text;
        string Name = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_lbl_Name")).Text;
        string Type = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("Type")).Text;
        DropDownList ddlEditState = (DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditState");
        int VerticalId = 0;int StateCId = 0; int RepresentativeId = 0;
        if (Type == "Customer")
        {
            DropDownList ddlEditddlVertical = (DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditddlVertical");
            DropDownList ddlEditddlRepresentative = (DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditddlRepresentative");
            VerticalId =Convert.ToInt32(ddlEditddlVertical.SelectedValue);
            StateCId= Convert.ToInt32(ddlEditState.SelectedValue);
            RepresentativeId = Convert.ToInt32(ddlEditddlRepresentative.SelectedValue);
        }
        if (Type == "Supplier")
        {
            StateCId = Convert.ToInt32(ddlEditState.SelectedValue);
        }

            DataTable DTCust = BusinessServices.Imaging_Customer_ExistsforUpdate(Convert.ToInt32(ID), Name, Type, VerticalId, StateCId, RepresentativeId);
        if (DTCust.Rows.Count > 0)
        {

            lbl_msg.Text = Type + " Already Exist";
            return;
        }
        else
        {

            string ContactName = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_ContactName")).Text;
            string ContactPhoneNO = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtContactPhoneNO")).Text;
            string ContactEmail = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtContactEmail")).Text;
            string BillingAdrress = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtBillingAdrress")).Text;
            string ShippingAddress = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtShippingAddress")).Text;

            string VATCST = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtVATCST")).Text;
            string PAN = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtPAN")).Text;
            //if(PAN=="")
            //{
            //    PAN = "N/A";
            //}
            string ServiceTaxNumber = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtServiceTaxNumber")).Text;
            DropDownList ddlEditddlVertical = (DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditddlVertical");
            DropDownList ddlEditddlRepresentative = (DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditddlRepresentative");
            int StateID = 0;int Vertical = 0; int PaymentTerms = 0; int ReverseCharge = 2; int Representative = 0;
            if (Type == "Customer")
            {
                Vertical = Convert.ToInt32(ddlEditddlVertical.SelectedValue);
                Representative = Convert.ToInt32(ddlEditddlRepresentative.SelectedValue);
                StateID = int.Parse(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditState")).SelectedValue);
                PaymentTerms = Convert.ToInt32(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditPaymentterms")).SelectedValue);
                if(VATCST!="")
                {
                    ReverseCharge = 2;
                }
                else
                {
                    ReverseCharge = 1;
                }
               // ReverseCharge = Convert.ToInt32(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("dr_Reverse_charge")).SelectedValue);
            }
           
            if (Type == "Supplier")
            {
                PaymentTerms = Convert.ToInt32(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditPaymentterms")).SelectedValue);
                StateID = int.Parse(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("ddlEditState")).SelectedValue);
                if (VATCST != "")
                {
                    ReverseCharge = 2;
                }
                else
                {
                    ReverseCharge = 1;
                }
                // ReverseCharge = Convert.ToInt32(((DropDownList)GvwCustomer.Rows[e.RowIndex].FindControl("dr_Reverse_charge")).SelectedValue);
            }

            //ADDED BY KUSHAL PATIL
            //dr_Reverse_charge            

            bool result = BusinessServices.Imaging_Admin_CusSupTrans_update(Convert.ToInt32(ID), Name, ContactName, ContactPhoneNO, ContactEmail, BillingAdrress, ShippingAddress, VATCST, PAN, ServiceTaxNumber, StateID, Convert.ToInt32(Session["Id"]), PaymentTerms, ReverseCharge, Vertical, Representative);

            Clear();
            GvwCustomer.EditIndex = -1;
            // Display status message
            lbl_msg.Text = result ? "Updated successful" : "Updation failed";
            // Reload the grid
            GetGrd(); GvwCustomer.Columns[14].Visible = true;
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
        lbl_msg.Text = "Editing canceled";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[14].Visible = false; GvwCustomer.Columns[15].Visible = true;
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

        string Type = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("type")).Text;
        Session["ID"] = ID;

        Session["Type"] = Type;



    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {


            bool result = BusinessServices.Imaging_Admin_CusSupTrans_delete(Convert.ToInt32(Session["ID"]));
            string msg = Session["Type"].ToString() + " is deleted.";
            string script = "<script type='text/javascript' language='javascript'>";
            script += "alert('" + msg.ToString() + "' );"; script += "</script>";
            if (script != "<script type='text/javascript' language='javascript'></script>")
                if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                    Page.RegisterStartupScript("clientScript2", script);

            // Cancel edit mode
            GvwCustomer.EditIndex = -1;
            // Display status message
            //   lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
            // Reload the grid
            GetGrd(); GvwCustomer.Columns[14].Visible = false;
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
            GetGrd(); GvwCustomer.Columns[14].Visible = false;
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void GvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            txtSearch.Text = "";
            GetGrd();
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Type.SelectedValue == "2")
        {
            Clear1();
            TrBilling.Visible = true;
            TrShipping.Visible = true;
            TrState.Visible = true;
            TrVATCST.Visible = true;
            TrPAN.Visible = true;
            TrServiceTaxNumber.Visible = false;
            //added by kushal
            // TrReverscharge.Visible = true;
            TrReverscharge.Visible = false;
            TrVertical.Visible = true;
            TrPaymentterms.Visible = true;
            TrReprsnt.Visible = true;

        }
        else if (ddl_Type.SelectedValue == "1")
        {
            Clear1();
            TrState.Visible = true;
            TrVATCST.Visible = true;
            TrPaymentterms.Visible = true;
            //added by kushal
            //TrReverscharge.Visible = true;
            TrReverscharge.Visible = false;
            TrPAN.Visible = true;
            TrVertical.Visible = false;
            TrReprsnt.Visible = false;
        }
        else
        {
            Clear1();
            TrBilling.Visible = false;
            TrShipping.Visible = false;
            TrState.Visible = false;
            ddlState.SelectedIndex = 0;
            txtBillingAddr.Text = "";
            txtShipping.Text = "";
            TrVATCST.Visible = false;
            TrPAN.Visible = false;
            TrServiceTaxNumber.Visible = false;
            TrPaymentterms.Visible = false;
            ddlPaymentTerms.SelectedIndex = 0;
            //added by kushal
            TrReverscharge.Visible = false;
            TrVertical.Visible = false;
            TrReprsnt.Visible = false;
        }
    }
    private void Clear1()
    {
        txt_Name.Text = "";
        lbl_msg.Text = "";
        txtContactName.Text = "";
        txtContactPhoneNo.Text = "";
        txtEmail.Text = "";
        txtBillingAddr.Text = "";
        txtShipping.Text = "";
        txtPAN.Text = "";
        txtVATCST.Text = "";
        txtServiceTaxNumber.Text = "";
        ddlState.SelectedIndex = 0;
        // ddl_Type.SelectedValue = "-1";
        ddlVertical.SelectedIndex = 0;
        Drreversecharge.SelectedIndex = 0;
        TrBilling.Visible = false;
        TrShipping.Visible = false;
        TrState.Visible = false;
        TrVATCST.Visible = false;
        TrPAN.Visible = false;
        TrServiceTaxNumber.Visible = false;
        TrReverscharge.Visible = false;
        TrVertical.Visible = false;
        TrReprsnt.Visible = false;
        ddlReprsnt.SelectedIndex = 0;
    }
    protected void GvwCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                Label Type = (Label)e.Row.FindControl("Type");
                Label lblEdit_Paymentterms = (Label)e.Row.FindControl("lblEdit_Paymentterms");
                TextBox txtBillingAdrress = (TextBox)e.Row.FindControl("txtBillingAdrress");
                TextBox txtShippingAddress = (TextBox)e.Row.FindControl("txtShippingAddress");
                DropDownList ddlEditState = (DropDownList)e.Row.FindControl("ddlEditState");
                TextBox txtPAN = (TextBox)e.Row.FindControl("txtPAN");
                TextBox txtVATCST = (TextBox)e.Row.FindControl("txtVATCST");
                TextBox txtServiceTaxNumber = (TextBox)e.Row.FindControl("txtServiceTaxNumber");
                DropDownList ddlEditPaymentterms = (DropDownList)e.Row.FindControl("ddlEditPaymentterms");

                //ADDED BY KUSHAL PATIL
                Label LblEdit_Reverserecharge = (Label)e.Row.FindControl("LblEdit_Reverserecharge");
                DropDownList dr_Reverse_charge = (DropDownList)e.Row.FindControl("dr_Reverse_charge");

                DropDownList ddlEditddlVertical = (DropDownList)e.Row.FindControl("ddlEditddlVertical");
                DropDownList ddlEditddlRepresentative = (DropDownList)e.Row.FindControl("ddlEditddlRepresentative");
                if (Type.Text == "Customer")
                {
                    txtBillingAdrress.Enabled = true;
                    txtShippingAddress.Enabled = true;
                    txtPAN.Enabled = true;
                    txtServiceTaxNumber.Enabled = true;
                    ddlEditState.Enabled = true;
                    ddlEditPaymentterms.Enabled = true;

                    //ADDED BY KUSHAL PATIL
                    dr_Reverse_charge.Visible = false;
                    dr_Reverse_charge.Enabled = true;
                    ddlEditddlVertical.Enabled = true;
                    ddlEditddlRepresentative.Enabled = true;


                    txtVATCST.Enabled = true;
                    Label lbl_StateID = (Label)e.Row.FindControl("lbl_StateID");
                    DataTable dt = new DataTable();
                    dt = BusinessServices.BindState();
                    if (dt.Rows.Count > 0)
                    {
                        ddlEditState.Items.Clear();
                        ddlEditState.DataSource = dt;
                        ddlEditState.DataTextField = "State_Name";
                        ddlEditState.DataValueField = "State_ID";
                        ddlEditState.DataBind();
                        ddlEditState.Items.Insert(0, new ListItem("--Select State--", "0"));
                    }
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddlEditState.SelectedValue = lbl_StateID.Text;


                    DataTable dtPaymentterms = new DataTable();
                    // dtPaymentterms = BusinessServices.BindPaymentTerms();
                    dtPaymentterms = BusinessServices.Imaging_GetCreditperiod();
                    if (dtPaymentterms.Rows.Count > 0)
                    {
                        ddlEditPaymentterms.Items.Clear();
                        ddlEditPaymentterms.DataSource = dtPaymentterms;
                        ddlEditPaymentterms.DataTextField = "CreditPeriod";
                        ddlEditPaymentterms.DataValueField = "Id";
                        ddlEditPaymentterms.DataBind();
                        ddlEditPaymentterms.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    ddlEditPaymentterms.SelectedValue = lblEdit_Paymentterms.Text;


                    DataTable dtre = BusinessServices.selecting_reversecharge();

                    if (dtre.Rows.Count > 0)
                    {
                        //dr_Reverse_charge
                        dr_Reverse_charge.Items.Clear();
                        dr_Reverse_charge.DataSource = dtre;
                        dr_Reverse_charge.DataTextField = "Reverse_Charge";
                        dr_Reverse_charge.DataValueField = "Id";
                        dr_Reverse_charge.DataBind();
                        dr_Reverse_charge.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    dr_Reverse_charge.SelectedValue = LblEdit_Reverserecharge.Text;

                    GetMasterList("VE", ddlEditddlVertical);
                    Label lbl_VerticalID = (Label)e.Row.FindControl("lbl_VerticalID");
                    ddlEditddlVertical.SelectedValue = lbl_VerticalID.Text;
                    // bindRepresentativeOnLoc();
                    DataTable dtRepresentative = BusinessServices.GetRepresentativeonLoc();
                    if (dtre.Rows.Count > 0)
                    {
                        ddlEditddlRepresentative.Items.Clear();
                        ddlEditddlRepresentative.DataSource = dtRepresentative;
                        ddlEditddlRepresentative.DataTextField = "Name";
                        ddlEditddlRepresentative.DataValueField = "Id";
                        ddlEditddlRepresentative.DataBind();
                        ddlEditddlRepresentative.Items.Insert(0, new ListItem("--Select Representative--", "0"));
                    }
                    Label lbl_RepresentativeID = (Label)e.Row.FindControl("lbl_RepresentativeID");
                    ddlEditddlRepresentative.SelectedValue = lbl_RepresentativeID.Text;
                }
                else if (Type.Text == "Supplier")
                {
                    ddlEditState.Enabled = true;
                    txtBillingAdrress.Enabled = false;
                    txtShippingAddress.Enabled = false;
                    txtPAN.Enabled = true;
                    txtServiceTaxNumber.Enabled = false;
                    ddlEditPaymentterms.Enabled = true;
                    //ADDED BY KUSHAL PATIL
                    dr_Reverse_charge.Visible = false;
                    dr_Reverse_charge.Enabled = true;
                    ddlEditddlVertical.Enabled = false;
                    ddlEditddlRepresentative.Enabled = false;
                    txtVATCST.Enabled = true;
                    Label lbl_StateID = (Label)e.Row.FindControl("lbl_StateID");
                    DataTable dt = new DataTable();
                    dt = BusinessServices.BindState();
                    if (dt.Rows.Count > 0)
                    {
                        ddlEditState.Items.Clear();
                        ddlEditState.DataSource = dt;
                        ddlEditState.DataTextField = "State_Name";
                        ddlEditState.DataValueField = "State_ID";
                        ddlEditState.DataBind();
                        ddlEditState.Items.Insert(0, new ListItem("--Select State--", "0"));
                    }
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddlEditState.SelectedValue = lbl_StateID.Text;
                    DataTable dtPaymentterms = new DataTable();
                    // dtPaymentterms = BusinessServices.BindPaymentTerms();
                    dtPaymentterms = BusinessServices.Imaging_GetCreditperiod();
                    if (dtPaymentterms.Rows.Count > 0)
                    {
                        ddlEditPaymentterms.Items.Clear();
                        ddlEditPaymentterms.DataSource = dtPaymentterms;
                        ddlEditPaymentterms.DataTextField = "CreditPeriod";
                        ddlEditPaymentterms.DataValueField = "Id";
                        ddlEditPaymentterms.DataBind();
                        ddlEditPaymentterms.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    ddlEditPaymentterms.SelectedValue = lblEdit_Paymentterms.Text;

                    //Added by kushal patil
                    DataTable dtre = BusinessServices.selecting_reversecharge();

                    if (dtre.Rows.Count > 0)
                    {
                        //dr_Reverse_charge
                        dr_Reverse_charge.Items.Clear();
                        dr_Reverse_charge.DataSource = dtre;
                        dr_Reverse_charge.DataTextField = "Reverse_Charge";
                        dr_Reverse_charge.DataValueField = "Id";
                        dr_Reverse_charge.DataBind();
                        dr_Reverse_charge.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    dr_Reverse_charge.SelectedValue = LblEdit_Reverserecharge.Text;
                }
                else
                {
                    txtBillingAdrress.Enabled = false;
                    txtShippingAddress.Enabled = false;
                    ddlEditState.Enabled = false;
                    txtPAN.Enabled = false;
                    txtServiceTaxNumber.Enabled = false;
                    ddlEditPaymentterms.Enabled = false;
                    ddlEditddlVertical.Enabled = false;
                    ddlEditddlRepresentative.Enabled = false;
                    //ADDED KUSHAL PATIL
                    //dr_Reverse_charge.Enabled = false;

                    txtVATCST.Enabled = false;
                }


            }

        }
    }

    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            DrpList.Items.Clear();
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        catch (Exception Ex)
        {

        }
    }

    public void GetReverseCharge()
    {
        try
        {            
            DataTable dtre = BusinessServices.selecting_reversecharge();
            if (dtre.Rows.Count > 0)
            {
                //dr_Reverse_charge
                Drreversecharge.Items.Clear();
                Drreversecharge.DataSource = dtre;
                Drreversecharge.DataTextField = "Reverse_Charge";
                Drreversecharge.DataValueField = "Id";
                Drreversecharge.DataBind();
                Drreversecharge.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void ddlState_SelectedIndexChanged(object sender,EventArgs e)
    {
        try
        {
            //DataTable dtGSTNum = BusinessServices.GetGSTNumBasedOnState(Convert.ToInt32(ddlState.SelectedValue));
            //if (dtGSTNum.Rows.Count > 0)
            //{
            //    txtVATCST.Text = dtGSTNum.Rows[0]["GSTNum"].ToString();
            //}
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void ddlEditState_SelectedIndexChanged(object sender,EventArgs e)
    {
        try
        {
            //DropDownList ddlEditStateDropDownList = (DropDownList)sender;
            //GridViewRow grdrDropDownRow = ((GridViewRow)ddlEditStateDropDownList.Parent.Parent);
            //TextBox txtEditVATCST = (TextBox)grdrDropDownRow.FindControl("txtVATCST");
            //DataTable dtGSTNum = BusinessServices.GetGSTNumBasedOnState(Convert.ToInt32(ddlEditStateDropDownList.SelectedValue));
            //if (dtGSTNum.Rows.Count > 0)
            //{
            //    txtEditVATCST.Text = dtGSTNum.Rows[0]["GSTNum"].ToString();
            //}           

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}