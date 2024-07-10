using Bibliotopia.Models;

namespace Bibliotopia.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
           
            Publishers = new List<BookPublisher>();
            Authors = new List<Author>();
        }

 
        public List<BookPublisher> Publishers { get; set; }
        public List<Author> Authors { get; set; }
    }
}

