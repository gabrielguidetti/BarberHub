using AutoMapper;
using BarberHub.Repositories.Interfaces;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;

namespace BarberHub.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }

        public UserViewModel ValidableLogin(UserViewModel model)
        {
            if (model.Email is not null || model.Password is not null)
                return null;

            var result = _repository.Login(model.Email, model.Password);

            if(result == null)
                return null;

            return _mapper.Map<UserViewModel>(result);
        }
    }
}
