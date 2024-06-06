using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FrmCheckCalender : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds;
    SqlDataAdapter da;
    int i, c, n;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        cm = new SqlCommand("select Booking_Id,Event_Date,Party_Name,Event,Start_Time,End_Time from Event_Booking", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Event_Booking");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;

        GridViewCheckCalender.DataSource = ds.Tables[0];
        GridViewCheckCalender.DataBind();

    }

}