using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loans : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            BindLoansGrid();
        }
    }

    protected void BindLoansGrid()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Upit koji uključuje podatke iz tabele Users
            string query = @"
            SELECT 
                Loans.LoanId, 
                Loans.BookId, 
                Loans.MemberId, 
                Users.Name, 
                Users.Surname, 
                Loans.LoanDate, 
                Loans.ReturnDate
            FROM Loans
            INNER JOIN Users ON Loans.MemberId = Users.UserId";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            LoansGridView.DataSource = dt;
            LoansGridView.DataBind();
        }
    }


    // Dodavanje nove posudbe
    protected void AddLoan(object sender, EventArgs e)
    {
        string bookId = Request.Form["bookId"];
        string memberId = Request.Form["memberId"];
        string loanDate = Request.Form["loanDate"];
        string returnDate = Request.Form["returnDate"];

        try
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Loans (BookId, MemberId, LoanDate, ReturnDate) VALUES (@BookId, @MemberId, @LoanDate, @ReturnDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookId", bookId);
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                cmd.Parameters.AddWithValue("@LoanDate", loanDate);
                cmd.Parameters.AddWithValue("@ReturnDate", returnDate);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Ponovno učitaj listu posudbi
            BindLoansGrid();
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Došlo je do greške: " + ex.Message;
        }
    }

    // Brisanje posudbe
    protected void LoansGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Check if the DataKeys collection contains the expected key
        if (e.Keys["LoanId"] != null)
        {
            int loanId = Convert.ToInt32(e.Keys["LoanId"]);
            DeleteLoanFromDatabase(loanId);
            BindLoansGrid(); // Osvježavanje GridView-a nakon brisanja
        }
        else
        {
            lblMessage.Text = "Greška: Nevažeći LoanId.";
        }
    }



    private void DeleteLoanFromDatabase(int loanId)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ToString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Loans WHERE LoanId = @LoanId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LoanId", loanId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

}
