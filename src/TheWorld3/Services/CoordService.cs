using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TheWorld3.Services
{
    public class CoordService
    {
        private ILogger<CoordService> _logger;

        public CoordService(ILogger<CoordService> logger)
        {
            _logger = logger;
        }
        public CoorServiceResult Lookup(string location)
        {
            var result = new CoorServiceResult
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            // https://www.microsoft.com/maps/create-a-bing-maps-key.aspx
            var bingKey = Startup.Configuration["AppSettings:BingKey"];

            var encodedName = WebUtility.UrlEncode(location);

            //var url = "http://dev.virtualearth.net/REST";


            return result;
        }

    }

    public class CoorServiceResult
    {
        public bool Success { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Message { get; set; }

    }
}
