using BarberHub.ViewModel;

namespace BarberHub.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel ValidableLogin(UserViewModel model);
        UserViewModel Add(UserViewModel model);
    }
}
