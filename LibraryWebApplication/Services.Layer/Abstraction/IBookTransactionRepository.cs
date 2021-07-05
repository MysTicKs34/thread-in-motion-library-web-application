using Data.Access.Layer.Classes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Layer.Abstraction
{
    public interface IBookTransactionRepository : IGenericRepository<BookTransactions>
    {
        public Task<IEnumerable<BookTransactions>> GetAllWithBooksAndMembersAsync();
        public Task<BookTransactions> GetAllWithBooksAndMembersByIdAsync(int id);
        public Task<List<BookTransactions>> GetAllWithBooksAndMembersForPredicateAsync();
    }
}
