using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Services;
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
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IUserService userService;


        public MessageController(IMessageService messageService, IUserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;

        }

        //
        // GET: /Message/

        public ActionResult Index()
        {
            var myId = userService.GetIdByUsername(User.Identity.Name);
            var view = Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(messageService.GetUserLastMessages(myId));
            ViewBag.CurrentUserId = myId;

            return View(view);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowUserMessages(int Id)
        {            
            var view = Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(messageService.GetUserLastMessages(Id));
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name); ;

            return View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AdminDetails(int Id)
        {
            var message=messageService.GetByIdMessage(Id);       
            var view = Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(messageService.GetUserToUserMessages(message.SenderId, message.ReceiverId));            
            return View(view);
        }
        

        [HttpGet]
        public ActionResult SendMessage(int Id)
        {
            
            return View(new UIMessage());
        }


        [HttpGet]
        public ActionResult Details(int Id)
        {
            var myId = userService.GetIdByUsername(User.Identity.Name);
            var view = Mapper.Map<IEnumerable<BLLMessage>, List<UIMessage>>(messageService.GetUserToUserMessages(myId, Id));
            ViewBag.CurrentUserId = myId;
            ViewBag.OtherUserId = Id;
            return View(view);
        }

        [HttpPost]
        public ActionResult Details(UIMessage message)
        {
            message.Id = 0;
            message.MessageSendingTime = DateTime.Now;
            messageService.SendMessage(Mapper.Map<UIMessage, BLLMessage>(message));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CorrectMessage(int Id)
        {

            return View(Mapper.Map<BLLMessage, UIMessage>(messageService.GetByIdMessage(Id)));
        }

        [HttpPost]
        public ActionResult CorrectMessage(UIMessage message)
        {
            messageService.CorrectMessage(Mapper.Map<UIMessage, BLLMessage>(message));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMessage(int Id)
        {
            messageService.DeleteMessage(Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            messageService.Dispose();            
            userService.Dispose();            
            base.Dispose(disposing);
        }

    }
}
