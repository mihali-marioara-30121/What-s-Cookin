using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Register : Form
    {
        // FormFirstPage f = new FormFirstPage();
       // public FormFirstPage f;
        public Register()
        {
           
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;


        /*  private void button1_Click(object sender, EventArgs e)
          {
              //trebuie sa pun cod de verificare daca a introdus corect
              MessageBox.Show("Register successful!");
              this.Hide();
          }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox4.Text;

            if (password == confirmPassword)
            {
                // Crează o conexiune la baza de date utilizând cheia de conexiune din App.config
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
                        if (UtilizatorExists(username))
                        {
                            MessageBox.Show("Utilizatorul există deja în baza de date. Vă rugăm să alegeți un alt nume de utilizator.", "Eroare de înregistrare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Deschide conexiunea la baza de date
                        connection.Open();

                        // Execută interogarea SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        // Verifică dacă inserarea a avut succes
                        if (rowsAffected > 0)
                        {
                            FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();
                            Login login = Application.OpenForms.OfType<Login>().FirstOrDefault();
                            MyProfile mp = Application.OpenForms.OfType<MyProfile>().FirstOrDefault();


                            if (form1 != null)
                            {
                                form1.label1.Text = "Hello " + textBox1.Text + " !";
                                form1.button_login.Text = "Logout";
                                login.label1.Text = "Hello " + username;
                                mp.label1.Text = "HELLO " + username + " !";
                            }


                            //f.label1.Text = "Hello " + textBox1.Text;
                          //  ((FormFirstPage)this.Owner).label1.Text = "Hello " + textBox1.Text; 
                            MessageBox.Show("Utilizatorul a fost înregistrat cu succes!");
                            textBox1.Text = "USERNAME";
                            textBox2.Text = "EMAIL";
                            textBox3.Text = "PASSWORD";
                            textBox4.Text = "CONFIRM PASSWORD";
                            //((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Add(checkedListBox1.Items[e.Index]);
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Înregistrarea utilizatorului a eșuat!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Parola și confirmarea parolei nu coincid!");
            }
            
        }

        private bool UtilizatorExists(string username)
        {
            // Crează conexiunea la baza de date și interogarea SQL
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


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
           
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.UseSystemPasswordChar = !string.IsNullOrEmpty(textBox.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.UseSystemPasswordChar = !string.IsNullOrEmpty(textBox.Text);
        }
    }
}
