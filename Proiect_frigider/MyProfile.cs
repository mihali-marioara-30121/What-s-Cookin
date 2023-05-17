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

       // public string Username { get; set; }


        private void button_changePassword_Click(object sender, EventArgs e)
        {
            CP.TopLevel = false;
            panel_profile.Controls.Add(CP);
            CP.BringToFront();
            CP.Show();
        }

       /* private void MyProfile_Load(object sender, EventArgs e)
        {
            label1.Text = "Hello " + Username;

        }
       */
    }
}
