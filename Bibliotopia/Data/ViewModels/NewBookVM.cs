using Bibliotopia.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bibliotopia.Models
{
    public class NewBookVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наслов на книгата")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цена во денари")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "На продажба од")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "На продажба до")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Категорија")]
        public BookCategory BookCategory { get; set; }

        [Required]
        [Display(Name = "Слика од корица (линк)")]
        public string BookImageUrl { get; set; }

        // Relationships
        [Required]
        [Display(Name = "Aвтори")]
        public List<int> AuthorsIds { get; set; }

        // Publisher
        [Required]
        [Display(Name = "Издавачки куќи")]
        public int PublisherId { get; set; }
    }
}
