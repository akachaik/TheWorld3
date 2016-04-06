using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TheWorld3.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}