using MVCMonolitico.Models.Entities;

namespace MVCMonolitico.Models.Services.Interfaces
{
    public interface IUserService
    {
        public int Insert(User user);
        public int Delete(int id);
        public List<User> GetAll();

    }
}
