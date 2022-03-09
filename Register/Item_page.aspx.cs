using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register
{
    public partial class Item_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Img_item.ImageUrl = Session["Item_imgpath"].ToString();
            LB_name.Text = Session["Item_name"].ToString();
            LB_price.Text = Session["Item_price"].ToString() + " лв";
            LB_stock.Text += Session["Item_stock"].ToString();
            LB_desc.Text = Session["Item_desc"].ToString();
        }

        protected void BT_return_Click(object sender, EventArgs e)
        {
            Session["Item_name"] = null;
            Session["Item_price"] = null;
            Session["Item_stock"] = null;
            Session["Item_desc"] = null;
            LB_name.Text = null;
            LB_desc.Text = null;
            LB_price.Text = null;
            LB_stock.Text = "Stock: ";
            Response.Redirect("Catalog.aspx");
        }
    }
}