using System.ComponentModel.DataAnnotations;

namespace Bibliotopia.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Име и презиме")]
        [Required(ErrorMessage = "Задолжително поле.")]
        public string FullName { get; set; }

        [Display(Name = "Е-маил адреса")]
        [Required(ErrorMessage = "Задолжително поле.")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Лозинка")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Потврди лозинка")]
        [Required(ErrorMessage = "Задолжително поле.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Лозинките не се совпаѓаат")]
        public string ConfirmPassword { get; set; }
    }
}
