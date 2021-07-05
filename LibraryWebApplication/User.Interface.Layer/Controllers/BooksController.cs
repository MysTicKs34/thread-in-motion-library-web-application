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
            IEnumerable<Books> books = _uOw.BookRepository.GetAllAsync().GetAwaiter().GetResult();
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            Books book = _uOw.BookRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
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
            Books book = _uOw.BookRepository.GetByIdAsync(id).GetAwaiter().GetResult();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
