using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using TheWorld3.Models;
using TheWorld3.Services;
using TheWorld3.ViewModels;

namespace TheWorld3.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private WorldContext _worldContext;

        public AppController(IMailService mailService, WorldContext worldContext)
        {
            _mailService = mailService;
            _worldContext = worldContext;
        }
        public IActionResult Index()
        {
            var trips = _worldContext.Trips.OrderBy(t => t.Name).ToList();
            return View(trips);
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
