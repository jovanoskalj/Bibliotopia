using Bibliotopia.Data.ViewModels;
using Bibliotopia.Models;

namespace Bibliotopia.Data.Base
{
    public interface IBooksService : IEntityBaseRepository <Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task <Book> GetBookByIdAsync(int id);
        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBooks(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
        Task DeleteBookAsync(int id);   
    }
}
