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
    public partial class CHANGE_PASSWORD : Form
    {
        public CHANGE_PASSWORD()
        {
            InitializeComponent();
        }

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Password updated!");
            this.Hide();
        }
    }
}
