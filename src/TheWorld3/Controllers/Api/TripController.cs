using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private ILogger<TripContrller> _logger;
        private IWorldRepository _repository;

        public TripContrller(IWorldRepository repository, ILogger<TripContrller> logger)
        {
            _repository = repository;
            _logger = logger;
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
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(vm);

                    // Save to database
                    _logger.LogInformation("Attemping to save a new trip");
                    _repository.AddTrip(newTrip);

                    if(_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<TripViewModel>(newTrip));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new trip", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });

            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Failed", modelState = ModelState });
        }
    }
}
