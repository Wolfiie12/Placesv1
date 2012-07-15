using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Placesv1.Web.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        [Required]
        public string Password { get; set; }
    }
}