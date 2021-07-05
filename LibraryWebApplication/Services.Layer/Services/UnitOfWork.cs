using Data.Access.Layer;
using Services.Layer.Abstraction;
using System.Threading.Tasks;

namespace Services.Layer.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryWebApplicationContext _context;
        private BookRepository _bookRepository;
        private MemberRepository _memberRepository;
        private BookTransactionRepository _bookTransactionRepository;
        private AuthorRepository _authorRepository;

        public UnitOfWork(LibraryWebApplicationContext context)
        {
            _context = context;
        }
        public IBookRepository BookRepository => _bookRepository = _bookRepository ?? new BookRepository(_context);
        public IMemberRepository MemberRepository => _memberRepository = _memberRepository ?? new MemberRepository(_context);
        public IBookTransactionRepository BookTransactionRepository => _bookTransactionRepository = _bookTransactionRepository ?? new BookTransactionRepository(_context);
        public IAuthorRepository AuthorRepository => _authorRepository = _authorRepository ?? new AuthorRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
