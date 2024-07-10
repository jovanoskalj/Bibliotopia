using Bibliotopia.Models;

namespace Bibliotopia.Data.Base
{
    public class PublishersService : EntityBaseRepository<BookPublisher>, IPublishersService
    {
        public PublishersService(AppDbContext context):base(context)
        {
            
        }
    }
}
