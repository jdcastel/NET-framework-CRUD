using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDRC2237A3.Models
{
    public class TrackAddViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Composer { get; set; }

        [Display(Name = "Length (ms)")]
        [Required]
        public int Milliseconds { get; set; }

        [Display(Name = "Unit price")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Album is required")]
        public int AlbumId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Media Type is required")]
        public int MediaTypeId { get; set; }
    }
}