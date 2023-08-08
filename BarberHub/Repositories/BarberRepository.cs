using BarberHub.Models;
using BarberHub.ProjectSettings;
using BarberHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private AppDbContext _context;

        public BarberRepository(AppDbContext context)
        {
            _context = context;
        }

        public Barber Add(Barber model)
        {
            _context.Barbers.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Barber Get(int id)
        {
            return _context.Barbers.FirstOrDefault(x => x.Id == id);
        }

        public Barber Update(Barber model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
    }
}
