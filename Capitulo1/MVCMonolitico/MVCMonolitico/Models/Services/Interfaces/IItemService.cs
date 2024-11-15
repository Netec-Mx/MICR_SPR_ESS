using MVCMonolitico.Models.Entities;

namespace MVCMonolitico.Models.Services.Interfaces
{
    public interface IItemService
    {
        public int Insert(Item item);
        public int Delete(int id);

        public List<Item> GetAll();
    }
}
