using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class singleBillreportt : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm, m;
    DataSet ds;
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnString x = new ConnString();
        cn = new SqlConnection(x.a);
        cn.Open();
        ds = new DataSet();
        da = new SqlDataAdapter();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        cm = new SqlCommand("select * from Bill where Bill_No=" + int.Parse(DropDownList1.Text), cn);
        da.SelectCommand = cm;
        da.Fill(ds, "Bill");
        ds.AcceptChanges();
        da.Update(ds.Tables[0]);

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ds.Tables[0]));
        ReportViewer1.LocalReport.Refresh();
    }
}