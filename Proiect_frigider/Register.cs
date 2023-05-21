using System;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Register : Form
    {
        Login login;
        public Register(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox4.Text;

            Boolean verifyUsername = isTextBoxComplete(textBox1, "USERNAME");
            Boolean verifyEmail = isTextBoxComplete(textBox2, "EMAIL");
            Boolean verifyPassword = isTextBoxComplete(textBox3, null);
            Boolean verifyConfirmPassword = isTextBoxComplete(textBox4, null);

            if (!(verifyUsername && verifyPassword && verifyEmail && verifyConfirmPassword))
            {
                MessageBox.Show("All fields must be completed!");
                return;
            }

            if (password == confirmPassword)
            {
                if (UserService.UtilizatorExists(username))
                {
                    MessageBox.Show("Utilizatorul există deja în baza de date. Vă rugăm să alegeți un alt nume de utilizator.", "Eroare de înregistrare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isUserAddedSuccessfully = UserService.AddUser(username, password, email);

                   // Verifică dacă inserarea a avut succes
                if (isUserAddedSuccessfully)
                    {
                      FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();

                     if (form1 != null)
                     {
                        form1.helloLabel.Text = "Hello " + username + "!";
                        form1.button_login.Text = "Logout";    
                     }

                      UserContext.username = username;
                      UserContext.password = password;
                      UserContext.id = UserService.GetUserIdByName(UserContext.username); 

                    MessageBox.Show("Utilizatorul a fost înregistrat cu succes!");
                     textBox1.Text = "USERNAME";
                     textBox2.Text = "EMAIL";
                     textBox3.Text = "PASSWORD";
                     textBox4.Text = "CONFIRM PASSWORD";

                      this.Hide();
                      if (login != null)
                      {
                           login.Hide();
                      }

                }
                else
                {
                    MessageBox.Show("Înregistrarea utilizatorului a eșuat!");
                }
            }
            else
            {
                MessageBox.Show("Parola și confirmarea parolei nu coincid!");
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

        private Boolean isTextBoxComplete(TextBox textBox, string initialValue)
        {
            if(textBox.Text == null)
            {
                return false; ;
            }
            if (textBox.Text == "")
            {
                return false; ;
            }
            if (textBox.Text == initialValue)
            {
                return false; ;
            }
            return true;
        }
    }
}
