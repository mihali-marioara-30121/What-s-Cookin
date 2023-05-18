using System;
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
        RecipeDTO recipeDTO;
        Bookmarks bookmarks;
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;


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


        /*  private void BookmarkButton_Click(object sender, EventArgs e)
          {     
              MessageBox.Show("Recipe bookmarked!");
              if (isUser)
              {

              }
              bookmarks().Show();

          }

          private void recipeDescriptionPanel_Paint(object sender, PaintEventArgs e)
          {

          }

         

          private void bookmarkButton_Click_1(object sender, EventArgs e)
          {
              MessageBox.Show("Recipe bookmarked!");
          }

          private void descriptionLabel_Click(object sender, EventArgs e)
          {

          }
        */
        private string GetCommentsFromDatabase()
        {
            return "User1: Great recipe!\r\nUser2: I loved it!\r\nUser3: Delicious!";
        }

        private void bookmarkButton_Click(object sender, EventArgs e)
        {

            int idUser = getUserIdByUsername(UserContext.username);
            int idRetetaApi = recipeDTO.id;

            if (!(idUser > 0 && idRetetaApi > 0))
            {
                MessageBox.Show("Something went wrong trying to bookmark this recipe!");
                return;
            }

            Boolean successfullyAddedBookmark = addBookmarkToCurrentRecipe(idUser, idRetetaApi);

            if (!successfullyAddedBookmark)
            {
                MessageBox.Show("Bookmark couldn't be added!");
                return;
            }

            MessageBox.Show("Successfully added bookmark!");
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

        private int getUserIdByUsername(string username)
        {
            string query = "Select * FROM Utilizator WHERE nume_utilizator = @username";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            if (username != null)
            {
                command.Parameters.Add("@username", username);
            }

            SqlDataReader reader = command.ExecuteReader();
            

            while (reader.Read())
            {
                return reader.GetInt32(0);
            }

            return -1;
            connection.Close();
        }

        
    }
}
