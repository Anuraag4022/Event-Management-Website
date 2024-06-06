using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmForgotPasswd : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataReader sdr;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnString x = new ConnString();
        cn = new SqlConnection(x.a);
        cn.Open();
        //sdr = new SqlDataAdapter();
    }
    
    protected void btnshowpasswd_Click(object sender, EventArgs e)
    {
        if (txtuser_Name.Text != "" && txtEmail_Id.Text != "")
        {

            SqlCommand cm = new SqlCommand("select passwd from Login where user_name=@user_name and email_id=@email_id and school_name=@school_name  and contact_no=@contact_no", cn);
            cm.Parameters.AddWithValue("@user_name", txtuser_Name.Text);
            cm.Parameters.AddWithValue("@email_id", txtEmail_Id.Text);
            cm.Parameters.AddWithValue("@school_name", txtschool_Name.Text);
            cm.Parameters.AddWithValue("@contact_no", txtcontact_No.Text);

            sdr = cm.ExecuteReader();
            if (sdr.Read())
            {
                /*
                 * SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

                 smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
                 // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
                 smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                 smtpClient.EnableSsl = true;
                 MailMessage mail = new MailMessage();

                 //Setting From , To and CC
                 mail.From = new MailAddress("kck.exam2021@gmail.com", "google.com");
                 mail.To.Add(new MailAddress(txtEmailId .Text ));
               //  mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
                 mail.Body = "Your Password is" + sdr[0].ToString();
                 smtpClient.Send(mail);
                 */

                Response.Write("<script>alert('Your Passwd is " + sdr[0].ToString() + "');</script>");

            }
            sdr.Close();
            cn.Close();
            // Response.Redirect("frmLogin.aspx");
        }
        else
        {
            Response.Write("<script>alert('should be same');</script>");
        }


    }
    protected void btnshowpasswd0_Click(object sender, EventArgs e)
    {
        txtuser_Name.Text = "";
        txtcontact_No.Text = "";
        txtEmail_Id.Text = "";
        txtschool_Name.Text = "";
    }
}