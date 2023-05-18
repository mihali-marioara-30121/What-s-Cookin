using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Login : Form
    {
        Register register= new Register();
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
       // MyProfile mp = new MyProfile();

        public Login()
        {
            InitializeComponent();
        }
       // public MyProfile mp; // Proprietate pentru a menține referința la formularul MyProfile

        // Metodă pentru a seta textul etichetei în formularul MyProfile
      /*  private void SetMyProfileLabelText(string username)
        {
            if (myProfileForm != null)
            {
                myProfileForm.label1.Text = "Hello " + username;
            }
        }
      */

        private void button_register_Click(object sender, EventArgs e)
        {
            register.TopLevel = false;
            panel_login.Controls.Add(register);
            register.BringToFront();
            register.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            TextBox textBox = (TextBox)sender;
            textBox.UseSystemPasswordChar = !string.IsNullOrEmpty(textBox.Text);

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Verifică dacă utilizatorul și parola corespund
            if (VerifyCredentials(username, password))
            {
                UserContext.username = username;
                MessageBox.Show("Autentificare reușită! Bine ați venit, " + username + "!");
                this.label1.Text = "Hello " + username;
                FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();
               // MyProfile mp = Application.OpenForms.OfType<MyProfile>().FirstOrDefault();
               
                
               //mp.label1.Text = "HELLO " + username + " !";

                if (form1 != null)
                {
                   
                    form1.label1.Text = "Hello " + textBox1.Text + " !";
                    form1.button_login.Text = "Logout";
                }
                textBox1.Text = "USERNAME";
                textBox2.Text = "PASSWORD";
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parolă incorectă. Vă rugăm să încercați din nou.", "Eroare de autentificare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerifyCredentials(string username, string password)
        {
            // Crează conexiunea la baza de date și interogarea SQL
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.UseSystemPasswordChar = !string.IsNullOrEmpty(textBox.Text);
        }
    }
}
