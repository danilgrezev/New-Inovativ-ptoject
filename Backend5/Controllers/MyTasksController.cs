using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend5.Data;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class MyTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyTasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Task.Include(m => m.Geo).Include(m => m.Insurance).Include(m => m.TaskType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTask = await _context.Task
                .Include(m => m.Geo)
                .Include(m => m.Insurance)
                .Include(m => m.TaskType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // GET: MyTasks/Create
        public IActionResult Create()
        {
            ViewData["GeoId"] = new SelectList(_context.Geos, "Id", "Id");
            ViewData["InsuranceId"] = new SelectList(_context.Insurances, "Id", "Code");
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id");
            return View();
        }

        // POST: MyTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,Text,Status,Priority,ExecutionTime,ApplyingTime,InsuranceId,TaskTypeId,ClientId,EmployeeId,GeoId")] MyTask myTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeoId"] = new SelectList(_context.Geos, "Id", "Id", myTask.GeoId);
            ViewData["InsuranceId"] = new SelectList(_context.Insurances, "Id", "Code", myTask.InsuranceId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id", myTask.TaskTypeId);
            return View(myTask);
        }

        // GET: MyTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTask = await _context.Task.SingleOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }
            ViewData["GeoId"] = new SelectList(_context.Geos, "Id", "Id", myTask.GeoId);
            ViewData["InsuranceId"] = new SelectList(_context.Insurances, "Id", "Code", myTask.InsuranceId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id", myTask.TaskTypeId);
            return View(myTask);
        }

        // POST: MyTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,Text,Status,Priority,ExecutionTime,ApplyingTime,InsuranceId,TaskTypeId,ClientId,EmployeeId,GeoId")] MyTask myTask)
        {
            if (id != myTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTaskExists(myTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeoId"] = new SelectList(_context.Geos, "Id", "Id", myTask.GeoId);
            ViewData["InsuranceId"] = new SelectList(_context.Insurances, "Id", "Code", myTask.InsuranceId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Id", myTask.TaskTypeId);
            return View(myTask);
        }

        // GET: MyTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTask = await _context.Task
                .Include(m => m.Geo)
                .Include(m => m.Insurance)
                .Include(m => m.TaskType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // POST: MyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myTask = await _context.Task.SingleOrDefaultAsync(m => m.Id == id);
            _context.Task.Remove(myTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyTaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
