using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Quick_ingredients : Form
    {
        //FormFirstPage form1 = new FormFirstPage();
        public Quick_ingredients()
        {
            InitializeComponent();
            //  form1.Owner = this;

        }
        // public CheckedListBox CheckedListBox1 { get { return checkedListBox1; } }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Adaugă elementul selectat la controlul checkedListBox_selectedIngredients de pe formularul Form1
                ((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Add(checkedListBox1.Items[e.Index]);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Elimină elementul deselectat din controlul checkedListBox_selectedIngredients de pe formularul Form1
                ((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Remove(checkedListBox1.Items[e.Index]);
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Adaugă elementul selectat la controlul checkedListBox_selectedIngredients de pe formularul Form1
                ((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Add(checkedListBox2.Items[e.Index]);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Elimină elementul deselectat din controlul checkedListBox_selectedIngredients de pe formularul Form1
                ((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Remove(checkedListBox2.Items[e.Index]);
            }
        }

        private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Adaugă elementul selectat la controlul checkedListBox_selectedIngredients de pe formularul Form1
                ((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Add(checkedListBox3.Items[e.Index]);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Elimină elementul deselectat din controlul checkedListBox_selectedIngredients de pe formularul Form1
                ((FormFirstPage)this.Owner).checkedListBox_selectedIngredients.Items.Remove(checkedListBox3.Items[e.Index]);
            }
        }

        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        private void Quick_ingredients_Load(object sender, EventArgs e)
        {

            // Creează o conexiune la baza de date utilizând cheia de conexiune din App.config
            SqlConnection connection = new SqlConnection(connectionString);

            // Creează interogarea SQL care selectează toate ingredientele din tabela "ingrediente" care sunt ingrediente de bază
            string query = "SELECT id, nume, categorie FROM ingrediente WHERE ingrediente_de_baza = 1 ORDER BY id ASC";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Execută interogarea SQL și obține un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Adaugă toate ingredientele de bază în checkedListBox1
            int count = 0;
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nume = reader.GetString(1);
                string categorie = reader.GetString(2);

                count++;
                if (count <= 21)
                {

                    checkedListBox1.Items.Add(nume);
                }
                else if(count>=22 && count<=42)
                {
                    checkedListBox2.Items.Add(nume);
                }
                else
                {
                    checkedListBox3.Items.Add(nume);

                }
            }

            // Închide SqlDataReader și conexiunea la baza de date și eliberează resursele
            reader.Close();
            command.Dispose();
            connection.Close();
        }  
    }
}

