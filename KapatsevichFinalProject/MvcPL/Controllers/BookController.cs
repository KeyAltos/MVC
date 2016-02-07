using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Interfacies.Services;
using MvcPL.Infrastructura;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGradeService gradeService;
        private readonly IGenreService genreService;
        private readonly IUserService userService;

        public BookController(IBookService bookService, IAuthorService authorService, IGradeService gradeService, IGenreService genreService, IUserService userService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.gradeService = gradeService;
            this.genreService = genreService;
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index(int page = 1)
        {
            var listOfBooksFromDB= bookService.GetAllBookEntities().Select(book => Mapper.Map<BLLBook, BookIndexModel>(book));

            int pageSize = 15; 
            IEnumerable<BookIndexModel> booksPerPages = listOfBooksFromDB.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = listOfBooksFromDB.Count() };
            ViewBag.CurrentUserBooksId = userService.GetAllUserBooksId(userService.GetIdByUsername(User.Identity.Name));
            var view = new PanginationViewModel<BookIndexModel> { PageInfo = pageInfo, ListOfItems = booksPerPages };
            return View(view);   
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var getListOfAuthors = Mapper.Map<List<BLLAuthor>, List<AuthorForBookModel>>(authorService.GetAllAuthorsEntities().ToList());
            ViewBag.ListOfGenres = Mapper.Map<List<BLLGenre>, List<UIGenre>>(genreService.GetAllGenreEntities().ToList());
            var view = new BookCreateModel() { ListOfAuthors = getListOfAuthors, IsCreatingNow = true };
            return View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BookCreateModel book, int[] selectedGenres)
        {
           
            bookService.CreateBook(Mapper.Map<BookCreateModel, BLLBook>(book), selectedGenres);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            bookService.DeleteBook(Id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLBook, BookCreateModel>(bookService.GetById(Id));
            view.ListOfAuthors = Mapper.Map<List<BLLAuthor>, List<AuthorForBookModel>>(authorService.GetAllAuthorsEntities().ToList());
            ViewBag.ListOfGenres = Mapper.Map<List<BLLGenre>, List<UIGenre>>(genreService.GetAllGenreEntities().ToList());
            view.IsCreatingNow = false;
            return View("Create", view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BookCreateModel book, int[] selectedGenres)
        {            
            bookService.UpdateBook(Mapper.Map<BookCreateModel, BLLBook>(book),selectedGenres);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var view = Mapper.Map<BLLBook, UIBook>(bookService.GetById(Id));
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);
            ViewBag.CurrentUserBooksId = userService.GetAllUserBooksId(ViewBag.CurrentUserId);
            ViewBag.LastThreeBookGrades = gradeService.GetAllBookGrades(Id).ToList();
            ViewBag.ListAdminId = userService.GetAllAdminsId();
            return View(view);
        }

        [HttpPost]
        public ActionResult BookSearchPartial(string title,string authorFirstName, string authorLastName)
        {
            ViewBag.ListMyBooksId = userService.GetAllUserBooksId(userService.GetIdByUsername(User.Identity.Name));

            var retrievedBooks = bookService.SearchBook(title,authorFirstName,authorLastName);
            
            return PartialView(Mapper.Map < IEnumerable<BLLBook>, IEnumerable<BookIndexModel>> (retrievedBooks));
        }

        public ActionResult BookSearchIndex()
        {            
            return View();
        }

        public ActionResult ShowBookGrades(int Id)
        {            
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);            
            return View(Mapper.Map<IEnumerable<BLLGrade>, IEnumerable<UIGrade>>(gradeService.GetAllBookGrades(Id)));
        }

        protected override void Dispose(bool disposing)
        {
            authorService.Dispose();
            bookService.Dispose();
            userService.Dispose();
            gradeService.Dispose();
            genreService.Dispose();            
            base.Dispose(disposing);
        }
    }
}
