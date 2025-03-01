using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            BindUsersGrid();
        }
    }

    protected void BindUsersGrid()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Users";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UsersGridView.DataSource = dt;
            UsersGridView.DataBind();
        }
    }

    protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userId = Convert.ToInt32(UsersGridView.DataKeys[e.RowIndex].Value);
        DeleteUserFromDatabase(userId);
        BindUsersGrid(); // Osvježavanje GridView-a nakon brisanja
    }

    private void DeleteUserFromDatabase(int userId)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserID", userId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Dodavanje novog člana
    protected void AddUser(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;
        string surname = surnameTextBox.Text;
        string membership = membershipTextBox.Text;
        string contact = contactTextBox.Text;

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Users (Name, Surname, MembershipCard, Contact) VALUES (@Name, @Surname, @MembershipCard, @Contact)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@MembershipCard", membership);
            cmd.Parameters.AddWithValue("@Contact", contact);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        BindUsersGrid(); // Osvježavanje GridView-a nakon dodavanja novog člana
    }
}