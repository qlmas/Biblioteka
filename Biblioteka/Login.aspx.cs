using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ako je korisnik već prijavljen, preusmjeri ga
        if (Session["Username"] != null)
        {
            Response.Redirect("Books.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Privremena provjera podataka
        if (username == "admin" && password == "admin")
        {
            // Postavi sesiju i preusmjeri korisnika
            Session["Username"] = username;
            Response.Redirect("Books.aspx");
        }
        else
        {
            lblMessage.Text = "Neispravno korisničko ime ili lozinka.";
        }
    }
}