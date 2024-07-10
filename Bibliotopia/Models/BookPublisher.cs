using Bibliotopia.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Bibliotopia.Models
{
    public class BookPublisher : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Лого: ")]
        public string LogoUrl { get; set; }
        [Required]
        [Display(Name="Издавачка куќа: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Опис: ")]
        public string Description { get; set; }

        //Relationships
        public List<Book>? Books { get; set; }
    }
}
