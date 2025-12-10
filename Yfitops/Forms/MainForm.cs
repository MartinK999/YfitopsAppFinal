using Microsoft.Extensions.DependencyInjection;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yfitops.Forms;
using Yfitops.Models;
using Yfitops.Models.Entities;
using Yfitops.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Yfitops
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserFavoriteRepository _userFavoriteRepository;

        private WaveOutEvent _output;
        private AudioFileReader _audio;

        public MainForm(IAlbumRepository albumRepository, IUserRepository userRepository,
                ITrackRepository trackRepository, IUserFavoriteRepository userFavoriteRepository)
        {
            InitializeComponent();
            PanelFavorites_Load();


            _albumRepository = albumRepository;
            _userRepository = userRepository;
            _trackRepository = trackRepository;
            _userFavoriteRepository = userFavoriteRepository;
            dataTracks.DataBindingComplete += DataTracks_DataBindingComplete;
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;

            SetupAlbumsGrid();
            SetupTracksGrid();
            UpdateUIBasedOnRole();
            LoadAlbums();
            LoadTracks();

            panelFavorites.Visible = false;
            panelFavorites.BringToFront();

        }

        private void DataTracks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataAlbums.Columns.Contains("FavoriteAlbumButton"))
            {
                foreach (DataGridViewRow row in dataAlbums.Rows)
                {
                    if (row.DataBoundItem is AlbumViewModel album)
                    {
                        var albumBtnCell = (DataGridViewButtonCell)row.Cells["FavoriteAlbumButton"];
                        if (_userFavoriteRepository.Exists(_currentUser.Id, "Album", album.Id))
                        {
                            albumBtnCell.Value = "Remove";
                            albumBtnCell.Style.BackColor = Color.LightCoral;
                        }
                        else
                        {
                            albumBtnCell.Value = "Add";
                            albumBtnCell.Style.BackColor = Color.LightGreen;
                        }
                    }
                }

                foreach (DataGridViewRow row in dataTracks.Rows)
                {
                    if (row.DataBoundItem is TrackViewModel track)
                    {
                        var trackBtnCell = (DataGridViewButtonCell)row.Cells["FavoriteTrackButton"];
                        if (_userFavoriteRepository.Exists(_currentUser.Id, "Track", track.Id))
                        {
                            trackBtnCell.Value = "Remove";
                            trackBtnCell.Style.BackColor = Color.LightCoral;
                        }
                        else
                        {
                            trackBtnCell.Value = "Add";
                            trackBtnCell.Style.BackColor = Color.LightGreen;
                        }

                        var artistBtnCell = (DataGridViewButtonCell)row.Cells["FavoriteArtistButton"];
                        if (_userFavoriteRepository.Exists(_currentUser.Id, "Artist", track.CreatedByUserId))
                        {
                            artistBtnCell.Value = "Remove";
                            artistBtnCell.Style.BackColor = Color.LightCoral;
                        }
                        else
                        {
                            artistBtnCell.Value = "Add";
                            artistBtnCell.Style.BackColor = Color.LightGreen;
                        }
                    }
                }
            }

        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        private void buttonAddAlbum_Click(object sender, EventArgs e)
        {

        }

        private void UpdateUIBasedOnRole()
        {
            if (_currentUser == null)
                return;
            switch (_currentUser.Role)
            {
                case "Admin":
                    buttonLogout.Visible = true;
                    buttonAddTrack.Visible = true;
                    buttonAddAlbum.Visible = true;
                    buttonMyFav.Visible = true;
                    break;
                case "Musician":
                    buttonLogout.Visible = true;
                    buttonAddTrack.Visible = true;
                    buttonAddAlbum.Visible = true;
                    buttonMyFav.Visible = false;
                    break;
                case "User":
                    buttonLogout.Visible = true;
                    buttonAddTrack.Visible = false;
                    buttonAddAlbum.Visible = false;
                    buttonMyFav.Visible = true;
                    break;
                case "Guest":
                    buttonLogout.Visible = false;
                    buttonAddTrack.Visible = false;
                    buttonAddAlbum.Visible = false;
                    buttonMyFav.Visible = false;
                    break;
                default:
                    // Handle unknown roles
                    break;
            }

            labelUsername.Text = _currentUser.Username;
            labelRole.Text = _currentUser.Role;
        }

        private void LoadAlbums()
        {

            var albums = _albumRepository.GetAll().Select(a => new AlbumViewModel
            {
                Id = a.Id,
                Title = a.Title,
                ArtistId = a.ArtistId,
                ArtistName = _userRepository.GetById(a.ArtistId).Username
            }).ToList();

            dataAlbums.DataSource = albums;

        }
        private void LoadTracksForAlbum(int albumId)
        {

            var tracks = _trackRepository.GetByAlbumId(albumId).Select(t => new TrackViewModel
            {
                Id = t.Id,
                Title = t.Title,
                AlbumTitle = t.AlbumId.HasValue ? _albumRepository.GetById(t.AlbumId.Value).Title : "-Standalone-",
                TrackAuthor = _userRepository.GetById(t.CreatedByUserId)?.Username ?? "Unknown"
            }).ToList();

            dataTracks.DataSource = tracks;

        }

        private void LoadTracks()
        {

            var tracks = _trackRepository.GetAll().Select(t => new TrackViewModel
            {
                Id = t.Id,
                Title = t.Title,
                AlbumTitle = t.AlbumId.HasValue ? _albumRepository.GetById(t.AlbumId.Value).Title : "-Standalone-",
                TrackAuthor = _userRepository.GetById(t.CreatedByUserId)?.Username ?? "Unknown",
                CreatedByUserId = t.CreatedByUserId
            }).ToList();

            dataTracks.DataSource = tracks;

        }

        private void SetupAlbumsGrid()
        {
            dataAlbums.Columns.Clear();
            dataAlbums.AutoGenerateColumns = false;

            dataAlbums.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Album",
                DataPropertyName = "Title",
                ReadOnly = true
            });

            dataAlbums.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Author",
                DataPropertyName = "ArtistName",
                ReadOnly = true
            });

            var editAlbumBtn = new DataGridViewButtonColumn();
            editAlbumBtn.HeaderText = "";
            editAlbumBtn.Text = "Edit";
            editAlbumBtn.UseColumnTextForButtonValue = true;
            if (_currentUser.Role == "Admin" || _currentUser.Role == "Musician")
            {
                dataAlbums.Columns.Add(editAlbumBtn);
            }

            var deleteAlbumBtn = new DataGridViewButtonColumn();
            deleteAlbumBtn.HeaderText = "";
            deleteAlbumBtn.Text = "Delete";
            deleteAlbumBtn.UseColumnTextForButtonValue = true;
            if (_currentUser.Role == "Admin" || _currentUser.Role == "Musician")
            {
                dataAlbums.Columns.Add(deleteAlbumBtn);
            }

            var favBtn = new DataGridViewButtonColumn();
            favBtn.Name = "FavoriteAlbumButton";
            favBtn.HeaderText = "♥ Favorite album";
            favBtn.Text = "Add";
            favBtn.UseColumnTextForButtonValue = false;
            if (_currentUser.Role == "User" || _currentUser.Role == "Admin")
            {
                dataAlbums.Columns.Add(favBtn);
            }

            dataAlbums.CellClick += DataAlbums_CellClick;
        }

        private void SetupTracksGrid()
        {
            dataTracks.Columns.Clear();
            dataTracks.AutoGenerateColumns = false;

            dataTracks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Track",
                DataPropertyName = "Title",
                ReadOnly = true
            });

            dataTracks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Album",
                DataPropertyName = "AlbumTitle",
                ReadOnly = true
            });

            dataTracks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Author",
                DataPropertyName = "TrackAuthor",
                ReadOnly = true
            });

            var editBtn = new DataGridViewButtonColumn();
            editBtn.HeaderText = "";
            editBtn.Text = "Edit";
            editBtn.UseColumnTextForButtonValue = true;
            if (_currentUser.Role == "Admin" || _currentUser.Role == "Musician")
            {
                dataTracks.Columns.Add(editBtn);
            }

            var deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "";
            deleteBtn.Text = "Delete";
            deleteBtn.UseColumnTextForButtonValue = true;
            if (_currentUser.Role == "Admin" || _currentUser.Role == "Musician")
            {
                dataTracks.Columns.Add(deleteBtn);
            }

            var favBtn = new DataGridViewButtonColumn();
            favBtn.Name = "FavoriteTrackButton";
            favBtn.HeaderText = "♥ Favorite Track";
            favBtn.Text = "Add";
            favBtn.UseColumnTextForButtonValue = false;
            if (_currentUser.Role == "User" || _currentUser.Role == "Admin")
            {
                dataTracks.Columns.Add(favBtn);
            }

            var favBtnArtist = new DataGridViewButtonColumn();
            favBtnArtist.Name = "FavoriteArtistButton";
            favBtnArtist.HeaderText = "♥ Favorite Artist";
            favBtnArtist.Text = "Add";
            favBtnArtist.UseColumnTextForButtonValue = false;
            if (_currentUser.Role == "User" || _currentUser.Role == "Admin")
            {
                dataTracks.Columns.Add(favBtnArtist);
            }

            var playBtn = new DataGridViewButtonColumn();
            playBtn.Name = "PlayTrackButton";
            playBtn.HeaderText = "▶";
            playBtn.Text = "Play";
            playBtn.UseColumnTextForButtonValue = true;
            dataTracks.Columns.Add(playBtn);



            dataTracks.CellClick += DataTracks_CellClick;
        }

        private void DataTracks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var track = (TrackViewModel)dataTracks.Rows[e.RowIndex].DataBoundItem;

            if (dataTracks.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string buttonText = dataTracks[e.ColumnIndex, e.RowIndex].Value.ToString();
                var btnCell = (DataGridViewButtonCell)dataTracks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var trackEntity = _trackRepository.GetById(track.Id);

                if (buttonText == "Edit")
                {
                    if (_currentUser.Role == "Admin" || (_currentUser.Role == "Musician" && trackEntity.CreatedByUserId == _currentUser.Id))
                    {
                        string newTitle = Prompt.ShowDialog("New Track Name", "Edit Track");
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            trackEntity.Title = newTitle;
                            _trackRepository.Update(trackEntity);
                            if (trackEntity.AlbumId == null)
                            {
                                LoadTracks();
                            }
                            else
                            {
                                LoadTracksForAlbum(trackEntity.AlbumId ?? 0);
                            }

                        }
                    }
                }
                else if (buttonText == "Delete")
                {
                    if (_currentUser.Role == "Admin" || (_currentUser.Role == "Musician" && trackEntity.CreatedByUserId == _currentUser.Id))
                    {
                        var trackFavs = _userFavoriteRepository.GetAll()
                            .Where(f => f.FavoriteType == "Track" && f.FavoriteId == trackEntity.Id)
                            .ToList();


                        foreach (var f in trackFavs)
                        {
                            _userFavoriteRepository.Delete(f);
                        }

                        _trackRepository.Delete(trackEntity);
                        if (trackEntity.AlbumId == null)
                        {
                            LoadTracks();
                        }
                        else
                        {
                            LoadTracksForAlbum(trackEntity.AlbumId ?? 0);
                        }
                    }
                }
                else if (dataTracks.Columns[e.ColumnIndex].Name == "FavoriteTrackButton")
                {
                    if (_currentUser.Role == "User" || _currentUser.Role == "Admin")
                    {

                        if (_userFavoriteRepository.Exists(_currentUser.Id, "Track", track.Id))
                        {
                            var fav = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                                         .FirstOrDefault(f => f.FavoriteType == "Track" && f.FavoriteId == track.Id);
                            if (fav != null)
                            {
                                _userFavoriteRepository.Delete(fav);
                            }
                        }
                        else
                        {
                            // Add to favorites
                            var newFav = new UserFavorite
                            {
                                UserId = _currentUser.Id,
                                FavoriteType = "Track",
                                FavoriteId = track.Id
                            };
                            _userFavoriteRepository.Add(newFav);
                        }

                        // Update button UI immediately
                        var btnCellUI = (DataGridViewButtonCell)dataTracks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        bool isNowFavorite = _userFavoriteRepository.Exists(_currentUser.Id, "Track", track.Id);
                        btnCellUI.Value = isNowFavorite ? "Remove" : "Add";
                        btnCellUI.Style.BackColor = isNowFavorite ? Color.LightCoral : Color.LightGreen;

                    }
                }
                else if (dataTracks.Columns[e.ColumnIndex].Name == "FavoriteArtistButton")
                {
                    if (_currentUser.Role == "User" || _currentUser.Role == "Admin")
                    {

                        if (_userFavoriteRepository.Exists(_currentUser.Id, "Artist", track.CreatedByUserId))
                        {
                            var fav = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                                         .FirstOrDefault(f => f.FavoriteType == "Artist" && f.FavoriteId == track.CreatedByUserId);
                            if (fav != null)
                                _userFavoriteRepository.Delete(fav);
                        }
                        else
                        {
                            var newFav = new UserFavorite
                            {
                                UserId = _currentUser.Id,
                                FavoriteType = "Artist",
                                FavoriteId = track.CreatedByUserId
                            };
                            _userFavoriteRepository.Add(newFav);
                        }

                        var btnCellUI = (DataGridViewButtonCell)dataTracks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        bool isNowFavorite = _userFavoriteRepository.Exists(_currentUser.Id, "Artist", track.CreatedByUserId);
                        btnCellUI.Value = isNowFavorite ? "Remove" : "Add";
                        btnCellUI.Style.BackColor = isNowFavorite ? Color.LightCoral : Color.LightGreen;
                        LoadTracks();
                    }
                }
                else if (dataTracks.Columns[e.ColumnIndex].Name == "PlayTrackButton")
                {

                    if (string.IsNullOrEmpty(trackEntity.FilePath))
                    {
                        MessageBox.Show("File not found!");
                        return;
                    }
                    else
                    {
                        PlayTrack(trackEntity.FilePath);
                    }
                }
            }
        }


        private void DataAlbums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var album = (AlbumViewModel)dataAlbums.Rows[e.RowIndex].DataBoundItem;

            if (dataAlbums.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string buttonText = dataAlbums[e.ColumnIndex, e.RowIndex].Value.ToString();

                var albumEntity = _albumRepository.GetById(album.Id);
                if (buttonText == "Edit")
                {
                    if (_currentUser.Role == "Admin" || (_currentUser.Role == "Musician" && album.ArtistId == _currentUser.Id))
                    {
                        string newTitle = Prompt.ShowDialog("New Album Name", "Edit Album");
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            albumEntity.Title = newTitle;
                            _albumRepository.Update(albumEntity);
                            LoadAlbums();
                        }
                    }
                }
                else if (buttonText == "Delete")
                {
                    if (_currentUser.Role == "Admin" || (_currentUser.Role == "Musician" && album.ArtistId == _currentUser.Id))
                    {
                        var albumFavs = _userFavoriteRepository.GetAll()
                            .Where(f => f.FavoriteType == "Album" && f.FavoriteId == albumEntity.Id)
                            .ToList();


                        foreach (var f in albumFavs)
                        {
                            _userFavoriteRepository.Delete(f);
                        }

                        var trackIds = _trackRepository.GetByAlbumId(albumEntity.Id).Select(t => t.Id).ToList();
                        var trackFavs = _userFavoriteRepository.GetAll()
                            .Where(f => f.FavoriteType == "Track" && trackIds.Contains(f.FavoriteId))
                            .ToList();
                        foreach (var f in trackFavs)
                        {
                            _userFavoriteRepository.Delete(f);
                        }

                        _albumRepository.Delete(albumEntity);
                        LoadAlbums();
                    }
                }
                else if (dataAlbums.Columns[e.ColumnIndex].Name == "FavoriteAlbumButton")
                {
                    if (_currentUser.Role == "User" || _currentUser.Role == "Admin")
                    {
                        if (_userFavoriteRepository.Exists(_currentUser.Id, "Album", album.Id))
                        {
                            var fav = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                                         .FirstOrDefault(f => f.FavoriteType == "Album" && f.FavoriteId == album.Id);
                            if (fav != null)
                                _userFavoriteRepository.Delete(fav);
                        }
                        else
                        {
                            var newFav = new UserFavorite
                            {
                                UserId = _currentUser.Id,
                                FavoriteType = "Album",
                                FavoriteId = album.Id
                            };
                            _userFavoriteRepository.Add(newFav);
                        }

                        var btnCellUI = (DataGridViewButtonCell)dataAlbums.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        bool isNowFavorite = _userFavoriteRepository.Exists(_currentUser.Id, "Album", album.Id);
                        btnCellUI.Value = isNowFavorite ? "Remove" : "Add";
                        btnCellUI.Style.BackColor = isNowFavorite ? Color.LightCoral : Color.LightGreen;

                    }
                }
            }

            LoadTracksForAlbum(album.Id);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {


            var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();

            loginForm.ResetForm();
            loginForm.Show();

            _currentUser = null;
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void dataAlbums_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddAlbum_Click_1(object sender, EventArgs e)
        {
            var currentUserFromDb = _userRepository.GetById(_currentUser.Id);
            string albumTitle = Prompt.ShowDialog("Album name:", "Add New Album");
            if (string.IsNullOrEmpty(albumTitle)) return;

            Album newAlbum = new Album
            {
                Title = albumTitle,
                ArtistId = currentUserFromDb.Id
            };

            _albumRepository.Add(newAlbum);
            LoadAlbums();


        }

        private void buttonAddTrack_Click(object sender, EventArgs e)
        {

            var myAlbums = _albumRepository.GetByArtistId(_currentUser.Id).ToList();

            Album selectedAlbum = null;
            if (myAlbums.Any())
            {
                using (Form selectAlbumForm = new Form())
                {
                    selectAlbumForm.Text = "Select Album";
                    selectAlbumForm.Width = 300;
                    selectAlbumForm.Height = 150;
                    selectAlbumForm.StartPosition = FormStartPosition.CenterParent;

                    ComboBox comboBox = new ComboBox() { Left = 20, Top = 20, Width = 240 };
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Items.Add("None");
                    foreach (var album in myAlbums)
                    {
                        comboBox.Items.Add(album.Title);
                    }

                    comboBox.SelectedIndex = 0;

                    Button btnOk = new Button() { Text = "OK", Left = 100, Width = 80, Top = 60, DialogResult = DialogResult.OK };
                    selectAlbumForm.Controls.Add(comboBox);
                    selectAlbumForm.Controls.Add(btnOk);
                    selectAlbumForm.AcceptButton = btnOk;

                    if (selectAlbumForm.ShowDialog() == DialogResult.OK)
                    {
                        if (comboBox.SelectedIndex > 0)
                            selectedAlbum = myAlbums[comboBox.SelectedIndex - 1];
                    }
                }
            }

            string trackTitle = Prompt.ShowDialog("Track name:", "Add New Track");
            if (string.IsNullOrEmpty(trackTitle)) return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Audio files|*.mp3;*.wav;*.flac";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                string selectedPath = dlg.FileName;


                var newTrack = new Models.Entities.Track
                {
                    Title = trackTitle,
                    AlbumId = selectedAlbum?.Id,
                    CreatedByUserId = _currentUser.Id,
                    FilePath = selectedPath
                };

                _trackRepository.Add(newTrack);

            }
            if (selectedAlbum != null)
                LoadTracksForAlbum(selectedAlbum.Id);
            else
                LoadTracks();
        }

        private void buttonAllTracks_Click(object sender, EventArgs e)
        {
            LoadTracks();
        }

        private void dataTracks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PanelFavorites_Load()
        {

            var playBtn = new DataGridViewButtonColumn();
            playBtn.Name = "PlayTrackButton";
            playBtn.HeaderText = "▶";
            playBtn.Text = "Play";
            playBtn.UseColumnTextForButtonValue = true;
            playBtn.DefaultCellStyle.BackColor = Color.Green;
            dataFavTracks.Columns.Add(playBtn);

            // Artists
            var colArtist = new DataGridViewButtonColumn();
            colArtist.Name = "RemoveArtist";
            colArtist.Text = "Remove";
            colArtist.UseColumnTextForButtonValue = true;
            colArtist.DefaultCellStyle.BackColor = Color.LightCoral;
            dataFavArtists.Columns.Add(colArtist);

            // Albums
            var colAlbum = new DataGridViewButtonColumn();
            colAlbum.Name = "RemoveAlbum";
            colAlbum.Text = "Remove";
            colAlbum.UseColumnTextForButtonValue = true;
            colAlbum.DefaultCellStyle.BackColor = Color.LightCoral;
            dataFavAlbums.Columns.Add(colAlbum);

            // Tracks
            var colTrack = new DataGridViewButtonColumn();
            colTrack.Name = "RemoveTrack";
            colTrack.Text = "Remove";
            colTrack.UseColumnTextForButtonValue = true;
            colTrack.DefaultCellStyle.BackColor = Color.LightCoral;
            dataFavTracks.Columns.Add(colTrack);

            dataFavArtists.CellClick += dataFavArtists_CellClick;
            dataFavAlbums.CellClick += dataFavAlbums_CellClick;
            dataFavTracks.CellClick += dataFavTracks_CellClick;
        }
        private void LoadFavorites()
        {


            // Artists
            var favArtists = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                .Where(f => f.FavoriteType == "Artist")
                .Select(f => _userRepository.GetById(f.FavoriteId))
                .Where(u => u != null)
                .Select(u => new { u.Id, Name = u.Username })
                .ToList();
            dataFavArtists.DataSource = favArtists;

            // Albums
            var favAlbums = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                .Where(f => f.FavoriteType == "Album")
                .Select(f => _albumRepository.GetById(f.FavoriteId))
                .Where(a => a != null)
                .Select(a => new { a.Id, a.Title })
                .ToList();
            dataFavAlbums.DataSource = favAlbums;

            // Tracks
            var favTracks = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                .Where(f => f.FavoriteType == "Track")
                .Select(f => _trackRepository.GetById(f.FavoriteId))
                .Where(t => t != null)
                .Select(t => new { t.Id, t.Title })
                .ToList();
            dataFavTracks.DataSource = favTracks;


        }

        private void dataFavArtists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dataFavArtists.Columns[e.ColumnIndex].Name == "RemoveArtist")
            {
                int artistId = (int)dataFavArtists.Rows[e.RowIndex].Cells["Id"].Value;

                var fav = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                    .FirstOrDefault(f => f.FavoriteType == "Artist" && f.FavoriteId == artistId);

                if (fav != null)
                    _userFavoriteRepository.Delete(fav);

                LoadFavorites();
            }
        }

        private void dataFavAlbums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dataFavAlbums.Columns[e.ColumnIndex].Name == "RemoveAlbum")
            {
                int albumId = (int)dataFavAlbums.Rows[e.RowIndex].Cells["Id"].Value;

                var fav = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                    .FirstOrDefault(f => f.FavoriteType == "Album" && f.FavoriteId == albumId);

                if (fav != null)
                    _userFavoriteRepository.Delete(fav);

                LoadFavorites();
            }
        }

        private void dataFavTracks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dataFavTracks.Columns[e.ColumnIndex].Name == "RemoveTrack")
            {
                int trackId = (int)dataFavTracks.Rows[e.RowIndex].Cells["Id"].Value;

                var fav = _userFavoriteRepository.GetByUserId(_currentUser.Id)
                    .FirstOrDefault(f => f.FavoriteType == "Track" && f.FavoriteId == trackId);

                if (fav != null)
                    _userFavoriteRepository.Delete(fav);

                LoadFavorites();
            }
            else if (dataFavTracks.Columns[e.ColumnIndex].Name == "PlayTrackButton")
            {
                int trackId = (int)dataFavTracks.Rows[e.RowIndex].Cells["Id"].Value;
                var trackEntity = _trackRepository.GetById(trackId);
                if (string.IsNullOrEmpty(trackEntity.FilePath))
                {
                    MessageBox.Show("File not found!");
                    return;
                }
                else
                {
                    PlayTrack(trackEntity.FilePath);
                }
            }
        }
        private void buttonMyFav_Click(object sender, EventArgs e)
        {
            LoadFavorites();

            panelFavorites.Visible = true;
            panelFavorites.BringToFront();
        }

        public void PlayTrack(string filePath)
        {
            Task.Run(() =>
            {
                try
                {
                    StopTrack();

                    _audio = new AudioFileReader(filePath);
                    _output = new WaveOutEvent();
                    _output.Init(_audio);
                    _output.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            });
        }
        public void StopTrack()
        {
            _output?.Stop();
            _audio?.Dispose();
            _output?.Dispose();

            _output = null;
            _audio = null;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopTrack();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panelFavorites_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonFavClose_Click(object sender, EventArgs e)
        {
            panelFavorites.Visible = false;
            LoadTracks();
        }

        private void buttonFavStop_Click(object sender, EventArgs e)
        {
            StopTrack();
        }
    }
}
