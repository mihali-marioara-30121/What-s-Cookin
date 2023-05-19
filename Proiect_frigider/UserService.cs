using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_frigider
{
   
    public static class UserService
    {
        public static int GetUserIdByName(string username)
        {
            int id = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Utilizator WHERE nume_utilizator = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (username != null)
                    {
                        command.Parameters.AddWithValue("@username", username);
                    }
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.Close();
                    //connection.Close();
                }
                return id;

            }

        }
    }
}
