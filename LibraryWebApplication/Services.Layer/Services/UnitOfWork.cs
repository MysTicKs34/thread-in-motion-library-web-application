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
        private BookTypeRepository _bookTypeRepository;
        private TypeRepository _typeRepository;

        public UnitOfWork(LibraryWebApplicationContext context)
        {
            this._context = context;
        }
        public IBookRepository BookRepository => _bookRepository = _bookRepository ?? new BookRepository(_context);

        public IMemberRepository MemberRepository => _memberRepository = _memberRepository ?? new MemberRepository(_context);

        public IBookTransactionRepository BookTransactionRepository => _bookTransactionRepository = _bookTransactionRepository ?? new BookTransactionRepository(_context);

        public IAuthorRepository AuthorRepository => _authorRepository = _authorRepository ?? new AuthorRepository(_context);

        public IBookTypeRepository BookTypeRepository => _bookTypeRepository = _bookTypeRepository ?? new BookTypeRepository(_context);

        public ITypeRepository TypeRepository => _typeRepository = _typeRepository ?? new TypeRepository(_context);

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
