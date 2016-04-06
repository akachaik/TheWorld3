using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace TheWorld3.Models
{
    public class WorldContextSeedData
    {
        private UserManager<WorldUser> _userManager;
        private WorldContext _worldContext;
        public WorldContextSeedData(WorldContext worldContext, UserManager<WorldUser> userManager)
        {
            _worldContext = worldContext;
            _userManager = userManager;
        }

		public async Task EnsureSeedDataAsync()
        {
            if(await _userManager.FindByEmailAsync("sam.hastings@theworld.com") == null)
            {
                var newUser = new WorldUser
                {
                    UserName = "samhastings",
                    Email = "sam.hastings@theworld.com"
                };
                await _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }

			if(!_worldContext.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "samhastings",
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



