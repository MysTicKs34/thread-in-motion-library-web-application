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
            return View(new SearchViewModel());
        }
        // POST: SearchController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            IEnumerable<Books> books = _uOw.BookRepository.GetAllAsync().GetAwaiter().GetResult();
            books = books.Where(x => x.Name.Contains(searchViewModel.Name) || x.LoanDate.Year == searchViewModel.LoanDate.Year).ToList();
            return View(books);
        }
    }
}
