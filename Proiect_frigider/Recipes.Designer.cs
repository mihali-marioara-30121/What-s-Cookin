namespace Proiect_frigider
{
    partial class Recipes
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
            this.recipesPanel = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipesPanel
            // 
            this.recipesPanel.AutoScroll = true;
            this.recipesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.recipesPanel.Location = new System.Drawing.Point(55, 106);
            this.recipesPanel.Name = "recipesPanel";
            this.recipesPanel.Size = new System.Drawing.Size(1285, 579);
            this.recipesPanel.TabIndex = 1;
            this.recipesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel.Controls.Add(this.textBox1);
            this.panel.Location = new System.Drawing.Point(55, 30);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1284, 77);
            this.panel.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(75, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1094, 34);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "RECIPE RESULTS";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Recipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1416, 726);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.recipesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Recipes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Recipes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel recipesPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel;
    }
}