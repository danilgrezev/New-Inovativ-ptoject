﻿using System;
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
            try
            {
                var userforid = await this.userManager.GetUserAsync(this.HttpContext.User);
                ViewData["F"] = userforid.UserTypeId;
            }
            catch { }
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).Where(x=>x.Status=="Новый").ToListAsync();
            return View(new TaskOneIdViewModel() {
                L=m
            });
        }

        public async Task<IActionResult> GetOne(TaskOneIdViewModel model)
        {
            try
            {
                var userforid = await this.userManager.GetUserAsync(this.HttpContext.User);
                ViewData["F"] = userforid.UserTypeId;
            }
            catch { }
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id== model.Id);
            return View(m);
        }

        public async Task<IActionResult> Apply(MyTask model)
        {
            try
            {
                var userforid = await this.userManager.GetUserAsync(this.HttpContext.User);
                ViewData["F"] = userforid.UserTypeId;
            }
            catch { }
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == model.Id);

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            m.EmployeeId = user.Id;
            m.Status = "В работе";
            _context.Update(m);
            await _context.SaveChangesAsync();

            return this.Redirect("/Home/Index");
        }
    }
}