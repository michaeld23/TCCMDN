using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace TCCMDN
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
           // string userId = Membership.GetUser().ProviderUserKey.ToString();
                try
                {

                    // Open connection to the database
                    string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                                        
                    // Set up a command with the given query and associate
                    // this with the current connection.
                    string CommandText = "SELECT UserName, LastName, Firstname" +
                                         "  FROM Users";
                    cmd = new SqlCommand(CommandText);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    Lastname.Text = CommandText;
                    while(rdr.Read())
                    {
                        Lastname.Text = rdr.GetString(0);
                        FirstName.Text=rdr["Firstname"].ToString();
                        Lastname.Text=rdr["LastName"].ToString();
                        UserName.Text=rdr["UserName"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    // Print error message
                }
                finally
                {
                    // Close data reader object and database connection
                    if (rdr != null)
                        rdr.Close();

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            
        }
    }
}