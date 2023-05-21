using System.Configuration;
using System.Data.SqlClient;

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

        public static bool AddUser(string username, string password, string email)
        {
            // Crează o conexiune la baza de date utilizând cheia de conexiune din App.config
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construiește interogarea SQL pentru a insera utilizatorul în baza de date
                string query = "INSERT INTO Utilizator (parola, nume_utilizator, email) VALUES (@parola, @nume_utilizator, @email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adaugă parametrii pentru interogare pentru a evita SQL injection
                    command.Parameters.AddWithValue("@parola", password);
                    command.Parameters.AddWithValue("@nume_utilizator", username);
                    command.Parameters.AddWithValue("@email", email);

                    // Deschide conexiunea la baza de date
                    connection.Open();

                    // Execută interogarea SQL
                    int rowsAffected = command.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
         public static bool VerifyCredentials(string username, string password)
         {
            // Crează conexiunea la baza de date și interogarea SQL
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM Utilizator WHERE nume_utilizator = @Username AND parola = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            // Deschide conexiunea și execută interogarea
            connection.Open();
            int count = (int)command.ExecuteScalar();

            // Închide conexiunea și eliberează resursele
            connection.Close();
            command.Dispose();

            // Returnează true dacă utilizatorul și parola corespund, altfel false
            return count > 0;
        }

        public static bool UtilizatorExists(string username)
        {
            // Crează conexiunea la baza de date și interogarea SQL
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM Utilizator WHERE nume_utilizator = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);

            // Deschide conexiunea și execută interogarea
            connection.Open();
            int count = (int)command.ExecuteScalar();

            // Închide conexiunea și eliberează resursele
            connection.Close();
            command.Dispose();

            // Returnează true dacă numele de utilizator există deja, altfel false
            return count > 0;
        }

        public static bool ChangePassword(string username, string newPassword)
        {
            // Actualizați parola în baza de date
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            string query = "UPDATE Utilizator SET parola = @newPassword WHERE nume_utilizator = @username";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@username", username); 

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
