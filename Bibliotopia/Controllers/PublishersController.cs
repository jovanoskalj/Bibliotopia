using Bibliotopia.Data;
using Bibliotopia.Data.Base;
using Bibliotopia.Data.Static;
using Bibliotopia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotopia.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PublishersController : Controller
    {
        private readonly IPublishersService _context;

        public PublishersController(IPublishersService context)
        {
            _context = context;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index(string searchQuery)
        {
            var publishers = from p in await _context.GetAll()
                             select p;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                publishers = publishers.Where(p => p.Name.Contains(searchQuery) || p.Description.Contains(searchQuery));
            }

            var allPublishers =publishers.ToList();
            return View(allPublishers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogoUrl,Name,Description")] BookPublisher bookPublisher)
        {
            if (!ModelState.IsValid)
            {
                return View(bookPublisher);
            }

            await _context.AddAsync(bookPublisher);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _context.GetById(id);

            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _context.GetById(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoUrl,Name,Description")] BookPublisher bookPublisher)
        {
            if (!ModelState.IsValid)
            {
                return View(bookPublisher);
            }

            await _context.UpdateAsync(id, bookPublisher);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _context.GetById(id);
            if (publisherDetails == null) return View("NotFound");

            await _context.DeleteAsync(id);
            return Ok(); // Return an appropriate response
        }

    }

}
