using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        private Boolean isBookmark = false;
        private RecipeDTO recipeDTO;
        private Bookmarks bookmarks;
       
        
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;


        public RecipeDescription(RecipeDTO recipe, RecipeInformationDTO bookmarkRecipe, Bookmarks bookmarks)
        {    
            InitializeComponent();
            this.bookmarks = bookmarks;

            if (bookmarkRecipe == null)
            {
                recipeDTO = recipe;
                recipeInformation = RecipeInformationService.GetRecipeInformation(recipe.id);

                if (recipeInformation != null)
                {
                    hasDescription = true;
                    recipeInformationDTO = RecipeInformationService.extractNecessaryInformationFromCompleteRecipes(recipeInformation);
                    setRecipeDetails(recipeInformationDTO.image);
                }
                else
                {
                    hasDescription = false;
                    MessageBox.Show("Informations about the " + recipe.title + " are not available!");
                }
            }
            else if (recipe == null)
            {  
                isBookmark = true;
                bookmarkButton.Text = "DELETE BOOKMARK!";
                hasDescription = true;
                recipeInformationDTO = bookmarkRecipe;
                setRecipeDetails(recipeInformationDTO.image);
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
                    pictureBox.Location = new Point(90, 41);
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

        private void bookmarkButton_Click(object sender, EventArgs e)
       {
            if (isBookmark)
            {
                isBookmark = false;

                Boolean succsesfullyDeletedBookmark = BookmarkService.deleteBookmark(UserContext.id, recipeInformationDTO.id);
                
                    if (!succsesfullyDeletedBookmark)
                    {
                        MessageBox.Show("Bookmark couldn't be deleted!");
                        return;
                    }

                MessageBox.Show("Bookmark deleted successfully!");

                bookmarkButton.Text = "BOOKMARK IT!";

                if (bookmarks != null)
                {
                    bookmarks.UpdateBookmarksPanel();
                }

                return;
            }
            
            if (UserContext.username == null)
            { 
                MessageBox.Show("You must log in to add bookmarks!!");
                return;
            }

            string currentUsername = UserContext.username;
            int idUser = UserContext.id;
            int idRetetaApi = recipeDTO.id;

            if (!(idRetetaApi > 0))
            {
                MessageBox.Show("Something went wrong trying to bookmark this recipe!");
                return;
            }

            List<Bookmark> bookmarksList = BookmarkService.GetBookmarksByUserId(idUser);

            foreach(Bookmark bookmark in bookmarksList)
            {
                if (bookmark.id_reteta_api == idRetetaApi)
                {
                    MessageBox.Show("Recipe already added to bookmarks!");
                    return;
                }
            }
           
            Boolean successfullyAddedBookmark = addBookmarkToCurrentRecipe(idUser, idRetetaApi);

            if (!successfullyAddedBookmark)
            {
                MessageBox.Show("Bookmark couldn't be added!");
                return;
            }

            MessageBox.Show("Successfully added bookmark!");
            bookmarkButton.Text = "BOOKMARKED!";
        }

        private bool addBookmarkToCurrentRecipe(int idUser, int idRetetaApi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO retete_preferate (id_user, id_reteta_api) VALUES (@idUser, @idRetetaApi)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUser", idUser);
                    command.Parameters.AddWithValue("@idRetetaApi", idRetetaApi);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }
    }
}
