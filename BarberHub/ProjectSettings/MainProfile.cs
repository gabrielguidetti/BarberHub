using AutoMapper;
using BarberHub.Models;
using BarberHub.ViewModel;

namespace BarberHub.ProjectSettings
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap();

            CreateMap<BarberShop, BarberShopViewModel>()
                .ReverseMap();

            CreateMap<Barber, BarberViewModel>()
                .ReverseMap();
        }
    }
}
