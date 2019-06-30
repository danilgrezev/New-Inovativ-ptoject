using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Controllers
{
    public class FTaskController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).ToListAsync();
            var d = 4;
            return View(m);
        }


        public async Task<IActionResult> GetOne(Int32 id)
        {
            var m = await this._context.Task
                .Include(x => x.Geo)
                .Include(x => x.Client).FirstOrDefaultAsync(x => x.Id==id);
            var d = 4;
            return View(m);
        }
    }
}