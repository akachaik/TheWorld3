using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace TheWorld3.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _worldContext;
        public WorldContextSeedData(WorldContext worldContext)
        {
            _worldContext = worldContext;
        }

		public void EnsureSeedData()
        {
			if(!_worldContext.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>
                    {
                        new Stop { Name = "New York"  }
                    }
                };

                _worldContext.Trips.Add(usTrip);
                _worldContext.Stops.AddRange(usTrip.Stops);
                _worldContext.SaveChanges();
            }
        }

    }

}



