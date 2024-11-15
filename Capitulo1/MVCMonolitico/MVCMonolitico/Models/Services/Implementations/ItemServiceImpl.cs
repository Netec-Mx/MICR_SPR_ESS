using MVCMonolitico.Models.Data.Repositories;
using MVCMonolitico.Models.Entities;
using MVCMonolitico.Models.Services.Interfaces;

namespace MVCMonolitico.Models.Services.Implementations
{
    public class ItemServiceImpl : IItemService
    {
        private readonly ItemRepository _itemRepository;

        public ItemServiceImpl(ItemRepository itemRepository) { 
           _itemRepository = itemRepository;
        }


        public int Delete(int id)
        {
          return  _itemRepository.Delete(id);
        }

        public List<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public int Insert(Item item)
        {
          return  _itemRepository.Insert(item);
        }
    }

}
