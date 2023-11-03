using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDRC2237A3.Models
{
    public class TrackAddFormViewModel : TrackAddViewModel
    {
        [Display(Name = "Album")]
        public SelectList AlbumList { get; set; }
        [Display(Name = "Media Type")]
        public SelectList MediaTypeList { get; set; }
    }
}