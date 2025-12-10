using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yfitops.Models.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public int? AlbumId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public Album Album { get; set; }
        public int CreatedByUserId { get; set; }
    }

}
