using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Register
{
    public partial class Login : System.Web.UI.Page
    {
        static string Str_hash(string rawData)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));


                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void B_log_Click(object sender, EventArgs e)
        {
            string sta_salt = "eChkAEq6Yx9s";
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            con.Open();
            string checkuname =
                "SELECT count(*) FROM users WHERE username = '" + TB_logname.Text + "'";
            MySqlCommand com = new MySqlCommand(checkuname, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            
            if (temp == 1)
            {
                
                string checkpass =
                    "SELECT password FROM users WHERE username = '" + TB_logname.Text + "'";
                string get_email =
                    "SELECT email FROM users WHERE username = '" + TB_logname.Text + "'";
                string verify = 
                    "SELECT verified FROM users WHERE username = '" + TB_logname.Text + "'";
                string id =
                    "SELECT iduser FROM users WHERE username = '" + TB_logname.Text + "'";
                MySqlCommand compass = new MySqlCommand(checkpass, con);
                MySqlCommand commail = new MySqlCommand(get_email, con);
                MySqlCommand comver = new MySqlCommand(verify, con);
                MySqlCommand comid = new MySqlCommand(id, con);
                string password = compass.ExecuteScalar().ToString().Replace(" ","");
                string mail = commail.ExecuteScalar().ToString().Replace(" ", "");
                int ver = int.Parse(comver.ExecuteScalar().ToString());
                int uid = int.Parse(comid.ExecuteScalar().ToString());
                con.Close();
                if(password == Str_hash((TB_logpass.Text + sta_salt)) && ver == 1)
                {
                    Session["U_name"] = TB_logname.Text;
                    Session["Mail"] = mail;
                    Session["ID"] = uid.ToString(); 
                    Response.Redirect("Catalog.aspx");
                }
                else
                {
                    if (ver != 1)
                    {
                        Session["U_name"] = TB_logname.Text;
                        Session["Mail"] = mail;
                        Session["ID"] = uid.ToString();
                        Response.Redirect("Verify_reg.aspx");
                    }
                    else
                    {
                        Response.Write("Incorrect password");
                    }
                }
            }
            else
            {
                Response.Write("No such user exists");
            }
            
        }

        protected void B_reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}