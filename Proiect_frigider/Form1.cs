using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class FormFirstPage : Form
    {
        // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        MyProfile mp = new MyProfile();
        Quick_ingredients quick_i = new Quick_ingredients();
        All_ingredients all_i; 
        Bookmarks bookmarks = new Bookmarks();
        Login login = new Login();
        Tips tips = new Tips();
        Recipes recipesForm;
        RecipeDescription recipeDescription;
       // Register register = new Register();
        public FormFirstPage()
        {
            InitializeComponent();
            all_i = new All_ingredients(checkedListBox_selectedIngredients);
           // recipeDescription.Show();
            
        }

        /*  private void textBox_Search_KeyPress(object sender, KeyPressEventArgs e)
          {

          }
        */

        private void FormFirstPage_Load(object sender, EventArgs e)
        {
           // MyProfile mp = new MyProfile();

            quick_i.Owner = this;
            //register.Owner = this;
            quick_i.TopLevel = false;
            panel_ingredients.Controls.Add(quick_i);
            quick_i.BringToFront();
            quick_i.Show();

        }

        private void button_ingredients_Click(object sender, EventArgs e)
        {
           
            quick_i.TopLevel = false;
            panel_ingredients.Controls.Add(quick_i);

            
            all_i.TopLevel = false;
            panel_ingredients.Controls.Add(all_i);

            if (button_ingredients.Text == "CLICK HERE FOR MORE INGREDIENTS")
            {
                all_i.BringToFront();
                all_i.Show();
                button_ingredients.Text = "LESS INGREDIENTS";
                label_kitchen.Text = "DETAILED KITCHEN";
            }
            else
            {

                quick_i.BringToFront();
                quick_i.Show();
                button_ingredients.Text = "CLICK HERE FOR MORE INGREDIENTS";
                label_kitchen.Text = "QUICK KITCHEN";
            }

            // asta ii daca faceam fara forma noua
            /*  if (button_ingredients.Text == "CLICK HERE FOR MORE INGREDIENTS")
              {
                  panel_all.Show();
                  button_ingredients.Text = "LESS INGREDIENTS";
                  label_kitchen.Text = "DETAILED KITCHEN";
              }
              else
              {
                  panel_all.Hide();
                  panel_ingredients.Show();
                  panel_ingredients.BringToFront();
                  button_ingredients.Text = "CLICK HERE FOR MORE INGREDIENTS";
                  label_kitchen.Text = "QUICK KITCHEN";
              }
            */
        }
        private void button_MyProfile_Click(object sender, EventArgs e)
        {
            // mp = new MyProfile();
         
            if (label1.Text == "")
            {
                login.TopLevel = false;
                panel_main.Controls.Add(login);
                login.BringToFront();
                login.Show();
            }
            else
            {
                mp.label1.Text =this.label1.Text;
                mp.TopLevel = false;
                panel_main.Controls.Add(mp);
                mp.BringToFront();
                mp.Show();

             
            }
        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            mp.Hide();
            bookmarks.Hide();
            login.Hide();
            tips.Hide();
            recipesForm.Hide();
            //panel_main.BringToFront();
           // panel_main.Show();
           // recipeDescription.Hide();

          /*  if(recipesForm.ShowDialog() == DialogResult.OK) 
            { 
                recipesForm.Hide();
            }
          */
           
            //recipeDescription.Hide();
            // panel_main.BringToFront();
             panel_main.Show();
        }

        private void button_bookmarks_Click(object sender, EventArgs e)
        {

           
            if (label1.Text == "")
            {
                login.TopLevel = false;
                panel_main.Controls.Add(login);
                login.BringToFront();
                login.Show();
            }
            else
            {
                bookmarks.TopLevel = false;
                panel_main.Controls.Add(bookmarks);
                bookmarks.BringToFront();
                bookmarks.Show();
            }

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            login.TopLevel = false;
            panel_main.Controls.Add(login);
            login.BringToFront();
            login.Show();

            if(button_login.Text == "Logout")
            {
                this.label1.Text = "";
                Login login = Application.OpenForms.OfType<Login>().FirstOrDefault();
                login.label1.Text = "LOGIN";
                button_login.Text = "Login";
                login.textBox1.Text = "USERNAME";
                login.textBox2.Text = "PASSWORD";
            }
        }

        private void button_tips_Click(object sender, EventArgs e)
        {
            tips.TopLevel = false;
            panel_main.Controls.Add(tips);
            tips.BringToFront();
            tips.Show();
        }

        
        private void button_CS_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox_selectedIngredients.CheckedItems.Count - 1; i >= 0; i--)
            {
                object item = checkedListBox_selectedIngredients.CheckedItems[i];
                checkedListBox_selectedIngredients.Items.Remove(item);

                if (quick_i != null)
                {
                    int index1 = quick_i.checkedListBox1.Items.IndexOf(item);
                    int index2 = quick_i.checkedListBox2.Items.IndexOf(item);
                    int index3 = quick_i.checkedListBox3.Items.IndexOf(item);


                    if (index1 >= 0)
                    {
                        quick_i.checkedListBox1.SetItemChecked(index1, false);
                    }
                    if (index2 >= 0)
                    {
                        quick_i.checkedListBox2.SetItemChecked(index2, false);
                    }
                    if (index3 >= 0)
                    {
                        quick_i.checkedListBox3.SetItemChecked(index3, false);
                    }
                }
            }
        }


        private void button_CA_Click(object sender, EventArgs e)
        {
            checkedListBox_selectedIngredients.Items.Clear();

            // Deselectam toate elementele din checkedListBox1
            foreach (var item in quick_i.checkedListBox1.CheckedItems.OfType<object>().ToList())
            {
                quick_i.checkedListBox1.SetItemChecked(quick_i.checkedListBox1.Items.IndexOf(item), false);
            }

            // Deselectam toate elementele din checkedListBox2
            foreach (var item in quick_i.checkedListBox2.CheckedItems.OfType<object>().ToList())
            {
                quick_i.checkedListBox2.SetItemChecked(quick_i.checkedListBox2.Items.IndexOf(item), false);
            }
            foreach (var item in quick_i.checkedListBox3.CheckedItems.OfType<object>().ToList())
            {
                quick_i.checkedListBox3.SetItemChecked(quick_i.checkedListBox3.Items.IndexOf(item), false);
            }
        }

        private void findRecipeButton_Click_1(object sender, EventArgs e)
        {
            string ingredientList = "";

            for (int i = 0; i < checkedListBox_selectedIngredients.Items.Count; i++)
            {       
                    string ingredient = checkedListBox_selectedIngredients.Items[i].ToString();
                    ingredientList += ingredient + ",";
            }
            if (checkedListBox_selectedIngredients.Items.Count == 0)
            {
                MessageBox.Show("Select ingredients!");
            }
            else
            {
                ingredientList.Substring(0, ingredientList.Length - 1);
                List<Recipe> recipes = RecipeService.findRecipesByIngredients(ingredientList, 20);
                //foreach (Recipe recipe in recipes)
                //{
                //   var recipeInformations = RecipeInformationService.GetRecipeInformation(recipe.id);
                //   RecipeInformationDTO recipeInformationDTO = RecipeInformationService.extractNecessaryInformationFromCompleteRecipes(recipeInformations);

                //}

               
                recipesForm = new Recipes(panel_main, recipes);

                recipesForm.TopLevel = false;
                panel_main.Controls.Add(recipesForm);
                recipesForm.BringToFront();
                recipesForm.Show();
            }
        }
    }
}
