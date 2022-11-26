using System.Data.SqlClient;
using System.Data;

namespace BookManagementSystem.Models
{
    public class ClientDAL
    {

        string connectionString = "Data Source=DESKTOP-UK4UJ3E;Initial Catalog=LibraryManagementSystem;Integrated Security=True";

        //To View all employees details   
        public IEnumerable<Client> GetAllClients()
        {
            List<Client> lstClient = new List<Client>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetClients", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Client client = new Client();

                    client.id = Convert.ToInt32(rdr["Id"]);
                    client.Name = rdr["Name"].ToString();
                    client.Phone = rdr["Phone"].ToString();
                    client.Address = rdr["Address"].ToString();
                    client.City = rdr["City"].ToString();

                    lstClient.Add(client);
                }
                con.Close();
            }
            return lstClient;
        }

        public Client GetClientDataID(int? id)
        {
            Client client = new Client();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Client WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    client.id = Convert.ToInt32(rdr["Id"]);
                    client.Name = rdr["Name"].ToString();
                    client.Phone = rdr["Phone"].ToString();
                    client.Address = rdr["Address"].ToString();
                    client.City = rdr["City"].ToString();
                }
            }
            return client;
        }


        public void AddClient(Client client)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddClient", con);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@Id", client.id);
                cmd.Parameters.AddWithValue("@Address", client.Address);
                cmd.Parameters.AddWithValue("@City", client.City);
                cmd.Parameters.AddWithValue("@Name", client.Name);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        
        public void UpdateClient(Client client)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdClient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", client.id);
                cmd.Parameters.AddWithValue("@Address", client.Address);
                cmd.Parameters.AddWithValue("@City", client.City);
                cmd.Parameters.AddWithValue("@Name", client.Name);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);
                //cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee 


        //To Delete the record on a particular employee 
        public void DeleteClient(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDelClient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}

