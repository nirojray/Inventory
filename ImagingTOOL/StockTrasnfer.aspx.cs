using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class StockTrasnfer : System.Web.UI.Page
{
    ClsStockTransfer objST = new ClsStockTransfer();
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                try
                {
                    bindFromToLoc();
                    LoadMainCategory();

                }
                catch (Exception ex)
                {

                }
            }
        }

    }
    //Binding all locations into from and to location dropdowns
    public void bindFromToLoc()
    {
        try
        {
            DataTable dt = objST.Get_AllLocationsforST();
            //Bidnging From Location
            ddlFromLoc.Items.Clear();
            ddlFromLoc.DataSource = dt;
            ddlFromLoc.DataTextField = "Location_Name";
            ddlFromLoc.DataValueField = "Location_ID";
            ddlFromLoc.DataBind();
            ddlFromLoc.Items.Insert(0, new ListItem("--Select From Location--", "0"));
            //Binding To Location
            ddlToLoc.Items.Clear();
            ddlToLoc.DataSource = dt;
            ddlToLoc.DataTextField = "Location_Name";
            ddlToLoc.DataValueField = "Location_ID";
            ddlToLoc.DataBind();
            ddlToLoc.Items.Insert(0, new ListItem("--Select To Location--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Binding main category dropdown
    private void LoadMainCategory()
    {
        DataTable DTMainCategory = objST.Get_MainCategoryforSt();
        ddlMainCategory.Items.Clear();
        ddlMainCategory.DataSource = DTMainCategory;
        ddlMainCategory.DataValueField = "M_categoryid";
        ddlMainCategory.DataTextField = "M_CategoryName";
        ddlMainCategory.DataBind();
        ddlMainCategory.Items.Insert(0, new ListItem("--Select Main Category--", "0"));
    }
    //Adding first row into grid
    private void AddFirstRow()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sno");
            dt.Columns.Add("CatagoryID");
            dt.Columns.Add("Catagory");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Product");
            dt.Columns.Add("FCurentStock");
            dt.Columns.Add("TCurentStock");
            dt.Columns.Add("Quantity");

            DataRow dr1 = dt.NewRow();
            dr1["sno"] = "";
            dr1["CatagoryID"] = "";
            dr1["Catagory"] = "";
            dr1["ProductID"] = "";
            dr1["FCurentStock"] = "";
            dr1["TCurentStock"] = "";
            dr1["Product"] = "";

            dt.Rows.Add(dr1);
            GvStockTransfer.DataSource = dt;
            GvStockTransfer.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    //Clearing Grid
    private void GridDDlClear()
    {
        AddFirstRow();
        BindSubCategory();

    }
    //Binding sub category on main category
    public void BindSubCategory()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DropDownList DdlCatagory = (DropDownList)GvStockTransfer.FooterRow.FindControl("DdlCatagory");

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddlMainCategory.SelectedValue));
            if (DT.Rows.Count > 0)
            {
                DdlCatagory.Items.Clear();
                DdlCatagory.DataSource = DT;
                DdlCatagory.DataValueField = "ID";
                DdlCatagory.DataTextField = "NAME";
                DdlCatagory.DataBind();
                DdlCatagory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
            else
            {
                DdlCatagory.Items.Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridDDlClear();
    }

    protected void GvStockTransfer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sno");
            dt.Columns.Add("CatagoryID");
            dt.Columns.Add("Catagory");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Product");
            dt.Columns.Add("FCurentStock");
            dt.Columns.Add("TCurentStock");
            dt.Columns.Add("Quantity");
            foreach (GridViewRow gvRow in GvStockTransfer.Rows)
            {

                DataRow dr = dt.NewRow();
                dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                dr["FCurentStock"] = ((Label)gvRow.FindControl("lblFCurntStock")).Text;
                dr["TCurentStock"] = ((Label)gvRow.FindControl("lblTCurntStock")).Text;
                dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                dt.Rows.Add(dr);

            }
            dt.Rows[e.RowIndex].Delete();
            GvStockTransfer.DataSource = dt;
            GvStockTransfer.DataBind();
            BindSubCategory();
            ((DropDownList)GvStockTransfer.FooterRow.FindControl("DdlCatagory")).Focus();
            int i = GvStockTransfer.Rows.Count;
            if (i == 0)
            {
                AddFirstRow();
                BindSubCategory();

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void GvStockTransfer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GvStockTransfer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblCatagory = (Label)e.Row.FindControl("lblCatagory");
                Label LblProduct = (Label)e.Row.FindControl("LblProduct");
                Label LblQuantity = (Label)e.Row.FindControl("LblQuantity");
                Label lblFCurntStock = (Label)e.Row.FindControl("lblFCurntStock");
                Label lblTCurntStock = (Label)e.Row.FindControl("lblTCurntStock");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkLink");
                if (lblCatagory.Text != "" && LblProduct.Text != "" && lblFCurntStock.Text != "" && lblTCurntStock.Text != "" && LblQuantity.Text != "")
                {
                    if (GvStockTransfer.Rows.Count >= 0)
                    {
                        lnkDelete.Visible = true;
                    }
                    else
                    {
                        lnkDelete.Visible = false;
                    }
                }
                else
                {
                    lnkDelete.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
        }

    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
           
            Button BtnAdd = (Button)sender;
            // Get the GridViewRow 
            GridViewRow row = (GridViewRow)BtnAdd.Parent.Parent;

            DropDownList DdlCatagory = (DropDownList)row.FindControl("DdlCatagory");
            DropDownList DdlProduct = (DropDownList)row.FindControl("DdlProduct");
            Label lblFCurntStock = (Label)row.FindControl("lblFFtCurntStock");
            Label lblTCurntStock = (Label)row.FindControl("lblTFtCurntStock");
            TextBox TxtQuantity = (TextBox)row.FindControl("TxtQuantity");
            //if (DdlCatagory.SelectedIndex ==0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please select category...');</script>", false);
            //    return;
            //}
            //else if (DdlProduct.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please select Product...');</script>", false);
            //    return;
            //}
            if (lblFCurntStock.Text == "" || lblTCurntStock.Text == "" || TxtQuantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
                return;
            }
            else
                if (Convert.ToInt32(TxtQuantity.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('0 qty can not be be transferred...');</script>", false);
                return;
            }
            else
                if (Convert.ToInt32(lblFCurntStock.Text) < Convert.ToInt32(TxtQuantity.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Transfer qty cant be greater than from location available stock...');</script>", false);
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("sno");
            dt.Columns.Add("CatagoryID");
            dt.Columns.Add("Catagory");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Product");
            dt.Columns.Add("FCurentStock");
            dt.Columns.Add("TCurentStock");
            dt.Columns.Add("Quantity");
            string Product = DdlProduct.SelectedItem.ToString();
            foreach (GridViewRow gvRow in GvStockTransfer.Rows)
            {

                if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                {
                    // && ((Label)gvRow.FindControl("lblCatagoryID")).Text == DdlCatagory.SelectedValue.ToString()
                    if (((Label)gvRow.FindControl("LblProductID")).Text == DdlProduct.SelectedValue.ToString())
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('You cant select same product twice...');</script>", false);

                        return;
                    }
                    DataRow dr = dt.NewRow();
                    dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                    dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                    dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                    dr["FCurentStock"] = ((Label)gvRow.FindControl("lblFCurntStock")).Text;
                    dr["TCurentStock"] = ((Label)gvRow.FindControl("lblTCurntStock")).Text;
                    dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                    dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                    dt.Rows.Add(dr);

                }
            }


            DataRow dr1 = dt.NewRow();
            dr1["CatagoryID"] = ((DropDownList)GvStockTransfer.FooterRow.FindControl("DdlCatagory")).SelectedValue.ToString();
            dr1["Catagory"] = ((DropDownList)GvStockTransfer.FooterRow.FindControl("DdlCatagory")).SelectedItem.Text;
            dr1["ProductID"] = ((DropDownList)GvStockTransfer.FooterRow.FindControl("DdlProduct")).SelectedValue.ToString();
            dr1["FCurentStock"] = ((Label)GvStockTransfer.FooterRow.FindControl("lblFFtCurntStock")).Text;
            dr1["TCurentStock"] = ((Label)GvStockTransfer.FooterRow.FindControl("lblTFtCurntStock")).Text;
            dr1["Product"] = ((DropDownList)GvStockTransfer.FooterRow.FindControl("DdlProduct")).SelectedItem.Text;
            dr1["Quantity"] = ((TextBox)GvStockTransfer.FooterRow.FindControl("TxtQuantity")).Text;

            dt.Rows.Add(dr1);
            GvStockTransfer.DataSource = dt;
            GvStockTransfer.DataBind();
            BindSubCategory();
            ViewState["dtcount"] = dt;
        }
        catch (Exception ex)
        {

        }

    }

    protected void DdlCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCategory.Parent.Parent;

            TextBox TxtQuantity = (TextBox)row.FindControl("TxtQuantity");
            DropDownList ddlProduct = (DropDownList)row.FindControl("DdlProduct");
            Label lblFCurntStock = (Label)row.FindControl("lblFFtCurntStock");
            Label lblTCurntStock = (Label)row.FindControl("lblTFtCurntStock");
            lblFCurntStock.Text = "";
            lblTCurntStock.Text = "";
            TxtQuantity.Text = "";

            if (ddlCategory.SelectedIndex != 0)
            {

                //Product Bidning Based on Main Category and Sub Category
                DataTable DTProduct = BusinessServices.GetProductOnCategory(Convert.ToInt32(ddlMainCategory.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));



            }
            else
            {
                ddlProduct.Items.Clear();

            }

        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void DdlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList DrpProduct = (DropDownList)sender;
            GridViewRow row = (GridViewRow)DrpProduct.Parent.Parent;
            DropDownList DdlProduct = (DropDownList)row.FindControl("DdlProduct");
            Label lblFCurntStock = (Label)row.FindControl("lblFFtCurntStock");
            Label lblTCurntStock = (Label)row.FindControl("lblTFtCurntStock");
            if (DdlProduct.SelectedIndex != 0)
            {
                ddlFromLoc.Enabled = false;
                ddlToLoc.Enabled = false;
                if (ddlFromLoc.SelectedIndex == 0)
                {
                    DdlProduct.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select From Location..');</script>", false);
                    return;
                }
                else if (ddlToLoc.SelectedIndex == 0)
                {
                    DdlProduct.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select To Location..');</script>", false);
                    return;
                }


                DataTable DtFStock = BusinessServices.Get_ProductStock(ddlFromLoc.SelectedItem.Text, Convert.ToInt32(DdlProduct.SelectedValue));
                lblFCurntStock.Text = DtFStock.Rows[0][0].ToString();

                DataTable DtTStock = BusinessServices.Get_ProductStock(ddlToLoc.SelectedItem.Text, Convert.ToInt32(DdlProduct.SelectedValue));
                lblTCurntStock.Text = DtTStock.Rows[0][0].ToString();
            }
            else
            {
                lblFCurntStock.Text = "";
                lblTCurntStock.Text = "";
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList DdlCatagory = (DropDownList)GvStockTransfer.FooterRow.FindControl("DdlCatagory");
            DropDownList DdlProduct = (DropDownList)GvStockTransfer.FooterRow.FindControl("DdlProduct");
            TextBox TxtQuantity = (TextBox)GvStockTransfer.FooterRow.FindControl("TxtQuantity");
            if (DdlCatagory.SelectedValue != "0" && DdlProduct.SelectedValue == "0" && TxtQuantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
                return;
            }
            else if (DdlCatagory.SelectedValue != "0" && DdlProduct.SelectedValue != "0" && TxtQuantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
                return;
            }
            else if (DdlCatagory.SelectedValue != "0" && DdlProduct.SelectedValue == "0" && TxtQuantity.Text != "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
                return;
            }
            else if (DdlCatagory.SelectedValue == "0" && DdlProduct.SelectedValue == "" && TxtQuantity.Text != "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
                return;
            }
            DataTable dt = (DataTable)ViewState["dtcount"];
            if (dt == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid/Click On Add Button...');</script>", false);
                return;
            }
            else {
                if (dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
                    return;
                }
            }


            if (DdlCatagory.SelectedValue != "0" && DdlProduct.SelectedValue != "0" && TxtQuantity.Text != "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Click On Add Button...');</script>", false);
                return;
            }
            //if (DdlCatagory.SelectedValue != "0" && TxtQuantity.Text != "")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Click On Add Button...');</script>", false);
            //    return;
            //}



            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all fields in the grid...');</script>", false);
            //    return;
            //}



            bool result1, result2;
            int St_ID;
            result1 = objST.InsertStockTransfer(out St_ID, Convert.ToInt32(ddlFromLoc.SelectedValue), ddlFromLoc.SelectedItem.ToString(),
            Convert.ToInt32(ddlToLoc.SelectedValue), ddlToLoc.SelectedItem.ToString(), Convert.ToInt32(ddlMainCategory.SelectedValue),
            Convert.ToInt32(Session["Id"]));

           
            foreach (GridViewRow row in GvStockTransfer.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int Sub_Catg_ID =Convert.ToInt32(((Label)row.FindControl("lblCatagoryID")).Text);                   ;
                    int Product_ID = Convert.ToInt32(((Label)row.FindControl("LblProductID")).Text);
                    int FAvailable_Stock = Convert.ToInt32(((Label)row.FindControl("lblFCurntStock")).Text);
                    int T_Available_Stock = Convert.ToInt32(((Label)row.FindControl("lblTCurntStock")).Text);                    
                    int Transferred_Stock = Convert.ToInt32(((Label)row.FindControl("LblQuantity")).Text);
                    result2 = objST.InsertStockTransferDetails(St_ID, Sub_Catg_ID, Product_ID, FAvailable_Stock, T_Available_Stock, Transferred_Stock);
                }
            }
            if (result1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Stock Transfer Inserted Successfully...');</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Stock Transfer Insertion Failed...');</script>", false);
            }
            Clear(); ViewState["dtcount"] = null;
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        AddFirstRow();
        ddlFromLoc.SelectedValue = "0";
        ddlToLoc.SelectedValue = "0";
        ddlMainCategory.SelectedValue = "0";
        ddlFromLoc.Enabled = true;
        ddlToLoc.Enabled = true;
    }
}