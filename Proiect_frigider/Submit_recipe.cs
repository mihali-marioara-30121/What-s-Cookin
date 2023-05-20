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
    public partial class Submit_recipe : Form
    {
        public Submit_recipe()
        {
            InitializeComponent();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fișiere imagine (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                textBox2.Text = imagePath;
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();

            // Obțineți ID-ul utilizatorului corespunzător numelui de utilizator din label1
            string numeUtilizator = form1.helloLabel.Text.Split(' ')[1];
            int userId = GetUserIdByNumeUtilizator(numeUtilizator);

            // Obțineți valorile introduse în controalele TextBox
            string titlu = textBox1.Text;
            string pozaPath = textBox2.Text;
            TimeSpan timpPreparare = TimeSpan.Parse(textBox3.Text);
            int portii = int.Parse(textBox4.Text);
            string ingrediente = textBox5.Text;
            string instructiuni = textBox6.Text;

            // Convertiți poza într-un șir de octeți
            byte[] pozaBytes = File.ReadAllBytes(pozaPath);

            // Creați o conexiune la baza de date utilizând cheia de conexiune din App.config
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construiți interogarea SQL pentru a adăuga reteta în tabela "retete_postate"
                string query = "INSERT INTO retete_postate (id_user, titlu, ingrediente, timp_preparare, portii, instructiuni, poza) " +
                               "VALUES (@id_user, @titlu, @ingrediente, @timp_preparare, @portii, @instructiuni, @poza)";

                // Creați un obiect SqlCommand cu interogarea SQL și conexiunea
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adăugați parametrii corespunzători valorilor introduse
                    command.Parameters.AddWithValue("@id_user", userId);
                    command.Parameters.AddWithValue("@titlu", titlu);
                    command.Parameters.AddWithValue("@ingrediente", ingrediente);
                    command.Parameters.AddWithValue("@timp_preparare", timpPreparare);
                    command.Parameters.AddWithValue("@portii", portii);
                    command.Parameters.AddWithValue("@instructiuni", instructiuni);
                    command.Parameters.AddWithValue("@poza", pozaBytes);

                    // Deschideți conexiunea la baza de date
                    connection.Open();

                    // Executați interogarea SQL pentru a adăuga reteta în tabela "retete_postate"
                    command.ExecuteNonQuery();

                    // Eliberați resursele
                    command.Dispose();

                    // Afisati un mesaj de succes
                    MessageBox.Show("Reteta a fost adaugata cu succes!");

                    this.Hide();
                    textBox1.Text = "RECIPE NAME";
                    textBox2.Text = "UPLOAD A FILE";
                    textBox3.Text = "COOKING TIME(MINUTES)";
                    textBox4.Text = "SERVINGS";
                    textBox5.Text = "INGREDIENT LIST";
                    textBox4.Text = "INSTRUCTIONS";

                }
            }
        }

        // Funcție pentru a obține ID-ul utilizatorului pe baza numelui de utilizator
        private int GetUserIdByNumeUtilizator(string numeUtilizator)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id FROM Utilizator WHERE nume_utilizator = @nume_utilizator";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nume_utilizator", numeUtilizator);
                    connection.Open();
                    int userId = (int)command.ExecuteScalar();
                    command.Dispose();
                    return userId;
                }
            }
        }

    }
}
