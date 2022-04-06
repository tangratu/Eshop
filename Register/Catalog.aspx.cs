using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Register
{

    public partial class User : System.Web.UI.Page
    {
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LB_user.Text = Session["U_name"].ToString();
                //GV_items.AllowSorting = true;                
                MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
                con.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter("SELECT name, price, stock, imagepath FROM items", con);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                GV_items.DataSource = dt;
                GV_items.DataBind();

                con.Close();
            }
        }

        protected void B_logout_Click(object sender, EventArgs e)
        {
            Session["U_name"] = null;
            Session["Mail"] = null;
            LB_user.Text = "User";
            Response.Redirect("Login.aspx");
        }

        protected void Items_sql_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            
        }

        protected void GV_items_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowid = Convert.ToInt32(e.CommandArgument);
            Session["Item_name"] = GV_items.Rows[rowid].Cells[0].Text;
            Session["Item_price"] = GV_items.Rows[rowid].Cells[1].Text;
            Session["Item_stock"] = GV_items.Rows[rowid].Cells[2].Text;            
            string getdesc =
                "SELECT description FROM items WHERE name = '" + GV_items.Rows[rowid].Cells[0].Text + "'";
            string getimg =
                "SELECT imagepath FROM items WHERE name = '" + GV_items.Rows[rowid].Cells[0].Text + "'";
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            MySqlCommand comimg = new MySqlCommand(getimg, con);
            con.Open();
            Session["Item_imgpath"] = comimg.ExecuteScalar().ToString();
            MySqlCommand comdesc = new MySqlCommand(getdesc, con);            
            Session["Item_desc"] = comdesc.ExecuteScalar().ToString();
            con.Close();
            Response.Redirect("Item_page.aspx");
        }

        protected void GV_items_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GV_items_Sorting(object sender, GridViewSortEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            con.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter("SELECT name, price, stock, imagepath FROM items", con);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            con.Close();
            DataView dv = dt.AsDataView();
            if(this.SortDirection == "ASC") { this.SortDirection = "DESC"; }
            else { this.SortDirection = "ASC"; }
            dv.Sort = e.SortExpression + " " + this.SortDirection;
            GV_items.DataSource = dv;
        }

        protected void HLB_Profile_Click(object sender, EventArgs e)
        {
            LB_user.Text = "User";
            Response.Redirect("User_page.aspx");
        }
    }
}