using Microsoft.EntityFrameworkCore;
using MVCMonolitico.Models.Entities;

namespace MVCMonolitico.Models.Data.Repositories
{
    public class UserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext dbContext) { 
             _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }


        public int Insert(User user) { 
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();    
        }

        public int Delete(int id) {
            var user= _dbContext.Users.Find(id);
            if (user!=null) {
                _dbContext.Users.Remove(user);
                return _dbContext.SaveChanges() ;
            }

            throw new Exception($"El usuario {id} no existe!!!!!");
        }

        public List<User> GetAll() { 
           return _dbContext.Users.ToList();
        }



       
    }
}
