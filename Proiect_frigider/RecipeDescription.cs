using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class RecipeDescription : Form
    {
        private RecipeInformation recipeInformation;
        private RecipeInformationDTO recipeInformationDTO;

        public Boolean hasDescription = false;
        RecipeDTO recipeDTO;
        Bookmarks bookmarks;

    public RecipeDescription(RecipeDTO recipe)
        {
            recipeDTO = recipe;
            InitializeComponent();
            recipeInformation = RecipeInformationService.GetRecipeInformation(recipe.id);
            if (recipeInformation != null)
            {
                hasDescription = true;
                recipeInformationDTO = RecipeInformationService.extractNecessaryInformationFromCompleteRecipes(recipeInformation);
                setRecipeDetails(recipeInformationDTO.image);
            } else
            {
                hasDescription = false;
                MessageBox.Show("Informations about the " + recipe.title + " are not available!");
            }
  
            // PopulateRecipeDetails();
        }

    

        private void setRecipeDetails(string imageUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] imageData = webClient.DownloadData(imageUrl);
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(stream);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point(130, 41);
                    pictureBox.Width = 550; 
                    pictureBox.Height = 300;
                    pictureBox.Image = image;
                }
            }

            pictureBox.Show();
            titleLabel.Text = recipeInformationDTO.title;
            cookingTime_label.Text = "Cooking time: " + recipeInformationDTO.readyInMinutes.ToString() + " min";
            servings_label.Text = "Servings: " + recipeInformationDTO.servings.ToString();

            foreach(string ingredient in recipeInformationDTO.ingredientsList) { 
                ingredients_listBox.Items.Add(ingredient);
            }

            if (recipeInformationDTO.instructions != null)
            {
                descriptionLabel.Text = recipeInformationDTO.instructions.ToString();
            }
               else
            {
                descriptionLabel.Text = "No instructions available!";
            }
        }


        private void BookmarkButton_Click(object sender, EventArgs e)
        {     
           /* MessageBox.Show("Recipe bookmarked!");
            if (isUser)
            {

            }
            bookmarks().Show();
           */
        }

        private void recipeDescriptionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private string GetCommentsFromDatabase()
        {
            return "User1: Great recipe!\r\nUser2: I loved it!\r\nUser3: Delicious!";
        }

        private void bookmarkButton_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Recipe bookmarked!");
        }

        private void descriptionLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
