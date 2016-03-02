using Microsoft.AspNet.Mvc;
using System;
using TheWorld3.Services;
using TheWorld3.ViewModels;

namespace TheWorld3.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            _mailService.SendMail("", "", model.Message);
            return View();

        }
    }
}
