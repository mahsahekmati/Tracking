using System.ComponentModel.DataAnnotations;

namespace Faradid.Tracking.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
