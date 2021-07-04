using System;
using System.Threading.Tasks;

namespace Services.Layer.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IMemberRepository MemberRepository { get; }
        IBookTransactionRepository BookTransactionRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IBookTypeRepository BookTypeRepository { get; }
        ITypeRepository TypeRepository { get; }
        Task<int> CommitAsync();
    }
}
