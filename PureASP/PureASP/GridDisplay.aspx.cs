using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Collections.Generic;

namespace PureASP
{
    public partial class GridDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);

            SqlCommand Cmd = new SqlCommand("Procedure", conn);

            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(Cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);
            GvVehicles.DataSource = dt;
            GvVehicles.DataBind();

        }
    }
}