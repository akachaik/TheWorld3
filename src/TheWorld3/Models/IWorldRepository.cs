﻿using System.Collections.Generic;

namespace TheWorld3.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
    }
}