using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Interface.Layer.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ILogger<AuthorsController> _logger;
        private IUnitOfWork _uOw;

        public AuthorsController(ILogger<AuthorsController> logger, IUnitOfWork uOw)
        {
            _logger = logger;
            _uOw = uOw;
        }
        // GET: AuthorsController
        public ActionResult Index()
        {
            IEnumerable<Authors> authors = _uOw.AuthorRepository.GetAllAsync().GetAwaiter().GetResult();
            _uOw.Dispose();
            return View(authors);
        }

        // GET: AuthorsController/Details/5
        public ActionResult Details(int id)
        {
            Authors author = _uOw.AuthorRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            _uOw.Dispose();
            return View(author);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Authors author)
        {
            try
            {
                _uOw.AuthorRepository.AddAsync(author).GetAwaiter().GetResult();
                _uOw.CommitAsync().GetAwaiter().GetResult();
                _uOw.Dispose();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public ActionResult Edit(int id)
        {
            Authors author = _uOw.AuthorRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            _uOw.Dispose();
            return View(author);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Authors author)
        {
            try
            {
                _uOw.AuthorRepository.UpdateAsync(author).GetAwaiter().GetResult();
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
