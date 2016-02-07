using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interfacies.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {            
            this.genreService = genreService;
        }
        //
        // GET: /Genre/

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(genreService.GetAllGenreEntities()
                .Select(genre => Mapper.Map<BLLGenre, UIGenre>(genre)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {            
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(UIGenre genre)
        {
            genreService.CreateGenre(Mapper.Map<UIGenre, BLLGenre>(genre));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            genreService.DeleteGenre(Id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLGenre, UIGenre>(genreService.GetById(Id));            
            return View("Create", view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(UIGenre genre)
        {
            genreService.UpdateGenre(Mapper.Map<UIGenre, BLLGenre>(genre));
            return RedirectToAction("Index");
        }

    }
}
