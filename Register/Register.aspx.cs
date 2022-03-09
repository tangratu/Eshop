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
using System.Net.Mail;
using System.Net;


namespace Register
{
   
    
    public partial class Register : System.Web.UI.Page
    {
        public bool user_exi = false;
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
            if (IsPostBack)
            {
                MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
                con.Open();
                string checkuname = "select count(*) from users where username = '"+ TB_uname.Text +"'";
                MySqlCommand com = new MySqlCommand(checkuname, con);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if(temp == 1)
                {
                    Response.Write("User already exists");
                    user_exi = true;
                    con.Close();
                    TB_mail.Text = null;
                    TB_pass1.Text = null;
                    TB_pass2.Text = null;
                    TB_uname.Text = null;
                    TB_captcha.Text = null;
                    return;
                }
                else
                {
                    user_exi = false;
                }
                
            }
        }

        protected void B_reg_Click(object sender, EventArgs e)
        {
            string input = TB_captcha.Text;
            bool captcha = Captcha_box.Validate(input);
            string sta_salt = "eChkAEq6Yx9s";
            TB_captcha.Text = null;
            try
            {
                if (user_exi)
                {
                    
                    return;
                }
                
                
                    if (captcha)
                    {
                        Random rand = new Random();
                        int ver_code = rand.Next(1000, 10000);
                        MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=eshop;User ID=root;Password=Tangratu");
                        con.Open();
                        string ins_qry = "insert into users (username,password,email,email_code) values (@uname,@pass,@mail,@code)";
                        MySqlCommand com = new MySqlCommand(ins_qry, con);
                        com.Parameters.AddWithValue("@uname", TB_uname.Text);
                        com.Parameters.AddWithValue("@pass", Str_hash((TB_pass1.Text + sta_salt)));
                        com.Parameters.AddWithValue("@mail", TB_mail.Text);
                        com.Parameters.AddWithValue("@code", ver_code);
                        com.ExecuteNonQuery();
                        Session["U_name"] = TB_uname.Text;
                        Session["Mail"] = TB_mail.Text;
                        SmtpClient smtpcl = new SmtpClient();
                        smtpcl.Host = "smtp.gmail.com";
                        smtpcl.Port = 587;
                        smtpcl.Credentials = new NetworkCredential("antonge995@gmail.com", "Richirich1@");
                        smtpcl.EnableSsl = true;
                        MailMessage ver_msg = new MailMessage();
                        ver_msg.Subject = "Code";
                        ver_msg.Body = ver_code.ToString();
                        ver_msg.To.Add(TB_mail.Text);
                        ver_msg.From = new MailAddress("antonge995@gmail.com");
                        con.Close();
                        smtpcl.Send(ver_msg);
                        Response.Redirect("Verify_email.aspx");

                    }
                    else
                    {

                        if(!user_exi)Response.Write("Captcha incorrect, please try again.");
                    }
                
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void B_log_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        
    }
}