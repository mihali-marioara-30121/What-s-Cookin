﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class MyProfile : Form
    {
        CHANGE_PASSWORD CP = new CHANGE_PASSWORD();
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        Submit_recipe sr;
        My_recipes mr = new My_recipes();

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

        private void MyProfile_Load(object sender, EventArgs e)
        {
            string alDoileaCuvant = UserContext.username;
            string username = string.Empty;
            string email = string.Empty;

            // Realizați interogarea către baza de date pentru a obține numele utilizatorului și adresa de email
            string query = "SELECT nume_utilizator, email FROM Utilizator WHERE nume_utilizator = @username";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", alDoileaCuvant); // Utilizați alDoileaCuvant ca valoare pentru parametrul de interogare

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Obțineți valorile corespunzătoare din baza de date
                    username = reader.GetString(0);
                    email = reader.GetString(1);
                }

                reader.Close();
            }

            // Actualizați valorile în label-uri
            label2.Text = username;
            label4.Text = email;

        }

        //submit a recipe
        private void button2_Click(object sender, EventArgs e)
        {
            sr = new Submit_recipe();

            sr.BringToFront();
            sr.Show();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mr == null || mr.IsDisposed)
            {
                // Forma 'mr' nu există sau a fost închisă, creăm o nouă instanță
                mr = new My_recipes();
            }

            // Aducem forma 'mr' în față și o afișăm
            mr.BringToFront();
            mr.Show();
            
        }
    }
}
