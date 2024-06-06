using System;
using System.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
public partial class rptPayment2 : System.Web.UI.Page
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
        cm = new SqlCommand("select * from Payment", cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Payment");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        n = ds.Tables[0].Rows.Count;
    }
}