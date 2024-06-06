using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmEventMaster : System.Web.UI.Page
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
                Response.Redirect("FrmEventMaster.aspx");
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
        
        cm = new SqlCommand("select max(Event_Id) from Event_Master", cn);
        SqlDataReader dr3 = cm.ExecuteReader();
        if (dr3.Read())
            txtEventId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
        dr3.Close();
        showData();
    }

    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Event_Master", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Event_Master");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    private void clr()
    {
        txtEventId.Text = "";
        txtEventName.Text = "";
        CheckBoxflower.Checked = false;
        CheckBoxbhatgi.Checked = false;
        CheckBoxBreakfast.Checked = false;
        CheckBoxIceCream.Checked = false;
        CheckBoxLaunch.Checked = false;
        CheckBoxMusician.Checked = false;
        CheckBoxOther.Checked = false;
        CheckBoxPhotographer.Checked = false;
        txtrateprpartic.Text = "";
        

    }
    private void eachRec()
    {
        CheckBoxflower.Checked = false;
        CheckBoxbhatgi .Checked = false;
        CheckBoxBreakfast .Checked = false;
        CheckBoxIceCream .Checked = false;
        CheckBoxLaunch .Checked = false;
        CheckBoxMusician .Checked = false;
        CheckBoxOther .Checked = false;
        CheckBoxPhotographer .Checked = false;
        showData();
        txtEventId.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        txtEventName.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        string x = ds.Tables[0].Rows[c].ItemArray[2].ToString();
        string [] y=x.Split(',');
        foreach (var a in y)
        {
            if (a.Trim() == "Musician")
                CheckBoxMusician.Checked = true;
            if (a.Trim() == "Photographer")
                CheckBoxPhotographer.Checked = true;
            if (a.Trim() == "Breakfast")
                CheckBoxBreakfast.Checked = true;
            if (a.Trim() == "Launch/Dinner")
                CheckBoxLaunch.Checked = true;
            if (a.Trim() == "Ice Cream")
                CheckBoxIceCream.Checked = true;
            if (a.Trim() == "Flower Decoration")
                CheckBoxflower.Checked = true;
            if (a.Trim() == "Bhatgi")
                CheckBoxbhatgi.Checked = true;
            if (a.Trim() == "Other")
                CheckBoxOther.Checked = true;
          
        }
        txtrateprpartic.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();

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
        
            string c = "";

            if (CheckBoxMusician.Checked == true)
            {

                c += " Musician";
            }
            if (CheckBoxPhotographer.Checked == true)
            {

                c += " Photographer ";
            }
            if (CheckBoxBreakfast.Checked == true)
            {

                c += " Breakfast ";
            }
            if (CheckBoxLaunch.Checked == true)
            {

                c += " Launch/Dinner ";
            }
            if (CheckBoxIceCream.Checked == true)
            {

                c += " Ice Cream ";
            }
            if (CheckBoxflower.Checked == true)
            {

                c += " Flower Decoration ";
            }
            if (CheckBoxbhatgi.Checked == true)
            {

                c += " Bhatgi ";
            }
            if (CheckBoxOther.Checked == true)
            {

                c += " Other ";
            }

            Response.Write("<script >alert('Record added Successfully !"+c.ToString ()+"');</script>");

            cm = new SqlCommand("insert into Event_Master values(@Event_Id,@Event_Name,@Items,@Rate_Per_Participants)", cn);


            cm.Parameters.AddWithValue("@Event_Id", txtEventId.Text);
            cm.Parameters.AddWithValue("@Event_Name", txtEventName.Text);
            cm.Parameters.AddWithValue("@Items", c);
            cm.Parameters.AddWithValue("@Rate_Per_Participants", txtrateprpartic.Text);


            da.InsertCommand = cm;
            DataRow drw = ds.Tables[0].NewRow();
            drw[0] = int.Parse(txtEventId.Text);
            drw[1] = txtEventName.Text;
            drw[2] = c;
            drw[3] = float.Parse(txtrateprpartic.Text);

            ds.Tables[0].Rows.Add(drw);

            da.Update(ds.Tables[0]);
            ds.AcceptChanges();
            showData();
            //clr();
            Response.Write("<script >alert('Record added Successfully !');</script>");
        }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string c = "";

        if (CheckBoxMusician.Checked == true)
        {

            c += " Musician";
        }
        if (CheckBoxPhotographer.Checked == true)
        {

            c += " Photographer ";
        }
        if (CheckBoxBreakfast.Checked == true)
        {

            c += " Breakfast ";
        }
        if (CheckBoxLaunch.Checked == true)
        {

            c += " Launch/Dinner ";
        }
        if (CheckBoxIceCream.Checked == true)
        {

            c += " Ice Cream ";
        }
        if (CheckBoxflower.Checked == true)
        {

            c += " Flower Decoration ";
        }
        if (CheckBoxbhatgi.Checked == true)
        {

            c += " Bhatgi ";
        }
        if (CheckBoxOther.Checked == true)
        {

            c += " Other ";
        }

        //Response.Write("<script >alert('Record edted Successfully !" + c.ToString() + "');</script>");

        cm = new SqlCommand("update Event_Master set Event_Name=@Event_Name,Items=@Items,Rate_Per_Participants=@Rate_Per_Participants where Event_Id=@Event_Id", cn);


        cm.Parameters.AddWithValue("@Event_Id", txtEventId.Text);
        cm.Parameters.AddWithValue("@Event_Name", txtEventName.Text);
        cm.Parameters.AddWithValue("@Items", c);
        cm.Parameters.AddWithValue("@Rate_Per_Participants", txtrateprpartic.Text);

        da.UpdateCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Event_Id=" + int.Parse(txtEventId.Text)));
        drw[0][0] = int.Parse(txtEventId.Text);
        drw[0][1] = txtEventName.Text;
        drw[0][2] = c;
        drw[0][3] = float.Parse(txtrateprpartic.Text);
        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record Edited Successfully !');</script>");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        cm = new SqlCommand("delete from Event_Master where Event_Id=@Event_Id ", cn);


        cm.Parameters.AddWithValue("Event_Id", txtEventId.Text);

        da.DeleteCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Event_Id=" + int.Parse(txtEventId.Text)));

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