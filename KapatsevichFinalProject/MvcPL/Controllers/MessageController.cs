namespace MvcPL.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using BLL.Interface.Entities;
    using BLL.Interface.Services;
    using BLL.Interfacies.Services;

    using MvcPL.Models;

    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;

        private readonly IUserService userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AdminDetails(int Id)
        {
            var message = this.messageService.GetByIdMessage(Id);
            var view =
                Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(
                    this.messageService.GetUserToUserMessages(message.SenderId, message.ReceiverId));
            return this.View(view);
        }

        [HttpGet]
        public ActionResult CorrectMessage(int Id)
        {
            return this.View(Mapper.Map<BLLMessage, UIMessage>(this.messageService.GetByIdMessage(Id)));
        }

        [HttpPost]
        public ActionResult CorrectMessage(UIMessage message)
        {
            this.messageService.CorrectMessage(Mapper.Map<UIMessage, BLLMessage>(message));
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMessage(int Id)
        {
            this.messageService.DeleteMessage(Id);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var myId = this.userService.GetIdByUsername(this.User.Identity.Name);
            var view =
                Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(
                    this.messageService.GetUserToUserMessages(myId, Id));
            this.ViewBag.CurrentUserId = myId;
            this.ViewBag.OtherUserId = Id;
            return this.View(view);
        }

        [HttpPost]
        public ActionResult Details(UIMessage message)
        {
            message.Id = 0;
            message.MessageSendingTime = DateTime.Now;
            this.messageService.SendMessage(Mapper.Map<UIMessage, BLLMessage>(message));
            return this.RedirectToAction("Index");
        }

        // GET: /Message/
        public ActionResult Index()
        {
            var myId = this.userService.GetIdByUsername(this.User.Identity.Name);
            var view =
                Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(this.messageService.GetUserLastMessages(myId));
            this.ViewBag.CurrentUserId = myId;

            return this.View(view);
        }

        [HttpGet]
        public ActionResult SendMessage(int Id)
        {
            return this.View(new UIMessage());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowUserMessages(int Id)
        {
            var view = Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(this.messageService.GetUserLastMessages(Id));
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            

            return this.View(view);
        }

        protected override void Dispose(bool disposing)
        {
            this.messageService.Dispose();
            this.userService.Dispose();
            base.Dispose(disposing);
        }
    }
}