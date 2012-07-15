using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace Placesv1.Model
{
    class Tag
    {
        [Key]
        public int TagID { get; }
        [Required]
        public string Name { get; set; }
    }

    class Entry
    {
        [Key]
        public int PlaceID { get; set; }
        [Key]
        public int TagID { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
