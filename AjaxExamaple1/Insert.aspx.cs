using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AjaxExamaple1
{
    public partial class Insert : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        string opr,empName;
        protected void Page_Load(object sender, EventArgs e)
        {
            opr = Request.QueryString["opr"].ToString();
            if(opr == "search")
            {
                empName = Request.QueryString["name"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from employee where empName like('"+empName.ToString()+"%')",con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                Response.Write("<table border='1'");
                Response.Write("<tr>");
                Response.Write("<td style = text-align:center>");Response.Write("empName");Response.Write("</td>");
                Response.Write("<td style = text-align:center>"); Response.Write("empEmail"); Response.Write("</td>");
                Response.Write("<td style = text-align:center>"); Response.Write("empContact"); Response.Write("</td>");
                Response.Write("<td style = text-align:center>"); Response.Write("empDOB"); Response.Write("</td>");
                Response.Write("<tr>");

                foreach(DataRow dr in dt.Rows)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr["empName"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["empEmail"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["empContact"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["empDOB"].ToString()); Response.Write("</td>");
                    Response.Write("<tr>");
                }
                Response.Write("</table>");
                con.Close();
            }
        }
    }
}