namespace Yfitops
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            labelWelcome = new Label();
            labelUsername = new Label();
            buttonLogout = new Button();
            dataTracks = new DataGridView();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            albumDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            trackBindingSource = new BindingSource(components);
            dataAlbums = new DataGridView();
            titleDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            albumBindingSource = new BindingSource(components);
            buttonAddTrack = new Button();
            buttonAddAlbum = new Button();
            buttonAllTracks = new Button();
            labelRole = new Label();
            buttonMyFav = new Button();
            buttonStop = new Button();
            panelFavorites = new Panel();
            buttonFavClose = new Button();
            labelMyFavTitle = new Label();
            tabControl1 = new TabControl();
            tabFavArtists = new TabPage();
            dataFavArtists = new DataGridView();
            tabFavAlbums = new TabPage();
            dataFavAlbums = new DataGridView();
            tabFavTracks = new TabPage();
            dataFavTracks = new DataGridView();
            buttonFavStop = new Button();
            ((System.ComponentModel.ISupportInitialize)dataTracks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataAlbums).BeginInit();
            ((System.ComponentModel.ISupportInitialize)albumBindingSource).BeginInit();
            panelFavorites.SuspendLayout();
            tabControl1.SuspendLayout();
            tabFavArtists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFavArtists).BeginInit();
            tabFavAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFavAlbums).BeginInit();
            tabFavTracks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFavTracks).BeginInit();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWelcome.Location = new Point(12, 9);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(69, 17);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome:";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(87, 11);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(60, 15);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Username";
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.LightCoral;
            buttonLogout.FlatStyle = FlatStyle.Popup;
            buttonLogout.Location = new Point(1043, 11);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(75, 23);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // dataTracks
            // 
            dataTracks.AutoGenerateColumns = false;
            dataTracks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTracks.Columns.AddRange(new DataGridViewColumn[] { titleDataGridViewTextBoxColumn, albumDataGridViewTextBoxColumn });
            dataTracks.DataSource = trackBindingSource;
            dataTracks.Location = new Point(501, 79);
            dataTracks.Name = "dataTracks";
            dataTracks.Size = new Size(617, 328);
            dataTracks.TabIndex = 3;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // albumDataGridViewTextBoxColumn
            // 
            albumDataGridViewTextBoxColumn.DataPropertyName = "Album";
            albumDataGridViewTextBoxColumn.HeaderText = "Album";
            albumDataGridViewTextBoxColumn.Name = "albumDataGridViewTextBoxColumn";
            // 
            // trackBindingSource
            // 
            trackBindingSource.DataSource = typeof(Models.Entities.Track);
            // 
            // dataAlbums
            // 
            dataAlbums.AutoGenerateColumns = false;
            dataAlbums.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAlbums.Columns.AddRange(new DataGridViewColumn[] { titleDataGridViewTextBoxColumn1 });
            dataAlbums.DataSource = albumBindingSource;
            dataAlbums.Location = new Point(12, 79);
            dataAlbums.Name = "dataAlbums";
            dataAlbums.Size = new Size(483, 328);
            dataAlbums.TabIndex = 4;
            dataAlbums.CellContentClick += dataAlbums_CellContentClick;
            // 
            // titleDataGridViewTextBoxColumn1
            // 
            titleDataGridViewTextBoxColumn1.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn1.HeaderText = "Title";
            titleDataGridViewTextBoxColumn1.Name = "titleDataGridViewTextBoxColumn1";
            // 
            // albumBindingSource
            // 
            albumBindingSource.DataSource = typeof(Models.Entities.Album);
            // 
            // buttonAddTrack
            // 
            buttonAddTrack.BackColor = Color.SpringGreen;
            buttonAddTrack.Location = new Point(851, 12);
            buttonAddTrack.Name = "buttonAddTrack";
            buttonAddTrack.Size = new Size(162, 23);
            buttonAddTrack.TabIndex = 5;
            buttonAddTrack.Text = "Add track";
            buttonAddTrack.UseVisualStyleBackColor = false;
            buttonAddTrack.Click += buttonAddTrack_Click;
            // 
            // buttonAddAlbum
            // 
            buttonAddAlbum.BackColor = Color.LightGreen;
            buttonAddAlbum.Location = new Point(660, 12);
            buttonAddAlbum.Name = "buttonAddAlbum";
            buttonAddAlbum.Size = new Size(175, 23);
            buttonAddAlbum.TabIndex = 6;
            buttonAddAlbum.Text = "Add Album";
            buttonAddAlbum.UseVisualStyleBackColor = false;
            buttonAddAlbum.Click += buttonAddAlbum_Click_1;
            // 
            // buttonAllTracks
            // 
            buttonAllTracks.Location = new Point(1022, 413);
            buttonAllTracks.Name = "buttonAllTracks";
            buttonAllTracks.Size = new Size(96, 23);
            buttonAllTracks.TabIndex = 7;
            buttonAllTracks.Text = "All tracks";
            buttonAllTracks.UseVisualStyleBackColor = true;
            buttonAllTracks.Click += buttonAllTracks_Click;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.ForeColor = Color.Fuchsia;
            labelRole.Location = new Point(87, 35);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(38, 15);
            labelRole.TabIndex = 8;
            labelRole.Text = "label1";
            // 
            // buttonMyFav
            // 
            buttonMyFav.BackColor = Color.PaleGoldenrod;
            buttonMyFav.Location = new Point(913, 413);
            buttonMyFav.Name = "buttonMyFav";
            buttonMyFav.Size = new Size(100, 23);
            buttonMyFav.TabIndex = 9;
            buttonMyFav.Text = "My Favorites";
            buttonMyFav.UseVisualStyleBackColor = false;
            buttonMyFav.Click += buttonMyFav_Click;
            // 
            // buttonStop
            // 
            buttonStop.BackColor = Color.Firebrick;
            buttonStop.Location = new Point(1043, 474);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 10;
            buttonStop.Text = "STOP";
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // panelFavorites
            // 
            panelFavorites.BackColor = SystemColors.Desktop;
            panelFavorites.Controls.Add(buttonFavStop);
            panelFavorites.Controls.Add(buttonFavClose);
            panelFavorites.Controls.Add(labelMyFavTitle);
            panelFavorites.Controls.Add(tabControl1);
            panelFavorites.Dock = DockStyle.Fill;
            panelFavorites.Location = new Point(0, 0);
            panelFavorites.Name = "panelFavorites";
            panelFavorites.Size = new Size(1130, 509);
            panelFavorites.TabIndex = 11;
            panelFavorites.Visible = false;
            panelFavorites.Paint += panelFavorites_Paint;
            // 
            // buttonFavClose
            // 
            buttonFavClose.BackColor = Color.IndianRed;
            buttonFavClose.Location = new Point(1043, 474);
            buttonFavClose.Name = "buttonFavClose";
            buttonFavClose.Size = new Size(75, 23);
            buttonFavClose.TabIndex = 3;
            buttonFavClose.Text = "Close";
            buttonFavClose.UseVisualStyleBackColor = false;
            buttonFavClose.Click += buttonFavClose_Click;
            // 
            // labelMyFavTitle
            // 
            labelMyFavTitle.AutoSize = true;
            labelMyFavTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMyFavTitle.ForeColor = Color.PaleGoldenrod;
            labelMyFavTitle.Location = new Point(351, 12);
            labelMyFavTitle.Name = "labelMyFavTitle";
            labelMyFavTitle.Size = new Size(425, 65);
            labelMyFavTitle.TabIndex = 2;
            labelMyFavTitle.Text = "★ My Favorites ★";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabFavArtists);
            tabControl1.Controls.Add(tabFavAlbums);
            tabControl1.Controls.Add(tabFavTracks);
            tabControl1.Location = new Point(233, 94);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(632, 403);
            tabControl1.TabIndex = 0;
            // 
            // tabFavArtists
            // 
            tabFavArtists.Controls.Add(dataFavArtists);
            tabFavArtists.Location = new Point(4, 24);
            tabFavArtists.Name = "tabFavArtists";
            tabFavArtists.Padding = new Padding(3);
            tabFavArtists.Size = new Size(624, 375);
            tabFavArtists.TabIndex = 0;
            tabFavArtists.Text = "Artists";
            tabFavArtists.UseVisualStyleBackColor = true;
            tabFavArtists.Click += tabPage1_Click;
            // 
            // dataFavArtists
            // 
            dataFavArtists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFavArtists.Dock = DockStyle.Fill;
            dataFavArtists.Location = new Point(3, 3);
            dataFavArtists.Name = "dataFavArtists";
            dataFavArtists.Size = new Size(618, 369);
            dataFavArtists.TabIndex = 0;
            // 
            // tabFavAlbums
            // 
            tabFavAlbums.Controls.Add(dataFavAlbums);
            tabFavAlbums.Location = new Point(4, 24);
            tabFavAlbums.Name = "tabFavAlbums";
            tabFavAlbums.Padding = new Padding(3);
            tabFavAlbums.Size = new Size(624, 375);
            tabFavAlbums.TabIndex = 1;
            tabFavAlbums.Text = "Albums";
            tabFavAlbums.UseVisualStyleBackColor = true;
            // 
            // dataFavAlbums
            // 
            dataFavAlbums.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFavAlbums.Dock = DockStyle.Fill;
            dataFavAlbums.Location = new Point(3, 3);
            dataFavAlbums.Name = "dataFavAlbums";
            dataFavAlbums.Size = new Size(618, 369);
            dataFavAlbums.TabIndex = 0;
            // 
            // tabFavTracks
            // 
            tabFavTracks.Controls.Add(dataFavTracks);
            tabFavTracks.Location = new Point(4, 24);
            tabFavTracks.Name = "tabFavTracks";
            tabFavTracks.Padding = new Padding(3);
            tabFavTracks.Size = new Size(624, 375);
            tabFavTracks.TabIndex = 2;
            tabFavTracks.Text = "Tracks";
            tabFavTracks.UseVisualStyleBackColor = true;
            // 
            // dataFavTracks
            // 
            dataFavTracks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFavTracks.Dock = DockStyle.Fill;
            dataFavTracks.Location = new Point(3, 3);
            dataFavTracks.Name = "dataFavTracks";
            dataFavTracks.Size = new Size(618, 369);
            dataFavTracks.TabIndex = 0;
            // 
            // buttonFavStop
            // 
            buttonFavStop.Location = new Point(765, 84);
            buttonFavStop.Name = "buttonFavStop";
            buttonFavStop.Size = new Size(75, 23);
            buttonFavStop.TabIndex = 4;
            buttonFavStop.Text = "Stop track";
            buttonFavStop.UseVisualStyleBackColor = true;
            buttonFavStop.Click += buttonFavStop_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1130, 509);
            Controls.Add(panelFavorites);
            Controls.Add(buttonStop);
            Controls.Add(buttonMyFav);
            Controls.Add(labelRole);
            Controls.Add(buttonAllTracks);
            Controls.Add(buttonAddAlbum);
            Controls.Add(buttonAddTrack);
            Controls.Add(dataAlbums);
            Controls.Add(dataTracks);
            Controls.Add(buttonLogout);
            Controls.Add(labelUsername);
            Controls.Add(labelWelcome);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataTracks).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataAlbums).EndInit();
            ((System.ComponentModel.ISupportInitialize)albumBindingSource).EndInit();
            panelFavorites.ResumeLayout(false);
            panelFavorites.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabFavArtists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataFavArtists).EndInit();
            tabFavAlbums.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataFavAlbums).EndInit();
            tabFavTracks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataFavTracks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Label labelUsername;
        private Button buttonLogout;
        private DataGridView dataTracks;
        private BindingSource trackBindingSource;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn albumDataGridViewTextBoxColumn;
        private DataGridView dataAlbums;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn artistDataGridViewTextBoxColumn;
        private BindingSource albumBindingSource;
        private Button buttonAddTrack;
        private Button buttonAddAlbum;
        private Button buttonAllTracks;
        private Label labelRole;
        private Button buttonMyFav;
        private Button buttonStop;
        private Panel panelFavorites;
        private TabControl tabControl1;
        private TabPage tabFavArtists;
        private TabPage tabFavAlbums;
        private TabPage tabFavTracks;
        private DataGridView dataFavArtists;
        private DataGridView dataFavAlbums;
        private DataGridView dataFavTracks;
        private Label labelMyFavTitle;
        private Button buttonFavClose;
        private Button buttonFavStop;
    }
}