using System.Data.SqlClient;
using System.Data;
using BookManagementSystem.Models;

namespace BookManagementSystem.Models
{
    public class PublisherDAL
    {
        string connectionString = "Data Source=DESKTOP-UK4UJ3E;Initial Catalog=LibraryManagementSystem;Integrated Security=True";

        //To View all employees details   
        public IEnumerable<Publisher> GetAllPublishers()
        {
            List<Publisher> publishers = new List<Publisher>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetPublishers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Publisher publisher = new Publisher();

                    publisher.Id = Convert.ToInt32(rdr["Id"]);
                    publisher.Name = rdr["Name"].ToString();
                    publisher.Country = rdr["Country"].ToString();


                    publishers.Add(publisher);
                }
                con.Close();
            }
            return publishers;
        }

        public Publisher GetPublisherID(int? id)
        {
            Publisher pub = new Publisher();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Publisher WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    pub.Id = Convert.ToInt32(rdr["Id"]);
                    pub.Name = rdr["Name"].ToString();
                    pub.Country = rdr["Country"].ToString();
                }
            }
            return pub;
        }


        public void AddPublisher(Publisher publisher)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPublisher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Id", publisher.Id);
                cmd.Parameters.AddWithValue("@Name", publisher.Name);
                cmd.Parameters.AddWithValue("@Country", publisher.Country);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

       
        public void UpdatePublisher(Publisher publisher)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdPublisher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", publisher.Id);
                cmd.Parameters.AddWithValue("@Name", publisher.Name);
                cmd.Parameters.AddWithValue("@Country", publisher.Country);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee 


        //To Delete the record on a particular employee 
        public void DeletePublisher(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDelPublisher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

