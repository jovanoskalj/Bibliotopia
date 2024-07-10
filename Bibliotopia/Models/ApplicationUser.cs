using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bibliotopia.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Име и презиме")]
        public string FullName { get; set; }
    }
}
