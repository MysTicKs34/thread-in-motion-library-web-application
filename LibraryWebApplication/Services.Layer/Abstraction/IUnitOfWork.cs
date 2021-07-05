﻿using System;
using System.Threading.Tasks;

namespace Services.Layer.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IMemberRepository MemberRepository { get; }
        IBookTransactionRepository BookTransactionRepository { get; }
        Task<int> CommitAsync();
    }
}
