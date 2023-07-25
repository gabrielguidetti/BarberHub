using AutoMapper;
using BarberHub.Models;
using BarberHub.Repositories.Interfaces;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;

namespace BarberHub.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper)
        {
            UserRepository = userRepository;
            _mapper = mapper;
        }

        public UserViewModel ValidableLogin(UserViewModel model)
        {
            if (model.Email is null || model.Password is null)
                return null;

            var result = UserRepository.Login(model.Email, model.Password);

            if(result == null)
                return null;

            return _mapper.Map<UserViewModel>(result);
        }

        public UserViewModel Add(UserViewModel model)
        {
            if (model.FirstName is null ||
               model.LastName is null ||
               model.Email is null ||
               model.Password is null ||
               model.ConfirmPassword is null)
                return null;

            if(model.Password != model.ConfirmPassword)
                return null;

            var result = UserRepository.Add(_mapper.Map<User>(model));

            return _mapper.Map<UserViewModel>(result);
        }
    }
}
