using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Login : Form
    {
        Register register = new Register();
        public Login()
        {
            InitializeComponent();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            register.TopLevel = false;
            panel_login.Controls.Add(register);
            register.BringToFront();
            register.Show();
        }
    }
}
