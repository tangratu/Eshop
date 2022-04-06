using MySql.Data.MySqlClient;
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
            LB_user.Text = Session["U_name"].ToString();
            RV_amount.MaximumValue = LB_stock.Text;
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

        protected void HLB_profile_Click(object sender, EventArgs e)
        {
            Session["Item_name"] = null;
            Session["Item_price"] = null;
            Session["Item_stock"] = null;
            Session["Item_desc"] = null;
            LB_name.Text = null;
            LB_desc.Text = null;
            LB_price.Text = null;
            LB_stock.Text = "Stock: ";
            Response.Redirect("User_page.aspx");
        }

        protected void BT_buy_Click(object sender, EventArgs e)
        {
            string getid =
                "SELECT iditems FROM  items WHERE name ='" + LB_name.Text + "'";
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            string add_to_cart =
                "INSERT INTO cart (iditem , iduser,  quantity) VALUES (@itemid, @id, @quan)";
            con.Open();
            MySqlCommand comid = new MySqlCommand(getid, con);
            int id = int.Parse(comid.ExecuteScalar().ToString());
            MySqlCommand comcart = new MySqlCommand(add_to_cart, con);
            comcart.Parameters.AddWithValue("@itemid", id);
            comcart.Parameters.AddWithValue("@id", int.Parse(Session["ID"].ToString()));                      
            comcart.Parameters.AddWithValue("@quan", int.Parse(TB_amount.Text));            
            comcart.ExecuteNonQuery();
            con.Close();
        }
    }
}