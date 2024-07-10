using Bibliotopia.Data.ViewModels;
using Bibliotopia.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bibliotopia.Data.Base
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.AuthorsBooks)
                    .ThenInclude(ab => ab.Author)
                .ToListAsync();
        }

        public async Task AddNewBooks(NewBookVM newBook)
        {
            var newBookEntity = new Book()
            {
                Title = newBook.Title,
                Description = newBook.Description,
                Price = newBook.Price,
                BookImageUrl = newBook.BookImageUrl,
                PublisherId = newBook.PublisherId,
                StartDate = newBook.StartDate,
                EndDate = newBook.EndDate,
                BookCategory = newBook.BookCategory
            };
            await _context.Books.AddAsync(newBookEntity);
            await _context.SaveChangesAsync();

            // Add Book Authors
            foreach (var authorId in newBook.AuthorsIds)
            {
                var newAuthorBook = new Author_Books()
                {
                    BookId = newBookEntity.Id,
                    AuthorId = authorId
                };
                await _context.AuthorsBooks.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(b => b.BookPublisher)
                .Include(b => b.AuthorsBooks)
                    .ThenInclude(ab => ab.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            return bookDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.FullName).ToListAsync(),
                Publishers = await _context.BookPublishers.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
                dbBook.Title = data.Title;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.BookImageUrl = data.BookImageUrl;
                dbBook.PublisherId = data.PublisherId;
                dbBook.StartDate = data.StartDate;
                dbBook.EndDate = data.EndDate;
                dbBook.BookCategory = data.BookCategory;

                await _context.SaveChangesAsync();
            }

            // Remove existing authors
            var existingAuthorsDb = _context.AuthorsBooks.Where(n => n.BookId == data.Id).ToList();
            _context.AuthorsBooks.RemoveRange(existingAuthorsDb);
            await _context.SaveChangesAsync();

            // Add Books Authors
            foreach (var authorId in data.AuthorsIds)
            {
                var newAuthorBook = new Author_Books()
                {
                    BookId = data.Id,
                    AuthorId = authorId
                };
                await _context.AuthorsBooks.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

    }
}
