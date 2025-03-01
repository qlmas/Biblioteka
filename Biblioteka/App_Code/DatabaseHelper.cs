using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseHelper
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();

    // Metoda za dodavanje knjige u bazu
    public void AddBook(string title, string author, int year, string category)
    {
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
    }

    // Metoda za dohvatanje svih knjiga iz baze
    public DataTable GetBooks()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Books";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
        }
        return dt;
    }

    // Metoda za brisanje knjige iz baze
    public void DeleteBook(int bookId)
    {
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
