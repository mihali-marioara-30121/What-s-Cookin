using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_frigider
{
    public  static class BookmarkService
    {

        public static List<Bookmark> GetBookmarksByUserId(int userId)
        {
           List<Bookmark> listBookmarks = new List<Bookmark>();
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM retete_preferate WHERE id_user = @id_user";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_user", userId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    { 
                        int id = reader.GetInt32(0);
                        int id_user = reader.GetInt32(1);
                        int id_reteta_api = reader.GetInt32(3);

                        Bookmark bookmark = new Bookmark(id, id_user, -1, id_reteta_api);

                        listBookmarks.Add(bookmark);
                    }
                 
                }
                return listBookmarks;
            }
        }
    }
}
