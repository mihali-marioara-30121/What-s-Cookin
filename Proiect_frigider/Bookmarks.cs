using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Bookmarks : Form
    {
        int userId;
        RecipeDescription recipeDescription;
        public Bookmarks(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            generateAllRecipes();
        }
        public void UpdateBookmarksPanel()
        {
            bookmarksPanel.Controls.Clear();
            generateAllRecipes();
        }

        private void generateAllRecipes()
        {
            bookmarksPanel.Controls.Clear();
            int count = 0;
            int yPos = 50; // Starting Y position for the first label
            int spacing = 25; // Vertical spacing between labels and checkbox lists
            int xPos = 50;

            List<Bookmark> bookmarksList = BookmarkService.GetBookmarksByUserId(userId);
            List<RecipeInformation> recipeInformationList = new List<RecipeInformation>();

            foreach(Bookmark bookmark in bookmarksList)
            {
                RecipeInformation recipeInformation 
                    = RecipeInformationService.GetRecipeInformation(bookmark.id_reteta_api);
                recipeInformationList.Add(recipeInformation);
            }

            List<RecipeInformationDTO> recipeInformationDTOList = new List<RecipeInformationDTO>();


            foreach (RecipeInformation recipeInformation in recipeInformationList)
            {
                RecipeInformationDTO recipeInformationDTO
                    = RecipeInformationService.extractNecessaryInformationFromCompleteRecipes(recipeInformation);
                recipeInformationDTOList.Add(recipeInformationDTO);
            }


            foreach (RecipeInformationDTO recipeInformationDTO in recipeInformationDTOList)
            {
                populateUI(recipeInformationDTO, xPos, yPos, spacing);
                count++;

                if (count % 3 != 0)
                {
                    xPos += 250;
                }
                else
                {
                    xPos = 50;
                    yPos += 150;
                }
            }
        }

        private void populateUI(RecipeInformationDTO recipeInformationDTO, int xPos, int yPos, int spacing)
        {

            if (recipeInformationDTO == null)
            {
                MessageBox.Show("Error!");
                return;
            }
            // Add image on the top
            PictureBox recipeImage = getRecipeImage(recipeInformationDTO.image, xPos, yPos);

            // Create the label for the recipe
            Label recipeTitle = new Label();
            recipeTitle.Text = recipeInformationDTO.title;
            recipeTitle.Font = new Font(recipeTitle.Font, FontStyle.Bold);
            recipeTitle.AutoSize = false;
            recipeTitle.Size = new Size(200, 30);
            recipeTitle.Location = new Point(xPos - 40, yPos + 110);

            bookmarksPanel.Controls.Add(recipeImage);
            bookmarksPanel.Controls.Add(recipeTitle);

            //on click event

            recipeImage.Click += (sender, e) =>
            {
                // Open the ItemDetailsForm and pass the corresponding data
                recipeDescription = new RecipeDescription(null, recipeInformationDTO, this);
                if (recipeDescription.hasDescription)
                {
                    recipeDescription.Show();

                }
            };
        }

        private PictureBox getRecipeImage(string imageUrl, int xPos, int yPos)
        {
            // Create a PictureBox control
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(xPos, yPos);
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
