using System;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //trebuie sa pun cod de verificare daca a introdus corect
            MessageBox.Show("Register successful!");
            this.Hide();
        }
    }
}
