using Microsoft.AspNetCore.Mvc;
using MVCMonolitico.Models;
using MVCMonolitico.Models.Entities;
using MVCMonolitico.Models.Services.Interfaces;
using System.Diagnostics;

namespace MVCMonolitico.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IItemService _itemService;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, 
            IItemService itemService, IUserService userService)
        {
            _logger = logger;
            _itemService = itemService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewData["Users"]=_userService.GetAll();
            return View();
        }


        [HttpPost]
        public IActionResult SaveUser([Bind("Name", "Email", "Password")] User user) { 
            int result = _userService.Insert(user);
            
            return RedirectToAction("Index");

        }

        public IActionResult DeleteUser([FromQuery] int id) { 
            int result=_userService.Delete(id);
            return RedirectToAction("Index");
        }





        

        
    }
}
