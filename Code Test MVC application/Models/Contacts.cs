using System.ComponentModel.DataAnnotations;

namespace Code_Test_MVC_application.Models
{
    public class Contacts
    {
        [Display(Name = "First Name")]
        public string? firstname { get; set; }

        [Display(Name = "Last Name")]
        public string? lastname { get; set; }
        [Display(Name = "Contact Email")]
        
        [Required(ErrorMessage = "Please enter email address")]
        public string? email { get; set; }

    }
}
