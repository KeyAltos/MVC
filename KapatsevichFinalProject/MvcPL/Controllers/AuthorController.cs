namespace MvcPL.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using BLL.Interface.Entities;
    using BLL.Interface.Services;

    using MvcPL.Models;

    [Authorize]
    public class AuthorController : Controller
    {
        // GET: /Author/
        private readonly IAuthorService authorService;

        private readonly IBookService bookService;

        private readonly IUserService userService;

        public AuthorController(IBookService bookService, IAuthorService authorService, IUserService userService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var view = new AuthorCreateModel() { IsCreatingNow = true };
            return this.View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(AuthorCreateModel author)
        {
            if (this.ModelState.IsValid)
            {
                this.authorService.CreateAuthor(Mapper.Map<AuthorCreateModel, BLLAuthor>(author));
                return this.RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Complete all fields");
            }

            return this.View(author);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            this.authorService.DeleteAuthor(Id);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            this.ViewBag.ListAdminId = this.userService.GetAllAdminsId();
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            var view = Mapper.Map<BLLAuthor, UIAuthor>(this.authorService.GetById(Id));
            return this.View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLAuthor, AuthorCreateModel>(this.authorService.GetById(Id));
            view.IsCreatingNow = false;
            return this.View("Create", view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(AuthorCreateModel author)
        {
            if (this.ModelState.IsValid)
            {
                this.authorService.UpdateAuthor(Mapper.Map<AuthorCreateModel, BLLAuthor>(author));
                return this.RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Complete all fields");
            }

            return this.View(author);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return
                this.View(
                    this.authorService.GetAllAuthorsEntities()
                        .Select(author => Mapper.Map<BLLAuthor, AuthorIndexModel>(author)));
        }

        protected override void Dispose(bool disposing)
        {
            this.authorService.Dispose();
            this.bookService.Dispose();
            this.userService.Dispose();
            base.Dispose(disposing);
        }
    }
}