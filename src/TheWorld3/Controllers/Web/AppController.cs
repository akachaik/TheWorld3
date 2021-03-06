﻿using Microsoft.AspNet.Authorization;
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
        private IWorldRepository _repository;

        public AppController(IMailService mailService, IWorldRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            var trips = _repository.GetAllTrips();
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
