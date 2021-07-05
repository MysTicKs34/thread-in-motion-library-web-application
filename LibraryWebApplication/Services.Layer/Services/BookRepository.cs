using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Microsoft.EntityFrameworkCore;
using Services.Layer.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Layer.Services
{
    public class BookRepository : GenericRepository<Books>, IBookRepository
    {
        public BookRepository(LibraryWebApplicationContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Books>> GetAllWithAuthorAsync()
        {
            return await _context.Set<Books>().Include("Author").ToListAsync();
        }

        public async Task<Books> GetByIdWithAuthorAsync(int id)
        {
            return await _context.Set<Books>().Include("Author").FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
