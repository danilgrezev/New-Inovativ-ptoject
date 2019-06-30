using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Data;
using Backend5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend5.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;


        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;



        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.HttpContext.User);
                ViewData["F"] = user.UserTypeId;
            }
            catch { }

            return this.View();
        }

        public IActionResult Error()
        {
            return this.View();
        }
    }
}
