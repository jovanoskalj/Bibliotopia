using Bibliotopia.Data;
using Bibliotopia.Data.Base;
using Bibliotopia.Data.Static;
using Bibliotopia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotopia.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BooksController : Controller
    {
        private readonly IBooksService _context;

        public BooksController(IBooksService context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchQuery)
        {
            var allBooks = await _context.GetAllBooksAsync(); // Ensure this method includes eager loading
            var books = from b in allBooks
                        select b;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                books = books.Where(b => b.Title.Contains(searchQuery) || b.Description.Contains(searchQuery));
            }

            return View(books);
        }

        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _context.GetBookByIdAsync(id);
            return View(bookDetail);
        }
        //GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var booksDropdownsData = await _context.GetNewBookDropdownsValues();

            ViewBag.Publishers = new SelectList(booksDropdownsData.Publishers, "Id", "Name");

            ViewBag.Authors = new SelectList(booksDropdownsData.Authors, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _context.GetNewBookDropdownsValues();

                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");

                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _context.AddNewBooks(book);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _context.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                StartDate = bookDetails.StartDate,
                EndDate = bookDetails.EndDate,
                BookImageUrl = bookDetails.BookImageUrl,
                BookCategory = bookDetails.BookCategory,
                PublisherId = bookDetails.PublisherId,
                AuthorsIds = bookDetails.AuthorsBooks.Select(n => n.AuthorId).ToList(),
            };

            var bookDropdownsData = await _context.GetNewBookDropdownsValues();
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _context.GetNewBookDropdownsValues();

                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _context.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            await _context.DeleteBookAsync(id);
            return Ok();
        }


    }
}



