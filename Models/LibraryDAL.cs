using System.Data.SqlClient;
using System.Data;
using BookManagementSystem.Models;

namespace BookManagementSystem.Models
{
    public class LibraryDAL
    {
        string connectionString = "Data Source=DESKTOP-UK4UJ3E;Initial Catalog=LibraryManagementSystem;Integrated Security=True";

        //To View all employees details   
        public IEnumerable<Library> GetAllLibraries()
        {
            List<Library> libraries = new List<Library>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetLibraries", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Library library = new Library();

                    library.id = Convert.ToInt32(rdr["Id"]);
                    library.Name = rdr["Name"].ToString();
                    library.Address = rdr["Address"].ToString();
                    library.City = rdr["City"].ToString();

                    libraries.Add(library);
                }
                con.Close();
            }
            return libraries;
        }

        public Library GetLibraryData(int? id)
        {
            Library library = new Library();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Library WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    library.id = Convert.ToInt32(rdr["Id"]);
                    library.Name = rdr["Name"].ToString();
                    library.Address = rdr["Address"].ToString();
                    library.City = rdr["City"].ToString();
                }
            }
            return library;
        }

        public void AddLibrary(Library library)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddLibrary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Address", library.Address);
                cmd.Parameters.AddWithValue("@City", library.City);
                cmd.Parameters.AddWithValue("@Name", library.Name);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee 
        public void UpdateLibrary(Library library)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdLibrary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", library.id);
                cmd.Parameters.AddWithValue("@Address", library.Address);
                cmd.Parameters.AddWithValue("@City", library.City);
                cmd.Parameters.AddWithValue("@Name", library.Name);
                //cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee 


        //To Delete the record on a particular employee 
        public void DeleteLibrary(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDelLibrary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
