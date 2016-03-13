using Microsoft.AspNet.Mvc;
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
            var results = _repository.GetAllTripsWithStops();
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel newTrip)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Failed", modelState = ModelState });
        }
    }
}
