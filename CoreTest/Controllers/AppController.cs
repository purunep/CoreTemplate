using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Services;
using CoreTest.ViewModels;
using CoreTest.Data;
using Microsoft.AspNetCore.Authorization;

namespace CoreTest.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly ICoreRepository _repository;
     
        public AppController(IMailService mailService, ICoreRepository repository)
        {
          _mailService = mailService;
           _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

       [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel contactModel)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("youremail@contact.com","Welcome",
                    $"Name:{contactModel.Name} Email: {contactModel.Email}");
                ViewBag.Message = "Mail Sent";
                ModelState.Clear();
            } 
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }
    }
}
