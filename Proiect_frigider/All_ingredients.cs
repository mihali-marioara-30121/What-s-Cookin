using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class All_ingredients : Form
    {
        private string queryCategoriiDistincte = "SELECT DISTINCT categorie FROM ingrediente";
        private string queryIngredienteDupaCategorie = "SELECT nume FROM ingrediente WHERE categorie = @categorie";
        private CheckedListBox checkedListBox_selectedIngredients;

        public All_ingredients(CheckedListBox checkedListBox)
        {
            InitializeComponent();
            checkedListBox_selectedIngredients = checkedListBox;
            generateAllIngredientsByCategory();
        }

        private void generateAllIngredientsByCategory()
        {
            panel_all_ingredients.Controls.Clear();
            int count = 1;
            int yPos = 10; // Starting Y position for the first label
            int spacing = 25; // Vertical spacing between labels and checkbox lists

            List<string> categoriiDistinct = obtineInformatiiDinBD(queryCategoriiDistincte, null);

            foreach (string categorie in categoriiDistinct)
            {
                int xPos = 10;
                List<string> ingredienteCategorie = obtineInformatiiDinBD(queryIngredienteDupaCategorie, categorie);
                if (count % 2 == 0)
                {
                    xPos += 250;
                    yPos -= 134;
                }
                yPos = populateUI(categorie, ingredienteCategorie, xPos, yPos, spacing);
                count++;
            }
        }

        private int populateUI(string categorie, List<string> ingredienteCategorie, int xPos, int yPos, int spacing)
        {
            // Create the label for the category
            Label categoryLabel = new Label();
            categoryLabel.Text = categorie;
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(xPos, yPos + 25);

            // Create the checkbox list for the ingredients
            CheckedListBox ingredientCheckBoxList = new CheckedListBox();
            ingredientCheckBoxList.Location = new Point(xPos, yPos + categoryLabel.Height + spacing);
            ingredientCheckBoxList.Width = 200;

            // Populate the checkbox list with ingredients for the current category
            ingredientCheckBoxList.Items.AddRange(ingredienteCategorie.ToArray());

            // Add event handler to the ItemCheck event of the checkbox list
            ingredientCheckBoxList.ItemCheck += IngredientCheckBoxList_ItemCheck;

            // Add the label and checkbox list to the panel
            panel_all_ingredients.Controls.Add(categoryLabel);
            panel_all_ingredients.Controls.Add(ingredientCheckBoxList);

            // Update the Y position for the next label and checkbox list
            yPos += categoryLabel.Height + ingredientCheckBoxList.Height + spacing;

            return yPos;
        }

        private void IngredientCheckBoxList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the CheckBoxList control that triggered the event
            CheckedListBox checkBoxList = (CheckedListBox) sender;

            // Get the selected item and its state (checked or unchecked)
            string selectedItem = checkBoxList.Items[e.Index].ToString();
            bool isChecked = e.NewValue == CheckState.Checked;

            // Perform actions based on the selected item and its state
            if (isChecked)
            {
                // Item was checked
                // Do something
                checkedListBox_selectedIngredients.Items.Add(selectedItem);
            }
            else
            {
                checkedListBox_selectedIngredients.Items.Remove(selectedItem);
            }
        }

        private List<string> obtineInformatiiDinBD(string query, string numeCategorie)
        {
            List<string> listaObiecte = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            if (numeCategorie != null)
            {
                command.Parameters.Add("@categorie", numeCategorie);
            }

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) { 
                listaObiecte.Add(reader.GetString(0));
            }

            connection.Close();

            return listaObiecte;
        }

    }
}
