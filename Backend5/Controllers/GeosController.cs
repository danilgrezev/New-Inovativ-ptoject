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
    public class GeosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Geos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Geos.ToListAsync());
        }

        // GET: Geos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geo = await _context.Geos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (geo == null)
            {
                return NotFound();
            }

            return View(geo);
        }

        // GET: Geos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Geos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,Country,District")] Geo geo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geo);
        }

        // GET: Geos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geo = await _context.Geos.SingleOrDefaultAsync(m => m.Id == id);
            if (geo == null)
            {
                return NotFound();
            }
            return View(geo);
        }

        // POST: Geos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Country,District")] Geo geo)
        {
            if (id != geo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeoExists(geo.Id))
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
            return View(geo);
        }

        // GET: Geos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geo = await _context.Geos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (geo == null)
            {
                return NotFound();
            }

            return View(geo);
        }

        // POST: Geos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var geo = await _context.Geos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Geos.Remove(geo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeoExists(int id)
        {
            return _context.Geos.Any(e => e.Id == id);
        }
    }
}
