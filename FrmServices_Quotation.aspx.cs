using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmServices : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m,ca;
    DataSet ds,ds1;
    SqlDataAdapter da;
    int i, c, n,n1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["admin"].ToString().Equals("admin"))
            {
                Response.Redirect("FrmServicesQuotation.aspx");
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
        da = new SqlDataAdapter();
        showData();
        showData1();
       
        txtDate.Text = DateTime.Now.ToShortDateString();
    }
    private void eachRec()
    {
        chbkMusician.Checked = false;
        chbkBhatji.Checked = false;
        chbkPhotographer.Checked = false;
        chbkCook.Checked = false;
        chbkFlowerArtist.Checked = false;
        chbkHelper.Checked = false;
        chbkMakeupart.Checked = false;
        showData();
        //showData1();
        txtQuotId.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        txtCustId.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        ddlCustName.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
       
        txtDate.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();

        txtTotBillAmt.Text = ds.Tables[0].Rows[c].ItemArray[4].ToString();
        eachRec1();

    }
    private void eachRec1()
    {
        chbkMusician.Checked = false;
        chbkBhatji.Checked = false;
        chbkPhotographer.Checked = false;
        chbkCook.Checked = false;
        chbkFlowerArtist.Checked = false;
        chbkHelper.Checked = false;
        chbkMakeupart.Checked = false;
        txtmusician.Text = "";
        txtmusicianAmt.Text = "";
        txtPhotographer.Text = "";
        txtPhotographerAmt.Text = "";
        txtCook.Text = "";
        txtCookAmt.Text = "";
        txtmakeup.Text = "";
        txtmakeupamt.Text = "";
        txtFlowerArtist.Text = "";
        txtFlowerArtistAmt.Text = "";
        txtBhatji.Text = "";
        txtBhatjiAmt.Text = "";
        txthelper.Text = "";
        txtHeplerAmt.Text = "";

        showData1();

        for (i = 0; i < n1; i++)
        {
            string x = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
            
            if (x == "Musician")
            {
                chbkMusician.Checked = true;
                txtmusician.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtmusicianAmt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
            }
            if (x == "Photographer")
            {
                chbkPhotographer.Checked = true;
                txtPhotographer.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtPhotographerAmt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
        
            }
            if (x == "Cook")
            {
                chbkCook.Checked = true;
                txtCook.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtCookAmt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
            }
            if (x == "Makeup Artist")
            {
                chbkMakeupart.Checked = true;
                txtmakeup.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtmakeupamt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
            }
            if (x == "Flower Artist")
            {
                chbkFlowerArtist.Checked = true;
                txtFlowerArtist.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtFlowerArtistAmt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
            }
            if (x == "Bhatgi")
            {
                chbkBhatji.Checked = true;
                txtBhatji.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtBhatjiAmt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
            }
            if (x == "Helper")
            {
                chbkHelper.Checked = true;
                txthelper.Text = ds1.Tables[0].Rows[i].ItemArray[2].ToString();
                txtHeplerAmt.Text = ds1.Tables[0].Rows[i].ItemArray[3].ToString();

            }         

        }
    }
    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Services_Quotation", cn);

        da.SelectCommand = cm;
        da.Fill(ds, "Services_Quotation");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }

    

    private void showData1()
    {
        try
        {
            ds1.Clear();
            cm = new SqlCommand("select * from QDetails where Quotation_Id=" + int.Parse(txtQuotId.Text), cn);

            da.SelectCommand = cm;
            da.Fill(ds1, "QDetails");
            ds1.AcceptChanges();
            da.Update(ds1.Tables[0]);
            n1 = ds1.Tables[0].Rows.Count;
        }
        catch (Exception hh) { }
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

    
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        cm = new SqlCommand("insert into Services_Quotation values(@Quotation_Id,@Customer_Id,@Customer_Name,@Date,@Total_Amt)", cn);

        cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
        cm.Parameters.AddWithValue("@Customer_Id", txtCustId.Text);
        cm.Parameters.AddWithValue("@Customer_Name", ddlCustName.Text);
        cm.Parameters.AddWithValue("@Date", txtDate.Text);

        cm.Parameters.AddWithValue("@Total_Amt", txtTotBillAmt.Text);
        da.InsertCommand = cm;
        DataRow drw = ds.Tables[0].NewRow();
        drw[0] = int.Parse(txtQuotId.Text);
        drw[1] = int.Parse(txtCustId.Text);
        drw[2] = ddlCustName.Text;
        drw[3] = txtDate.Text;
        drw[4] = txtTotBillAmt.Text;

        ds.Tables[0].Rows.Add(drw);

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        //clr();
        Response.Write("<script >alert('Record added Successfully !');</script>");




        if (chbkMusician.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
            
            cm.Parameters.AddWithValue("@Item", "Musician");
            cm.Parameters.AddWithValue("@No", txtmusician.Text);
            cm.Parameters.AddWithValue("@Amt", txtmusicianAmt.Text);
            cm.ExecuteNonQuery();

        }
        if (chbkCook.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
         
            cm.Parameters.AddWithValue("@Item","Cook");
            cm.Parameters.AddWithValue("@No", txtCook.Text);
            cm.Parameters.AddWithValue("@Amt", txtCookAmt.Text);
            cm.ExecuteNonQuery();

        }
        if (chbkFlowerArtist.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
         
            cm.Parameters.AddWithValue("@Item", "Flower Artist");
            cm.Parameters.AddWithValue("@No", txtFlowerArtist.Text);
            cm.Parameters.AddWithValue("@Amt", txtFlowerArtistAmt.Text);
            cm.ExecuteNonQuery();
        }
        if (chbkBhatji.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
         
            cm.Parameters.AddWithValue("@Item", "Bhatji");
            cm.Parameters.AddWithValue("@No", txtBhatji.Text);
            cm.Parameters.AddWithValue("@Amt", txtBhatjiAmt.Text);
            cm.ExecuteNonQuery();
        }
        if (chbkPhotographer.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
         
            cm.Parameters.AddWithValue("@Item", "Photographer");
            cm.Parameters.AddWithValue("@No", txtPhotographer.Text);
            cm.Parameters.AddWithValue("@Amt", txtPhotographerAmt.Text);
            cm.ExecuteNonQuery();
        }
        if (chbkHelper.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
            
            cm.Parameters.AddWithValue("@Item", "Helper");
            cm.Parameters.AddWithValue("@No", txthelper.Text);
            cm.Parameters.AddWithValue("@Amt", txtHeplerAmt.Text);
            cm.ExecuteNonQuery();
        }

        if (chbkMakeupart.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
            
            cm.Parameters.AddWithValue("@Item", "Makeup Artist");
            cm.Parameters.AddWithValue("@No", txtmakeup.Text);
            cm.Parameters.AddWithValue("@Amt", txtmakeupamt.Text);
            cm.ExecuteNonQuery();
        }


    }
    protected void ddlCustName_SelectedIndexChanged(object sender, EventArgs e)
    {
        cm = new SqlCommand("select * from Customer where cstmr_name='"+ ddlCustName .Text  +"'", cn);
        SqlDataReader dr2 = cm.ExecuteReader();
        if (dr2.Read())
            txtCustId.Text = dr2[0].ToString();
        dr2.Close();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("update Services_Quotation set Customer_Id=@Customer_Id,Customer_Name=@Customer_Name,Date=@Date, Total_Amt=@Total_Amt  where Quotation_Id=@Quotation_Id", cn);


        cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
        cm.Parameters.AddWithValue("@Customer_Id", txtCustId.Text);
        cm.Parameters.AddWithValue("@Customer_Name", ddlCustName.Text);
        cm.Parameters.AddWithValue("@Date", txtDate.Text);

        cm.Parameters.AddWithValue("@Total_Amt", txtTotBillAmt.Text);
        //cm.ExecuteNonQuery();

        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Quotation_Id=" + int.Parse(txtQuotId.Text)));
        drw[0][0] = int.Parse(txtQuotId.Text);
        drw[0][1] = int.Parse(txtCustId.Text);
        drw[0][2] = ddlCustName.Text;
        drw[0][3] = txtDate.Text;
        drw[0][4] = txtTotBillAmt.Text;


        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        //clr();
        Response.Write("<script >alert('Record Edited Successfully !');</script>");

        if (chbkMusician.Checked == true)
        {
            cm = new SqlCommand("update QDetails set Item=@Item,No=@No,Amt=@Amt  where Quotation_Id=@Quotation_Id", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Musician");
            cm.Parameters.AddWithValue("@No", txtmusician.Text);
            cm.Parameters.AddWithValue("@Amt", txtmusicianAmt.Text);
            cm.ExecuteNonQuery();

        }
        if (chbkCook.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Cook");
            cm.Parameters.AddWithValue("@No", txtCook.Text);
            cm.Parameters.AddWithValue("@Amt", txtCookAmt.Text);
            cm.ExecuteNonQuery();

        }
        if (chbkFlowerArtist.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Flower Artist");
            cm.Parameters.AddWithValue("@No", txtFlowerArtist.Text);
            cm.Parameters.AddWithValue("@Amt", txtFlowerArtistAmt.Text);
            cm.ExecuteNonQuery();
        }
        if (chbkBhatji.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Bhatji");
            cm.Parameters.AddWithValue("@No", txtBhatji.Text);
            cm.Parameters.AddWithValue("@Amt", txtBhatjiAmt.Text);
            cm.ExecuteNonQuery();
        }
        if (chbkPhotographer.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Photographer");
            cm.Parameters.AddWithValue("@No", txtPhotographer.Text);
            cm.Parameters.AddWithValue("@Amt", txtPhotographerAmt.Text);
            cm.ExecuteNonQuery();
        }
        if (chbkHelper.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Helper");
            cm.Parameters.AddWithValue("@No", txthelper.Text);
            cm.Parameters.AddWithValue("@Amt", txtHeplerAmt.Text);
            cm.ExecuteNonQuery();
        }

        if (chbkMakeupart.Checked == true)
        {
            cm = new SqlCommand("insert into QDetails values(@Quotation_Id,@Item,@No,@Amt)", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);

            cm.Parameters.AddWithValue("@Item", "Makeup Artist");
            cm.Parameters.AddWithValue("@No", txtmakeup.Text);
            cm.Parameters.AddWithValue("@Amt", txtmakeupamt.Text);
            cm.ExecuteNonQuery();
        }
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

    protected void btnNewID_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("select max(Quotation_Id) from Services_Quotation", cn);
        SqlDataReader dr3 = cm.ExecuteReader();
        if (dr3.Read())
            txtQuotId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
        dr3.Close();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            cm = new SqlCommand("delete from QDetails where Quotation_Id=@Quotation_Id ", cn);
            cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
            cm.ExecuteNonQuery();
        }
        catch (Exception jj) { }
        cm = new SqlCommand("delete from Services_Quotation where Quotation_Id=@Quotation_Id ", cn);


        cm.Parameters.AddWithValue("@Quotation_Id", txtQuotId.Text);
        //cm.ExecuteNonQuery();

        da.DeleteCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Quotation_Id=" + int.Parse(txtQuotId.Text)));

        ds.Tables[0].Rows[0].Delete();

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        //clr();
        Response.Write("<script >alert('Record Deleted Successfully !');</script>");
    }
    protected void btnTodaysDate_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("select max(Quotation_Id) from Services_Quotation", cn);
        SqlDataReader dr3 = cm.ExecuteReader();
        if (dr3.Read())
            txtQuotId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
        dr3.Close();
    }
}