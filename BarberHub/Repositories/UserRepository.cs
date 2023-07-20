using BarberHub.Models;
using BarberHub.ProjectSettings;
using BarberHub.Repositories.Interfaces;

namespace BarberHub.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Login(string email, string password)
        {
            var result = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            return result;
        }
    }
}
