using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System;
using System.Collections.Generic;

namespace User.Interface.Layer.Controllers
{
    public class RezervationsController : Controller
    {
        private static int updatedBookId;
        private readonly ILogger<RezervationsController> _logger;
        private IUnitOfWork _uOw;

        public RezervationsController(ILogger<RezervationsController> logger, IUnitOfWork uOw)
        {
            _logger = logger;
            _uOw = uOw;
        }
        // GET: RezervationController
        public ActionResult Index()
        {
            IEnumerable<BookTransactions> bookTransactions = _uOw.BookTransactionRepository.GetAllWithBooksAndMembersAsync().GetAwaiter().GetResult();
            return View(bookTransactions);
        }

        // GET: RezervationController/Details/5
        public ActionResult Details(int id)
        {
            BookTransactions bookTransaction = _uOw.BookTransactionRepository.GetAllWithBooksAndMembersByIdAsync(id).GetAwaiter().GetResult();
            return View(bookTransaction);
        }

        // GET: RezervationController/Create
        public ActionResult Create()
        {
            ViewBag.Books = _uOw.BookRepository.GetAllAsync().GetAwaiter().GetResult();
            ViewBag.Members = _uOw.MemberRepository.GetAllAsync().GetAwaiter().GetResult();
            return View();
        }

        // POST: RezervationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookTransactions bookTransaction)
        {
            try
            {
                Books book = _uOw.BookRepository.GetByIdAsync(bookTransaction.BookID).GetAwaiter().GetResult();
                if (book.StockQuantity > 0)
                {
                    _uOw.BookTransactionRepository.AddAsync(bookTransaction).GetAwaiter().GetResult();
                    bookTransaction.Book.StockQuantity--;
                    _uOw.BookRepository.UpdateAsync(bookTransaction.Book).GetAwaiter().GetResult();
                    _uOw.CommitAsync().GetAwaiter().GetResult();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception($"Sorry. We dont have this book enough!");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RezervationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Books = _uOw.BookRepository.GetAllAsync().GetAwaiter().GetResult();
            ViewBag.Members = _uOw.MemberRepository.GetAllAsync().GetAwaiter().GetResult();
            BookTransactions bookTransaction = _uOw.BookTransactionRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            updatedBookId = bookTransaction.BookID;
            return View(bookTransaction);
        }

        // POST: RezervationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookTransactions bookTransaction)
        {
            try
            {
                Books book = _uOw.BookRepository.GetByIdAsync(bookTransaction.BookID).GetAwaiter().GetResult();
                if (book.StockQuantity > 0)
                {
                    _uOw.BookTransactionRepository.UpdateAsync(bookTransaction).GetAwaiter().GetResult();
                    if (updatedBookId != bookTransaction.BookID)
                    {
                        bookTransaction.Book.StockQuantity--;
                        _uOw.BookRepository.UpdateAsync(bookTransaction.Book).GetAwaiter().GetResult();
                        Books updatedBook = _uOw.BookRepository.GetByIdAsync(updatedBookId).GetAwaiter().GetResult();
                        updatedBook.StockQuantity++;
                        _uOw.BookRepository.UpdateAsync(updatedBook);
                    }
                    _uOw.CommitAsync().GetAwaiter().GetResult();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception($"Sorry. We dont have this book enough!");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
