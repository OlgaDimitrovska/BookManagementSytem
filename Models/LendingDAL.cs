using System.Data.SqlClient;
using System.Data;
using BookManagementSystem.Models;

namespace BookManagementSystem.Models
{
    public class LendingDAL
    {
        string connectionString = "Data Source=DESKTOP-UK4UJ3E;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
  
        public IEnumerable<Lending> GetAllLendings()
        {
            List<Lending> lendings = new List<Lending>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetLendings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Lending lend = new Lending();

                    lend.Id = Convert.ToInt32(rdr["Id"]);
                    lend.FK_Book = Convert.ToInt32(rdr["FK_Book"]);
                    lend.FK_Client = Convert.ToInt32(rdr["FK_Client"]);
                    lend.DatumZajmuvanje = rdr["DatumZajmuvanje"].ToString();
                    lend.DatumVratena = rdr["DatumVratena"].ToString();

                    lendings.Add(lend);
                }
                con.Close();
            }
            return lendings;
        }


        public IEnumerable<Lending> GetAllReturnedLendings()
        {
            List<Lending> lendings = new List<Lending>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Returned", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Lending lend = new Lending();

                    lend.Id = Convert.ToInt32(rdr["Id"]);
                    lend.FK_Book = Convert.ToInt32(rdr["FK_Book"]);
                    lend.FK_Client = Convert.ToInt32(rdr["FK_Client"]);
                    lend.DatumZajmuvanje = rdr["DatumZajmuvanje"].ToString();
                    lend.DatumVratena = rdr["DatumVratena"].ToString();

                    lendings.Add(lend);
                }
                con.Close();
            }
            return lendings;
        }

        public IEnumerable<Lending> GetAllNotReturnedLendings()
        {
            List<Lending> lendings = new List<Lending>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("NotReturned", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Lending lend = new Lending();

                    lend.Id = Convert.ToInt32(rdr["Id"]);
                    lend.FK_Book = Convert.ToInt32(rdr["FK_Book"]);
                    lend.FK_Client = Convert.ToInt32(rdr["FK_Client"]);
                    lend.DatumZajmuvanje = rdr["DatumZajmuvanje"].ToString();
                    lend.DatumVratena = rdr["DatumVratena"].ToString();

                    lendings.Add(lend);
                }
                con.Close();
            }
            return lendings;
        }

        public Lending GetLending(int? id)
        {
            Lending lend = new Lending();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Lending WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lend.Id = Convert.ToInt32(rdr["Id"]);
                    lend.FK_Book = Convert.ToInt32(rdr["FK_Book"]);
                    lend.FK_Client = Convert.ToInt32(rdr["FK_Client"]);
                    lend.DatumZajmuvanje = rdr["DatumZajmuvanje"].ToString();
                    lend.DatumVratena = rdr["DatumVratena"].ToString();
                }
            }
            return lend;
        }


        public void AddLending(Lending lending)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddLending", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FK_Book", lending.FK_Book);
                cmd.Parameters.AddWithValue("@FK_Client", lending.FK_Client);
                cmd.Parameters.AddWithValue("@DatumZajmuvanje", lending.DatumZajmuvanje);
                cmd.Parameters.AddWithValue("@DatumVratena", lending.DatumVratena);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void UpdateLending(Lending lending)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdLending", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FK_Book", lending.FK_Book);
                cmd.Parameters.AddWithValue("@FK_Client", lending.FK_Client);
                cmd.Parameters.AddWithValue("@DatumZajmuvanje", lending.DatumZajmuvanje);
                cmd.Parameters.AddWithValue("@DatumVratena", lending.DatumVratena);
                //cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

  
        public void DeleteLending(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDelLending", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
