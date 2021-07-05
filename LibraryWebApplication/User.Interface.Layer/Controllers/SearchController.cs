using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Interface.Layer.Models;

namespace User.Interface.Layer.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private IUnitOfWork _uOw;

        public SearchController(ILogger<SearchController> logger, IUnitOfWork uOw)
        {
            _logger = logger;
            _uOw = uOw;
        }
        // GET: SearchController
        public ActionResult Index()
        {
            SearchViewModel searchViewModel = new();
            searchViewModel.Authors = _uOw.AuthorRepository.GetAllAsync().GetAwaiter().GetResult();
            return View(searchViewModel);
        }
        // POST: SearchController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            IEnumerable<Books> books = _uOw.BookRepository.GetAllAsync().GetAwaiter().GetResult();
            books = books.Where(x => x.Name.Contains(searchViewModel.Name ?? "***") || x.LoanDate.Year == searchViewModel.LoanDate.Year || x.AuthorID == searchViewModel.AuthorId || x.ISBN == searchViewModel.ISBN).ToList();
            _uOw.Dispose();
            return View(books);
        }
    }
}
