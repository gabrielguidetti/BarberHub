﻿using BarberHub.Models;

namespace BarberHub.Repositories.Interfaces
{
    public interface IBarberRepository
    {
        Barber Add(Barber model);
        Barber Update(Barber model);
        Barber Get(int id);
    }
}
