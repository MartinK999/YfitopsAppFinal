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
            ((System.ComponentModel.ISupportInitialize)dataTracks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataAlbums).BeginInit();
            ((System.ComponentModel.ISupportInitialize)albumBindingSource).BeginInit();
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1130, 509);
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
    }
}