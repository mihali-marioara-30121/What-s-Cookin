using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class My_recipes : Form
    {
       
        public My_recipes()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        private void My_recipes_Load(object sender, EventArgs e)
        {
            FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();
            string numeUtilizator = UserContext.username;
            this.textBox1.Text = numeUtilizator + " 'S RECIPES";

            // Interogăm baza de date pentru a obține primele trei retete postate de către utilizatorul respectiv
            string query = "SELECT TOP 6 titlu, poza FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator) ORDER BY id ASC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                SqlDataReader reader = command.ExecuteReader();

                // Verificăm dacă există o primă retetă
                if (reader.Read())
                {
                    // Extragem titlul și poza primei retete
                    string titluReteta1 = reader["titlu"].ToString();
                    byte[] pozaReteta1 = (byte[])reader["poza"];

                    // Afisam titlul în label2
                    label1.Text = titluReteta1;

                    // Afisam poza în pictureBox1
                    using (MemoryStream ms = new MemoryStream(pozaReteta1))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Dacă nu există prima retetă, afișăm un mesaj în label2
                    // label2.Text = "Nu există prima rețetă";
                    label8.Text = " IT SEEMS YOU HAVEN'T POSTED ANYTHING YET :(";
                    panel2.Hide();
                }

                // Verificăm dacă există și a doua retetă
                if (reader.Read())
                {
                    // Extragem titlul și poza celei de-a doua retete
                    string titluReteta2 = reader["titlu"].ToString();
                    byte[] pozaReteta2 = (byte[])reader["poza"];

                    // Afisam titlul în label1
                    label2.Text = titluReteta2;

                    // Afisam poza în pictureBox2
                    using (MemoryStream ms = new MemoryStream(pozaReteta2))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Dacă nu există a doua retetă, afișăm un mesaj în label1
                    // label1.Text = "Nu există a doua rețetă";
                    panel3.Hide();
                }

                // Verificăm dacă există și a treia retetă
                if (reader.Read())
                {
                    // Extragem titlul și poza celei de-a treia retete
                    string titluReteta3 = reader["titlu"].ToString();
                    byte[] pozaReteta3 = (byte[])reader["poza"];

                    // Afisam titlul în label3
                    label3.Text = titluReteta3;

                    // Afisam poza în pictureBox3
                    using (MemoryStream ms = new MemoryStream(pozaReteta3))
                    {
                        pictureBox3.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Dacă nu există a treia retetă, afișăm un mesaj în label3
                    panel4.Hide();
                }

                if (reader.Read())
                {
                    // Extragem titlul și poza celei de-a treia retete
                    string titluReteta4 = reader["titlu"].ToString();
                    byte[] pozaReteta4 = (byte[])reader["poza"];

                    // Afisam titlul în label3
                    label4.Text = titluReteta4;

                    // Afisam poza în pictureBox3
                    using (MemoryStream ms = new MemoryStream(pozaReteta4))
                    {
                        pictureBox4.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Dacă nu există a treia retetă, afișăm un mesaj în label3
                    panel5.Hide();
                }

                if (reader.Read())
                {
                    // Extragem titlul și poza celei de-a treia retete
                    string titluReteta5 = reader["titlu"].ToString();
                    byte[] pozaReteta5 = (byte[])reader["poza"];

                    // Afisam titlul în label3
                    label5.Text = titluReteta5;

                    // Afisam poza în pictureBox3
                    using (MemoryStream ms = new MemoryStream(pozaReteta5))
                    {
                        pictureBox5.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Dacă nu există a treia retetă, afișăm un mesaj în label3
                    panel6.Hide();
                }

                if (reader.Read())
                {
                    // Extragem titlul și poza celei de-a treia retete
                    string titluReteta6 = reader["titlu"].ToString();
                    byte[] pozaReteta6 = (byte[])reader["poza"];

                    // Afisam titlul în label3
                    label6.Text = titluReteta6;

                    // Afisam poza în pictureBox3
                    using (MemoryStream ms = new MemoryStream(pozaReteta6))
                    {
                        pictureBox6.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Dacă nu există a treia retetă, afișăm un mesaj în label3
                    panel7.Hide();
                }

                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteRecipe(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteRecipe(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRecipe(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteRecipe(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteRecipe(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteRecipe(6);
        }

        private void DeleteRecipe(int recipeIndex)
        {
            // Obținem numele utilizatorului din textBox1
            string numeUtilizator = textBox1.Text.Split(' ')[0];

            // Interogăm baza de date pentru a obține reteta pe baza indexului și utilizatorului
            string query = "SELECT id FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator) ORDER BY id ASC OFFSET @OffsetRows ROWS FETCH NEXT 1 ROWS ONLY";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                command.Parameters.AddWithValue("@OffsetRows", recipeIndex - 1);
                int recipeId = (int)command.ExecuteScalar();

                // Ștergem reteta din baza de date
                string deleteQuery = "DELETE FROM retete_postate WHERE id = @RecipeId";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@RecipeId", recipeId);
                deleteCommand.ExecuteNonQuery();

                // Afișăm un mesaj de confirmare
                MessageBox.Show("Reteta a fost ștearsă cu succes!");

                // Reîncarcăm formularul pentru a reflecta modificările
                My_recipes_Load(null, EventArgs.Empty);
            }
        }

        Tips_descriere td;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            td = new Tips_descriere();
            td.Show();
            td.pictureBox1.Image = this.pictureBox1.Image;

            string numeUtilizator = UserContext.username;

            // Interogați baza de date pentru a obține id_user-ul corespunzător
            int idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_user FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                idUser = (int?)command.ExecuteScalar() ?? 0;
            }

            // Utilizați idUser pentru a obține timpul de preparare corespunzător
            if (idUser != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string titlu = reader.GetString(0);
                        int timpPreparare = reader.GetInt32(1);
                        string ingrediente = reader.GetString(2);
                        int portii = reader.GetInt32(3);
                        string instructiuni = reader.GetString(4);

                        // Setăm titlul formei td
                        td.Text = titlu;


                        // Afișați detaliile în textBox1
                        td.textBox1.Text = $"Timp preparare: {timpPreparare}{Environment.NewLine}";
                        td.textBox1.AppendText($"Ingrediente: {ingrediente}{Environment.NewLine}");
                        td.textBox1.AppendText($"Număr de porții: {portii}{Environment.NewLine}");
                        td.textBox1.AppendText($"Instrucțiuni: {instructiuni}");
                    }
                }

            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            td = new Tips_descriere();
            td.Show();
            td.pictureBox1.Image = this.pictureBox2.Image;
            string numeUtilizator = UserContext.username;

            // Interogați baza de date pentru a obține id_user-ul corespunzător
            int idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_user FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                idUser = (int?)command.ExecuteScalar() ?? 0;
            }

            // Utilizați idUser pentru a obține timpul de preparare corespunzător
            if (idUser != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser ORDER BY id ASC OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string titlu = reader.GetString(0);
                        int timpPreparare = reader.GetInt32(1);
                        string ingrediente = reader.GetString(2);
                        int portii = reader.GetInt32(3);
                        string instructiuni = reader.GetString(4);

                        // Setăm titlul formei td
                        td.Text = titlu;


                        // Afișați detaliile în textBox1
                        td.textBox1.Text = $"Timp preparare: {timpPreparare}{Environment.NewLine}";
                        td.textBox1.AppendText($"Ingrediente: {ingrediente}{Environment.NewLine}");
                        td.textBox1.AppendText($"Număr de porții: {portii}{Environment.NewLine}");
                        td.textBox1.AppendText($"Instrucțiuni: {instructiuni}");
                    }
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            td = new Tips_descriere();
            td.Show();
            td.pictureBox1.Image = this.pictureBox3.Image;
            string numeUtilizator = UserContext.username;

            // Interogați baza de date pentru a obține id_user-ul corespunzător
            int idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_user FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                idUser = (int?)command.ExecuteScalar() ?? 0;
            }

            // Utilizați idUser pentru a obține timpul de preparare corespunzător
            if (idUser != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser ORDER BY id ASC OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string titlu = reader.GetString(0);
                        int timpPreparare = reader.GetInt32(1);
                        string ingrediente = reader.GetString(2);
                        int portii = reader.GetInt32(3);
                        string instructiuni = reader.GetString(4);

                        // Setăm titlul formei td
                        td.Text = titlu;


                        // Afișați detaliile în textBox1
                        td.textBox1.Text = $"Timp preparare: {timpPreparare}{Environment.NewLine}";
                        td.textBox1.AppendText($"Ingrediente: {ingrediente}{Environment.NewLine}");
                        td.textBox1.AppendText($"Număr de porții: {portii}{Environment.NewLine}");
                        td.textBox1.AppendText($"Instrucțiuni: {instructiuni}");
                    }
                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            td = new Tips_descriere();
            td.Show();
            td.pictureBox1.Image = this.pictureBox4.Image;
            string numeUtilizator = UserContext.username;

            // Interogați baza de date pentru a obține id_user-ul corespunzător
            int idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_user FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                idUser = (int?)command.ExecuteScalar() ?? 0;
            }

            // Utilizați idUser pentru a obține timpul de preparare corespunzător
            if (idUser != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser ORDER BY id ASC OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string titlu = reader.GetString(0);
                        int timpPreparare = reader.GetInt32(1);
                        string ingrediente = reader.GetString(2);
                        int portii = reader.GetInt32(3);
                        string instructiuni = reader.GetString(4);

                        // Setăm titlul formei td
                        td.Text = titlu;


                        // Afișați detaliile în textBox1
                        td.textBox1.Text = $"Timp preparare: {timpPreparare}{Environment.NewLine}";
                        td.textBox1.AppendText($"Ingrediente: {ingrediente}{Environment.NewLine}");
                        td.textBox1.AppendText($"Număr de porții: {portii}{Environment.NewLine}");
                        td.textBox1.AppendText($"Instrucțiuni: {instructiuni}");
                    }
                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            td = new Tips_descriere();
            td.Show();
            td.pictureBox1.Image = this.pictureBox5.Image;
            string numeUtilizator = UserContext.username;

            // Interogați baza de date pentru a obține id_user-ul corespunzător
            int idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser ORDER BY id ASC OFFSET 4 ROWS FETCH NEXT 1 ROWS ONLY";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                idUser = (int?)command.ExecuteScalar() ?? 0;
            }

            // Utilizați idUser pentru a obține timpul de preparare corespunzător
            if (idUser != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string titlu = reader.GetString(0);
                        int timpPreparare = reader.GetInt32(1);
                        string ingrediente = reader.GetString(2);
                        int portii = reader.GetInt32(3);
                        string instructiuni = reader.GetString(4);

                        // Setăm titlul formei td
                        td.Text = titlu;


                        // Afișați detaliile în textBox1
                        td.textBox1.Text = $"Timp preparare: {timpPreparare}{Environment.NewLine}";
                        td.textBox1.AppendText($"Ingrediente: {ingrediente}{Environment.NewLine}");
                        td.textBox1.AppendText($"Număr de porții: {portii}{Environment.NewLine}");
                        td.textBox1.AppendText($"Instrucțiuni: {instructiuni}");
                    }
                }

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            td = new Tips_descriere();
            td.Show();
            td.pictureBox1.Image = this.pictureBox6.Image;
            string numeUtilizator = UserContext.username;

            // Interogați baza de date pentru a obține id_user-ul corespunzător
            int idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_user FROM retete_postate WHERE id_user = (SELECT id FROM Utilizator WHERE nume_utilizator = @NumeUtilizator)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeUtilizator", numeUtilizator);
                idUser = (int?)command.ExecuteScalar() ?? 0;
            }

            // Utilizați idUser pentru a obține timpul de preparare corespunzător
            if (idUser != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT titlu, timp_preparare, ingrediente, portii, instructiuni FROM retete_postate WHERE id_user = @IdUser ORDER BY id ASC OFFSET 5 ROWS FETCH NEXT 1 ROWS ONLY";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string titlu = reader.GetString(0);
                        int timpPreparare = reader.GetInt32(1);
                        string ingrediente = reader.GetString(2);
                        int portii = reader.GetInt32(3);
                        string instructiuni = reader.GetString(4);

                        // Setăm titlul formei td
                        td.Text = titlu;


                        // Afișați detaliile în textBox1
                        td.textBox1.Text = $"Timp preparare: {timpPreparare} minute{Environment.NewLine}";
                        td.textBox1.AppendText($"Ingrediente: {ingrediente}{Environment.NewLine}");
                        td.textBox1.AppendText($"Număr de porții: {portii}{Environment.NewLine}");
                        td.textBox1.AppendText($"Instrucțiuni: {instructiuni}");
                    }
                }

            }
        }
    }
}
