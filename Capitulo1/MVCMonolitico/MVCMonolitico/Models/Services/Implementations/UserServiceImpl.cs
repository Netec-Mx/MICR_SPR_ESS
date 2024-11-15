using MVCMonolitico.Models.Data.Repositories;
using MVCMonolitico.Models.Entities;
using MVCMonolitico.Models.Services.Interfaces;

namespace MVCMonolitico.Models.Services.Implementations
{
    public class UserServiceImpl : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserServiceImpl(UserRepository userRepository) { 
           _userRepository = userRepository;
        }
        

        public int Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public int Insert(User user)
        {
            return _userRepository.Insert(user);
        }
    }
}
