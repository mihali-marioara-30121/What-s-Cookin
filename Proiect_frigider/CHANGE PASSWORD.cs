using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class CHANGE_PASSWORD : Form
    {
        public CHANGE_PASSWORD()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();

            //string labelText = form1.label1.Text;
            //string[] words = labelText.Split(' ');
            //string alDoileaCuvant = words[1];
            string alDoileaCuvant = UserContext.username;
            string newPassword = textBox1.Text;
            string confirmPassword = textBox2.Text;

          

            if (newPassword == confirmPassword)
            {
                if (newPassword.Equals(UserContext.password))
                {
                    MessageBox.Show("The new password cannot be the same as the old one!");
                    return;
                }
                // Actualizați parola în baza de date
                string query = "UPDATE Utilizator SET parola = @newPassword WHERE nume_utilizator = @username";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    command.Parameters.AddWithValue("@username", alDoileaCuvant); // Utilizați alDoileaCuvant ca valoare pentru parametrul de interogare

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Parola a fost actualizată cu succes!");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Parolele nu coincid!");
            }
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
