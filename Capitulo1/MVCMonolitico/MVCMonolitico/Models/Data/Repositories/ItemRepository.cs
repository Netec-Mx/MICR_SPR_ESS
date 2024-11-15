using MVCMonolitico.Models.Entities;

namespace MVCMonolitico.Models.Data.Repositories
{
    public class ItemRepository
    {
        private readonly AppDBContext _dbContext;

        public ItemRepository(AppDBContext dbContext) { 
             _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }


        public int Insert(Item item) { 
            _dbContext.Items.Add(item);
            return _dbContext.SaveChanges();    
        }

        public int Delete(int id) {
            var item = _dbContext.Items.Find(id);
            if (item!=null) { 
                _dbContext.Items.Remove(item);
                return _dbContext.SaveChanges();
            }

            throw new Exception($"el item {id} no existe!!!");
        }


        public List<Item> GetAll() { 
           return _dbContext.Items.ToList();
        }




    }
}
