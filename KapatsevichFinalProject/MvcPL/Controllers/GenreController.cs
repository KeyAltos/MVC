namespace MvcPL.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using BLL.Interface.Entities;
    using BLL.Interfacies.Services;

    using MvcPL.Models;

    [Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(UIGenre genre)
        {
            this.genreService.CreateGenre(Mapper.Map<UIGenre, BLLGenre>(genre));
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            this.genreService.DeleteGenre(Id);
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLGenre, UIGenre>(this.genreService.GetById(Id));
            return this.View("Create", view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(UIGenre genre)
        {
            this.genreService.UpdateGenre(Mapper.Map<UIGenre, BLLGenre>(genre));
            return this.RedirectToAction("Index");
        }

        // GET: /Genre/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return
                this.View(this.genreService.GetAllGenreEntities().Select(genre => Mapper.Map<BLLGenre, UIGenre>(genre)));
        }
    }
}