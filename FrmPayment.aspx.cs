using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmPayment : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds,ds1,ds2;
    SqlDataAdapter da;
    int i, c, n;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["admin"].ToString().Equals("admin"))
            {
                Response.Redirect("FrmPayment.aspx");
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
        ds1 = new DataSet();
        ds2 = new DataSet();
        da = new SqlDataAdapter();
        
        showData();
    }

    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Payment", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Payment");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    private void showData1()
    {
        ds1.Clear();
        cm = new SqlCommand("select * from Customer", cn);
        da.SelectCommand = cm;
        da.Fill(ds1, "Customer");
        ds1.AcceptChanges();
        da.Update(ds1.Tables[0]);
        ddlCust_Name.DataSource = ds1.Tables[0];
        ddlCust_Name.DataTextField = "cstmr_name";
        ddlCust_Name.DataValueField = "cstmr_name";
        ddlCust_Name.DataBind();

       

    }

    private void showData2()
    {
        ds2.Clear();
        cm = new SqlCommand("select * from Event_Master", cn);
        da.SelectCommand = cm;
        da.Fill(ds2, "Event_Master");
        ds2.AcceptChanges();
        da.Update(ds2.Tables[0]);
        ddlEvent_Id.DataSource = ds2.Tables[0];
        ddlEvent_Id.DataTextField = "Event_Id";
        ddlEvent_Id.DataValueField = "Event_Id";
        ddlEvent_Id.DataBind();



    }

    private void eachRec()
    {
        showData();
        txtBill_No.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        ddlEvent_Id.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        txtEvent_Name.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
        ddlCust_Name.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();
        txtPay_Due_amt.Text = ds.Tables[0].Rows[c].ItemArray[4].ToString();   
    }
    private void clr()
    {
        txtBill_No.Text = "";
        txtEvent_Name.Text = "";
        //ddlEvent_Id.Text = "";
        txtPay_Due_amt.Text = "";
        //ddlCust_Name.Text = "";
        

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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("update Payment set Event_Id=@Event_Id,Event_Name=@Event_Name,Customer_Name=@Customer_Name,Payment_Due_Amount=@Payment_Due_Amount where Bill_No=@Bill_No", cn);


        cm.Parameters.AddWithValue("@Bill_No", txtBill_No.Text);
        cm.Parameters.AddWithValue("@Event_Id", ddlEvent_Id.Text);
        cm.Parameters.AddWithValue("@Event_Name", txtEvent_Name.Text);
        cm.Parameters.AddWithValue("@Customer_Name", ddlCust_Name.Text);
        cm.Parameters.AddWithValue("@Payment_Due_Amount", txtPay_Due_amt.Text);

        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Bill_No=" + int.Parse(txtBill_No.Text)));

        drw[0][0] = int.Parse(txtBill_No.Text);
        drw[0][1] = int.Parse(ddlEvent_Id.Text);
        drw[0][2] = txtEvent_Name.Text;
        drw[0][3] = ddlCust_Name.Text;
        drw[0][4] = float.Parse(txtPay_Due_amt.Text);
        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record Edited Successfully !');</script>");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("insert into Payment values(@Bill_No,@Event_Id,@Event_Name,@Customer_Name,@Payment_Due_Amount)", cn);


        cm.Parameters.AddWithValue("@Bill_No", txtBill_No.Text);
        cm.Parameters.AddWithValue("@Event_Id", ddlEvent_Id.Text);
        cm.Parameters.AddWithValue("@Event_Name", txtEvent_Name.Text);
        cm.Parameters.AddWithValue("@Customer_Name", ddlCust_Name.Text);
        cm.Parameters.AddWithValue("@Payment_Due_Amount", txtPay_Due_amt.Text);
        
        da.InsertCommand = cm;
        DataRow drw = ds.Tables[0].NewRow();
        drw[0] = int.Parse(txtBill_No.Text);
        drw[1] = int.Parse(ddlEvent_Id.Text);
        drw[2] = txtEvent_Name.Text;
        drw[3] = ddlCust_Name.Text;
        drw[4] = float.Parse(txtPay_Due_amt.Text);
        
        ds.Tables[0].Rows.Add(drw);

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record added Successfully !');</script>");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("delete from Payment where Bill_No=@Bill_No ", cn);


        cm.Parameters.AddWithValue("Bill_No", txtBill_No.Text);

        da.DeleteCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Bill_No=" + int.Parse(txtBill_No.Text)));

        ds.Tables[0].Rows[0].Delete();

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record Deleted Successfully !');</script>");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clr();
    }

    protected void btnShowname_Click(object sender, EventArgs e)
    {
        showData1();
      
    }

    protected void ddlEvent_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        cm = new SqlCommand("select * from Event_Master where Event_Id='" + ddlEvent_Id.Text + "'", cn);
        SqlDataReader dr2 = cm.ExecuteReader();
        if (dr2.Read())
            txtEvent_Name.Text = dr2[1].ToString();
        dr2.Close();
    }
    protected void btnShowID_Click(object sender, EventArgs e)
    {
        showData2();
    }
}