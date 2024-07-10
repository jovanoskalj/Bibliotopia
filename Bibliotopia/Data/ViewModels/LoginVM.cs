using System.ComponentModel.DataAnnotations;

namespace Bibliotopia.Data.ViewModels
{
   
        public class LoginVM
        {
            [Display(Name = "Е-маил адреса")]
            [Required(ErrorMessage = "Задолжително поле")]
            public string EmailAddress { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    
}
