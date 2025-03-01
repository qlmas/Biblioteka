using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Brisanje sesije i preusmjeravanje na login
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}