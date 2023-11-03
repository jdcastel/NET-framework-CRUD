using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JDRC2237A3.Models
{
    public class PlaylistBaseViewModel
    {
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        [Display(Name = "Playlist Name")]
        public string Name { get; set; }
        [Display(Name = "Playlist Track Count")]
        public int TracksCount { get; set; }
        public ICollection<TrackBaseViewModel> Tracks { get; set; }
    }
}