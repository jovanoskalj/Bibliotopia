using Bibliotopia.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Bibliotopia.Models
{
    public class Author:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Слика:")]
        [Required (ErrorMessage ="Задолжително поле")]
        public string PictureURL { get; set; }
        [Required(ErrorMessage = "Задолжително поле")]
        [Display(Name = "Име и презиме:")]
        [StringLength(50,MinimumLength =3)]
        public string FullName { get; set; }
        [Display(Name = "Биографија:")]
        [Required(ErrorMessage = "Задолжително поле")]
        public string Bio { get; set; }

        //Relationships
     

        public List<Author_Books>? Authors_Books { get; set; }
    }
}
