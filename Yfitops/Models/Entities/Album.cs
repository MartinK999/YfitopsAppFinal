using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Yfitops.Models.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }

        public Artist Artist { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
