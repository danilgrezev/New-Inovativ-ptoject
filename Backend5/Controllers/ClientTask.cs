﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Data;
using Backend5.Models;
using Backend5.Models.MyViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Controllers
{
    public class ClientTaskController : Controller
    {

        private readonly ApplicationDbContext _context;


        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;



        public ClientTaskController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            ViewData["F"] = user.UserTypeId;
            var m = await this._context.Task.Where(x => x.ClientId == user.Id).ToListAsync();
            return View(new TaskOneIdViewModel() { L=m});
        }


        public async Task<IActionResult> Delete(TaskOneIdViewModel model)
        {
            var m = await this._context.Task
              .Include(x => x.Geo)
              .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == model.Id);

            m.Status = "Отозвано";
            _context.Update(m);
            await _context.SaveChangesAsync();

            return this.Redirect("/Home/Index");
        }

        public async Task<IActionResult> Create()
        {
            var fff = await this._context.TaskTypes.Select(x => x.Type).ToListAsync();

            List<SelectListItem> l = new List<SelectListItem>();
            for (int i = 0; i < fff.Count; i++)
            {
                l.Add(new SelectListItem() { Text = fff[i], Value = i.ToString() });
            }

            this.ViewBag.TaskTypeId = new SelectList(l, "Value", "Text");

            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateTaskModel m)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            _context.Add(new MyTask() {
                Header = m.Header,
                Price=m.Price,
                ClientId= user.Id,
                GeoId=1,
                Priority=1,
                Status = "Новый",
                TaskTypeId=Int32.Parse(m.TaskTypeId)+1,
                Text=m.Text
            });
            await _context.SaveChangesAsync();
            return Redirect("/FTask");
        }

        /*  public async Task<IActionResult> GetOne(TaskOneIdViewModel model)
          {
              var m = await this._context.Task
                  .Include(x => x.Geo)
                  .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == model.Id);
              return View(m);
          }

          public async Task<IActionResult> Apply(MyTask model)
          {
              var m = await this._context.Task
                  .Include(x => x.Geo)
                  .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == model.Id);

              var user = await this.userManager.GetUserAsync(this.HttpContext.User);

              m.EmployeeId = user.Id;
              m.Status = "В работе";
              _context.Update(m);
              await _context.SaveChangesAsync();

              return this.Redirect("/Home/Index");
          }*/
    }
}