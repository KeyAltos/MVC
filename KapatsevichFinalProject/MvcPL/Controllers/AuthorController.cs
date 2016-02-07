using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        //
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
        public ActionResult Index()
        {
            return View(authorService.GetAllAuthorsEntities()
                .Select(author => Mapper.Map<BLLAuthor, AuthorIndexModel>(author)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var view = new AuthorCreateModel() { IsCreatingNow = true };
            return View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(AuthorCreateModel author)
        {
            if (ModelState.IsValid)
            {
                authorService.CreateAuthor(Mapper.Map<AuthorCreateModel, BLLAuthor>(author));
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Complete all fields");
            }
            return View(author);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            authorService.DeleteAuthor(Id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLAuthor, AuthorCreateModel>(authorService.GetById(Id));            
            view.IsCreatingNow = false;
            return View("Create", view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(AuthorCreateModel author)
        {
            if (ModelState.IsValid)
            {
                authorService.UpdateAuthor(Mapper.Map<AuthorCreateModel, BLLAuthor>(author));
            return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Complete all fields");
            }
            return View(author);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            ViewBag.ListAdminId = userService.GetAllAdminsId();
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);
            var view = Mapper.Map<BLLAuthor, UIAuthor>(authorService.GetById(Id));
            return View(view);
        }

        protected override void Dispose(bool disposing)
        {
            authorService.Dispose();
            bookService.Dispose();
            userService.Dispose();
            base.Dispose(disposing);
        }

    }
}
