using System;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class MyProfile : Form
    {
        CHANGE_PASSWORD CP = new CHANGE_PASSWORD();
        public MyProfile()
        {
            InitializeComponent();
        }

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            CP.TopLevel = false;
            panel_profile.Controls.Add(CP);
            CP.BringToFront();
            CP.Show();
        }
    }
}
