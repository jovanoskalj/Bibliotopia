using Bibliotopia.Data.Services;
using Bibliotopia.Data.Static;
using Bibliotopia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
[Authorize(Roles =UserRoles.Admin)]
public class AuthorsController : Controller
{
    private readonly IAuthorsService _context;

    public AuthorsController(IAuthorsService service)
    {
        _context = service;
    }
    [AllowAnonymous]

    public async Task<IActionResult> Index(string searchQuery)
    {
        var authors = await _context.GetAll();

        if (!string.IsNullOrEmpty(searchQuery))
        {
            authors = authors.Where(a => a.FullName.Contains(searchQuery) || a.Bio.Contains(searchQuery));
        }

        return View(authors.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FullName,PictureURL,Bio")] Author author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        await _context.AddAsync(author);
        return RedirectToAction(nameof(Index));
    }
    [AllowAnonymous]

    public async Task<IActionResult> Details(int id)
    {
        var actorDetails = await _context.GetById(id);

        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var authorDetails = await _context.GetById(id);
        if (authorDetails == null) return View("NotFound");
        return View(authorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,PictureURL,Bio")] Author author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        await _context.UpdateAsync(id, author);
        return RedirectToAction(nameof(Index));
    }

   

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var authorDetails = await _context.GetById(id);
        if (authorDetails == null) return View("NotFound");

        await _context.DeleteAsync(id);
        return Ok(); // Return an appropriate response
    }

}
