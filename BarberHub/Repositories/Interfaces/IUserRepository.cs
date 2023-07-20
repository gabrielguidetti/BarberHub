using BarberHub.Models;

namespace BarberHub.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Login(string email, string password);
    }
}
