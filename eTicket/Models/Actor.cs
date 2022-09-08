using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile picture must be required.")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name must be required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be contains between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography must be required.")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
