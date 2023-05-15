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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.bookmarkIt_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ingredients_listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(351, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(567, 240);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1264, 1);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 641);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(563, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "tilte_label";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(570, 400);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(110, 16);
            this.description_label.TabIndex = 5;
            this.description_label.Text = "description_label";
            // 
            // bookmarkIt_button
            // 
            this.bookmarkIt_button.Location = new System.Drawing.Point(538, 563);
            this.bookmarkIt_button.Name = "bookmarkIt_button";
            this.bookmarkIt_button.Size = new System.Drawing.Size(169, 67);
            this.bookmarkIt_button.TabIndex = 6;
            this.bookmarkIt_button.Text = "BOOKMARK IT!";
            this.bookmarkIt_button.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "ingredients:";
            // 
            // ingredients_listBox
            // 
            this.ingredients_listBox.FormattingEnabled = true;
            this.ingredients_listBox.ItemHeight = 16;
            this.ingredients_listBox.Location = new System.Drawing.Point(62, 303);
            this.ingredients_listBox.Name = "ingredients_listBox";
            this.ingredients_listBox.Size = new System.Drawing.Size(128, 260);
            this.ingredients_listBox.TabIndex = 8;
            // 
            // RecipeDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1285, 642);
            this.Controls.Add(this.ingredients_listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bookmarkIt_button);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipeDescription";
            this.Text = "RecipeDescription";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.Button bookmarkIt_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ingredients_listBox;
    }
}