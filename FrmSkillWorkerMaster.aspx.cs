using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class SkillWorkerMaster : System.Web.UI.Page
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
                Response.Redirect("FrmSkillWorkerMaster.aspx");
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
        //cm = new SqlCommand("select max(Worker_Id) from Skilled_Worker", cn);
        //SqlDataReader dr3 = cm.ExecuteReader();
        //if (dr3.Read())
        //    txtWorkerId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
        //dr3.Close();
    }

    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Skilled_Worker", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Skilled_Worker");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    private void eachRec()
    {
        showData();
        txtWorkerId.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        DropDowndesigntion.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        txtrate.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
       

    }
    private void clr()
    {
        txtWorkerId.Text = "";
        DropDowndesigntion.Text = "";
        txtrate.Text = "";
        
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
            cm = new SqlCommand("insert into Skilled_Worker values(@Worker_Id,@Designation,@RatePerday)", cn);


            cm.Parameters.AddWithValue("@Worker_Id", txtWorkerId.Text);
            cm.Parameters.AddWithValue("@Designation", DropDowndesigntion.Text);
            cm.Parameters.AddWithValue("@RatePerday", txtrate.Text);
            


            da.InsertCommand = cm;
            DataRow drw = ds.Tables[0].NewRow();
            drw[0] = int.Parse(txtWorkerId.Text);
            drw[1] = DropDowndesigntion.Text;
            drw[2] = float.Parse(txtrate.Text);
           

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
        cm = new SqlCommand("update Skilled_Worker set Designation=@Designation,RatePerday=@RatePerday where Worker_Id=@Worker_Id", cn);

        cm.Parameters.AddWithValue("@Worker_Id", txtWorkerId.Text);
        cm.Parameters.AddWithValue("@Designation", DropDowndesigntion.Text);
        cm.Parameters.AddWithValue("@RatePerday", txtrate.Text);


        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Worker_Id=" + int.Parse(txtWorkerId.Text)));
        drw[0][0] = int.Parse(txtWorkerId.Text);
        drw[0][1] = DropDowndesigntion.Text;
        drw[0][2] = float.Parse(txtrate.Text);


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
            cm = new SqlCommand("delete from Skilled_Worker where Worker_Id=@Worker_Id ", cn);


            cm.Parameters.AddWithValue("Worker_Id", txtWorkerId.Text);

            da.DeleteCommand = cm;
            DataRow[] drw = ds.Tables[0].Select(String.Format("Worker_Id=" + int.Parse(txtWorkerId.Text)));

            ds.Tables[0].Rows[0].Delete();

            da.Update(ds.Tables[0]);
            ds.AcceptChanges();
            showData();
            //clr();
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
    protected void btnworkerid_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("select max(Worker_Id) from Skilled_Worker", cn);
        SqlDataReader dr3 = cm.ExecuteReader();
        if (dr3.Read())
            txtWorkerId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
        dr3.Close();
    }
}