using System.Data.SqlClient;
using System.Data;

namespace BookManagementSystem.Models
{
    public class BookCopiesDAL
    {
        string connectionString = "Data Source=DESKTOP-UK4UJ3E;Initial Catalog=LibraryManagementSystem;Integrated Security=True";

        
        public IEnumerable<BookCopies> GetAllBookCopies()
        {
            List<BookCopies> bookCopies = new List<BookCopies>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetBookCopies", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BookCopies book = new BookCopies();

                    book.id = Convert.ToInt32(rdr["Id"]);
                    book.FK_Book = Convert.ToInt32(rdr["FK_Book"]);
                    book.FK_Library = Convert.ToInt32(rdr["FK_Library"]);
                    book.NumberOfCopies = Convert.ToInt32(rdr["NumberOfCopies"]);
                    

                    bookCopies.Add(book);
                }
                con.Close();
            }
            return bookCopies;
        }

          
        public void AddBookCopies(BookCopies bookcopy)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddBookCopies", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_Library", bookcopy.FK_Library);
                cmd.Parameters.AddWithValue("@FK_Book", bookcopy.FK_Book);
                cmd.Parameters.AddWithValue("@NumberOfCopies", bookcopy.NumberOfCopies);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        
        public void UpdateBookCopies(BookCopies bookCopies)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateBookCopies", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", bookCopies.id);
                cmd.Parameters.AddWithValue("@FK_Library", bookCopies.FK_Library);
                cmd.Parameters.AddWithValue("@FK_Book", bookCopies.FK_Book);
                cmd.Parameters.AddWithValue("@NumberOfCopies", bookCopies.NumberOfCopies);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        
        public BookCopies GetBookCopies(int? id)
        {
            BookCopies book = new BookCopies();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM BookCopies WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    book.id = Convert.ToInt32(rdr["Id"]);
                    book.FK_Library = Convert.ToInt32(rdr["FK_Library"]);
                    book.FK_Book = Convert.ToInt32(rdr["FK_Book"]);
                    book.NumberOfCopies = Convert.ToInt32(rdr["NumberOfCopies"]);

                }
            }
            return book;
        }

        //To Delete the record on a particular employee 
        public void DeleteBookCopies(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteBookCopies", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
