using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDRC2237A3.Models
{
    public class PlaylistEditTracksFormViewModel : TrackBaseViewModel
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public IEnumerable<int> SelectedTrackIds { get; set; }
        public SelectList AllTracks { get; set; }
        public IEnumerable<TrackBaseViewModel> CurrentTracks { get; set; }
        public int TracksCount { get; set; }
    }
}