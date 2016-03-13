using Microsoft.AspNet.Mvc;
using System;
using TheWorld3.Models;

namespace TheWorld3.Controllers.Api
{
    [Route("api/trips")]
    public class TripContrller : Controller
    {
        private IWorldRepository _repository;

        public TripContrller(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repository.GetAllTripsWithStops();
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]Trip newTrip)
        {
            return Json(true);
        }
    }
}
