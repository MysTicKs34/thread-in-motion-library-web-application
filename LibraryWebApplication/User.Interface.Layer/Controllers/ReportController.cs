using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System.Collections.Generic;

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
            IEnumerable<BookTransactions> bookTransactions = _uOw.BookTransactionRepository.GetAllWithBooksAndMembersAsync().GetAwaiter().GetResult();
            return View(bookTransactions);
        }
    }
}
