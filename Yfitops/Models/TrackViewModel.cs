using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yfitops.Models
{
    public class TrackViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string TrackAuthor { get; internal set; }
        public int CreatedByUserId { get; set; }
    }
}
