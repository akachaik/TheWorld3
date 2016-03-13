using AutoMapper;
using Microsoft.AspNet.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TheWorld3.Models;
using TheWorld3.VieweModels;

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
            var results = Mapper.Map<IEnumerable<TripViewModel>>(_repository.GetAllTripsWithStops());
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip>(vm);

                // Save to database

                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(Mapper.Map<TripViewModel>(newTrip));
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Failed", modelState = ModelState });
        }
    }
}
