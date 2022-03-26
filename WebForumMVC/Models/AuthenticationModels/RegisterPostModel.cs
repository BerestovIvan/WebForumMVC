using System.ComponentModel.DataAnnotations;

namespace WebForumMVC.Models.AuthenticationModels
{
    public class RegisterPostModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm password did not match")]
        public string ConfirmPassword { get; set; }
    }
}
