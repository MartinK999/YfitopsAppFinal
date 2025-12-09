using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yfitops.Models.Entities;
using Yfitops.Repositories;

namespace Yfitops.Forms
{
    public partial class FavoritesForm : Form
    {
        private User _currentUser;
        private readonly IUserFavoriteRepository _userFavoriteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ITrackRepository _trackRepopository;
        private object _userFavoriteRepositary;

        public FavoritesForm(
            IUserFavoriteRepository userFavoriteRepository,
            IUserRepository userRepository,
            IAlbumRepository albumRepository,
            ITrackRepository trackRepository
            )
        {
            InitializeComponent();
            _userFavoriteRepository = userFavoriteRepository;
            _userRepository = userRepository;
            _albumRepository = albumRepository;
            _trackRepopository = trackRepository;
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            LoadFavorites();
        }

        private void FavoritesForm_Load(object sender, EventArgs e)
        {
            // Artists
            var colArtist = new DataGridViewButtonColumn();
            colArtist.Name = "RemoveArtist";
            colArtist.Text = "Remove";
            colArtist.UseColumnTextForButtonValue = true;
            dataFavArtists.Columns.Add(colArtist);

            // Albums
            var colAlbum = new DataGridViewButtonColumn();
            colAlbum.Name = "RemoveAlbum";
            colAlbum.Text = "Remove";
            colAlbum.UseColumnTextForButtonValue = true;
            dataFavAlbums.Columns.Add(colAlbum);

            // Tracks
            var colTrack = new DataGridViewButtonColumn();
            colTrack.Name = "RemoveTrack";
            colTrack.Text = "Remove";
            colTrack.UseColumnTextForButtonValue = true;
            dataFavTracks.Columns.Add(colTrack);

            dataFavArtists.CellClick += dataFavArtists_CellClick;
            dataFavAlbums.CellClick += dataFavAlbums_CellClick;
            dataFavTracks.CellClick += dataFavTracks_CellClick;

            LoadFavorites();
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
                .Select(f => _trackRepopository.GetById(f.FavoriteId))
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
        }

        private void dataFavArtists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
