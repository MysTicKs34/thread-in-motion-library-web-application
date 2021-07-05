using Data.Access.Layer.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Layer.Abstraction
{
    public interface IBookTransactionRepository : IGenericRepository<BookTransactions>
    {
        public Task<IEnumerable<BookTransactions>> GetAllWithBooksAndMembersAsync();
        public Task<BookTransactions> GetAllWithBooksAndMembersByIdAsync(int id);
        public Task<BookTransactions> GetAllWithBooksAndMembersByBookIdAsync(int bookId);
    }
}
