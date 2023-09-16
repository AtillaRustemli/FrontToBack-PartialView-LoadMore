using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities.DemoEntities;
using FrontToBack_PartialView_LoadMore.ViewModels.AdminBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DemoController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DemoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var book=_appDbContext.Book
                .Include(b=>b.BookGenre)
                .ThenInclude(bg=>bg.Genre)
                .Include(b=>b.BookAuthor)
                .ThenInclude(ba=>ba.Author)
                .ToList();
            return View(book);
        }
        public IActionResult Create()
        {

            ViewBag.Author=_appDbContext.Author.ToList();
            ViewBag.Genre=_appDbContext.Genre.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateBookVM createBookVM)
        {
            ViewBag.Author=_appDbContext.Author.ToList();
            ViewBag.Genre=_appDbContext.Genre.ToList();

            if (!ModelState.IsValid) return View();
            Book book = new();
            book.Name = createBookVM.Name;
            foreach (var genreId in createBookVM.GenreId)
            {
                BookGenre bookGenre = new();
                bookGenre.BookId = book.Id;
                bookGenre.GenreId = genreId;
                book.BookGenre.Add(bookGenre);
            }
            foreach (var authorId in createBookVM.AuthorId)
            {
                BookAuthor bookAuthor = new();
                bookAuthor.BookId = book.Id;
                bookAuthor.AuthorId = authorId;
                book.BookAuthor.Add(bookAuthor);
            }
            _appDbContext.Book.Add(book);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
