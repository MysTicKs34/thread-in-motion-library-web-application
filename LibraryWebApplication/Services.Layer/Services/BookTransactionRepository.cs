using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Microsoft.EntityFrameworkCore;
using Services.Layer.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Layer.Services
{
    public class BookTransactionRepository : GenericRepository<BookTransactions>, IBookTransactionRepository
    {
        public BookTransactionRepository(LibraryWebApplicationContext context)
            : base(context)
        { }

        public async Task<IEnumerable<BookTransactions>> GetAllWithBooksAndMembersAsync()
        {
            return await _context.Set<BookTransactions>().Include("Book").Include("Member").Where(x => x.Book.StockQuantity > 0).ToListAsync();
        }

        public async Task<BookTransactions> GetAllWithBooksAndMembersByIdAsync(int id)
        {
            return await _context.Set<BookTransactions>().Include("Book").Include("Member").FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<BookTransactions> GetAllWithBooksAndMembersByBookIdAsync(int bookId)
        {
            return await _context.Set<BookTransactions>().Include("Book").Include("Member").FirstOrDefaultAsync(x => x.Book.ID == bookId && x.Book.StockQuantity > 0);
        }

    }
}
