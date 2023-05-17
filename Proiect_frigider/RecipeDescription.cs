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

    public RecipeDescription(RecipeDTO recipe)
        {
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
                    pictureBox.Location = new Point(250, 39);
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
            MessageBox.Show("Recipe bookmarked!");
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



        //private void PopulateRecipeDetails()
        //{
        //    // Add comments text box
        //    TextBox commentsTextBox = new TextBox();
        //    commentsTextBox.Multiline = true;
        //    commentsTextBox.ReadOnly = true;
        //    commentsTextBox.ScrollBars = ScrollBars.Vertical;
        //    commentsTextBox.Dock = DockStyle.Bottom;
        //    commentsTextBox.Height = 150;
        //    // Populate comments from the database or any other source
        //    commentsTextBox.Text = GetCommentsFromDatabase();
        //    recipeDescriptionPanel.Controls.Add(commentsTextBox);

        //    //// Add ingredients list box
        //    //ListBox ingredientsListBox = new ListBox();
        //    //ingredientsListBox.Dock = DockStyle.Left;
        //    //ingredientsListBox.Width = 200;
        //    //ingredientsListBox.Items.Add("INGREDIENTS:");
        //    //ingredientsListBox.Items.AddRange(recipeDTO.ingredients.Split(','));
        //    //recipeDescriptionPanel.Controls.Add(ingredientsListBox);

        //    // Add "BOOKMARK IT!" button
        //    Button bookmarkButton = new Button();
        //    bookmarkButton.Text = "BOOKMARK IT!";
        //    bookmarkButton.Dock = DockStyle.Top;
        //    bookmarkButton.Height = 50;
        //    bookmarkButton.Width = 50;
        //    bookmarkButton.Click += BookmarkButton_Click;
        //    recipeDescriptionPanel.Controls.Add(bookmarkButton);

        //    // Add description label
        //    TextBox descriptionTextBox = new TextBox();
        //    descriptionTextBox.Multiline = true;
        //    descriptionTextBox.Text = recipeDTO.description;
        //    descriptionTextBox.ReadOnly = true;
        //    descriptionTextBox.BackColor = Color.White;
        //    descriptionTextBox.BorderStyle = BorderStyle.None;
        //    descriptionTextBox.Dock = DockStyle.Top;
        //    descriptionTextBox.Height = 100;
        //    recipeDescriptionPanel.Controls.Add(descriptionTextBox);

        //    // Add title label
        //    Label titleLabel = new Label();
        //    titleLabel.Text = recipeDTO.title;
        //    titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
        //    titleLabel.AutoSize = true;
        //    titleLabel.Dock = DockStyle.Top;
        //    recipeDescriptionPanel.Controls.Add(titleLabel);

        //    // Add picture box for recipe image
        //    PictureBox recipeImage = GetRecipeImage(recipeDTO.image);
        //    recipeImage.SizeMode = PictureBoxSizeMode.StretchImage;
        //    recipeImage.Dock = DockStyle.Top;
        //    recipeImage.Height = 200;
        //    recipeImage.Width = 200;
        //    recipeDescriptionPanel.Controls.Add(recipeImage);

        //    // Add "Go Back" button
        //    Button goBackButton = new Button();
        //    goBackButton.Text = "Go Back";
        //    goBackButton.Dock = DockStyle.Bottom;
        //    goBackButton.Click += GoBackButton_Click;
        //    recipeDescriptionPanel.Controls.Add(goBackButton);
        //}
    }
}
