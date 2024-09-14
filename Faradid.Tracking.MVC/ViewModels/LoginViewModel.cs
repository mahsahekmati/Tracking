using System.ComponentModel.DataAnnotations;

namespace Faradid.Tracking.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
