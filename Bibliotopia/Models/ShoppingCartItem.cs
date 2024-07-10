using System.ComponentModel.DataAnnotations;

namespace Bibliotopia.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Book Book { get; set; }
       

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
