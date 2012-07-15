using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Placesv1.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        [Required]
        public string Password { get; set; }
    }
}