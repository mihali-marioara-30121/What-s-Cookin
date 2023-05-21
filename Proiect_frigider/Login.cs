using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Login : Form
    {
        Register register;
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
       // MyProfile mp = new MyProfile();

        public Login()
        {
            InitializeComponent();
            register = new Register(this);
        }
    
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
            //string username = "mari";
            //string password = "parola";

            // Verifică dacă utilizatorul și parola corespund
            if (UserService.VerifyCredentials(username, password))
            {
                UserContext.username = username;
                UserContext.password = password;
                UserContext.id = UserService.GetUserIdByName(UserContext.username);

                MessageBox.Show("Autentificare reușită! Bine ați venit, " + username + "!");
                this.label1.Text = "Hello " + username;
                FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();
            

                if (form1 != null)
                {
                   
                    form1.helloLabel.Text = "Hello " + username + "!";                  
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.UseSystemPasswordChar = !string.IsNullOrEmpty(textBox.Text);
        }
    }
}
