using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Books : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            BindBooksGrid();
        }
    }

    protected void AddBook_Click(object sender, EventArgs e)
    {
        string title = titleTextBox.Text;
        string author = authorTextBox.Text;
        int year = int.Parse(yearTextBox.Text);
        string category = categoryTextBox.Text;

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Books (Title, Author, Year, Category) VALUES (@Title, @Author, @Year, @Category)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Category", category);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        BindBooksGrid(); // Osvježavanje GridView-a nakon dodavanja nove knjige
    }

    private void BindBooksGrid()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Books";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BooksGridView.DataSource = dt;
            BooksGridView.DataBind();
        }
    }

    protected void BooksGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int bookId = Convert.ToInt32(BooksGridView.DataKeys[e.RowIndex].Value);
        DeleteBookFromDatabase(bookId);
        BindBooksGrid(); // Osvježavanje GridView-a nakon brisanja
    }

    private void DeleteBookFromDatabase(int bookId)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Books WHERE BookID = @BookID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BookID", bookId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
