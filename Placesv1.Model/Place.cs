using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System;

namespace Placesv1.Model
{
    class Place
    {
        [Key]
        public int PlaceID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string URI { get; set; }
        [Required]
        [Timestamp]
        public DateTime CreationDate { get; set; }
        [Key]
        public int UserID { get; set; }
    }
}
