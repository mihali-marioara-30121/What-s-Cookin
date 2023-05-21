using System;
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

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            FormFirstPage form1 = Application.OpenForms.OfType<FormFirstPage>().FirstOrDefault();

            string username= UserContext.username;
            string newPassword = textBox1.Text;
            string confirmPassword = textBox2.Text;

            if (newPassword == confirmPassword)
            {
                if (newPassword.Equals(UserContext.password))
                {
                    MessageBox.Show("The new password cannot be the same as the old one!");
                    return;
                }
            
                bool isPasswordUpdatedSuccessfully = UserService.ChangePassword(username, newPassword);
                if (!isPasswordUpdatedSuccessfully)
                {
                    MessageBox.Show("Something went wrong. Try again!");
                    return;
                }
                MessageBox.Show("Password successfully updated!");
                UserContext.password = newPassword;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
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
