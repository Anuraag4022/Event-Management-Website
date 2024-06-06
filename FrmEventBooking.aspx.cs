using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
public partial class FrmEventBookingt : System.Web.UI.Page
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
                Response.Redirect("FrmEventBooking.aspx");
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
       // showData2();
       showData();
       
       
    }
    private void showData()
    {
        ds.Clear();
        cm = new SqlCommand("select * from Event_Booking", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Event_Booking");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    private void showData2()
    {
        ds2.Clear();
        cm = new SqlCommand("select * from Customer", cn);
        da.SelectCommand = cm;
        da.Fill(ds2, "Customer");
        ds2.AcceptChanges();
        da.Update(ds2.Tables[0]);
        ddlPartyName.DataSource = ds2.Tables[0];
        ddlPartyName.DataTextField = "cstmr_name";
        ddlPartyName.DataValueField = "cstmr_name";
        ddlPartyName.DataBind();

    }
    private void eachRec()
    {
        showData();
        txtBookingId.Text = ds.Tables[0].Rows[c].ItemArray[0].ToString();
        txtDate.Text = ds.Tables[0].Rows[c].ItemArray[1].ToString();
        //ddlPartyName.Text = ds.Tables[0].Rows[c].ItemArray[2].ToString();
        txtAddress.Text = ds.Tables[0].Rows[c].ItemArray[3].ToString();

        txtContactNo.Text = ds.Tables[0].Rows[c].ItemArray[4].ToString();
        DropEvent.Text = ds.Tables[0].Rows[c].ItemArray[5].ToString();
        txtEventDate.Text = ds.Tables[0].Rows[c].ItemArray[6].ToString();
        txtPlaceAddress.Text = ds.Tables[0].Rows[c].ItemArray[7].ToString();

        txtApproxParti.Text = ds.Tables[0].Rows[c].ItemArray[8].ToString();
        txtStart_Time.Text = ds.Tables[0].Rows[c].ItemArray[9].ToString();
        txtEnd_Time.Text = ds.Tables[0].Rows[c].ItemArray[10].ToString();
        
    }
    private void clr() 
    {
        txtBookingId.Text="";
        txtDate.Text="";
        //ddlPartyName.Text="";
        txtAddress.Text="";

        txtContactNo.Text="";
        DropEvent.Text="";
        txtEventDate.Text="";
        txtPlaceAddress.Text="";

        txtApproxParti.Text="";
        txtStart_Time.Text="";
        txtEnd_Time.Text="";

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
        cm = new SqlCommand("insert into Event_Booking values(@Booking_Id,@Date,@Party_Name,@Address,@Contact_No,@Event,@Event_Date,@Place_Address,@Approx_Parti,@Start_Time,@End_Time)", cn);


        cm.Parameters.AddWithValue("@Booking_Id", txtBookingId.Text);
        cm.Parameters.AddWithValue("@Date", txtDate.Text);
        cm.Parameters.AddWithValue("@Party_Name", ddlPartyName.Text);
        cm.Parameters.AddWithValue("@Address", txtAddress.Text);

        cm.Parameters.AddWithValue("@Contact_No", txtContactNo.Text);
        cm.Parameters.AddWithValue("@Event", DropEvent.Text);
        cm.Parameters.AddWithValue("@Event_Date", txtEventDate.Text);
        cm.Parameters.AddWithValue("@Place_Address", txtPlaceAddress.Text);

        cm.Parameters.AddWithValue("@Approx_Parti", txtApproxParti.Text);
        cm.Parameters.AddWithValue("@Start_Time", txtStart_Time.Text);
        cm.Parameters.AddWithValue("@End_Time", txtEnd_Time.Text);
        


        da.InsertCommand = cm;
        DataRow drw = ds.Tables[0].NewRow();
        drw[0] = int.Parse(txtBookingId.Text);
        drw[1] = txtDate.Text;
        drw[2] = ddlPartyName.Text;
        drw[3] = txtAddress.Text;

        drw[4] = txtContactNo.Text;
        drw[5] = DropEvent.Text;
        drw[6] = txtEventDate.Text;
        drw[7] = txtPlaceAddress.Text;

        drw[8] = txtApproxParti.Text;
        drw[9] = txtStart_Time.Text;
        drw[10] = txtEnd_Time.Text;
        

        ds.Tables[0].Rows.Add(drw);

        da.Update(ds.Tables[0]);
        ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record added Successfully !');</script>");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            showData();
            cm = new SqlCommand("update Event_Booking set Date=@Date,Party_Name=@Party_Name,Address=@Address, Contact_No=@Contact_No,Event=@Event,Event_Date=@Event_Date, Place_Address=@Place_Address, Approx_Parti=@Approx_Parti,Start_Time=@Start_Time,End_Time=@End_Time  where Booking_Id=@Booking_Id", cn);

            //@Booking_Id,@Date,@Party_Name,@Address,@Contact_No,@Event,@Event_Date,@Place_Address,@Approx_Parti,@Start_Time,@End_Time
            cm.Parameters.AddWithValue("@Booking_Id", txtBookingId.Text);
            cm.Parameters.AddWithValue("@Date", txtDate.Text);
            cm.Parameters.AddWithValue("@Party_Name", ddlPartyName.Text);
            cm.Parameters.AddWithValue("@Address", txtAddress.Text);

            cm.Parameters.AddWithValue("@Contact_No", txtContactNo.Text);
            cm.Parameters.AddWithValue("@Event", DropEvent.Text);
            cm.Parameters.AddWithValue("@Event_Date", txtEventDate.Text);
            cm.Parameters.AddWithValue("@Place_Address", txtPlaceAddress.Text);

            cm.Parameters.AddWithValue("@Approx_Parti", txtApproxParti.Text);
            cm.Parameters.AddWithValue("@Start_Time", txtStart_Time.Text);
            cm.Parameters.AddWithValue("@End_Time", txtEnd_Time.Text);
        


            cm.ExecuteNonQuery();
            //da.UpdateCommand = cm;
            //DataRow[] drw1 = ds.Tables[0].Select(String.Format("Booking_Id=" + int.Parse(txtBookingId.Text)));
            //drw1[0][0] = int.Parse(txtBookingId.Text);
            //drw1[0][1] = txtDate.Text;
            //drw1[0][2] = ddlPartyName.Text;
            //drw1[0][3] = txtAddress.Text;

            //drw1[0][4] = txtContactNo.Text;
            //drw1[0][5] = DropEvent.Text;
            //drw1[0][6] = txtEventDate.Text;
            //drw1[0][7] = txtPlaceAddress.Text;

            //drw1[0][8] = txtApproxParti.Text;
            //drw1[0][9] = txtStart_Time.Text;
            //drw1[0][10] = txtEnd_Time.Text;

            //da.Update(ds.Tables[0]);
            //ds.AcceptChanges();
            showData();
            clr();
            Response.Write("<script >alert('Record Edited Successfully !');</script>");
        }
        catch (Exception hh) { Response.Write("<script >alert('"+hh.ToString ()+"');</script>"); }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        showData();
        cm = new SqlCommand("delete from Event_Booking where Booking_Id=@Booking_Id ", cn);


        cm.Parameters.AddWithValue("Booking_Id", txtBookingId.Text);

        da.DeleteCommand = cm;
        DataRow[] drw = ds.Tables[0].Select(String.Format("Booking_Id=" + int.Parse(txtBookingId.Text)));
        cm.ExecuteNonQuery();
        //ds.Tables[0].Rows[0].Delete();

        //da.Update(ds.Tables[0]);
        //ds.AcceptChanges();
        showData();
        clr();
        Response.Write("<script >alert('Record Deleted Successfully !');</script>");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clr();
    }

    protected void btnShowID_Click(object sender, EventArgs e)
    {
        showData2();
    }
    protected void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        cm = new SqlCommand("select * from Customer where cstmr_name='" + ddlPartyName.Text + "'", cn);
        SqlDataReader dr2 = cm.ExecuteReader();
        if (dr2.Read())
            txtContactNo.Text = dr2[2].ToString();
        dr2.Close();
    }
    protected void btnNewID_Click(object sender, EventArgs e)
    {
        try
        {
            cm = new SqlCommand("select max(Booking_Id) from Event_Booking", cn);
            SqlDataReader dr3 = cm.ExecuteReader();
            if (dr3.Read())
                txtBookingId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
            dr3.Close();
        }
        catch (Exception hhh) { txtBookingId.Text = "1"; }
    }
   
    protected void btnShow0_Click1(object sender, EventArgs e)
    {
        try
        {
            cm = new SqlCommand("select max(Booking_Id) from Event_Booking", cn);
            SqlDataReader dr3 = cm.ExecuteReader();
            if (dr3.Read())
                txtBookingId.Text = (int.Parse(dr3[0].ToString()) + 1).ToString();
            dr3.Close();
        }
        catch (Exception hhh) { txtBookingId.Text = "1"; }
    }
    protected void btnShow1_Click(object sender, EventArgs e)
    {
        showData2();
    }
}