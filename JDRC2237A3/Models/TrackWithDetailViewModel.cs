using JDRC2237A3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JDRC2237A3.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name = "Album Title")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Artist Name")]
        public string AlbumArtistName { get; set; }

        [Display(Name = "Media Type")]
        public MediaType MediaType { get; set; }
    }
}