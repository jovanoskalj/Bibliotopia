using Bibliotopia.Data.Base;
using Bibliotopia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bibliotopia.Data.Services
{
    public interface IAuthorsService : IEntityBaseRepository<Author>

    {
        /*  Task<IEnumerable<Author>> GetAll();
          Task<Author> GetById(int id);
          Task AddAsync(Author author);
          Task UpdateAsync(int id, Author newAuthor);
          Task DeleteAsync(int id);
      }*/
    }
}
