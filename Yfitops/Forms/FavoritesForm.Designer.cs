namespace Yfitops.Forms
{
    partial class FavoritesForm
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
            tabControlFavorites = new TabControl();
            tabArtists = new TabPage();
            dataFavArtists = new DataGridView();
            tabAlbums = new TabPage();
            dataFavAlbums = new DataGridView();
            tabTracks = new TabPage();
            dataFavTracks = new DataGridView();
            labelMyFavTitle = new Label();
            tabControlFavorites.SuspendLayout();
            tabArtists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFavArtists).BeginInit();
            tabAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFavAlbums).BeginInit();
            tabTracks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFavTracks).BeginInit();
            SuspendLayout();
            // 
            // tabControlFavorites
            // 
            tabControlFavorites.Controls.Add(tabArtists);
            tabControlFavorites.Controls.Add(tabAlbums);
            tabControlFavorites.Controls.Add(tabTracks);
            tabControlFavorites.Location = new Point(12, 69);
            tabControlFavorites.Name = "tabControlFavorites";
            tabControlFavorites.SelectedIndex = 0;
            tabControlFavorites.Size = new Size(776, 369);
            tabControlFavorites.TabIndex = 0;
            // 
            // tabArtists
            // 
            tabArtists.Controls.Add(dataFavArtists);
            tabArtists.Location = new Point(4, 24);
            tabArtists.Name = "tabArtists";
            tabArtists.Padding = new Padding(3);
            tabArtists.Size = new Size(768, 341);
            tabArtists.TabIndex = 0;
            tabArtists.Text = "Artists";
            tabArtists.UseVisualStyleBackColor = true;
            // 
            // dataFavArtists
            // 
            dataFavArtists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFavArtists.Dock = DockStyle.Fill;
            dataFavArtists.Location = new Point(3, 3);
            dataFavArtists.Name = "dataFavArtists";
            dataFavArtists.Size = new Size(762, 335);
            dataFavArtists.TabIndex = 0;
            dataFavArtists.CellContentClick += dataFavArtists_CellContentClick;
            // 
            // tabAlbums
            // 
            tabAlbums.Controls.Add(dataFavAlbums);
            tabAlbums.Location = new Point(4, 24);
            tabAlbums.Name = "tabAlbums";
            tabAlbums.Padding = new Padding(3);
            tabAlbums.Size = new Size(768, 341);
            tabAlbums.TabIndex = 1;
            tabAlbums.Text = "Albums";
            tabAlbums.UseVisualStyleBackColor = true;
            // 
            // dataFavAlbums
            // 
            dataFavAlbums.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFavAlbums.Dock = DockStyle.Fill;
            dataFavAlbums.Location = new Point(3, 3);
            dataFavAlbums.Name = "dataFavAlbums";
            dataFavAlbums.Size = new Size(762, 335);
            dataFavAlbums.TabIndex = 0;
            // 
            // tabTracks
            // 
            tabTracks.Controls.Add(dataFavTracks);
            tabTracks.Location = new Point(4, 24);
            tabTracks.Name = "tabTracks";
            tabTracks.Padding = new Padding(3);
            tabTracks.Size = new Size(768, 341);
            tabTracks.TabIndex = 2;
            tabTracks.Text = "Tracks";
            tabTracks.UseVisualStyleBackColor = true;
            // 
            // dataFavTracks
            // 
            dataFavTracks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFavTracks.Dock = DockStyle.Fill;
            dataFavTracks.Location = new Point(3, 3);
            dataFavTracks.Name = "dataFavTracks";
            dataFavTracks.Size = new Size(762, 335);
            dataFavTracks.TabIndex = 0;
            // 
            // labelMyFavTitle
            // 
            labelMyFavTitle.AutoSize = true;
            labelMyFavTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMyFavTitle.ForeColor = Color.PaleGoldenrod;
            labelMyFavTitle.Location = new Point(203, 9);
            labelMyFavTitle.Name = "labelMyFavTitle";
            labelMyFavTitle.Size = new Size(425, 65);
            labelMyFavTitle.TabIndex = 1;
            labelMyFavTitle.Text = "★ My Favorites ★";
            // 
            // FavoritesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(labelMyFavTitle);
            Controls.Add(tabControlFavorites);
            Name = "FavoritesForm";
            Text = "FavoritesForm";
            Load += FavoritesForm_Load;
            tabControlFavorites.ResumeLayout(false);
            tabArtists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataFavArtists).EndInit();
            tabAlbums.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataFavAlbums).EndInit();
            tabTracks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataFavTracks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControlFavorites;
        private TabPage tabArtists;
        private TabPage tabAlbums;
        private TabPage tabTracks;
        private DataGridView dataFavArtists;
        private DataGridView dataFavAlbums;
        private DataGridView dataFavTracks;
        private Label labelMyFavTitle;
    }
}