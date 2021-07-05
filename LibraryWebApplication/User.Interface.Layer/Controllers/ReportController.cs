using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace User.Interface.Layer.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private IUnitOfWork _uOw;

        public ReportController(ILogger<ReportController> logger, IUnitOfWork uOw)
        {
            _logger = logger;
            _uOw = uOw;
        }
        // GET: ReportController
        public ActionResult Index()
        {
            IEnumerable<BookTransactions> bookTransactions = _uOw.BookTransactionRepository.GetAllWithBooksAndMembersForPredicateAsync().GetAwaiter().GetResult().Where(x => x.ReturnDate.Subtract(DateTime.Today).Days <= 2 || DateTime.Today.Subtract(x.ReturnDate).Days < 0).ToList();
            _uOw.Dispose();
            return View(bookTransactions);
        }
    }
}
