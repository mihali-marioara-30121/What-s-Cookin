using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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

        public static bool addBookmarkToCurrentRecipe(int idUser, int idRetetaApi)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO retete_preferate (id_user, id_reteta_api) VALUES (@idUser, @idRetetaApi)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUser", idUser);
                    command.Parameters.AddWithValue("@idRetetaApi", idRetetaApi);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }
        public static bool deleteBookmark(int idUser, int idRetetaApi)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM retete_preferate WHERE  id_user = @idUser AND id_reteta_api = @idRetetaApi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUser", idUser);
                    command.Parameters.AddWithValue("@idRetetaApi", idRetetaApi);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }
    }
}
