using Bibliotopia.Data.Base;
using Bibliotopia.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bibliotopia.Data.Services
{
    public class AuthorsService : EntityBaseRepository<Author>, IAuthorsService
    {
        /* private readonly AppDbContext _context;*/

        public AuthorsService(AppDbContext context) : base(context)
        {

        }

        /* public async Task<IEnumerable<Author>> GetAll()
         {
             return await _context.Authors.ToListAsync();
         }

         public async Task<Author> GetById(int id)
         {
             return await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
         }

         public async Task AddAsync(Author author)
         {
             _context.Authors.Add(author);
             await _context.SaveChangesAsync();  // Ensure the changes are committed to the database
         }

         public async Task UpdateAsync(int id, Author newAuthor)
         {
             var author = await _context.Authors.FindAsync(id);
             if (author != null)
             {
                 author.FullName = newAuthor.FullName;
                 author.PictureURL = newAuthor.PictureURL;
                 author.Bio = newAuthor.Bio;
                 await _context.SaveChangesAsync();
             }
             else
             {
                 throw new InvalidOperationException("Author not found.");
             }
         }

         public async Task DeleteAsync(int id)
         {
             var author = await _context.Authors.FindAsync(id);
             if (author != null)
             {
                 _context.Authors.Remove(author);
                 await _context.SaveChangesAsync();
             }
             else
             {
                 throw new InvalidOperationException("Author not found.");
             }
         }
     }*/
    }
}
