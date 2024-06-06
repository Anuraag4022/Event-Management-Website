using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;


public partial class FrmCustomer : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds;
    SqlDataAdapter da;
    int i, c, n;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["admin"].ToString().Equals("admin"))
            {
                Response.Redirect("FrmCustomer.aspx");
            }

        }
        catch (Exception e1)
        {
            Response.Redirect("FrmLogin.aspx");
        }

        if (ViewState["c"] != null)
        {
            c = int.Parse(ViewState["c"].ToString());
        }
        else
        {
            c = 0;
        }
        ConnString x = new ConnString();
        cn = new SqlConnection(x.a);
        cn.Open();
        ds = new DataSet();
        da = new SqlDataAdapter();
        showData();
        cm = new SqlCommand("select max(cstmr_Id) from Customer", cn);
        SqlDataReader dr3 = cm.ExecuteReader();
        if (dr3.Read())
            txtCustomerId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
        dr3.Close();
    }

    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Customer", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Customer");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }

    private void eachRec()
    {
        showData();
        txtCustomerId.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        txtCustomerName.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        txtwpNo.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
        txtEmailId.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();
       

    }
    private void clr()
    {
        txtCustomerId.Text = "";
        txtCustomerName.Text = "";
        txtwpNo.Text = "";
        txtEmailId.Text = "";
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        showData();
    }
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        c = 0;
        eachRec();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        
        if (c < n - 1)
        {
            c++;
            eachRec();
        }
        else
        {
            Response.Write("<script> alert('Last Record');</script>");

        }
        ViewState["c"] = c.ToString();

    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        if (c > 0)
        {
            c--;
            eachRec();
        }
        else
        {
            Response.Write("<script> alert('First Record');</script>");

        }
        ViewState["c"] = c.ToString();
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        c = n - 1;
        eachRec();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            cm = new SqlCommand("insert into customer values(@cstmr_Id,@cstmr_name,@cstmr_wpno,@cstmr_emailid)", cn);


            cm.Parameters.AddWithValue("@cstmr_Id", txtCustomerId.Text);
            cm.Parameters.AddWithValue("@cstmr_name", txtCustomerName.Text);
            cm.Parameters.AddWithValue("@cstmr_wpno", txtwpNo.Text);
            cm.Parameters.AddWithValue("@cstmr_emailid", txtEmailId.Text);


            da.InsertCommand = cm;
            DataRow drw = ds.Tables[0].NewRow();
            drw[0] = int.Parse(txtCustomerId.Text);
            drw[1] = txtCustomerName.Text;
            drw[2] = long.Parse(txtwpNo.Text);
            drw[3] = txtEmailId.Text;

            ds.Tables[0].Rows.Add(drw);

            da.Update(ds.Tables[0]);
            ds.AcceptChanges();
            showData();
            clr();
            Response.Write("<script >alert('Record added Successfully !');</script>");
        }
        catch (Exception e1)
        { }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {


        cm = new SqlCommand("update Customer set cstmr_name=@cstmr_name,cstmr_wpno=@cstmr_wpno,cstmr_emailid=@cstmr_emailid where cstmr_Id=@cstmr_Id", cn);

        //@d_id,@d_name,@d_dob,@d_age,@d_address,@d_contact,@d_bloodgroup,@d_desease_history
        cm.Parameters.AddWithValue("@cstmr_Id", txtCustomerId.Text);
        cm.Parameters.AddWithValue("@cstmr_name", txtCustomerName.Text);
        cm.Parameters.AddWithValue("@cstmr_wpno", txtwpNo.Text);
        cm.Parameters.AddWithValue("@cstmr_emailid", txtEmailId.Text);
        

        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("cstmr_Id=" + int.Parse(txtCustomerId.Text)));
        drw[0][0] = int.Parse(txtCustomerId.Text);
        drw[0][1] = txtCustomerName.Text;
        drw[0][2] = long.Parse(txtwpNo.Text);
        drw[0][3] = txtEmailId.Text;


        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record Edited Successfully !');</script>");
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            cm = new SqlCommand("delete from customer where cstmr_Id=@cstmr_Id ", cn);


            cm.Parameters.AddWithValue("cstmr_Id", txtCustomerId.Text);

            da.DeleteCommand = cm;
            DataRow[] drw = ds.Tables[0].Select(String.Format("cstmr_Id=" + int.Parse(txtCustomerId.Text)));

            ds.Tables[0].Rows[0].Delete();

            da.Update(ds.Tables[0]);
            ds.AcceptChanges();
            showData();
            clr();
            Response.Write("<script >alert('Record Deleted Successfully !');</script>");
        }
        //m = new SqlCommand("delete from customer", cn);
        //m.ExecuteNonQuery();
        catch (Exception e1)
        { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clr();
   
    }
}