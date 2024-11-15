using Microsoft.AspNetCore.Mvc;
using MVCMonolitico.Models.Entities;
using MVCMonolitico.Models.Services.Interfaces;

namespace MVCMonolitico.Controllers
{
    public class ItemController : Controller
    {

        private readonly IItemService _itemService;

        public ItemController(IItemService itemService) { 
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            ViewData["Items"] = _itemService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SaveItem([Bind("Name", "Description", "Brand")] Item item) {
            var result = _itemService.Insert(item);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem([FromQuery] int id) { 
            var result=_itemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
