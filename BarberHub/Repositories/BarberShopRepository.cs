﻿using BarberHub.Models;
using BarberHub.ProjectSettings;
using BarberHub.Repositories.Interfaces;

namespace BarberHub.Repositories
{
    public class BarberShopRepository : IBarberShopRepository
    {
        private AppDbContext _context;

        public BarberShopRepository(AppDbContext context)
        {
            _context =  context;
        }

        public BarberShop Add(BarberShop model)
        {
            _context.BarberShops.Add(model);
            _context.SaveChanges();
            return model;
        }

        public BarberShop GetByUser(int userId)
        {
            var result = _context.BarberShops.FirstOrDefault(x => x.UserId == userId);

            if (result == null)
                return null;

            return result;
        }
    }
}