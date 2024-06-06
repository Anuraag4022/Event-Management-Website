using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmBill : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds,ds2;
    SqlDataAdapter da;
    int i, c, n;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["admin"].ToString().Equals("admin"))
            {
                Response.Redirect("FrmBill.aspx");
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
        ds2 = new DataSet();
        da = new SqlDataAdapter();
        //showData();
    }

    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Bill", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Bill");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    private void showData2()
    {
        ds2.Clear();
        cm = new SqlCommand("select * from Services_Quotation", cn);
        da.SelectCommand = cm;
        da.Fill(ds2, "Services_Quotation");
        ds2.AcceptChanges();
        da.Update(ds2.Tables[0]);
        ddlQuotId.DataSource = ds2.Tables[0];
        ddlQuotId.DataTextField = "Quotation_Id";
        ddlQuotId.DataValueField = "Quotation_Id";
        ddlQuotId.DataBind();

    }

    private void eachRec()
    {
        rdbUPI.Checked = true;
        rdbCash.Checked = false;
        rdbdebit.Checked = false;

        showData();
        txtBill_No.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        txtDate.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        ddlQuotId.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
        txtCustName.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();
        txtAmt.Text = ds.Tables[0].Rows[c].ItemArray[4].ToString();
        txtAdv_amt.Text = ds.Tables[0].Rows[c].ItemArray[5].ToString();
        txtBal_amt.Text = ds.Tables[0].Rows[c].ItemArray[6].ToString();
        string x = ds.Tables[0].Rows[c].ItemArray[7].ToString();
        if (x == "UPI")
            rdbUPI.Checked = true;
        else if (x == "Cash")
            rdbCash.Checked = true;
        else if (x == "Debit")
            rdbdebit.Checked = true;
        txtRecvd_By.Text = ds.Tables[0].Rows[c].ItemArray[8].ToString();
    
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        showData();
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        
        c = 0;
        eachRec();
        ViewState["c"] = c.ToString();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

       // if (c < n - 1)
        //{
            c++;
            eachRec();
        //}
        //else
        //{
            //Response.Write("<script> alert('Last Record');</script>");

        //}
        ViewState["c"] = c.ToString();

    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {

        //if (c > 0)
        //{
            c--;
            eachRec();
        //}
        //else
        //{
         //   Response.Write("<script> alert('First Record');</script>");

        //}
        ViewState["c"] = c.ToString();
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {

        c = n - 1;
        eachRec();
        ViewState["c"] = c.ToString();
    }

    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        string x = " ";
        if (rdbUPI.Checked == true)
            x += "UPI";
        else if (rdbCash.Checked == true)
            x += "Cash";
        else if (rdbdebit.Checked == true)
            x += "Debit";

        cm = new SqlCommand("insert into Bill values(@Bill_No,@Date,@Quotation_Id,@Customer_Name,@Amount,@Advance_Amount,@Balance_Amount,@Paid_By,@Received_By)", cn);


        cm.Parameters.AddWithValue("@Bill_No", txtBill_No.Text);
        cm.Parameters.AddWithValue("@Date", txtDate.Text);
        cm.Parameters.AddWithValue("@Quotation_Id", ddlQuotId.Text);
        cm.Parameters.AddWithValue("@Customer_Name", txtCustName.Text);

        cm.Parameters.AddWithValue("@Amount", txtAmt.Text);
        cm.Parameters.AddWithValue("@Advance_Amount", txtAdv_amt.Text);
        cm.Parameters.AddWithValue("@Balance_Amount", txtBal_amt.Text);
        cm.Parameters.AddWithValue("@Paid_By", x);

        cm.Parameters.AddWithValue("@Received_By", txtRecvd_By.Text);

        da.InsertCommand = cm;
        DataRow drw = ds.Tables[0].NewRow();
        drw[0] = int.Parse(txtBill_No.Text);
        drw[1] = txtDate.Text;
        drw[2] = ddlQuotId.Text;
        drw[3] = txtCustName.Text;

        drw[4] = txtAmt.Text;
        drw[5] = txtAdv_amt.Text;
        drw[6] = txtBal_amt.Text;
        drw[7] = x;

        drw[8] = txtRecvd_By.Text;



        ds.Tables[0].Rows.Add(drw);

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        //clr();
        Response.Write("<script >alert('Record added Successfully !');</script>");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string x = " ";
        if (rdbUPI.Checked == true)
            x += "UPI";
        else if (rdbCash.Checked == true)
            x += "Cash";
        else if (rdbdebit.Checked == true)
            x += "Debit";
        cm = new SqlCommand("update  Bill set Date=@Date,Quotation_Id=@Quotation_Id,Customer_Name=@Customer_Name,Amount=@Amount,Advance_Amount=@Advance_Amount,Balance_Amount=@Balance_Amount,Paid_By=@Paid_By,Received_By=@Received_By where Bill_No=@Bill_No", cn);

        cm.Parameters.AddWithValue("@Bill_No", txtBill_No.Text);
        cm.Parameters.AddWithValue("@Date", txtDate.Text);
        cm.Parameters.AddWithValue("@Quotation_Id", ddlQuotId.Text);
        cm.Parameters.AddWithValue("@Customer_Name", txtCustName.Text);

        cm.Parameters.AddWithValue("@Amount", txtAmt.Text);
        cm.Parameters.AddWithValue("@Advance_Amount", txtAdv_amt.Text);
        cm.Parameters.AddWithValue("@Balance_Amount", txtBal_amt.Text);
        cm.Parameters.AddWithValue("@Paid_By", x);

        cm.Parameters.AddWithValue("@Received_By", txtRecvd_By.Text);

        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Bill_No=" + int.Parse(txtBill_No.Text)));

        drw[0][0] = int.Parse(txtBill_No.Text);
        drw[0][1] = txtDate.Text;
        drw[0][2] = ddlQuotId.Text;
        drw[0][3] = txtCustName.Text;

        drw[0][4] = txtAmt.Text;
        drw[0][5] = txtAdv_amt.Text;
        drw[0][6] = txtBal_amt.Text;
        drw[0][7] = x;

        drw[0][8] = txtRecvd_By.Text;

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        //clr();
        Response.Write("<script >alert('Record Edited Successfully !');</script>");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("delete from Bill where Bill_No=@Bill_No ", cn);


        cm.Parameters.AddWithValue("Bill_No", txtBill_No.Text);

            da.DeleteCommand = cm;
            DataRow[] drw = ds.Tables[0].Select(String.Format("Bill_No=" + int.Parse(txtBill_No.Text)));

            ds.Tables[0].Rows[0].Delete();

            da.Update(ds.Tables[0]);
            ds.AcceptChanges();
            showData();
            //clr();
            Response.Write("<script >alert('Record Deleted Successfully !');</script>");
    }


    protected void ddlQuotId_SelectedIndexChanged(object sender, EventArgs e)
    {
        cm = new SqlCommand("select * from Services_Quotation where Quotation_Id='" + ddlQuotId.Text + "'", cn);
        SqlDataReader dr2 = cm.ExecuteReader();
        if (dr2.Read())
            txtCustName.Text = dr2[2].ToString();
        dr2.Close();
    }
    protected void btnShowID_Click(object sender, EventArgs e)
    {
        showData2();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBill_No.Text = "";
        txtDate.Text = "";
        ddlQuotId.Text = "";
        txtCustName.Text = "";
        txtAmt.Text = "";
        txtAdv_amt.Text = "";
        txtBal_amt.Text = "";
        txtRecvd_By.Text = "";
        rdbUPI.Checked = false;
        rdbCash.Checked = false;
        rdbdebit.Checked = false;

    }
}