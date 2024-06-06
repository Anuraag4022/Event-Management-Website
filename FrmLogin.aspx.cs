using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmLogin : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds;
    SqlDataAdapter da;
    SqlDataReader sdr;
    int i, c, n;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnString x = new ConnString();
        cn = new SqlConnection(x.a);
        cn.Open();
        ds = new DataSet();
        da = new SqlDataAdapter();
    }
    private void login()
    {
        //try
        //{
        ds.Clear();
        cm = new SqlCommand("select * from Login where user_name='" + txtusername.Text + "'and passwd='" + txtpass.Text + "'", cn);

        sdr = cm.ExecuteReader();
        if (sdr.Read())
        {
            Session["admin"] = "admin";
            Response.Write("<script>alert('login succesfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('login failed');</script>");
        }
        sdr.Close();
        //}
        //catch (Exception rr) { }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        login();
    }
    protected void btnnewuser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrmNewUser.aspx");
    }
    protected void btnforgetpasswd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrmForgotPasswd.aspx");
    }
}