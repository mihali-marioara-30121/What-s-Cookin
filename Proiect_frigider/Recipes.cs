using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Recipes : Form
    {
        FormFirstPage formFirstPage;
        private List<Recipe> recipes;
        Boolean missedIngredientsRowsGrew = false;
        RecipeDescription recipeDescription;
        Panel panel_main;
        public Recipes(Panel panel_main, List<Recipe> recipeList)
        {
             this.panel_main = panel_main;
            recipes = recipeList;
            InitializeComponent();
            generateAllRecipes();
        }
    
    private void generateAllRecipes()
    {
        recipesPanel.Controls.Clear();
        int count = 0;
        int yPos = 50; // Starting Y position for the first label
        int spacing = 25; // Vertical spacing between labels and checkbox lists
        int xPos = 10;
        
        List<RecipeDTO> recipeDTOs = RecipeService.extractNecessaryInformationFromCompleteRecipes(recipes);

        foreach (RecipeDTO recipeDTO in recipeDTOs)
        {
            populateUI(recipeDTO, xPos, yPos, spacing);
            count++;
            
            if (count % 3 != 0)
            {
                xPos += 350;
            } else
            {
                xPos = 10;
                yPos += 230;
            }
        }
    }

    private void populateUI(RecipeDTO recipeDTOs, int xPos, int yPos, int spacing)
    {

            if (recipeDTOs == null)
            {
                MessageBox.Show("Error!");
                return;
            }
            // Add image on the top
            PictureBox recipeImage = getRecipeImage(recipeDTOs.image, xPos, yPos);
        int maxWidth = 300;

        // Create the label for the recipe
        Label recipeTitle = new Label();
        recipeTitle.Text = recipeDTOs.title;
        recipeTitle.Font = new Font(recipeTitle.Font, FontStyle.Bold);
        recipeTitle.AutoSize = false;
        recipeTitle.Location = new Point(xPos, yPos + 125);

        // Create the missedIngredients section
        Label missedIngredients = new Label();
        missedIngredients.Text = "Missed ingredients: " + recipeDTOs.missedIngredients;
        missedIngredients.AutoSize = false;
        missedIngredients = resizedLabel(missedIngredients, maxWidth);  
        missedIngredients.Location = new Point(xPos, yPos + 145);

         // Create the missedIngredients section
        Label unusedIngredients = new Label();
        unusedIngredients.Text = "Unused ingredients: " + recipeDTOs.unusedIngredients;
        unusedIngredients.AutoSize = false;
        unusedIngredients.Location = new Point(xPos, yPos + 175);
         
         unusedIngredients = resizedLabel(unusedIngredients, maxWidth);
            
         missedIngredientsRowsGrew = false;
         recipesPanel.Controls.Add(recipeImage);
         recipesPanel.Controls.Add(recipeTitle);
         recipesPanel.Controls.Add(missedIngredients);
         recipesPanel.Controls.Add(unusedIngredients);

            //on click event

            recipeImage.Click += (sender, e) =>
            {
                // Open the ItemDetailsForm and pass the corresponding data
                recipeDescription = new RecipeDescription(recipeDTOs);
                //recipesPanel.Hide();
                //recipeDescription.TopLevel = false;
                //panel_main.Controls.Add(recipeDescription);
                //recipeDescription.BringToFront();
                //recipeDescription.Show();

                recipeDescription.Show();
            };
        }

        private Label resizedLabel(Label label, int maxWidth)
        {
            Size textSize = TextRenderer.MeasureText(label.Text, label.Font);

            // Check if the text exceeds the maximum width
            if (textSize.Width > maxWidth)
            {
                // Calculate the number of lines required
                int lines = (int)Math.Ceiling((double)textSize.Width / maxWidth);

                // Set the label size to wrap the text
                label.Size = new Size(maxWidth, label.Font.Height * lines);
            }
            else
            {
                // Set the label size to fit the text
                label.Size = textSize;
            }
            return label;
        }

        private PictureBox getRecipeImage(string imageUrl, int xPos, int yPos)
        {
            // Create a PictureBox control
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(xPos,yPos);
            pictureBox.Width = 100; // Set the desired width
            pictureBox.Height = 100; // Set the desired height

            // Download the image from the URL
            using (var webClient = new WebClient())
            {
                byte[] imageData = webClient.DownloadData(imageUrl);

                // Create a memory stream from the downloaded image data
                using (var stream = new MemoryStream(imageData))
                {
                    // Set the image of the PictureBox control
                    pictureBox.Image = Image.FromStream(stream);
                }
            }
            // Add the PictureBox control to your form
            return pictureBox;
        }
    }
}
