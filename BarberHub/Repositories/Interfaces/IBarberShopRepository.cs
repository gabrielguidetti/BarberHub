using BarberHub.Models;

namespace BarberHub.Repositories.Interfaces
{
    public interface IBarberShopRepository
    {
        BarberShop GetByUser(int userId);
    }
}
