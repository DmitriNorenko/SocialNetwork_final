using System.ComponentModel.DataAnnotations;

namespace SocialNetwork_final.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} " +
           "и максимум {1} символов", MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "UrlReturn")]
        public string ReturnUrl { get; set; } = "/Home/Privacy";
    }
}
