using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Services.Layer.Abstraction;

namespace Services.Layer.Services
{
    public class BookTransactionRepository: GenericRepository<BookTransactions>, IBookTransactionRepository
    {
        public BookTransactionRepository(LibraryWebApplicationContext context)
            : base(context)
        { }
    }
}
