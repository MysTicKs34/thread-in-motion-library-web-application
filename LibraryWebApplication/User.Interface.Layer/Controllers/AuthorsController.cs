using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System.Collections.Generic;

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
            return View(authors);
        }

        // GET: AuthorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                _uOw.AuthorRepository.AddAsync(author);
                _uOw.CommitAsync();
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
            return View();
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
