using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System.Collections.Generic;

namespace User.Interface.Layer.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private IUnitOfWork _uOw;

        public BooksController(ILogger<BooksController> logger, IUnitOfWork uOw)
        {
            _logger = logger;
            _uOw = uOw;
        }
        // GET: BooksController
        public ActionResult Index()
        {
            IEnumerable<Books> books = _uOw.BookRepository.GetAllWithAuthorAsync().GetAwaiter().GetResult();
            _uOw.Dispose();
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            Books book = _uOw.BookRepository.GetByIdWithAuthorAsync(id).GetAwaiter().GetResult();
            _uOw.Dispose();
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            ViewBag.Authors = _uOw.AuthorRepository.GetAllAsync().GetAwaiter().GetResult();
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Books book)
        {
            try
            {
                _uOw.BookRepository.AddAsync(book).GetAwaiter().GetResult();
                _uOw.CommitAsync().GetAwaiter().GetResult();
                _uOw.Dispose();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Authors = _uOw.AuthorRepository.GetAllAsync().GetAwaiter().GetResult();
            Books book = _uOw.BookRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            _uOw.Dispose();
            return View(book);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Books book)
        {
            try
            {
                _uOw.BookRepository.UpdateAsync(book).GetAwaiter().GetResult();
                _uOw.CommitAsync().GetAwaiter().GetResult();
                _uOw.Dispose();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
