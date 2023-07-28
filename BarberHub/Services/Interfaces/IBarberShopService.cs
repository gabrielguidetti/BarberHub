using BarberHub.ViewModel;

namespace BarberHub.Services.Interfaces
{
    public interface IBarberShopService
    {
        BarberShopViewModel GetByUser(int userId);
    }
}
