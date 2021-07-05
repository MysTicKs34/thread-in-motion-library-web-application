using Data.Access.Layer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Layer.Abstraction;
using System.Collections.Generic;

namespace User.Interface.Layer.Controllers
{
    public class MembersController : Controller
    {
        private readonly ILogger<MembersController> _logger;
        private IUnitOfWork _uOw;

        public MembersController(ILogger<MembersController> logger, IUnitOfWork uOw)
        {
            _logger = logger;
            _uOw = uOw;
        }
        // GET: MembersController
        public ActionResult Index()
        {
            IEnumerable<Members> members = _uOw.MemberRepository.GetAllAsync().GetAwaiter().GetResult();
            return View(members);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int id)
        {
            Members member = _uOw.MemberRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            return View(member);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Members member)
        {
            try
            {
                _uOw.MemberRepository.AddAsync(member).GetAwaiter().GetResult();
                _uOw.CommitAsync().GetAwaiter().GetResult();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int id)
        {
            Members member = _uOw.MemberRepository.GetByIdAsync(id).GetAwaiter().GetResult();
            return View(member);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Members member)
        {
            try
            {
                _uOw.MemberRepository.UpdateAsync(member).GetAwaiter().GetResult();
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
