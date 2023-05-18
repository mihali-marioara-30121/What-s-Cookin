using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_frigider
{
    internal class UserService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        //static User GetUserDetails(int userId)
        //{
        //    User user = null;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT id, parola, nume_utilizator, email FROM UserTable WHERE id = @UserId";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@UserId", userId);

        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                user = new User
        //                {
        //                    Id = reader.GetInt32(0),
        //                    Parola = reader.GetString(1),
        //                    NumeUtilizator = reader.GetString(2),
        //                    Email = reader.GetString(3)
        //                };
        //            }

        //            reader.Close();
        //        }
        //    }

        //    return user;
        //}
    }
}
