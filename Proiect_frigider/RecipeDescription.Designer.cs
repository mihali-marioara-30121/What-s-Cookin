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
            this.recipeDescriptionPanel.AutoScrollMinSize = new System.Drawing.Size(0, 683);
            this.recipeDescriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.recipeDescriptionPanel.Controls.Add(this.bookmarkButton);
            this.recipeDescriptionPanel.Controls.Add(this.titleLabel);
            this.recipeDescriptionPanel.Controls.Add(this.descriptionLabel);
            this.recipeDescriptionPanel.Controls.Add(this.pictureBox);
            this.recipeDescriptionPanel.Location = new System.Drawing.Point(41, 52);
            this.recipeDescriptionPanel.Name = "recipeDescriptionPanel";
            this.recipeDescriptionPanel.Size = new System.Drawing.Size(1333, 683);
            this.recipeDescriptionPanel.TabIndex = 0;
            this.recipeDescriptionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.recipeDescriptionPanel_Paint);
            // 
            // bookmarkButton
            // 
            this.bookmarkButton.Location = new System.Drawing.Point(538, 738);
            this.bookmarkButton.Name = "bookmarkButton";
            this.bookmarkButton.Size = new System.Drawing.Size(138, 56);
            this.bookmarkButton.TabIndex = 3;
            this.bookmarkButton.Text = "BOOKMARK IT!";
            this.bookmarkButton.UseVisualStyleBackColor = true;
            this.bookmarkButton.Click += new System.EventHandler(this.bookmarkButton_Click_1);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(530, 441);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(179, 46);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "titleLabel";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.Color.White;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(443, 515);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(266, 39);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "descriptionLabel";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(319, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(627, 399);
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
    }
}