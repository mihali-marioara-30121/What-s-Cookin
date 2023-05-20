using System.Drawing;
using System.Windows.Forms;

namespace Proiect_frigider
{
    partial class RecipeDescription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recipeDescriptionPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ingredients_listBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.servings_label = new System.Windows.Forms.Label();
            this.cookingTime_label = new System.Windows.Forms.Label();
            this.bookmarkButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.recipeDescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // recipeDescriptionPanel
            // 
            this.recipeDescriptionPanel.AutoScroll = true;
            this.recipeDescriptionPanel.AutoScrollMargin = new System.Drawing.Size(0, 700);
            this.recipeDescriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.recipeDescriptionPanel.Controls.Add(this.label1);
            this.recipeDescriptionPanel.Controls.Add(this.ingredients_listBox);
            this.recipeDescriptionPanel.Controls.Add(this.label4);
            this.recipeDescriptionPanel.Controls.Add(this.servings_label);
            this.recipeDescriptionPanel.Controls.Add(this.cookingTime_label);
            this.recipeDescriptionPanel.Controls.Add(this.bookmarkButton);
            this.recipeDescriptionPanel.Controls.Add(this.titleLabel);
            this.recipeDescriptionPanel.Controls.Add(this.descriptionLabel);
            this.recipeDescriptionPanel.Controls.Add(this.pictureBox);
            this.recipeDescriptionPanel.Location = new System.Drawing.Point(282, 52);
            this.recipeDescriptionPanel.Name = "recipeDescriptionPanel";
            this.recipeDescriptionPanel.Size = new System.Drawing.Size(918, 683);
            this.recipeDescriptionPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 1026);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Instructions:";
            // 
            // ingredients_listBox
            // 
            this.ingredients_listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ingredients_listBox.ColumnWidth = 100;
            this.ingredients_listBox.FormattingEnabled = true;
            this.ingredients_listBox.ItemHeight = 16;
            this.ingredients_listBox.Location = new System.Drawing.Point(31, 712);
            this.ingredients_listBox.Name = "ingredients_listBox";
            this.ingredients_listBox.Size = new System.Drawing.Size(843, 288);
            this.ingredients_listBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 671);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingredients:";
            // 
            // servings_label
            // 
            this.servings_label.AutoSize = true;
            this.servings_label.Font = new System.Drawing.Font("MV Boli", 12F);
            this.servings_label.Location = new System.Drawing.Point(368, 636);
            this.servings_label.Name = "servings_label";
            this.servings_label.Size = new System.Drawing.Size(132, 26);
            this.servings_label.TabIndex = 6;
            this.servings_label.Text = "servings_label";
            // 
            // cookingTime_label
            // 
            this.cookingTime_label.AutoSize = true;
            this.cookingTime_label.Font = new System.Drawing.Font("MV Boli", 12F);
            this.cookingTime_label.Location = new System.Drawing.Point(346, 596);
            this.cookingTime_label.Name = "cookingTime_label";
            this.cookingTime_label.Size = new System.Drawing.Size(173, 26);
            this.cookingTime_label.TabIndex = 5;
            this.cookingTime_label.Text = "cookingTime_label";
            // 
            // bookmarkButton
            // 
            this.bookmarkButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bookmarkButton.Font = new System.Drawing.Font("MV Boli", 12F);
            this.bookmarkButton.Location = new System.Drawing.Point(342, 543);
            this.bookmarkButton.Name = "bookmarkButton";
            this.bookmarkButton.Size = new System.Drawing.Size(186, 50);
            this.bookmarkButton.TabIndex = 3;
            this.bookmarkButton.Text = "BOOKMARK IT!";
            this.bookmarkButton.UseVisualStyleBackColor = true;
            this.bookmarkButton.Click += new System.EventHandler(this.bookmarkButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(90, 419);
            this.titleLabel.MaximumSize = new System.Drawing.Size(731, 100);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(731, 46);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "titleLabel";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.Color.White;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(38, 1065);
            this.descriptionLabel.MaximumSize = new System.Drawing.Size(800, 666666);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(192, 29);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "descriptionLabel";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(183, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(564, 377);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // RecipeDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1442, 768);
            this.Controls.Add(this.recipeDescriptionPanel);
            this.Name = "RecipeDescription";
            this.Text = "RecipeDescription";
            this.recipeDescriptionPanel.ResumeLayout(false);
            this.recipeDescriptionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel recipeDescriptionPanel;
        private Button bookmarkButton;
        private Label titleLabel;
        private Label descriptionLabel;
        private PictureBox pictureBox;
        private ListBox ingredients_listBox;
        private Label label4;
        private Label servings_label;
        private Label cookingTime_label;
        private Label label1;
    }
}