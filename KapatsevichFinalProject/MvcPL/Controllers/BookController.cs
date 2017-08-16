namespace MvcPL.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using BLL.Interface.Entities;
    using BLL.Interface.Services;
    using BLL.Interfacies.Services;

    using MvcPL.Infrastructura;
    using MvcPL.Models;

    [Authorize]
    public class BookController : Controller
    {
        private readonly IAuthorService authorService;

        private readonly IBookService bookService;

        private readonly IGenreService genreService;

        private readonly IGradeService gradeService;

        private readonly IUserService userService;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            IGradeService gradeService,
            IGenreService genreService,
            IUserService userService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.gradeService = gradeService;
            this.genreService = genreService;
            this.userService = userService;
        }

        public ActionResult BookSearchIndex()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult BookSearchPartial(string title, string authorFirstName, string authorLastName)
        {
            this.ViewBag.ListMyBooksId =
                this.userService.GetAllUserBooksId(this.userService.GetIdByUsername(this.User.Identity.Name));

            var retrievedBooks = this.bookService.SearchBook(title, authorFirstName, authorLastName);

            return this.PartialView(Mapper.Map<IEnumerable<BLLBook>, IEnumerable<BookIndexModel>>(retrievedBooks));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var getListOfAuthors =
                Mapper.Map<List<BLLAuthor>, List<AuthorForBookModel>>(
                    this.authorService.GetAllAuthorsEntities().ToList());
            this.ViewBag.ListOfGenres =
                Mapper.Map<List<BLLGenre>, List<UIGenre>>(this.genreService.GetAllGenreEntities().ToList());
            var view = new BookCreateModel() { ListOfAuthors = getListOfAuthors, IsCreatingNow = true };
            return this.View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BookCreateModel book, int[] selectedGenres)
        {
            this.bookService.CreateBook(Mapper.Map<BookCreateModel, BLLBook>(book), selectedGenres);
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            this.bookService.DeleteBook(Id);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var view = Mapper.Map<BLLBook, UIBook>(this.bookService.GetById(Id));
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            this.ViewBag.CurrentUserBooksId = this.userService.GetAllUserBooksId(this.ViewBag.CurrentUserId);
            this.ViewBag.LastThreeBookGrades = this.gradeService.GetAllBookGrades(Id).ToList();
            this.ViewBag.ListAdminId = this.userService.GetAllAdminsId();
            return this.View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLBook, BookCreateModel>(this.bookService.GetById(Id));
            view.ListOfAuthors =
                Mapper.Map<List<BLLAuthor>, List<AuthorForBookModel>>(
                    this.authorService.GetAllAuthorsEntities().ToList());
            this.ViewBag.ListOfGenres =
                Mapper.Map<List<BLLGenre>, List<UIGenre>>(this.genreService.GetAllGenreEntities().ToList());
            view.IsCreatingNow = false;
            return this.View("Create", view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BookCreateModel book, int[] selectedGenres)
        {
            this.bookService.UpdateBook(Mapper.Map<BookCreateModel, BLLBook>(book), selectedGenres);
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index(int page = 1)
        {
            var listOfBooksFromDB =
                this.bookService.GetAllBookEntities().Select(book => Mapper.Map<BLLBook, BookIndexModel>(book));

            int pageSize = 15;
            IEnumerable<BookIndexModel> booksPerPages = listOfBooksFromDB.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
                                    {
                                        PageNumber = page,
                                        PageSize = pageSize,
                                        TotalItems = listOfBooksFromDB.Count()
                                    };
            this.ViewBag.CurrentUserBooksId =
                this.userService.GetAllUserBooksId(this.userService.GetIdByUsername(this.User.Identity.Name));
            var view = new PanginationViewModel<BookIndexModel> { PageInfo = pageInfo, ListOfItems = booksPerPages };
            return this.View(view);
        }

        public ActionResult ShowBookGrades(int Id)
        {
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            return
                this.View(
                    Mapper.Map<IEnumerable<BLLGrade>, IEnumerable<UIGrade>>(this.gradeService.GetAllBookGrades(Id)));
        }

        protected override void Dispose(bool disposing)
        {
            this.authorService.Dispose();
            this.bookService.Dispose();
            this.userService.Dispose();
            this.gradeService.Dispose();
            this.genreService.Dispose();
            base.Dispose(disposing);
        }
    }
}