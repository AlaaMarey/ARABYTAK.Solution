using System.ComponentModel.DataAnnotations;

namespace ARABYTAK.APIS.DTOs
{
    public class RegisterDto
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
      
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        [Required]
        //[Regular Expression]
        public string Password { get; set; }
    }
}
