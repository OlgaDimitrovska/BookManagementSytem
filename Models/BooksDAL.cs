using System.Data;
using System.Data.SqlClient;

namespace BookManagementSystem.Models
{
    public class BooksDAL
    {
         
        string connectionString = "Data Source=DESKTOP-UK4UJ3E;Initial Catalog=LibraryManagementSystem;Integrated Security=True";

        //To View all employees details   
        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> lstBook = new List<Book>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetBooks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Book book = new Book();

                    book.id = Convert.ToInt32(rdr["Id"]);
                    book.Title = rdr["Title"].ToString();
                    book.YearOfIssue = rdr["YearOfIssue"].ToString();
                    book.NumberOfPages = Convert.ToInt32(rdr["NumberOfPages"]);
                    book.FK_Publisher = Convert.ToInt32(rdr["FK_Publisher"]);

                    lstBook.Add(book);
                }
                con.Close();
            }
            return lstBook;
        }

        public Book GetBookData(int? id)
        {
            Book book = new Book();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Book WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    book.id = Convert.ToInt32(rdr["Id"]);
                    book.Title = rdr["Title"].ToString();
                    book.YearOfIssue = rdr["YearOfIssue"].ToString();
                    book.NumberOfPages = Convert.ToInt32(rdr["NumberOfPages"]);
                    book.FK_Publisher = Convert.ToInt32(rdr["FK_Publisher"]);
                }
            }
            return book;
        }


        public void AddBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Id", book.id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@YearOfIssue", book.YearOfIssue);
                cmd.Parameters.AddWithValue("@NumberOfPages", book.NumberOfPages);
                cmd.Parameters.AddWithValue("@Publisher", book.FK_Publisher);
                //book.Publisher.Id = Convert.ToInt32(rdr["FK_Publisher"]);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee 
        public void UpdateBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", book.id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@NumberOfPages", book.NumberOfPages);
                cmd.Parameters.AddWithValue("@YearOfIssue", book.YearOfIssue);
                cmd.Parameters.AddWithValue("@Publisher", book.FK_Publisher);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

      
        public void DeleteBook(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDelBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

