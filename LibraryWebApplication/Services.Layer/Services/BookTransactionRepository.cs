using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Microsoft.EntityFrameworkCore;
using Services.Layer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return await _context.Set<BookTransactions>().Include("Book").Include("Member").ToListAsync();
        }

        public async Task<BookTransactions> GetAllWithBooksAndMembersByIdAsync(int id)
        {
            return await _context.Set<BookTransactions>().Include("Book").Include("Member").FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<List<BookTransactions>> GetAllWithBooksAndMembersForPredicateAsync()
        {
            return await _context.Set<BookTransactions>().Include("Book").Include("Member").ToListAsync();
        }

    }
}
