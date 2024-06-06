using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmNewUser : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds;
    SqlDataAdapter da;
    int i, c, n;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnString x = new ConnString();
        cn = new SqlConnection(x.a);
        cn.Open();
        ds = new DataSet();
        da = new SqlDataAdapter();
    }
    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Login", cn);
        da.SelectCommand = cm;
        da.Fill(ds, ";Login");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);
        n = ds.Tables[0].Rows.Count;

    }
    private void clr() 
    {
         txtUsername.Text="";
         txtPass.Text = "";
         txtSchool.Text = "";
         txtEmail.Text = "";
         txtMob.Text = "";
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        showData();
        //try
        //{

        cm = new SqlCommand("insert into Login values(@user_name,@passwd,@email_id,@school_name,@contact_no)", cn);

        cm.Parameters.AddWithValue("@user_name", txtUsername.Text);
        cm.Parameters.AddWithValue("@passwd", txtPass.Text);
        cm.Parameters.AddWithValue("@school_name", txtSchool.Text);
        cm.Parameters.AddWithValue("@email_id", txtEmail.Text);
        cm.Parameters.AddWithValue("@contact_no", txtMob.Text);

        da.InsertCommand = cm;

        DataRow drw = ds.Tables[0].NewRow();
        drw[0] = txtUsername.Text;
        drw[1] = txtPass.Text;
        drw[3] = txtSchool.Text;
        drw[2] = txtEmail.Text;
        drw[4] = txtMob.Text;

        ds.Tables[0].Rows.Add(drw);

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        clr();
        Response.Write("<script >alert('User Added Successfully !');</script>");

    }
}