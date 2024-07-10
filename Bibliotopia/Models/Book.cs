using Bibliotopia.Data.Base;
using Bibliotopia.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotopia.Models
{
    public class Book : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наслов на книга:")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Опис:")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цена:")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "На продажба од:")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "На продажба до:")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Категорија:")]
        public BookCategory BookCategory { get; set; }

        [Required]
        [Display(Name = "Слика од корица:")]
        public string BookImageUrl { get; set; }

        // Relationships
        public List<Author_Books> AuthorsBooks { get; set; }

        // Publisher
        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public BookPublisher BookPublisher { get; set; }
    }
}
