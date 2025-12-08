using Microsoft.Extensions.DependencyInjection;
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

        public MainForm(IAlbumRepository albumRepository, IUserRepository userRepository,
                ITrackRepository trackRepository)
        {
            InitializeComponent();

            _albumRepository = albumRepository;
            _userRepository = userRepository;
            _trackRepository = trackRepository;





            LoadAlbums();
            LoadTracks();


        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            SetupAlbumsGrid();
            SetupTracksGrid();
            UpdateUIBasedOnRole();

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
                    break;
                case "Musician":
                    buttonLogout.Visible = true;
                    buttonAddTrack.Visible = true;
                    buttonAddAlbum.Visible = true;
                    break;
                case "User":
                    buttonLogout.Visible = true;
                    buttonAddTrack.Visible = false;
                    buttonAddAlbum.Visible = false;
                    break;
                case "Guest":
                    buttonLogout.Visible = false;
                    buttonAddTrack.Visible = false;
                    buttonAddAlbum.Visible = false;
                    break;
                default:
                    // Handle unknown roles
                    break;
            }

            labelUsername.Text = _currentUser.Username;
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
                TrackAuthor = _userRepository.GetById(t.CreatedByUserId)?.Username ?? "Unknown"
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
            dataTracks.CellClick += DataTracks_CellClick;
        }

        private void DataTracks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var track = (TrackViewModel)dataTracks.Rows[e.RowIndex].DataBoundItem;

            if (dataTracks.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string buttonText = dataTracks[e.ColumnIndex, e.RowIndex].Value.ToString();
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
            }
        }

        private void LoadAlbums()
        {
            var albums = _albumRepository.GetAll();

            var list = albums.Select(a => new AlbumViewModel
            {
                Id = a.Id,
                Title = a.Title,
                ArtistId = a.ArtistId,
                ArtistName = _userRepository.GetById(a.ArtistId).Username
            }).ToList();

            dataAlbums.DataSource = list;

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
                        _albumRepository.Delete(albumEntity);
                        LoadAlbums();
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
            string trackTitle = Prompt.ShowDialog("Track name:", "Add New Track");
            if (string.IsNullOrEmpty(trackTitle)) return;

            var myAlbums = _albumRepository.GetByArtistId(_currentUser.Id).ToList();

            Album selectedAlbum = null;
            if (myAlbums.Any())
            {
                string albumList = "0: None\n";
                int idx = 1;
                foreach (var album in myAlbums)
                {
                    albumList += $"{idx}: {album.Title}\n";
                    idx++;
                }

                string input = Prompt.ShowDialog(
                     $"Choose album for the track:\n{albumList}",
                     "Select Album"
                );

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= myAlbums.Count)
                        selectedAlbum = myAlbums[choice - 1];
                    else
                        selectedAlbum = null;
                }
                else
                {
                    selectedAlbum = null; // None
                }
            }


            var newTrack = new Models.Entities.Track
            {
                Title = trackTitle,
                AlbumId = selectedAlbum?.Id,
                CreatedByUserId = _currentUser.Id
            };

            _trackRepository.Add(newTrack);

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
    }
}
