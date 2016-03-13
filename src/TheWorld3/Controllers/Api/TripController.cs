using Microsoft.AspNet.Mvc;
using System;
using TheWorld3.Models;

namespace TheWorld3.Controllers.Api
{
    public class TripContrller : Controller
    {
        private IWorldRepository _repository;

        public TripContrller(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/trips")]
        public JsonResult Get()
        {
            var results = _repository.GetAllTripsWithStops();
            return Json(results);
        }
    }
}
