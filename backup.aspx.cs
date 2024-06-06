using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
public partial class backup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnbackup_Click(object sender, EventArgs e)
    {
        byte[] x = File.ReadAllBytes("F:\\Event Management Project\\EventManagement\\App_Data\\Event_Management.mdf");
        string fd = "E:\\backup";
        if (!System.IO.Directory.Exists(fd))
        {
            System.IO.Directory.CreateDirectory(fd);
        }
        File.WriteAllBytes(fd + "\\Event_Management.mdf", x);
    }
    protected void Btnrestore_Click(object sender, EventArgs e)
    {
        byte[] x = File.ReadAllBytes("E:\\backup\\Event_Management.mdf");
        string fd = "F:\\Event Management Project\\EventManagement\\App_Data";
        if (!System.IO.Directory.Exists(fd))
        {
            System.IO.Directory.CreateDirectory(fd);
        }
        File.WriteAllBytes(fd + "\\Event_Management.mdf", x);
    }
}