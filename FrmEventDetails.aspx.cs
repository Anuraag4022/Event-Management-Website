using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmEventDetails : System.Web.UI.Page
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
                Response.Redirect("FrmEventDetails.aspx");
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
    }

    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Event_Details", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Event_Details");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    private void eachRec()
    {
        showData();
        txtBook_ID.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        txtParty_Name.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        txtQuot_Id.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
        txtBill_amt.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();

        txtAdv_Amt.Text = ds.Tables[0].Rows[c].ItemArray[4].ToString();
        txtRecvd_By.Text = ds.Tables[0].Rows[c].ItemArray[5].ToString();
       

    }
    private void clr()
    {
        txtBook_ID.Text = "";
        txtParty_Name.Text = "";
        txtQuot_Id.Text = "";
        txtBill_amt.Text = "";
        txtAdv_Amt.Text = "";
        txtRecvd_By.Text = "";

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
        cm = new SqlCommand("insert into Event_Details values(@Booking_Id,@Party_Name,@Quotation_Id,@Bill_Amt,@Advance_Amt,@Received_By)", cn);


        cm.Parameters.AddWithValue("@Booking_Id", txtBook_ID.Text);
        cm.Parameters.AddWithValue("@Party_Name", txtParty_Name.Text);
        cm.Parameters.AddWithValue("@Quotation_Id", txtQuot_Id.Text);
        cm.Parameters.AddWithValue("@Bill_Amt", txtBill_amt.Text);

        cm.Parameters.AddWithValue("@Advance_Amt", txtAdv_Amt.Text);
        cm.Parameters.AddWithValue("@Received_By", txtRecvd_By.Text);



        da.InsertCommand = cm;
        DataRow drw = ds.Tables[0].NewRow();
        drw[0] = int.Parse(txtBook_ID.Text);
        drw[1] = txtParty_Name.Text;
        drw[2] = int.Parse(txtQuot_Id.Text);
        drw[3] = float.Parse(txtBill_amt.Text);

        drw[4] = float.Parse(txtAdv_Amt.Text);
        drw[5] = txtRecvd_By.Text;
        

        ds.Tables[0].Rows.Add(drw);

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record added Successfully !');</script>");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("update Event_Details set Party_Name=@Party_Name,Quotation_Id=@Quotation_Id,Bill_Amt=@Bill_Amt,Advance_Amt=@Advance_Amt,Received_By=@Received_By where Booking_Id=@Booking_Id", cn);


        cm.Parameters.AddWithValue("@Booking_Id", txtBook_ID.Text);
        cm.Parameters.AddWithValue("@Party_Name", txtParty_Name.Text);
        cm.Parameters.AddWithValue("@Quotation_Id", txtQuot_Id.Text);
        cm.Parameters.AddWithValue("@Bill_Amt", txtBill_amt.Text);

        cm.Parameters.AddWithValue("@Advance_Amt", txtAdv_Amt.Text);
        cm.Parameters.AddWithValue("@Received_By", txtRecvd_By.Text);




        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Booking_Id=" + int.Parse(txtBook_ID.Text)));
        drw[0][0] = int.Parse(txtBook_ID.Text);
        drw[0][1] = txtParty_Name.Text;
        drw[0][2] = int.Parse(txtQuot_Id.Text);
        drw[0][3] = float.Parse(txtBill_amt.Text);

        drw[0][4] = float.Parse(txtAdv_Amt.Text);
        drw[0][5] = txtRecvd_By.Text;


        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record Edited Successfully !');</script>");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("delete from Event_Details where Booking_Id=@Booking_Id ", cn);


        cm.Parameters.AddWithValue("Booking_Id", txtBook_ID.Text);

        da.DeleteCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Booking_Id=" + int.Parse(txtBook_ID.Text)));

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
}