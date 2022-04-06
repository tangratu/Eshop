using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register
{
    public partial class User_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LB_Mail.Text = Session["Mail"].ToString();
            LB_User.Text = Session["U_name"].ToString();
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            con.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter("SELECT items.name, quantity, items.price FROM cart JOIN items ON cart.iditem = items.iditems WHERE cart.iduser ='" + Session["ID"].ToString() + "'", con);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            GV_cart.DataSource = dt;
            GV_cart.DataBind();
            string get_total =
                "SELECT SUM(items.price*cart.quantity) FROM cart JOIN items ON cart.iditem = items.iditems WHERE cart.iduser ='" + Session["ID"].ToString() + "'";
            MySqlCommand comsum = new MySqlCommand(get_total, con);
            LB_sum.Text += comsum.ExecuteScalar().ToString() + " лв";

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LB_Mail.Text = "Email";
            LB_User.Text = "User";
            Response.Redirect("Catalog.aspx");
        }

        protected void BT_Logout_Click(object sender, EventArgs e)
        {
            Session["U_name"] = null;
            Session["Mail"] = null;
            Session["ID"] = null;
            LB_Mail.Text = "Email";
            LB_User.Text = "User";
            Response.Redirect("Login.aspx");
        }

        

        protected void GV_cart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowid = Convert.ToInt32(e.CommandArgument);
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            con.Open();
            string itemname = GV_cart.Rows[rowid].Cells[0].Text;
            string getid =
                "SELECT iditems FROM  items WHERE name ='" + itemname + "'";
            MySqlCommand comid = new MySqlCommand(getid, con);            
            string delet = 
                "DELETE FROM cart WHERE iditem = '" + comid.ExecuteScalar().ToString() + "' AND iduser ='"+ Session["ID"].ToString() + "'";
            MySqlCommand delete = new MySqlCommand(delet, con);
            delete.ExecuteNonQuery();
            MySqlDataAdapter mda = new MySqlDataAdapter("SELECT items.name, quantity, items.price FROM cart JOIN items ON cart.iditem = items.iditems WHERE cart.iduser ='" + Session["ID"].ToString() + "'", con);
            DataTable dt = new DataTable();
            mda.Fill(dt);
           // dt.Rows[rowid].Delete();
            ViewState["dt"] = dt;
            GV_cart.DataSource = dt;
            GV_cart.DataBind();

        }
    }
}