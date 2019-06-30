using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Data;
using Backend5.Models;
using Backend5.Models.MyViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Controllers
{
    public class FTaskController : Controller
    {

        private readonly ApplicationDbContext _context;


        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

       

        public FTaskController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).ToListAsync();
            //var d = 4;
            return View(new TaskOneIdViewModel() {
                L=m
            });
        }

        public async Task<IActionResult> GetOne(TaskOneIdViewModel model)
        {
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id== model.Id);
           // var d = 4;
            return View(m);
        }

        public async Task<IActionResult> Apply(MyTask model)
        {
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == model.Id);

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            m.EmployeeId = user.Id;
            _context.Update(model);
            await _context.SaveChangesAsync();

            //var d = 4;
            return View(m);
        }
    }
}