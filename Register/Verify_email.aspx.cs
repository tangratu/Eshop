using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Register
{
    public partial class Verify_email : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void BT_ver_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            con.Open();
            string ver_code =
                "SELECT email_code FROM users WHERE username = '" + Session["U_name"].ToString() + "'";
            MySqlCommand vercom = new MySqlCommand(ver_code, con);
            if (TB_ver.Text == vercom.ExecuteScalar().ToString())
            {
                string update =
                    "UPDATE users SET verified = 1 WHERE username = '" + Session["U_name"].ToString() + "'";
                MySqlCommand updatecom = new MySqlCommand(update, con);
                updatecom.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Login.aspx");
            }
            else
            {
                con.Close();
                TB_ver.Text = "";
                Response.Write("Incorrect code please try again");
            }

        }

        protected void BT_resend_Click(object sender, EventArgs e)
        {
            TB_ver.Text = "";
            Random rand = new Random();
            int ver_code = rand.Next(1000, 10000);
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
            con.Open();
            string change_code =
                "UPDATE users SET email_code = '" + ver_code.ToString() + "' WHERE username = '" + Session["U_name"].ToString() + "'";
            MySqlCommand codecom = new MySqlCommand(change_code, con);            
            codecom.ExecuteNonQuery();            
            SmtpClient smtpcl = new SmtpClient();
            smtpcl.Host = "smtp.gmail.com";
            smtpcl.Port = 587;
            smtpcl.Credentials = new NetworkCredential("antonge995@gmail.com", "Richirich1@");
            smtpcl.EnableSsl = true;
            MailMessage ver_msg = new MailMessage();
            ver_msg.Subject = "Code";
            ver_msg.Body = ver_code.ToString();
            ver_msg.To.Add(Session["Mail"].ToString());
            ver_msg.From = new MailAddress("antonge995@gmail.com");
            con.Close();
            smtpcl.Send(ver_msg);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["U_name"] = null;
            Session["Mail"] = null;
            Response.Redirect("Register.aspx");
        }
    }
}