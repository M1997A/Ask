using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ask.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUser> userManager;
        public UserController(UserManager<AppUser> userMngr)
        {
            userManager = userMngr;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Profile(string UserId)
        {
            if(UserId != null)
            {
                var user = userManager.FindByIdAsync(UserId).Result;
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
